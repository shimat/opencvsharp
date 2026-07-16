using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Face;

/// <inheritdoc />
/// <summary>
///
/// </summary>
// ReSharper disable once InconsistentNaming
public sealed class FacemarkAAM : FacemarkTrain
{
    private FacemarkAAM(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.face_Ptr_FacemarkAAM_delete(p)))
    { }

    /// <summary>
    ///
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public static FacemarkAAM Create(Params? parameters = null)
    {
        IntPtr smartPtr;
        if (parameters is null)
        {
            NativeMethods.HandleException(
                NativeMethods.face_FacemarkAAM_create(IntPtr.Zero, out smartPtr));
        }
        else
        {
            var p = parameters.ToNative();
            try
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_create(p, out smartPtr));
            }
            finally
            {
                NativeMethods.HandleException(NativeMethods.face_FacemarkAAM_Params_delete(p));
            }
        }

        if (smartPtr == IntPtr.Zero)
            throw new OpenCvSharpException($"Invalid cv::Ptr<{nameof(FacemarkAAM)}> pointer");
        NativeMethods.HandleException(NativeMethods.face_Ptr_FacemarkAAM_get(smartPtr, out var rawPtr));
        return new FacemarkAAM(smartPtr, rawPtr);
    }

    /// <summary>
    /// Stores algorithm parameters in a file storage.
    /// </summary>
    /// <remarks>
    /// Overrides the generic Algorithm.Write, which passes a cv::Algorithm* to the native side.
    /// cv::face::Facemark inherits Algorithm virtually, so a raw pointer obtained as FacemarkAAM*
    /// cannot be safely reinterpreted as Algorithm* on the managed side; this override calls
    /// write() with the pointer kept at its concrete native type instead.
    /// </remarks>
    /// <param name="fs"></param>
    public override void Write(FileStorage fs)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(fs);
        fs.ThrowIfDisposed();

        NativeMethods.HandleException(NativeMethods.face_FacemarkAAM_write(Handle, fs.CvPtr));
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

        NativeMethods.HandleException(NativeMethods.face_FacemarkAAM_read(Handle, fn.CvPtr));
        GC.KeepAlive(fn);
    }

    /// <summary>
    /// Runtime pose and scale configuration for fitting one face.
    /// </summary>
    public readonly struct Config
    {
        /// <summary>
        /// Creates a configuration with OpenCV's defaults.
        /// </summary>
        public Config()
            : this(null, default, 1.0f, 0)
        {
        }

        /// <summary>
        /// Creates a runtime fitting configuration.
        /// </summary>
        public Config(Mat? rotation, Point2f translation, float scale, int modelScaleIndex)
        {
            Rotation = rotation;
            Translation = translation;
            Scale = scale;
            ModelScaleIndex = modelScaleIndex;
        }

        /// <summary>
        /// Optional 2x2 CV_32F rotation matrix. Null uses the identity matrix.
        /// </summary>
        public Mat? Rotation { get; }

        /// <summary>
        /// Translation applied during fitting.
        /// </summary>
        public Point2f Translation { get; }

        /// <summary>
        /// Scale applied during fitting.
        /// </summary>
        public float Scale { get; }

        /// <summary>
        /// Index of the model scale to use.
        /// </summary>
        public int ModelScaleIndex { get; }
    }

    /// <summary>
    /// Fits landmarks using a per-face runtime configuration.
    /// </summary>
    public bool FitConfig(
        InputArray image,
        InputArray roi,
        IEnumerable<Config> runtimeParameters,
        out Point2f[][] landmarks)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(runtimeParameters);

        var configs = runtimeParameters.ToArray();
        var rotations = new IntPtr[configs.Length];
        var translations = new Point2f[configs.Length];
        var scales = new float[configs.Length];
        var modelScaleIndexes = new int[configs.Length];
        for (var i = 0; i < configs.Length; i++)
        {
            configs[i].Rotation?.ThrowIfDisposed();
            rotations[i] = configs[i].Rotation?.CvPtr ?? IntPtr.Zero;
            translations[i] = configs[i].Translation;
            scales[i] = configs[i].Scale;
            modelScaleIndexes[i] = configs[i].ModelScaleIndex;
        }

        using var landmarkVector = new VectorOfVectorPoint2f();
        NativeMethods.HandleException(
            NativeMethods.face_FacemarkAAM_fitConfig(
                Handle, image.Proxy, roi.Proxy, landmarkVector.CvPtr,
                rotations, translations, scales, modelScaleIndexes, configs.Length, out var result));
        landmarks = landmarkVector.ToArray();
        GC.KeepAlive(image.Source);
        GC.KeepAlive(roi.Source);
        GC.KeepAlive(configs);
        return result != 0;
    }

    /// <summary>
    /// Retrieves the mean shape (s0) of the trained AAM model.
    /// </summary>
    /// <param name="s0">The mean shape points, or an empty array if the model has no data yet.</param>
    /// <returns>true if the model had data to return.</returns>
    public bool GetData(out Point2f[] s0)
    {
        ThrowIfDisposed();
        using var s0Vector = new StdVector<Point2f>();
        NativeMethods.HandleException(
            NativeMethods.face_FacemarkAAM_getData(Handle, s0Vector.CvPtr, out var result));
        s0 = s0Vector.ToArray();
        return result != 0;
    }

