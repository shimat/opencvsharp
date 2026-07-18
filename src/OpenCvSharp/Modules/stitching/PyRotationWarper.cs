using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Rotation-based image warper, usable standalone (without a full <see cref="Stitcher"/> pipeline).
/// </summary>
public class PyRotationWarper : CvObject
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="type">Warper type: "plane", "affine", "cylindrical", "spherical", "fisheye",
    /// "stereographic", "compressedPlaneA2B1", "compressedPlaneA1.5B1", "compressedPlanePortraitA2B1",
    /// "compressedPlanePortraitA1.5B1", "paniniA2B1", "paniniA1.5B1", "paniniPortraitA2B1",
    /// "paniniPortraitA1.5B1", "mercator", "transverseMercator"</param>
    /// <param name="scale">Warper scale</param>
    public PyRotationWarper(string type, float scale) : base(Create(type, scale))
    {
        InitSafeHandle(CvPtr);
    }

    private static IntPtr Create(string type, float scale)
    {
        ArgumentNullException.ThrowIfNull(type);
        NativeMethods.HandleException(NativeMethods.stitching_PyRotationWarper_new(type, scale, out var ptr));
        return ptr;
    }

    private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            static h => NativeMethods.HandleException(NativeMethods.stitching_PyRotationWarper_delete(h))));
    }

    /// <summary>
    /// Projects the image point.
    /// </summary>
    public Point2f WarpPoint(Point2f pt, InputArray k, InputArray r)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.stitching_PyRotationWarper_warpPoint(Handle, pt, k.Proxy, r.Proxy, out var ret));
        GC.KeepAlive(k.Source);
        GC.KeepAlive(r.Source);
        return ret;
    }

    /// <summary>
    /// Projects the image point backward.
    /// </summary>
    public Point2f WarpPointBackward(Point2f pt, InputArray k, InputArray r)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.stitching_PyRotationWarper_warpPointBackward(Handle, pt, k.Proxy, r.Proxy, out var ret));
        GC.KeepAlive(k.Source);
        GC.KeepAlive(r.Source);
        return ret;
    }

    /// <summary>
    /// Builds the projection maps according to the given camera data.
    /// </summary>
    /// <returns>Projected image minimum bounding box</returns>
    public Rect BuildMaps(Size srcSize, InputArray k, InputArray r, OutputArray xmap, OutputArray ymap)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.stitching_PyRotationWarper_buildMaps(Handle, srcSize, k.Proxy, r.Proxy, xmap.Proxy, ymap.Proxy, out var ret));
        GC.KeepAlive(k.Source);
        GC.KeepAlive(r.Source);
        GC.KeepAlive(xmap.Source);
        GC.KeepAlive(ymap.Source);
        return ret;
    }

    /// <summary>
    /// Projects the image.
    /// </summary>
    /// <returns>Projected image top-left corner</returns>
    public Point Warp(InputArray src, InputArray k, InputArray r, InterpolationFlags interpMode, BorderTypes borderMode, OutputArray dst)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.stitching_PyRotationWarper_warp(
                Handle, src.Proxy, k.Proxy, r.Proxy, (int)interpMode, (int)borderMode, dst.Proxy, out var ret));
        GC.KeepAlive(src.Source);
        GC.KeepAlive(k.Source);
        GC.KeepAlive(r.Source);
        GC.KeepAlive(dst.Source);
        return ret;
    }

    /// <summary>
    /// Projects the image backward.
    /// </summary>
    public void WarpBackward(
        InputArray src, InputArray k, InputArray r, InterpolationFlags interpMode, BorderTypes borderMode, Size dstSize, OutputArray dst)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.stitching_PyRotationWarper_warpBackward(
                Handle, src.Proxy, k.Proxy, r.Proxy, (int)interpMode, (int)borderMode, dstSize, dst.Proxy));
        GC.KeepAlive(src.Source);
        GC.KeepAlive(k.Source);
        GC.KeepAlive(r.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Computes the projected image minimum bounding box.
    /// </summary>
    public Rect WarpRoi(Size srcSize, InputArray k, InputArray r)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.stitching_PyRotationWarper_warpRoi(Handle, srcSize, k.Proxy, r.Proxy, out var ret));
        GC.KeepAlive(k.Source);
        GC.KeepAlive(r.Source);
        return ret;
    }

    /// <summary>
    /// Warper scale.
    /// </summary>
    public float Scale
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_PyRotationWarper_getScale(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_PyRotationWarper_setScale(Handle, value));
        }
    }
}
