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
    /// It includes two ONNX models: an object detection model and a super resolution model.
    /// Pass empty strings to create a detector without neural network models.
    /// </summary>
    /// <param name="detectorModelPath">ONNX model file path for the detector</param>
    /// <param name="superResolutionModelPath">ONNX model file path for the super resolution model</param>
    public WeChatQRCode(
        string detectorModelPath = "",
        string superResolutionModelPath = "")
    {
        if (detectorModelPath is null)
            throw new ArgumentNullException(nameof(detectorModelPath));
        if (superResolutionModelPath is null)
            throw new ArgumentNullException(nameof(superResolutionModelPath));

        NativeMethods.HandleException(
            NativeMethods.wechat_qrcode_create1(
                detectorModelPath, superResolutionModelPath,
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
