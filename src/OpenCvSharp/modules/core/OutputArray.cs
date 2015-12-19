using System;
using System.Collections.Generic;
using OpenCvSharp.Gpu;

namespace OpenCvSharp
{
    /// <summary>
    /// Proxy datatype for passing Mat's and List&lt;&gt;'s as output parameters
    /// </summary>
    public class OutputArray : DisposableCvObject
    {
        private bool disposed;
        private readonly object obj;

        #region Init & Disposal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        internal OutputArray(Mat mat)
        {
            if (mat == null)
                throw new ArgumentNullException("mat");
            ptr = NativeMethods.core_OutputArray_new_byMat(mat.CvPtr);
            obj = mat;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        internal OutputArray(GpuMat mat)
        {
            if (mat == null)
                throw new ArgumentNullException("mat");
            ptr = NativeMethods.core_OutputArray_new_byGpuMat(mat.CvPtr);
            obj = mat;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        internal OutputArray(IEnumerable<Mat> mat)
        {
            if (mat == null)
                throw new ArgumentNullException("mat");
            using (var matVector = new VectorOfMat(mat))
            {
                ptr = NativeMethods.core_OutputArray_new_byVectorOfMat(matVector.CvPtr);
            }
            obj = mat;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                    }
                    if (ptr != IntPtr.Zero)
                    {
                        NativeMethods.core_OutputArray_delete(ptr);
                        ptr = IntPtr.Zero;
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static implicit operator OutputArray(GpuMat mat)
        {
            return new OutputArray(mat);
        }

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
        public virtual Mat GetMat()
        {
            return obj as Mat;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsGpuMat()
        {
            return obj is GpuMat;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual Mat GetGpuMat()
        {
            return obj as GpuMat;
        }

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
        public virtual IEnumerable<Mat> GetVectorOfMat()
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
            else if (IsGpuMat())
            {
                // do nothing
            }
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
                !disposed &&
                obj != null &&
                (IsMat() || IsGpuMat());
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

        /// <summary>
        /// Creates a proxy class of the specified matrix
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static OutputArray Create(GpuMat mat)
        {
            return new OutputArray(mat);
        }

        /// <summary>
        /// Creates a proxy class of the specified list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static OutputArrayOfStructList<T> Create<T>(List<T> list)
            where T : struct
        {
            if (list == null)
                throw new ArgumentNullException("list");
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
                throw new ArgumentNullException("list");
            return new OutputArrayOfMatList(list);
        }

        #endregion
    }
}
