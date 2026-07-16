using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp.Saliency;

/// <summary>
/// Objectness saliency using the Binarized Normed Gradients (BING) algorithm.
/// </summary>
public class ObjectnessBING : Algorithm
{
    private ObjectnessBING(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(
            NativeMethods.saliency_Ptr_ObjectnessBING_delete(p)))
    { }

    /// <summary>
    /// Creates an ObjectnessBING instance.
    /// </summary>
    public static ObjectnessBING Create()
    {
        NativeMethods.HandleException(
            NativeMethods.saliency_ObjectnessBING_create(out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.saliency_Ptr_ObjectnessBING_get(smartPtr, out var rawPtr));
        return new ObjectnessBING(smartPtr, rawPtr);
    }

    /// <summary>
    /// Computes objectness proposals.
    /// The model files must be loaded via <see cref="SetTrainingPath"/> before calling this method.
    /// </summary>
    /// <param name="image">Input image.</param>
    /// <param name="objectnessBoundingBox">
    /// Detected objectness bounding boxes, each as (minX, minY, maxX, maxY).
    /// Sorted by descending objectness score.
    /// </param>
    /// <returns>true if the computation succeeded.</returns>
    public virtual bool ComputeSaliency(InputArray image, out Vec4i[] objectnessBoundingBox)
    {
        ThrowIfDisposed();

        using var vec = new StdVector<Vec4i>();
        NativeMethods.HandleException(
            NativeMethods.saliency_ObjectnessBING_computeSaliency(
                Handle, image.Proxy, vec.CvPtr, out var ret));
        GC.KeepAlive(image.Source);
        objectnessBoundingBox = vec.ToArray();
        return ret != 0;
    }

    /// <summary>
    /// Returns the objectness score for each bounding box in the order returned by
    /// <see cref="ComputeSaliency"/>. A larger value indicates a higher likelihood of being an object.
    /// </summary>
    public float[] GetObjectnessValues()
    {
        ThrowIfDisposed();
        using var vec = new StdVector<float>();
        NativeMethods.HandleException(
            NativeMethods.saliency_ObjectnessBING_getobjectnessValues(Handle, vec.CvPtr));
        return vec.ToArray();
    }

    /// <summary>
    /// Sets the path to the trained model files required by the BING algorithm.
    /// </summary>
    public void SetTrainingPath(string trainingPath)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(trainingPath);
        NativeMethods.HandleException(
            NativeMethods.saliency_ObjectnessBING_setTrainingPath(Handle, trainingPath));
    }

    /// <summary>
    /// Sets the directory path for writing optional output results.
    /// </summary>
    public void SetBBResDir(string resultsDir)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(resultsDir);
        NativeMethods.HandleException(
            NativeMethods.saliency_ObjectnessBING_setBBResDir(Handle, resultsDir));
    }

    /// <summary>
    /// Gets or sets the base value used internally by the BING algorithm.
    /// </summary>
    public double Base
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_ObjectnessBING_getBase(Handle, out var val));
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_ObjectnessBING_setBase(Handle, value));
        }
    }

    /// <summary>
    /// Gets or sets the NSS value.
    /// </summary>
    public int NSS
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_ObjectnessBING_getNSS(Handle, out var val));
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_ObjectnessBING_setNSS(Handle, value));
        }
    }

    /// <summary>
    /// Gets or sets the W value.
    /// </summary>
    public int W
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_ObjectnessBING_getW(Handle, out var val));
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_ObjectnessBING_setW(Handle, value));
        }
    }

    /// <summary>
    /// Stores algorithm parameters in a file storage.
    /// </summary>
    /// <remarks>
    /// Overrides the generic Algorithm.Write, which passes a cv::Algorithm* to the native side.
    /// cv::saliency::Saliency inherits Algorithm virtually, so a raw pointer obtained as
    /// ObjectnessBING* cannot be safely reinterpreted as Algorithm* on the managed side; this
    /// override calls write() with the pointer kept at its concrete native type instead.
    /// </remarks>
    /// <param name="fs"></param>
    public override void Write(FileStorage fs)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(fs);

        NativeMethods.HandleException(
            NativeMethods.saliency_ObjectnessBING_write(Handle, fs.CvPtr));
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
            NativeMethods.saliency_ObjectnessBING_read(Handle, fn.CvPtr));
        GC.KeepAlive(fn);
    }
}
