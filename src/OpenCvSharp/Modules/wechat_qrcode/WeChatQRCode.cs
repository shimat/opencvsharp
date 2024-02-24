using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

/// <summary>
/// WeChat QRCode includes two CNN-based models:
/// A object detection model and a super resolution model.
/// Object detection model is applied to detect QRCode with the bounding box.
/// super resolution model is applied to zoom in QRCode when it is small.
/// </summary>
public class WeChatQRCode : DisposableCvObject
{
    private Ptr? objectPtr;

    internal WeChatQRCode(IntPtr ptr)
    {
        objectPtr = new Ptr(ptr);
        this.ptr = objectPtr.Get();
    }

    /// <summary>
    /// Initialize the WeChatQRCode.
    /// It includes two models, which are packaged with caffe format.
    /// Therefore, there are prototxt and caffe models (In total, four paramenters).
    /// </summary>
    /// <param name="detectorPrototxtPath">prototxt file path for the detector</param>
    /// <param name="detectorCaffeModelPath">caffe model file path for the detector</param>
    /// <param name="superResolutionPrototxtPath">prototxt file path for the super resolution model</param>
    /// <param name="superResolutionCaffeModelPath">caffe file path for the super resolution model</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static WeChatQRCode Create(
        string detectorPrototxtPath,
        string detectorCaffeModelPath,
        string superResolutionPrototxtPath,
        string superResolutionCaffeModelPath)
    {
        if (string.IsNullOrWhiteSpace(detectorPrototxtPath))
            throw new ArgumentException("empty string", nameof(detectorPrototxtPath));
        if (string.IsNullOrWhiteSpace(detectorCaffeModelPath))
            throw new ArgumentException("empty string", nameof(detectorCaffeModelPath));
        if (string.IsNullOrWhiteSpace(superResolutionPrototxtPath))
            throw new ArgumentException("empty string", nameof(superResolutionPrototxtPath));
        if (string.IsNullOrWhiteSpace(superResolutionCaffeModelPath))
            throw new ArgumentException("empty string", nameof(superResolutionCaffeModelPath));

        NativeMethods.HandleException(
            NativeMethods.wechat_qrcode_create1(
                detectorPrototxtPath, detectorCaffeModelPath, superResolutionPrototxtPath, superResolutionCaffeModelPath,
                out var ptr));

        return new WeChatQRCode(ptr);
    }

    /// <summary>
    /// Both detects and decodes QR code.
    /// To simplify the usage, there is a only API: detectAndDecode
    /// </summary>
    /// <param name="inputImage">supports grayscale or color(BGR) image.</param>
    /// <param name="bbox">optional output array of vertices of the found QR code quadrangle.Will be empty if not found.</param>
    /// <param name="results">list of decoded string.</param>
    public void DetectAndDecode(InputArray inputImage, out Mat[] bbox, out string[] results)
    {
        if (inputImage is null)
            throw new ArgumentNullException(nameof(inputImage));
        inputImage.ThrowIfDisposed();

        using var bboxVec = new VectorOfMat();
        using var texts = new VectorOfString();
        NativeMethods.HandleException(
            NativeMethods.wechat_qrcode_WeChatQRCode_detectAndDecode(
                ptr, inputImage.CvPtr, bboxVec.CvPtr, texts.CvPtr));

        bbox = bboxVec.ToArray();
        results = texts.ToArray();
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

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.wechat_qrcode_Ptr_WeChatQRCode_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.wechat_qrcode_Ptr_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
