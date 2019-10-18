﻿using System;
using System.Collections.Generic;
#if ENABLED_CUDA
using OpenCvSharp.Cuda;
#endif

namespace OpenCvSharp
{
    /// <summary>
    /// Proxy datatype for passing Mat's and List&lt;&gt;'s as output parameters
    /// </summary>
    public class OutputArray : DisposableCvObject
    {
        private readonly object obj;

        #region Init & Disposal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        internal OutputArray(Mat mat)
        {
            if (mat == null)
                throw new ArgumentNullException(nameof(mat));
            ptr = NativeMethods.core_OutputArray_new_byMat(mat.CvPtr);
            GC.KeepAlive(mat);
            obj = mat;
        }

#if ENABLED_CUDA
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        internal OutputArray(GpuMat mat)
        {
            if (mat == null)
                throw new ArgumentNullException(nameof(mat));
            ptr = NativeMethods.core_OutputArray_new_byGpuMat(mat.CvPtr);
            GC.KeepAlive(mat);
            obj = mat;
        }
#endif

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        internal OutputArray(IEnumerable<Mat> mat)
        {
            if (mat == null)
                throw new ArgumentNullException(nameof(mat));
            using (var matVector = new VectorOfMat(mat))
            {
                ptr = NativeMethods.core_OutputArray_new_byVectorOfMat(matVector.CvPtr);
            }
            obj = mat;
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.core_OutputArray_delete(ptr);
            base.DisposeUnmanaged();
        }

#endregion

#region Cast
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static implicit operator OutputArray(Mat mat)
        {
            return new OutputArray(mat);
        }

#if ENABLED_CUDA
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static implicit operator OutputArray(GpuMat mat)
        {
            return new OutputArray(mat);
        }
#endif

#endregion

#region Operators
#endregion

#region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsMat()
        {
            return obj is Mat;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual Mat? GetMat()
        {
            return obj as Mat;
        }

#if ENABLED_CUDA
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsGpuMat()
        {
            return obj is GpuMat;
        }
#endif

#if ENABLED_CUDA
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual Mat GetGpuMat()
        {
            return obj as GpuMat;
        }
#endif

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsVectorOfMat()
        {
            return obj is IEnumerable<Mat>;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<Mat>? GetVectorOfMat()
        {
            return obj as IEnumerable<Mat>;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void AssignResult()
        {
            if (!IsReady())
                throw new NotSupportedException();

            // OutputArrayの実体が cv::Mat のとき
            if (IsMat())
            {
                // 実は、何もしなくても結果入ってるっぽい？
                /*
                Mat mat = GetMat();
                // OutputArrayからMatオブジェクトを取得
                IntPtr outMat = NativeMethods.core_OutputArray_getMat(ptr);
                // ポインタをセット
                //NativeMethods.core_Mat_assignment_FromMat(mat.CvPtr, outMat);
                NativeMethods.core_Mat_assignTo(outMat, mat.CvPtr);
                // OutputArrayから取り出したMatをdelete
                NativeMethods.core_Mat_delete(outMat);
                */
            }
#if ENABLED_CUDA
            else if (IsGpuMat())
            {
                // do nothing
            }
#endif
            else
            {
                throw new OpenCvSharpException("Not supported OutputArray-compatible type");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Fix()
        {
            AssignResult();
            Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsReady()
        {
            return
                ptr != IntPtr.Zero &&
                !IsDisposed &&
                obj != null &&
#if ENABLED_CUDA
                (IsMat() || IsGpuMat());
#else
                IsMat();
#endif
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void ThrowIfNotReady()
        {
            if (!IsReady())
                throw new OpenCvSharpException("Invalid OutputArray");
        }

        /// <summary>
        /// Creates a proxy class of the specified matrix
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static OutputArray Create(Mat mat)
        {
            return new OutputArray(mat);
        }

#if ENABLED_CUDA
        /// <summary>
        /// Creates a proxy class of the specified matrix
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static OutputArray Create(GpuMat mat)
        {
            return new OutputArray(mat);
        }
#endif

        /// <summary>
        /// Creates a proxy class of the specified list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static OutputArrayOfStructList<T> Create<T>(List<T> list)
            where T : unmanaged
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            return new OutputArrayOfStructList<T>(list);
        }

        /// <summary>
        /// Creates a proxy class of the specified list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static OutputArrayOfMatList Create(List<Mat> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            return new OutputArrayOfMatList(list);
        }

#endregion
    }
}
