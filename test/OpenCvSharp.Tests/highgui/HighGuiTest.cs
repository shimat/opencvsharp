using Xunit;

namespace OpenCvSharp.Tests.HighGui;

public class HighGuiTest : TestBase
{
    [Fact]
    public void WaitKey()
    {
        int val = Cv2.WaitKey(1);
        Assert.Equal(-1, val);
    }

    [Fact]
    public void WaitKeyEx()
    {
        int val = Cv2.WaitKeyEx(1);
        Assert.Equal(-1, val);
    }

    [Fact, Explicit]
    public void Window()
    {
        using var img = new Mat("_data/image/mandrill.png");

        using (var window = new Window("window01"))
        {
            window.ShowImage(img);
            Assert.NotEqual(IntPtr.Zero, window.GetHandle());
            Cv2.WaitKey();
        }
        using (var window = new Window("window02"))
        {
            Cv2.CvtColor(img, img, ColorConversionCodes.BGR2GRAY);
            window.ShowImage(img);
            Cv2.WaitKey();
        }
    }
}
