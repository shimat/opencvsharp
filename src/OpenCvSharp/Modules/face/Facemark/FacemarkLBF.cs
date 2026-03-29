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
        NativeMethods.HandleException(
            NativeMethods.face_FacemarkLBF_create(parameters?.CvPtr ?? IntPtr.Zero, out var smartPtr));
        if (smartPtr == IntPtr.Zero)
            throw new OpenCvSharpException($"Invalid cv::Ptr<{nameof(FacemarkLBF)}> pointer");
        NativeMethods.HandleException(NativeMethods.face_Ptr_FacemarkLBF_get(smartPtr, out var rawPtr));
        return new FacemarkLBF(smartPtr, rawPtr);
    }

#pragma warning disable CA1034
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public sealed class Params : CvObject
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Params()
        {
            NativeMethods.HandleException(
                NativeMethods.face_FacemarkLBF_Params_new(out var p));
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException($"Invalid {GetType().Name} pointer");
            InitSafeHandle(p);
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>

        private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
        {
            SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
                static h => NativeMethods.HandleException(NativeMethods.face_FacemarkLBF_Params_delete(h))));
        }

        /// <summary>
        /// offset for the loaded face landmark points
        /// </summary>
        public double ShapeOffset
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_shape_offset_get(CvPtr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_shape_offset_set(CvPtr, value));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// filename of the face detector model
        /// </summary>
        public string CascadeFace
        {
            get
            {
                using var s = new StdString();
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_cascade_face_get(CvPtr, s.CvPtr));
                GC.KeepAlive(this);
                return s.ToString();
            }
            set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(value));
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_cascade_face_set(CvPtr, value));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// show the training print-out
        /// </summary>
        public bool Verbose
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_verbose_get(CvPtr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_verbose_set(CvPtr, value ? 1 : 0));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// number of landmark points
        /// </summary>
        public int NLandmarks
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_n_landmarks_get(CvPtr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_n_landmarks_set(CvPtr, value));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// multiplier for augment the training data
        /// </summary>
        public int InitShapeN
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_initShape_n_get(CvPtr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_initShape_n_set(CvPtr, value));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// number of refinement stages
        /// </summary>
        public int StagesN
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_stages_n_get(CvPtr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_stages_n_set(CvPtr, value));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// number of tree in the model for each landmark point refinement
        /// </summary>
        public int TreeN
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_tree_n_get(CvPtr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_tree_n_set(CvPtr, value));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// the depth of decision tree, defines the size of feature
        /// </summary>
        public int TreeDepth
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_tree_depth_get(CvPtr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_tree_depth_set(CvPtr, value));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// overlap ratio for training the LBF feature
        /// </summary>
        public double BaggingOverlap
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_bagging_overlap_get(CvPtr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_bagging_overlap_set(CvPtr, value));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// filename where the trained model will be saved
        /// </summary>
        public string ModelFilename
        {
            get
            {
                using var s = new StdString();
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_model_filename_get(CvPtr, s.CvPtr));
                GC.KeepAlive(this);
                return s.ToString();
            }
            set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(value));
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_model_filename_set(CvPtr, value));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// flag to save the trained model or not
        /// </summary>
        public bool SaveModel
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_save_model_get(CvPtr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_save_model_set(CvPtr, value ? 1 : 0));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// seed for shuffling the training data
        /// </summary>
        public uint Seed
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_seed_get(CvPtr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_seed_set(CvPtr, value));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyList<int> FeatsM
        {
            get
            {
                using var vec = new VectorOfInt32();
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_feats_m_get(CvPtr, vec.CvPtr));
                GC.KeepAlive(this);
                return vec.ToArray();
            }
            set
            {
                using var vec = new VectorOfInt32(value);
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_feats_m_set(CvPtr, vec.CvPtr));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyList<double> RadiusM
        {
            get
            {
                using var vec = new VectorOfDouble();
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_radius_m_get(CvPtr, vec.CvPtr));
                GC.KeepAlive(this);
                return vec.ToArray();
            }
            set
            {
                using var vec = new VectorOfDouble(value);
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_radius_m_set(CvPtr, vec.CvPtr));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// index of facemark points on pupils of left and right eye
        /// </summary>
        public IReadOnlyList<int> Pupils0
        {
            get
            {
                using var vec = new VectorOfInt32();
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_pupils0_get(CvPtr, vec.CvPtr));
                GC.KeepAlive(this);
                return vec.ToArray();
            }
            set
            {
                using var vec = new VectorOfInt32(value);
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_pupils0_set(CvPtr, vec.CvPtr));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// index of facemark points on pupils of left and right eye
        /// </summary>
        public IReadOnlyList<int> Pupils1
        {
            get
            {
                using var vec = new VectorOfInt32();
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_pupils1_get(CvPtr, vec.CvPtr));
                GC.KeepAlive(this);
                return vec.ToArray();
            }
            set
            {
                using var vec = new VectorOfInt32(value);
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_pupils1_set(CvPtr, vec.CvPtr));
                GC.KeepAlive(this);
            }
        }
            
        /// <summary>
        /// 
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public Rect DetectROI
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_detectROI_get(CvPtr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_detectROI_set(CvPtr, value));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fn"></param>
        public void Read(FileNode fn)
        {
            if (fn is null)
                throw new ArgumentNullException(nameof(fn));
            NativeMethods.HandleException(
                NativeMethods.face_FacemarkLBF_Params_write(CvPtr, fn.CvPtr));
            GC.KeepAlive(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fs"></param>
        public void Write(FileStorage fs)
        {
            if (fs is null)
                throw new ArgumentNullException(nameof(fs));
            NativeMethods.HandleException(
                NativeMethods.face_FacemarkLBF_Params_write(CvPtr, fs.CvPtr));
            GC.KeepAlive(this);
        }
    }

    }
