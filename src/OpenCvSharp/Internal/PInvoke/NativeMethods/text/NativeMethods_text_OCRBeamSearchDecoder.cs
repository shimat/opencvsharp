using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // OCRBeamSearchDecoder::ClassifierCallback

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_Ptr_OCRBeamSearchDecoder_ClassifierCallback_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_Ptr_OCRBeamSearchDecoder_ClassifierCallback_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_loadOCRBeamSearchClassifierCNN(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, out IntPtr returnValue);

    // OCRBeamSearchDecoder

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_Ptr_OCRBeamSearchDecoder_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_Ptr_OCRBeamSearchDecoder_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus text_OCRBeamSearchDecoder_create_callback(
        IntPtr classifier, [MarshalAs(UnmanagedType.LPUTF8Str)] string vocabulary,
        in InputArrayProxy transitionProbabilitiesTable, in InputArrayProxy emissionProbabilitiesTable,
        int mode, int beamSize, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus text_OCRBeamSearchDecoder_create_file(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, [MarshalAs(UnmanagedType.LPUTF8Str)] string vocabulary,
        in InputArrayProxy transitionProbabilitiesTable, in InputArrayProxy emissionProbabilitiesTable,
        int mode, int beamSize, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_OCRBeamSearchDecoder_run1(
        OpenCvSafeHandle obj,
        IntPtr image,
        IntPtr outputText,
        IntPtr componentRects,
        IntPtr componentTexts,
        IntPtr componentConfidences,
        int componentLevel);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_OCRBeamSearchDecoder_run2(
        OpenCvSafeHandle obj,
        IntPtr image,
        IntPtr mask,
        IntPtr outputText,
        IntPtr componentRects,
        IntPtr componentTexts,
        IntPtr componentConfidences,
        int componentLevel);
}