#pragma warning disable CA1034
    /// <summary>
    /// Parameters for the FacemarkAAM model.
    /// This is a plain managed value holder; it is materialised into a native
    /// cv::face::FacemarkAAM::Params only at the moment of Create / Read / Write.
    /// </summary>
    public sealed class Params
    {
        /// <summary>
        /// Constructs a parameter set initialised with the OpenCV default values.
        /// </summary>
        public Params()
        {
            NativeMethods.HandleException(
                NativeMethods.face_FacemarkAAM_Params_new(out var p));
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException($"Invalid {nameof(Params)} pointer");
            try
            {
                LoadFrom(p);
            }
            finally
            {
                NativeMethods.HandleException(NativeMethods.face_FacemarkAAM_Params_delete(p));
            }
        }

        /// <summary>
        /// filename of the model
        /// </summary>
        public string ModelFilename { get; set; } = "";

        /// <summary>
        ///
        /// </summary>
        public int M { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int N { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int NIter { get; set; }

        /// <summary>
        /// show the training print-out
        /// </summary>
        public bool Verbose { get; set; }

        /// <summary>
        /// flag to save the trained model or not
        /// </summary>
        public bool SaveModel { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int MaxM { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int MaxN { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int TextureMaxM { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<float> Scales { get; set; } = [];

        /// <summary>
        /// Reads the parameters from a file node.
        /// </summary>
        /// <param name="fn"></param>
        public void Read(FileNode fn)
        {
            ArgumentNullException.ThrowIfNull(fn);
            fn.ThrowIfDisposed();
            var p = ToNative();
            try
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_read(p, fn.CvPtr));
                GC.KeepAlive(fn);
                LoadFrom(p);
            }
            finally
            {
                NativeMethods.HandleException(NativeMethods.face_FacemarkAAM_Params_delete(p));
            }
        }

        /// <summary>
        /// Writes the parameters to a file storage.
        /// </summary>
        /// <param name="fs"></param>
        public void Write(FileStorage fs)
        {
            ArgumentNullException.ThrowIfNull(fs);
            fs.ThrowIfDisposed();
            var p = ToNative();
            try
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_write(p, fs.CvPtr));
                GC.KeepAlive(fs);
            }
            finally
            {
                NativeMethods.HandleException(NativeMethods.face_FacemarkAAM_Params_delete(p));
            }
        }

        /// <summary>
        /// Copies every field of a native Params into this managed instance.
        /// </summary>
        private void LoadFrom(IntPtr nativeParams)
        {
            using var modelFilename = new StdString();
            using var scales = new StdVector<float>();
            NativeMethods.HandleException(
                NativeMethods.face_FacemarkAAM_Params_getAll(
                    nativeParams, out var data, modelFilename.CvPtr, scales.CvPtr));
            M = data.M;
            N = data.N;
            NIter = data.NIter;
            Verbose = data.Verbose != 0;
            SaveModel = data.SaveModel != 0;
            MaxM = data.MaxM;
            MaxN = data.MaxN;
            TextureMaxM = data.TextureMaxM;
            ModelFilename = modelFilename.ToString();
            Scales = scales.ToArray();
        }

        /// <summary>
        /// Builds a native cv::face::FacemarkAAM::Params from this managed instance.
        /// The caller is responsible for deleting the returned pointer.
        /// </summary>
        internal IntPtr ToNative()
        {
            NativeMethods.HandleException(
                NativeMethods.face_FacemarkAAM_Params_new(out var p));
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException($"Invalid {nameof(Params)} pointer");
            try
            {
                var data = new FacemarkAAMParamsData
                {
                    M = M,
                    N = N,
                    NIter = NIter,
                    Verbose = Verbose ? 1 : 0,
                    SaveModel = SaveModel ? 1 : 0,
                    MaxM = MaxM,
                    MaxN = MaxN,
                    TextureMaxM = TextureMaxM,
                };
                using var scales = new StdVector<float>(Scales);
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_setAll(
                        p, data, ModelFilename, scales.CvPtr));
                return p;
            }
            catch
            {
                NativeMethods.HandleException(NativeMethods.face_FacemarkAAM_Params_delete(p));
                throw;
            }
        }
    }
}
