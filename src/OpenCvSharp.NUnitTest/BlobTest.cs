using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Core;
using NUnit.Framework;
using OpenCvSharp.Blob;

namespace OpenCvSharp.NUnitTest
{
    [TestFixture]
    public class BlobTest
    {
        [Test]
        public void CheckPlatform()
        {
            Assert.Inconclusive("My platform is {0}", IntPtr.Size == 8 ? "x64" : "x86");
        }
        
        [Test]
        public void SimpleTest()
        {
            using (var src = new IplImage(@"Image\Blob\shapes2.png", LoadMode.GrayScale))
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
        
        [Test]
        public void NewEqualsOld1()
        {
            using (var img = new IplImage(@"Image\Blob\shapes1.png", LoadMode.GrayScale))
            {
                CompareBlob(img);
                CompareRendering(img);
                CompareLabelImage(img);
            }
        }
        
        [Test]
        public void NewEqualsOld2()
        {
            using (var img = new IplImage(@"Image\Blob\shapes2.png", LoadMode.GrayScale))
            {
                CompareBlob(img);
                CompareRendering(img);
                CompareLabelImage(img);
            }
        }
        
        [Test]
        public void NewEqualsOld3()
        {
            using (var img = new IplImage(@"Image\Blob\shapes3.png", LoadMode.GrayScale))
            {
                CompareBlob(img);
                CompareRendering(img);
                CompareLabelImage(img);
            }
        }
        
        public void DebugShowOldLabel(IplImage oldLabels)
        {
            using (IplImage img = new IplImage(oldLabels.Size, BitDepth.U8, 1))
            {
                img.Zero();
                for (int r = 0; r < img.Height; r++)
                {
                    for (int c = 0; c < img.Width; c++)
                    {
                        try
                        {
                            if (oldLabels[r, c] != 0)
                                img[r, c] = 255;
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                CvWindow.ShowImages("old", img);
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
            //DebugShowOldLabel(labelsOld);
            //labelsNew.DebugShow();
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

            binary.Dispose();
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
                //CvWindow.ShowImages(renderOld, renderNew);
                IsSameImage(renderOld, renderNew);
            }

            binary.Dispose();
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
                //CvWindow.ShowImages(filterOld, filterNew);
                IsSameImage(filterOld, filterNew);
            }

            binary.Dispose();
            blobsOld.Dispose();
            labelsOld.Dispose();
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
            if (img1.NChannels == 1)
            {
                (img1 - img2).CountNonZero().Is(0);
            }
            else if (img1.NChannels == 3)
            {
                using (IplImage imgB1 = new IplImage(roi.Size, BitDepth.U8, 1))
                using (IplImage imgG1 = new IplImage(roi.Size, BitDepth.U8, 1))
                using (IplImage imgR1 = new IplImage(roi.Size, BitDepth.U8, 1))
                using (IplImage imgB2 = new IplImage(roi.Size, BitDepth.U8, 1))
                using (IplImage imgG2 = new IplImage(roi.Size, BitDepth.U8, 1))
                using (IplImage imgR2 = new IplImage(roi.Size, BitDepth.U8, 1))
                {
                    Cv.Split(img1, imgB1, imgG1, imgR1, null);
                    Cv.Split(img2, imgB2, imgG2, imgR2, null);
                    (imgB1 - imgB2).CountNonZero().Is(0);
                    (imgG1 - imgG2).CountNonZero().Is(0);
                    (imgR1 - imgR2).CountNonZero().Is(0);
                }
            }
            else
            {
                Assert.Fail();
            }

            /*
            CvRect roi = img1.ROI;
            //for (int y = roi.Top; y < roi.Bottom; y++)
            for (int y = 0; y < roi.Height; y++)
            {
                //for (int x = roi.Left; x < roi.Right; x++)
                for (int x = 0; x < roi.Width; x++)
                {
                    try
                    {
                        File.AppendAllText(@"C:\Users\Hoge\Desktop\coord.txt", String.Format("({0}, {1})\n", x, y));
                        //img1[y, x].Is(img2[y, x],
                        //    String.Format("Pixel comparison failed at ({0},{1})", x, y));
                    }
                    catch(Exception ex)
                    {
                        File.AppendAllText(@"C:\Users\Hoge\Desktop\coord.txt", ex.ToString());
                        throw;
                    }
                }
            }*/
        }
    }
}

