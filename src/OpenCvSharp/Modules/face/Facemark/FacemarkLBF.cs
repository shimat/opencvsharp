using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Face;

/// <inheritdoc />
/// <summary>
///
/// </summary>
// ReSharper disable once InconsistentNaming
public sealed class FacemarkLBF : Facemark
{
    private FacemarkLBF(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.face_Ptr_FacemarkLBF_delete(p)))
    { }

    /// <summary>
    ///
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public static FacemarkLBF Create(Params? parameters = null)
    {
        IntPtr smartPtr;
        if (parameters is null)
        {
            NativeMethods.HandleException(
                NativeMethods.face_FacemarkLBF_create(IntPtr.Zero, out smartPtr));
        }
        else
        {
            var p = parameters.ToNative();
            try
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_create(p, out smartPtr));
            }
            finally
            {
                NativeMethods.HandleException(NativeMethods.face_FacemarkLBF_Params_delete(p));
            }
        }

        if (smartPtr == IntPtr.Zero)
            throw new OpenCvSharpException($"Invalid cv::Ptr<{nameof(FacemarkLBF)}> pointer");
        NativeMethods.HandleException(NativeMethods.face_Ptr_FacemarkLBF_get(smartPtr, out var rawPtr));
        return new FacemarkLBF(smartPtr, rawPtr);
    }

#pragma warning disable CA1034
    /// <summary>
    /// Parameters for the FacemarkLBF model.
    /// This is a plain managed value holder; it is materialised into a native
    /// cv::face::FacemarkLBF::Params only at the moment of Create / Read / Write.
    /// </summary>
    public sealed class Params
    {
        /// <summary>
        /// Constructs a parameter set initialised with the OpenCV default values.
        /// </summary>
        public Params()
        {
            NativeMethods.HandleException(
                NativeMethods.face_FacemarkLBF_Params_new(out var p));
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException($"Invalid {nameof(Params)} pointer");
            try
            {
                LoadFrom(p);
            }
            finally
            {
                NativeMethods.HandleException(NativeMethods.face_FacemarkLBF_Params_delete(p));
            }
        }

        /// <summary>
        /// offset for the loaded face landmark points
        /// </summary>
        public double ShapeOffset { get; set; }

        /// <summary>
        /// filename of the face detector model
        /// </summary>
        public string CascadeFace { get; set; } = "";

        /// <summary>
        /// show the training print-out
        /// </summary>
        public bool Verbose { get; set; }

        /// <summary>
        /// number of landmark points
        /// </summary>
        public int NLandmarks { get; set; }

        /// <summary>
        /// multiplier for augment the training data
        /// </summary>
        public int InitShapeN { get; set; }

        /// <summary>
        /// number of refinement stages
        /// </summary>
        public int StagesN { get; set; }

        /// <summary>
        /// number of tree in the model for each landmark point refinement
        /// </summary>
        public int TreeN { get; set; }

        /// <summary>
        /// the depth of decision tree, defines the size of feature
        /// </summary>
        public int TreeDepth { get; set; }

        /// <summary>
        /// overlap ratio for training the LBF feature
        /// </summary>
        public double BaggingOverlap { get; set; }

        /// <summary>
        /// filename where the trained model will be saved
        /// </summary>
        public string ModelFilename { get; set; } = "";

        /// <summary>
        /// flag to save the trained model or not
        /// </summary>
        public bool SaveModel { get; set; }

        /// <summary>
        /// seed for shuffling the training data
        /// </summary>
        public uint Seed { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<int> FeatsM { get; set; } = [];

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<double> RadiusM { get; set; } = [];

        /// <summary>
        /// index of facemark points on pupils of left and right eye
        /// </summary>
        public IReadOnlyList<int> Pupils0 { get; set; } = [];

        /// <summary>
        /// index of facemark points on pupils of left and right eye
        /// </summary>
        public IReadOnlyList<int> Pupils1 { get; set; } = [];

        /// <summary>
        ///
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public Rect DetectROI { get; set; }

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
                    NativeMethods.face_FacemarkLBF_Params_read(p, fn.CvPtr));
                GC.KeepAlive(fn);
                LoadFrom(p);
            }
            finally
            {
                NativeMethods.HandleException(NativeMethods.face_FacemarkLBF_Params_delete(p));
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
                    NativeMethods.face_FacemarkLBF_Params_write(p, fs.CvPtr));
                GC.KeepAlive(fs);
            }
            finally
            {
                NativeMethods.HandleException(NativeMethods.face_FacemarkLBF_Params_delete(p));
            }
        }

        /// <summary>
        /// Copies every field of a native Params into this managed instance.
        /// </summary>
        private void LoadFrom(IntPtr nativeParams)
        {
            using var cascadeFace = new StdString();
            using var modelFilename = new StdString();
            using var featsM = new StdVector<int>();
            using var radiusM = new StdVector<double>();
            using var pupils0 = new StdVector<int>();
            using var pupils1 = new StdVector<int>();
            NativeMethods.HandleException(
                NativeMethods.face_FacemarkLBF_Params_getAll(
                    nativeParams, out var data, cascadeFace.CvPtr, modelFilename.CvPtr,
                    featsM.CvPtr, radiusM.CvPtr, pupils0.CvPtr, pupils1.CvPtr));
            ShapeOffset = data.ShapeOffset;
            Verbose = data.Verbose != 0;
            NLandmarks = data.NLandmarks;
            InitShapeN = data.InitShapeN;
            StagesN = data.StagesN;
            TreeN = data.TreeN;
            TreeDepth = data.TreeDepth;
            BaggingOverlap = data.BaggingOverlap;
            SaveModel = data.SaveModel != 0;
            Seed = data.Seed;
            DetectROI = data.DetectROI;
            CascadeFace = cascadeFace.ToString();
            ModelFilename = modelFilename.ToString();
            FeatsM = featsM.ToArray();
            RadiusM = radiusM.ToArray();
            Pupils0 = pupils0.ToArray();
            Pupils1 = pupils1.ToArray();
        }

        /// <summary>
        /// Builds a native cv::face::FacemarkLBF::Params from this managed instance.
        /// The caller is responsible for deleting the returned pointer.
        /// </summary>
        internal IntPtr ToNative()
        {
            NativeMethods.HandleException(
                NativeMethods.face_FacemarkLBF_Params_new(out var p));
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException($"Invalid {nameof(Params)} pointer");
            try
            {
                var data = new FacemarkLBFParamsData
                {
                    ShapeOffset = ShapeOffset,
                    Verbose = Verbose ? 1 : 0,
                    NLandmarks = NLandmarks,
                    InitShapeN = InitShapeN,
                    StagesN = StagesN,
                    TreeN = TreeN,
                    TreeDepth = TreeDepth,
                    BaggingOverlap = BaggingOverlap,
                    SaveModel = SaveModel ? 1 : 0,
                    Seed = Seed,
                    DetectROI = DetectROI,
                };
                using var featsM = new StdVector<int>(FeatsM);
                using var radiusM = new StdVector<double>(RadiusM);
                using var pupils0 = new StdVector<int>(Pupils0);
                using var pupils1 = new StdVector<int>(Pupils1);
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_setAll(
                        p, data, CascadeFace, ModelFilename,
                        featsM.CvPtr, radiusM.CvPtr, pupils0.CvPtr, pupils1.CvPtr));
                return p;
            }
            catch
            {
                NativeMethods.HandleException(NativeMethods.face_FacemarkLBF_Params_delete(p));
                throw;
            }
        }
    }
}
