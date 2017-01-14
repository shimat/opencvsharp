using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace OpenCvSharp.Tests
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public class RNG_MT19937Test
    {
        [Test]
        public void Next()
        {
            var rng = new RNG_MT19937(0xffffffff);

            Assert.AreEqual(419326371, rng.Next());
            Assert.AreEqual(479346978, rng.Next());
            Assert.AreEqual(3918654476, rng.Next());
        }

        [Test]
        public void Uniform()
        {
            var rng = new RNG_MT19937(1234);

            Assert.AreEqual(5, rng.Uniform(0, 10));
            Assert.AreEqual(1, rng.Uniform(0, 10));
            Assert.AreEqual(6, rng.Uniform(0, 10));
        }
    }
}
