using System.Runtime.InteropServices;
using Xunit;

namespace OpenCvSharp.Tests.HighGui;

public partial class HighGuiTest : TestBase
{
    public static bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

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

    // Verifies the UnmanagedCallersOnly trampoline + GCHandle context plumbing behind
    // SetMouseCallback/CreateTrackbar actually reaches the managed delegate. SetTrackbarPos
    // invokes the registered callback synchronously (see window_w32.cpp icvUpdateTrackbar),
    // so this can run unattended without a real UI message loop.
    [Fact]
    public void CreateTrackbarCallbackFiresViaTrampoline()
    {
        var winName = $"__test_trackbar_{Guid.NewGuid():N}";
        const string trackbarName = "pos";
        Cv2.NamedWindow(winName);
        try
        {
            var receivedPos = -1;
            var callCount = 0;
            var value = 0;
            Cv2.CreateTrackbar(trackbarName, winName, ref value, 100, (pos, _) =>
            {
                receivedPos = pos;
                callCount++;
            });

            Cv2.SetTrackbarPos(trackbarName, winName, 42);

            Assert.True(callCount > 0);
            Assert.Equal(42, receivedPos);
        }
        finally
        {
            Cv2.DestroyWindow(winName);
        }
    }

    [Fact]
    public void CreateTrackbarWithoutCallbackDoesNotAllocateContext()
    {
        var winName = $"__test_trackbar_nocb_{Guid.NewGuid():N}";
        Cv2.NamedWindow(winName);
        try
        {
            // onChange omitted: must not throw, and must not crash on window teardown even
            // though no GCHandle context was registered for this trackbar.
            // cv::createTrackbar returns 1 on success.
            var ret = Cv2.CreateTrackbar("pos", winName, 100);
            Assert.Equal(1, ret);
        }
        finally
        {
            Cv2.DestroyWindow(winName);
        }
    }

    [Fact]
    public void SetMouseCallbackRegistersAndSurvivesReplaceAndTeardown()
    {
        var winName = $"__test_mouse_{Guid.NewGuid():N}";
        Cv2.NamedWindow(winName);
        try
        {
            // Registering must not throw, and replacing an existing callback for the same
            // window must free the previous GCHandle rather than leak it.
            Cv2.SetMouseCallback(winName, (_, _, _, _, _) => { });
            Cv2.SetMouseCallback(winName, (_, _, _, _, _) => { });
        }
        finally
        {
            // Must release the GCHandle without crashing.
            Cv2.DestroyWindow(winName);
        }
    }

    [Fact]
    public void DestroyAllWindowsReleasesAllCallbackHandles()
    {
        var winName1 = $"__test_mouse_{Guid.NewGuid():N}";
        var winName2 = $"__test_trackbar_{Guid.NewGuid():N}";
        Cv2.NamedWindow(winName1);
        Cv2.NamedWindow(winName2);

        Cv2.SetMouseCallback(winName1, (_, _, _, _, _) => { });
        var value = 0;
        Cv2.CreateTrackbar("pos", winName2, ref value, 100, (_, _) => { });

        // Must free every registered GCHandle without crashing or leaking.
        Cv2.DestroyAllWindows();
    }

    [Fact]
    public void CreateTrackbarCallbackReceivesUserData()
    {
        var winName = $"__test_trackbar_userdata_{Guid.NewGuid():N}";
        const string trackbarName = "pos";
        Cv2.NamedWindow(winName);
        try
        {
            var expectedUserData = new IntPtr(0x1234_5678);
            var receivedUserData = IntPtr.Zero;
            var callCount = 0;
            var value = 0;
            Cv2.CreateTrackbar(trackbarName, winName, ref value, 100, (_, userData) =>
            {
                receivedUserData = userData;
                callCount++;
            }, expectedUserData);

            Cv2.SetTrackbarPos(trackbarName, winName, 5);

            Assert.True(callCount > 0);
            Assert.Equal(expectedUserData, receivedUserData);
        }
        finally
        {
            Cv2.DestroyWindow(winName);
        }
    }

