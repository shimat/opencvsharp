using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// cv::Mat
    /// </summary>
    public class Mat : DisposableCvObject, ICloneable
    {
        private bool disposed;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public Mat(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Native object address is NULL");
            this.ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        public Mat()
        {
            try
            {
                ptr = CppInvoke.core_Mat_new();
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        public Mat(int rows, int cols, MatrixType type)
        {
            try
            {
                ptr = CppInvoke.core_Mat_new(rows, cols, (int)type);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        public Mat(Size size, int type)
        {
            try
            {
                ptr = CppInvoke.core_Mat_new(size.Width, size.Height, type);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        /// <param name="s"></param>
        public Mat(int rows, int cols, int type, Scalar s)
        {
            try
            {
                ptr = CppInvoke.core_Mat_new(rows, cols, type, s);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <param name="s"></param>
        public Mat(Size size, MatrixType type, Scalar s)
        {
            try
            {
                ptr = CppInvoke.core_Mat_new(size.Width, size.Height, (int)type, s);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="rowRange"></param>
        /// <param name="colRange"></param>
        public Mat(Mat m, Range rowRange, Range colRange)
        {
            try
            {
                ptr = CppInvoke.core_Mat_new(m.ptr, rowRange, colRange);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="rowRange"></param>
        public Mat(Mat m, Range rowRange)
        {
            try
            {
                ptr = CppInvoke.core_Mat_new(m.ptr, rowRange);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="roi"></param>
        public Mat(Mat m, Rect roi)
        {
            try
            {
                ptr = CppInvoke.core_Mat_new(m.ptr, roi);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="step"></param>
        public Mat(int rows, int cols, MatrixType type, IntPtr data, long step = 0)
        {
            try
            {
                ptr = CppInvoke.core_Mat_new(rows, cols, (int)type, data, new IntPtr(step));
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="step"></param>
        public Mat(int rows, int cols, MatrixType type, Array data, long step = 0)
        {
            try
            {
                GCHandle handle = AllocGCHandle(data);
                ptr = CppInvoke.core_Mat_new(rows, cols, (int)type,
                                             handle.AddrOfPinnedObject(), new IntPtr(step));
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sizes"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="steps"></param>
        public Mat(IEnumerable<int> sizes, MatrixType type, IntPtr data, IEnumerable<long> steps = null)
        {
            if (sizes == null)
                throw new ArgumentNullException("steps");
            if (data == IntPtr.Zero)
                throw new ArgumentNullException("data");
            try
            {
                int[] sizesArray = new List<int>(sizes).ToArray();
                if (steps == null)
                {
                    ptr = CppInvoke.core_Mat_new(sizesArray.Length, sizesArray, (int)type, data, IntPtr.Zero);
                }
                else
                {
                    List<IntPtr> stepsList = new List<IntPtr>();
                    foreach (long step in steps)
                    {
                        stepsList.Add(new IntPtr(step));
                    }
                    ptr = CppInvoke.core_Mat_new(sizesArray.Length, sizesArray, (int)type, data, stepsList.ToArray());
                }
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sizes"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="steps"></param>
        public Mat(IEnumerable<int> sizes, MatrixType type, Array data, IEnumerable<long> steps = null)
        {
            if (sizes == null)
                throw new ArgumentNullException("steps");
            if (data == null)
                throw new ArgumentNullException("data");
            try
            {
                GCHandle handle = AllocGCHandle(data);
                int[] sizesArray = new List<int>(sizes).ToArray();
                if (steps == null)
                {
                    ptr = CppInvoke.core_Mat_new(sizesArray.Length, sizesArray,
                                                 (int)type, handle.AddrOfPinnedObject(), IntPtr.Zero);
                }
                else
                {
                    List<IntPtr> stepsList = new List<IntPtr>();
                    foreach (long step in steps)
                    {
                        stepsList.Add(new IntPtr(step));
                    }
                    ptr = CppInvoke.core_Mat_new(sizesArray.Length, sizesArray,
                                                 (int)type, handle.AddrOfPinnedObject(), stepsList.ToArray());
                }
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

#if LANG_JP
    /// <summary>
    /// リソースの解放
    /// </summary>
#else
        /// <summary>
        /// Releases the resources
        /// </summary>
#endif
        public void Release()
        {
            Dispose();
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
        /// Releases the resources
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
                try
                {
                    // releases managed resources
                    if (disposing)
                    {
                    }
                    // releases unmanaged resources
                    if (IsEnabledDispose)
                    {
                        if (ptr != IntPtr.Zero)
                        {
                            CppInvoke.core_Mat_delete(ptr);
                        }
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

        #region Static
        #region Diag

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Mat Diag(Mat d)
        {
            return d.Diag();
        }

        #endregion
        #region Eye

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MatExpr Eye(Size size, MatrixType type)
        {
            return Eye(size.Height, size.Width, type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MatExpr Eye(int rows, int cols, MatrixType type)
        {
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_eye(rows, cols, (int)type);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region Ones

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MatExpr Ones(int rows, int cols, MatrixType type)
        {
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_ones(rows, cols, (int)type);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MatExpr Ones(Size size, MatrixType type)
        {
            return Ones(size.Height, size.Width, type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="sizes"></param>
        /// <returns></returns>
        public static MatExpr Ones(MatrixType type, params int[] sizes)
        {
            if (sizes == null)
                throw new ArgumentNullException("sizes");
            /*
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_ones(sizes.Length, sizes, (int)type);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }*/
            throw new NotImplementedException(); // Undefined this in .lib file
        }

        #endregion
        #region Zeros

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MatExpr Zeros(int rows, int cols, MatrixType type)
        {
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_zeros(rows, cols, (int)type);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MatExpr Zeros(Size size, MatrixType type)
        {
            return Zeros(size.Height, size.Width, type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="sizes"></param>
        /// <returns></returns>
        public static MatExpr Zeros(MatrixType type, params int[] sizes)
        {
            if (sizes == null)
                throw new ArgumentNullException("sizes");
            /*
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_zeros(sizes.Length, sizes, (int)type);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }*/
            throw new NotImplementedException();
        }

        #endregion
        #endregion

        #region Operators
        #region Casting

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator IplImage(Mat self)
        {
            return self.ToIplImage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IplImage ToIplImage()
        {
            ThrowIfDisposed();
            try
            {
                IplImage img = new IplImage(false);
                CppInvoke.core_Mat_IplImage(ptr, img.CvPtr);
                return img;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator CvMat(Mat self)
        {
            return self.ToCvMat();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CvMat ToCvMat()
        {
            ThrowIfDisposed();
            try
            {
                CvMat mat = new CvMat(false);
                CppInvoke.core_Mat_CvMat(ptr, mat.CvPtr);
                return mat;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region Arithmetic
        #region Unary

        public static MatExpr operator -(Mat m)
        {
            throw new NotImplementedException();
        }

        public static Mat operator +(Mat m)
        {
            return m;
        }

        #endregion
        #region Binary
        #region +
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static MatExpr operator +(Mat a, Mat b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorAdd_MatMat(a.CvPtr, b.CvPtr);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static MatExpr operator +(Mat a, Scalar s)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorAdd_MatScalar(a.CvPtr, s);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static MatExpr operator +(Scalar s, Mat a)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorAdd_ScalarMat(s, a.CvPtr);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region -
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static MatExpr operator -(Mat a, Mat b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorSubtract_MatMat(a.CvPtr, b.CvPtr);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static MatExpr operator -(Mat a, Scalar s)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorSubtract_MatScalar(a.CvPtr, s);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static MatExpr operator -(Scalar s, Mat a)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorSubtract_ScalarMat(s, a.CvPtr);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region *

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static MatExpr operator *(Mat a, Mat b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorMultiply_MatMat(a.CvPtr, b.CvPtr);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static MatExpr operator *(Mat a, double s)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorMultiply_MatDouble(a.CvPtr, s);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static MatExpr operator *(double s, Mat a)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorMultiply_DoubleMat(s, a.CvPtr);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region /
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static MatExpr operator /(Mat a, Mat b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorDivide_MatMat(a.CvPtr, b.CvPtr);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static MatExpr operator /(Mat a, double s)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorDivide_MatDouble(a.CvPtr, s);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static MatExpr operator /(double s, Mat a)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorDivide_DoubleMat(s, a.CvPtr);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region Comparison
        public static MatExpr operator <(Mat a, Mat b)
        {
            throw new NotImplementedException();
        }

        public static MatExpr operator <(Mat a, double s)
        {
            throw new NotImplementedException();
        }

        public static MatExpr operator <(double s, Mat a)
        {
            throw new NotImplementedException();
        }

        public static MatExpr operator <=(Mat a, Mat b)
        {
            throw new NotImplementedException();
        }

        public static MatExpr operator <=(Mat a, double s)
        {
            throw new NotImplementedException();
        }

        public static MatExpr operator <=(double s, Mat a)
        {
            throw new NotImplementedException();
        }

        /*
        public static MatExpr operator ==(Mat a, Mat b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
                return true;
            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
                return false;
            
        }
        public static MatExpr operator ==(Mat a, double s) { throw new NotImplementedException(); }
        public static MatExpr operator ==(double s, Mat a) { throw new NotImplementedException(); }

        public static MatExpr operator !=(Mat a, Mat b) { throw new NotImplementedException(); }
        public static MatExpr operator !=(Mat a, double s) { throw new NotImplementedException(); }
        public static MatExpr operator !=(double s, Mat a) { throw new NotImplementedException(); }
        */

        public static MatExpr operator >=(Mat a, Mat b)
        {
            throw new NotImplementedException();
        }

        public static MatExpr operator >=(Mat a, double s)
        {
            throw new NotImplementedException();
        }

        public static MatExpr operator >=(double s, Mat a)
        {
            throw new NotImplementedException();
        }

        public static MatExpr operator >(Mat a, Mat b)
        {
            throw new NotImplementedException();
        }

        public static MatExpr operator >(Mat a, double s)
        {
            throw new NotImplementedException();
        }

        public static MatExpr operator >(double s, Mat a)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region And
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static MatExpr operator &(Mat a, Mat b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorAnd_MatMat(a.CvPtr, b.CvPtr);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static MatExpr operator &(Mat a, double s)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorAnd_MatDouble(a.CvPtr, s);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static MatExpr operator &(double s, Mat a)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorAnd_DoubleMat(s, a.CvPtr);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Or
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static MatExpr operator |(Mat a, Mat b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorOr_MatMat(a.CvPtr, b.CvPtr);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static MatExpr operator |(Mat a, double s)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorOr_MatDouble(a.CvPtr, s);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static MatExpr operator |(double s, Mat a)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorOr_DoubleMat(s, a.CvPtr);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Xor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static MatExpr operator ^(Mat a, Mat b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorXor_MatMat(a.CvPtr, b.CvPtr);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static MatExpr operator ^(Mat a, double s)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorXor_MatDouble(a.CvPtr, s);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static MatExpr operator ^(double s, Mat a)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorXor_DoubleMat(s, a.CvPtr);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Not
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static MatExpr operator ~(Mat m)
        {
            if (m == null)
                throw new ArgumentNullException("m");
            m.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorNot_Mat(m.CvPtr);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #region
        #endregion

        #endregion
        #endregion
        #endregion
        #endregion

        #region Public Methods
        #region Indexers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowStart"></param>
        /// <param name="rowEnd"></param>
        /// <param name="colStart"></param>
        /// <param name="colEnd"></param>
        /// <returns></returns>
        public MatExpr this[int rowStart, int rowEnd, int colStart, int colEnd]
        {
            get
            {
                return SubMat(rowStart, rowEnd, colStart, colEnd);
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                Mat submat = SubMat(rowStart, rowEnd, colStart, colEnd);
                CppInvoke.core_Mat_assignment_FromMatExpr(submat.CvPtr, value.CvPtr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowRange"></param>
        /// <param name="colRange"></param>
        /// <returns></returns>
        public MatExpr this[Range rowRange, Range colRange]
        {
            get
            {
                return SubMat(rowRange, colRange);
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                Mat submat = SubMat(rowRange, colRange);
                CppInvoke.core_Mat_assignment_FromMatExpr(submat.CvPtr, value.CvPtr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roi"></param>
        /// <returns></returns>
        public MatExpr this[Rect roi]
        {
            get
            {
                return SubMat(roi);
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                Mat submat = SubMat(roi);
                CppInvoke.core_Mat_assignment_FromMatExpr(submat.CvPtr, value.CvPtr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ranges"></param>
        /// <returns></returns>
        public MatExpr this[params Range[] ranges]
        {
            get
            {
                return SubMat(ranges);
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                Mat submat = SubMat(ranges);
                CppInvoke.core_Mat_assignment_FromMatExpr(submat.CvPtr, value.CvPtr);
            }
        }

        #endregion

        #region AdjustROI

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtop"></param>
        /// <param name="dbottom"></param>
        /// <param name="dleft"></param>
        /// <param name="dright"></param>
        /// <returns></returns>
        public Mat AdjustROI(int dtop, int dbottom, int dleft, int dright)
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_adjustROI(ptr, dtop, dbottom, dleft, dright);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region AssignTo

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="type"></param>
        public void AssignTo(Mat m, MatrixType type)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException("m");
            try
            {
                CppInvoke.core_Mat_assignTo(ptr, m.CvPtr, (int)type);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        public void AssignTo(Mat m)
        {
            try
            {
                CppInvoke.core_Mat_assignTo(ptr, m.CvPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region Channels

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Channels()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_channels(ptr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region CheckVector

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elemChannels"></param>
        /// <returns></returns>
        public int CheckVector(int elemChannels)
        {
            ThrowIfDisposed();
            try
            {
                int retVal = CppInvoke.core_Mat_checkVector(ptr, elemChannels);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elemChannels"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        public int CheckVector(int elemChannels, int depth)
        {
            ThrowIfDisposed();
            try
            {
                int retVal = CppInvoke.core_Mat_checkVector(ptr, elemChannels, depth);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elemChannels"></param>
        /// <param name="depth"></param>
        /// <param name="requireContinuous"></param>
        /// <returns></returns>
        public int CheckVector(int elemChannels, int depth, bool requireContinuous)
        {
            ThrowIfDisposed();
            try
            {
                int retVal = CppInvoke.core_Mat_checkVector(
                    ptr, elemChannels, depth, requireContinuous ? 1 : 0);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region Clone

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Mat Clone()
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_clone(ptr);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        #endregion
        #region Col
        /// <summary>
        /// Mat column's indexer object
        /// </summary>
        public class ColIndexer : MatRowColIndexer
        {
            protected internal ColIndexer(Mat parent)
                : base(parent)
            {
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <returns></returns>
            public override MatExpr this[int x]
            {
                get
                {
                    parent.ThrowIfDisposed();
                    try
                    {
                        IntPtr matExprPtr = CppInvoke.core_Mat_col_toMatExpr(parent.ptr, x);
                        MatExpr matExpr = new MatExpr(matExprPtr);
                        return matExpr;
                    }
                    catch (BadImageFormatException ex)
                    {
                        throw PInvokeHelper.CreateException(ex);
                    }
                }
                set
                {
                    if(value == null)
                        throw new ArgumentNullException("value");
                    parent.ThrowIfDisposed();
                    try
                    {
                        IntPtr colMatPtr = CppInvoke.core_Mat_col_toMat(parent.ptr, x);
                        CppInvoke.core_Mat_assignment_FromMatExpr(colMatPtr, value.CvPtr);
                        CppInvoke.core_Mat_delete(colMatPtr);
                    }
                    catch (BadImageFormatException ex)
                    {
                        throw PInvokeHelper.CreateException(ex);
                    }
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="startCol"></param>
            /// <param name="endCol"></param>
            /// <returns></returns>
            public override MatExpr this[int startCol, int endCol]
            {
                get
                {
                    parent.ThrowIfDisposed();
                    try
                    {
                        IntPtr matExprPtr = CppInvoke.core_Mat_colRange_toMatExpr(parent.ptr, startCol, endCol);
                        MatExpr matExpr = new MatExpr(matExprPtr);
                        return matExpr;
                    }
                    catch (BadImageFormatException ex)
                    {
                        throw PInvokeHelper.CreateException(ex);
                    }
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value");
                    parent.ThrowIfDisposed();
                    try
                    {
                        IntPtr colMatPtr = CppInvoke.core_Mat_colRange_toMat(parent.ptr, startCol, endCol);
                        CppInvoke.core_Mat_assignment_FromMatExpr(colMatPtr, value.CvPtr);
                        CppInvoke.core_Mat_delete(colMatPtr);
                    }
                    catch (BadImageFormatException ex)
                    {
                        throw PInvokeHelper.CreateException(ex);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ColIndexer Col
        {
            get
            {
                if(col == null)
                    col = new ColIndexer(this);
                return col;
            }
        }
        private ColIndexer col = null;
        #endregion
        #region Cols

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Cols
        {
            get
            {
                if (colsVal == int.MinValue)
                {
                    try
                    {
                        colsVal = CppInvoke.core_Mat_cols(ptr);
                    }
                    catch (BadImageFormatException ex)
                    {
                        throw PInvokeHelper.CreateException(ex);
                    }
                }
                return colsVal;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Width
        {
            get
            {
                if (colsVal == int.MinValue)
                {
                    colsVal = Cols;
                }
                return colsVal;
            }
        }

        private int colsVal = int.MinValue;

        #endregion
        #region ColRange
        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startCol"></param>
        /// <param name="endCol"></param>
        /// <returns></returns>
        public Mat ColRange(int startCol, int endCol)
        {
            return Col[startCol, endCol];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Mat ColRange(Range range)
        {
            return Col[range];
        }
        */
        #endregion
        #region Dims

        /// <summary>
        /// 
        /// </summary>
        public int Dims
        {
            get
            {
                ThrowIfDisposed();
                try
                {
                    return CppInvoke.core_Mat_dims(ptr);
                }
                catch (BadImageFormatException ex)
                {
                    throw PInvokeHelper.CreateException(ex);
                }
            }
        }

        #endregion
        #region ConvertTo

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="rtype"></param>
        public void ConvertTo(Mat m, int rtype)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException("m");
            try
            {
                CppInvoke.core_Mat_convertTo(ptr, m.CvPtr, rtype);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="rtype"></param>
        /// <param name="alpha"></param>
        public void ConvertTo(Mat m, int rtype, double alpha)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException("m");
            try
            {
                CppInvoke.core_Mat_convertTo(ptr, m.CvPtr, rtype, alpha);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="rtype"></param>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        public void ConvertTo(Mat m, int rtype, double alpha, double beta)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException("m");
            try
            {
                CppInvoke.core_Mat_convertTo(ptr, m.CvPtr, rtype, alpha, beta);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region CopyTo

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        public void CopyTo(Mat m)
        {
            CopyTo(m, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="mask"></param>
        public void CopyTo(Mat m, Mat mask)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException("m");
            try
            {
                IntPtr maskPtr = GetCvPtr(mask);
                CppInvoke.core_Mat_copyTo(ptr, m.CvPtr, maskPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region Create

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        public void Create(int rows, int cols, MatrixType type)
        {
            ThrowIfDisposed();
            try
            {
                CppInvoke.core_Mat_create(ptr, rows, cols, (int)type);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        public void Create(Size size, MatrixType type)
        {
            Create(size.Width, size.Height, type);
        }

        #endregion
        #region Cross

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public Mat Cross(Mat m)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException("m");
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_cross(ptr, m.CvPtr);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region Data

        /// <summary>
        /// 
        /// </summary>
        public IntPtr Data
        {
            get
            {
                unsafe
                {
                    return new IntPtr(DataPointer);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public unsafe byte* DataPointer
        {
            get
            {
                ThrowIfDisposed();
                try
                {
                    return CppInvoke.core_Mat_data(ptr);
                }
                catch (BadImageFormatException ex)
                {
                    throw PInvokeHelper.CreateException(ex);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IntPtr DataStart
        {
            get
            {
                ThrowIfDisposed();
                try
                {
                    return CppInvoke.core_Mat_datastart(ptr);
                }
                catch (BadImageFormatException ex)
                {
                    throw PInvokeHelper.CreateException(ex);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IntPtr DataEnd
        {
            get
            {
                ThrowIfDisposed();
                try
                {
                    return CppInvoke.core_Mat_dataend(ptr);
                }
                catch (BadImageFormatException ex)
                {
                    throw PInvokeHelper.CreateException(ex);
                }
            }
        }

        #endregion
        #region Depth

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Depth()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_depth(ptr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region Diag

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Mat Diag()
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_diag(ptr);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public Mat Diag(MatDiagType d)
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_diag(ptr, (int)d);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region Dot

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public double Dot(Mat m)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException("m");
            try
            {
                return CppInvoke.core_Mat_dot(ptr, m.CvPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region ElemSize

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ulong ElemSize()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_elemSize(ptr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region ElemSize1

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ulong ElemSize1()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_elemSize1(ptr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region Empty

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Empty()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_empty(ptr) != 0;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region Inv

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Mat Inv()
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_inv(ptr);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public Mat Inv(MatrixDecomposition method)
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_inv(ptr, (int)method);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region IsContinuous

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsContinuous()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_isContinuous(ptr) != 0;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region IsSubmatirx

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsSubmatrix()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_isSubmatrix(ptr) != 0;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region LocateROI

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wholeSize"></param>
        /// <param name="ofs"></param>
        public void LocateROI(out Size wholeSize, out Point ofs)
        {
            ThrowIfDisposed();
            try
            {
                CvSize wholeSize2;
                CvPoint ofs2;
                CppInvoke.core_Mat_locateROI(ptr, out wholeSize2, out ofs2);
                wholeSize = wholeSize2;
                ofs = ofs2;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region Mul

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public MatExpr Mul(Mat m)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException();
            try
            {
                IntPtr mPtr = m.CvPtr;
                IntPtr retPtr = CppInvoke.core_Mat_mul(ptr, mPtr);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public MatExpr Mul(Mat m, double scale)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException();
            try
            {
                IntPtr mPtr = m.CvPtr;
                IntPtr retPtr = CppInvoke.core_Mat_mul(ptr, mPtr, scale);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region PushBack

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        public void PushBack(Mat m)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException();
            try
            {
                IntPtr mPtr = GetCvPtr(m);
                CppInvoke.core_Mat_push_back(ptr, mPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region Reshape

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <returns></returns>
        public Mat Reshape(int cn)
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_reshape(ptr, cn);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public Mat Reshape(int cn, int rows)
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_reshape(ptr, cn, rows);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="newDims"></param>
        /// <returns></returns>
        public Mat Reshape(int cn, params int[] newDims)
        {
            ThrowIfDisposed();
            if (newDims == null)
                throw new ArgumentNullException("newDims");
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_reshape(ptr, cn, newDims.Length, newDims);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region Row

        /// <summary>
        /// Mat row's indexer object
        /// </summary>
        public class RowIndexer : MatRowColIndexer
        {
            protected internal RowIndexer(Mat parent)
                : base(parent)
            {
            }
            /// <summary>
            /// Mat::row
            /// </summary>
            /// <param name="y"></param>
            /// <returns></returns>
            public override MatExpr this[int y]
            {
                get
                {
                    parent.ThrowIfDisposed();
                    try
                    {
                        IntPtr matExprPtr = CppInvoke.core_Mat_row_toMatExpr(parent.ptr, y);
                        MatExpr matExpr = new MatExpr(matExprPtr);
                        return matExpr;
                    }
                    catch (BadImageFormatException ex)
                    {
                        throw PInvokeHelper.CreateException(ex);
                    }
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value");
                    parent.ThrowIfDisposed();
                    try
                    {
                        IntPtr rowMatPtr = CppInvoke.core_Mat_row_toMat(parent.ptr, y);
                        CppInvoke.core_Mat_assignment_FromMatExpr(rowMatPtr, value.CvPtr);
                        CppInvoke.core_Mat_delete(rowMatPtr);
                    }
                    catch (BadImageFormatException ex)
                    {
                        throw PInvokeHelper.CreateException(ex);
                    }
                }
            }
            /// <summary>
            /// Mat::rowRange
            /// </summary>
            /// <param name="startRow"></param>
            /// <param name="endRow"></param>
            /// <returns></returns>
            public override MatExpr this[int startRow, int endRow]
            {
                get
                {
                    parent.ThrowIfDisposed();
                    try
                    {
                        IntPtr matExprPtr = CppInvoke.core_Mat_rowRange_toMatExpr(parent.ptr, startRow, endRow);
                        MatExpr matExpr = new MatExpr(matExprPtr);
                        return matExpr;
                    }
                    catch (BadImageFormatException ex)
                    {
                        throw PInvokeHelper.CreateException(ex);
                    }
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value");
                    parent.ThrowIfDisposed();
                    try
                    {
                        IntPtr rowMatPtr = CppInvoke.core_Mat_rowRange_toMat(parent.ptr, startRow, endRow);
                        CppInvoke.core_Mat_assignment_FromMatExpr(rowMatPtr, value.CvPtr);
                    }
                    catch (BadImageFormatException ex)
                    {
                        throw PInvokeHelper.CreateException(ex);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RowIndexer Row
        {
            get
            {
                if (row == null)
                    row = new RowIndexer(this);
                return row;
            }
        }
        private RowIndexer row = null;

        #endregion
        #region RowRange
        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startRow"></param>
        /// <param name="endRow"></param>
        /// <returns></returns>
        public Mat RowRange(int startRow, int endRow)
        {
            return Row[startRow, endRow];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Mat RowRange(Range range)
        {
            return Row[range];
        }
        */
        #endregion
        #region Rows

        /// <summary>
        /// 
        /// </summary>
        public int Rows
        {
            get
            {
                if (rowsVal == int.MinValue)
                {
                    try
                    {
                        rowsVal = CppInvoke.core_Mat_cols(ptr);
                    }
                    catch (BadImageFormatException ex)
                    {
                        throw PInvokeHelper.CreateException(ex);
                    }
                }
                return rowsVal;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Height
        {
            get
            {
                if (rowsVal == int.MinValue)
                {
                    rowsVal = Rows;
                }
                return rowsVal;
            }
        }

        private int rowsVal = int.MinValue;

        #endregion
        #region SetTo

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Mat SetTo(Scalar value)
        {
            return SetTo(value, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public Mat SetTo(Scalar value, Mat mask)
        {
            ThrowIfDisposed();
            try
            {
                IntPtr maskPtr = GetCvPtr(mask);
                IntPtr retPtr = CppInvoke.core_Mat_setTo(ptr, value, maskPtr);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Mat SetTo(Mat value)
        {
            return SetTo(value, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public Mat SetTo(Mat value, Mat mask)
        {
            ThrowIfDisposed();
            if (value == null)
                throw new ArgumentNullException("value");
            try
            {
                IntPtr maskPtr = GetCvPtr(mask);
                IntPtr retPtr = CppInvoke.core_Mat_setTo(ptr, value.CvPtr, maskPtr);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region Size

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Size Size()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_size(ptr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
        public int Size(int dim)
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_sizeAt(ptr, dim);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region Step

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long Step()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_step(ptr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public ulong Step(int i)
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_stepAt(ptr, i);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region Step1

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ulong Step1()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_step1(ptr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public ulong Step1(int i)
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_step1(ptr, i);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region SubMat

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowStart"></param>
        /// <param name="rowEnd"></param>
        /// <param name="colStart"></param>
        /// <param name="colEnd"></param>
        /// <returns></returns>
        public Mat SubMat(int rowStart, int rowEnd, int colStart, int colEnd)
        {
            if (rowStart >= rowEnd)
                throw new ArgumentException("rowStart >= rowEnd");
            if (colStart >= colEnd)
                throw new ArgumentException("colStart >= colEnd");

            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_subMat(ptr, rowStart, rowEnd, colStart, colEnd);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowRange"></param>
        /// <param name="colRange"></param>
        /// <returns></returns>
        public Mat SubMat(Range rowRange, Range colRange)
        {
            return SubMat(rowRange.Start, rowRange.End, colRange.Start, colRange.End);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roi"></param>
        /// <returns></returns>
        public Mat SubMat(Rect roi)
        {
            return SubMat(roi.Y, roi.Y + roi.Height, roi.X, roi.X + roi.Width);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ranges"></param>
        /// <returns></returns>
        public Mat SubMat(params Range[] ranges)
        {
            if (ranges == null)
                throw new ArgumentNullException();

            ThrowIfDisposed();
            try
            {
                CvSlice[] slices = new CvSlice[ranges.Length];
                for (int i = 0; i < ranges.Length; i++)
                {
                    slices[i] = ranges[i];
                }

                IntPtr retPtr = CppInvoke.core_Mat_subMat(ptr, slices.Length, slices);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region T

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Mat T()
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_t(ptr);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region Total

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ulong Total()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_total(ptr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region Type

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MatrixType Type()
        {
            ThrowIfDisposed();
            try
            {
                return (MatrixType)CppInvoke.core_Mat_type(ptr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region ToString

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Mat [ " +
                   Rows + "*" + Cols + "*" + CvType.TypeToString((int)Type()) +
                   ", IsContinuous=" + IsContinuous() + ", IsSubmatrix=" + IsSubmatrix() +
                   ", NativeObject=0x" + Convert.ToString(ptr.ToInt64(), 16) +
                   ", DataAddr=0x" + Convert.ToString(Data.ToInt64(), 16) +
                   " ]";
        }

        #endregion

        #region Dump

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Dump(DumpFormat format = DumpFormat.Default)
        {
            ThrowIfDisposed();
            try
            {
                string formatStr = GetDumpFormatString(format);
                unsafe
                {
                    sbyte* buf = CppInvoke.core_Mat_dump(ptr, formatStr);
                    string ret = new string(buf);
                    CppInvoke.core_Mat_dump_delete(buf);
                    return ret;
                }
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        private string GetDumpFormatString(DumpFormat format)
        {
            if (format == DumpFormat.Default)
                return null;

            string name = Enum.GetName(typeof (DumpFormat), format);
            if(name == null)
                throw new ArgumentException();
            return name.ToLower();
        }
        #endregion

        #region Ptr*D

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i0"></param>
        /// <returns></returns>
        public IntPtr Ptr(int i0)
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_ptr1d(ptr, i0);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i0"></param>
        /// <param name="i1"></param>
        /// <returns></returns>
        public IntPtr Ptr(int i0, int i1)
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_ptr2d(ptr, i0, i1);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i0"></param>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public IntPtr Ptr(int i0, int i1, int i2)
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_ptr3d(ptr, i0, i1, i2);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public IntPtr Ptr(params int[] idx)
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_ptrnd(ptr, idx);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region At

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract class IndexerBase<T> where T : struct
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <returns></returns>
            public abstract T this[int i0] { get; set; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <param name="i1"></param>
            /// <returns></returns>
            public abstract T this[int i0, int i1] { get; set; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <param name="i1"></param>
            /// <param name="i2"></param>
            /// <returns></returns>
            public abstract T this[int i0, int i1, int i2] { get; set; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="idx"></param>
            /// <returns></returns>
            public abstract T this[params int[] idx] { get; set; }

            protected readonly Mat parent;
            protected readonly long[] steps;

            internal IndexerBase(Mat parent)
            {
                this.parent = parent;

                int dims = parent.Dims;
                steps = new long[dims];
                for (int i = 0; i < dims; i++)
                {
                    steps[i] = (long)parent.Step(i);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public sealed class Indexer<T> : IndexerBase<T> where T : struct
        {
            private readonly long ptrVal;

            internal Indexer(Mat parent)
                : base(parent)
            {
                ptrVal = parent.Data.ToInt64();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <returns></returns>
            public override T this[int i0]
            {
                get
                {
                    IntPtr p = new IntPtr(ptrVal + (steps[0] * i0));
                    return (T)Marshal.PtrToStructure(p, typeof (T));
                }
                set
                {
                    IntPtr p = new IntPtr(ptrVal + (steps[0] * i0));
                    Marshal.StructureToPtr(value, p, false);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <param name="i1"></param>
            /// <returns></returns>
            public override T this[int i0, int i1]
            {
                get
                {
                    IntPtr p = new IntPtr(ptrVal + (steps[0] * i0) + (steps[1] * i1));
                    return (T)Marshal.PtrToStructure(p, typeof (T));
                }
                set
                {
                    IntPtr p = new IntPtr(ptrVal + (steps[0] * i0) + (steps[1] * i1));
                    Marshal.StructureToPtr(value, p, false);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <param name="i1"></param>
            /// <param name="i2"></param>
            /// <returns></returns>
            public override T this[int i0, int i1, int i2]
            {
                get
                {
                    IntPtr p = new IntPtr(ptrVal + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2));
                    return (T)Marshal.PtrToStructure(p, typeof (T));
                }
                set
                {
                    IntPtr p = new IntPtr(ptrVal + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2));
                    Marshal.StructureToPtr(value, p, false);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="idx"></param>
            /// <returns></returns>
            public override T this[params int[] idx]
            {
                get
                {
                    long offset = 0;
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    IntPtr p = new IntPtr(ptrVal + offset);
                    return (T)Marshal.PtrToStructure(p, typeof (T));
                }
                set
                {
                    long offset = 0;
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    IntPtr p = new IntPtr(ptrVal + offset);
                    Marshal.StructureToPtr(value, p, false);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Indexer<T> GetGenericIndexer<T>() where T : struct
        {
            return new Indexer<T>(this);
        }

        #endregion
        #region Get

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i0"></param>
        /// <returns></returns>
        public T Get<T>(int i0) where T : struct
        {
            return new Indexer<T>(this)[i0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i0"></param>
        /// <param name="i1"></param>
        /// <returns></returns>
        public T Get<T>(int i0, int i1) where T : struct
        {
            return new Indexer<T>(this)[i0, i1];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i0"></param>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public T Get<T>(int i0, int i1, int i2) where T : struct
        {
            return new Indexer<T>(this)[i0, i1, i2];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="idx"></param>
        /// <returns></returns>
        public T Get<T>(params int[] idx) where T : struct
        {
            return new Indexer<T>(this)[idx];
        }

        #endregion

        #endregion
    }

}

