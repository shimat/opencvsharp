using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // ReSharper disable InconsistentNaming

    [LibraryImport(DllExtern, EntryPoint = "dnn_Tokenizer_load"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Tokenizer_load_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string modelConfig, out IntPtr returnValue);

    [LibraryImport(DllExtern, EntryPoint = "dnn_Tokenizer_load"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Tokenizer_load_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string modelConfig, out IntPtr returnValue);

    public static ExceptionStatus dnn_Tokenizer_load(string modelConfig, out IntPtr returnValue)
        => IsWindows()
            ? dnn_Tokenizer_load_Windows(modelConfig, out returnValue)
            : dnn_Tokenizer_load_NotWindows(modelConfig, out returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Tokenizer_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Tokenizer_encode(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Tokenizer_decode(OpenCvSafeHandle obj, int[] tokens, int tokensLength, IntPtr returnValue);
}
