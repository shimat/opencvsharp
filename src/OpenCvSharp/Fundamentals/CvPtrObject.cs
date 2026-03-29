namespace OpenCvSharp;

/// <summary>
/// Base class for OpenCV Algorithm-hierarchy objects.
/// Stores both the smart pointer (cv::Ptr&lt;T&gt;*) for lifetime management
/// and the raw T* for P/Invoke calls, so that <see cref="RawPtr"/> always
/// returns the raw pointer without ambiguity.
/// </summary>
public abstract class CvPtrObject : DisposableObject
{
    private OpenCvSafeHandle? _lifecycleHandle;
    private readonly IntPtr _nativePtr;

    /// <summary>
    /// Factory-pattern constructor.
    /// <paramref name="smartPtr"/> is a cv::Ptr&lt;T&gt;* that owns the object lifetime;
    /// <paramref name="rawPtr"/> is the T* extracted from it for P/Invoke.
    /// </summary>
    protected CvPtrObject(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> releaseSmartPtr)
    {
        _nativePtr = rawPtr;
        _lifecycleHandle = new OpenCvPtrSafeHandle(
            smartPtr, ownsHandle: true,
            releaseAction: _ => releaseSmartPtr(smartPtr));
    }

    /// <summary>
    /// Direct-allocation constructor.
    /// <paramref name="rawPtr"/> is a T* that is released directly by <paramref name="releaseRawPtr"/>.
    /// </summary>
    protected CvPtrObject(IntPtr rawPtr, Action<IntPtr> releaseRawPtr)
    {
        _nativePtr = rawPtr;
        _lifecycleHandle = new OpenCvPtrSafeHandle(
            rawPtr, ownsHandle: true,
            releaseAction: _ => releaseRawPtr(rawPtr));
    }

    /// <summary>
    /// Returns the raw T* for use in P/Invoke calls.
    /// </summary>
    public IntPtr RawPtr
    {
        get
        {
            ThrowIfDisposed();
            return _nativePtr;
        }
    }

    /// <summary>
    /// Alias for <see cref="RawPtr"/>. Kept for source compatibility with existing subclass code.
    /// </summary>
    public IntPtr CvPtr => RawPtr;

    /// <summary>
    /// Returns the cv::Ptr&lt;T&gt;* smart pointer for P/Invoke calls that require it
    /// (e.g. functions that take ownership of the pointer).
    /// </summary>
    internal IntPtr SmartPtr
    {
        get
        {
            ThrowIfDisposed();
            return _lifecycleHandle?.DangerousGetHandle() ?? IntPtr.Zero;
        }
    }

    /// <inheritdoc />
    protected override void DisposeManaged()
    {
        _lifecycleHandle?.Dispose();
        _lifecycleHandle = null;
    }
}
