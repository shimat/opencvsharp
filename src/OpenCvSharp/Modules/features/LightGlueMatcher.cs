using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable once InconsistentNaming
/// <summary>
/// LightGlue: a deep learning based descriptor matcher with an attention mechanism (OpenCV 5).
/// Runs an ONNX model through the DNN module. Requires OpenCV built with the dnn module.
/// </summary>
public class LightGlueMatcher : DescriptorMatcher
{
    private LightGlueMatcher(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.features_Ptr_LightGlueMatcher_delete(p)))
    {
    }

    /// <summary>
    /// Creates a LightGlueMatcher from a model file path.
    /// </summary>
    /// <param name="modelPath">Path to the ONNX model file.</param>
    /// <param name="scoreThreshold">Match confidence threshold.</param>
    /// <param name="backend">DNN backend (see <see cref="Dnn.Backend"/>). Default is 0 (DEFAULT).</param>
    /// <param name="target">DNN target (see <see cref="Dnn.Target"/>). Default is 0 (CPU).</param>
    public static LightGlueMatcher Create(string modelPath, float scoreThreshold = 0.0f, int backend = 0, int target = 0)
    {
        if (modelPath is null)
            throw new ArgumentNullException(nameof(modelPath));

        NativeMethods.HandleException(
            NativeMethods.features_LightGlueMatcher_create(modelPath, scoreThreshold, backend, target, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.features_Ptr_LightGlueMatcher_get(smartPtr, out var rawPtr));
        return new LightGlueMatcher(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates a LightGlueMatcher from an in-memory ONNX model buffer.
    /// </summary>
    /// <param name="modelData">Buffer containing the model data.</param>
    /// <param name="scoreThreshold">Match confidence threshold.</param>
    /// <param name="backend">DNN backend (see <see cref="Dnn.Backend"/>). Default is 0 (DEFAULT).</param>
    /// <param name="target">DNN target (see <see cref="Dnn.Target"/>). Default is 0 (CPU).</param>
    public static LightGlueMatcher CreateFromMemory(byte[] modelData, float scoreThreshold = 0.0f, int backend = 0, int target = 0)
    {
        if (modelData is null)
            throw new ArgumentNullException(nameof(modelData));

        NativeMethods.HandleException(
            NativeMethods.features_LightGlueMatcher_create_buffer(
                modelData, new IntPtr(modelData.Length), scoreThreshold, backend, target, out var smartPtr));
        GC.KeepAlive(modelData);
        NativeMethods.HandleException(
            NativeMethods.features_Ptr_LightGlueMatcher_get(smartPtr, out var rawPtr));
        return new LightGlueMatcher(smartPtr, rawPtr);
    }

    /// <summary>
    /// Sets the keypoint and image size context for the next match() call.
    /// Must be called before match()/knnMatch()/radiusMatch() unless using automatic context
    /// from in-process ALIKED instances.
    /// </summary>
    /// <param name="queryKpts">Query image keypoints (Nx2 float matrix with x,y coordinates).</param>
    /// <param name="trainKpts">Train image keypoints (Nx2 float matrix with x,y coordinates).</param>
    /// <param name="queryImageSize">Size of the query image (width, height).</param>
    /// <param name="trainImageSize">Size of the train image (width, height).</param>
    public void SetPairInfo(InputArray queryKpts, InputArray trainKpts, Size queryImageSize = default, Size trainImageSize = default)
    {
        ThrowIfDisposed();
        if (queryKpts is null)
            throw new ArgumentNullException(nameof(queryKpts));
        if (trainKpts is null)
            throw new ArgumentNullException(nameof(trainKpts));
        queryKpts.ThrowIfDisposed();
        trainKpts.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.features_LightGlueMatcher_setPairInfo(RawPtr, queryKpts.CvPtr, trainKpts.CvPtr, queryImageSize, trainImageSize));
        GC.KeepAlive(this);
        GC.KeepAlive(queryKpts);
        GC.KeepAlive(trainKpts);
    }

    /// <summary>
    /// Clears stored pair context information.
    /// </summary>
    public void ClearPairInfo()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.features_LightGlueMatcher_clearPairInfo(RawPtr));
        GC.KeepAlive(this);
    }
}
