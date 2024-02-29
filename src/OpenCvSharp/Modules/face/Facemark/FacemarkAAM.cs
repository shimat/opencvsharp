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
    private Ptr? ptrObj;

    /// <summary>
    ///
    /// </summary>
    private FacemarkAAM()
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
    public static FacemarkAAM Create(Params? parameters = null)
    {
        NativeMethods.HandleException(
            NativeMethods.face_FacemarkAAM_create(parameters?.CvPtr ?? IntPtr.Zero, out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Invalid cv::Ptr<{nameof(FacemarkAAM)}> pointer");
        var ptrObj = new Ptr(p);
        var detector = new FacemarkAAM
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
                NativeMethods.face_FacemarkAAM_Params_new(out ptr));
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
                    NativeMethods.face_FacemarkAAM_Params_delete(ptr));
            base.DisposeUnmanaged();
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
                    NativeMethods.face_FacemarkAAM_Params_model_filename_get(ptr, s.CvPtr));
                GC.KeepAlive(this);
                return s.ToString();
            }
            set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(value));
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_model_filename_set(ptr, value));
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
                    NativeMethods.face_FacemarkAAM_Params_m_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_m_set(ptr, value));
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
                    NativeMethods.face_FacemarkAAM_Params_n_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_n_set(ptr, value));
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
                    NativeMethods.face_FacemarkAAM_Params_n_iter_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_n_iter_set(ptr, value));
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
                    NativeMethods.face_FacemarkAAM_Params_verbose_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_verbose_set(ptr, value ? 1 : 0));
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
                    NativeMethods.face_FacemarkAAM_Params_save_model_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_save_model_set(ptr, value ? 1 : 0));
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
                    NativeMethods.face_FacemarkAAM_Params_scales_get(ptr, vec.CvPtr));
                GC.KeepAlive(this);
                return vec.ToArray();
            }
            set
            {
                using var vec = new VectorOfFloat(value);
                NativeMethods.HandleException(
                    NativeMethods.face_FacemarkAAM_Params_scales_set(ptr, vec.CvPtr));
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
                NativeMethods.face_FacemarkAAM_Params_write(ptr, fn.CvPtr));
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
                NativeMethods.face_FacemarkAAM_Params_write(ptr, fs.CvPtr));
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
                NativeMethods.face_Ptr_FacemarkAAM_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.face_Ptr_FacemarkAAM_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
