#if ENABLED_CUDA
using System;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Cuda;

#pragma warning disable 1591

namespace OpenCvSharp.Internal
{
    static partial class NativeMethods
    {

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_createHarrisCorner(int srcType, int blockSize, int ksize, double k, int borderType, out IntPtr returnValue);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_createMinEigenValCorner(int srcType, int blockSize, int ksize, int borderType, out IntPtr returnValue);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_CornernessCriteria_get(IntPtr ptr, out IntPtr returnValue);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_CornernessCriteria_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_CornernessCriteria_compute(IntPtr obj, IntPtr src, IntPtr dst, IntPtr stream);



    }
}
#endif
