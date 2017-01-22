using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace OpenCvSharp.Tests.Calib3D
{
    [TestFixture]
    public class StereoSGBMTest
    {
        [Test]
        public void New()
        {
            var sgbm = StereoSGBM.Create(10, 100, 16);
            sgbm.Dispose();
        }
    }
}

