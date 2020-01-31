using Xunit;

namespace OpenCvSharp.Tests.ImgProc
{
    public class ConnectedComponentsTest : TestBase
    {
        [Theory]
        [InlineData(PixelConnectivity.Connectivity4, ConnectedComponentsAlgorithmsTypes.Default)]
        [InlineData(PixelConnectivity.Connectivity4, ConnectedComponentsAlgorithmsTypes.GRANA)]
        [InlineData(PixelConnectivity.Connectivity8, ConnectedComponentsAlgorithmsTypes.Default)]
        [InlineData(PixelConnectivity.Connectivity8, ConnectedComponentsAlgorithmsTypes.GRANA)]
        public void Run(PixelConnectivity connectivity, ConnectedComponentsAlgorithmsTypes algorithmType)
        {
            using var src = Image("alphabet.png", ImreadModes.Grayscale);
            using var binary = new Mat();
            Cv2.Threshold(src, binary, 128, 255, ThresholdTypes.BinaryInv);
            ShowImagesWhenDebugMode(src, binary);

            var cc = Cv2.ConnectedComponentsEx(binary, connectivity, algorithmType);
            
            Assert.Equal(27, cc.LabelCount);
            Assert.NotEmpty(cc.Labels);
            Assert.Equal(src.Rows, cc.Labels.GetLength(0));
            Assert.Equal(src.Cols, cc.Labels.GetLength(1));

            using var render = new Mat();
            cc.RenderBlobs(render);
            ShowImagesWhenDebugMode(render);
        }

        [Fact]
        public void GetLargestBlob()
        {
            using var src = new Mat(100, 100, MatType.CV_8UC1, Scalar.Black);
            Cv2.Rectangle(src, new Rect(10, 20, 10, 20), Scalar.White, -1);
            Cv2.Rectangle(src, new Rect(50, 60, 20, 30), Scalar.White, -1); // greater
            ShowImagesWhenDebugMode(src);

            var cc = Cv2.ConnectedComponentsEx(src, PixelConnectivity.Connectivity8, ConnectedComponentsAlgorithmsTypes.Default);
            
            var largestBlob = cc.GetLargestBlob();
            Assert.Equal(50, largestBlob.Left);
            Assert.Equal(60, largestBlob.Top);
            Assert.Equal(20, largestBlob.Width);
            Assert.Equal(30, largestBlob.Height);
            Assert.Equal(new Rect(50, 60, 20, 30), largestBlob.Rect);
            Assert.Equal(20 * 30, largestBlob.Area);
            Assert.Equal(new Point2d(59.5, 74.5), largestBlob.Centroid);
        }

        [Fact]
        public void FilterByLabel()
        {
            using var src = new Mat(100, 100, MatType.CV_8UC1, Scalar.Black);
            Cv2.Rectangle(src, new Rect(10, 20, 10, 20), Scalar.White, -1);
            Cv2.Rectangle(src, new Rect(50, 60, 20, 30), Scalar.White, -1); // greater

            var cc = Cv2.ConnectedComponentsEx(src, PixelConnectivity.Connectivity8, ConnectedComponentsAlgorithmsTypes.Default);

            using var dst = new Mat();
            cc.FilterByLabel(src, dst, 1);

            using var expected = new Mat(100, 100, MatType.CV_8UC1, Scalar.Black);
            Cv2.Rectangle(expected, new Rect(10, 20, 10, 20), Scalar.White, -1);
            ShowImagesWhenDebugMode(src, dst, expected);

            ImageEquals(dst, expected);
        }
    }
}
