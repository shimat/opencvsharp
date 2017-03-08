using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace OpenCvSharp.Tests.Core
{
    [TestFixture]
    public class CoreTest : TestBase
    {
        [Test]
        public void Sum()
        {
            using (Mat ones = Mat.Ones(10, 10, MatType.CV_8UC1))
            {
                Scalar sum = Cv2.Sum(ones);
                Assert.AreEqual(100, (int)sum.Val0);
            }
        }
    }
}

