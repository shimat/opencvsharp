using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

/// <summary>
/// WeChat QRCode includes two CNN-based models:
/// A object detection model and a super resolution model.
/// Object detection model is applied to detect QRCode with the bounding box.
/// super resolution model is applied to zoom in QRCode when it is small.
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
    /// It includes two models, which are packaged with caffe format.
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
            NativeMethods.barcode_detector_create(
                superResolutionPrototxtPath, superResolutionCaffeModelPath,
                out var ptr));

        return new BarcodeDetector(ptr);
    }

    /// <summary>
    /// Both detects and decodes QR code.
    /// To simplify the usage, there is a only API: detectAndDecode
    /// </summary>
    /// <param name="inputImage">supports grayscale or color(BGR) image.</param>
    /// <param name="bbox">optional output array of vertices of the found QR code quadrangle.Will be empty if not found.</param>
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
            NativeMethods.barcode_detector_BarcodeDetector_detectAndDecodeWithType(
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

    internal class Ptr(IntPtr ptr) : OpenCvSharp.Ptr(ptr)
    {
        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.barcode_detector_Ptr_BarcodeDetector_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.barcode_detector_Ptr_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
