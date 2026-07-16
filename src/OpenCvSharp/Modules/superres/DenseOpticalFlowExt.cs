using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <inheritdoc />
/// <summary>
/// </summary>
public abstract class DenseOpticalFlowExt : Algorithm
{
    #region Init & Disposal

    /// <summary>
    /// 
    /// </summary>
    protected DenseOpticalFlowExt(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release) { }

    /// <summary>
    /// Creates instance from cv::Ptr&lt;T&gt; .
    /// ptr is disposed when the wrapper disposes.
    /// </summary>
    /// <param name="ptr"></param>
    internal static DenseOpticalFlowExt FromPtr(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException("Invalid DenseOpticalFlowExt pointer");

        NativeMethods.HandleException(NativeMethods.superres_Ptr_DenseOpticalFlowExt_get(ptr, out var rawPtr));
        return new GenericDenseOpticalFlowExt(ptr, rawPtr);
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public static DenseOpticalFlowExt CreateFarneback()
    {
        NativeMethods.HandleException(
            NativeMethods.superres_createOptFlow_Farneback(out var ptr));
        return FarnebackOpticalFlow.FromPtr(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static DenseOpticalFlowExt CreateFarneback_CUDA()
    {
        NativeMethods.HandleException(
            NativeMethods.superres_createOptFlow_Farneback_CUDA(out var ptr));
        return FarnebackOpticalFlow.FromPtr(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static DenseOpticalFlowExt CreateDualTVL1()
    {
        NativeMethods.HandleException(
            NativeMethods.superres_createOptFlow_DualTVL1(out var ptr));
        return DualTVL1OpticalFlow.FromPtr(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static DenseOpticalFlowExt CreateDualTVL1_CUDA()
    {
        NativeMethods.HandleException(
            NativeMethods.superres_createOptFlow_DualTVL1_CUDA(out var ptr));
        return DualTVL1OpticalFlow.FromPtr(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static DenseOpticalFlowExt CreateBrox_CUDA()
    {
        NativeMethods.HandleException(
            NativeMethods.superres_createOptFlow_Brox_CUDA(out var ptr));
        return BroxOpticalFlow.FromPtr(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static DenseOpticalFlowExt CreatePyrLK_CUDA()
    {
        NativeMethods.HandleException(
            NativeMethods.superres_createOptFlow_PyrLK_CUDA(out var ptr));
        return PyrLKOpticalFlow.FromPtr(ptr);
    }

    #endregion

    /// <summary>
    /// Clear all inner buffers.
    /// </summary>
    public virtual void CollectGarbage()
    {
        NativeMethods.HandleException(
            NativeMethods.superres_DenseOpticalFlowExt_collectGarbage(Handle));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="frame0"></param>
    /// <param name="frame1"></param>
    /// <param name="flow1"></param>
    /// <param name="flow2"></param>
    public virtual void Calc(InputArray frame0, InputArray frame1, OutputArray flow1, OutputArray flow2 = default)
    {
        NativeMethods.HandleException(
            NativeMethods.superres_DenseOpticalFlowExt_calc(
                Handle, frame0.Proxy, frame1.Proxy, flow1.Proxy, flow2.Proxy));

        GC.KeepAlive(frame0.Source);
        GC.KeepAlive(frame1.Source);
        GC.KeepAlive(flow1.Source);
        GC.KeepAlive(flow2.Source);
    }

    private sealed class GenericDenseOpticalFlowExt : DenseOpticalFlowExt
    {
        public GenericDenseOpticalFlowExt(IntPtr smartPtr, IntPtr rawPtr)
            : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.superres_Ptr_DenseOpticalFlowExt_delete(p)))
        {
        }
    }
}
