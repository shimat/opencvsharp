﻿using System;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Tracking;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible

// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool tracking_Tracker_init(IntPtr obj, IntPtr image, Rect2d boundingBox);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool tracking_Tracker_update(IntPtr obj, IntPtr image, ref Rect2d boundingBox);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void tracking_Ptr_Tracker_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_Ptr_Tracker_get(IntPtr ptr);


        // TrackerKCF

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_TrackerKCF_create1();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_TrackerKCF_create2(TrackerKCF.Params parameters);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void tracking_Ptr_TrackerKCF_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_Ptr_TrackerKCF_get(IntPtr ptr);


        // TrackerMIL

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_TrackerMIL_create1();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe IntPtr tracking_TrackerMIL_create2(TrackerMIL.Params* parameters);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void tracking_Ptr_TrackerMIL_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_Ptr_TrackerMIL_get(IntPtr ptr);


        // TrackerBoosting

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_TrackerBoosting_create1();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe IntPtr tracking_TrackerBoosting_create2(TrackerBoosting.Params* parameters);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void tracking_Ptr_TrackerBoosting_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_Ptr_TrackerBoosting_get(IntPtr ptr);


        // TrackerBoosting

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_TrackerMedianFlow_create1();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe IntPtr tracking_TrackerMedianFlow_create2(TrackerMedianFlow.Params* parameters);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void tracking_Ptr_TrackerMedianFlow_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_Ptr_TrackerMedianFlow_get(IntPtr ptr);


        // TrackerTLD

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_TrackerTLD_create1();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe IntPtr tracking_TrackerTLD_create2(TrackerTLD.Params* parameters);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void tracking_Ptr_TrackerTLD_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_Ptr_TrackerTLD_get(IntPtr ptr);


        // TrackerGOTURN

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_TrackerGOTURN_create1();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe IntPtr tracking_TrackerGOTURN_create2(TrackerGOTURN.Params* parameters);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void tracking_Ptr_TrackerGOTURN_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_Ptr_TrackerGOTURN_get(IntPtr ptr);

        // TrackerMOSSE

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_TrackerMOSSE_create();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void tracking_Ptr_TrackerMOSSE_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_Ptr_TrackerMOSSE_get(IntPtr ptr);

        // TrackerCSRT

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_TrackerCSRT_create1();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_TrackerCSRT_create2(ref TrackerCSRT.Params parameters);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void tracking_Ptr_TrackerCSRT_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_Ptr_TrackerCSRT_get(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void tracking_TrackerCSRT_setInitialMask(IntPtr tracker, IntPtr mask);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void tracking_TrackerCSRT_Params_write(ref TrackerCSRT.Params @params, IntPtr fs);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern void tracking_TrackerCSRT_Params_read(ref TrackerCSRT.Params @params, StringBuilder windowFunctionBuf, IntPtr fn);
    }
}