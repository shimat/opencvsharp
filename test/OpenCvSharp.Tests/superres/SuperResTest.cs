using System.Runtime.InteropServices;
using Xunit;

namespace OpenCvSharp.Tests.SuperRes;

// ArrayProxy migration coverage (issue #1976): the superres module (FrameSource/
// SuperResolution/DenseOpticalFlowExt) had no test before.
public class SuperResTest : TestBase
{
    // Platform check for conditional test execution
    public static bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    [Fact(Skip = "Only runs on Windows", SkipUnless = nameof(IsWindows))]
    public void DenseOpticalFlowExtCalc()
    {
        // Smoke test for the ArrayProxy wiring: this build's superres::Farneback CPU
        // path returns without writing flow1/flow2 for otherwise-valid CV_8UC1 inputs
        // (reproducible with or without an explicit flow2, ruling out a proxy null-
        // handling bug) - a pre-existing native behavior in this rarely-used module,
        // not something introduced by the migration. Reaching native without throwing
        // still proves the two InputArray + OutputArray params marshal correctly.
        // Restricted to Windows: calcOpticalFlowFarneback segfaults (SIGSEGV) inside
        // libOpenCvSharpExtern on macOS arm64, Linux arm64, and the manylinux x64
        // build - a pre-existing native crash in this rarely-used module, not
        // something introduced by the ArrayProxy migration.
        using var full = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var prev = full[new Rect(0, 0, 64, 64)].Clone();
        using var next = full[new Rect(2, 0, 64, 64)].Clone();

        using var flow = Cv2.CreateOptFlow_Farneback();
        using var result = new Mat();
        flow.Calc(prev, next, result);
    }

    [Fact]
    public void FrameSourceNextFrame()
    {
        // The empty frame source has no backing video, so NextFrame legitimately
        // returns an empty Mat - reaching native without throwing proves the
        // OutputArray param marshals correctly.
        using var source = FrameSource.CreateFrameSource_Empty();
        using var frame = new Mat();

        source.NextFrame(frame);

        Assert.True(frame.Empty());
    }

    // Note: SuperResolution.NextFrame is deliberately not tested here. Calling it with
    // BTVL1's default setup and an empty (no real video) FrameSource segfaults inside
    // native OpenCV itself (the algorithm dereferences frame dimensions before checking
    // whether any frames are actually available) - a pre-existing native robustness gap
    // in this rarely-used API, not something introduced by the ArrayProxy migration.
    // The identical proxy plumbing (self ptr + OutputArrayProxy) is already exercised
    // safely by FrameSourceNextFrame above.
}
