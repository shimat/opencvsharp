using OpenCvSharp.Dnn;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// DNN-based face detector
/// </summary>
public class FaceDetectorYN : DisposableCvObject
{
    /// <summary>
    /// A pointer to the shared pointer to the unmanaged object
    /// </summary>
    private IntPtr _sharedPtr;

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
    public FaceDetectorYN(
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

        ptr = NativeMethods.cveFaceDetectorYNCreate(
            csModel.CvPtr,
            csConfig.CvPtr,
            ref inputSize,
            scoreThreshold,
            nmsThreshold,
            topK,
            backendId,
            targetId,
            ref _sharedPtr
        );
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
        using InputArray iaImage = new(image);
        using OutputArray oaFaces = new(faces);
        int result = NativeMethods.cveFaceDetectorYNDetect(ptr, iaImage.CvPtr, oaFaces.CvPtr);
        GC.KeepAlive(this);
        return result;
    }

    /// <summary>
    /// Release the unmanaged memory associated with this FaceDetectorYN
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        if (!IntPtr.Zero.Equals(_sharedPtr))
        {
            NativeMethods.cveFaceDetectorYNRelease(ref _sharedPtr);
            _sharedPtr = IntPtr.Zero;
        }

        base.DisposeUnmanaged();
    }
}
