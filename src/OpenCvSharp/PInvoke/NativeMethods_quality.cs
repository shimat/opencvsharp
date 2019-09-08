using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        #region QualityBase

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Scalar quality_QualityBase_compute(IntPtr obj, IntPtr img);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void quality_QualityBase_getQualityMap(IntPtr obj, IntPtr dst);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void quality_QualityBase_clear(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int quality_QualityBase_empty(IntPtr obj);

        #endregion

        #region QualityPSNR

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr quality_createQualityPSNR(IntPtr @ref, double maxPixelValue);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void quality_Ptr_QualityPSNR_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Scalar quality_QualityPSNR_staticCompute(IntPtr @ref, IntPtr cmp, IntPtr qualityMap, double maxPixelValue);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double quality_QualityPSNR_getMaxPixelValue(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void quality_QualityPSNR_setMaxPixelValue(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr quality_Ptr_QualityPSNR_get(IntPtr ptr);

        #endregion

        #region QualitySSIM

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr quality_createQualitySSIM(IntPtr @ref);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void quality_Ptr_QualitySSIM_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr quality_Ptr_QualitySSIM_get(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Scalar quality_QualitySSIM_staticCompute(IntPtr @ref, IntPtr cmp, IntPtr qualityMap);

        #endregion

        #region QualityGMSD

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr quality_createQualityGMSD(IntPtr @ref);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void quality_Ptr_QualityGMSD_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr quality_Ptr_QualityGMSD_get(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Scalar quality_QualityGMSD_staticCompute(IntPtr @ref, IntPtr cmp, IntPtr qualityMap);

        #endregion

        #region QualityMSE

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr quality_createQualityMSE(IntPtr @ref);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void quality_Ptr_QualityMSE_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr quality_Ptr_QualityMSE_get(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Scalar quality_QualityMSE_staticCompute(IntPtr @ref, IntPtr cmp, IntPtr qualityMap);

        #endregion

        #region QualityBRISQUE

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr quality_createQualityBRISQUE1(
            [MarshalAs(UnmanagedType.LPStr)] string modelFilePath,
            [MarshalAs(UnmanagedType.LPStr)] string rangeFilePath);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr quality_createQualityBRISQUE2(IntPtr model, IntPtr range);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void quality_Ptr_QualityBRISQUE_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr quality_Ptr_QualityBRISQUE_get(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Scalar quality_QualityBRISQUE_staticCompute(
            IntPtr @ref, 
            [MarshalAs(UnmanagedType.LPStr)] string modelFilePath, 
            [MarshalAs(UnmanagedType.LPStr)] string rangeFilePath);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void quality_QualityBRISQUE_computeFeatures(IntPtr img, IntPtr features);

        #endregion
    }
}