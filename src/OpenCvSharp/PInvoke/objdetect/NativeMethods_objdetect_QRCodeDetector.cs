using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591
// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern IntPtr objdetect_QRCodeDetector_new();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern void objdetect_QRCodeDetector_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern void objdetect_QRCodeDetector_setEpsX(IntPtr obj, double epsX);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern void objdetect_QRCodeDetector_setEpsY(IntPtr obj, double epsY);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern int objdetect_QRCodeDetector_detect(IntPtr obj, IntPtr img, IntPtr points);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern void objdetect_QRCodeDetector_decode(
            IntPtr obj, IntPtr img, IntPtr points, IntPtr straight_qrcode, IntPtr result);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern void objdetect_QRCodeDetector_detectAndDecode(
            IntPtr obj, IntPtr img, IntPtr points,
            IntPtr straight_qrcode, IntPtr result);
    }
}