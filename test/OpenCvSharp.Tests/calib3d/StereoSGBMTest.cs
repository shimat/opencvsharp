using System.Diagnostics;
using Xunit;

namespace OpenCvSharp.Tests.Calib3D;

public class StereoSGBMTest : TestBase
{
    [Fact]
    public void SimpleCompute()
    {
        var left = LoadImage("tsukuba_left.png", ImreadModes.Grayscale);
        var right = LoadImage("tsukuba_right.png", ImreadModes.Grayscale);

        using var sbm = StereoSGBM.Create(0, 32, 5);
        var disparity = new Mat();
        sbm.Compute(left, right, disparity);

        if (Debugger.IsAttached)
        {
            Cv2.MinMaxLoc(disparity, out var min, out double max);

            var disparityU8 = new Mat();
            disparity.ConvertTo(disparityU8, MatType.CV_8UC1, 255 / (max - min), -255 * min / (max - min));
            Window.ShowImages(disparityU8);
        }
    }
}
