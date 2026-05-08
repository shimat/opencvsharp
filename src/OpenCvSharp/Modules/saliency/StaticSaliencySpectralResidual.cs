using OpenCvSharp.Internal;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp.Saliency;

/// <summary>
/// The Spectral Residual approach for static saliency detection.
/// </summary>
public class StaticSaliencySpectralResidual : Algorithm
{
    private StaticSaliencySpectralResidual(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(
            NativeMethods.saliency_Ptr_StaticSaliencySpectralResidual_delete(p)))
    { }

    /// <summary>
    /// Creates a StaticSaliencySpectralResidual instance.
    /// </summary>
    public static StaticSaliencySpectralResidual Create()
    {
        NativeMethods.HandleException(
            NativeMethods.saliency_StaticSaliencySpectralResidual_create(out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.saliency_Ptr_StaticSaliencySpectralResidual_get(smartPtr, out var rawPtr));
        return new StaticSaliencySpectralResidual(smartPtr, rawPtr);
    }

    /// <summary>
    /// Computes the saliency map.
    /// </summary>
    /// <param name="image">The input image.</param>
    /// <param name="saliencyMap">The computed saliency map (CV_32FC1).</param>
    /// <returns>true if the saliency map was computed successfully.</returns>
    public virtual bool ComputeSaliency(InputArray image, OutputArray saliencyMap)
    {
        ThrowIfDisposed();
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        if (saliencyMap is null)
            throw new ArgumentNullException(nameof(saliencyMap));
        image.ThrowIfDisposed();
        saliencyMap.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.saliency_StaticSaliencySpectralResidual_computeSaliency(
                RawPtr, image.CvPtr, saliencyMap.CvPtr, out var ret));
        GC.KeepAlive(this);
        GC.KeepAlive(image);
        saliencyMap.Fix();
        return ret != 0;
    }

    /// <summary>
    /// Computes a binary saliency map from the given saliency map using an adaptive threshold.
    /// </summary>
    /// <param name="saliencyMap">The input saliency map (CV_32FC1).</param>
    /// <param name="binaryMap">The computed binary map.</param>
    /// <returns>true if the binary map was computed successfully.</returns>
    public virtual bool ComputeBinaryMap(InputArray saliencyMap, OutputArray binaryMap)
    {
        ThrowIfDisposed();
        if (saliencyMap is null)
            throw new ArgumentNullException(nameof(saliencyMap));
        if (binaryMap is null)
            throw new ArgumentNullException(nameof(binaryMap));
        saliencyMap.ThrowIfDisposed();
        binaryMap.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.saliency_StaticSaliencySpectralResidual_computeBinaryMap(
                RawPtr, saliencyMap.CvPtr, binaryMap.CvPtr, out var ret));
        GC.KeepAlive(this);
        GC.KeepAlive(saliencyMap);
        binaryMap.Fix();
        return ret != 0;
    }

    /// <summary>
    /// Gets or sets the resize width used during internal computation.
    /// </summary>
    public int ImageWidth
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_StaticSaliencySpectralResidual_getImageWidth(RawPtr, out var val));
            GC.KeepAlive(this);
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_StaticSaliencySpectralResidual_setImageWidth(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets the resize height used during internal computation.
    /// </summary>
    public int ImageHeight
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_StaticSaliencySpectralResidual_getImageHeight(RawPtr, out var val));
            GC.KeepAlive(this);
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_StaticSaliencySpectralResidual_setImageHeight(RawPtr, value));
            GC.KeepAlive(this);
        }
    }
}
