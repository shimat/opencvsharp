using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCvSharp.Blob;

namespace OpenCvSharp.Test
{
    [TestClass]
    public class BlobTest
    {
        [TestMethod]
        [DeploymentItem(@"OpenCV\opencv_core245.dll")]
        [DeploymentItem(@"OpenCV\opencv_highgui245.dll")]
        [DeploymentItem(@"OpenCV\opencv_imgproc245.dll")]
        public void CheckPlatform()
        {
            Assert.Inconclusive("My platform is {0}", IntPtr.Size == 8 ? "x64" : "x86");
        }

        [TestMethod]
        [DeploymentItem(@"Image\Blob\shapes.png")]
        [DeploymentItem(@"OpenCV\opencv_core245.dll")]
        [DeploymentItem(@"OpenCV\opencv_highgui245.dll")]
        [DeploymentItem(@"OpenCV\opencv_imgproc245.dll")]
        public void TestMethod1()
        {
            using (var src = new IplImage("shapes.png", LoadMode.GrayScale))
            using (var binary = new IplImage(src.Size, BitDepth.U8, 1))
            //using (var label = new IplImage(src.Size, BitDepth.S32, 1))
            using (var render = new IplImage(src.Size, BitDepth.U8, 3))
            {
                Cv.Threshold(src, binary, 0, 255, ThresholdType.Otsu);

                int[,] labels = new int[src.Height, src.Width];
                var blobs = new CvBlobs(binary, labels);
                blobs.RenderBlobs(label, src, render);
                blobs.ToString();
                using (new CvWindow(render))
                {
                    Cv.WaitKey();
                }
            }
            Assert.Inconclusive();
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.Inconclusive();
        }
    }
}
