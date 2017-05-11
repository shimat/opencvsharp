using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_Tracker_create(string trackerType);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern bool tracking_Tracker_init(IntPtr obj, IntPtr image, Rectd boundingBox);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern bool tracking_Tracker_update(IntPtr obj, IntPtr image, ref Rectd boundingBox);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void tracking_Ptr_Tracker_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_Ptr_Tracker_get(IntPtr ptr);
    }
}