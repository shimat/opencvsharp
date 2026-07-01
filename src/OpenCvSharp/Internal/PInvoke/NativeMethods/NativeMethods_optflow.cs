using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    #region motempl

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_motempl_updateMotionHistory(
        in InputArrayProxy silhouette, in InputOutputArrayProxy mhi,
        double timestamp, double duration);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_motempl_calcMotionGradient(
        in InputArrayProxy mhi, in OutputArrayProxy mask, in OutputArrayProxy orientation,
        double delta1, double delta2, int apertureSize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_motempl_calcGlobalOrientation(
        in InputArrayProxy orientation, in InputArrayProxy mask,
        in InputArrayProxy mhi, double timestamp, double duration, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_motempl_segmentMotion(
        in InputArrayProxy mhi, in OutputArrayProxy segmask, IntPtr boundingRects,
        double timestamp, double segThresh);

    #endregion


    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_calcOpticalFlowSF1(
        in InputArrayProxy from, in InputArrayProxy to, in OutputArrayProxy flow,
        int layers,
        int averagingBlockSize,
        int maxFlow);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_calcOpticalFlowSF2(
        in InputArrayProxy from, in InputArrayProxy to, in OutputArrayProxy flow,
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

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_calcOpticalFlowSparseToDense(
        in InputArrayProxy from, in InputArrayProxy to, in OutputArrayProxy flow,
        int gridStep, int k, float sigma, int usePostProc, float fgsLambda, float fgsSigma);
}
