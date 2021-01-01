using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style
// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // BriefDescriptorExtractor

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_BriefDescriptorExtractor_create(int bytes, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_Ptr_BriefDescriptorExtractor_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_BriefDescriptorExtractor_read(IntPtr obj, IntPtr fn);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_BriefDescriptorExtractor_write(IntPtr obj, IntPtr fs);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_BriefDescriptorExtractor_descriptorSize(IntPtr obj, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_BriefDescriptorExtractor_descriptorType(IntPtr obj, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_Ptr_BriefDescriptorExtractor_get(IntPtr ptr, out IntPtr returnValue);


        // FREAK

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_FREAK_create(int orientationNormalized,
            int scaleNormalized, float patternScale, int nOctaves,
            int[]? selectedPairs, int selectedPairsLength,
            out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_Ptr_FREAK_delete(IntPtr ptr);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_Ptr_FREAK_get(IntPtr ptr, out IntPtr returnValue);

        // StarDetector
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_StarDetector_create(
            int maxSize, int responseThreshold,
            int lineThresholdProjected, int lineThresholdBinarized, int suppressNonmaxSize, 
            out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_Ptr_StarDetector_delete(IntPtr ptr);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_Ptr_StarDetector_get(IntPtr ptr, out IntPtr returnValue);


        // LUCID

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_LUCID_create(int lucidKernel, int blurKernel, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_Ptr_LUCID_delete(IntPtr ptr);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_Ptr_LUCID_get(IntPtr ptr, out IntPtr returnValue);


        // LATCH

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_LATCH_create(
            int bytes, int rotationInvariance, int halfSsdSize, double sigma, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_Ptr_LATCH_delete(IntPtr ptr);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_Ptr_LATCH_get(IntPtr ptr, out IntPtr returnValue);


        // SURF

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_SURF_create(
            double hessianThreshold, int nOctaves,
            int nOctaveLayers, int extended, int upright, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_Ptr_SURF_delete(IntPtr ptr);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_Ptr_SURF_get(IntPtr ptr, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_SURF_getHessianThreshold(IntPtr obj, out double returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_SURF_getNOctaves(IntPtr obj, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_SURF_getNOctaveLayers(IntPtr obj, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_SURF_getExtended(IntPtr obj, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_SURF_getUpright(IntPtr obj, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_SURF_setHessianThreshold(IntPtr obj, double value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_SURF_setNOctaves(IntPtr obj, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_SURF_setNOctaveLayers(IntPtr obj, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_SURF_setExtended(IntPtr obj, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus xfeatures2d_SURF_setUpright(IntPtr obj, int value);
    }
}