using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.LineDescriptor;

/// <summary>
/// Matches binary line descriptors using multi-index hashing.
/// </summary>
public sealed class BinaryDescriptorMatcher : Algorithm
{
    private BinaryDescriptorMatcher(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p =>
            NativeMethods.HandleException(NativeMethods.line_descriptor_Ptr_BinaryDescriptorMatcher_delete(p)))
    {
    }

    /// <summary>Creates a binary line descriptor matcher.</summary>
    public static BinaryDescriptorMatcher Create()
    {
        NativeMethods.HandleException(
            NativeMethods.line_descriptor_BinaryDescriptorMatcher_create(out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.line_descriptor_Ptr_BinaryDescriptorMatcher_get(smartPtr, out var rawPtr));
        return new BinaryDescriptorMatcher(smartPtr, rawPtr);
    }

    /// <summary>Finds the best train descriptor for every query descriptor.</summary>
    public DMatch[] Match(Mat queryDescriptors, Mat trainDescriptors, Mat? mask = null)
    {
        Validate(queryDescriptors, nameof(queryDescriptors));
        Validate(trainDescriptors, nameof(trainDescriptors));
        mask?.ThrowIfDisposed();
        using var matches = new StdVector<DMatch>();
        NativeMethods.HandleException(
            NativeMethods.line_descriptor_BinaryDescriptorMatcher_match(
                Handle, queryDescriptors.CvPtr, trainDescriptors.CvPtr, matches.CvPtr,
                mask?.Handle ?? OpenCvSafeHandle.Null));
        GC.KeepAlive(queryDescriptors);
        GC.KeepAlive(trainDescriptors);
        GC.KeepAlive(mask);
        return matches.ToArray();
    }

    /// <summary>Matches query descriptors against the matcher's trained dataset.</summary>
    public DMatch[] MatchQuery(Mat queryDescriptors, IEnumerable<Mat>? masks = null)
    {
        Validate(queryDescriptors, nameof(queryDescriptors));
        var maskArray = Materialize(masks);
        using var matches = new StdVector<DMatch>();
        NativeMethods.HandleException(
            NativeMethods.line_descriptor_BinaryDescriptorMatcher_matchQuery(
                Handle, queryDescriptors.CvPtr, matches.CvPtr,
                maskArray.Select(x => x.CvPtr).ToArray(), maskArray.Length));
        GC.KeepAlive(queryDescriptors);
        GC.KeepAlive(maskArray);
        return matches.ToArray();
    }

    /// <summary>Finds the k nearest train descriptors for every query descriptor.</summary>
    public DMatch[][] KnnMatch(
        Mat queryDescriptors,
        Mat trainDescriptors,
        int k,
        Mat? mask = null,
        bool compactResult = false)
    {
        Validate(queryDescriptors, nameof(queryDescriptors));
        Validate(trainDescriptors, nameof(trainDescriptors));
        mask?.ThrowIfDisposed();
        using var matches = new VectorOfVectorDMatch();
        NativeMethods.HandleException(
            NativeMethods.line_descriptor_BinaryDescriptorMatcher_knnMatch(
                Handle, queryDescriptors.CvPtr, trainDescriptors.CvPtr, matches.CvPtr, k,
                mask?.Handle ?? OpenCvSafeHandle.Null, compactResult ? 1 : 0));
        GC.KeepAlive(queryDescriptors);
        GC.KeepAlive(trainDescriptors);
        GC.KeepAlive(mask);
        return matches.ToArray();
    }

    /// <summary>Finds k nearest matches in the matcher's trained dataset.</summary>
    public DMatch[][] KnnMatchQuery(
        Mat queryDescriptors,
        int k,
        IEnumerable<Mat>? masks = null,
        bool compactResult = false)
    {
        Validate(queryDescriptors, nameof(queryDescriptors));
        var maskArray = Materialize(masks);
        using var matches = new VectorOfVectorDMatch();
        NativeMethods.HandleException(
            NativeMethods.line_descriptor_BinaryDescriptorMatcher_knnMatchQuery(
                Handle, queryDescriptors.CvPtr, matches.CvPtr, k,
                maskArray.Select(x => x.CvPtr).ToArray(), maskArray.Length,
                compactResult ? 1 : 0));
        GC.KeepAlive(queryDescriptors);
        GC.KeepAlive(maskArray);
        return matches.ToArray();
    }

    /// <summary>Adds descriptor matrices to the matcher's pending dataset.</summary>
    public void Add(IEnumerable<Mat> descriptors)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(descriptors);
        var descriptorArray = Materialize(descriptors);
        NativeMethods.HandleException(
            NativeMethods.line_descriptor_BinaryDescriptorMatcher_add(
                Handle, descriptorArray.Select(x => x.CvPtr).ToArray(), descriptorArray.Length));
        GC.KeepAlive(descriptorArray);
    }

    /// <summary>Builds the search dataset from descriptors added to the matcher.</summary>
    public void Train()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.line_descriptor_BinaryDescriptorMatcher_train(Handle));
    }

    /// <summary>Clears the dataset and all internal matcher state.</summary>
    public void Clear()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.line_descriptor_BinaryDescriptorMatcher_clear(Handle));
    }

    private void Validate(Mat mat, string parameterName)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(mat, parameterName);
        mat.ThrowIfDisposed();
    }

    private static Mat[] Materialize(IEnumerable<Mat>? mats)
    {
        if (mats is null)
            return [];
        var result = mats.ToArray();
        foreach (var mat in result)
        {
            if (mat is null)
                throw new ArgumentException("The collection contains null.", nameof(mats));
            mat.ThrowIfDisposed();
        }
        return result;
    }
}
