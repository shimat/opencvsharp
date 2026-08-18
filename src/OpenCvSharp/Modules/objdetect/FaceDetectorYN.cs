using OpenCvSharp.Dnn;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

/// <summary>
/// DNN-based face detector
/// </summary>
public class FaceDetectorYN : Algorithm
{
    /// <summary>
    /// Creates instance by cv::Ptr&lt;cv::FaceDetectorYN&gt;* and cv::FaceDetectorYN*
    /// </summary>
    private FaceDetectorYN(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(
            NativeMethods.objdetect_Ptr_FaceDetectorYN_delete(p)))
    { }

    /// <summary>
    /// Creates an instance of this class with given parameters.
    /// </summary>
    /// <param name="model">The path to the requested model</param>
    /// <param name="config">The path to the config file for compatibility, which is not requested for ONNX models</param>
    /// <param name="inputSize">The size of the input image</param>
    /// <param name="scoreThreshold">The threshold to filter out bounding boxes of score smaller than the given value</param>
    /// <param name="nmsThreshold">The threshold to suppress bounding boxes of IoU bigger than the given value</param>
    /// <param name="topK">Keep top K bboxes before NMS</param>
    /// <param name="backendId">The id of backend</param>
    /// <param name="targetId">The id of target device</param>
    public static FaceDetectorYN Create(
        string model,
        string config,
        Size inputSize,
        float scoreThreshold = 0.9f,
        float nmsThreshold = 0.3f,
        int topK = 5000,
        Backend backendId = Backend.DEFAULT,
        Target targetId = Target.CPU)
    {
        using StdString csModel = new(model);
        using StdString csConfig = new(config);

        NativeMethods.HandleException(
            NativeMethods.objdetect_FaceDetectorYN_create(
                csModel.CvPtr,
                csConfig.CvPtr,
                ref inputSize,
                scoreThreshold,
                nmsThreshold,
                topK,
                (int)backendId,
                (int)targetId,
                out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.objdetect_Ptr_FaceDetectorYN_get(smartPtr, out var rawPtr));
        return new FaceDetectorYN(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates an instance of this class from buffers containing the model weights and configuration.
    /// </summary>
    /// <param name="framework">Name of the framework.</param>
    /// <param name="bufferModel">A buffer containing the binary model weights.</param>
    /// <param name="bufferConfig">A buffer containing the network configuration.</param>
    /// <param name="inputSize">The size of the input image.</param>
    /// <param name="scoreThreshold">The threshold to filter out bounding boxes of score smaller than the given value.</param>
    /// <param name="nmsThreshold">The threshold to suppress bounding boxes of IoU bigger than the given value.</param>
    /// <param name="topK">Keep top K bounding boxes before NMS.</param>
    /// <param name="backendId">The id of backend.</param>
    /// <param name="targetId">The id of target device.</param>
    public static FaceDetectorYN Create(
        string framework,
        byte[] bufferModel,
        byte[] bufferConfig,
        Size inputSize,
        float scoreThreshold = 0.9f,
        float nmsThreshold = 0.3f,
        int topK = 5000,
        Backend backendId = Backend.DEFAULT,
        Target targetId = Target.CPU)
    {
        ArgumentNullException.ThrowIfNull(bufferModel);
        ArgumentNullException.ThrowIfNull(bufferConfig);

        using StdString csFramework = new(framework);
        using var bufferModelVec = new StdVector<byte>(bufferModel);
        using var bufferConfigVec = new StdVector<byte>(bufferConfig);

        NativeMethods.HandleException(
            NativeMethods.objdetect_FaceDetectorYN_create_buffer(
                csFramework.CvPtr,
                bufferModelVec.CvPtr,
                bufferConfigVec.CvPtr,
                inputSize,
                scoreThreshold,
                nmsThreshold,
                topK,
                (int)backendId,
                (int)targetId,
                out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.objdetect_Ptr_FaceDetectorYN_get(smartPtr, out var rawPtr));
        return new FaceDetectorYN(smartPtr, rawPtr);
    }

    /// <summary>
    /// Sets the network input size, overwriting the size specified when the detector was created.
    /// </summary>
    /// <param name="inputSize">The size of the input image.</param>
    public void SetInputSize(Size inputSize)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.objdetect_FaceDetectorYN_setInputSize(Handle, inputSize));
    }

    /// <summary>
    /// Sets the network input size, overwriting the size specified when the detector was created.
    /// </summary>
    /// <param name="width">The input image width.</param>
    /// <param name="height">The input image height.</param>
    public void SetInputSize(int width, int height) => SetInputSize(new Size(width, height));

    /// <summary>
    /// Gets the network input size.
    /// </summary>
    /// <returns>The size of the input image.</returns>
    public Size GetInputSize()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.objdetect_FaceDetectorYN_getInputSize(Handle, out var result));
        return result;
    }

    /// <summary>
    /// Sets the score threshold used to filter bounding boxes.
    /// </summary>
    /// <param name="scoreThreshold">The threshold for filtering bounding boxes.</param>
    public void SetScoreThreshold(float scoreThreshold)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.objdetect_FaceDetectorYN_setScoreThreshold(Handle, scoreThreshold));
    }

    /// <summary>
    /// Gets the score threshold used to filter bounding boxes.
    /// </summary>
    /// <returns>The score threshold.</returns>
    public float GetScoreThreshold()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.objdetect_FaceDetectorYN_getScoreThreshold(Handle, out var result));
        return result;
    }

    /// <summary>
    /// Sets the non-maximum-suppression threshold.
    /// </summary>
    /// <param name="nmsThreshold">The threshold for NMS.</param>
    public void SetNMSThreshold(float nmsThreshold)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.objdetect_FaceDetectorYN_setNMSThreshold(Handle, nmsThreshold));
    }

    /// <summary>
    /// Gets the non-maximum-suppression threshold.
    /// </summary>
    /// <returns>The threshold for NMS.</returns>
    public float GetNMSThreshold()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.objdetect_FaceDetectorYN_getNMSThreshold(Handle, out var result));
        return result;
    }

    /// <summary>
    /// Sets the number of bounding boxes preserved before NMS.
    /// </summary>
    /// <param name="topK">The number of bounding boxes to preserve.</param>
    public void SetTopK(int topK)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.objdetect_FaceDetectorYN_setTopK(Handle, topK));
    }

    /// <summary>
    /// Gets the number of bounding boxes preserved before NMS.
    /// </summary>
    /// <returns>The number of bounding boxes to preserve.</returns>
    public int GetTopK()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.objdetect_FaceDetectorYN_getTopK(Handle, out var result));
        return result;
    }

    /// <summary>
    /// A simple interface to detect face from given image.
    /// </summary>
    /// <param name="image">An image to detect</param>
    /// <param name="faces">Detection results stored in a Mat</param>
    /// <returns>1 if detection is successful, 0 otherwise.</returns>
    public int Detect(Mat image, Mat faces)
    {
        ThrowIfDisposed();
        InputArray iaImage = image;
        OutputArray oaFaces = faces;
        NativeMethods.HandleException(
            NativeMethods.objdetect_FaceDetectorYN_detect(Handle, iaImage.Proxy, oaFaces.Proxy, out var result));
        return result;
    }
}
