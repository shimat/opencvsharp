using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Face;

/// <summary>
/// Base class for face-recognition prediction result collectors.
/// </summary>
public abstract class PredictCollector : CvPtrObject
{
    /// <summary>
    /// Initializes a collector backed by a native smart pointer.
    /// </summary>
    protected PredictCollector(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release)
    {
    }

    /// <summary>Resets the collector for an expected number of prediction results.</summary>
    public void Init(int size)
    {
        ThrowIfDisposed();
        ArgumentOutOfRangeException.ThrowIfNegative(size);
        NativeMethods.HandleException(NativeMethods.face_PredictCollector_init(Handle, (nuint)size));
    }

    /// <summary>Adds a prediction result and returns whether collection should continue.</summary>
    public bool Collect(int label, double distance)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_PredictCollector_collect(Handle, label, distance, out var result));
        return result != 0;
    }
}

/// <summary>
/// A collected face-recognition label and distance.
/// </summary>
public readonly record struct PredictResult(int Label, double Distance);

/// <summary>
/// Default collector that tracks the minimum distance subject to a threshold.
/// </summary>
public sealed class StandardCollector : PredictCollector
{
    private StandardCollector(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p =>
            NativeMethods.HandleException(NativeMethods.face_Ptr_StandardCollector_delete(p)))
    {
    }

    /// <summary>
    /// Creates a standard collector.
    /// </summary>
    public static StandardCollector Create(double threshold = double.MaxValue)
    {
        NativeMethods.HandleException(
            NativeMethods.face_StandardCollector_create(threshold, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.face_Ptr_StandardCollector_get(smartPtr, out var rawPtr));
        return new StandardCollector(smartPtr, rawPtr);
    }

    /// <summary>Gets the label with the minimum distance.</summary>
    public int MinLabel
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.face_StandardCollector_getMinLabel(Handle, out var value));
            return value;
        }
    }

    /// <summary>Gets the minimum collected distance.</summary>
    public double MinDistance
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.face_StandardCollector_getMinDist(Handle, out var value));
            return value;
        }
    }

    /// <summary>Gets all collected results, optionally sorted by distance.</summary>
    public PredictResult[] GetResults(bool sorted = false)
    {
        ThrowIfDisposed();
        using var labels = new StdVector<int>();
        using var distances = new StdVector<double>();
        NativeMethods.HandleException(
            NativeMethods.face_StandardCollector_getResults(
                Handle, sorted ? 1 : 0, labels.CvPtr, distances.CvPtr));
        return Combine(labels.ToArray(), distances.ToArray());
    }

    /// <summary>Gets the minimum distance collected for each label.</summary>
    public IReadOnlyDictionary<int, double> GetResultsMap()
    {
        ThrowIfDisposed();
        using var labels = new StdVector<int>();
        using var distances = new StdVector<double>();
        NativeMethods.HandleException(
            NativeMethods.face_StandardCollector_getResultsMap(
                Handle, labels.CvPtr, distances.CvPtr));
        return Combine(labels.ToArray(), distances.ToArray()).ToDictionary(x => x.Label, x => x.Distance);
    }

    private static PredictResult[] Combine(int[] labels, double[] distances)
    {
        if (labels.Length != distances.Length)
            throw new OpenCvSharpException("The native collector returned inconsistent result arrays.");
        return labels.Zip(distances, static (label, distance) => new PredictResult(label, distance)).ToArray();
    }
}
