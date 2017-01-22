using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace OpenCvSharp.Tests.Calib3D
{
    [TestFixture]
    public class StereoBMTest
    {
        [Test]
        public void New()
        {
            var sbm = StereoBM.Create(16, 15);
            sbm.Dispose();
        }
    }
}

