﻿using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    // TODO

    static partial class NativeMethods
    {
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
        public static extern IntPtr superres_createFrameSource_Video_CUDA(
            [MarshalAs(UnmanagedType.LPStr)] string fileName);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr superres_createFrameSource_Camera(int deviceId);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr superres_Ptr_FrameSource_get(IntPtr ptr);
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
        public static extern IntPtr superres_createSuperResolution_BTVL1_CUDA();
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern IntPtr superres_createSuperResolution_BTVL1_OCL();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr superres_Ptr_SuperResolution_get(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void superres_Ptr_SuperResolution_delete(IntPtr ptr);
        

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void superres_DenseOpticalFlowExt_calc(
            IntPtr obj, IntPtr frame0, IntPtr frame1, IntPtr flow1, IntPtr flow2);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void superres_DenseOpticalFlowExt_collectGarbage(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr superres_Ptr_DenseOpticalFlowExt_get(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void superres_Ptr_DenseOpticalFlowExt_delete(IntPtr ptr);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr superres_createOptFlow_Farneback();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr superres_createOptFlow_Farneback_CUDA();
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern IntPtr superres_createOptFlow_Farneback_OCL();
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern IntPtr superres_createOptFlow_Simple();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr superres_createOptFlow_DualTVL1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr superres_createOptFlow_DualTVL1_CUDA();
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern IntPtr superres_createOptFlow_DualTVL1_OCL();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr superres_createOptFlow_Brox_CUDA();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr superres_createOptFlow_PyrLK_CUDA();
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern IntPtr superres_createOptFlow_PyrLK_OCL();

    }
}