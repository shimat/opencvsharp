using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_Ptr_OCRHolisticWordRecognizer_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_Ptr_OCRHolisticWordRecognizer_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_OCRHolisticWordRecognizer_create(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string archFilename,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string weightsFilename,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string wordsFilename,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_OCRHolisticWordRecognizer_run1(
        OpenCvSafeHandle obj,
        IntPtr image,
        IntPtr outputText,
        IntPtr componentRects,
        IntPtr componentTexts,
        IntPtr componentConfidences,
        int componentLevel);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_OCRHolisticWordRecognizer_run2(
        OpenCvSafeHandle obj,
        IntPtr image,
        IntPtr mask,
        IntPtr outputText,
        IntPtr componentRects,
        IntPtr componentTexts,
        IntPtr componentConfidences,
        int componentLevel);
}
