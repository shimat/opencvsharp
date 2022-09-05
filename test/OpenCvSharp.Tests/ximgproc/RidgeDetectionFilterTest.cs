using System.Diagnostics;
using Xunit;

namespace OpenCvSharp.Tests.XImgProc;

public class RidgeDetectionFilterTest
{
    [Fact]
    public void Test()
    {
        using var filter = RidgeDetectionFilter.Create();
        using var src = new Mat("_data/image/mandrill.png");
        using var dst = new Mat();
        filter.GetRidgeFilteredImage(src, dst);

        if (Debugger.IsAttached)
        {
            Window.ShowImages(src, dst);
        }
    }
}
