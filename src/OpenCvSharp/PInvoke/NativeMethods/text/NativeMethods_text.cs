using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // BaseOCR
        /*
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus text_BaseOCR_run1(
            IntPtr obj,
            IntPtr image,
            IntPtr outputText,
            IntPtr componentRects,
            IntPtr componentTexts,
            IntPtr componentConfidences,
            int componentLevel);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus text_BaseOCR_run2(
            IntPtr obj,
            IntPtr image,
            IntPtr mask,
            IntPtr outputText,
            IntPtr componentRects,
            IntPtr componentTexts,
            IntPtr componentConfidences,
            int componentLevel);
        */

        // OCRTesseract

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus text_OCRTesseract_run1(
            IntPtr obj,
            IntPtr image,
            IntPtr outputText,
            IntPtr componentRects,
            IntPtr componentTexts,
            IntPtr componentConfidences,
            int componentLevel);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus text_OCRTesseract_run2(
            IntPtr obj,
            IntPtr image,
            IntPtr mask,
            IntPtr outputText,
            IntPtr componentRects,
            IntPtr componentTexts,
            IntPtr componentConfidences,
            int componentLevel);

        /*
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus text_OCRTesseract_run3(
            IntPtr obj,
            IntPtr image,
            int minConfidence,
            int componentLevel,
            IntPtr dst);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus text_OCRTesseract_run4(
            IntPtr obj,
            IntPtr image,
            IntPtr mask,
            int minConfidence,
            int componentLevel,
            IntPtr dst);*/

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus text_OCRTesseract_setWhiteList(
            IntPtr obj, 
            [MarshalAs(UnmanagedType.LPStr)] string charWhitelist);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus text_OCRTesseract_create(
            [MarshalAs(UnmanagedType.LPStr)] string? datapath,
            [MarshalAs(UnmanagedType.LPStr)] string? language,
            [MarshalAs(UnmanagedType.LPStr)] string? charWhitelist,
            int oem,
            int psmode, 
            out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus text_Ptr_OCRTesseract_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus text_OCRTesseract_get(IntPtr obj, out IntPtr returnValue);

        // swt_text_detection.hpp

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus text_detectTextSWT(
            IntPtr input, IntPtr result, int darkOnLight, IntPtr draw, IntPtr chainBBs);
    }
}