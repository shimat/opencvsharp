using OpenCvSharp.XImgProc;
using Xunit;

namespace OpenCvSharp.Tests.XImgProc;

public class EdgeBoxesTest : TestBase
{
    [Fact]
    public void CreateAndDispose1()
    {
        using (var eb = EdgeBoxes.Create())
        {
            GC.KeepAlive(eb);
        }
    }

    [Fact]
    public void CreateAndDispose2()
    {
        using (var eb = Cv2.XImgProc.CreateEdgeBoxes())
        {
            GC.KeepAlive(eb);
        }
    }
}
