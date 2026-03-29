namespace OpenCvSharp;

/// <summary>
/// A delegate-based <see cref="OpenCvSafeHandle"/> that releases a native pointer
/// using a supplied release action. This avoids creating a dedicated SafeHandle subclass
/// for every OpenCV type.
/// </summary>
internal sealed class OpenCvPtrSafeHandle : OpenCvSafeHandle
{
    /// <summary>
    /// Delegate that performs the actual native resource release.
    /// </summary>
    private readonly Action<IntPtr>? releaseAction;

    /// <summary>
    /// Creates a new owning handle with a release action.
    /// </summary>
    /// <param name="existingHandle">The native pointer.</param>
    /// <param name="ownsHandle"><c>true</c> to own and release; <c>false</c> for borrowed pointers.</param>
    /// <param name="releaseAction">
    /// Action to invoke on <see cref="ReleaseHandle"/>. Typically wraps a P/Invoke delete call.
    /// May be <c>null</c> when <paramref name="ownsHandle"/> is <c>false</c>.
    /// </param>
    public OpenCvPtrSafeHandle(IntPtr existingHandle, bool ownsHandle, Action<IntPtr>? releaseAction)
        : base(existingHandle, ownsHandle)
    {
        this.releaseAction = releaseAction;
    }

    /// <inheritdoc />
    protected override bool ReleaseHandle()
    {
        releaseAction?.Invoke(handle);
        return true;
    }
}
