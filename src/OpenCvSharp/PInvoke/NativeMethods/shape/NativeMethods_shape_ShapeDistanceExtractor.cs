using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // ShapeDistanceExtractor

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float shape_ShapeDistanceExtractor_computeDistance(
            IntPtr obj, IntPtr contour1, IntPtr contour2);

        // ShapeContextDistanceExtractor

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shape_Ptr_ShapeContextDistanceExtractor_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr shape_Ptr_ShapeContextDistanceExtractor_get(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shape_ShapeContextDistanceExtractor_setAngularBins(IntPtr obj, int val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int shape_ShapeContextDistanceExtractor_getAngularBins(IntPtr obj);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shape_ShapeContextDistanceExtractor_setRadialBins(IntPtr obj, int val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int shape_ShapeContextDistanceExtractor_getRadialBins(IntPtr obj);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shape_ShapeContextDistanceExtractor_setInnerRadius(IntPtr obj, float val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float shape_ShapeContextDistanceExtractor_getInnerRadius(IntPtr obj);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shape_ShapeContextDistanceExtractor_setOuterRadius(IntPtr obj, float val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float shape_ShapeContextDistanceExtractor_getOuterRadius(IntPtr obj);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shape_ShapeContextDistanceExtractor_setRotationInvariant(IntPtr obj, int val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int shape_ShapeContextDistanceExtractor_getRotationInvariant(IntPtr obj);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shape_ShapeContextDistanceExtractor_setShapeContextWeight(IntPtr obj, float val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float shape_ShapeContextDistanceExtractor_getShapeContextWeight(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shape_ShapeContextDistanceExtractor_setImageAppearanceWeight(IntPtr obj, float val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float shape_ShapeContextDistanceExtractor_getImageAppearanceWeight(IntPtr obj);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shape_ShapeContextDistanceExtractor_setBendingEnergyWeight(IntPtr obj, float val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float shape_ShapeContextDistanceExtractor_getBendingEnergyWeight(IntPtr obj);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shape_ShapeContextDistanceExtractor_setImages(IntPtr obj, IntPtr image1, IntPtr image2);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shape_ShapeContextDistanceExtractor_getImages(IntPtr obj, IntPtr image1, IntPtr image2);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shape_ShapeContextDistanceExtractor_setIterations(IntPtr obj, int val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int shape_ShapeContextDistanceExtractor_getIterations(IntPtr obj);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shape_ShapeContextDistanceExtractor_setStdDev(IntPtr obj, float val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float shape_ShapeContextDistanceExtractor_getStdDev(IntPtr obj);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr shape_createShapeContextDistanceExtractor(
            int nAngularBins, int nRadialBins,
            float innerRadius, float outerRadius, int iterations /*,
            const Ptr<HistogramCostExtractor> &comparer = createChiHistogramCostExtractor(),
            const Ptr<ShapeTransformer> &transformer = createThinPlateSplineShapeTransformer()*/);


        // HausdorffDistanceExtractor
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shape_Ptr_HausdorffDistanceExtractor_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr shape_Ptr_HausdorffDistanceExtractor_get(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shape_HausdorffDistanceExtractor_setDistanceFlag(IntPtr obj, int val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int shape_HausdorffDistanceExtractor_getDistanceFlag(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shape_HausdorffDistanceExtractor_setRankProportion(IntPtr obj, float val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float shape_HausdorffDistanceExtractor_getRankProportion(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr shape_createHausdorffDistanceExtractor(int distanceFlag, float rankProp);
    }
}