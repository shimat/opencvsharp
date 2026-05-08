using OpenCvSharp.Internal;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp.Saliency;

/// <summary>
/// The Fine Grained Saliency approach for static saliency detection.
/// </summary>
public class StaticSaliencyFineGrained : Algorithm
{
    private StaticSaliencyFineGrained(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(
            NativeMethods.saliency_Ptr_StaticSaliencyFineGrained_delete(p)))
    { }

    /// <summary>
    /// Creates a StaticSaliencyFineGrained instance.
    /// </summary>
    public static StaticSaliencyFineGrained Create()
    {
        NativeMethods.HandleException(
            NativeMethods.saliency_StaticSaliencyFineGrained_create(out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.saliency_Ptr_StaticSaliencyFineGrained_get(smartPtr, out var rawPtr));
        return new StaticSaliencyFineGrained(smartPtr, rawPtr);
    }

    /// <summary>
    /// Computes the saliency map.
    /// </summary>
    /// <param name="image">The input image.</param>
    /// <param name="saliencyMap">The computed saliency map.</param>
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
            NativeMethods.saliency_StaticSaliencyFineGrained_computeSaliency(
                RawPtr, image.CvPtr, saliencyMap.CvPtr, out var ret));
        GC.KeepAlive(this);
        GC.KeepAlive(image);
        saliencyMap.Fix();
        return ret != 0;
    }

    /// <summary>
    /// Computes a binary saliency map from the given saliency map using an adaptive threshold.
    /// </summary>
    /// <param name="saliencyMap">The input saliency map.</param>
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
            NativeMethods.saliency_StaticSaliencyFineGrained_computeBinaryMap(
                RawPtr, saliencyMap.CvPtr, binaryMap.CvPtr, out var ret));
        GC.KeepAlive(this);
        GC.KeepAlive(saliencyMap);
        binaryMap.Fix();
        return ret != 0;
    }
}
