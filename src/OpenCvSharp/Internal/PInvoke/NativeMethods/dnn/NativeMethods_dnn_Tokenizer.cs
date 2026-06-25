using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // ReSharper disable InconsistentNaming

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_Tokenizer_load")]
    public static extern ExceptionStatus dnn_Tokenizer_load_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string modelConfig, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_Tokenizer_load")]
    public static extern ExceptionStatus dnn_Tokenizer_load_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string modelConfig, out IntPtr returnValue);

    public static ExceptionStatus dnn_Tokenizer_load(string modelConfig, out IntPtr returnValue)
        => IsWindows()
            ? dnn_Tokenizer_load_Windows(modelConfig, out returnValue)
            : dnn_Tokenizer_load_NotWindows(modelConfig, out returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Tokenizer_delete(IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_Tokenizer_encode(
        IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Tokenizer_decode(IntPtr obj, int[] tokens, int tokensLength, IntPtr returnValue);
}
