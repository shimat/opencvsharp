using System;
using System.Collections.Generic;

namespace OpenCvSharp.Face
{
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public sealed class FacemarkAAM : Facemark
    {
        private Ptr ptrObj;

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
        public static FacemarkAAM Create(Params parameters = null)
        {
            IntPtr p = NativeMethods.face_FacemarkAAM_create(parameters?.CvPtr ?? IntPtr.Zero);
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
                ptr = NativeMethods.face_FacemarkAAM_Params_new();
                if (ptr == IntPtr.Zero)
                    throw new OpenCvSharpException($"Invalid {GetType().Name} pointer");
            }

            /// <summary>
            /// Releases managed resources
            /// </summary>
            protected override void DisposeUnmanaged()
            {
                if (ptr != IntPtr.Zero)
                    NativeMethods.face_FacemarkAAM_Params_delete(ptr);
                base.DisposeUnmanaged();
            }

            /// <summary>
            /// filename of the model
            /// </summary>
            public string ModelFilename
            {
                get
                {
                    using (var s = new StdString())
                    {
                        NativeMethods.face_FacemarkAAM_Params_model_filename_get(ptr, s.CvPtr);
                        GC.KeepAlive(this);
                        return s.ToString();
                    }
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException(nameof(value));
                    NativeMethods.face_FacemarkAAM_Params_model_filename_set(ptr, value);
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
                    var ret = NativeMethods.face_FacemarkAAM_Params_m_get(ptr);
                    GC.KeepAlive(this);
                    return ret;
                }
                set
                {
                    NativeMethods.face_FacemarkAAM_Params_m_set(ptr, value);
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
                    var ret = NativeMethods.face_FacemarkAAM_Params_n_get(ptr);
                    GC.KeepAlive(this);
                    return ret;
                }
                set
                {
                    NativeMethods.face_FacemarkAAM_Params_n_set(ptr, value);
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
                    var ret = NativeMethods.face_FacemarkAAM_Params_n_iter_get(ptr);
                    GC.KeepAlive(this);
                    return ret;
                }
                set
                {
                    NativeMethods.face_FacemarkAAM_Params_n_iter_set(ptr, value);
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
                    var ret = NativeMethods.face_FacemarkAAM_Params_verbose_get(ptr);
                    GC.KeepAlive(this);
                    return ret != 0;
                }
                set
                {
                    NativeMethods.face_FacemarkAAM_Params_verbose_set(ptr, value ? 1 : 0);
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
                    var ret = NativeMethods.face_FacemarkAAM_Params_save_model_get(ptr);
                    GC.KeepAlive(this);
                    return ret != 0;
                }
                set
                {
                    NativeMethods.face_FacemarkAAM_Params_save_model_set(ptr, value ? 1 : 0);
                    GC.KeepAlive(this);
                }
            }

            /// <summary>
            /// 
            /// </summary>
#if NET20 || NET40
            public float[] Scales
#else
            public IReadOnlyList<float> Scales
#endif
            {
                get
                {
                    using (var vec = new VectorOfFloat())
                    {
                        NativeMethods.face_FacemarkAAM_Params_scales_get(ptr, vec.CvPtr);
                        GC.KeepAlive(this);
                        return vec.ToArray();
                    }
                }
                set
                {
                    using (var vec = new VectorOfFloat(value))
                    {
                        NativeMethods.face_FacemarkAAM_Params_scales_set(ptr, vec.CvPtr);
                        GC.KeepAlive(this);
                    }
                }
            }
            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="fn"></param>
            public void Read(FileNode fn)
            {
                if (fn == null)
                    throw new ArgumentNullException(nameof(fn));
                NativeMethods.face_FacemarkAAM_Params_write(ptr, fn.CvPtr);
                GC.KeepAlive(this);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="fs"></param>
            public void Write(FileStorage fs)
            {
                if (fs == null)
                    throw new ArgumentNullException(nameof(fs));
                NativeMethods.face_FacemarkAAM_Params_write(ptr, fs.CvPtr);
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
                var res = NativeMethods.face_Ptr_FacemarkAAM_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.face_Ptr_FacemarkAAM_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}