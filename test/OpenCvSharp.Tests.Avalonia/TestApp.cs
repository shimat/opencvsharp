using Avalonia;
using Avalonia.Headless;

namespace OpenCvSharp.Tests.Avalonia;

// Minimal headless Application used by [AvaloniaFact] tests; no theming/rendering is needed
// since these tests only exercise WriteableBitmap pixel storage, not a visual tree.
// UseHeadlessDrawing = false keeps the real Skia-backed WriteableBitmap (persistent pixel storage,
// genuine pixel-format restrictions) instead of Avalonia's dummy headless bitmap stub, which
// allocates a fresh throwaway buffer on every Lock() and would make round-trip pixel tests meaningless.
public class TestApp : Application
{
    public static AppBuilder BuildAvaloniaApp() =>
        AppBuilder.Configure<TestApp>()
            .UseSkia()
            .UseHeadless(new AvaloniaHeadlessPlatformOptions { UseHeadlessDrawing = false });
}
