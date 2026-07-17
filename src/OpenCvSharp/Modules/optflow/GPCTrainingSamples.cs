using OpenCvSharp.Internal;

namespace OpenCvSharp.OptFlow;

/// <summary>
/// Class encapsulating training samples for the Global Patch Collider (GPC).
/// </summary>
public class GPCTrainingSamples : CvPtrObject
{
    private GPCTrainingSamples(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, static p => NativeMethods.HandleException(
            NativeMethods.optflow_Ptr_GPCTrainingSamples_delete(p)))
    {
    }

    /// <summary>
    /// Extracts training samples from pairs of images and the corresponding ground-truth flow.
    /// Sizes of all the provided collections must be equal.
    /// </summary>
    /// <param name="imagesFrom">First images of the image pairs.</param>
    /// <param name="imagesTo">Second images of the image pairs.</param>
    /// <param name="gt">Ground-truth flow for each image pair.</param>
    /// <param name="descriptorType">Type of descriptors to extract.</param>
    public static GPCTrainingSamples Create(
        IEnumerable<Mat> imagesFrom, IEnumerable<Mat> imagesTo, IEnumerable<Mat> gt,
        GPCDescType descriptorType = GPCDescType.DCT)
    {
        ArgumentNullException.ThrowIfNull(imagesFrom);
        ArgumentNullException.ThrowIfNull(imagesTo);
        ArgumentNullException.ThrowIfNull(gt);

        var imagesFromArray = imagesFrom as Mat[] ?? imagesFrom.ToArray();
        var imagesToArray = imagesTo as Mat[] ?? imagesTo.ToArray();
        var gtArray = gt as Mat[] ?? gt.ToArray();
        if (imagesFromArray.Length != imagesToArray.Length || imagesFromArray.Length != gtArray.Length)
            throw new ArgumentException("Sizes of all the provided collections must be equal.");

        var imagesFromPtrs = imagesFromArray.Select(m => m.CvPtr).ToArray();
        var imagesToPtrs = imagesToArray.Select(m => m.CvPtr).ToArray();
        var gtPtrs = gtArray.Select(m => m.CvPtr).ToArray();

        NativeMethods.HandleException(
            NativeMethods.optflow_GPCTrainingSamples_create(
                imagesFromPtrs, imagesFromPtrs.Length,
                imagesToPtrs, imagesToPtrs.Length,
                gtPtrs, gtPtrs.Length,
                (int)descriptorType,
                out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.optflow_Ptr_GPCTrainingSamples_get(smartPtr, out var rawPtr));

        GC.KeepAlive(imagesFromArray);
        GC.KeepAlive(imagesToArray);
        GC.KeepAlive(gtArray);
        return new GPCTrainingSamples(smartPtr, rawPtr);
    }

    /// <summary>
    /// Number of extracted training samples.
    /// </summary>
    public int Size
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.optflow_GPCTrainingSamples_size(Handle, out var ret));
            return (int)ret;
        }
    }

    /// <summary>
    /// Descriptor type used by the extracted samples.
    /// </summary>
    public GPCDescType Type
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.optflow_GPCTrainingSamples_type(Handle, out var ret));
            return (GPCDescType)ret;
        }
    }
}
