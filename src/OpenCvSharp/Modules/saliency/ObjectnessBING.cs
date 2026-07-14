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
    /// <returns>
    /// Detected objectness bounding boxes, each as (minX, minY, maxX, maxY), sorted by descending objectness score.
    /// Empty if the computation failed.
    /// </returns>
    public virtual Vec4i[] ComputeSaliency(InputArray image)
    {
        ThrowIfDisposed();

        using var vec = new StdVector<Vec4i>();
        NativeMethods.HandleException(
            NativeMethods.saliency_ObjectnessBING_computeSaliency(
                Handle, image.Proxy, vec.CvPtr, out _));
        GC.KeepAlive(image.Source);
        return vec.ToArray();
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
}
