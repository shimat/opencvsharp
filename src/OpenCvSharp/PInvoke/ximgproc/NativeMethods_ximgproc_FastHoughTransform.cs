using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_FastHoughTransform(IntPtr src, IntPtr dst,
            int dstMatDepth, int angleRange, int op, int makeSkew);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Vec4i ximgproc_HoughPoint2Line(Point houghPoint, IntPtr srcImgInfo,
            int angleRange, int makeSkew, int rules);
    }
}