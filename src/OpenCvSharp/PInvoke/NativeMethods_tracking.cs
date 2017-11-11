using System;
using System.Runtime.InteropServices;
using OpenCvSharp.Tracking;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        /*
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_Tracker_create(string trackerType);
        */

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
        public static extern unsafe IntPtr tracking_TrackerKCF_create2(TrackerKCF.Params* parameters);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void tracking_Ptr_TrackerKCF_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_Ptr_TrackerKCF_get(IntPtr ptr);
    }
}