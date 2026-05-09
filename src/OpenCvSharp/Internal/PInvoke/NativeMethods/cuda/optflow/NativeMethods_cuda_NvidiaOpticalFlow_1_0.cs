#pragma warning disable 1591

using System.Runtime.InteropServices;

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_createNvidiaOpticalFlow_1_0(
    Size imageSize, int perfPreset, int enableTemporalHints,
    int enableExternalHints, int enableCostBuffer, int gpuId,
    IntPtr inputStream, IntPtr outputStream, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_NvidiaOpticalFlow_1_0_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_NvidiaOpticalFlow_1_0_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_NvidiaOpticalFlow_1_0_upSampler(
        IntPtr obj, IntPtr flow, Size imageSize, int gridSize, IntPtr upsampledFlow);
}
