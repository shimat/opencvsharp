using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// n次元の密な配列
    /// </summary>
#else
    /// <summary>
    /// n-dimensional dense array
    /// </summary>
#endif
    public class MatND : DisposableCvObject, ICloneable
    {
        #region Const
        // ReSharper disable InconsistentNaming
        /// <summary>
        /// 
        /// </summary>
        protected const int MAGIC_VAL = 0x42FE0000;
        /// <summary>
        /// 
        /// </summary>
        protected const int AUTO_STEP = -1;
        /// <summary>
        /// 
        /// </summary>
        protected const int CONTINUOUS_FLAG = CvConst.CV_MAT_CONT_FLAG;
        // ReSharper restore InconsistentNaming
        #endregion

        #region Fields
        /// <summary>
        /// sizeof(MatND)
        /// </summary>
        public static readonly int SizeOf;
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;
        #endregion

        #region Init and Disposal
        /// <summary>
        /// static constructor
        /// </summary>
        static MatND()
        {
            try
            {
                SizeOf = CppInvoke.MatND_sizeof();
            }
            catch (DllNotFoundException e)
            {
                PInvokeHelper.DllImportError(e);
                throw;
            }
            catch (BadImageFormatException e)
            {
                PInvokeHelper.DllImportError(e);
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #region Constructor
#if LANG_JP
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public MatND()
        {
            ptr = CppInvoke.MatND_new1();
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        #endregion
        #region Dispose
#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
#endif
        public void Release()
        {
            Dispose(true);
        }
#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
        /// <param name="disposing">
        /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
        /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
        ///</param>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {                        
                    }
                    if (IsEnabledDispose)
                    {
                        CppInvoke.MatND_delete(ptr);
                    }
                    disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
        #endregion
        #endregion

        #region Operators
        /*
        #region Unary
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static Mat operator -(Mat src)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (src.disposed)
                throw new ObjectDisposedException("Mat");
            Mat dst = new Mat();
            CppInvoke.Mat_opUnaryMinus(src.CvPtr, dst.CvPtr);
            return dst;
        }
        #endregion
        #region Binary
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
        public static Mat operator +(Mat src1, Mat src2)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (src1.disposed || src2.disposed)
                throw new ObjectDisposedException("Mat");
            Mat dst = new Mat();
            CppInvoke.Mat_opBinaryPlus1(src1.CvPtr, src2.CvPtr, dst.CvPtr);
            return dst;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
        public static Mat operator +(Mat src1, CvScalar src2)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src1.disposed)
                throw new ObjectDisposedException("Mat");
            Mat dst = new Mat();
            CppInvoke.Mat_opBinaryPlus2(src1.CvPtr, src2, dst.CvPtr);
            return dst;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
        public static Mat operator -(Mat src1, Mat src2)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (src1.disposed || src2.disposed)
                throw new ObjectDisposedException("Mat");
            Mat dst = new Mat();
            CppInvoke.Mat_opBinaryMinus1(src1.CvPtr, src2.CvPtr, dst.CvPtr);
            return dst;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
        public static Mat operator -(Mat src1, CvScalar src2)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src1.disposed)
                throw new ObjectDisposedException("Mat");
            Mat dst = new Mat();
            CppInvoke.Mat_opBinaryMinus2(src1.CvPtr, src2, dst.CvPtr);
            return dst;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
        public static Mat operator *(Mat src1, Mat src2)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (src1.disposed || src2.disposed)
                throw new ObjectDisposedException("Mat");
            Mat dst = new Mat();
            CppInvoke.Mat_opBinaryMultiply(src1.CvPtr, src2.CvPtr, dst.CvPtr);
            return dst;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
        public static Mat operator /(Mat src1, Mat src2)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (src1.disposed || src2.disposed)
                throw new ObjectDisposedException("Mat");
            Mat dst = new Mat();
            CppInvoke.Mat_opBinaryDivide(src1.CvPtr, src2.CvPtr, dst.CvPtr);
            return dst;
        }
        #endregion
        */
        #region Cast
        /// <summary>
        /// converts header to cv::Mat; no data is copied
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator Mat(MatND self)
        {
            if (self == null)
                return null;
            return self.ToMat();
        }

        /// <summary>
        /// converts header to CvMatND; no data is copied
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator CvMatND(MatND self)
        {
            if (self == null)
                return null;
            return self.ToCvMatND();
        }

        #endregion
        #endregion

        #region Properties
        /// <summary>
        /// includes several bit-fields: 
        ///  1.the magic signature 
        ///  2.continuity flag 
        ///  3.depth 
        ///  4.number of channels
        /// </summary>
        public int Flags
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("MatND");
                return CppInvoke.MatND_flags_get(ptr);
            }
        }
        /// <summary>
        /// the array dimensionality
        /// </summary>
        public int Dims
        {
            get 
            {
                if (disposed)
                    throw new ObjectDisposedException("MatND");
                return CppInvoke.MatND_dims_get(ptr); 
            }
        }
        /// <summary>
        /// pointer to the data
        /// </summary>
        public IntPtr Data
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("MatND");
                return CppInvoke.MatND_data_get(ptr);
            }
        }
        /// <summary>
        /// pointer to the reference counter;
        /// when matrix points to user-allocated data, the pointer is NULL
        /// </summary>
        public IntPtr RefCount
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("MatND");
                return CppInvoke.MatND_refcount_get(ptr);
            }
        }
        /// <summary>
        /// helper fields used in locateROI and adjustROI
        /// </summary>
        public IntPtr DataStart
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("MatND");
                return CppInvoke.MatND_datastart_get(ptr);
            }
        }
        /// <summary>
        /// helper fields used in locateROI and adjustROI
        /// </summary>
        public IntPtr DataEnd
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("MatND");
                return CppInvoke.MatND_dataend_get(ptr);
            }
        }
        /// <summary>
        /// size for each dimension, MAX_DIM at max
        /// </summary>
        public int[] Size
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("MatND");
                IntPtr p = CppInvoke.MatND_size_get(ptr);
                int[] result = new int[CvConst.CV_MAX_DIM];
                Marshal.Copy(p, result, 0, result.Length);
                return result;
            }
        }
        /// <summary>
        /// step for each dimension, MAX_DIM at max
        /// </summary>
        public int[] Step
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("MatND");
                IntPtr p = CppInvoke.MatND_size_get(ptr);
                int[] result = new int[CvConst.CV_MAX_DIM];
                Marshal.Copy(p, result, 0, result.Length);
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public MatrixType Type
        {
            get
            {
                return (MatrixType)Cv.MAT_TYPE(Flags);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ElemSize
        {
            get
            {
                return Cv.ELEM_SIZE(Flags);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ElemSize1
        {
            get
            {
                return Cv.ELEM_SIZE1(Flags);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Depth 
        {
            get
            {
                return Cv.MAT_DEPTH(Flags);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Channels
        {
            get 
            {
                return Cv.MAT_CN(Flags);
            }
        }

        /// <summary>
        /// sub-array selection; only the header is copied
        /// </summary>
        /// <param name="ranges"></param>
        /// <returns></returns>
        public virtual MatND this[CvSlice[] ranges]
        {
            get
            {
                MatND result = new MatND();
                CppInvoke.MatND_opRange(ptr, ranges, result.CvPtr);
                return result;
            }
        }
        #endregion

        #region Methods
        #region Static methods
        #endregion
        #region Instance methods
        /// <summary>
        /// creates a complete copy of the matrix (all the data is copied)
        /// </summary>
        /// <returns></returns>
        public MatND Clone()
        {
            if (disposed)
                throw new ObjectDisposedException("MatND");
            MatND outValue = new MatND();
            CppInvoke.Mat_clone(ptr, outValue.CvPtr);
            return outValue;
        }
        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// copies those matrix elements to "m" 
        /// </summary>
        /// <param name="m"></param>
        public void CopyTo(MatND m)
        {
            if (disposed)
                throw new ObjectDisposedException("MatND");
            if (m == null)
                throw new ArgumentNullException("m");
            CppInvoke.MatND_copyTo1(ptr, m.CvPtr);
        }
        /// <summary>
        /// copies those matrix elements to "m" that are marked with non-zero mask elements.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="mask"></param>
        public void CopyTo(MatND m, MatND mask)
        {
            if (disposed)
                throw new ObjectDisposedException("MatND");
            if (m == null)
                throw new ArgumentNullException("m");
            if (mask == null)
                throw new ArgumentNullException("mask");
            CppInvoke.MatND_copyTo2(ptr, m.CvPtr, mask.CvPtr);
        }

        /// <summary>
        /// converts data to the specified data type.
        /// calls m.create(this->size(), rtype) prior to the conversion
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="rtype"></param>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <returns></returns>
        public void ConvertTo(MatND dst, MatrixType rtype, double alpha = 1, double beta = 0)
        {
            if (disposed)
                throw new ObjectDisposedException("MatND");
            CppInvoke.MatND_convertTo(ptr, dst.CvPtr, rtype, alpha, beta);
        }

        /// <summary>
        /// assigns "s" to the selected elements of array
        /// (or to all the elements if mask==MatND())
        /// </summary>
        /// <param name="s"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public MatND SetTo(CvScalar s, MatND mask = null)
        {
            if (disposed)
                throw new ObjectDisposedException("MatND");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            MatND dst = new MatND();
            CppInvoke.MatND_setTo(ptr, s, maskPtr, dst.CvPtr);
            return dst;
        }

        /// <summary>
        /// modifies geometry of array without copying the data
        /// </summary>
        /// <param name="newcn"></param>
        /// <param name="newndims"></param>
        /// <param name="newsz"></param>
        /// <returns></returns>
        public MatND Reshape(int newcn, int newndims = 0, int[] newsz = null)
        {
            if (disposed)
                throw new ObjectDisposedException("MatND");
            MatND dst = new MatND();
            CppInvoke.MatND_reshape(ptr, newcn, newndims, newsz, dst.CvPtr);
            return dst;
        }

        /// <summary>
        /// converts header to cv::Mat; no data is copied
        /// </summary>
        /// <returns></returns>
        public Mat ToMat()
        {
            if (disposed)
                throw new ObjectDisposedException("MatND");
            Mat mat = new Mat();
            mat.IsEnabledDispose = false;
            CppInvoke.MatND_opMat(ptr, mat.CvPtr);
            return mat;
        }
        /// <summary>
        /// converts header to CvMatND; no data is copied
        /// </summary>
        /// <returns></returns>
        public CvMatND ToCvMatND()
        {
            if (disposed)
                throw new ObjectDisposedException("MatND");
            CvMatND mat = new CvMatND();
            mat.IsEnabledDispose = false;
            CppInvoke.MatND_opCvMatND(ptr, mat.CvPtr);
            return mat;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsContinuous()
        {
            return (Flags & CONTINUOUS_FLAG) != 0;
        }

        /// <summary>
        /// return pointer to the element 
        /// </summary>
        /// <param name="i0"></param>
        /// <returns></returns>
        public IntPtr Ptr(int i0)
        {
            if (disposed)
                throw new ObjectDisposedException("MatND");
            return CppInvoke.MatND_ptr1(ptr, i0);
        }
        /// <summary>
        /// return pointer to the element 
        /// </summary>
        /// <param name="i0"></param>
        /// <param name="i1"></param>
        /// <returns></returns>
        public IntPtr Ptr(int i0, int i1)
        {
            if (disposed)
                throw new ObjectDisposedException("MatND");
            return CppInvoke.MatND_ptr2(ptr, i0, i1);
        }
        /// <summary>
        /// return pointer to the element 
        /// </summary>
        /// <param name="i0"></param>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public IntPtr Ptr(int i0, int i1, int i2)
        {
            if (disposed)
                throw new ObjectDisposedException("MatND");
            return CppInvoke.MatND_ptr3(ptr, i0, i1, i2);
        }
        /// <summary>
        /// return pointer to the element 
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public IntPtr Ptr(params int[] idx)
        {
            if (disposed)
                throw new ObjectDisposedException("MatND");
            return CppInvoke.MatND_ptr4(ptr, idx);
        } 
        #endregion
        #endregion
    }
}
