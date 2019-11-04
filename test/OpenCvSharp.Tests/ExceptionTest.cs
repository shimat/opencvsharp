using Xunit;

namespace OpenCvSharp.Tests
{
    /// <summary>
    /// RedirectError tests
    /// </summary>
    public class ExceptionTest : TestBase
    {
        private const int TrialCount = 100;

        [Fact]
        public void GaussianBlur()
        {
            for (int i = 0; i < TrialCount; i++)
            {
                using (var img = new Mat(3, 3, MatType.CV_8UC1))
                {
                    var ex = Assert.Throws<OpenCVException>(
                        () => { Cv2.GaussianBlur(img, img, new Size(2, 2), 1); });

                    Assert.StartsWith("ksize.width > 0", ex.ErrMsg);
                    Assert.NotEmpty(ex.FileName);
                    Assert.NotEmpty(ex.FuncName);
                    Assert.True(ex.Line > 0);
                    Assert.Equal(ErrorCode.StsAssert, ex.Status);
                }
            }
        }

        [Fact]
        public void MedianBlur()
        {
            for (int i = 0; i < TrialCount; i++)
            {
                using (var img = new Mat(3, 3, MatType.CV_8UC1))
                {

                    var ex = Assert.Throws<OpenCVException>(
                        () => { Cv2.MedianBlur(img, img, 2); });

                    Assert.StartsWith("(ksize % 2 == 1", ex.ErrMsg);
                    Assert.NotEmpty(ex.FileName);
                    Assert.NotEmpty(ex.FuncName);
                    Assert.True(ex.Line > 0);
                    Assert.Equal(ErrorCode.StsAssert, ex.Status);
                }
            }
        }

        [Fact]
        public void BilateralFilter()
        {
            for (int i = 0; i < TrialCount; i++)
            {
                using (var img = new Mat(3, 3, MatType.CV_8UC1))
                {
                    var ex = Assert.Throws<OpenCVException>(
                        () => { Cv2.BilateralFilter(img, img, -1, -1, -1); });

                    Assert.StartsWith("(src.type() == CV_8UC1 ||", ex.ErrMsg);
                    Assert.NotEmpty(ex.FileName);
                    Assert.NotEmpty(ex.FuncName);
                    Assert.True(ex.Line > 0);
                    Assert.Equal(ErrorCode.StsAssert, ex.Status);
                }
            }
        }

        [Fact]
        public void BoxFilter()
        {
            for (int i = 0; i < TrialCount; i++)
            {
                using (var img = new Mat(3, 3, MatType.CV_8UC1))
                {
                    var ex = Assert.Throws<OpenCVException>(
                        () => { Cv2.BoxFilter(img, img, MatType.CV_8UC1, new Size(-1, -1)); });

                    Assert.StartsWith("anchor.inside(Rect(0, 0", ex.ErrMsg);
                    Assert.NotEmpty(ex.FileName);
                    Assert.NotEmpty(ex.FuncName);
                    Assert.True(ex.Line > 0);
                    Assert.Equal(ErrorCode.StsAssert, ex.Status);
                }
            }
        }
    }
}
