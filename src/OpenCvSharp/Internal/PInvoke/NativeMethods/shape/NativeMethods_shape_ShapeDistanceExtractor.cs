using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // ShapeDistanceExtractor

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeDistanceExtractor_computeDistance(
        IntPtr obj, IntPtr contour1, IntPtr contour2, out float returnValue);

    // ShapeContextDistanceExtractor

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_Ptr_ShapeContextDistanceExtractor_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_Ptr_ShapeContextDistanceExtractor_get(IntPtr obj, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_setAngularBins(IntPtr obj, int val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_getAngularBins(IntPtr obj, out int returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_setRadialBins(IntPtr obj, int val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_getRadialBins(IntPtr obj, out int returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_setInnerRadius(IntPtr obj, float val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_getInnerRadius(IntPtr obj, out float returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_setOuterRadius(IntPtr obj, float val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_getOuterRadius(IntPtr obj, out float returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_setRotationInvariant(IntPtr obj, int val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_getRotationInvariant(IntPtr obj, out int returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_setShapeContextWeight(IntPtr obj, float val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_getShapeContextWeight(IntPtr obj, out float returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_setImageAppearanceWeight(IntPtr obj, float val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_getImageAppearanceWeight(IntPtr obj, out float returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_setBendingEnergyWeight(IntPtr obj, float val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_getBendingEnergyWeight(IntPtr obj, out float returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_setImages(IntPtr obj, IntPtr image1, IntPtr image2);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_getImages(IntPtr obj, IntPtr image1, IntPtr image2);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_setIterations(IntPtr obj, int val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_getIterations(IntPtr obj, out int returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_setStdDev(IntPtr obj, float val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_ShapeContextDistanceExtractor_getStdDev(IntPtr obj, out float returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_createShapeContextDistanceExtractor(
        int nAngularBins, int nRadialBins,
        float innerRadius, float outerRadius, int iterations /*,
            const Ptr<HistogramCostExtractor> &comparer = createChiHistogramCostExtractor(),
            const Ptr<ShapeTransformer> &transformer = createThinPlateSplineShapeTransformer()*/, out IntPtr returnValue);


    // HausdorffDistanceExtractor
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_Ptr_HausdorffDistanceExtractor_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_Ptr_HausdorffDistanceExtractor_get(IntPtr obj, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_HausdorffDistanceExtractor_setDistanceFlag(IntPtr obj, int val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_HausdorffDistanceExtractor_getDistanceFlag(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_HausdorffDistanceExtractor_setRankProportion(IntPtr obj, float val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_HausdorffDistanceExtractor_getRankProportion(IntPtr obj, out float returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_createHausdorffDistanceExtractor(int distanceFlag, float rankProp, out IntPtr returnValue);
}
