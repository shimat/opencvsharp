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
        NativeMethods.HandleException(
            NativeMethods.face_FacemarkAAM_create(parameters?.CvPtr ?? IntPtr.Zero, out var smartPtr));
        if (smartPtr == IntPtr.Zero)
            throw new OpenCvSharpException($"Invalid cv::Ptr<{nameof(FacemarkAAM)}> pointer");
        NativeMethods.HandleException(NativeMethods.face_Ptr_FacemarkAAM_get(smartPtr, out var rawPtr));
        return new FacemarkAAM(smartPtr, rawPtr);
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
                NativeMethods.face_FacemarkAAM_Params_new(out var p));
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
                static h => NativeMethods.HandleException(NativeMethods.face_FacemarkAAM_Params_delete(h))));
        }

        /// <summary>
        /// filename of the model
        /// </summary>
        public string ModelFilename
        {
            get
            {
                using var s = new StdString();
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_model_filename_get(CvPtr, s.CvPtr));
                GC.KeepAlive(this);
                return s.ToString();
            }
            set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(value));
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_model_filename_set(CvPtr, value));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int M
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_m_get(CvPtr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_m_set(CvPtr, value));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int N
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_n_get(CvPtr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_n_set(CvPtr, value));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int NIter
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_n_iter_get(CvPtr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_n_iter_set(CvPtr, value));
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
                    NativeMethods.face_FacemarkAAM_Params_verbose_get(CvPtr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_verbose_set(CvPtr, value ? 1 : 0));
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
                    NativeMethods.face_FacemarkAAM_Params_save_model_get(CvPtr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_save_model_set(CvPtr, value ? 1 : 0));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyList<float> Scales
        {
            get
            {
                using var vec = new VectorOfFloat();
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_scales_get(CvPtr, vec.CvPtr));
                GC.KeepAlive(this);
                return vec.ToArray();
            }
            set
            {
                using var vec = new VectorOfFloat(value);
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_scales_set(CvPtr, vec.CvPtr));
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
                NativeMethods.face_FacemarkAAM_Params_write(CvPtr, fn.CvPtr));
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
                NativeMethods.face_FacemarkAAM_Params_write(CvPtr, fs.CvPtr));
            GC.KeepAlive(this);
        }
    }

    }
