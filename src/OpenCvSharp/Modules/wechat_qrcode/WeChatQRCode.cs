using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

/// <summary>
/// WeChat QRCode includes two CNN-based models:
/// A object detection model and a super resolution model.
/// Object detection model is applied to detect QRCode with the bounding box.
/// super resolution model is applied to zoom in QRCode when it is small.
/// </summary>
public class WeChatQRCode : CvObject
{
    /// <summary>
    /// Initialize the WeChatQRCode.
    /// It includes two models, which are packaged with caffe format.
    /// Therefore, there are prototxt and caffe models (In total, four paramenters).
    /// Pass empty strings to create a detector without neural network models.
    /// </summary>
    /// <param name="detectorPrototxtPath">prototxt file path for the detector</param>
    /// <param name="detectorCaffeModelPath">caffe model file path for the detector</param>
    /// <param name="superResolutionPrototxtPath">prototxt file path for the super resolution model</param>
    /// <param name="superResolutionCaffeModelPath">caffe file path for the super resolution model</param>
    public WeChatQRCode(
        string detectorPrototxtPath = "",
        string detectorCaffeModelPath = "",
        string superResolutionPrototxtPath = "",
        string superResolutionCaffeModelPath = "")
    {
        if (detectorPrototxtPath is null)
            throw new ArgumentNullException(nameof(detectorPrototxtPath));
        if (detectorCaffeModelPath is null)
            throw new ArgumentNullException(nameof(detectorCaffeModelPath));
        if (superResolutionPrototxtPath is null)
            throw new ArgumentNullException(nameof(superResolutionPrototxtPath));
        if (superResolutionCaffeModelPath is null)
            throw new ArgumentNullException(nameof(superResolutionCaffeModelPath));

        NativeMethods.HandleException(
            NativeMethods.wechat_qrcode_create1(
                detectorPrototxtPath, detectorCaffeModelPath, superResolutionPrototxtPath, superResolutionCaffeModelPath,
                out var ptr));

        SetSafeHandle(new OpenCvPtrSafeHandle(ptr, ownsHandle: true,
            releaseAction: h => NativeMethods.HandleException(NativeMethods.wechat_qrcode_delete(h))));
    }

    /// <summary>
    /// Both detects and decodes QR code.
    /// To simplify the usage, there is a only API: detectAndDecode
    /// </summary>
    /// <param name="inputImage">supports grayscale or color(BGR) image.</param>
    /// <param name="points">
    /// output array of vertices of the found QR code quadrangles.
    /// Each element is an array of 4 <see cref="Point2f"/> representing the corners of one detected QR code.
    /// Will be empty if not found.
    /// </param>
    /// <returns>list of decoded string.</returns>
    public string[] DetectAndDecode(InputArray inputImage, out Point2f[][] points)
    {
        if (inputImage is null)
            throw new ArgumentNullException(nameof(inputImage));
        inputImage.ThrowIfDisposed();

        using var pointsVec = new VectorOfVectorPoint2f();
        using var texts = new VectorOfString();
        NativeMethods.HandleException(
            NativeMethods.wechat_qrcode_WeChatQRCode_detectAndDecode_points(
                CvPtr, inputImage.CvPtr, pointsVec.CvPtr, texts.CvPtr));

        points = pointsVec.ToArray();
        GC.KeepAlive(this);
        GC.KeepAlive(inputImage);
        return texts.ToArray();
    }

    /// <summary>
    /// Both detects and decodes QR code.
    /// Returns each QR code's corner points as a raw <see cref="Mat"/> (4x2, CV_32FC1),
    /// which can be passed directly to other OpenCV functions.
    /// </summary>
    /// <param name="inputImage">supports grayscale or color(BGR) image.</param>
    /// <param name="bbox">
    /// output array of vertices of the found QR code quadrangles as raw <see cref="Mat"/> (4x2, CV_32FC1).
    /// Will be empty if not found.
    /// </param>
    /// <returns>list of decoded string.</returns>
    public string[] DetectAndDecodeRaw(InputArray inputImage, out Mat[] bbox)
    {
        if (inputImage is null)
            throw new ArgumentNullException(nameof(inputImage));
        inputImage.ThrowIfDisposed();

        using var bboxVec = new VectorOfMat();
        using var texts = new VectorOfString();
        NativeMethods.HandleException(
            NativeMethods.wechat_qrcode_WeChatQRCode_detectAndDecode(
                CvPtr, inputImage.CvPtr, bboxVec.CvPtr, texts.CvPtr));

        bbox = bboxVec.ToArray();
        GC.KeepAlive(this);
        GC.KeepAlive(inputImage);
        return texts.ToArray();
    }
}
