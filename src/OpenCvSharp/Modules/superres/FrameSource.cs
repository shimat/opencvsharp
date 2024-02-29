using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// 
/// </summary>
public class FrameSource : DisposableCvObject
{
    private Ptr? ptrObj;

    #region Init & Disposal

    /// <summary>
    /// Creates instance from cv::Ptr&lt;T&gt; .
    /// ptr is disposed when the wrapper disposes. 
    /// </summary>
    /// <param name="ptr"></param>
    private static FrameSource FromPtr(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException("Invalid FrameSource pointer");
        var obj = new FrameSource();
        var ptrObj = new Ptr(ptr);
        obj.ptrObj = ptrObj;
        obj.ptr = ptr;
        return obj;
    }

    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        ptrObj?.Dispose();
        ptrObj = null;
        base.DisposeManaged();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static FrameSource CreateFrameSource_Empty()
    {
        NativeMethods.HandleException(
            NativeMethods.superres_createFrameSource_Empty(out var ptr));
        return FromPtr(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static FrameSource CreateFrameSource_Video(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentNullException(nameof(fileName));
        if (!File.Exists(fileName))
            throw new FileNotFoundException("", fileName);

        NativeMethods.HandleException(
            NativeMethods.superres_createFrameSource_Video(fileName, out var ptr));
        return FromPtr(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static FrameSource CreateFrameSource_Video_CUDA(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentNullException(nameof(fileName));
        if (!File.Exists(fileName))
            throw new FileNotFoundException("", fileName);

        NativeMethods.HandleException(
            NativeMethods.superres_createFrameSource_Video_CUDA(fileName, out var ptr));
        return FromPtr(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="deviceId"></param>
    /// <returns></returns>
    public static FrameSource CreateFrameSource_Camera(int deviceId)
    {
        NativeMethods.HandleException(
            NativeMethods.superres_createFrameSource_Camera(deviceId, out var ptr));
        return FromPtr(ptr);
    }

    #endregion

    #region Methods
        
    /// <summary>
    /// 
    /// </summary>
    /// <param name="frame"></param>
    public virtual void NextFrame(OutputArray frame)
    {
        ThrowIfDisposed();
        if (frame is null)
            throw new ArgumentNullException(nameof(frame));
        frame.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.superres_FrameSource_nextFrame(ptr, frame.CvPtr));

        frame.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(frame);
    }

    /// <summary>
    /// 
    /// </summary>
    public virtual void Reset()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.superres_FrameSource_reset(ptr));
        GC.KeepAlive(this);
    }

    #endregion

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.superres_Ptr_FrameSource_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.superres_Ptr_FrameSource_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
