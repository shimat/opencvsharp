#if ENABLED_CUDA
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
#pragma warning disable 1591
namespace OpenCvSharp.Internal
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_createGoodFeaturesToTrackDetector(int srcType, int maxCorners, double qualityLevel, double minDistance, int blockSize, int useHarrisDetector, double harrisK, out IntPtr returnValue);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_CornersDetector_get(IntPtr ptr, out IntPtr returnValue);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_CornersDetector_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_CornersDetector_detect(IntPtr obj, IntPtr image, IntPtr corners, IntPtr mask, IntPtr stream);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_CornersDetector_setMinDistance(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus cuda_CornersDetector_setMaxCorners(IntPtr obj, int val);
    }

}

#endif
