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
        
    }
}

