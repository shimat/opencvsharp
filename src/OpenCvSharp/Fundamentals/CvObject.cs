#pragma warning disable CA2216
#pragma warning disable CA1805 // Do not initialize unnecessarily.

namespace OpenCvSharp;

/// <summary>
/// Base class for objects that own a single native OpenCV pointer through an
/// <see cref="OpenCvSafeHandle"/>. The SafeHandle is the single source of truth for the
/// native handle value and is responsible for releasing it (including from its own finalizer
/// when the managed object is dropped without <see cref="Dispose()"/>).
/// </summary>
public abstract class CvObject : IDisposable
{
    /// <summary>
    /// The SafeHandle that wraps (and optionally owns) the native pointer.
    /// </summary>
    private volatile OpenCvSafeHandle? safeHandle;

    private volatile int disposeSignaled;

    /// <summary>
    /// Gets a value indicating whether this instance has been disposed.
    /// Backed by the same once-only flag that guards disposal, so there is no
    /// separate state to keep in sync.
    /// </summary>
    public bool IsDisposed => disposeSignaled != 0;

    /// <summary>
    /// Native data pointer, derived from <see cref="safeHandle"/>.
    /// Returns <see cref="IntPtr.Zero"/> when no SafeHandle has been set.
    /// </summary>
    protected IntPtr ptr => safeHandle?.DangerousGetHandle() ?? IntPtr.Zero;

    /// <summary>
    /// Default constructor
    /// </summary>
    protected CvObject()
    {
    }

    /// <summary>
    /// Constructor (backward compatibility).
    /// Wraps the pointer in a non-owning SafeHandle.
    /// Derived classes that own the native resource should call
    /// <see cref="SetSafeHandle"/> to replace it with an owning handle.
    /// </summary>
    /// <param name="ptr"></param>
    protected CvObject(IntPtr ptr)
    {
        if (ptr != IntPtr.Zero)
            safeHandle = new OpenCvPtrSafeHandle(ptr, ownsHandle: false, releaseAction: null);
    }

    /// <summary>
    /// Constructor that accepts an <see cref="OpenCvSafeHandle"/>.
    /// The SafeHandle owns the native resource and will release it on disposal.
    /// </summary>
    /// <param name="safeHandle">The safe handle wrapping the native pointer.</param>
    protected CvObject(OpenCvSafeHandle safeHandle)
    {
        this.safeHandle = safeHandle ?? throw new ArgumentNullException(nameof(safeHandle));
    }

    /// <summary>
    /// Sets or replaces the internal SafeHandle.
    /// The <see cref="ptr"/> property will reflect the new handle's value.
    /// </summary>
    /// <param name="handle">The safe handle wrapping the native pointer.</param>
    protected void SetSafeHandle(OpenCvSafeHandle handle)
    {
        var old = safeHandle;
        safeHandle = handle ?? throw new ArgumentNullException(nameof(handle));

        // If we're replacing an existing SafeHandle (e.g. derived class overrides base),
        // invalidate the old one so its finalizer won't call the wrong delete function.
        if (old is not null && !ReferenceEquals(old, handle))
        {
            old.SetHandleAsInvalid();
        }
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
        // http://stackoverflow.com/questions/425132/a-reference-to-a-volatile-field-will-not-be-treated-as-volatile-implications
        if (Interlocked.Exchange(ref disposeSignaled, 1) != 0)
        {
            return;
        }
#pragma warning restore 420

        if (disposing)
        {
            DisposeManaged();
        }
        DisposeUnmanaged();
    }

    /// <summary>
    /// Destructor
    /// </summary>
    ~CvObject()
    {
        Dispose(false);
    }

    /// <summary>
    /// Releases managed resources, including the SafeHandle if present.
    /// </summary>
    protected virtual void DisposeManaged()
    {
        if (safeHandle is { IsInvalid: false, IsClosed: false })
        {
            safeHandle.Dispose();
        }
    }

    /// <summary>
    /// Releases unmanaged resources.
    /// Nulls out the SafeHandle so that <see cref="ptr"/> returns <see cref="IntPtr.Zero"/>
    /// after disposal, providing defence-in-depth against use-after-dispose.
    /// </summary>
    protected virtual void DisposeUnmanaged()
    {
        safeHandle = null;
    }

    /// <summary>
    /// If this object is disposed, then ObjectDisposedException is thrown.
    /// </summary>
    public void ThrowIfDisposed()
    {
        if (IsDisposed)
            throw new ObjectDisposedException(GetType().FullName);
    }

    /// <summary>
    /// Native pointer of OpenCV structure
    /// </summary>
    public IntPtr CvPtr => ptr;

    /// <summary>
    /// The SafeHandle wrapping the native pointer.
    /// Pass this to P/Invoke entry points whose parameter is typed as
    /// <see cref="OpenCvSafeHandle"/>: the marshaller AddRef/Release's it around the call,
    /// keeping this object alive for the call's duration and removing the need for an
    /// explicit <see cref="GC.KeepAlive(object?)"/> guard.
    /// </summary>
    /// <remarks>
    /// This only covers the duration of the native call. If the call returns an interior
    /// pointer that managed code dereferences afterwards (e.g. <c>data</c>/<c>c_str</c>/<c>getPointer</c>),
    /// keep an explicit <c>GC.KeepAlive(this)</c> after that later use.
    /// </remarks>
    internal OpenCvSafeHandle Handle
        => safeHandle ?? throw new ObjectDisposedException(GetType().FullName);
}
