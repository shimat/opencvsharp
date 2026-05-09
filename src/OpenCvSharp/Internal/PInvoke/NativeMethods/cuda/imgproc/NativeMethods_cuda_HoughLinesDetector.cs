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
        public static extern ExceptionStatus cuda_createHoughLinesDetector(float rho, float theta, int threshold, int doSort, int maxLines, out IntPtr returnValue);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_HoughLinesDetector_get(IntPtr ptr, out IntPtr returnValue);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_HoughLinesDetector_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_HoughLinesDetector_detect(IntPtr obj, IntPtr src, IntPtr lines, IntPtr stream);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_HoughLinesDetector_downloadResults(
    IntPtr obj, IntPtr dLines, IntPtr hLines, IntPtr hVotes, IntPtr stream);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_HoughLinesDetector_getDoSort(IntPtr obj, out int val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_HoughLinesDetector_setDoSort(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_HoughLinesDetector_getMaxLines(IntPtr obj, out int val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_HoughLinesDetector_setMaxLines(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_HoughLinesDetector_getRho(IntPtr obj, out float val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_HoughLinesDetector_setRho(IntPtr obj, float val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_HoughLinesDetector_getTheta(IntPtr obj, out float val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_HoughLinesDetector_setTheta(IntPtr obj, float val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_HoughLinesDetector_getThreshold(IntPtr obj, out int val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_HoughLinesDetector_setThreshold(IntPtr obj, int val);
    }
}
#endif
