#pragma warning disable CA1051 // Do not declare visible instance fields
#pragma warning disable CA2216

namespace OpenCvSharp;

/// <summary>
/// DisposableObject + ICvPtrHolder
/// </summary>
public abstract class DisposableCvObject : DisposableObject, ICvPtrHolder
{
    /// <summary>
    /// Data pointer
    /// </summary>
    protected IntPtr ptr;

    /// <summary>
    /// Default constructor
    /// </summary>
    protected DisposableCvObject()
        : this(true)
    {
    }

    /// <summary>
    /// Constructor
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
        : this(IntPtr.Zero, isEnabledDispose)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="ptr"></param>
    /// <param name="isEnabledDispose"></param>
    protected DisposableCvObject(IntPtr ptr, bool isEnabledDispose)
        : base(isEnabledDispose)
    {
        this.ptr = ptr;
    }

    /// <summary>
    /// releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        ptr = IntPtr.Zero;
        base.DisposeUnmanaged();
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
