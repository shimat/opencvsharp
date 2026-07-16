using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Face;

/// <summary>
/// Ensemble-of-regression-trees facemark implementation.
/// </summary>
public sealed class FacemarkKazemi : Facemark
{
    private FacemarkFaceDetectorBridge? faceDetectorBridge;
    private FacemarkKazemi(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p =>
            NativeMethods.HandleException(NativeMethods.face_Ptr_FacemarkKazemi_delete(p)))
    {
    }

    /// <summary>
    /// Creates a FacemarkKazemi model.
    /// </summary>
    public static FacemarkKazemi Create(Params? parameters = null)
    {
        var nativeParams = parameters?.ToNative() ?? IntPtr.Zero;
        try
        {
            NativeMethods.HandleException(
                NativeMethods.face_FacemarkKazemi_create(nativeParams, out var smartPtr));
            NativeMethods.HandleException(
                NativeMethods.face_Ptr_FacemarkKazemi_get(smartPtr, out var rawPtr));
            return new FacemarkKazemi(smartPtr, rawPtr);
        }
        finally
        {
            if (nativeParams != IntPtr.Zero)
                NativeMethods.HandleException(NativeMethods.face_FacemarkKazemi_Params_delete(nativeParams));
        }
    }

    /// <summary>
    /// Trains and writes a Kazemi model.
    /// </summary>
    public bool Training(
        IEnumerable<Mat> images,
        Point2f[][] landmarks,
        string configFile,
        Size scale,
        string modelFilename = "face_landmarks.dat")
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(images);
        ArgumentNullException.ThrowIfNull(landmarks);
        ArgumentNullException.ThrowIfNull(configFile);
        ArgumentNullException.ThrowIfNull(modelFilename);
        var imageArray = images.ToArray();
        if (imageArray.Length != landmarks.Length)
            throw new ArgumentException("Images and landmarks must have the same length.", nameof(landmarks));
        foreach (var image in imageArray)
        {
            ArgumentNullException.ThrowIfNull(image);
            image.ThrowIfDisposed();
        }

        using var landmarkPointers = new ArrayAddress2<Point2f>(landmarks);
        NativeMethods.HandleException(
            NativeMethods.face_FacemarkKazemi_training(
                Handle, imageArray.Select(x => x.CvPtr).ToArray(), imageArray.Length,
                landmarkPointers.GetPointer(), landmarkPointers.GetDim2Lengths(), landmarks.Length,
                configFile, scale, modelFilename, out var result));
        GC.KeepAlive(imageArray);
        return result != 0;
    }

    /// <summary>
    /// Detects faces with the configured detector.
    /// </summary>
    public bool GetFaces(InputArray image, out Rect[] faces)
    {
        ThrowIfDisposed();
        using var faceVector = new StdVector<Rect>();
        NativeMethods.HandleException(
            NativeMethods.face_FacemarkKazemi_getFaces(
                Handle, image.Proxy, faceVector.CvPtr, out var result));
        faces = faceVector.ToArray();
        GC.KeepAlive(image.Source);
        return result != 0;
    }

    /// <summary>
    /// Installs a managed face detector used by the model.
    /// </summary>
    public void SetFaceDetector(FacemarkFaceDetector detector)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(detector);
        var newBridge = new FacemarkFaceDetectorBridge(
            Handle, detector, NativeMethods.face_FacemarkKazemi_setFaceDetector);
        faceDetectorBridge?.Dispose();
        faceDetectorBridge = newBridge;
    }

    /// <summary>
    /// Stores algorithm parameters in a file storage.
    /// </summary>
    /// <remarks>
    /// Overrides the generic Algorithm.Write, which passes a cv::Algorithm* to the native side.
    /// cv::face::Facemark inherits Algorithm virtually, so a raw pointer obtained as FacemarkKazemi*
    /// cannot be safely reinterpreted as Algorithm* on the managed side; this override calls
    /// write() with the pointer kept at its concrete native type instead.
    /// </remarks>
    /// <param name="fs"></param>
    public override void Write(FileStorage fs)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(fs);
        fs.ThrowIfDisposed();

        NativeMethods.HandleException(NativeMethods.face_FacemarkKazemi_write(Handle, fs.CvPtr));
        GC.KeepAlive(fs);
    }

    /// <summary>
    /// Reads algorithm parameters from a file storage.
    /// </summary>
    /// <remarks>
    /// See the remarks on <see cref="Write"/> for why this override is needed.
    /// </remarks>
    /// <param name="fn"></param>
    public override void Read(FileNode fn)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(fn);
        fn.ThrowIfDisposed();

        NativeMethods.HandleException(NativeMethods.face_FacemarkKazemi_read(Handle, fn.CvPtr));
        GC.KeepAlive(fn);
    }

    /// <inheritdoc />
    protected override void DisposeManaged()
    {
        faceDetectorBridge?.Dispose();
        faceDetectorBridge = null;
        base.DisposeManaged();
    }

