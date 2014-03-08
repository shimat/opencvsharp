using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
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
            ptr = CppInvoke.core_Mat_new();
        }


        /// <summary>
        /// Loads an image from a file.
        /// </summary>
        /// <param name="fileName">Name of file to be loaded.</param>
        /// <param name="flags">Specifies color type of the loaded image</param>
        public Mat(string fileName, LoadMode flags = LoadMode.Color)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");
            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);
            ptr = CppInvoke.highgui_imread(fileName, (int)flags);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        public Mat(int rows, int cols, MatType type)
        {
            ptr = CppInvoke.core_Mat_new(rows, cols, (int)type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        public Mat(Size size, MatType type)
        {
            ptr = CppInvoke.core_Mat_new(size.Width, size.Height, type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        /// <param name="s"></param>
        public Mat(int rows, int cols, MatType type, Scalar s)
        {
            ptr = CppInvoke.core_Mat_new(rows, cols, type, s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <param name="s"></param>
        public Mat(Size size, MatType type, Scalar s)
        {
            ptr = CppInvoke.core_Mat_new(size.Width, size.Height, (int)type, s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="rowRange"></param>
        /// <param name="colRange"></param>
        public Mat(Mat m, Range rowRange, Range colRange)
        {
            ptr = CppInvoke.core_Mat_new(m.ptr, rowRange, colRange);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="rowRange"></param>
        public Mat(Mat m, Range rowRange)
        {
            ptr = CppInvoke.core_Mat_new(m.ptr, rowRange);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="roi"></param>
        public Mat(Mat m, Rect roi)
        {
            ptr = CppInvoke.core_Mat_new(m.ptr, roi);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="step"></param>
        public Mat(int rows, int cols, MatType type, IntPtr data, long step = 0)
        {
            ptr = CppInvoke.core_Mat_new(rows, cols, (int)type, data, new IntPtr(step));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="step"></param>
        public Mat(int rows, int cols, MatType type, Array data, long step = 0)
        {
            GCHandle handle = AllocGCHandle(data);
            ptr = CppInvoke.core_Mat_new(rows, cols, (int)type,
                handle.AddrOfPinnedObject(), new IntPtr(step));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sizes"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="steps"></param>
        public Mat(IEnumerable<int> sizes, MatType type, IntPtr data, IEnumerable<long> steps = null)
        {
            if (sizes == null)
                throw new ArgumentNullException("steps");
            if (data == IntPtr.Zero)
                throw new ArgumentNullException("data");
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sizes"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="steps"></param>
        public Mat(IEnumerable<int> sizes, MatType type, Array data, IEnumerable<long> steps = null)
        {
            if (sizes == null)
                throw new ArgumentNullException("steps");
            if (data == null)
                throw new ArgumentNullException("data");


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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="copyData"></param>
        public Mat(CvMat m, bool copyData = false)
        {
            if (m == null)
                throw new ArgumentNullException("m");
            m.ThrowIfDisposed();
            ptr = CppInvoke.core_Mat_new_FromCvMat(m.CvPtr, copyData ? 1 : 0);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="copyData"></param>
        public Mat(IplImage img, bool copyData = false)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            img.ThrowIfDisposed();
            ptr = CppInvoke.core_Mat_new_FromIplImage(img.CvPtr, copyData ? 1 : 0);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
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
        /// <summary>
        /// sizeof(cv::Mat)
        /// </summary>
        public static readonly int SizeOf = (int)CppInvoke.core_Mat_sizeof();

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
        public static MatExpr Eye(Size size, MatType type)
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
        public static MatExpr Eye(int rows, int cols, MatType type)
        {
            IntPtr retPtr = CppInvoke.core_Mat_eye(rows, cols, type);
            MatExpr retVal = new MatExpr(retPtr);
            return retVal;
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
        public static MatExpr Ones(int rows, int cols, MatType type)
        {
            IntPtr retPtr = CppInvoke.core_Mat_ones(rows, cols, type);
            MatExpr retVal = new MatExpr(retPtr);
            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MatExpr Ones(Size size, MatType type)
        {
            return Ones(size.Height, size.Width, type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="sizes"></param>
        /// <returns></returns>
        public static MatExpr Ones(MatType type, params int[] sizes)
        {
            if (sizes == null)
                throw new ArgumentNullException("sizes");
            /*
            IntPtr retPtr = CppInvoke.core_Mat_ones(sizes.Length, sizes, (int)type);
            MatExpr retVal = new MatExpr(retPtr);
            return retVal;
            */
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
        public static MatExpr Zeros(int rows, int cols, MatType type)
        {
            IntPtr retPtr = CppInvoke.core_Mat_zeros(rows, cols, type);
            MatExpr retVal = new MatExpr(retPtr);
            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MatExpr Zeros(Size size, MatType type)
        {
            return Zeros(size.Height, size.Width, type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="sizes"></param>
        /// <returns></returns>
        public static MatExpr Zeros(MatType type, params int[] sizes)
        {
            if (sizes == null)
                throw new ArgumentNullException("sizes");
            /*
            IntPtr retPtr = CppInvoke.core_Mat_zeros(sizes.Length, sizes, (int)type);
            MatExpr retVal = new MatExpr(retPtr);
            return retVal;
            */
            throw new NotImplementedException();
        }

        #endregion
        #endregion

        #region Operators
        #region Cast

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

            IntPtr imgPtr;
            CppInvoke.core_Mat_IplImage_alignment(ptr, out imgPtr);
            return new IplImage(imgPtr);
            /*
            // キャストの結果を参考に使う.
            // メモリ管理の問題から、直接は使わない.
            IplImage dummy = new IplImage(false);
            CppInvoke.core_Mat_IplImage(ptr, dummy.CvPtr);

            // alignmentをそろえる
            IplImage img = new IplImage(dummy.Size, dummy.Depth, dummy.NChannels);
            int height = img.Height;
            int sstep = (int)Step();
            int dstep = img.WidthStep;
            for (int i = 0; i < height; ++i)
            {
                IntPtr dp = new IntPtr(img.ImageData.ToInt64() + (dstep * i));
                IntPtr sp = new IntPtr(Data.ToInt64() + (sstep * i));
                Util.CopyMemory(dp, sp, sstep);
            }
            return img;*/
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

            CvMat mat = new CvMat(false);
            CppInvoke.core_Mat_CvMat(ptr, mat.CvPtr);
            return mat;
        }

        #endregion
        #region Arithmetic
        #region Unary
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static MatExpr operator -(Mat mat)
        {
            IntPtr expr = CppInvoke.core_operatorUnaryMinus_Mat(mat.CvPtr);
            return new MatExpr(expr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static Mat operator +(Mat mat)
        {
            return mat;
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

            IntPtr retPtr = CppInvoke.core_operatorAdd_MatMat(a.CvPtr, b.CvPtr);
            return new MatExpr(retPtr);
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
            
            IntPtr retPtr = CppInvoke.core_operatorAdd_MatScalar(a.CvPtr, s);
            return new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_operatorAdd_ScalarMat(s, a.CvPtr);
            return new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_operatorSubtract_MatMat(a.CvPtr, b.CvPtr);
            return new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_operatorSubtract_MatScalar(a.CvPtr, s);
            return new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_operatorSubtract_ScalarMat(s, a.CvPtr);
            return new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_operatorMultiply_MatMat(a.CvPtr, b.CvPtr);
            return new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_operatorMultiply_MatDouble(a.CvPtr, s);
            return new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_operatorMultiply_DoubleMat(s, a.CvPtr);
            return new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_operatorDivide_MatMat(a.CvPtr, b.CvPtr);
            return new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_operatorDivide_MatDouble(a.CvPtr, s);
            return new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_operatorDivide_DoubleMat(s, a.CvPtr);
            return new MatExpr(retPtr);
        }

        #endregion
        #region Comparison
#pragma warning disable 1591
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
#pragma warning restore 1591
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
            IntPtr retPtr = CppInvoke.core_operatorAnd_MatMat(a.CvPtr, b.CvPtr);
            return new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_operatorAnd_MatDouble(a.CvPtr, s);
            return new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_operatorAnd_DoubleMat(s, a.CvPtr);
            return new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_operatorOr_MatMat(a.CvPtr, b.CvPtr);
            return new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_operatorOr_MatDouble(a.CvPtr, s);
            return new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_operatorOr_DoubleMat(s, a.CvPtr);
            return new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_operatorXor_MatMat(a.CvPtr, b.CvPtr);
            return new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_operatorXor_MatDouble(a.CvPtr, s);
            return new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_operatorXor_DoubleMat(s, a.CvPtr);
            return new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_operatorNot_Mat(m.CvPtr);
            return new MatExpr(retPtr);
        }

        #endregion
        #endregion
        #endregion
        #endregion

        #region Public Methods
        #region Indexers
        #region SubMat
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
        #region Col
        /// <summary>
        /// Mat column's indexer object
        /// </summary>
        public class ColIndexer : MatRowColIndexer
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="parent"></param>
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
                    IntPtr matExprPtr = CppInvoke.core_Mat_col_toMatExpr(parent.ptr, x);
                    MatExpr matExpr = new MatExpr(matExprPtr);
                    return matExpr;
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value");
                    parent.ThrowIfDisposed();
                    IntPtr colMatPtr = CppInvoke.core_Mat_col_toMat(parent.ptr, x);
                    CppInvoke.core_Mat_assignment_FromMatExpr(colMatPtr, value.CvPtr);
                    CppInvoke.core_Mat_delete(colMatPtr);
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
                    IntPtr matExprPtr = CppInvoke.core_Mat_colRange_toMatExpr(parent.ptr, startCol, endCol);
                    MatExpr matExpr = new MatExpr(matExprPtr);
                    return matExpr;
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value");
                    parent.ThrowIfDisposed();
                    IntPtr colMatPtr = CppInvoke.core_Mat_colRange_toMat(parent.ptr, startCol, endCol);
                    CppInvoke.core_Mat_assignment_FromMatExpr(colMatPtr, value.CvPtr);
                    CppInvoke.core_Mat_delete(colMatPtr);
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
                if (colIndexer == null)
                    colIndexer = new ColIndexer(this);
                return colIndexer;
            }
        }
        private ColIndexer colIndexer = null;
        #endregion
        #region Row

        /// <summary>
        /// Mat row's indexer object
        /// </summary>
        public class RowIndexer : MatRowColIndexer
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="parent"></param>
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
                    IntPtr matExprPtr = CppInvoke.core_Mat_row_toMatExpr(parent.ptr, y);
                    MatExpr matExpr = new MatExpr(matExprPtr);
                    return matExpr;
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value");
                    parent.ThrowIfDisposed();
                    IntPtr rowMatPtr = CppInvoke.core_Mat_row_toMat(parent.ptr, y);
                    CppInvoke.core_Mat_assignment_FromMatExpr(rowMatPtr, value.CvPtr);
                    CppInvoke.core_Mat_delete(rowMatPtr);
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
                    IntPtr matExprPtr = CppInvoke.core_Mat_rowRange_toMatExpr(parent.ptr, startRow, endRow);
                    MatExpr matExpr = new MatExpr(matExprPtr);
                    return matExpr;
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value");
                    parent.ThrowIfDisposed();
                    IntPtr rowMatPtr = CppInvoke.core_Mat_rowRange_toMat(parent.ptr, startRow, endRow);
                    CppInvoke.core_Mat_assignment_FromMatExpr(rowMatPtr, value.CvPtr);
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
                if (rowIndexer == null)
                    rowIndexer = new RowIndexer(this);
                return rowIndexer;
            }
        }
        private RowIndexer rowIndexer = null;

        #endregion
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
            IntPtr retPtr = CppInvoke.core_Mat_adjustROI(ptr, dtop, dbottom, dleft, dright);
            Mat retVal = new Mat(retPtr);
            return retVal;
        }

        #endregion
        #region AssignTo

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="type"></param>
        public void AssignTo(Mat m, MatType type)
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
            CppInvoke.core_Mat_assignTo(ptr, m.CvPtr);
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
            return CppInvoke.core_Mat_channels(ptr);
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
            return CppInvoke.core_Mat_checkVector(ptr, elemChannels);
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
            return CppInvoke.core_Mat_checkVector(ptr, elemChannels, depth);
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
            return CppInvoke.core_Mat_checkVector(
                    ptr, elemChannels, depth, requireContinuous ? 1 : 0);
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
        #region Dims

        /// <summary>
        /// 
        /// </summary>
        public int Dims
        {
            get
            {
                ThrowIfDisposed();
                return CppInvoke.core_Mat_dims(ptr);
            }
        }

        #endregion
        #region ConvertTo

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="rtype"></param>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        public void ConvertTo(Mat m, MatType rtype, double alpha = 1, double beta = 0)
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
            IntPtr maskPtr = Cv2.ToPtr(mask);
            CppInvoke.core_Mat_copyTo(ptr, m.CvPtr, maskPtr);
        }

        #endregion
        #region Create

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        public void Create(int rows, int cols, MatType type)
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
        public void Create(Size size, MatType type)
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
            m.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_Mat_mul(ptr, m.CvPtr);
            MatExpr retVal = new MatExpr(retPtr);
            return retVal;
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
            CppInvoke.core_Mat_push_back(ptr, m.CvPtr);
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
        /// <param name="cn"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public Mat Reshape(int cn, int rows)
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_reshape(ptr, cn, rows);
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
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

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
                        rowsVal = CppInvoke.core_Mat_rows(ptr);
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
            IntPtr maskPtr = Cv2.ToPtr(mask);
            IntPtr retPtr = CppInvoke.core_Mat_setTo(ptr, value, maskPtr);
            Mat retVal = new Mat(retPtr);
            return retVal;
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
            IntPtr maskPtr = Cv2.ToPtr(mask);
            IntPtr retPtr = CppInvoke.core_Mat_setTo(ptr, value.CvPtr, maskPtr);
            Mat retVal = new Mat(retPtr);
            return retVal;
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
        public MatType Type()
        {
            ThrowIfDisposed();
            return (MatType)CppInvoke.core_Mat_type(ptr);
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
                   Rows + "*" + Cols + "*" + Type().ToString() +
                   ", IsContinuous=" + IsContinuous() + ", IsSubmatrix=" + IsSubmatrix() +
                   ", Ptr=0x" + Convert.ToString(ptr.ToInt64(), 16) +
                   ", Data=0x" + Convert.ToString(Data.ToInt64(), 16) +
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
            string formatStr = GetDumpFormatString(format);
            unsafe
            {
                sbyte* buf = CppInvoke.core_Mat_dump(ptr, formatStr);
                string ret = new string(buf);
                CppInvoke.core_Mat_dump_delete(buf);
                return ret;
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
            return CppInvoke.core_Mat_ptr1d(ptr, i0);
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
            return CppInvoke.core_Mat_ptr2d(ptr, i0, i1);
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
            return CppInvoke.core_Mat_ptr3d(ptr, i0, i1, i2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public IntPtr Ptr(params int[] idx)
        {
            ThrowIfDisposed();
            return CppInvoke.core_Mat_ptrnd(ptr, idx);
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

            /// <summary>
            /// 
            /// </summary>
            protected readonly Mat parent;
            /// <summary>
            /// 
            /// </summary>
            protected readonly long[] steps;
            /// <summary>
            /// 
            /// </summary>
            /// <param name="parent"></param>
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
                    return (T)Marshal.PtrToStructure(p, typeof(T));
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
                    return (T)Marshal.PtrToStructure(p, typeof(T));
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
        #region Get/Set

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

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i0"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Set<T>(int i0, T value) where T : struct
        {
            (new Indexer<T>(this))[i0] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i0"></param>
        /// <param name="i1"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Set<T>(int i0, int i1, T value) where T : struct
        {
            (new Indexer<T>(this))[i0, i1] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i0"></param>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Set<T>(int i0, int i1, int i2, T value) where T : struct
        {
            (new Indexer<T>(this)[i0, i1, i2]) = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="idx"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Set<T>(int[] idx, T value) where T : struct
        {
            (new Indexer<T>(this)[idx]) = value;
        }

        #endregion
        #region GetCol/GetColRange

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Mat GetCol(int x)
        {
            ThrowIfDisposed();
            IntPtr matPtr = CppInvoke.core_Mat_col_toMat(ptr, x);
            return new Mat(matPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startCol"></param>
        /// <param name="endCol"></param>
        /// <returns></returns>
        public Mat GetColRange(int startCol, int endCol)
        {
            ThrowIfDisposed();
            IntPtr matPtr = CppInvoke.core_Mat_colRange_toMat(ptr, startCol, endCol);
            return new Mat(matPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Mat GetColRange(Range range)
        {
            return GetColRange(range.Start, range.End);
        }

        #endregion
        #region GetRow/GetRowRange

        /// <summary>
        /// 
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public Mat GetRow(int y)
        {
            ThrowIfDisposed();
            IntPtr matPtr = CppInvoke.core_Mat_row_toMat(ptr, y);
            return new Mat(matPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startRow"></param>
        /// <param name="endRow"></param>
        /// <returns></returns>
        public Mat GetRowRange(int startRow, int endRow)
        {
            ThrowIfDisposed();
            IntPtr matPtr = CppInvoke.core_Mat_rowRange_toMat(ptr, startRow, endRow);
            return new Mat(matPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Mat GetRowRange(Range range)
        {
            return GetRowRange(range.Start, range.End);
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
        #region GetArray
        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, params byte[] data)
        {
            ThrowIfDisposed();
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException("row");
            if (col < 0 || col >= Cols)
                throw new ArgumentOutOfRangeException("col");
            if (data == null)
                throw new ArgumentNullException("data");

            MatType t = Type();
            if (data == null || data.Length % t.Channels != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    data.Length, t.Channels);
            if (t.Depth != MatType.CV_8U && t.Depth != MatType.CV_8S)
                throw new OpenCvSharpException("Mat data type is not compatible: " + t);
            CppInvoke.core_Mat_nGetB(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, short[] data)
        {
            ThrowIfDisposed();
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException("row");
            if (col < 0 || col >= Cols)
                throw new ArgumentOutOfRangeException("col");
            if (data == null)
                throw new ArgumentNullException("data");

            MatType t = Type();
            if (data == null || data.Length % t.Channels != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    data.Length, t.Channels);
            if (t.Depth != MatType.CV_16U && t.Depth != MatType.CV_16S)
                throw new OpenCvSharpException("Mat data type is not compatible: " + t);
            CppInvoke.core_Mat_nGetS(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, int[] data)
        {
            ThrowIfDisposed();
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException("row");
            if (col < 0 || col >= Cols)
                throw new ArgumentOutOfRangeException("col");
            if (data == null)
                throw new ArgumentNullException("data");

            MatType t = Type();
            if (data == null || data.Length % t.Channels != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    data.Length, t.Channels);
            if (t.Depth != MatType.CV_32S)
                throw new OpenCvSharpException("Mat data type is not compatible: " + t);
            CppInvoke.core_Mat_nGetI(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, float[] data)
        {
            ThrowIfDisposed();
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException("row");
            if (col < 0 || col >= Cols)
                throw new ArgumentOutOfRangeException("col");
            if (data == null)
                throw new ArgumentNullException("data");

            MatType t = Type();
            if (data == null || data.Length % t.Channels != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    data.Length, t.Channels);
            if (t.Depth != MatType.CV_32F)
                throw new OpenCvSharpException("Mat data type is not compatible: " + t);
            CppInvoke.core_Mat_nGetF(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, double[] data)
        {
            ThrowIfDisposed();
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException("row");
            if (col < 0 || col >= Cols)
                throw new ArgumentOutOfRangeException("col");
            if (data == null)
                throw new ArgumentNullException("data");

            MatType t = Type();
            if (data == null || data.Length % t.Channels != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    data.Length, t.Channels);
            if (t.Depth != MatType.CV_64F)
                throw new OpenCvSharpException("Mat data type is not compatible: " + t);
            CppInvoke.core_Mat_nGetD(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public double[] GetArray(int row, int col)
        {
            ThrowIfDisposed();
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException("row");
            if (col < 0 || col >= Cols)
                throw new ArgumentOutOfRangeException("col");

            double[] ret = new double[Channels()];
            CppInvoke.core_Mat_nGetD(ptr, row, col, ret, ret.Length);
            return ret;
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Vec3b[] data)
        {
            ThrowIfDisposed();
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException("row");
            if (col < 0 || col >= Cols)
                throw new ArgumentOutOfRangeException("col");
            if (data == null)
                throw new ArgumentNullException("data");

            MatType t = Type();
            if (data == null || data.Length % t.Channels != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    data.Length, t.Channels);
            if (t != MatType.CV_8UC3)
                throw new OpenCvSharpException("Mat data type is not compatible: " + t);
            CppInvoke.core_Mat_nGetVec3b(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point[] data)
        {
            ThrowIfDisposed();
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException("row");
            if (col < 0 || col >= Cols)
                throw new ArgumentOutOfRangeException("col");
            if (data == null)
                throw new ArgumentNullException("data");

            MatType t = Type();
            if (data == null || data.Length % t.Channels != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    data.Length, t.Channels);
            if (t != MatType.CV_32SC2)
                throw new OpenCvSharpException("Mat data type is not compatible: " + t);
            CppInvoke.core_Mat_nGetPoint(ptr, row, col, data, data.Length);
        }

        #endregion
        #region SetArray
        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params byte[] data)
        {
            ThrowIfDisposed();
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException("row");
            if (col < 0 || col >= Cols)
                throw new ArgumentOutOfRangeException("col");
            if (data == null)
                throw new ArgumentNullException("data");

            MatType t = Type();
            if (data == null || data.Length % t.Channels != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    data.Length, t.Channels);
            if (t.Depth != MatType.CV_8U && t.Depth != MatType.CV_8S)
                throw new OpenCvSharpException("Mat data type is not compatible: " + t);
            CppInvoke.core_Mat_nSetB(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params short[] data)
        {
            ThrowIfDisposed();
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException("row");
            if (col < 0 || col >= Cols)
                throw new ArgumentOutOfRangeException("col");
            if (data == null)
                throw new ArgumentNullException("data");

            MatType t = Type();
            if (data == null || data.Length % t.Channels != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    data.Length, t.Channels);
            if (t.Depth != MatType.CV_16U && t.Depth != MatType.CV_16S)
                throw new OpenCvSharpException("Mat data type is not compatible: " + t);
            CppInvoke.core_Mat_nSetS(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params int[] data)
        {
            ThrowIfDisposed();
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException("row");
            if (col < 0 || col >= Cols)
                throw new ArgumentOutOfRangeException("col");
            if (data == null)
                throw new ArgumentNullException("data");

            MatType t = Type();
            if (data == null || data.Length % t.Channels != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    data.Length, t.Channels);
            if (t.Depth != MatType.CV_32S)
                throw new OpenCvSharpException("Mat data type is not compatible: " + t);
            CppInvoke.core_Mat_nSetI(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params float[] data)
        {
            ThrowIfDisposed();
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException("row");
            if (col < 0 || col >= Cols)
                throw new ArgumentOutOfRangeException("col");
            if (data == null)
                throw new ArgumentNullException("data");

            MatType t = Type();
            if (data == null || data.Length % t.Channels != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    data.Length, t.Channels);
            if (t.Depth != MatType.CV_32F)
                throw new OpenCvSharpException("Mat data type is not compatible: " + t);
            CppInvoke.core_Mat_nSetF(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params double[] data)
        {
            ThrowIfDisposed();
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException("row");
            if (col < 0 || col >= Cols)
                throw new ArgumentOutOfRangeException("col");
            if (data == null)
                throw new ArgumentNullException("data");

            MatType t = Type();
            if (data.Length % t.Channels != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    data.Length, t.Channels);
            CppInvoke.core_Mat_nSetD(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params Vec3b[] data)
        {
            ThrowIfDisposed();
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException("row");
            if (col < 0 || col >= Cols)
                throw new ArgumentOutOfRangeException("col");
            if (data == null)
                throw new ArgumentNullException("data");

            MatType t = Type();
            if (data == null || data.Length % t.Channels != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    data.Length, t.Channels);
            if (t != MatType.CV_8UC3)
                throw new OpenCvSharpException("Mat data type is not compatible: " + t);
            CppInvoke.core_Mat_nSetVec3b(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params Point[] data)
        {
            ThrowIfDisposed();
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException("row");
            if (col < 0 || col >= Cols)
                throw new ArgumentOutOfRangeException("col");
            if (data == null)
                throw new ArgumentNullException("data");

            MatType t = Type();
            if (data == null || data.Length % t.Channels != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    data.Length, t.Channels);
            if (t != MatType.CV_32SC2)
                throw new OpenCvSharpException("Mat data type is not compatible: " + t);
            CppInvoke.core_Mat_nSetPoint(ptr, row, col, data, data.Length);
        }
        #endregion
        

        #region ToBitmap

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Bitmap ToBitmap()
        {
            return ToBitmap(".png");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ext"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public Bitmap ToBitmap(string ext, params ImageEncodingParam[] prms)
        {
            byte[] imageBytes;
            Cv2.ImEncode(ext, this, out imageBytes, prms);
            using (MemoryStream stream = new MemoryStream(imageBytes))
            {
                return new Bitmap(stream);
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public Mat Alignment(int n = 4)
        {
            int newCols = Cv2.AlignSize(Cols, n);
            Mat pMat = new Mat(Rows, newCols, Type());
            Mat roiMat = new Mat(pMat, new Rect(0, 0, Cols, Rows));
            CopyTo(roiMat);
            return roiMat;
        }

        #endregion

        #region Cv2 Methods

        #region Line
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="pt1X">線分の1番目の端点x</param>
        /// <param name="pt1Y">線分の1番目の端点y</param>
        /// <param name="pt2X">線分の2番目の端点x</param>
        /// <param name="pt2Y">線分の2番目の端点y</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ. [既定値は1]</param>
        /// <param name="lineType">線分の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. [By default this is 1]</param>
        /// <param name="lineType">Type of the line. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public void Line(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color,
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Line(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ. [既定値は1]</param>
        /// <param name="lineType">線分の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. [By default this is 1]</param>
        /// <param name="lineType">Type of the line. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public void Line(Point pt1, Point pt2, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Line(this, pt1, pt2, color, thickness, lineType, shift);
        }
        #endregion
        #region Rectangle
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値を指定した場合は塗りつぶされる. [既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values make the function to draw a filled rectangle. [By default this is 1]</param>
        /// <param name="lineType">Type of the line, see cvLine description. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public void Rectangle(Point pt1, Point pt2, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Rectangle(this, pt1, pt2, color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値を指定した場合は塗りつぶされる. [既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values make the function to draw a filled rectangle. [By default this is 1]</param>
        /// <param name="lineType">Type of the line, see cvLine description. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public void Rectangle(Rect rect, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Rectangle(this, rect, color, thickness, lineType, shift);
        }
        #endregion
        #region Circle
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="centerX">円の中心のx座標</param>
        /// <param name="centerY">円の中心のy座標</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．[既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">中心座標と半径の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="centerX">X-coordinate of the center of the circle. </param>
        /// <param name="centerY">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. [By default this is 1]</param>
        /// <param name="lineType">Type of the circle boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. [By default this is 0]</param>
#endif
        public void Circle(int centerX, int centerY, int radius, Scalar color,
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Circle(this, centerX, centerY, radius, color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="center">円の中心</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．[既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">中心座標と半径の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. [By default this is 1]</param>
        /// <param name="lineType">Type of the circle boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. [By default this is 0]</param>
#endif
        public void Circle(Point center, int radius, Scalar color,
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Circle(this, center, radius, color, thickness, lineType, shift);
        }
        #endregion
        #region Ellipse
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，楕円弧，もしくは塗りつぶされた扇形の楕円を描画する
        /// </summary>
        /// <param name="center">楕円の中心</param>
        /// <param name="axes">楕円の軸の長さ</param>
        /// <param name="angle">回転角度</param>
        /// <param name="startAngle">楕円弧の開始角度</param>
        /// <param name="endAngle">楕円弧の終了角度</param>
        /// <param name="color">楕円の色</param>
        /// <param name="thickness">楕円弧の線の幅 [既定値は1]</param>
        /// <param name="lineType">楕円弧の線の種類 [既定値はLineType.Link8]</param>
        /// <param name="shift">中心座標と軸の長さの小数点以下の桁を表すビット数 [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="center">Center of the ellipse. </param>
        /// <param name="axes">Length of the ellipse axes. </param>
        /// <param name="angle">Rotation angle. </param>
        /// <param name="startAngle">Starting angle of the elliptic arc. </param>
        /// <param name="endAngle">Ending angle of the elliptic arc. </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse arc. [By default this is 1]</param>
        /// <param name="lineType">Type of the ellipse boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and axes' values. [By default this is 0]</param>
#endif
        public void Ellipse(Point center, Size axes, double angle, double startAngle, double endAngle, Scalar color,
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Ellipse(this, center, axes, angle, startAngle, endAngle, color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，もしくは塗りつぶされた楕円を描画する
        /// </summary>
        /// <param name="box">描画したい楕円を囲む矩形領域．</param>
        /// <param name="color">楕円の色．</param>
        /// <param name="thickness">楕円境界線の幅．[既定値は1]</param>
        /// <param name="lineType">楕円境界線の種類．[既定値はLineType.Link8]</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="box">The enclosing box of the ellipse drawn </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse boundary. [By default this is 1]</param>
        /// <param name="lineType">Type of the ellipse boundary. [By default this is LineType.Link8]</param>
#endif
        public void Ellipse(RotatedRect box, Scalar color,
            int thickness = 1, LineType lineType = LineType.Link8)
        {
            Cv2.Ellipse(this, box, color, thickness, lineType);
        }
        #endregion
        #region FillConvexPoly
#if LANG_JP
        /// <summary>
        /// 塗りつぶされた凸ポリゴンを描きます．
        /// </summary>
        /// <param name="pts">ポリゴンの頂点．</param>
        /// <param name="color">ポリゴンの色．</param>
        /// <param name="lineType">ポリゴンの枠線の種類，</param>
        /// <param name="shift">ポリゴンの頂点座標において，小数点以下の桁を表すビット数．</param>
#else
        /// <summary>
        /// Fills a convex polygon.
        /// </summary>
        /// <param name="pts">The polygon vertices</param>
        /// <param name="color">Polygon color</param>
        /// <param name="lineType">Type of the polygon boundaries</param>
        /// <param name="shift">The number of fractional bits in the vertex coordinates</param>
#endif
        public void FillConvexPoly(IEnumerable<Point> pts, Scalar color,
            LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.FillConvexPoly(this, pts, color, lineType, shift);
        }
        #endregion
        #region FillPoly
#if LANG_JP
        /// <summary>
        /// 1つ，または複数のポリゴンで区切られた領域を塗りつぶします．
        /// </summary>
        /// <param name="pts">ポリゴンの配列．各要素は，点の配列で表現されます．</param>
        /// <param name="color">ポリゴンの色．</param>
        /// <param name="lineType">ポリゴンの枠線の種類，</param>
        /// <param name="shift">ポリゴンの頂点座標において，小数点以下の桁を表すビット数．</param>
        /// <param name="offset"></param>
#else
        /// <summary>
        /// Fills the area bounded by one or more polygons
        /// </summary>
        /// <param name="pts">Array of polygons, each represented as an array of points</param>
        /// <param name="color">Polygon color</param>
        /// <param name="lineType">Type of the polygon boundaries</param>
        /// <param name="shift">The number of fractional bits in the vertex coordinates</param>
        /// <param name="offset"></param>
#endif
        public void FillPoly(IEnumerable<IEnumerable<Point>> pts, Scalar color,
            LineType lineType = LineType.Link8, int shift = 0, Point? offset = null)
        {
            Cv2.FillPoly(this, pts, color, lineType, shift, offset);
        }
        #endregion
        #region Polylines
        /// <summary>
        /// draws one or more polygonal curves
        /// </summary>
        /// <param name="pts"></param>
        /// <param name="isClosed"></param>
        /// <param name="color"></param>
        /// <param name="thickness"></param>
        /// <param name="lineType"></param>
        /// <param name="shift"></param>
        public void Polylines(IEnumerable<IEnumerable<Point>> pts, bool isClosed, Scalar color,
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Polylines(this, pts, isClosed, color, thickness, lineType, shift);
        }
        #endregion
        #region PutText
        /// <summary>
        /// renders text string in the image
        /// </summary>
        /// <param name="text"></param>
        /// <param name="org"></param>
        /// <param name="fontFace"></param>
        /// <param name="fontScale"></param>
        /// <param name="color"></param>
        /// <param name="thickness"></param>
        /// <param name="lineType"></param>
        /// <param name="bottomLeftOrigin"></param>
        public void PutText(string text, Point org,
            FontFace fontFace, double fontScale, Scalar color,
            int thickness = 1, 
            LineType lineType = LineType.Link8, 
            bool bottomLeftOrigin = false)
        {
            Cv2.PutText(this, text, org, fontFace, fontScale, color, thickness, lineType, bottomLeftOrigin);
        }
        #endregion
        #region ImWrite
        /// <summary>
        /// Saves an image to a specified file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public bool ImWrite(string fileName, int[] prms = null)
        {
            return Cv2.ImWrite(fileName, this, prms);
        }
        /// <summary>
        /// Saves an image to a specified file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public bool ImWrite(string fileName, params ImageEncodingParam[] prms)
        {
            return Cv2.ImWrite(fileName, this, prms);
        }
        #endregion

        #endregion
    }

}

