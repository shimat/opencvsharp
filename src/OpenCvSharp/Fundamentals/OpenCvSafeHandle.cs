using System.Runtime.InteropServices;

namespace OpenCvSharp;

/// <summary>
/// Base class for SafeHandle instances wrapping native OpenCV pointers.
/// Provides a common <see cref="SafeHandle"/> implementation where <c>IntPtr.Zero</c> is the invalid handle value.
/// </summary>
public abstract class OpenCvSafeHandle : SafeHandle
{
    private Action? postReleaseAction;

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenCvSafeHandle"/> class that owns the handle.
    /// </summary>
    protected OpenCvSafeHandle()
        : base(IntPtr.Zero, ownsHandle: true)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenCvSafeHandle"/> class.
    /// </summary>
    /// <param name="ownsHandle">
    /// <c>true</c> if this instance owns the handle and should release it on disposal;
    /// <c>false</c> for a borrowed (non-owning) wrapper around an existing pointer.
    /// </param>
    protected OpenCvSafeHandle(bool ownsHandle)
        : base(IntPtr.Zero, ownsHandle)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenCvSafeHandle"/> class with an existing handle.
    /// </summary>
    /// <param name="existingHandle">The pre-existing native pointer to wrap.</param>
    /// <param name="ownsHandle">
    /// <c>true</c> if this instance owns the handle and should release it on disposal;
    /// <c>false</c> for a borrowed (non-owning) wrapper.
    /// </param>
    protected OpenCvSafeHandle(IntPtr existingHandle, bool ownsHandle)
        : base(IntPtr.Zero, ownsHandle)
    {
        SetHandle(existingHandle);
    }

    /// <inheritdoc />
    public override bool IsInvalid => handle == IntPtr.Zero;

    /// <summary>
    /// Registers cleanup that must run after the native handle has been released.
    /// This is used for callback contexts whose lifetime is bounded by the native owner.
    /// </summary>
    internal void SetPostReleaseAction(Action action)
    {
        ArgumentNullException.ThrowIfNull(action);
        if (IsClosed)
            throw new ObjectDisposedException(GetType().FullName);
        if (Interlocked.CompareExchange(ref postReleaseAction, action, null) is not null)
            throw new InvalidOperationException("A post-release action has already been registered.");
    }

    /// <summary>
    /// Runs and clears the registered post-release cleanup without allowing an exception
    /// to escape the SafeHandle critical-finalizer path.
    /// </summary>
    protected bool RunPostReleaseAction()
    {
#pragma warning disable CA1031 // Exceptions must never escape a SafeHandle critical-finalizer path.
        var action = Interlocked.Exchange(ref postReleaseAction, null);
        if (action is null)
            return true;

        try
        {
            action();
            return true;
        }
        catch
        {
            return false;
        }
#pragma warning restore CA1031
    }

    /// <summary>
    /// A non-owning handle wrapping a null native pointer. Pass this for an optional
    /// SafeHandle-typed P/Invoke argument (e.g. a mask) when the caller has none, instead
    /// of overloading the parameter type with a plain <see cref="IntPtr"/>.
    /// </summary>
    public static OpenCvSafeHandle Null { get; } = new OpenCvPtrSafeHandle(IntPtr.Zero, ownsHandle: false, releaseAction: null);
}
