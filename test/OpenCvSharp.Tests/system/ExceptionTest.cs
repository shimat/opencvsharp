using Xunit;

namespace OpenCvSharp.Tests;

/// <summary>
/// RedirectError tests
/// </summary>
public class ExceptionTest : TestBase
{
    private const int TrialCount = 10;

    [Fact]
    public void MatRow()
    {
        for (int i = 0; i < TrialCount; i++)
        {
            using var mat = new Mat(1, 1, MatType.CV_8UC1);
            var ex = Assert.Throws<OpenCVException>(() =>
            {
                using var row = mat.Row(100);
                GC.KeepAlive(row);
            });
                
            Assert.StartsWith("0 <= _rowRange", ex.ErrMsg, StringComparison.Ordinal);
            Assert.NotEmpty(ex.FileName);
            Assert.NotEmpty(ex.FuncName);
            Assert.True(ex.Line > 0);
            Assert.Equal(ErrorCode.StsAssert, ex.Status);
        }
    }

    [Fact]
    public void MatInv()
    {
        for (int i = 0; i < TrialCount; i++)
        {
            var data = new byte[] {1, 10, 100};
            using var mat = Mat.FromPixelData(3, 1, MatType.CV_8UC1, data);
            var ex = Assert.Throws<OpenCVException>(() =>
            {
                using var expr = mat.Inv();
                using var evaluated = expr.ToMat();
                GC.KeepAlive(evaluated);
            });
                
            Assert.StartsWith("type == CV_32F", ex.ErrMsg, StringComparison.Ordinal);
            Assert.NotEmpty(ex.FileName);
            Assert.NotEmpty(ex.FuncName);
            Assert.True(ex.Line > 0);
            Assert.Equal(ErrorCode.StsAssert, ex.Status);
        }
    }

    [Fact]
    public void GaussianBlur()
    {
        for (int i = 0; i < TrialCount; i++)
        {
            using var img = new Mat(3, 3, MatType.CV_8UC1);
            var ex = Assert.Throws<OpenCVException>(
                () => { Cv2.GaussianBlur(img, img, new Size(2, 2), 1); });

            Assert.StartsWith("ksize.width > 0", ex.ErrMsg, StringComparison.Ordinal);
            Assert.NotEmpty(ex.FileName);
            Assert.NotEmpty(ex.FuncName);
            Assert.True(ex.Line > 0);
            Assert.Equal(ErrorCode.StsAssert, ex.Status);
        }
    }

    [Fact]
    public void MedianBlur()
    {
        for (int i = 0; i < TrialCount; i++)
        {
            using var img = new Mat(3, 3, MatType.CV_8UC1);
            var ex = Assert.Throws<OpenCVException>(
                () => { Cv2.MedianBlur(img, img, 2); });

            Assert.StartsWith("(ksize % 2 == 1", ex.ErrMsg, StringComparison.Ordinal);
            Assert.NotEmpty(ex.FileName);
            Assert.NotEmpty(ex.FuncName);
            Assert.True(ex.Line > 0);
            Assert.Equal(ErrorCode.StsAssert, ex.Status);
        }
    }
        
    [Fact]
    public void ArucoDetectMarkers()
    {
        using var image = new Mat();
        using var dict = OpenCvSharp.Aruco.CvAruco.GetPredefinedDictionary(OpenCvSharp.Aruco.PredefinedDictionaryName.Dict6X6_250);

        var param = new OpenCvSharp.Aruco.DetectorParameters();

        var ex = Assert.Throws<OpenCVException>(
            () => { OpenCvSharp.Aruco.CvAruco.DetectMarkers(image, dict, out _, out _, param, out _); });

        Assert.StartsWith("!_image.empty()", ex.ErrMsg, StringComparison.Ordinal);
        Assert.NotEmpty(ex.FileName);
        Assert.NotEmpty(ex.FuncName);
        Assert.True(ex.Line > 0);
        Assert.Equal(ErrorCode.StsAssert, ex.Status);
    }
}
