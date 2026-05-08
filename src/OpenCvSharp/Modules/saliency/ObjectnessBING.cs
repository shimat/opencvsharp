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
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        image.ThrowIfDisposed();

        using var vec = new VectorOfVec4i();
        NativeMethods.HandleException(
            NativeMethods.saliency_ObjectnessBING_computeSaliency(
                RawPtr, image.CvPtr, vec.CvPtr, out var ret));
        GC.KeepAlive(this);
        GC.KeepAlive(image);
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
        using var vec = new VectorOfFloat();
        NativeMethods.HandleException(
            NativeMethods.saliency_ObjectnessBING_getobjectnessValues(RawPtr, vec.CvPtr));
        GC.KeepAlive(this);
        return vec.ToArray();
    }

    /// <summary>
    /// Sets the path to the trained model files required by the BING algorithm.
    /// </summary>
    public void SetTrainingPath(string trainingPath)
    {
        ThrowIfDisposed();
        if (trainingPath is null)
            throw new ArgumentNullException(nameof(trainingPath));
        NativeMethods.HandleException(
            NativeMethods.saliency_ObjectnessBING_setTrainingPath(RawPtr, trainingPath));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Sets the directory path for writing optional output results.
    /// </summary>
    public void SetBBResDir(string resultsDir)
    {
        ThrowIfDisposed();
        if (resultsDir is null)
            throw new ArgumentNullException(nameof(resultsDir));
        NativeMethods.HandleException(
            NativeMethods.saliency_ObjectnessBING_setBBResDir(RawPtr, resultsDir));
        GC.KeepAlive(this);
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
                NativeMethods.saliency_ObjectnessBING_getBase(RawPtr, out var val));
            GC.KeepAlive(this);
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_ObjectnessBING_setBase(RawPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.saliency_ObjectnessBING_getNSS(RawPtr, out var val));
            GC.KeepAlive(this);
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_ObjectnessBING_setNSS(RawPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.saliency_ObjectnessBING_getW(RawPtr, out var val));
            GC.KeepAlive(this);
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.saliency_ObjectnessBING_setW(RawPtr, value));
            GC.KeepAlive(this);
        }
    }
}
