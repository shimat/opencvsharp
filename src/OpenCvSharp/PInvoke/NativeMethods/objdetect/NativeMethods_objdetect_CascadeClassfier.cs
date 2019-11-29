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
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr objdetect_CascadeClassifier_new();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern IntPtr objdetect_CascadeClassifier_newFromFile([MarshalAs(UnmanagedType.LPStr)] string fileName);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void objdetect_CascadeClassifier_delete(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int objdetect_CascadeClassifier_empty(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern int objdetect_CascadeClassifier_load(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string fileName);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void objdetect_CascadeClassifier_detectMultiScale1(
            IntPtr obj, IntPtr image, IntPtr objects,
            double scaleFactor, int minNeighbors, int flags, Size minSize, Size maxSize);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void objdetect_CascadeClassifier_detectMultiScale2(
            IntPtr obj, IntPtr image, IntPtr objects,
            IntPtr rejectLevels, IntPtr levelWeights,
            double scaleFactor, int minNeighbors, int flags,
            Size minSize, Size maxSize, int outputRejectLevels);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int objdetect_CascadeClassifier_isOldFormatCascade(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Size objdetect_CascadeClassifier_getOriginalWindowSize(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int objdetect_CascadeClassifier_getFeatureType(IntPtr obj);
    }
}