using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // RFFeatureGetter

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_createRFFeatureGetter();

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_Ptr_RFFeatureGetter_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_Ptr_RFFeatureGetter_get(IntPtr ptr);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_RFFeatureGetter_getFeatures(
            IntPtr obj, IntPtr src, IntPtr features,
            int gnrmRad, int gsmthRad, int shrink, int outNum, int gradNum);


        // StructuredEdgeDetection

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_createStructuredEdgeDetection(
            [MarshalAs(UnmanagedType.LPStr)] string model, IntPtr howToGetFeatures);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_Ptr_StructuredEdgeDetection_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_Ptr_StructuredEdgeDetection_get(
            IntPtr ptr);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_StructuredEdgeDetection_detectEdges(IntPtr obj,
            IntPtr src, IntPtr dst);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_StructuredEdgeDetection_computeOrientation(IntPtr obj,
            IntPtr src, IntPtr dst);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_StructuredEdgeDetection_edgesNms(IntPtr obj,
            IntPtr edge_image, IntPtr orientation_image, IntPtr dst,
            int r, int s, float m, int isParallel);
    }
}