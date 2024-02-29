using OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo

namespace OpenCvSharp.Quality;

/// <summary>
/// Full reference GMSD algorithm
/// </summary>
public class QualityGMSD : QualityBase
{
    private Ptr? ptrObj;

    /// <summary>
    /// Creates instance by raw pointer
    /// </summary>
    protected QualityGMSD(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Create an object which calculates quality
    /// </summary>
    /// <param name="ref">input image to use as the source for comparison</param>
    /// <returns></returns>
    public static QualityGMSD Create(InputArray @ref)
    {
        if (@ref is null)
            throw new ArgumentNullException(nameof(@ref));
        @ref.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.quality_createQualityGMSD(@ref.CvPtr, out var ptr));
        GC.KeepAlive(@ref);
        return new QualityGMSD(ptr);
    }

    /// <summary>
    /// static method for computing quality
    /// </summary>
    /// <param name="ref"></param>
    /// <param name="cmp"></param>
    /// <param name="qualityMap">output quality map, or null</param>
    /// <returns>cv::Scalar with per-channel quality values.  Values range from 0 (worst) to 1 (best)</returns>
    public static Scalar Compute(InputArray @ref, InputArray cmp, OutputArray? qualityMap)
    {
        if (@ref is null)
            throw new ArgumentNullException(nameof(@ref));
        if (cmp is null)
            throw new ArgumentNullException(nameof(cmp));
        @ref.ThrowIfDisposed();
        cmp.ThrowIfDisposed();
        qualityMap?.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.quality_QualityGMSD_staticCompute(
                @ref.CvPtr, cmp.CvPtr, qualityMap?.CvPtr ?? IntPtr.Zero, out var ret));

        GC.KeepAlive(@ref);
        GC.KeepAlive(cmp);
        qualityMap?.Fix();
        return ret;
    }

    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        ptrObj?.Dispose();
        ptrObj = null;
        base.DisposeManaged();
    }

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.quality_Ptr_QualityGMSD_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException( 
                NativeMethods.quality_Ptr_QualityGMSD_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
