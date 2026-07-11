using OpenCvSharp.Dnn;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

/// <summary>
/// Definition of distance used for calculating the distance between two face features (cv::FaceRecognizerSF::DisType).
/// </summary>
public enum FaceRecognizerSFDisType
{
    /// <summary>
    /// FR_COSINE
    /// </summary>
    Cosine = 0,

    /// <summary>
    /// FR_NORM_L2
    /// </summary>
    NormL2 = 1,
}

/// <summary>
/// DNN-based face recognizer
/// </summary>
public class FaceRecognizerSF : Algorithm
{
    /// <summary>
    /// Creates instance by cv::Ptr&lt;cv::FaceRecognizerSF&gt;* and cv::FaceRecognizerSF*
    /// </summary>
    private FaceRecognizerSF(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(
            NativeMethods.objdetect_Ptr_FaceRecognizerSF_delete(p)))
    { }

    /// <summary>
    /// Creates an instance of this class with given parameters.
    /// </summary>
    /// <param name="model">the path of the onnx model used for face recognition</param>
    /// <param name="config">the path to the config file for compatibility, which is not requested for ONNX models</param>
    /// <param name="backendId">the id of backend</param>
    /// <param name="targetId">the id of target device</param>
    public static FaceRecognizerSF Create(
        string model,
        string config,
        Backend backendId = Backend.DEFAULT,
        Target targetId = Target.CPU)
    {
        using StdString csModel = new(model);
        using StdString csConfig = new(config);

        NativeMethods.HandleException(
            NativeMethods.objdetect_FaceRecognizerSF_create(
                csModel.CvPtr,
                csConfig.CvPtr,
                (int)backendId,
                (int)targetId,
                out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.objdetect_Ptr_FaceRecognizerSF_get(smartPtr, out var rawPtr));
        return new FaceRecognizerSF(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates an instance of this class from a buffer containing the model weights and configuration.
    /// </summary>
    /// <param name="framework">Name of the framework (ONNX, etc.)</param>
    /// <param name="bufferModel">A buffer containing the binary model weights.</param>
    /// <param name="bufferConfig">A buffer containing the network configuration.</param>
    /// <param name="backendId">the id of backend</param>
    /// <param name="targetId">the id of target device</param>
    public static FaceRecognizerSF Create(
        string framework,
        byte[] bufferModel,
        byte[] bufferConfig,
        Backend backendId = Backend.DEFAULT,
        Target targetId = Target.CPU)
    {
        ArgumentNullException.ThrowIfNull(bufferModel);
        ArgumentNullException.ThrowIfNull(bufferConfig);

        using StdString csFramework = new(framework);
        using var bufferModelVec = new StdVector<byte>(bufferModel);
        using var bufferConfigVec = new StdVector<byte>(bufferConfig);

        NativeMethods.HandleException(
            NativeMethods.objdetect_FaceRecognizerSF_create_buffer(
                csFramework.CvPtr,
                bufferModelVec.CvPtr,
                bufferConfigVec.CvPtr,
                (int)backendId,
                (int)targetId,
                out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.objdetect_Ptr_FaceRecognizerSF_get(smartPtr, out var rawPtr));
        return new FaceRecognizerSF(smartPtr, rawPtr);
    }

    /// <summary>
    /// Aligns detected face with the source input image and crops it.
    /// </summary>
    /// <param name="srcImg">input image</param>
    /// <param name="faceBox">the detected face result from the input image</param>
    /// <param name="alignedImg">output aligned image</param>
    public void AlignCrop(InputArray srcImg, InputArray faceBox, OutputArray alignedImg)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.objdetect_FaceRecognizerSF_alignCrop(Handle, srcImg.Proxy, faceBox.Proxy, alignedImg.Proxy));

        GC.KeepAlive(srcImg.Source);
        GC.KeepAlive(faceBox.Source);
        GC.KeepAlive(alignedImg.Source);
    }

    /// <summary>
    /// Extracts face feature from aligned image.
    /// </summary>
    /// <param name="alignedImg">input aligned image</param>
    /// <param name="faceFeature">output face feature</param>
    public void Feature(InputArray alignedImg, OutputArray faceFeature)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.objdetect_FaceRecognizerSF_feature(Handle, alignedImg.Proxy, faceFeature.Proxy));

        GC.KeepAlive(alignedImg.Source);
        GC.KeepAlive(faceFeature.Source);
    }

    /// <summary>
    /// Calculates the distance between two face features.
    /// </summary>
    /// <param name="faceFeature1">the first input feature</param>
    /// <param name="faceFeature2">the second input feature of the same size and the same type as faceFeature1</param>
    /// <param name="disType">defines how to calculate the distance between two face features</param>
    public double Match(InputArray faceFeature1, InputArray faceFeature2, FaceRecognizerSFDisType disType = FaceRecognizerSFDisType.Cosine)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.objdetect_FaceRecognizerSF_match(Handle, faceFeature1.Proxy, faceFeature2.Proxy, (int)disType, out var ret));

        GC.KeepAlive(faceFeature1.Source);
        GC.KeepAlive(faceFeature2.Source);

        return ret;
    }
}
