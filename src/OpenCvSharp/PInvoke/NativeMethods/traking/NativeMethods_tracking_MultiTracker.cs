using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_MultiTracker_create();

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void tracking_Ptr_MultiTracker_delete(IntPtr ptr);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr tracking_Ptr_MultiTracker_get(IntPtr ptr);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int tracking_MultiTracker_add1(IntPtr obj, IntPtr newTracker, IntPtr image,
            Rect2d boundingBox);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int tracking_MultiTracker_add2(IntPtr obj, IntPtr[] newTrackers, int newTrackersLength,
            IntPtr image, Rect2d[] boundingBox, int boundingBoxLength);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int tracking_MultiTracker_update1(IntPtr obj, IntPtr image);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int tracking_MultiTracker_update2(IntPtr obj, IntPtr image, IntPtr boundingBox);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void tracking_MultiTracker_getObjects(IntPtr obj, IntPtr boundingBox);
    }
}