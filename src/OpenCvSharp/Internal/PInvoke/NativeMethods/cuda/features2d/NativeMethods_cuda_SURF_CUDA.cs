#if ENABLED_CUDA
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SURF_CUDA_new(double hessianThreshold, int nOctaves, int nOctaveLayers, int extended, float keypointsRatio, int upright, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SURF_CUDA_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SURF_CUDA_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SURF_CUDA_detect(IntPtr obj, IntPtr img, IntPtr mask, IntPtr keypoints);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SURF_CUDA_detectWithDescriptors(IntPtr obj, IntPtr img, IntPtr mask, IntPtr keypoints, IntPtr descriptors, int useProvidedKeypoints);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SURF_CUDA_downloadKeypoints(IntPtr obj, IntPtr keypointsGPU, IntPtr keypoints);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SURF_CUDA_downloadDescriptors(IntPtr obj, IntPtr descriptorsGPU, IntPtr descriptors);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SURF_CUDA_uploadKeypoints(IntPtr obj, IntPtr keypoints, IntPtr keypointsGPU);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SURF_CUDA_descriptorSize(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SURF_CUDA_getHessianThreshold(IntPtr obj, out double val);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SURF_CUDA_setHessianThreshold(IntPtr obj, double val);
}
#endif
