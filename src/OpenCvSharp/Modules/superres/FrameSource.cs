using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// 
/// </summary>
public class FrameSource : CvObject
{
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
        obj.SetSafeHandle(new OpenCvPtrSafeHandle(ptr, ownsHandle: true,
            releaseAction: _ => NativeMethods.HandleException(NativeMethods.superres_Ptr_FrameSource_delete(ptr))));
        return obj;
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
            NativeMethods.superres_FrameSource_nextFrame(CvPtr, frame.CvPtr));

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
            NativeMethods.superres_FrameSource_reset(CvPtr));
        GC.KeepAlive(this);
    }

    #endregion

    }
