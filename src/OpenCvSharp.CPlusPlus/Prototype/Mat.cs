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
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        public Mat(int rows, int cols, MatrixType type)
        {
            ptr = CppInvoke.core_Mat_new(rows, cols, (int)type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        public Mat(Size size, int type)
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
        public Mat(int rows, int cols, int type, Scalar s)
        {
            ptr = CppInvoke.core_Mat_new(rows, cols, type, s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <param name="s"></param>
        public Mat(Size size, int type, Scalar s)
        {
            ptr = CppInvoke.core_Mat_new(size.Width, size.Height, type, s);
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
            if (!IsDisposed)
            {
                // releases managed resources
                if (disposing)
                {
                }
                // releases unmanaged resources
                CppInvoke.core_Mat_delete(ptr);
                //CppInvoke.core_Mat_release(ptr);
                ptr = IntPtr.Zero;
                IsDisposed = true;
            }
        }

        #endregion

        #region Public Methods
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
            try
            {
                CppInvoke.core_Mat_assignTo(ptr, m.CvPtr, (int) type);
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Mat Col(int x)
        {
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_col(ptr, x);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
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
                if (cols == int.MinValue)
                {
                    try
                    {
                        cols = CppInvoke.core_Mat_cols(ptr);
                    }
                    catch (BadImageFormatException ex)
                    {
                        throw PInvokeHelper.CreateException(ex);
                    }
                }
                return cols;
            }
        }
        private int cols = int.MinValue;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startcol"></param>
        /// <param name="endcol"></param>
        /// <returns></returns>
        public Mat ColRange(int startcol, int endcol)
        {
            return ColRange(new Range(startcol, endcol));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public Mat ColRange(Range r)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_colRange(ptr, r.Start, r.End));
            //return retVal;
        }

        // javadoc: Mat::dims()
        public int Dims()
        {
            throw new NotImplementedException();
            //int retVal = n_dims(ptr);
            //return retVal;
        }

        // javadoc: Mat::convertTo(m, rtype, alpha, beta)
        public void ConvertTo(Mat m, int rtype, double alpha, double beta)
        {
            throw new NotImplementedException();
            //n_convertTo(ptr, m.ptr, rtype, alpha, beta);
        }

        // javadoc: Mat::convertTo(m, rtype, alpha)
        public void ConvertTo(Mat m, int rtype, double alpha)
        {
            throw new NotImplementedException();
            //n_convertTo(ptr, m.ptr, rtype, alpha);
        }

        // javadoc: Mat::convertTo(m, rtype)
        public void ConvertTo(Mat m, int rtype)
        {
            throw new NotImplementedException();
            //n_convertTo(ptr, m.ptr, rtype);
        }

        // javadoc: Mat::copyTo(m)
        public void CopyTo(Mat m)
        {
            throw new NotImplementedException();
            //n_copyTo(ptr, m.ptr);
        }

        // javadoc: Mat::copyTo(m, mask)
        public void CopyTo(Mat m, Mat mask)
        {
            throw new NotImplementedException();
            //n_copyTo(ptr, m.ptr, mask.ptr);
        }

        // javadoc: Mat::create(rows, cols, type)
        public void Create(int rows, int cols, int type)
        {
            throw new NotImplementedException();
            //n_create(ptr, rows, cols, type);
        }

        // javadoc: Mat::create(size, type)
        public void Create(Size size, int type)
        {
            throw new NotImplementedException();
            //n_create(ptr, size.Width, size.Height, type);
        }

        // javadoc: Mat::cross(m)
        public Mat Cross(Mat m)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_cross(ptr, m.ptr));
            //return retVal;
        }

        // javadoc: Mat::dataAddr()
        public IntPtr DataAddr()
        {
            throw new NotImplementedException();
            //IntPtr retVal = n_dataAddr(ptr);
            //return retVal;
        }

        // javadoc: Mat::depth()
        public int Depth()
        {
            throw new NotImplementedException();
            //int retVal = n_depth(ptr);
            //return retVal;
        }

        // javadoc: Mat::diag(d)
        public Mat Diag(int d)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_diag(ptr, d));
            //return retVal;
        }

        // javadoc: Mat::diag()
        public Mat Diag()
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_diag(ptr, 0));
            //return retVal;
        }

        // javadoc: Mat::diag(d)
        public static Mat Diag(Mat d)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_diag(d.ptr));
            //return retVal;
        }

        // javadoc: Mat::dot(m)
        public double Dot(Mat m)
        {
            throw new NotImplementedException();
            //double retVal = n_dot(ptr, m.ptr);
            //return retVal;
        }

        // javadoc: Mat::elemSize()
        public long ElemSize()
        {
            throw new NotImplementedException();
            //long retVal = n_elemSize(ptr);
            //return retVal;
        }

        // javadoc: Mat::elemSize1()
        public long ElemSize1()
        {
            throw new NotImplementedException();
            //long retVal = n_elemSize1(ptr);
            //return retVal;
        }

        // javadoc: Mat::empty()
        public bool Empty()
        {
            throw new NotImplementedException();
            //bool retVal = n_empty(ptr);
            //return retVal;
        }

        // javadoc: Mat::eye(rows, cols, type)
        public static Mat Eye(int rows, int cols, int type)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_eye(rows, cols, type));
            //return retVal;
        }

        // javadoc: Mat::eye(size, type)
        public static Mat Eye(Size size, int type)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_eye(size.Width, size.Height, type));
            //return retVal;
        }

        // javadoc: Mat::inv(method)
        public Mat Inv(int method)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_inv(ptr, method));
            //return retVal;
        }

        // javadoc: Mat::inv()
        public Mat Inv()
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_inv(ptr));
            //return retVal;
        }

        // javadoc: Mat::isContinuous()
        public bool IsContinuous()
        {
            throw new NotImplementedException();
            //bool retVal = n_isContinuous(ptr);
            //return retVal;
        }

        // javadoc: Mat::isSubmatrix()
        public bool IsSubmatrix()
        {
            throw new NotImplementedException();
            //bool retVal = n_isSubmatrix(ptr);
            //return retVal;
        }

        // javadoc: Mat::locateROI(wholeSize, ofs)
        public void LocateROI(Size wholeSize, Point ofs)
        {
            /*double[] wholeSizeOut = new double[2];
            double[] ofsOut = new double[2];
            locateROI_0(ptr, wholeSizeOut, ofsOut);
            wholeSize.Width = wholeSizeOut[0];
            wholeSize.Height = wholeSizeOut[1];
            ofs.X = ofsOut[0];
            ofs.Y = ofsOut[1];*/
            throw new NotImplementedException();
        }
 
        // javadoc: Mat::mul(m, scale)
        public Mat Mul(Mat m, double scale)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_mul(ptr, m.ptr, scale));
            //return retVal;
        }

        // javadoc: Mat::mul(m)
        public Mat Mul(Mat m)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_mul(ptr, m.ptr));
            //return retVal;
        }

        // javadoc: Mat::ones(rows, cols, type)
        public static Mat Ones(int rows, int cols, int type)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_ones(rows, cols, type));
            //return retVal;
        }

        // javadoc: Mat::ones(size, type)
        public static Mat Ones(Size size, int type)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_ones(size.Width, size.Height, type));
            //return retVal;
        }

        //
        // C++: void Mat::push_back(Mat m)
        //

        // javadoc: Mat::push_back(m)
        public void PushBack(Mat m)
        {
            throw new NotImplementedException();
            //n_push_back(ptr, m.ptr);
        }

        // javadoc: Mat::reshape(cn, rows)
        public Mat Reshape(int cn, int rows)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_reshape(ptr, cn, rows));
            //return retVal;
        }

        // javadoc: Mat::reshape(cn)
        public Mat Reshape(int cn)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_reshape(ptr, cn));
            //return retVal;
        }

        // javadoc: Mat::row(y)
        public Mat Row(int y)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_row(ptr, y));
            //return retVal;
        }

        // javadoc: Mat::rowRange(startrow, endrow)
        public Mat RowRange(int startrow, int endrow)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_rowRange(ptr, startrow, endrow));
            //return retVal;
        }

        // javadoc: Mat::rowRange(r)
        public Mat RowRange(Range r)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_rowRange(ptr, r.Start, r.End));
            //return retVal;
        }

        // javadoc: Mat::rows()
        public int Rows()
        {
            throw new NotImplementedException();
            //int retVal = n_rows(ptr);
            //return retVal;
        }

        // javadoc: Mat::operator =(s)
        public Mat SetTo(Scalar s)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_setTo(ptr, s[0], s[1], s[2], s[3]));
            //return retVal;
        }

        // javadoc: Mat::setTo(value, mask)
        public Mat SetTo(Scalar value, Mat mask)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_setTo(ptr, value[0], value[1], value[2], value[3], mask.ptr));
            //return retVal;
        }

        // javadoc: Mat::setTo(value, mask)
        public Mat SetTo(Mat value, Mat mask)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_setTo(ptr, value.ptr, mask.ptr));
            //return retVal;
        }

        // javadoc: Mat::setTo(value)
        public Mat SetTo(Mat value)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_setTo(ptr, value.ptr));
            //return retVal;
        }

        // javadoc: Mat::size()
        public Size Size()
        {
            throw new NotImplementedException();
            //double[] size = n_size(ptr);
            //Size retVal = new Size(size[0], size[1]);
            //return retVal;
        }

        //
        // C++: size_t Mat::step1(int i = 0)
        //

        // javadoc: Mat::step1(i)
        public long Step1(int i)
        {
            throw new NotImplementedException();
            //long retVal = n_step1(ptr, i);
            //return retVal;
        }

        // javadoc: Mat::step1()
        public long Step1()
        {
            throw new NotImplementedException();
            //long retVal = n_step1(ptr);
            //return retVal;
        }

        // javadoc: Mat::operator()(rowStart, rowEnd, colStart, colEnd)
        public Mat SubMat(int rowStart, int rowEnd, int colStart, int colEnd)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_submat_rr(ptr, rowStart, rowEnd, colStart, colEnd));
            //return retVal;
        }

        // javadoc: Mat::operator()(rowRange, colRange)
        public Mat SubMat(Range rowRange, Range colRange)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_submat_rr(ptr, rowRange.Start, rowRange.End, colRange.Start, colRange.End));
            //return retVal;
        }

        // javadoc: Mat::operator()(roi)
        public Mat SubMat(Rect roi)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_submat(ptr, roi.X, roi.Y, roi.Width, roi.Height));
            //return retVal;
        }

        // javadoc: Mat::t()
        public Mat T()
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_t(ptr));
            //return retVal;
        }

        // javadoc: Mat::total()
        public long Total()
        {
            throw new NotImplementedException();
            //long retVal = n_total(ptr);
            //return retVal;
        }

        // javadoc: Mat::type()
        public int Type()
        {
            throw new NotImplementedException();
            //int retVal = n_type(ptr);
            //return retVal;
        }

        // javadoc: Mat::zeros(rows, cols, type)
        public static Mat Zeros(int rows, int cols, int type)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_zeros(rows, cols, type));
            //return retVal;
        }

        // javadoc: Mat::zeros(size, type)
        public static Mat Zeros(Size size, int type)
        {
            throw new NotImplementedException();
            //Mat retVal = new Mat(n_zeros(size.Width, size.Height, type));
            //return retVal;
        }

        // javadoc:Mat::ToString()
        public override string ToString()
        {
            return "Mat [ " +
                   Rows() + "*" + Cols() + "*" + CvType.TypeToString(Type()) +
                   ", isCont=" + IsContinuous() + ", isSubmat=" + IsSubmatrix() +
                   ", nativeObj=0x" + Convert.ToString(ptr.ToInt64(), 16) +
                   ", dataAddr=0x" + Convert.ToString(DataAddr().ToInt64(), 16) +
                   " ]";
        }

        // javadoc:Mat::dump()
        public String Dump()
        {
            throw new NotImplementedException();
            //return nDump(ptr);
        }

        // javadoc:Mat::put(row,col,data)
        public int Put(int row, int col, params double[] data)
        {
            throw new NotImplementedException();
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            return nPutD(ptr, row, col, data.Length, data);*/
        }

        // javadoc:Mat::put(row,col,data)
        public int Put(int row, int col, float[] data)
        {
            throw new NotImplementedException();
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            if (CvType.Depth(t) == CvType.CV_32F)
            {
                return nPutF(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);*/
        }

        // javadoc:Mat::put(row,col,data)
        public int Put(int row, int col, int[] data)
        {
            throw new NotImplementedException();
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            if (CvType.Depth(t) == CvType.CV_32S)
            {
                return nPutI(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);*/
        }

        // javadoc:Mat::put(row,col,data)
        public int Put(int row, int col, short[] data)
        {
            throw new NotImplementedException();
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            if (CvType.Depth(t) == CvType.CV_16U || CvType.Depth(t) == CvType.CV_16S)
            {
                return nPutS(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);*/
        }

        // javadoc:Mat::put(row,col,data)
        public int Put(int row, int col, byte[] data)
        {
            throw new NotImplementedException();
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            if (CvType.Depth(t) == CvType.CV_8U || CvType.Depth(t) == CvType.CV_8S)
            {
                return nPutB(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);*/
        }

        // javadoc:Mat::get(row,col,data)
        public int Get(int row, int col, byte[] data)
        {
            throw new NotImplementedException();
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            if (CvType.Depth(t) == CvType.CV_8U || CvType.Depth(t) == CvType.CV_8S)
            {
                return nGetB(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);*/
        }

        // javadoc:Mat::get(row,col,data)
        public int Get(int row, int col, short[] data)
        {
            throw new NotImplementedException();
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            if (CvType.Depth(t) == CvType.CV_16U || CvType.Depth(t) == CvType.CV_16S)
            {
                return nGetS(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);*/
        }

        // javadoc:Mat::get(row,col,data)
        public int Get(int row, int col, int[] data)
        {
            throw new NotImplementedException();
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            if (CvType.Depth(t) == CvType.CV_32S)
            {
                return nGetI(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);*/
        }

        // javadoc:Mat::get(row,col,data)
        public int Get(int row, int col, float[] data)
        {
            throw new NotImplementedException();
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})", 
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            if (CvType.Depth(t) == CvType.CV_32F)
            {
                return nGetF(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);*/
        }

        // javadoc:Mat::get(row,col,data)
        public int Get(int row, int col, double[] data)
        {
            throw new NotImplementedException();
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            if (CvType.Depth(t) == CvType.CV_64F)
            {
                return nGetD(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);*/
        }

        // javadoc:Mat::get(row,col)
        public double[] Get(int row, int col)
        {
            throw new NotImplementedException();
            //return nGet(ptr, row, col);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Height()
        {
            return Rows();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Width
        {
            get
            {
                if (cols == int.MinValue)
                {
                    try
                    {
                        cols = CppInvoke.core_Mat_cols(ptr);
                    }
                    catch (BadImageFormatException ex)
                    {
                        throw PInvokeHelper.CreateException(ex);
                    }
                }
                return cols;
            }
        }
        #endregion
        /*
        // C++: void Mat::assignTo(Mat m, int type = -1)
        private static extern void n_assignTo(IntPtr nativeObj, IntPtr m_nativeObj, int type);

        private static extern void n_assignTo(IntPtr nativeObj, IntPtr m_nativeObj);

        // C++: int Mat::channels()
        private static extern int n_channels(IntPtr nativeObj);

        // C++: int Mat::checkVector(int elemChannels, int depth = -1, bool
        // requireContinuous = true)
        private static extern int n_checkVector(IntPtr nativeObj, int elemChannels, int depth, bool requireContinuous);

        private static extern int n_checkVector(IntPtr nativeObj, int elemChannels, int depth);

        private static extern int n_checkVector(IntPtr nativeObj, int elemChannels);

        // C++: Mat Mat::clone()
        private static extern IntPtr n_clone(IntPtr nativeObj);

        // C++: Mat Mat::col(int x)
        private static extern IntPtr n_col(IntPtr nativeObj, int x);

        // C++: Mat Mat::colRange(int startcol, int endcol)
        private static extern IntPtr n_colRange(IntPtr nativeObj, int startcol, int endcol);

        // C++: int Mat::dims()
        private static extern int n_dims(IntPtr nativeObj);

        // C++: int Mat::cols()
        private static extern int n_cols(IntPtr nativeObj);

        // C++: void Mat::convertTo(Mat& m, int rtype, double alpha = 1, double beta
        // = 0)
        private static extern void n_convertTo(IntPtr nativeObj, IntPtr m_nativeObj, int rtype, double alpha, double beta);

        private static extern void n_convertTo(IntPtr nativeObj, IntPtr m_nativeObj, int rtype, double alpha);

        private static extern void n_convertTo(IntPtr nativeObj, IntPtr m_nativeObj, int rtype);

        // C++: void Mat::copyTo(Mat& m)
        private static extern void n_copyTo(IntPtr nativeObj, IntPtr m_nativeObj);

        // C++: void Mat::copyTo(Mat& m, Mat mask)
        private static extern void n_copyTo(IntPtr nativeObj, IntPtr m_nativeObj, IntPtr mask_nativeObj);

        // C++: void Mat::create(int rows, int cols, int type)
        private static extern void n_create(IntPtr nativeObj, int rows, int cols, int type);

        // C++: void Mat::create(Size size, int type)
        private static extern void n_create(IntPtr nativeObj, double size_width, double size_height, int type);

        // C++: Mat Mat::cross(Mat m)
        private static extern IntPtr n_cross(IntPtr nativeObj, IntPtr m_nativeObj);

        // C++: long Mat::dataAddr()
        private static extern IntPtr n_dataAddr(IntPtr nativeObj);

        // C++: int Mat::depth()
        private static extern int n_depth(IntPtr nativeObj);

        // C++: Mat Mat::diag(int d = 0)
        private static extern IntPtr n_diag(IntPtr nativeObj, int d);

        // C++: static Mat Mat::diag(Mat d)
        private static extern IntPtr n_diag(IntPtr d_nativeObj);

        // C++: double Mat::dot(Mat m)
        private static extern double n_dot(IntPtr nativeObj, IntPtr m_nativeObj);

        // C++: size_t Mat::elemSize()
        private static extern long n_elemSize(IntPtr nativeObj);

        // C++: size_t Mat::elemSize1()
        private static extern long n_elemSize1(IntPtr nativeObj);

        // C++: bool Mat::empty()
        private static extern bool n_empty(IntPtr nativeObj);

        // C++: static Mat Mat::eye(int rows, int cols, int type)
        private static extern IntPtr n_eye(int rows, int cols, int type);

        // C++: static Mat Mat::eye(Size size, int type)
        private static extern IntPtr n_eye(double size_width, double size_height, int type);

        // C++: Mat Mat::inv(int method = DECOMP_LU)
        private static extern IntPtr n_inv(IntPtr nativeObj, int method);

        private static extern IntPtr n_inv(IntPtr nativeObj);

        // C++: bool Mat::isContinuous()
        private static extern bool n_isContinuous(IntPtr nativeObj);

        // C++: bool Mat::isSubmatrix()
        private static extern bool n_isSubmatrix(IntPtr nativeObj);

        // C++: void Mat::locateROI(Size wholeSize, Point ofs)
        private static extern void locateROI_0(IntPtr nativeObj, double[] wholeSize_out, double[] ofs_out);

        // C++: Mat Mat::mul(Mat m, double scale = 1)
        private static extern IntPtr n_mul(IntPtr nativeObj, IntPtr m_nativeObj, double scale);

        private static extern IntPtr n_mul(IntPtr nativeObj, IntPtr m_nativeObj);

        // C++: static Mat Mat::ones(int rows, int cols, int type)
        private static extern IntPtr n_ones(int rows, int cols, int type);

        // C++: static Mat Mat::ones(Size size, int type)
        private static extern IntPtr n_ones(double size_width, double size_height, int type);

        // C++: void Mat::push_back(Mat m)
        private static extern void n_push_back(IntPtr nativeObj, IntPtr m_nativeObj);

        // C++: void Mat::release()
        private static extern void n_release(IntPtr nativeObj);

        // C++: Mat Mat::reshape(int cn, int rows = 0)
        private static extern IntPtr n_reshape(IntPtr nativeObj, int cn, int rows);

        private static extern IntPtr n_reshape(IntPtr nativeObj, int cn);

        // C++: Mat Mat::row(int y)
        private static extern IntPtr n_row(IntPtr nativeObj, int y);

        // C++: Mat Mat::rowRange(int startrow, int endrow)
        private static extern IntPtr n_rowRange(IntPtr nativeObj, int startrow, int endrow);

        // C++: int Mat::rows()
        private static extern int n_rows(IntPtr nativeObj);

        // C++: Mat Mat::operator =(Scalar s)
        private static extern IntPtr n_setTo(IntPtr nativeObj, double s_val0, double s_val1, double s_val2, double s_val3);

        // C++: Mat Mat::setTo(Scalar value, Mat mask = Mat())
        private static extern IntPtr n_setTo(IntPtr nativeObj, double s_val0, double s_val1, double s_val2, double s_val3,
                                           IntPtr mask_nativeObj);

        // C++: Mat Mat::setTo(Mat value, Mat mask = Mat())
        private static extern IntPtr n_setTo(IntPtr nativeObj, IntPtr value_nativeObj, IntPtr mask_nativeObj);

        private static extern IntPtr n_setTo(IntPtr nativeObj, IntPtr value_nativeObj);

        // C++: Size Mat::size()
        private static extern double[] n_size(IntPtr nativeObj);

        // C++: size_t Mat::step1(int i = 0)
        private static extern long n_step1(IntPtr nativeObj, int i);

        private static extern long n_step1(IntPtr nativeObj);

        // C++: Mat Mat::operator()(Range rowRange, Range colRange)
        private static extern IntPtr n_submat_rr(IntPtr nativeObj, int rowRange_start, int rowRange_end, int colRange_start,
                                               int colRange_end);

        // C++: Mat Mat::operator()(Rect roi)
        private static extern IntPtr n_submat(IntPtr nativeObj, int roi_x, int roi_y, int roi_width, int roi_height);

        // C++: Mat Mat::t()
        private static extern IntPtr n_t(IntPtr nativeObj);

        // C++: size_t Mat::total()
        private static extern long n_total(IntPtr nativeObj);

        // C++: int Mat::type()
        private static extern int n_type(IntPtr nativeObj);

        // C++: static Mat Mat::zeros(int rows, int cols, int type)
        private static extern IntPtr n_zeros(int rows, int cols, int type);

        // C++: static Mat Mat::zeros(Size size, int type)
        private static extern IntPtr n_zeros(double size_width, double size_height, int type);

        // extern support for java finalize()
        private static extern void n_delete(IntPtr nativeObj);

        private static extern int nPutD(IntPtr self, int row, int col, int count, double[] data);

        private static extern int nPutF(IntPtr self, int row, int col, int count, float[] data);

        private static extern int nPutI(IntPtr self, int row, int col, int count, int[] data);

        private static extern int nPutS(IntPtr self, int row, int col, int count, short[] data);

        private static extern int nPutB(IntPtr self, int row, int col, int count, byte[] data);

        private static extern int nGetB(IntPtr self, int row, int col, int count, byte[] vals);

        private static extern int nGetS(IntPtr self, int row, int col, int count, short[] vals);

        private static extern int nGetI(IntPtr self, int row, int col, int count, int[] vals);

        private static extern int nGetF(IntPtr self, int row, int col, int count, float[] vals);

        private static extern int nGetD(IntPtr self, int row, int col, int count, double[] vals);

        private static extern double[] nGet(IntPtr self, int row, int col);

        private static extern String nDump(IntPtr self);
        */
    }

}

