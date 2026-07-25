namespace OpenCvSharp;

/// <summary>
/// Atomically owns a replaceable disposable resource.
/// </summary>
internal sealed class DisposableObjectHolder<T> : IDisposable
    where T : class, IDisposable
{
    private readonly object sync = new();
    private T? value;
    private bool disposed;

    public void Replace(T? replacement)
    {
        T? previous;
        var rejectReplacement = false;
        lock (sync)
        {
            if (disposed)
            {
                previous = null;
                rejectReplacement = true;
            }
            else
            {
                previous = value;
                value = replacement;
            }
        }

        if (rejectReplacement)
        {
            replacement?.Dispose();
            throw new ObjectDisposedException(GetType().FullName);
        }
        if (!ReferenceEquals(previous, replacement))
            previous?.Dispose();
    }

    public void Dispose()
    {
        T? previous;
        lock (sync)
        {
            if (disposed)
                return;

            disposed = true;
            previous = value;
            value = null;
        }

        previous?.Dispose();
    }
}
