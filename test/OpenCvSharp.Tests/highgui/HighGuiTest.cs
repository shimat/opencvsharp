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

    [Fact]
    public void PollKey()
    {
        int val = Cv2.PollKey();
        Assert.Equal(-1, val);
    }

    [Fact]
    public void CurrentUIFramework()
    {
        string framework = Cv2.CurrentUIFramework();
        Assert.NotNull(framework);
    }

    [ExplicitFact]
    public void Window()
    {
        using var img = new Mat("_data/image/mandrill.png");

        using (var window = new Window("window01"))
        {
            window.ShowImage(img);
            Cv2.WaitKey();
        }
        using (var window = new Window("window02"))
        {
            Cv2.CvtColor(img, img, ColorConversionCodes.BGR2GRAY);
            window.ShowImage(img);
            Cv2.WaitKey();
        }
    }

    // ArrayProxy migration coverage (issue #1976): SelectROI/SelectROIs need interactive
    // mouse input (space/enter to confirm, esc/c to cancel), so they can only run manually.
    // ReSharper disable once InconsistentNaming
    [ExplicitFact]
    public void SelectROI()
    {
        using var img = new Mat("_data/image/mandrill.png");
        var roi = Cv2.SelectROI("Select a ROI and press space/enter", img);
        Console.WriteLine(roi);
    }

    // ReSharper disable once InconsistentNaming
    [ExplicitFact]
    public void SelectROIs()
    {
        using var img = new Mat("_data/image/mandrill.png");
        var rois = Cv2.SelectROIs("Select ROIs, space/enter for each, esc to finish", img);
        Console.WriteLine(string.Join(", ", rois));
    }
}
