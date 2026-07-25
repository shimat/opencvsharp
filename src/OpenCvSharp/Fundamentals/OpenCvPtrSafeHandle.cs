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
    private readonly bool releaseNullHandle;

    /// <summary>
    /// Creates a new owning handle with a release action.
    /// </summary>
    /// <param name="existingHandle">The native pointer.</param>
    /// <param name="ownsHandle"><c>true</c> to own and release; <c>false</c> for borrowed pointers.</param>
    /// <param name="releaseAction">
    /// Action to invoke on <see cref="ReleaseHandle"/>. Typically wraps a P/Invoke delete call.
    /// May be <c>null</c> when <paramref name="ownsHandle"/> is <c>false</c>.
    /// </param>
    /// <param name="releaseNullHandle">
    /// Whether a null raw handle still represents an owned resource that must invoke
    /// <paramref name="releaseAction"/> (for example, a non-null empty cv::Ptr).
    /// </param>
    public OpenCvPtrSafeHandle(
        IntPtr existingHandle,
        bool ownsHandle,
        Action<IntPtr>? releaseAction,
        bool releaseNullHandle = false)
        : base(existingHandle, ownsHandle)
    {
        this.releaseAction = releaseAction;
        this.releaseNullHandle = releaseNullHandle;
    }

    /// <inheritdoc />
    public override bool IsInvalid => !releaseNullHandle && base.IsInvalid;

    /// <inheritdoc />
    protected override bool ReleaseHandle()
    {
#pragma warning disable CA1031 // Exceptions must never escape a SafeHandle critical-finalizer path.
        var released = true;
        try
        {
            releaseAction?.Invoke(handle);
        }
        catch
        {
            released = false;
        }

        return released && RunPostReleaseAction();
#pragma warning restore CA1031
    }
}
