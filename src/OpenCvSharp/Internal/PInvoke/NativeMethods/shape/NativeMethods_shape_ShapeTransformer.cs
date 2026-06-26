using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // ShapeTransformer (base class methods)

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeTransformer_estimateTransformation(
        IntPtr obj, IntPtr transformingShape, IntPtr targetShape, IntPtr matches);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeTransformer_applyTransformation(
        IntPtr obj, IntPtr input, IntPtr output, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeTransformer_warpImage(
        IntPtr obj, IntPtr transformingImage, IntPtr output,
        int flags, int borderMode, Scalar borderValue);

    // ThinPlateSplineShapeTransformer

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_Ptr_ThinPlateSplineShapeTransformer_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_Ptr_ThinPlateSplineShapeTransformer_get(
        IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_createThinPlateSplineShapeTransformer(
        double regularizationParameter, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ThinPlateSplineShapeTransformer_setRegularizationParameter(
        IntPtr obj, double beta);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ThinPlateSplineShapeTransformer_getRegularizationParameter(
        IntPtr obj, out double returnValue);

    // AffineTransformer

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_Ptr_AffineTransformer_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_Ptr_AffineTransformer_get(
        IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_createAffineTransformer(
        int fullAffine, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_AffineTransformer_setFullAffine(IntPtr obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_AffineTransformer_getFullAffine(
        IntPtr obj, out int returnValue);

    // Upcast helpers: Ptr<Derived> → Ptr<ShapeTransformer>

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_Ptr_ThinPlateSplineShapeTransformer_upcast(
        IntPtr src, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_Ptr_AffineTransformer_upcast(
        IntPtr src, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_Ptr_ShapeTransformer_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_ShapeContextDistanceExtractor_setTransformAlgorithm(
        IntPtr obj, IntPtr transformer);
}