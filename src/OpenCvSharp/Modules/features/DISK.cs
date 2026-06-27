using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable once InconsistentNaming
/// <summary>
/// DISK: deep learning based local feature detector and descriptor (OpenCV 5).
/// Runs an ONNX model through the DNN module. Requires OpenCV built with the dnn module.
/// </summary>
public class DISK : Feature2D
{
    /// <summary>
    /// Creates instance by raw pointer cv::DISK*
    /// </summary>
    private DISK(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.features_Ptr_DISK_delete(p)))
    {
    }

    /// <summary>
    /// Creates a DISK detector from a model file path.
    /// </summary>
    /// <param name="modelPath">Path to the DISK ONNX model.</param>
    /// <param name="maxKeypoints">Maximum number of keypoints to return per image; -1 keeps all detections.</param>
    /// <param name="scoreThreshold">Discard keypoints with network score strictly below this value.</param>
    /// <param name="imageSize">Target input size fed to the network. Default (empty) falls back to the network's
    /// fixed 1024x1024 input. When overriding, both dimensions must be positive multiples of 16.</param>
    /// <param name="backendId">DNN backend identifier (see <see cref="Dnn.Backend"/>); 0 = default.</param>
    /// <param name="targetId">DNN target identifier (see <see cref="Dnn.Target"/>); 0 = CPU.</param>
    public static DISK Create(
        string modelPath, int maxKeypoints = -1, float scoreThreshold = 0.0f,
        Size imageSize = default, int backendId = 0, int targetId = 0)
    {
        if (modelPath is null)
            throw new ArgumentNullException(nameof(modelPath));

        NativeMethods.HandleException(
            NativeMethods.features_DISK_create(modelPath, maxKeypoints, scoreThreshold, imageSize, backendId, targetId, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.features_Ptr_Feature2D_get(smartPtr, out var rawPtr));
        return new DISK(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates a DISK detector from an in-memory ONNX model buffer.
    /// </summary>
    /// <param name="bufferModel">A buffer containing the contents of the DISK ONNX model.</param>
    /// <param name="maxKeypoints">Maximum number of keypoints to return per image; -1 keeps all detections.</param>
    /// <param name="scoreThreshold">Discard keypoints with network score strictly below this value.</param>
    /// <param name="imageSize">Target input size fed to the network. Default (empty) falls back to the network's
    /// fixed 1024x1024 input. When overriding, both dimensions must be positive multiples of 16.</param>
    /// <param name="backendId">DNN backend identifier (see <see cref="Dnn.Backend"/>); 0 = default.</param>
    /// <param name="targetId">DNN target identifier (see <see cref="Dnn.Target"/>); 0 = CPU.</param>
    public static DISK CreateFromMemory(
        byte[] bufferModel, int maxKeypoints = -1, float scoreThreshold = 0.0f,
        Size imageSize = default, int backendId = 0, int targetId = 0)
    {
        if (bufferModel is null)
            throw new ArgumentNullException(nameof(bufferModel));

        NativeMethods.HandleException(
            NativeMethods.features_DISK_create_buffer(
                bufferModel, new IntPtr(bufferModel.Length), maxKeypoints, scoreThreshold, imageSize, backendId, targetId, out var smartPtr));
        GC.KeepAlive(bufferModel);
        NativeMethods.HandleException(
            NativeMethods.features_Ptr_Feature2D_get(smartPtr, out var rawPtr));
        return new DISK(smartPtr, rawPtr);
    }

    /// <summary>
    /// Maximum number of keypoints to return per image; -1 keeps all detections.
    /// </summary>
    public int MaxKeypoints
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.features_DISK_getMaxKeypoints(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.features_DISK_setMaxKeypoints(Handle, value));
        }
    }

    /// <summary>
    /// Keypoints with network score strictly below this value are discarded.
    /// </summary>
    public float ScoreThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.features_DISK_getScoreThreshold(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.features_DISK_setScoreThreshold(Handle, value));
        }
    }

    /// <summary>
    /// Target input size fed to the network.
    /// </summary>
    public Size ImageSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.features_DISK_getImageSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.features_DISK_setImageSize(Handle, value));
        }
    }
}
