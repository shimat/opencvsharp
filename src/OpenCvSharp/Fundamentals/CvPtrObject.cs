namespace OpenCvSharp;

/// <summary>
/// Base class for OpenCV Algorithm-hierarchy objects.
/// The owned <see cref="OpenCvSafeHandle"/> (in <see cref="CvObject"/>) wraps the raw <c>T*</c> used
/// for P/Invoke, so <see cref="RawPtr"/>, <see cref="CvObject.CvPtr"/> and <see cref="CvObject.Handle"/>
/// all yield that pointer. When the object is owned through a <c>cv::Ptr&lt;T&gt;*</c> smart pointer,
/// that smart pointer (kept in <see cref="smartPtr"/>) is what gets released on disposal.
/// </summary>
public abstract class CvPtrObject : CvObject
{
    private readonly IntPtr smartPtr;

    /// <summary>
    /// Factory-pattern constructor.
    /// <paramref name="smartPtr"/> is a cv::Ptr&lt;T&gt;* that owns the object lifetime;
    /// <paramref name="rawPtr"/> is the T* extracted from it for P/Invoke.
    /// </summary>
    protected CvPtrObject(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> releaseSmartPtr)
    {
        this.smartPtr = smartPtr;
        // The handle is the raw T* (so it marshals correctly to P/Invoke), but releasing it must
        // delete the smart pointer that actually owns the lifetime.
        SetSafeHandle(new OpenCvPtrSafeHandle(rawPtr, ownsHandle: true, releaseAction: _ => releaseSmartPtr(smartPtr)));
    }

    /// <summary>
    /// Direct-allocation constructor.
    /// <paramref name="rawPtr"/> is a T* that is released directly by <paramref name="releaseRawPtr"/>.
    /// </summary>
    protected CvPtrObject(IntPtr rawPtr, Action<IntPtr> releaseRawPtr)
    {
        smartPtr = IntPtr.Zero;
        SetSafeHandle(new OpenCvPtrSafeHandle(rawPtr, ownsHandle: true, releaseAction: releaseRawPtr));
    }

    /// <summary>
    /// Returns the raw T* for use in P/Invoke calls.
    /// </summary>
    public IntPtr RawPtr
    {
        get
        {
            ThrowIfDisposed();
            return CvPtr;
        }
    }

    /// <summary>
    /// Returns the cv::Ptr&lt;T&gt;* smart pointer for P/Invoke calls that require it
    /// (e.g. functions that take ownership of the pointer). Falls back to the raw pointer
    /// for directly-allocated objects that have no smart pointer.
    /// </summary>
    internal IntPtr SmartPtr
    {
        get
        {
            ThrowIfDisposed();
            return smartPtr != IntPtr.Zero ? smartPtr : CvPtr;
        }
    }
}
