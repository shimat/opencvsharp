using System;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    // ReSharper disable InconsistentNaming

    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_minMaxLoc1(
            IntPtr src, out double minVal, out double maxVal, out Point minLoc, out Point maxLoc,
            IntPtr mask);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_minMaxLoc2(
            IntPtr src, out double minVal, out double maxVal, out Point minLoc, out Point maxLoc,
            IntPtr mask, IntPtr valbuf, IntPtr locbuf);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_matchTemplate1(
            IntPtr image, IntPtr templ, IntPtr result, int method, IntPtr stream);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_matchTemplate2(
            IntPtr image, IntPtr templ, IntPtr result, int method, IntPtr buf, IntPtr stream);
    }
}