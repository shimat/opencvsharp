using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Thin Plate Spline shape transformer.
/// </summary>
public class ThinPlateSplineShapeTransformer : ShapeTransformer
{
    #region Init & Disposal

    private ThinPlateSplineShapeTransformer(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(
            NativeMethods.shape_Ptr_ThinPlateSplineShapeTransformer_delete(p))) { }

    /// <summary>
    /// Creates a Thin Plate Spline shape transformer.
    /// </summary>
    /// <param name="regularizationParameter">
    /// The regularization parameter for relaxing the exact interpolation requirements
    /// of the TPS algorithm. Default: 0 (exact interpolation).
    /// </param>
    /// <returns>A new ThinPlateSplineShapeTransformer instance.</returns>
    public static ThinPlateSplineShapeTransformer Create(double regularizationParameter = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.shape_createThinPlateSplineShapeTransformer(
                regularizationParameter, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.shape_Ptr_ThinPlateSplineShapeTransformer_get(smartPtr, out var rawPtr));
        return new ThinPlateSplineShapeTransformer(smartPtr, rawPtr);
    }

    #endregion

    #region Properties

    /// <summary>
    /// The regularization parameter for the TPS transformation.
    /// </summary>
    public double RegularizationParameter
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ThinPlateSplineShapeTransformer_getRegularizationParameter(
                    RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ThinPlateSplineShapeTransformer_setRegularizationParameter(
                    RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    #endregion

    #region Internal

    internal override IntPtr CreateBaseSmartPtr()
    {
        NativeMethods.HandleException(
            NativeMethods.shape_Ptr_ThinPlateSplineShapeTransformer_upcast(SmartPtr, out var basePtr));
        GC.KeepAlive(this);
        return basePtr;
    }

    #endregion
}