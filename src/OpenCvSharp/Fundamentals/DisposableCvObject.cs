#pragma warning disable CA2216

using System.Runtime.InteropServices;

namespace OpenCvSharp;

/// <summary>
/// DisposableObject + ICvPtrHolder
/// </summary>
public abstract class DisposableCvObject : DisposableObject, ICvPtrHolder
{
    /// <summary>
    /// The SafeHandle that wraps (and optionally owns) the native pointer.
    /// This is the single source of truth for the native handle value.
    /// </summary>
    private OpenCvSafeHandle? safeHandle;

    /// <summary>
    /// Native data pointer, derived from <see cref="safeHandle"/>.
    /// Returns <see cref="IntPtr.Zero"/> when no SafeHandle has been set.
    /// </summary>
    protected IntPtr ptr => safeHandle?.DangerousGetHandle() ?? IntPtr.Zero;

    /// <summary>
    /// Default constructor
    /// </summary>
    protected DisposableCvObject()
        : this(true)
    {
    }

    /// <summary>
    /// Constructor (backward compatibility).
    /// Wraps the pointer in a non-owning SafeHandle.
    /// Derived classes that own the native resource should call
    /// <see cref="SetSafeHandle"/> to replace it with an owning handle.
    /// </summary>
    /// <param name="ptr"></param>
    protected DisposableCvObject(IntPtr ptr)
        : this(ptr, true)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="isEnabledDispose"></param>
    protected DisposableCvObject(bool isEnabledDispose)
        : base(isEnabledDispose)
    {
    }

    /// <summary>
    /// Constructor (backward compatibility).
    /// Wraps the pointer in a non-owning SafeHandle so that the
    /// <see cref="ptr"/> property returns the correct value.
    /// </summary>
    /// <param name="ptr"></param>
    /// <param name="isEnabledDispose"></param>
    protected DisposableCvObject(IntPtr ptr, bool isEnabledDispose)
        : base(isEnabledDispose)
    {
        if (ptr != IntPtr.Zero)
            safeHandle = new OpenCvPtrSafeHandle(ptr, ownsHandle: false, releaseAction: null);
    }

    /// <summary>
    /// Constructor that accepts an <see cref="OpenCvSafeHandle"/>.
    /// The SafeHandle owns the native resource and will release it on disposal.
    /// </summary>
    /// <param name="safeHandle">The safe handle wrapping the native pointer.</param>
    protected DisposableCvObject(OpenCvSafeHandle safeHandle)
        : base(true)
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
    /// releases unmanaged resources
    /// </summary>

    /// <summary>
    /// Releases managed resources, including the SafeHandle if present.
    /// </summary>
    protected override void DisposeManaged()
    {
        if (safeHandle is { IsInvalid: false, IsClosed: false })
        {
            safeHandle.Dispose();
        }
        base.DisposeManaged();
    }
        
    /// <summary>
    /// Native pointer of OpenCV structure
    /// </summary>
    public IntPtr CvPtr
    {
        get
        {
            ThrowIfDisposed();
            return ptr;
        }
    }
}
