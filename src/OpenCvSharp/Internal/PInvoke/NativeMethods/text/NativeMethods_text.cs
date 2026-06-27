using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // BaseOCR
    /*
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_BaseOCR_run1(
        IntPtr obj,
        IntPtr image,
        IntPtr outputText,
        IntPtr componentRects,
        IntPtr componentTexts,
        IntPtr componentConfidences,
        int componentLevel);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_BaseOCR_run2(
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

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_OCRTesseract_run1(
        IntPtr obj,
        IntPtr image,
        IntPtr outputText,
        IntPtr componentRects,
        IntPtr componentTexts,
        IntPtr componentConfidences,
        int componentLevel);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_OCRTesseract_run2(
        IntPtr obj,
        IntPtr image,
        IntPtr mask,
        IntPtr outputText,
        IntPtr componentRects,
        IntPtr componentTexts,
        IntPtr componentConfidences,
        int componentLevel);

    /*
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_OCRTesseract_run3(
        IntPtr obj,
        IntPtr image,
        int minConfidence,
        int componentLevel,
        IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_OCRTesseract_run4(
        IntPtr obj,
        IntPtr image,
        IntPtr mask,
        int minConfidence,
        int componentLevel,
        IntPtr dst);*/

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_OCRTesseract_setWhiteList(
        IntPtr obj, 
        [MarshalAs(UnmanagedType.LPStr)] string charWhitelist);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_OCRTesseract_create(
        [MarshalAs(UnmanagedType.LPStr)] string? datapath,
        [MarshalAs(UnmanagedType.LPStr)] string? language,
        [MarshalAs(UnmanagedType.LPStr)] string? charWhitelist,
        int oem,
        int psmode, 
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_Ptr_OCRTesseract_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_Ptr_OCRTesseract_delete(IntPtr obj);

    // swt_text_detection.hpp

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_detectTextSWT(
        IntPtr input, IntPtr result, int darkOnLight, IntPtr draw, IntPtr chainBBs);
}
