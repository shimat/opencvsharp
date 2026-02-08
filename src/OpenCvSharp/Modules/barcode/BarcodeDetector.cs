using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

/// <summary>
/// BarcodeDetector use a super resolution model.
/// super resolution model is applied to zoom in Barcode when it is small.
/// </summary>
public class BarcodeDetector : DisposableCvObject
{
    private Ptr? objectPtr;

    internal BarcodeDetector(IntPtr ptr)
    {
        objectPtr = new Ptr(ptr);
        this.ptr = objectPtr.Get();
    }

    /// <summary>
    /// Initialize the BarcodeDetector.
    /// It includes one models, which are packaged with caffe format.
    /// Therefore, there are prototxt and caffe models (In total, four paramenters).
    /// </summary>
    /// <param name="superResolutionPrototxtPath">prototxt file path for the super resolution model</param>
    /// <param name="superResolutionCaffeModelPath">caffe file path for the super resolution model</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static BarcodeDetector Create(
        string superResolutionPrototxtPath,
        string superResolutionCaffeModelPath)
    {
        if (string.IsNullOrWhiteSpace(superResolutionPrototxtPath))
            throw new ArgumentException("empty string", nameof(superResolutionPrototxtPath));
        if (string.IsNullOrWhiteSpace(superResolutionCaffeModelPath))
            throw new ArgumentException("empty string", nameof(superResolutionCaffeModelPath));

        NativeMethods.HandleException(
            NativeMethods.barcode_BarcodeDetector_create(
                superResolutionPrototxtPath, superResolutionCaffeModelPath,
                out var ptr));

        return new BarcodeDetector(ptr);
    }

    /// <summary>
    /// Set detector downsampling threshold.
    /// 
    /// By default, the detect method resizes the input image to this limit if the smallest image size is is greater than the threshold.
    /// Increasing this value can improve detection accuracy and the number of results at the expense of performance.
    /// Correlates with detector scales.Setting this to a large value will disable downsampling.
    /// </summary>
    /// <param name="thresh">downsampling limit to apply (default 512).</param>
    public void SetDownsamplingThreshold(double thresh)
    {
        NativeMethods.HandleException(
            NativeMethods.barcode_BarcodeDetector_setDownsamplingThreshold(ptr, thresh));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Set detector gradient magnitude threshold.
    /// 
    /// Sets the coherence threshold for detected bounding boxes.
    /// Increasing this value will generate a closer fitted bounding box width and can reduce false-positives.
    /// Values between 16 and 1024 generally work, while too high of a value will remove valid detections.
    /// </summary>
    /// <param name="thresh">gradient magnitude threshold (default 64).</param>
    public void SetGradientThreshold(double thresh)
    {
        NativeMethods.HandleException(
            NativeMethods.barcode_BarcodeDetector_setGradientThreshold(ptr, thresh));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Set detector box filter sizes.
    /// 
    /// Adjusts the value and the number of box filters used in the detect step.
    /// The filter sizes directly correlate with the expected line widths for a barcode.Corresponds to expected barcode distance.
    /// If the downsampling limit is increased, filter sizes need to be adjusted in an inversely proportional way.
    /// </summary>
    /// <param name="sizes">box filter sizes, relative to minimum dimension of the image (default [0.01, 0.03, 0.06, 0.08]).</param>
    public void SetDetectorScales(IEnumerable<float> sizes)
    {
        if (sizes is null)
            throw new ArgumentNullException(nameof(sizes));
        using var sizesVec = new VectorOfFloat(sizes);
        NativeMethods.HandleException(
            NativeMethods.barcode_BarcodeDetector_setDetectorScales(ptr, sizesVec.CvPtr));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Both detects and decodes barcode.
    /// To simplify the usage, there is a only API: detectAndDecode
    /// </summary>
    /// <param name="inputImage">supports grayscale or color(BGR) image.</param>
    /// <param name="points">optional output vector of vertices of the found  barcode rectangle. Will be empty if not found.</param>
    /// <param name="results">list of decoded string.</param>
    /// <param name="types">list of decoded types.</param>
    public void DetectAndDecode(InputArray inputImage, out Point2f[] points, out string[] results, out string[] types)
    {
        if (inputImage is null)
            throw new ArgumentNullException(nameof(inputImage));
        inputImage.ThrowIfDisposed();

        using var pointsVec = new VectorOfPoint2f();
        using var infos = new VectorOfString();
        using var resultTypes = new VectorOfString();
        NativeMethods.HandleException(
            NativeMethods.barcode_BarcodeDetector_detectAndDecodeWithType(
                ptr, inputImage.CvPtr, pointsVec.CvPtr, infos.CvPtr, resultTypes.CvPtr));

        points = pointsVec.ToArray();
        results = infos.ToArray();
        types = resultTypes.ToArray();
        GC.KeepAlive(this);
        GC.KeepAlive(inputImage);
    }

    /// <inheritdoc />
    protected override void DisposeManaged()
    {
        objectPtr?.Dispose();
        objectPtr = null;
        base.DisposeManaged();
    }

    internal sealed class Ptr(IntPtr ptr) : OpenCvSharp.Ptr(ptr)
    {
        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.barcode_Ptr_BarcodeDetector_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.barcode_Ptr_BarcodeDetector_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
