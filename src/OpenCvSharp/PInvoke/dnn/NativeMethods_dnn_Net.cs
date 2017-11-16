using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void dnn_Net_delete(IntPtr net);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dnn_Net_forward(IntPtr net, [MarshalAs(UnmanagedType.LPStr)] string outputName);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void dnn_Net_setInput(IntPtr net, IntPtr blob, [MarshalAs(UnmanagedType.LPStr)] string name);
    }
}
