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

    #region createOptFlow_* factories (opaque Ptr<DenseOpticalFlow>/Ptr<SparseOpticalFlow>)

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_createOptFlow_DeepFlow(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_createOptFlow_SimpleFlow(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_createOptFlow_Farneback(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_createOptFlow_SparseToDense(out IntPtr returnValue);

    #endregion

    #region DualTVL1OpticalFlow

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_Ptr_DualTVL1OpticalFlow_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_Ptr_DualTVL1OpticalFlow_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_create(
        double tau, double lambda, double theta, int nscales, int warps, double epsilon,
        int innerIterations, int outerIterations, double scaleStep, double gamma,
        int medianFiltering, int useInitialFlow, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_createOptFlow_DualTVL1(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_getTau(OpenCvSafeHandle obj, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_setTau(OpenCvSafeHandle obj, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_getLambda(OpenCvSafeHandle obj, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_setLambda(OpenCvSafeHandle obj, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_getTheta(OpenCvSafeHandle obj, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_setTheta(OpenCvSafeHandle obj, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_getGamma(OpenCvSafeHandle obj, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_setGamma(OpenCvSafeHandle obj, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_getScalesNumber(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_setScalesNumber(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_getWarpingsNumber(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_setWarpingsNumber(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_getEpsilon(OpenCvSafeHandle obj, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_setEpsilon(OpenCvSafeHandle obj, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_getInnerIterations(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_setInnerIterations(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_getOuterIterations(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_setOuterIterations(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_getUseInitialFlow(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_setUseInitialFlow(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_getScaleStep(OpenCvSafeHandle obj, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_setScaleStep(OpenCvSafeHandle obj, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_getMedianFiltering(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DualTVL1OpticalFlow_setMedianFiltering(OpenCvSafeHandle obj, int value);

    #endregion

    #region PCAPrior

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_Ptr_PCAPrior_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_Ptr_PCAPrior_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_PCAPrior_new(string pathToPrior, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_PCAPrior_getPadding(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_PCAPrior_getBasisSize(OpenCvSafeHandle obj, out int returnValue);

    #endregion

    #region OpticalFlowPCAFlow

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_Ptr_OpticalFlowPCAFlow_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_Ptr_OpticalFlowPCAFlow_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_OpticalFlowPCAFlow_new(
        IntPtr prior, int basisSizeWidth, int basisSizeHeight,
        float sparseRate, float retainedCornersFraction, float occlusionsThreshold,
        float dampingFactor, float claheClip, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_createOptFlow_PCAFlow(out IntPtr returnValue);

    #endregion

    #region RLOFOpticalFlowParameter

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_Ptr_RLOFOpticalFlowParameter_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_Ptr_RLOFOpticalFlowParameter_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_create(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_setUseMEstimator(OpenCvSafeHandle obj, int val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_getSolverType(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_setSolverType(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_getSupportRegionType(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_setSupportRegionType(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_getNormSigma0(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_setNormSigma0(OpenCvSafeHandle obj, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_getNormSigma1(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_setNormSigma1(OpenCvSafeHandle obj, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_getSmallWinSize(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_setSmallWinSize(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_getLargeWinSize(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_setLargeWinSize(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_getCrossSegmentationThreshold(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_setCrossSegmentationThreshold(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_getMaxLevel(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_setMaxLevel(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_getUseInitialFlow(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_setUseInitialFlow(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_getUseIlluminationModel(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_setUseIlluminationModel(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_getUseGlobalMotionPrior(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_setUseGlobalMotionPrior(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_getMaxIteration(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_setMaxIteration(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_getMinEigenValue(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_setMinEigenValue(OpenCvSafeHandle obj, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_getGlobalMotionRansacThreshold(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_RLOFOpticalFlowParameter_setGlobalMotionRansacThreshold(OpenCvSafeHandle obj, float value);

    #endregion

    #region DenseRLOFOpticalFlow

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_Ptr_DenseRLOFOpticalFlow_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_Ptr_DenseRLOFOpticalFlow_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_create(
        IntPtr rlofParam, float forwardBackwardThreshold, Size gridStep, int interpType,
        int epicK, float epicSigma, float epicLambda, int ricSPSize, int ricSLICType,
        int usePostProc, float fgsLambda, float fgsSigma, int useVariationalRefinement,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_getRLOFOpticalFlowParameter(OpenCvSafeHandle obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_setRLOFOpticalFlowParameter(OpenCvSafeHandle obj, IntPtr val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_getForwardBackward(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_setForwardBackward(OpenCvSafeHandle obj, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_getGridStep(OpenCvSafeHandle obj, out Size returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_setGridStep(OpenCvSafeHandle obj, Size value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_getInterpolation(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_setInterpolation(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_getEPICK(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_setEPICK(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_getEPICSigma(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_setEPICSigma(OpenCvSafeHandle obj, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_getEPICLambda(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_setEPICLambda(OpenCvSafeHandle obj, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_getFgsLambda(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_setFgsLambda(OpenCvSafeHandle obj, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_getFgsSigma(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_setFgsSigma(OpenCvSafeHandle obj, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_getUsePostProc(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_setUsePostProc(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_getUseVariationalRefinement(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_setUseVariationalRefinement(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_getRICSPSize(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_setRICSPSize(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_getRICSLICType(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_DenseRLOFOpticalFlow_setRICSLICType(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_createOptFlow_DenseRLOF(out IntPtr returnValue);

    #endregion

    #region SparseRLOFOpticalFlow

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_Ptr_SparseRLOFOpticalFlow_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_Ptr_SparseRLOFOpticalFlow_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_SparseRLOFOpticalFlow_create(
        IntPtr rlofParam, float forwardBackwardThreshold, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_SparseRLOFOpticalFlow_getRLOFOpticalFlowParameter(OpenCvSafeHandle obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_SparseRLOFOpticalFlow_setRLOFOpticalFlowParameter(OpenCvSafeHandle obj, IntPtr val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_SparseRLOFOpticalFlow_getForwardBackward(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_SparseRLOFOpticalFlow_setForwardBackward(OpenCvSafeHandle obj, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_createOptFlow_SparseRLOF(out IntPtr returnValue);

    #endregion

    #region calcOpticalFlowDenseRLOF / calcOpticalFlowSparseRLOF

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_calcOpticalFlowDenseRLOF(
        in InputArrayProxy I0, in InputArrayProxy I1, in InputOutputArrayProxy flow,
        IntPtr rlofParam, float forwardBackwardThreshold, Size gridStep, int interpType,
        int epicK, float epicSigma, float epicLambda, int ricSPSize, int ricSLICType,
        int usePostProc, float fgsLambda, float fgsSigma, int useVariationalRefinement);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_calcOpticalFlowSparseRLOF(
        in InputArrayProxy prevImg, in InputArrayProxy nextImg,
        in InputArrayProxy prevPts, in InputOutputArrayProxy nextPts,
        in OutputArrayProxy status, in OutputArrayProxy err,
        IntPtr rlofParam, float forwardBackwardThreshold);

    #endregion
}
