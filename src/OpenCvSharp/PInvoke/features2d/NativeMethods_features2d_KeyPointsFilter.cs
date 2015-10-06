using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // ReSharper disable InconsistentNaming

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_KeyPointsFilter_runByImageBorder(
            IntPtr keypoints, Size imageSize, int borderSize);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_KeyPointsFilter_runByKeypointSize(
            IntPtr keypoints, float minSize, float maxSize);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_KeyPointsFilter_runByPixelsMask(
            IntPtr keypoints, IntPtr mask);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_KeyPointsFilter_removeDuplicated(
            IntPtr keypoints);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_KeyPointsFilter_retainBest(
            IntPtr keypoints, int npoints);
    }
}