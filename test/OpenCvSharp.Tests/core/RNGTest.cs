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

        [Fact]
        public void GetTheRNG()
        {
            var rng1 = Cv2.GetTheRNG();
            var rng2 = Cv2.GetTheRNG();

            Assert.Equal(rng1.State, rng2.State);
        }

        [Fact]
        public void SetTheRNG()
        {
            Cv2.SetTheRNG(12345UL);

            var rng = Cv2.GetTheRNG();

            Assert.Equal(12345UL, rng.State);
        }
    }
}
