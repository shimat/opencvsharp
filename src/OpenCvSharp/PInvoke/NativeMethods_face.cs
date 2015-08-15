
using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void face_FaceRecognizer_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void face_FaceRecognizer_train(
        IntPtr obj, IntPtr[] src, int srcLength, int[] labels, int labelsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void face_FaceRecognizer_update(
        IntPtr obj, IntPtr[] src, int srcLength, int[] labels, int labelsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int face_FaceRecognizer_predict1(IntPtr obj, IntPtr src);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void face_FaceRecognizer_predict2(
        IntPtr obj, IntPtr src, out int label, out double confidence);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void face_FaceRecognizer_save1(IntPtr obj, string filename);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void face_FaceRecognizer_load1(IntPtr obj, string filename);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void face_FaceRecognizer_save2(IntPtr obj, IntPtr fs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void face_FaceRecognizer_load2(IntPtr obj, IntPtr fs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr face_FaceRecognizer_info(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr face_createEigenFaceRecognizer(
        int numComponents, double threshold);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr face_createFisherFaceRecognizer(
        int numComponents, double threshold);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr face_createLBPHFaceRecognizer(
        int radius, int neighbors, int gridX, int gridY, double threshold);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr face_Ptr_FaceRecognizer_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void face_Ptr_FaceRecognizer_delete(IntPtr obj);
    }
}