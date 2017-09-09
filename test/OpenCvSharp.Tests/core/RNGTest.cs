using System;
using Xunit;

namespace OpenCvSharp.Tests.Core
{
    public class RNGTest : TestBase
    {
        [Fact]
        public void Next()
        {
            var rng = new RNG(0xffffffff);

            Assert.Equal(130063606U, rng.Next());
            Assert.Equal(3003295397U, rng.Next());
            Assert.Equal(3870020839U, rng.Next());
        }

        [Fact]
        public void Uniform()
        {
            var rng = new RNG(1234);

            Assert.Equal(4, rng.Uniform(0, 10));
            Assert.Equal(6, rng.Uniform(0, 10));
            Assert.Equal(9, rng.Uniform(0, 10));
        }
    }
}
