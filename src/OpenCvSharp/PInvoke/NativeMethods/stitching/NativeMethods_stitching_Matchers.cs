using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using OpenCvSharp.Detail;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp
{

    static partial class NativeMethods
    {
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_computeImageFeatures1_1(
            IntPtr featuresFinder,
            IntPtr[] images,
            int imagesLength,
            IntPtr[] features,
            IntPtr[] masks);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_computeImageFeatures1_2(
            IntPtr featuresFinder,
            IntPtr[] images,
            int imagesLength,
            IntPtr[] features,
            IntPtr masks);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe ExceptionStatus stitching_computeImageFeatures2(
            IntPtr featuresFinder,
            IntPtr image,
            WImageFeatures* features,
            IntPtr mask);
    }
}