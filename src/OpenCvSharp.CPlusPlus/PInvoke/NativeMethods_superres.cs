/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
    internal static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int superres_initModule_superres();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void superres_FrameSource_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void superres_FrameSource_nextFrame(IntPtr obj, IntPtr frame);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void superres_FrameSource_reset(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr superres_createFrameSource_Empty();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr superres_createFrameSource_Video(
            [MarshalAs(UnmanagedType.LPStr)] string fileName);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr superres_createFrameSource_Video_GPU(
            [MarshalAs(UnmanagedType.LPStr)] string fileName);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr superres_createFrameSource_Camera(int deviceId);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr superres_Ptr_FrameSource_obj(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void superres_Ptr_FrameSource_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void superres_SuperResolution_setInput(IntPtr obj, IntPtr frameSource);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void superres_SuperResolution_nextFrame(IntPtr obj, IntPtr frame);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void superres_SuperResolution_reset(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void superres_SuperResolution_collectGarbage(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr superres_createSuperResolution_BTVL1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr superres_createSuperResolution_BTVL1_GPU();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr superres_createSuperResolution_BTVL1_OCL();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr superres_Ptr_SuperResolution_obj(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void superres_Ptr_SuperResolution_delete(IntPtr ptr);

    }
}