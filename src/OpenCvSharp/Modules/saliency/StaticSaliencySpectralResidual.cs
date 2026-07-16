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

        NativeMethods.HandleException(
            NativeMethods.saliency_StaticSaliencySpectralResidual_computeSaliency(
                Handle, image.Proxy, saliencyMap.Proxy, out var ret));
        GC.KeepAlive(image.Source);
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

        NativeMethods.HandleException(
            NativeMethods.saliency_StaticSaliencySpectralResidual_computeBinaryMap(
                Handle, saliencyMap.Proxy, binaryMap.Proxy, out var ret));
        GC.KeepAlive(saliencyMap.Source);
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
                NativeMethods.saliency_StaticSaliencySpectralResidual_getImageWidth(Handle, out var val));
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_StaticSaliencySpectralResidual_setImageWidth(Handle, value));
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
                NativeMethods.saliency_StaticSaliencySpectralResidual_getImageHeight(Handle, out var val));
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_StaticSaliencySpectralResidual_setImageHeight(Handle, value));
        }
    }

    /// <summary>
    /// Stores algorithm parameters in a file storage.
    /// </summary>
    /// <remarks>
    /// Overrides the generic Algorithm.Write, which passes a cv::Algorithm* to the native side.
    /// cv::saliency::Saliency inherits Algorithm virtually, so a raw pointer obtained as
    /// StaticSaliencySpectralResidual* cannot be safely reinterpreted as Algorithm* on the managed
    /// side; this override calls write() with the pointer kept at its concrete native type instead.
    /// </remarks>
    /// <param name="fs"></param>
    public override void Write(FileStorage fs)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(fs);

        NativeMethods.HandleException(
            NativeMethods.saliency_StaticSaliencySpectralResidual_write(Handle, fs.CvPtr));
        GC.KeepAlive(fs);
    }

    /// <summary>
    /// Reads algorithm parameters from a file storage.
    /// </summary>
    /// <remarks>
    /// See the remarks on <see cref="Write"/> for why this override is needed.
    /// </remarks>
    /// <param name="fn"></param>
    public override void Read(FileNode fn)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(fn);

        NativeMethods.HandleException(
            NativeMethods.saliency_StaticSaliencySpectralResidual_read(Handle, fn.CvPtr));
        GC.KeepAlive(fn);
    }
}
