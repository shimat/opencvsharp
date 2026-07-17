using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.OptFlow;

/// <summary>
/// Class for computing the correspondences between two images using the Global Patch Collider (GPC) algorithm.
/// </summary>
/// <remarks>
/// This wraps <c>cv::optflow::GPCForest&lt;T&gt;</c>, a C++ template class, with a single fixed explicit
/// instantiation at <c>T = 5</c> (matching what upstream OpenCV's own samples/tests universally hardcode).
/// </remarks>
public class GPCForest5 : Algorithm
{
    private GPCForest5(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, static p => NativeMethods.HandleException(
            NativeMethods.optflow_Ptr_GPCForest5_delete(p)))
    {
    }

    /// <summary>
    /// Creates an empty GPC forest of 5 trees.
    /// </summary>
    public static GPCForest5 Create()
    {
        NativeMethods.HandleException(NativeMethods.optflow_createGPCForest5(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.optflow_Ptr_GPCForest5_get(smartPtr, out var rawPtr));
        return new GPCForest5(smartPtr, rawPtr);
    }

    /// <summary>
    /// Trains the forest using one sample set for every tree.
    /// Consider using the overload taking image/ground-truth-flow triples instead for better quality.
    /// </summary>
    /// <param name="samples">Training samples, e.g. obtained via <see cref="GPCTrainingSamples.Create"/>.</param>
    /// <param name="trainingParams">Training parameters. Uses the native defaults when null.</param>
    public void Train(GPCTrainingSamples samples, GPCTrainingParams? trainingParams = null)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(samples);
        samples.ThrowIfDisposed();

        var nativeParams = (trainingParams ?? new GPCTrainingParams()).ToNative();
        NativeMethods.HandleException(
            NativeMethods.optflow_GPCForest5_train(Handle, samples.Handle, in nativeParams));

        GC.KeepAlive(this);
        GC.KeepAlive(samples);
    }

    /// <summary>
    /// Trains the forest using individual samples extracted for each tree from the given image pairs
    /// and ground-truth flow. Generally produces better quality than the single-sample-set overload.
    /// </summary>
    /// <param name="imagesFrom">First images of the image pairs.</param>
    /// <param name="imagesTo">Second images of the image pairs.</param>
    /// <param name="gt">Ground-truth flow for each image pair.</param>
    /// <param name="trainingParams">Training parameters. Uses the native defaults when null.</param>
    public void Train(
        IEnumerable<Mat> imagesFrom, IEnumerable<Mat> imagesTo, IEnumerable<Mat> gt,
        GPCTrainingParams? trainingParams = null)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(imagesFrom);
        ArgumentNullException.ThrowIfNull(imagesTo);
        ArgumentNullException.ThrowIfNull(gt);

        var imagesFromArray = imagesFrom as Mat[] ?? imagesFrom.ToArray();
        var imagesToArray = imagesTo as Mat[] ?? imagesTo.ToArray();
        var gtArray = gt as Mat[] ?? gt.ToArray();
        if (imagesFromArray.Length != imagesToArray.Length || imagesFromArray.Length != gtArray.Length)
            throw new ArgumentException("imagesFrom, imagesTo, and gt must have the same number of elements.");

        var imagesFromPtrs = imagesFromArray.Select(m => m.CvPtr).ToArray();
        var imagesToPtrs = imagesToArray.Select(m => m.CvPtr).ToArray();
        var gtPtrs = gtArray.Select(m => m.CvPtr).ToArray();

        var nativeParams = (trainingParams ?? new GPCTrainingParams()).ToNative();
        NativeMethods.HandleException(
            NativeMethods.optflow_GPCForest5_train_fromMats(
                Handle,
                imagesFromPtrs, imagesFromPtrs.Length,
                imagesToPtrs, imagesToPtrs.Length,
                gtPtrs, gtPtrs.Length,
                in nativeParams));

        GC.KeepAlive(this);
        GC.KeepAlive(imagesFromArray);
        GC.KeepAlive(imagesToArray);
        GC.KeepAlive(gtArray);
    }

    /// <summary>
    /// Finds correspondences between two images using the trained forest.
    /// </summary>
    /// <param name="imgFrom">First image in a sequence (3-channel).</param>
    /// <param name="imgTo">Second image in a sequence (3-channel).</param>
    /// <param name="pointsFrom">Coordinates in <paramref name="imgFrom"/> of each found correspondence.</param>
    /// <param name="pointsTo">Corresponding coordinates in <paramref name="imgTo"/>, parallel to <paramref name="pointsFrom"/>.</param>
    /// <param name="matchingParams">Additional matching parameters for fine-tuning. Uses the native defaults when null.</param>
    public void FindCorrespondences(
        InputArray imgFrom, InputArray imgTo, out Point[] pointsFrom, out Point[] pointsTo,
        GPCMatchingParams? matchingParams = null)
    {
        ThrowIfDisposed();

        var nativeParams = (matchingParams ?? new GPCMatchingParams()).ToNative();
        using var pointsFromVec = new StdVector<Point>();
        using var pointsToVec = new StdVector<Point>();

        NativeMethods.HandleException(
            NativeMethods.optflow_GPCForest5_findCorrespondences(
                Handle, imgFrom.Proxy, imgTo.Proxy, pointsFromVec.CvPtr, pointsToVec.CvPtr, in nativeParams));

        pointsFrom = pointsFromVec.ToArray();
        pointsTo = pointsToVec.ToArray();

        GC.KeepAlive(this);
        GC.KeepAlive(imgFrom.Source);
        GC.KeepAlive(imgTo.Source);
    }
}
