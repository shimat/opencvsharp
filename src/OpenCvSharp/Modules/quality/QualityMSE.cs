using OpenCvSharp.Internal;

namespace OpenCvSharp.Quality;

/// <summary>
/// Full reference mean square error algorithm  https://en.wikipedia.org/wiki/Mean_squared_error
/// </summary>
// ReSharper disable once InconsistentNaming
public class QualityMSE : QualityBase
{
    /// <summary>
    /// Creates instance by raw pointer
    /// </summary>
    private QualityMSE(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.quality_Ptr_QualityMSE_delete(p)))
    { }
    /// <summary>
    /// Create an object which calculates quality
    /// </summary>
    /// <param name="ref">input image to use as the source for comparison</param>
    /// <returns></returns>
    public static QualityMSE Create(InputArray @ref)
    {
        if (@ref is null)
            throw new ArgumentNullException(nameof(@ref));
        @ref.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.quality_createQualityMSE(@ref.CvPtr, out var smartPtr));

        GC.KeepAlive(@ref);
        NativeMethods.HandleException(NativeMethods.quality_Ptr_QualityMSE_get(smartPtr, out var rawPtr));
        return new QualityMSE(smartPtr, rawPtr);
    }

    // TODO support InputArrayOfArrays
    // CV_WRAP cv::Scalar compute( InputArrayOfArrays cmpImgs ) CV_OVERRIDE;

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
            NativeMethods.quality_QualityMSE_staticCompute(
                @ref.CvPtr, cmp.CvPtr, qualityMap?.CvPtr ?? IntPtr.Zero, out var ret));

        GC.KeepAlive(@ref);
        GC.KeepAlive(cmp);
        qualityMap?.Fix();
        return ret;
    }
}
