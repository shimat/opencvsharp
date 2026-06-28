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
                using Mat evaluated = mat.Inv();
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
        using var dict = Cv2.Aruco.GetPredefinedDictionary(OpenCvSharp.Aruco.PredefinedDictionaryType.Dict6X6_250);
        using var detector = new OpenCvSharp.Aruco.ArucoDetector(dict);

        var ex = Assert.Throws<OpenCVException>(
            () => { detector.DetectMarkers(image, out _, out _, out _); });

        Assert.StartsWith("!_image.empty()", ex.ErrMsg, StringComparison.Ordinal);
        Assert.NotEmpty(ex.FileName);
        Assert.NotEmpty(ex.FuncName);
        Assert.True(ex.Line > 0);
        Assert.Equal(ErrorCode.StsAssert, ex.Status);
    }

    [Fact]
    public void SetErrorHandlerInvokesCustomHandler()
    {
        var callCount = 0;
        var capturedStatus = default(ErrorCode);
        var capturedFunc = "";
        var capturedMsg = "";

        CvErrorCallback handler = (status, funcName, errMsg, fileName, line, userData) =>
        {
            callCount++;
            capturedStatus = status;
            capturedFunc = funcName;
            capturedMsg = errMsg;
            return 0;
        };

        try
        {
            Cv2.SetErrorHandler(handler);

            using var img = new Mat(3, 3, MatType.CV_8UC1);
            // Even with a custom handler installed, the error still surfaces as a managed exception.
            Assert.Throws<OpenCVException>(() => Cv2.GaussianBlur(img, img, new Size(2, 2), 1));
        }
        finally
        {
            Cv2.SetErrorHandler(null); // restore the default native silent handler
        }

        Assert.True(callCount > 0);
        Assert.Equal(ErrorCode.StsAssert, capturedStatus);
        Assert.StartsWith("ksize.width > 0", capturedMsg, StringComparison.Ordinal);
        Assert.False(string.IsNullOrEmpty(capturedFunc));
    }

    [Fact]
    public void SetErrorHandlerNullRestoresDefault()
    {
        // Installing then clearing a handler must leave errors still surfacing as OpenCVException.
        Cv2.SetErrorHandler((_, _, _, _, _, _) => 0);
        Cv2.SetErrorHandler(null);

        using var img = new Mat(3, 3, MatType.CV_8UC1);
        Assert.Throws<OpenCVException>(() => Cv2.GaussianBlur(img, img, new Size(2, 2), 1));
    }
}
