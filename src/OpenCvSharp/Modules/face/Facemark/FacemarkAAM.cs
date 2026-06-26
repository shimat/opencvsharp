using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Face;

/// <inheritdoc />
/// <summary>
///
/// </summary>
// ReSharper disable once InconsistentNaming
public sealed class FacemarkAAM : Facemark
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
            if (fn is null)
                throw new ArgumentNullException(nameof(fn));
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
            if (fs is null)
                throw new ArgumentNullException(nameof(fs));
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
