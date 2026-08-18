using Avalonia.Headless;

namespace OpenCvSharp.Tests.Avalonia;

// Keeps Avalonia setup and test execution on its dispatcher without relying on an xUnit discoverer.
public sealed class AvaloniaTestEnvironment : IAsyncDisposable
{
    private readonly HeadlessUnitTestSession session =
        HeadlessUnitTestSession.StartNew(typeof(TestApp), AvaloniaTestIsolationLevel.PerAssembly);

    public void Run(Action action)
    {
        session.Dispatch(action, CancellationToken.None).GetAwaiter().GetResult();
    }

    public ValueTask DisposeAsync() => session.DisposeAsync();
}
