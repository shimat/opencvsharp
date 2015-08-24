using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // ShapeDistanceExtractor

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float shape_ShapeDistanceExtractor_computeDistance(
            IntPtr obj, IntPtr contour1, IntPtr contour2);

        // ShapeContextDistanceExtractor

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void shape_Ptr_ShapeContextDistanceExtractor_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr shape_Ptr_ShapeContextDistanceExtractor_get(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void shape_ShapeContextDistanceExtractor_setAngularBins(IntPtr obj, int val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int shape_ShapeContextDistanceExtractor_getAngularBins(IntPtr obj);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void shape_ShapeContextDistanceExtractor_setRadialBins(IntPtr obj, int val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int shape_ShapeContextDistanceExtractor_getRadialBins(IntPtr obj);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void shape_ShapeContextDistanceExtractor_setInnerRadius(IntPtr obj, float val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float shape_ShapeContextDistanceExtractor_getInnerRadius(IntPtr obj);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void shape_ShapeContextDistanceExtractor_setOuterRadius(IntPtr obj, float val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float shape_ShapeContextDistanceExtractor_getOuterRadius(IntPtr obj);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void shape_ShapeContextDistanceExtractor_setRotationInvariant(IntPtr obj, int val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int shape_ShapeContextDistanceExtractor_getRotationInvariant(IntPtr obj);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void shape_ShapeContextDistanceExtractor_setShapeContextWeight(IntPtr obj, float val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float shape_ShapeContextDistanceExtractor_getShapeContextWeight(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void shape_ShapeContextDistanceExtractor_setImageAppearanceWeight(IntPtr obj, float val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float shape_ShapeContextDistanceExtractor_getImageAppearanceWeight(IntPtr obj);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void shape_ShapeContextDistanceExtractor_setBendingEnergyWeight(IntPtr obj, float val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float shape_ShapeContextDistanceExtractor_getBendingEnergyWeight(IntPtr obj);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void shape_ShapeContextDistanceExtractor_setImages(IntPtr obj, IntPtr image1, IntPtr image2);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void shape_ShapeContextDistanceExtractor_getImages(IntPtr obj, IntPtr image1, IntPtr image2);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void shape_ShapeContextDistanceExtractor_setIterations(IntPtr obj, int val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int shape_ShapeContextDistanceExtractor_getIterations(IntPtr obj);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void shape_ShapeContextDistanceExtractor_setStdDev(IntPtr obj, float val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float shape_ShapeContextDistanceExtractor_getStdDev(IntPtr obj);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr shape_createShapeContextDistanceExtractor(
            int nAngularBins, int nRadialBins,
            float innerRadius, float outerRadius, int iterations /*,
	        const Ptr<HistogramCostExtractor> &comparer = createChiHistogramCostExtractor(),
	        const Ptr<ShapeTransformer> &transformer = createThinPlateSplineShapeTransformer()*/);


        // HausdorffDistanceExtractor
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void shape_Ptr_HausdorffDistanceExtractor_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr shape_Ptr_HausdorffDistanceExtractor_get(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void shape_HausdorffDistanceExtractor_setDistanceFlag(IntPtr obj, int val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int shape_HausdorffDistanceExtractor_getDistanceFlag(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void shape_HausdorffDistanceExtractor_setRankProportion(IntPtr obj, float val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float shape_HausdorffDistanceExtractor_getRankProportion(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr shape_createHausdorffDistanceExtractor(int distanceFlag, float rankProp);
    }
}