using Xunit;

namespace OpenCvSharp.Tests.Photo
{
    public class TonemapTest : TestBase
    {
        [Fact]
        public void Process()
        {
            using var src = Image("lenna.png");
            using var dst = new Mat();
            using var tonemap = Tonemap.Create(2.2f);

            // 8UC3 -> 32FC3
            using var src32f = new Mat();
            src.ConvertTo(src32f, MatType.CV_32FC3);

            tonemap.Process(src32f, dst);

            ShowImagesWhenDebugMode(dst);
        }

        [Fact]
        public void Properties()
        {
            using var tonemap = Tonemap.Create(2.2f);
            Assert.Equal(2.2f, tonemap.Gamma, 3);

            tonemap.Gamma = 0.5f;
            Assert.Equal(0.5f, tonemap.Gamma, 3);
        }
    }
}