    // Regression test for the historical crash pattern: rapidly updating a trackbar used to
    // corrupt memory if the managed callback wasn't rooted against the GC, because OpenCV keeps
    // calling a native function pointer whose context could point at already-collected memory.
    // The UnmanagedCallersOnly trampoline + GCHandle-rooted context (see Cv2_highgui.cs) exists
    // specifically to prevent this, so this forces a blocking full GC between updates.
    [Fact]
    public void CreateTrackbarSurvivesRepeatedUpdatesWithForcedGc()
    {
        var winName = $"__test_trackbar_stress_{Guid.NewGuid():N}";
        const string trackbarName = "pos";
        Cv2.NamedWindow(winName);
        try
        {
            var callCount = 0;
            var value = 0;
            Cv2.CreateTrackbar(trackbarName, winName, ref value, 1000, (_, _) => callCount++);

            for (var i = 0; i < 500; i++)
            {
                // +1: icvUpdateTrackbar only invokes the callback when the position actually
                // changes, and the trackbar already starts at 0.
                Cv2.SetTrackbarPos(trackbarName, winName, i % 1000 + 1);
                if (i % 20 == 0)
                {
                    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, blocking: true);
                    GC.WaitForPendingFinalizers();
                }
            }

            Assert.Equal(500, callCount);
        }
        finally
        {
            Cv2.DestroyWindow(winName);
        }
    }

    // Same regression concern as above, exercised against the mouse callback's GCHandle registry
    // by repeatedly replacing the callback for one window (each replacement frees the previous
    // GCHandle; see RegisterMouseCallback).
    [Fact]
    public void SetMouseCallbackSurvivesRepeatedReplacementWithForcedGc()
    {
        var winName = $"__test_mouse_stress_{Guid.NewGuid():N}";
        Cv2.NamedWindow(winName);
        try
        {
            for (var i = 0; i < 200; i++)
            {
                Cv2.SetMouseCallback(winName, (_, _, _, _, _) => { });
                if (i % 20 == 0)
                {
                    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, blocking: true);
                    GC.WaitForPendingFinalizers();
                }
            }
        }
        finally
        {
            Cv2.DestroyWindow(winName);
        }
    }

    // Simulates a real mouse move by posting the same WM_MOUSEMOVE the OS would send, via
    // SendMessage on the window OpenCV created. Windows only: no public API exposes the HWND, so
    // this looks it up with FindWindow/FindWindowEx. window_w32.cpp's namedWindow_ creates two
    // HWNDs: an outer frame (class "Main HighGUI class", captioned with the window name, found
    // by FindWindow) and an inner child that actually owns WM_MOUSEMOVE/WM_LBUTTONDOWN/etc.
    // (class "HighGUI class", uncaptioned, found via FindWindowEx on the frame). SendMessage
    // (unlike PostMessage) dispatches synchronously without needing a message pump running.
    // Fragile by nature (depends on OpenCV's private Win32 window/class layout), but it is the
    // only way to exercise the trampoline end-to-end without real mouse input.
    [Fact(Skip = "Only runs on Windows", SkipUnless = nameof(IsWindows))]
    public void SetMouseCallbackReceivesCoordinatesFromSendMessage()
    {
        var winName = $"__test_mouse_coords_{Guid.NewGuid():N}";
        // AutoSize avoids window_w32.cpp's client-area rescaling path, so the coordinates sent
        // below map 1:1 to what the callback receives.
        Cv2.NamedWindow(winName, WindowFlags.AutoSize);
        try
        {
            var frameHwnd = FindWindowW(null, winName);
            Assert.NotEqual(IntPtr.Zero, frameHwnd);
            var childHwnd = FindWindowExW(frameHwnd, IntPtr.Zero, "HighGUI class", null);
            Assert.NotEqual(IntPtr.Zero, childHwnd);

            var receivedX = -1;
            var receivedY = -1;
            var callCount = 0;
            Cv2.SetMouseCallback(winName, (_, x, y, _, _) =>
            {
                receivedX = x;
                receivedY = y;
                callCount++;
            });

            const int wmMouseMove = 0x0200;
            const int x = 12;
            const int y = 34;
            var lParam = new IntPtr((y << 16) | (x & 0xFFFF));
            SendMessageW(childHwnd, wmMouseMove, IntPtr.Zero, lParam);

            Assert.True(callCount > 0);
            Assert.Equal(x, receivedX);
            Assert.Equal(y, receivedY);
        }
        finally
        {
            Cv2.DestroyWindow(winName);
        }
    }

    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [LibraryImport("user32.dll", EntryPoint = "FindWindowW", StringMarshalling = StringMarshalling.Utf16)]
    private static partial IntPtr FindWindowW(string? lpClassName, string lpWindowName);

    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [LibraryImport("user32.dll", EntryPoint = "FindWindowExW", StringMarshalling = StringMarshalling.Utf16)]
    private static partial IntPtr FindWindowExW(IntPtr hwndParent, IntPtr hwndChildAfter, string? lpszClass, string? lpszWindow);

    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [LibraryImport("user32.dll", EntryPoint = "SendMessageW")]
    private static partial IntPtr SendMessageW(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
}
