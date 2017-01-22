using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace OpenCvSharp.Tests.Calib3D
{
    [TestFixture]
    public class StereoBMTest
    {
        [OneTimeSetUp]
        public void Init()
        {
            var workDirectory = Path.Combine(TestContext.CurrentContext.WorkDirectory, "win10-x64");
            Directory.SetCurrentDirectory(workDirectory);
        }

        [Test]
        public void SimpleCompute()
        {
            var left = new Mat("Image/tsukuba_left.png", ImreadModes.GrayScale);
            var right = new Mat("Image/tsukuba_right.png", ImreadModes.GrayScale);

            var sbm = StereoBM.Create();
            var disparity = new Mat();
            sbm.Compute(left, right, disparity);

            /*
            double min, max;
            Cv2.MinMaxLoc(disparity, out min, out max);

            var disparityU8 = new Mat();
            disparity.ConvertTo(disparityU8, MatType.CV_8UC1, 255 / (max - min), -255 * min / (max - min));
            Window.ShowImages(disparityU8);
            //*/
        }
    }
}

