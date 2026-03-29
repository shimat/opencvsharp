using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// A <see cref="OpenCvSafeHandle"/> that releases a native <c>cv::Mat*</c> pointer.
/// </summary>
public sealed class MatSafeHandle : OpenCvSafeHandle
{
    /// <summary>
    /// Initializes a new owning instance (used by P/Invoke out parameters).
    /// </summary>
    public MatSafeHandle()
    {
    }

    /// <summary>
    /// Wraps an existing native <c>cv::Mat*</c> pointer.
    /// </summary>
    /// <param name="existingHandle">The pre-existing native pointer.</param>
    /// <param name="ownsHandle">
    /// <c>true</c> if this instance should call <c>core_Mat_delete</c> on disposal;
    /// <c>false</c> for borrowed pointers that are owned by another object.
    /// </param>
    public MatSafeHandle(IntPtr existingHandle, bool ownsHandle)
        : base(existingHandle, ownsHandle)
    {
    }

    /// <inheritdoc />
    protected override bool ReleaseHandle()
    {
        NativeMethods.HandleException(
            NativeMethods.core_Mat_delete(handle));
        return true;
    }
}
