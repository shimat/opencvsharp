using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace OpenCvSharp.Tests.Core
{
    [TestFixture]
    public class RNGTest : TestBase
    {
        [Test]
        public void Next()
        {
            var rng = new RNG(0xffffffff);

            Assert.AreEqual(130063606, rng.Next());
            Assert.AreEqual(3003295397, rng.Next());
            Assert.AreEqual(3870020839, rng.Next());
        }

        [Test]
        public void Uniform()
        {
            var rng = new RNG(1234);

            Assert.AreEqual(4, rng.Uniform(0, 10));
            Assert.AreEqual(6, rng.Uniform(0, 10));
            Assert.AreEqual(9, rng.Uniform(0, 10));
        }
    }
}
