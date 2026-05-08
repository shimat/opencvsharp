using System.Runtime.InteropServices;

namespace OpenCvSharp;

/// <summary>
/// Base class for SafeHandle instances wrapping native OpenCV pointers.
/// Provides a common <see cref="SafeHandle"/> implementation where <c>IntPtr.Zero</c> is the invalid handle value.
/// </summary>
public abstract class OpenCvSafeHandle : SafeHandle
{
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
}
