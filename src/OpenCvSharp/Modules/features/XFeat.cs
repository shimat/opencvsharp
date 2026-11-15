using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;

namespace OpenCvSharp;

/// <summary>ONNX-based feature detector and extractor of 64-dimensional descriptors.</summary>
/// <remarks>Requires an OpenCV build with the DNN module.</remarks>
public class XFeat : Feature2D
{
    private XFeat(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.features_Ptr_XFeat_delete(p)))
    {
    }

    /// <summary>Loads an XFeat ONNX model from a file.</summary>
    /// <param name="modelPath">Path to the ONNX model.</param>
    /// <param name="maxKeypoints">Maximum number of keypoints, or -1 for all detections.</param>
    /// <param name="scoreThreshold">Minimum score that a keypoint must exceed.</param>
    /// <param name="inputSize">Network input size. Defaults to 640 by 640.</param>
    /// <param name="backend">DNN backend ID.</param>
    /// <param name="target">DNN target ID.</param>
    /// <returns>The detector.</returns>
    public static XFeat Create(string modelPath, int maxKeypoints = -1, float scoreThreshold = 0.5f,
        Size? inputSize = null, int backend = 0, int target = 0)
    {
        ArgumentNullException.ThrowIfNull(modelPath);
        if (ModelPathUtil.RequiresBufferFallback(modelPath))
            return CreateFromMemory(File.ReadAllBytes(modelPath), maxKeypoints, scoreThreshold, inputSize, backend, target);

        NativeMethods.HandleException(NativeMethods.features_XFeat_create(
            modelPath, maxKeypoints, scoreThreshold, inputSize ?? new Size(640, 640), backend, target, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.features_Ptr_XFeat_get(smartPtr, out var rawPtr));
        return new XFeat(smartPtr, rawPtr);
    }

    /// <summary>Loads an XFeat ONNX model from memory.</summary>
    /// <param name="modelData">Buffer containing the ONNX model.</param>
    /// <param name="maxKeypoints">Maximum number of keypoints, or -1 for all detections.</param>
    /// <param name="scoreThreshold">Minimum score that a keypoint must exceed.</param>
    /// <param name="inputSize">Network input size. Defaults to 640 by 640.</param>
    /// <param name="backend">DNN backend ID.</param>
    /// <param name="target">DNN target ID.</param>
    /// <returns>The detector.</returns>
    public static XFeat CreateFromMemory(ReadOnlySpan<byte> modelData, int maxKeypoints = -1, float scoreThreshold = 0.5f,
        Size? inputSize = null, int backend = 0, int target = 0)
    {
        ArgumentOutOfRangeException.ThrowIfZero(modelData.Length, nameof(modelData));
        NativeMethods.HandleException(NativeMethods.features_XFeat_create_buffer(
            modelData, (nuint)modelData.Length, maxKeypoints, scoreThreshold, inputSize ?? new Size(640, 640),
            backend, target, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.features_Ptr_XFeat_get(smartPtr, out var rawPtr));
        return new XFeat(smartPtr, rawPtr);
    }

    /// <summary>Maximum number of keypoints. Use -1 to keep all detections.</summary>
    public int MaxKeypoints
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.features_XFeat_getMaxKeypoints(Handle, out var value));
            return value;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.features_XFeat_setMaxKeypoints(Handle, value));
        }
    }

    /// <summary>Minimum score that a keypoint must exceed.</summary>
    public float ScoreThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.features_XFeat_getScoreThreshold(Handle, out var value));
            return value;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.features_XFeat_setScoreThreshold(Handle, value));
        }
    }

    /// <summary>Image size used as input to the network.</summary>
    public Size InputSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.features_XFeat_getInputSize(Handle, out var value));
            return value;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.features_XFeat_setInputSize(Handle, value));
        }
    }
}
