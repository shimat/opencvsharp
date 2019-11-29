using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_FastHoughTransform(IntPtr src, IntPtr dst,
            int dstMatDepth, int angleRange, int op, int makeSkew);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Vec4i ximgproc_HoughPoint2Line(Point houghPoint, IntPtr srcImgInfo,
            int angleRange, int makeSkew, int rules);
    }
}