using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace OpenCvSharp.Tests.Core
{
    // ReSharper disable once InconsistentNaming
    public class RNG_MT19937Test : TestBase
    {
        [Fact]
        public void Next()
        {
            var rng = new RNG_MT19937(0xffffffff);

            Assert.Equal(419326371U, rng.Next());
            Assert.Equal(479346978U, rng.Next());
            Assert.Equal(3918654476U, rng.Next());
        }

        [Fact]
        public void Uniform()
        {
            var rng = new RNG_MT19937(1234);

            Assert.Equal(5, rng.Uniform(0, 10));
            Assert.Equal(1, rng.Uniform(0, 10));
            Assert.Equal(6, rng.Uniform(0, 10));
        }
    }
}
