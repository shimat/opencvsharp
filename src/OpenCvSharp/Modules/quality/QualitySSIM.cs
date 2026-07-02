using OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace OpenCvSharp.Quality;

/// <summary>
/// Full reference structural similarity algorithm  https://en.wikipedia.org/wiki/Structural_similarity
/// </summary>
public class QualitySSIM : QualityBase
{
    /// <summary>
    /// Creates instance by raw pointer
    /// </summary>
    private QualitySSIM(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.quality_Ptr_QualitySSIM_delete(p)))
    { }
    /// <summary>
    /// Create an object which calculates quality
    /// </summary>
    /// <param name="ref">input image to use as the source for comparison</param>
    /// <returns></returns>
    public static QualitySSIM Create(InputArrayRef @ref)
    {
        NativeMethods.HandleException(
            NativeMethods.quality_createQualitySSIM(@ref.Proxy, out var smartPtr));
        GC.KeepAlive(@ref.Source);
        NativeMethods.HandleException(NativeMethods.quality_Ptr_QualitySSIM_get(smartPtr, out var rawPtr));
        return new QualitySSIM(smartPtr, rawPtr);
    }

    /// <summary>
    /// static method for computing quality
    /// </summary>
    /// <param name="ref"></param>
    /// <param name="cmp"></param>
    /// <param name="qualityMap">output quality map, or default to skip it</param>
    /// <returns>cv::Scalar with per-channel quality values.  Values range from 0 (worst) to 1 (best)</returns>
    public static Scalar Compute(InputArrayRef @ref, InputArrayRef cmp, OutputArrayRef qualityMap = default)
    {
        NativeMethods.HandleException(
            NativeMethods.quality_QualitySSIM_staticCompute(
                @ref.Proxy, cmp.Proxy, qualityMap.Proxy, out var ret));

        GC.KeepAlive(@ref.Source);
        GC.KeepAlive(cmp.Source);
        GC.KeepAlive(qualityMap.Source);
        return ret;
    }
}
