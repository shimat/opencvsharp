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

        [Test]
        public void MinMaxLoc()
        {
            using (Mat ones = Mat.Ones(10, 10, MatType.CV_8UC1))
            {
                ones.Set(1, 2, 0);
                ones.Set(3, 4, 2);

                double minVal, maxVal;
                Point minLoc, maxLoc;
                Cv2.MinMaxLoc(ones, out minVal, out maxVal, out minLoc, out maxLoc);

                Assert.AreEqual(0, minVal);
                Assert.AreEqual(2, maxVal);
                Assert.AreEqual(new Point(2, 1), minLoc);
                Assert.AreEqual(new Point(4, 3), maxLoc);
            }
        }

        [Test]
        public void MinMaxIdx()
        {
            using (Mat ones = Mat.Ones(10, 10, MatType.CV_8UC1))
            {
                ones.Set(1, 2, 0);
                ones.Set(3, 4, 2);

                double minVal, maxVal;
                int[] minIdx = new int[2];
                int[] maxIdx = new int[2];
                Cv2.MinMaxIdx(ones, out minVal, out maxVal, minIdx, maxIdx);

                Assert.AreEqual(0, minVal);
                Assert.AreEqual(2, maxVal);
                Assert.AreEqual(new [] {1, 2}, minIdx);
                Assert.AreEqual(new [] {3, 4}, maxIdx);
            }
        }
    }
}