#pragma warning disable CA1034
    /// <summary>
    /// Parameters controlling Kazemi model training.
    /// </summary>
    public sealed class Params
    {
        /// <summary>Creates a parameter set initialized with OpenCV defaults.</summary>
        public Params()
        {
            NativeMethods.HandleException(NativeMethods.face_FacemarkKazemi_Params_new(out var native));
            try
            {
                LoadFrom(native);
            }
            finally
            {
                NativeMethods.HandleException(NativeMethods.face_FacemarkKazemi_Params_delete(native));
            }
        }

        /// <summary>Gets or sets the cascade depth used for training.</summary>
        public ulong CascadeDepth { get; set; }
        /// <summary>Gets or sets the maximum regression-tree depth.</summary>
        public ulong TreeDepth { get; set; }
        /// <summary>Gets or sets the number of trees per cascade level.</summary>
        public ulong NumTreesPerCascadeLevel { get; set; }
        /// <summary>Gets or sets the gradient-boosting learning rate.</summary>
        public float LearningRate { get; set; }
        /// <summary>Gets or sets the number of initializations per training sample.</summary>
        public ulong OversamplingAmount { get; set; }
        /// <summary>Gets or sets the number of candidate test coordinates.</summary>
        public ulong NumTestCoordinates { get; set; }
        /// <summary>Gets or sets the coordinate-closeness probability parameter.</summary>
        public float Lambda { get; set; }
        /// <summary>Gets or sets the number of random test splits.</summary>
        public ulong NumTestSplits { get; set; }
        /// <summary>Gets or sets the training configuration filename.</summary>
        public string ConfigFile { get; set; } = "";

        private void LoadFrom(IntPtr native)
        {
            using var configFile = new StdString();
            NativeMethods.HandleException(
                NativeMethods.face_FacemarkKazemi_Params_getAll(native, out var data, configFile.CvPtr));
            CascadeDepth = data.CascadeDepth;
            TreeDepth = data.TreeDepth;
            NumTreesPerCascadeLevel = data.NumTreesPerCascadeLevel;
            LearningRate = data.LearningRate;
            OversamplingAmount = data.OversamplingAmount;
            NumTestCoordinates = data.NumTestCoordinates;
            Lambda = data.Lambda;
            NumTestSplits = data.NumTestSplits;
            ConfigFile = configFile.ToString();
        }

        internal IntPtr ToNative()
        {
            NativeMethods.HandleException(NativeMethods.face_FacemarkKazemi_Params_new(out var native));
            try
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkKazemi_Params_setAll(native, new FacemarkKazemiParamsData
                    {
                        CascadeDepth = CascadeDepth,
                        TreeDepth = TreeDepth,
                        NumTreesPerCascadeLevel = NumTreesPerCascadeLevel,
                        LearningRate = LearningRate,
                        OversamplingAmount = OversamplingAmount,
                        NumTestCoordinates = NumTestCoordinates,
                        Lambda = Lambda,
                        NumTestSplits = NumTestSplits,
                    }, ConfigFile));
                return native;
            }
            catch
            {
                NativeMethods.HandleException(NativeMethods.face_FacemarkKazemi_Params_delete(native));
                throw;
            }
        }
    }
}
