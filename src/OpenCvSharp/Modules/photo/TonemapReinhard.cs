using OpenCvSharp.Internal;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp;

/// <summary>
/// This is a global tonemapping operator that models human visual system.
///
/// Mapping function is controlled by adaptation parameter, that is computed using light adaptation and 
/// color adaptation. For more information see @cite RD05.
/// </summary>
public sealed class TonemapReinhard : Tonemap
{
    private TonemapReinhard(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.photo_Ptr_TonemapReinhard_delete(p)))
    { }

    /// <summary>
    /// Creates TonemapReinhard object
    /// </summary>
    /// <param name="gamma">positive value for gamma correction. Gamma value of 1.0 implies no correction, gamma
    /// equal to 2.2f is suitable for most displays.
    /// Generally gamma &gt; 1 brightens the image and gamma &lt; 1 darkens it.</param>
    /// <param name="intensity">result intensity in [-8, 8] range. Greater intensity produces brighter results.</param>
    /// <param name="lightAdapt">light adaptation in [0, 1] range. If 1 adaptation is based only on pixel 
    /// value, if 0 it's global, otherwise it's a weighted mean of this two cases.</param>
    /// <param name="colorAdapt">chromatic adaptation in [0, 1] range. If 1 channels are treated independently,
    /// if 0 adaptation level is the same for each channel.</param>
    /// <returns></returns>
    public static TonemapReinhard Create(float gamma = 1.0f, float intensity = 0.0f, float lightAdapt = 1.0f, float colorAdapt = 0.0f)
    {
        NativeMethods.HandleException(
            NativeMethods.photo_createTonemapReinhard(gamma, intensity, lightAdapt, colorAdapt, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.photo_Ptr_TonemapReinhard_get(smartPtr, out var rawPtr));
        return new TonemapReinhard(smartPtr, rawPtr);
    }

    /// <summary>
    /// Gets or sets result intensity in [-8, 8] range. Greater intensity produces brighter results.
    /// </summary>
    public float Intensity
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.photo_TonemapReinhard_getIntensity(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.photo_TonemapReinhard_setIntensity(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets light adaptation in [0, 1] range. If 1 adaptation is based only on pixel 
    /// value, if 0 it's global, otherwise it's a weighted mean of this two cases.
    /// </summary>
    public float LightAdaptation
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.photo_TonemapReinhard_getLightAdaptation(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.photo_TonemapReinhard_setLightAdaptation(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets chromatic adaptation in [0, 1] range. If 1 channels are treated independently,
    /// if 0 adaptation level is the same for each channel.
    /// </summary>
    public float ColorAdaptation
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.photo_TonemapReinhard_getColorAdaptation(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.photo_TonemapReinhard_setColorAdaptation(CvPtr, value));
            GC.KeepAlive(this);
        }
    }
}
