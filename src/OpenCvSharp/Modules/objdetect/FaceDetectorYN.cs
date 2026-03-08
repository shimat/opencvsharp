using OpenCvSharp.Dnn;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// DNN-based face detector
/// </summary>
public class FaceDetectorYN : DisposableCvObject
{
    private Ptr? detectorPtr;

    /// <summary>
    /// Creates instance by raw pointer cv::FaceDetectorYN*
    /// </summary>
    protected FaceDetectorYN(IntPtr p)
    {
        detectorPtr = new Ptr(p);
        ptr = detectorPtr.Get();
    }

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
                out var p));

        return new FaceDetectorYN(p);
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
        NativeMethods.HandleException(
            NativeMethods.objdetect_FaceDetectorYN_detect(ptr, iaImage.CvPtr, oaFaces.CvPtr, out var result));
        GC.KeepAlive(this);
        return result;
    }

    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        detectorPtr?.Dispose();
        detectorPtr = null;
        base.DisposeManaged();
    }

    internal sealed class Ptr(IntPtr ptr) : OpenCvSharp.Ptr(ptr)
    {
        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.objdetect_Ptr_FaceDetectorYN_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.objdetect_Ptr_FaceDetectorYN_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
