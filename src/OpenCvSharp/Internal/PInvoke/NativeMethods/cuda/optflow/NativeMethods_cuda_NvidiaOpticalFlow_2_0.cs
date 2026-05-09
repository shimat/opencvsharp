#pragma warning disable 1591

using System.Runtime.InteropServices;

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_createNvidiaOpticalFlow_2_0(
    Size imageSize, int perfPreset, int outputGridSize, int hintGridSize,
    int enableTemporalHints, int enableExternalHints, int enableCostBuffer, int gpuId,
    IntPtr inputStream, IntPtr outputStream, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_createNvidiaOpticalFlow_2_0_roi(
        Size imageSize, [In] Rect[] roiData, int roiCount, int perfPreset, int outputGridSize, int hintGridSize,
        int enableTemporalHints, int enableExternalHints, int enableCostBuffer, int gpuId,
        IntPtr inputStream, IntPtr outputStream, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_NvidiaOpticalFlow_2_0_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_NvidiaOpticalFlow_2_0_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_NvidiaOpticalFlow_2_0_convertToFloat(IntPtr obj, IntPtr flow, IntPtr floatFlow);
}
