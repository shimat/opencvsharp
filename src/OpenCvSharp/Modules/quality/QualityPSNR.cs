using OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Quality;

/// <summary>
/// Full reference peak signal to noise ratio (PSNR) algorithm  https://en.wikipedia.org/wiki/Peak_signal-to-noise_ratio
/// </summary>
public class QualityPSNR : QualityBase
{
    private const double MaxPixelValueDefault = 255;

    /// <summary>
    /// Creates instance by raw pointer
    /// </summary>
    private QualityPSNR(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.quality_Ptr_QualityPSNR_delete(p)))
    { }
    /// <summary>
    /// get or set the maximum pixel value used for PSNR computation
    /// </summary>
    /// <returns></returns>
    public double MaxPixelValue
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.quality_QualityPSNR_getMaxPixelValue(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.quality_QualityPSNR_setMaxPixelValue(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Create an object which calculates quality
    /// </summary>
    /// <param name="ref">input image to use as the source for comparison</param>
    /// <param name="maxPixelValue">maximum per-channel value for any individual pixel; eg 255 for uint8 image</param>
    /// <returns></returns>
    public static QualityPSNR Create(InputArray @ref, double maxPixelValue = MaxPixelValueDefault)
    {
        if (@ref is null)
            throw new ArgumentNullException(nameof(@ref));
        @ref.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.quality_createQualityPSNR(@ref.CvPtr, maxPixelValue, out var smartPtr));
        GC.KeepAlive(@ref);
        NativeMethods.HandleException(NativeMethods.quality_Ptr_QualityPSNR_get(smartPtr, out var rawPtr));
        return new QualityPSNR(smartPtr, rawPtr);
    }
        
    /// <summary>
    /// static method for computing quality
    /// </summary>
    /// <param name="ref"></param>
    /// <param name="cmp"></param>
    /// <param name="qualityMap">output quality map, or null</param>
    /// <param name="maxPixelValue">maximum per-channel value for any individual pixel; eg 255 for uint8 image</param>
    /// <returns>PSNR value, or double.PositiveInfinity if the MSE between the two images == 0</returns>
    public static Scalar Compute(InputArray @ref, InputArray cmp, OutputArray? qualityMap, double maxPixelValue = MaxPixelValueDefault)
    {
        if (@ref is null)
            throw new ArgumentNullException(nameof(@ref));
        if (cmp is null)
            throw new ArgumentNullException(nameof(cmp));
        @ref.ThrowIfDisposed();
        cmp.ThrowIfDisposed();
        qualityMap?.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.quality_QualityPSNR_staticCompute(
                @ref.CvPtr, cmp.CvPtr, qualityMap?.CvPtr ?? IntPtr.Zero, maxPixelValue, out var ret));

        GC.KeepAlive(@ref);
        GC.KeepAlive(cmp);
        qualityMap?.Fix();
        return ret;
    }
}
