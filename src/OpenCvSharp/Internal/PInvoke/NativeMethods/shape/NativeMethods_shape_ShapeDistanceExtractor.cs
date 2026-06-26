using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // ShapeDistanceExtractor

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeDistanceExtractor_computeDistance(
        OpenCvSafeHandle obj, IntPtr contour1, IntPtr contour2, out float returnValue);

    // ShapeContextDistanceExtractor

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_Ptr_ShapeContextDistanceExtractor_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_Ptr_ShapeContextDistanceExtractor_get(IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_setAngularBins(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_getAngularBins(OpenCvSafeHandle obj, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_setRadialBins(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_getRadialBins(OpenCvSafeHandle obj, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_setInnerRadius(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_getInnerRadius(OpenCvSafeHandle obj, out float returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_setOuterRadius(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_getOuterRadius(OpenCvSafeHandle obj, out float returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_setRotationInvariant(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_getRotationInvariant(OpenCvSafeHandle obj, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_setShapeContextWeight(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_getShapeContextWeight(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_setImageAppearanceWeight(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_getImageAppearanceWeight(OpenCvSafeHandle obj, out float returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_setBendingEnergyWeight(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_getBendingEnergyWeight(OpenCvSafeHandle obj, out float returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_setImages(OpenCvSafeHandle obj, IntPtr image1, IntPtr image2);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_getImages(OpenCvSafeHandle obj, IntPtr image1, IntPtr image2);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_setIterations(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_getIterations(OpenCvSafeHandle obj, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_setStdDev(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_getStdDev(OpenCvSafeHandle obj, out float returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_createShapeContextDistanceExtractor(
        int nAngularBins, int nRadialBins,
        float innerRadius, float outerRadius, int iterations /*,
            const Ptr<HistogramCostExtractor> &comparer = createChiHistogramCostExtractor(),
            const Ptr<ShapeTransformer> &transformer = createThinPlateSplineShapeTransformer()*/, out IntPtr returnValue);


    // HausdorffDistanceExtractor
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_Ptr_HausdorffDistanceExtractor_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_Ptr_HausdorffDistanceExtractor_get(IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_HausdorffDistanceExtractor_setDistanceFlag(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_HausdorffDistanceExtractor_getDistanceFlag(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_HausdorffDistanceExtractor_setRankProportion(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_HausdorffDistanceExtractor_getRankProportion(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_createHausdorffDistanceExtractor(int distanceFlag, float rankProp, out IntPtr returnValue);

    // ShapeContextDistanceExtractor — sub-algorithm setters

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_setCostExtractor(
        OpenCvSafeHandle obj, IntPtr comparer);
}
