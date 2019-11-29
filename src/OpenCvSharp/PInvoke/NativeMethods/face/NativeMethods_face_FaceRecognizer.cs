
using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    static partial class NativeMethods
    {
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void face_FaceRecognizer_delete(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void face_FaceRecognizer_train(
            IntPtr obj, IntPtr[] src, int srcLength, int[] labels, int labelsLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void face_FaceRecognizer_update(
            IntPtr obj, IntPtr[] src, int srcLength, int[] labels, int labelsLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int face_FaceRecognizer_predict1(IntPtr obj, IntPtr src);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void face_FaceRecognizer_predict2(
            IntPtr obj, IntPtr src, out int label, out double confidence);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void face_FaceRecognizer_write1(IntPtr obj, string filename);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void face_FaceRecognizer_read1(IntPtr obj, string filename);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void face_FaceRecognizer_write2(IntPtr obj, IntPtr fs);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void face_FaceRecognizer_read2(IntPtr obj, IntPtr fs);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void face_FaceRecognizer_setLabelInfo(IntPtr obj, int label,
            [MarshalAs(UnmanagedType.LPStr)] string strInfo);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void face_FaceRecognizer_getLabelInfo(IntPtr obj, int label, IntPtr dst);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void face_FaceRecognizer_getLabelsByString(IntPtr obj,
            [MarshalAs(UnmanagedType.LPStr)] string str, IntPtr dst);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double face_FaceRecognizer_getThreshold(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void face_FaceRecognizer_setThreshold(IntPtr obj, double val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr face_Ptr_FaceRecognizer_get(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void face_Ptr_FaceRecognizer_delete(IntPtr obj);
    }
}