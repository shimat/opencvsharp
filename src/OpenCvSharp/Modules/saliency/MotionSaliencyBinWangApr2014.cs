using OpenCvSharp.Internal;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp.Saliency;

/// <summary>
/// A Fast Self-tuning Background Subtraction Algorithm for motion saliency detection.
/// </summary>
public class MotionSaliencyBinWangApr2014 : Algorithm
{
    private MotionSaliencyBinWangApr2014(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(
            NativeMethods.saliency_Ptr_MotionSaliencyBinWangApr2014_delete(p)))
    { }

    /// <summary>
    /// Creates a MotionSaliencyBinWangApr2014 instance.
    /// </summary>
    public static MotionSaliencyBinWangApr2014 Create()
    {
        NativeMethods.HandleException(
            NativeMethods.saliency_MotionSaliencyBinWangApr2014_create(out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.saliency_Ptr_MotionSaliencyBinWangApr2014_get(smartPtr, out var rawPtr));
        return new MotionSaliencyBinWangApr2014(smartPtr, rawPtr);
    }

    /// <summary>
    /// Computes the motion saliency map for the given frame.
    /// </summary>
    /// <param name="image">Input image frame (grayscale, CV_8UC1).</param>
    /// <param name="saliencyMap">The computed binary saliency map.</param>
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
            NativeMethods.saliency_MotionSaliencyBinWangApr2014_computeSaliency(
                RawPtr, image.CvPtr, saliencyMap.CvPtr, out var ret));
        GC.KeepAlive(this);
        GC.KeepAlive(image);
        saliencyMap.Fix();
        return ret != 0;
    }

    /// <summary>
    /// Sets the image dimensions to prepare the algorithm's data structures.
    /// Must be called before <see cref="Init"/>.
    /// </summary>
    /// <param name="width">Width of the input images.</param>
    /// <param name="height">Height of the input images.</param>
    public void SetImagesize(int width, int height)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.saliency_MotionSaliencyBinWangApr2014_setImagesize(RawPtr, width, height));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Initializes all data structures for the algorithm.
    /// Call after <see cref="SetImagesize"/>.
    /// </summary>
    /// <returns>true if initialization succeeded.</returns>
    public bool Init()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.saliency_MotionSaliencyBinWangApr2014_init(RawPtr, out var ret));
        GC.KeepAlive(this);
        return ret != 0;
    }

    /// <summary>
    /// Gets or sets the image width.
    /// </summary>
    public int ImageWidth
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_MotionSaliencyBinWangApr2014_getImageWidth(RawPtr, out var val));
            GC.KeepAlive(this);
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_MotionSaliencyBinWangApr2014_setImageWidth(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets the image height.
    /// </summary>
    public int ImageHeight
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_MotionSaliencyBinWangApr2014_getImageHeight(RawPtr, out var val));
            GC.KeepAlive(this);
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_MotionSaliencyBinWangApr2014_setImageHeight(RawPtr, value));
            GC.KeepAlive(this);
        }
    }
}
