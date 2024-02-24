using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    #region motempl

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus optflow_motempl_updateMotionHistory(
        IntPtr silhouette, IntPtr mhi,
        double timestamp, double duration);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus optflow_motempl_calcMotionGradient(
        IntPtr mhi, IntPtr mask, IntPtr orientation,
        double delta1, double delta2, int apertureSize);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus optflow_motempl_calcGlobalOrientation(
        IntPtr orientation, IntPtr mask,
        IntPtr mhi, double timestamp, double duration, out double returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus optflow_motempl_segmentMotion(
        IntPtr mhi, IntPtr segmask, IntPtr boundingRects,
        double timestamp, double segThresh);

    #endregion


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus optflow_calcOpticalFlowSF1(
        IntPtr from, IntPtr to, IntPtr flow,
        int layers,
        int averagingBlockSize,
        int maxFlow);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus optflow_calcOpticalFlowSF2(
        IntPtr from, IntPtr to, IntPtr flow,
        int layers,
        int averagingBlockSize,
        int maxFlow,
        double sigmaDist,
        double sigmaColor,
        int postprocessWindow,
        double sigmaDistFix,
        double sigmaColorFix,
        double occThr,
        int upscaleAveragingRadius,
        double upscaleSigmaDist,
        double upscaleSigmaColor,
        double speedUpThr);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus optflow_calcOpticalFlowSparseToDense(
        IntPtr from, IntPtr to, IntPtr flow,
        int gridStep, int k, float sigma, int usePostProc, float fgsLambda, float fgsSigma);
}
