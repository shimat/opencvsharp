using System;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCvSharp.Blob;

namespace OpenCvSharp.Test
{
    [TestClass]
    public class BlobTest
    {
        [TestMethod]
        [DeploymentItem(@"OpenCV\", "")]
        public void CheckPlatform()
        {
            Assert.Inconclusive("My platform is {0}", IntPtr.Size == 8 ? "x64" : "x86");
        }

        [TestMethod]
        [DeploymentItem(@"Image\Blob\")]
        [DeploymentItem(@"OpenCV\", "")]
        public void SimpleTest()
        {
            using (var src = new IplImage("shapes2.png", LoadMode.GrayScale))
            using (var binary = new IplImage(src.Size, BitDepth.U8, 1))
            using (var render = new IplImage(src.Size, BitDepth.U8, 3))
            {
                Cv.Threshold(src, binary, 0, 255, ThresholdType.Otsu);

                var blobs = new CvBlobs(binary);
                blobs.RenderBlobs(src, render);
                using (new CvWindow(render))
                {
                    Cv.WaitKey();
                }
            }
        }

        [TestMethod]
        [DeploymentItem(@"Image\Blob\")]
        [DeploymentItem(@"OpenCV\", "")]
        public void NewEqualsOld1()
        {
            using (var img = new IplImage("shapes1.png", LoadMode.GrayScale))
            {
                CompareBlob(img);
                CompareRendering(img);
                CompareLabelImage(img);
            }
        }

        [TestMethod]
        [DeploymentItem(@"Image\Blob\")]
        [DeploymentItem(@"OpenCV\", "")]
        public void NewEqualsOld2()
        {
            using (var img = new IplImage("shapes2.png", LoadMode.GrayScale))
            {
                CompareBlob(img);
                CompareRendering(img);
                CompareLabelImage(img);
            }
        }

        [TestMethod]
        [DeploymentItem(@"Image\Blob\")]
        [DeploymentItem(@"OpenCV\", "")]
        public void NewEqualsOld2WithRoi()
        {
            using (var img = new IplImage("shapes2.png", LoadMode.GrayScale))
            {
                img.ROI = new CvRect(100, 40, 700, 160);
                CompareBlob(img, false);
                CompareRendering(img);
                CompareLabelImage(img);
            }
        }

        [TestMethod]
        [DeploymentItem(@"Image\Blob\")]
        [DeploymentItem(@"OpenCV\", "")]
        public void NewEqualsOld3()
        {
            using (var img = new IplImage("shapes3.png", LoadMode.GrayScale))
            {
                CompareBlob(img);
                CompareRendering(img);
                CompareLabelImage(img);
            }
        }



        private void CompareBlob(IplImage src, bool comapresLabel = true)
        {
            IplImage binary;
            // old labeling
            IplImage labelsOld;
            Blob.Old.CvBlobs blobsOld; 
            // new labeling
            LabelData labelsNew;
            CvBlobs blobsNew;

            // Execute Labeling
            Label(src, out binary, out labelsOld, out labelsNew, out blobsOld, out blobsNew);

            // compare labels value
            if(comapresLabel)
            unsafe
            {
                byte* p1 = (byte*) labelsOld.ImageDataPtr;
                fixed (int* p2 = &labelsNew.Values[0, 0])
                {
                    int length = src.Width * src.Height;
                    int[] array1 = new int[length];
                    int[] array2 = new int[length];
                    Marshal.Copy(new IntPtr(p1), array1, 0, length);
                    Marshal.Copy(new IntPtr(p2), array2, 0, length);
                    array1.SequenceEqual(array2).IsTrue();
                }
            }

            // compare blobs
            blobsOld.Count.Is(blobsNew.Count);
            var keys1 = blobsOld.Keys.ToArray();
            var keys2 = blobsNew.Keys.ToArray();
            for (int i = 0; i < blobsNew.Count; i++)
            {
                // label equality
                var key1 = keys1[i];
                var key2 = keys2[i];
                ((int) key1).Is(key2);

                // value equality
                var val1 = blobsOld[key1];
                var val2 = blobsNew[key2];
                (val1.Centroid).Is(val2.Centroid);
                (val1.Rect).Is(val2.Rect);
                ((int) val1.Area).Is(val2.Area);
                (val1.M10).Is(val2.M10);
                (val1.M01).Is(val2.M01);
                (val1.M11).Is(val2.M11);
                (val1.M20).Is(val2.M20);
                (val1.M02).Is(val2.M02);
                (val1.U11).Is(val2.U11);
                (val1.U20).Is(val2.U20);
                (val1.U02).Is(val2.U02);
            }
            blobsOld.Dispose();
            labelsOld.Dispose();
        }

        private void CompareRendering(IplImage src)
        {
            IplImage binary;
            // old labeling
            IplImage labelsOld;
            Blob.Old.CvBlobs blobsOld;
            // new labeling
            LabelData labelsNew;
            CvBlobs blobsNew;

            // Execute Labeling
            Label(src, out binary, out labelsOld, out labelsNew, out blobsOld, out blobsNew);

            using (IplImage renderOld = new IplImage(src.Size, BitDepth.U8, 3))
            using (IplImage renderNew = new IplImage(src.Size, BitDepth.U8, 3))
            {
                renderOld.ROI = src.ROI;
                renderNew.ROI = src.ROI;

                blobsOld.RenderBlobs(labelsOld, binary, renderOld);
                blobsNew.RenderBlobs(binary, renderNew);
                CvWindow.ShowImages(renderOld, renderNew);
                IsSameImage(renderOld, renderNew);
            }

            blobsOld.Dispose();
            labelsOld.Dispose();
        }

        private void CompareLabelImage(IplImage src)
        {
            IplImage binary;
            // old labeling
            IplImage labelsOld;
            Blob.Old.CvBlobs blobsOld;
            // new labeling
            LabelData labelsNew;
            CvBlobs blobsNew;

            // Execute Labeling
            Label(src, out binary, out labelsOld, out labelsNew, out blobsOld, out blobsNew);

            using (IplImage filterOld = new IplImage(src.Size, BitDepth.U8, 1))
            using (IplImage filterNew = new IplImage(src.Size, BitDepth.U8, 1))
            {
                blobsOld.FilterLabels(labelsOld, filterOld);
                blobsNew.FilterLabels(filterNew); 
                CvWindow.ShowImages(filterOld, filterNew);
                IsSameImage(filterOld, filterNew);
            }
            
        }

        private void Label(IplImage src, out IplImage binary,
                           out IplImage labelsOld, out LabelData labelsNew,
                           out Blob.Old.CvBlobs blobsOld, out CvBlobs blobsNew)
        {
            binary = new IplImage(src.Size, BitDepth.U8, 1);
            binary.ROI = src.ROI;

            Cv.Threshold(src, binary, 0, 255, ThresholdType.Otsu);

            // old labeling
            labelsOld = new IplImage(src.Width, src.Height, BitDepth.F32, 1);
            blobsOld = new OpenCvSharp.Blob.Old.CvBlobs(binary, labelsOld);

            // new labeling
            blobsNew = new CvBlobs(binary);
            labelsNew = blobsNew.Labels;
        }

        private void IsSameImage(IplImage img1, IplImage img2)
        {
            img1.ROI.Is(img2.ROI);
            img1.Depth.Is(img2.Depth);
            img1.NChannels.Is(img2.NChannels);

            CvRect roi = img1.ROI;
            for (int y = roi.Top; y < roi.Bottom; y++)
            {
                for (int x = roi.Left; x < roi.Right; x++)
                {
                    img1[y, x].Is(img2[y, x], 
                        String.Format("Pixel comparison failed at ({0},{1})", x, y));
                }
            }
        }
    }
}

