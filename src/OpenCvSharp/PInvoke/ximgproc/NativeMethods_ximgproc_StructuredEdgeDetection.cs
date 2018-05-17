using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // RFFeatureGetter

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_createRFFeatureGetter();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_Ptr_RFFeatureGetter_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_Ptr_RFFeatureGetter_get(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_RFFeatureGetter_getFeatures(
            IntPtr obj, IntPtr src, IntPtr features,
            int gnrmRad, int gsmthRad, int shrink, int outNum, int gradNum);


        // StructuredEdgeDetection

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_createStructuredEdgeDetection(
            [MarshalAs(UnmanagedType.LPStr)] string model, IntPtr howToGetFeatures);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_Ptr_StructuredEdgeDetection_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_Ptr_StructuredEdgeDetection_get(
            IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_StructuredEdgeDetection_detectEdges(IntPtr obj,
            IntPtr src, IntPtr dst);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_StructuredEdgeDetection_computeOrientation(IntPtr obj,
            IntPtr src, IntPtr dst);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_StructuredEdgeDetection_edgesNms(IntPtr obj,
            IntPtr edge_image, IntPtr orientation_image, IntPtr dst,
            int r, int s, float m, int isParallel);
    }
}