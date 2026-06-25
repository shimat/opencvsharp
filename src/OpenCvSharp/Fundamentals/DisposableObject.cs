namespace OpenCvSharp;

/// <summary>
/// Minimal IDisposable base providing the standard dispose/finalize pattern.
/// </summary>
/// <remarks>
/// Native-pointer-owning types use <see cref="CvObject"/> instead (which owns an
/// <see cref="OpenCvSafeHandle"/>). This base is retained only for a few legacy utility
/// types (array pinning helpers and HighGUI wrappers) that hold managed-only unmanaged
/// state such as <see cref="System.Runtime.InteropServices.GCHandle"/>; those are slated
/// for a follow-up redesign.
/// </remarks>
public abstract class DisposableObject : IDisposable
{
    private volatile int disposeSignaled;

    /// <summary>
    /// Gets a value indicating whether this instance has been disposed.
    /// </summary>
    public bool IsDisposed { get; protected set; }

    /// <summary>
    /// Gets or sets a value indicating whether you permit disposing this instance.
    /// </summary>
    public bool IsEnabledDispose { get; set; }

    /// <summary>
    /// Default constructor
    /// </summary>
    protected DisposableObject()
        : this(true)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="isEnabledDispose">true if you permit disposing this class by GC</param>
    protected DisposableObject(bool isEnabledDispose)
    {
        IsDisposed = false;
        IsEnabledDispose = isEnabledDispose;
    }

    /// <summary>
    /// Releases the resources
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases the resources
    /// </summary>
    /// <param name="disposing">
    /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
    /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
    /// </param>
    protected virtual void Dispose(bool disposing)
    {
#pragma warning disable 420
        if (Interlocked.Exchange(ref disposeSignaled, 1) != 0)
        {
            return;
        }
#pragma warning restore 420

        IsDisposed = true;

        if (IsEnabledDispose)
        {
            if (disposing)
            {
                DisposeManaged();
            }
            DisposeUnmanaged();
        }
    }

    /// <summary>
    /// Destructor
    /// </summary>
    ~DisposableObject()
    {
        Dispose(false);
    }

    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected virtual void DisposeManaged()
    {
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected virtual void DisposeUnmanaged()
    {
    }

    /// <summary>
    /// If this object is disposed, then ObjectDisposedException is thrown.
    /// </summary>
    public void ThrowIfDisposed()
    {
        if (IsDisposed)
            throw new ObjectDisposedException(GetType().FullName);
    }
}
