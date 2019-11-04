using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // ReSharper disable once IdentifierTypo
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void text_TextDetector_detect(IntPtr obj, IntPtr inputImage, IntPtr bbox, IntPtr confidence);

        // ReSharper disable once IdentifierTypo
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void text_TextDetectorCNN_detect(IntPtr obj, IntPtr inputImage, IntPtr bbox, IntPtr confidence);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr text_TextDetectorCNN_create1(
            [MarshalAs(UnmanagedType.LPStr)] string modelArchFilename,
            [MarshalAs(UnmanagedType.LPStr)] string modelWeightsFilename,
            [MarshalAs(UnmanagedType.LPArray)] Size[] detectionSizes, int detectionSizesLength);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr text_TextDetectorCNN_create2(
            [MarshalAs(UnmanagedType.LPStr)] string modelArchFilename, 
            [MarshalAs(UnmanagedType.LPStr)] string modelWeightsFilename);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void text_Ptr_TextDetectorCNN_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr text_Ptr_TextDetectorCNN_get(IntPtr obj);
    }
}