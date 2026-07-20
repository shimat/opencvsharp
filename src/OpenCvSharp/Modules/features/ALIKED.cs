using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;

namespace OpenCvSharp;

// ReSharper disable once InconsistentNaming
/// <summary>
/// ALIKED: deep learning based local feature detector and descriptor (OpenCV 5).
/// Runs an ONNX model through the DNN module. Requires OpenCV built with the dnn module.
/// </summary>
public class ALIKED : Feature2D
{
    /// <summary>
    /// Creates instance by raw pointer cv::ALIKED*
    /// </summary>
    private ALIKED(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.features_Ptr_ALIKED_delete(p)))
    {
    }

    /// <summary>
    /// Creates ALIKED from a model file path.
    /// On Windows, a non-ASCII path is read into memory and passed through <see cref="CreateFromMemory"/>
    /// instead, since the native path overload is marshaled through the ANSI code page.
    /// </summary>
    /// <param name="modelPath">Path to the ONNX model file.</param>
    /// <param name="inputSize">Input image size for the network. Default is 640x640.</param>
    /// <param name="normalizeDescriptors">Whether to L2-normalize descriptors. Default is true.</param>
    /// <param name="engine">DNN engine type (cv::dnn::EngineType). Default is 2 (ENGINE_NEW).</param>
    /// <param name="backend">DNN backend (see <see cref="Dnn.Backend"/>). Default is 0 (DEFAULT).</param>
    /// <param name="target">DNN target (see <see cref="Dnn.Target"/>). Default is 0 (CPU).</param>
    public static ALIKED Create(
        string modelPath, Size? inputSize = null, bool normalizeDescriptors = true,
        int engine = 2, int backend = 0, int target = 0)
    {
        ArgumentNullException.ThrowIfNull(modelPath);
        var size = inputSize ?? new Size(640, 640);

        if (ModelPathUtil.RequiresBufferFallback(modelPath))
        {
            return CreateFromMemory(File.ReadAllBytes(modelPath), size, normalizeDescriptors, engine, backend, target);
        }

        NativeMethods.HandleException(
            NativeMethods.features_ALIKED_create(
                modelPath, size, normalizeDescriptors ? 1 : 0, engine, backend, target, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.features_Ptr_Feature2D_get(smartPtr, out var rawPtr));
        return new ALIKED(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates ALIKED from an in-memory ONNX model buffer.
    /// </summary>
    /// <param name="modelData">Buffer containing the model data.</param>
    /// <param name="inputSize">Input image size for the network. Default is 640x640.</param>
    /// <param name="normalizeDescriptors">Whether to L2-normalize descriptors. Default is true.</param>
    /// <param name="engine">DNN engine type (cv::dnn::EngineType). Default is 2 (ENGINE_NEW).</param>
    /// <param name="backend">DNN backend (see <see cref="Dnn.Backend"/>). Default is 0 (DEFAULT).</param>
    /// <param name="target">DNN target (see <see cref="Dnn.Target"/>). Default is 0 (CPU).</param>
    public static ALIKED CreateFromMemory(
        byte[] modelData, Size? inputSize = null, bool normalizeDescriptors = true,
        int engine = 2, int backend = 0, int target = 0)
    {
        ArgumentNullException.ThrowIfNull(modelData);
        var size = inputSize ?? new Size(640, 640);

        NativeMethods.HandleException(
            NativeMethods.features_ALIKED_create_buffer(
                modelData, new IntPtr(modelData.Length), size, normalizeDescriptors ? 1 : 0, engine, backend, target, out var smartPtr));
        GC.KeepAlive(modelData);
        NativeMethods.HandleException(
            NativeMethods.features_Ptr_Feature2D_get(smartPtr, out var rawPtr));
        return new ALIKED(smartPtr, rawPtr);
    }
}
