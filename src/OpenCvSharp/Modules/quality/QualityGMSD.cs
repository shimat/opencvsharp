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
    /// <summary>
    /// Creates instance by raw pointer
    /// </summary>
    private QualityGMSD(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.quality_Ptr_QualityGMSD_delete(p)))
    { }
    /// <summary>
    /// Create an object which calculates quality
    /// </summary>
    /// <param name="ref">input image to use as the source for comparison</param>
    /// <returns></returns>
    public static QualityGMSD Create(InputArray @ref)
    {
        NativeMethods.HandleException(
            NativeMethods.quality_createQualityGMSD(@ref.Proxy, out var smartPtr));
        GC.KeepAlive(@ref.Source);
        NativeMethods.HandleException(NativeMethods.quality_Ptr_QualityGMSD_get(smartPtr, out var rawPtr));
        return new QualityGMSD(smartPtr, rawPtr);
    }

    /// <summary>
    /// static method for computing quality
    /// </summary>
    /// <param name="ref"></param>
    /// <param name="cmp"></param>
    /// <param name="qualityMap">output quality map, or default to skip it</param>
    /// <returns>cv::Scalar with per-channel quality values.  Values range from 0 (worst) to 1 (best)</returns>
    public static Scalar Compute(InputArray @ref, InputArray cmp, OutputArray qualityMap = default)
    {
        NativeMethods.HandleException(
            NativeMethods.quality_QualityGMSD_staticCompute(
                @ref.Proxy, cmp.Proxy, qualityMap.Proxy, out var ret));

        GC.KeepAlive(@ref.Source);
        GC.KeepAlive(cmp.Source);
        GC.KeepAlive(qualityMap.Source);
        return ret;
    }
}
