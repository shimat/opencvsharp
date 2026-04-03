using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Affine shape transformer.
/// </summary>
public class AffineTransformer : ShapeTransformer
{
    #region Init & Disposal

    private AffineTransformer(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(
            NativeMethods.shape_Ptr_AffineTransformer_delete(p))) { }

    /// <summary>
    /// Creates an Affine shape transformer.
    /// </summary>
    /// <param name="fullAffine">
    /// If true, uses a full affine transformation (6 degrees of freedom).
    /// If false, uses a partial affine transformation (4 degrees of freedom). Default: false.
    /// </param>
    /// <returns>A new AffineTransformer instance.</returns>
    public static AffineTransformer Create(bool fullAffine = false)
    {
        NativeMethods.HandleException(
            NativeMethods.shape_createAffineTransformer(fullAffine ? 1 : 0, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.shape_Ptr_AffineTransformer_get(smartPtr, out var rawPtr));
        return new AffineTransformer(smartPtr, rawPtr);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Whether the full (6 DOF) affine transformation is used (true) or partial affine (4 DOF, false).
    /// </summary>
    public bool FullAffine
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_AffineTransformer_getFullAffine(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_AffineTransformer_setFullAffine(RawPtr, value ? 1 : 0));
            GC.KeepAlive(this);
        }
    }

    #endregion

    #region Internal

    internal override IntPtr CreateBaseSmartPtr()
    {
        NativeMethods.HandleException(
            NativeMethods.shape_Ptr_AffineTransformer_upcast(SmartPtr, out var basePtr));
        GC.KeepAlive(this);
        return basePtr;
    }

    #endregion
}