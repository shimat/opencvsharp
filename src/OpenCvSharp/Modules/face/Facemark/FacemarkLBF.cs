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
    private Ptr? ptrObj;

    /// <summary>
    ///
    /// </summary>
    private FacemarkLBF()
    {
        ptrObj = null;
        ptr = IntPtr.Zero;
    }
        
    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        ptrObj?.Dispose();
        ptrObj = null;
        base.DisposeManaged();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public static FacemarkLBF Create(Params? parameters = null)
    {
        NativeMethods.HandleException(
            NativeMethods.face_FacemarkLBF_create(parameters?.CvPtr ?? IntPtr.Zero, out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Invalid cv::Ptr<{nameof(FacemarkLBF)}> pointer");
        var ptrObj = new Ptr(p);
        var detector = new FacemarkLBF
        {
            ptrObj = ptrObj,
            ptr = ptrObj.Get()
        };
        return detector;
    }

#pragma warning disable CA1034
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public sealed class Params : DisposableCvObject
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Params()
        {
            NativeMethods.HandleException(
                NativeMethods.face_FacemarkLBF_Params_new(out ptr));
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException($"Invalid {GetType().Name} pointer");
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            if (ptr != IntPtr.Zero)
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_delete(ptr));
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// offset for the loaded face landmark points
        /// </summary>
        public double ShapeOffset
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_shape_offset_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_shape_offset_set(ptr, value));
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
                    NativeMethods.face_FacemarkLBF_Params_cascade_face_get(ptr, s.CvPtr));
                GC.KeepAlive(this);
                return s.ToString();
            }
            set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(value));
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_cascade_face_set(ptr, value));
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
                    NativeMethods.face_FacemarkLBF_Params_verbose_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_verbose_set(ptr, value ? 1 : 0));
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
                    NativeMethods.face_FacemarkLBF_Params_n_landmarks_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_n_landmarks_set(ptr, value));
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
                    NativeMethods.face_FacemarkLBF_Params_initShape_n_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_initShape_n_set(ptr, value));
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
                    NativeMethods.face_FacemarkLBF_Params_stages_n_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_stages_n_set(ptr, value));
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
                    NativeMethods.face_FacemarkLBF_Params_tree_n_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_tree_n_set(ptr, value));
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
                    NativeMethods.face_FacemarkLBF_Params_tree_depth_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_tree_depth_set(ptr, value));
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
                    NativeMethods.face_FacemarkLBF_Params_bagging_overlap_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_bagging_overlap_set(ptr, value));
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
                    NativeMethods.face_FacemarkLBF_Params_model_filename_get(ptr, s.CvPtr));
                GC.KeepAlive(this);
                return s.ToString();
            }
            set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(value));
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_model_filename_set(ptr, value));
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
                    NativeMethods.face_FacemarkLBF_Params_save_model_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_save_model_set(ptr, value ? 1 : 0));
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
                    NativeMethods.face_FacemarkLBF_Params_seed_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_seed_set(ptr, value));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
#if NET40
            public int[] FeatsM
#else
        public IReadOnlyList<int> FeatsM
#endif
        {
            get
            {
                using var vec = new VectorOfInt32();
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_feats_m_get(ptr, vec.CvPtr));
                GC.KeepAlive(this);
                return vec.ToArray();
            }
            set
            {
                using var vec = new VectorOfInt32(value);
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_feats_m_set(ptr, vec.CvPtr));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
#if NET40
            public double[] RadiusM
#else
        public IReadOnlyList<double> RadiusM
#endif
        {
            get
            {
                using var vec = new VectorOfDouble();
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_radius_m_get(ptr, vec.CvPtr));
                GC.KeepAlive(this);
                return vec.ToArray();
            }
            set
            {
                using var vec = new VectorOfDouble(value);
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_radius_m_set(ptr, vec.CvPtr));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// index of facemark points on pupils of left and right eye
        /// </summary>
#if NET40
            public int[] Pupils0
#else
        public IReadOnlyList<int> Pupils0
#endif
        {
            get
            {
                using var vec = new VectorOfInt32();
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_pupils0_get(ptr, vec.CvPtr));
                GC.KeepAlive(this);
                return vec.ToArray();
            }
            set
            {
                using var vec = new VectorOfInt32(value);
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_pupils0_set(ptr, vec.CvPtr));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// index of facemark points on pupils of left and right eye
        /// </summary>
#if NET40
            public int[] Pupils1
#else
        public IReadOnlyList<int> Pupils1
#endif
        {
            get
            {
                using var vec = new VectorOfInt32();
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_pupils1_get(ptr, vec.CvPtr));
                GC.KeepAlive(this);
                return vec.ToArray();
            }
            set
            {
                using var vec = new VectorOfInt32(value);
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_pupils1_set(ptr, vec.CvPtr));
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
                    NativeMethods.face_FacemarkLBF_Params_detectROI_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkLBF_Params_detectROI_set(ptr, value));
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
                NativeMethods.face_FacemarkLBF_Params_write(ptr, fn.CvPtr));
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
                NativeMethods.face_FacemarkLBF_Params_write(ptr, fs.CvPtr));
            GC.KeepAlive(this);
        }
    }

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.face_Ptr_FacemarkLBF_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.face_Ptr_FacemarkLBF_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
