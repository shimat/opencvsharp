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

        NativeMethods.HandleException(
            NativeMethods.saliency_MotionSaliencyBinWangApr2014_computeSaliency(
                Handle, image.Proxy, saliencyMap.Proxy, out var ret));
        GC.KeepAlive(image.Source);
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
            NativeMethods.saliency_MotionSaliencyBinWangApr2014_setImagesize(Handle, width, height));
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
            NativeMethods.saliency_MotionSaliencyBinWangApr2014_init(Handle, out var ret));
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
                NativeMethods.saliency_MotionSaliencyBinWangApr2014_getImageWidth(Handle, out var val));
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_MotionSaliencyBinWangApr2014_setImageWidth(Handle, value));
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
                NativeMethods.saliency_MotionSaliencyBinWangApr2014_getImageHeight(Handle, out var val));
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_MotionSaliencyBinWangApr2014_setImageHeight(Handle, value));
        }
    }

    /// <summary>
    /// Stores algorithm parameters in a file storage.
    /// </summary>
    /// <remarks>
    /// Overrides the generic Algorithm.Write, which passes a cv::Algorithm* to the native side.
    /// cv::saliency::Saliency inherits Algorithm virtually, so a raw pointer obtained as
    /// MotionSaliencyBinWangApr2014* cannot be safely reinterpreted as Algorithm* on the managed
    /// side; this override calls write() with the pointer kept at its concrete native type instead.
    /// </remarks>
    /// <param name="fs"></param>
    public override void Write(FileStorage fs)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(fs);

        NativeMethods.HandleException(
            NativeMethods.saliency_MotionSaliencyBinWangApr2014_write(Handle, fs.CvPtr));
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
            NativeMethods.saliency_MotionSaliencyBinWangApr2014_read(Handle, fn.CvPtr));
        GC.KeepAlive(fn);
    }
}
