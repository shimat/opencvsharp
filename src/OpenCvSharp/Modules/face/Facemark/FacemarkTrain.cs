using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Face;

/// <summary>
/// Base class for trainable facemark models.
/// </summary>
public abstract class FacemarkTrain : Facemark
{
    private FacemarkFaceDetectorBridge? faceDetectorBridge;
    /// <summary>
    /// Initializes a trainable facemark wrapper.
    /// </summary>
    protected FacemarkTrain(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release)
    {
    }

    /// <summary>
    /// Adds one training image and its landmark points.
    /// </summary>
    public bool AddTrainingSample(InputArray image, InputArray landmarks)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_FacemarkTrain_addTrainingSample(
                Handle, image.Proxy, landmarks.Proxy, out var result));
        GC.KeepAlive(image.Source);
        GC.KeepAlive(landmarks.Source);
        return result != 0;
    }

    /// <summary>
    /// Trains the model from samples previously added with <see cref="AddTrainingSample"/>.
    /// </summary>
    public void Training()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.face_FacemarkTrain_training(Handle));
    }

    /// <summary>
    /// Detects faces using the detector configured by the algorithm.
    /// </summary>
    public bool GetFaces(InputArray image, out Rect[] faces)
    {
        ThrowIfDisposed();
        using var faceVector = new StdVector<Rect>();
        NativeMethods.HandleException(
            NativeMethods.face_FacemarkTrain_getFaces(
                Handle, image.Proxy, faceVector.CvPtr, out var result));
        faces = faceVector.ToArray();
        GC.KeepAlive(image.Source);
        return result != 0;
    }

    /// <summary>
    /// Retrieves algorithm-specific data into a native structure.
    /// </summary>
    public bool GetData(IntPtr items)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_FacemarkTrain_getData(Handle, items, out var result));
        return result != 0;
    }

    /// <summary>
    /// Installs a managed face detector used by the facemark algorithm.
    /// </summary>
    public void SetFaceDetector(FacemarkFaceDetector detector)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(detector);
        var newBridge = new FacemarkFaceDetectorBridge(
            Handle, detector, NativeMethods.face_FacemarkTrain_setFaceDetector);
        faceDetectorBridge?.Dispose();
        faceDetectorBridge = newBridge;
    }

    /// <inheritdoc />
    protected override void DisposeManaged()
    {
        faceDetectorBridge?.Dispose();
        faceDetectorBridge = null;
        base.DisposeManaged();
    }
}
