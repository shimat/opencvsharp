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
    public virtual bool ComputeSaliency(InputArrayRef image, OutputArrayRef saliencyMap)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.saliency_StaticSaliencyFineGrained_computeSaliency(
                Handle, image.Proxy, saliencyMap.Proxy, out var ret));
        GC.KeepAlive(image.Source);
        return ret != 0;
    }

    /// <summary>
    /// Computes a binary saliency map from the given saliency map using an adaptive threshold.
    /// </summary>
    /// <param name="saliencyMap">The input saliency map.</param>
    /// <param name="binaryMap">The computed binary map.</param>
    /// <returns>true if the binary map was computed successfully.</returns>
    public virtual bool ComputeBinaryMap(InputArrayRef saliencyMap, OutputArrayRef binaryMap)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.saliency_StaticSaliencyFineGrained_computeBinaryMap(
                Handle, saliencyMap.Proxy, binaryMap.Proxy, out var ret));
        GC.KeepAlive(saliencyMap.Source);
        return ret != 0;
    }
}
