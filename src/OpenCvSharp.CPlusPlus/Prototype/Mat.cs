using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// cv::Mat
    /// </summary>
    public class Mat : DisposableCvObject, ICloneable
    {
        public Mat(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Native object address is NULL");
            this.ptr = ptr;
        }

        // Mat::Mat()
        public Mat()
        {
            ptr = n_Mat();
        }

        // Mat::Mat(rows, cols, type)
        public Mat(int rows, int cols, int type)
        {
            ptr = n_Mat(rows, cols, type);
        }

        // Mat::Mat(size, type)
        public Mat(Size size, int type)
        {
            ptr = n_Mat(size.Width, size.Height, type);
        }

        // Mat::Mat(rows, cols, type, s)
        public Mat(int rows, int cols, int type, Scalar s)
        {
            ptr = n_Mat(rows, cols, type, s[0], s[1], s[2], s[3]);
        }

        // Mat::Mat(size, type, s)
        public Mat(Size size, int type, Scalar s)
        {
            ptr = n_Mat(size.Width, size.Height, type, s[0], s[1], s[2], s[3]);
        }

        // javadoc: Mat::Mat(m, rowRange, colRange)
        public Mat(Mat m, Range rowRange, Range colRange)
        {
            ptr = n_Mat(m.ptr, rowRange.Start, rowRange.End, colRange.Start, colRange.End);
        }

        // javadoc: Mat::Mat(m, rowRange)
        public Mat(Mat m, Range rowRange)
        {
            ptr = n_Mat(m.ptr, rowRange.Start, rowRange.End);
        }

        // javadoc: Mat::Mat(m, roi)
        public Mat(Mat m, Rect roi)
        {
            ptr = n_Mat(m.ptr, roi.Y, roi.Y + roi.Height, roi.X, roi.X + roi.Width);
        }


        // javadoc: Mat::adjustROI(dtop, dbottom, dleft, dright)
        public Mat AdjustROI(int dtop, int dbottom, int dleft, int dright)
        {
            Mat retVal = new Mat(n_adjustROI(ptr, dtop, dbottom, dleft, dright));
            return retVal;
        }

        // javadoc: Mat::assignTo(m, type)
        public void AssignTo(Mat m, int type)
        {
            n_assignTo(ptr, m.ptr, type);
        }

        public void AssignTo(Mat m)
        {
            n_assignTo(ptr, m.ptr);
        }

        public int Channels()
        {
            int retVal = n_channels(ptr);
            return retVal;
        }

        // javadoc: Mat::checkVector(elemChannels, depth, requireContinuous)
        public int CheckVector(int elemChannels, int depth, bool requireContinuous)
        {

            int retVal = n_checkVector(ptr, elemChannels, depth, requireContinuous);

            return retVal;
        }

        // javadoc: Mat::checkVector(elemChannels, depth)
        public int CheckVector(int elemChannels, int depth)
        {

            int retVal = n_checkVector(ptr, elemChannels, depth);

            return retVal;
        }

        // javadoc: Mat::checkVector(elemChannels)
        public int CheckVector(int elemChannels)
        {
            int retVal = n_checkVector(ptr, elemChannels);
            return retVal;
        }

        //
        // C++: Mat Mat::clone()
        //

        // javadoc: Mat::clone()
        public Mat Clone()
        {
            Mat retVal = new Mat(n_clone(ptr));
            return retVal;
        }

        //
        // C++: Mat Mat::col(int x)
        //

        // javadoc: Mat::col(x)
        public Mat col(int x)
        {

            Mat retVal = new Mat(n_col(ptr, x));

            return retVal;
        }

        //
        // C++: Mat Mat::colRange(int startcol, int endcol)
        //

        // javadoc: Mat::colRange(startcol, endcol)
        public Mat colRange(int startcol, int endcol)
        {

            Mat retVal = new Mat(n_colRange(ptr, startcol, endcol));

            return retVal;
        }

        //
        // C++: Mat Mat::colRange(Range r)
        //

        // javadoc: Mat::colRange(r)
        public Mat colRange(Range r)
        {

            Mat retVal = new Mat(n_colRange(ptr, r.Start, r.End));

            return retVal;
        }

        //
        // C++: int Mat::dims()
        //

        // javadoc: Mat::dims()
        public int dims()
        {

            int retVal = n_dims(ptr);

            return retVal;
        }

        //
        // C++: int Mat::cols()
        //

        // javadoc: Mat::cols()
        public int cols()
        {

            int retVal = n_cols(ptr);

            return retVal;
        }

        //
        // C++: void Mat::convertTo(Mat& m, int rtype, double alpha = 1, double beta
        // = 0)
        //

        // javadoc: Mat::convertTo(m, rtype, alpha, beta)
        public void convertTo(Mat m, int rtype, double alpha, double beta)
        {

            n_convertTo(ptr, m.ptr, rtype, alpha, beta);

            return;
        }

        // javadoc: Mat::convertTo(m, rtype, alpha)
        public void convertTo(Mat m, int rtype, double alpha)
        {

            n_convertTo(ptr, m.ptr, rtype, alpha);

            return;
        }

        // javadoc: Mat::convertTo(m, rtype)
        public void convertTo(Mat m, int rtype)
        {

            n_convertTo(ptr, m.ptr, rtype);

            return;
        }

        //
        // C++: void Mat::copyTo(Mat& m)
        //

        // javadoc: Mat::copyTo(m)
        public void copyTo(Mat m)
        {

            n_copyTo(ptr, m.ptr);

            return;
        }

        //
        // C++: void Mat::copyTo(Mat& m, Mat mask)
        //

        // javadoc: Mat::copyTo(m, mask)
        public void copyTo(Mat m, Mat mask)
        {

            n_copyTo(ptr, m.ptr, mask.ptr);

            return;
        }

        //
        // C++: void Mat::create(int rows, int cols, int type)
        //

        // javadoc: Mat::create(rows, cols, type)
        public void create(int rows, int cols, int type)
        {

            n_create(ptr, rows, cols, type);

            return;
        }

        //
        // C++: void Mat::create(Size size, int type)
        //

        // javadoc: Mat::create(size, type)
        public void create(Size size, int type)
        {

            n_create(ptr, size.Width, size.Height, type);

            return;
        }

        //
        // C++: Mat Mat::cross(Mat m)
        //

        // javadoc: Mat::cross(m)
        public Mat cross(Mat m)
        {

            Mat retVal = new Mat(n_cross(ptr, m.ptr));

            return retVal;
        }

        //
        // C++: long Mat::dataAddr()
        //

        // javadoc: Mat::dataAddr()
        public long dataAddr()
        {

            long retVal = n_dataAddr(ptr);

            return retVal;
        }

        //
        // C++: int Mat::depth()
        //

        // javadoc: Mat::depth()
        public int depth()
        {

            int retVal = n_depth(ptr);

            return retVal;
        }

        //
        // C++: Mat Mat::diag(int d = 0)
        //

        // javadoc: Mat::diag(d)
        public Mat diag(int d)
        {

            Mat retVal = new Mat(n_diag(ptr, d));

            return retVal;
        }

        // javadoc: Mat::diag()
        public Mat diag()
        {

            Mat retVal = new Mat(n_diag(ptr, 0));

            return retVal;
        }

        //
        // C++: static Mat Mat::diag(Mat d)
        //

        // javadoc: Mat::diag(d)
        public static Mat diag(Mat d)
        {

            Mat retVal = new Mat(n_diag(d.ptr));

            return retVal;
        }

        //
        // C++: double Mat::dot(Mat m)
        //

        // javadoc: Mat::dot(m)
        public double dot(Mat m)
        {

            double retVal = n_dot(ptr, m.ptr);

            return retVal;
        }

        //
        // C++: size_t Mat::elemSize()
        //

        // javadoc: Mat::elemSize()
        public long elemSize()
        {

            long retVal = n_elemSize(ptr);

            return retVal;
        }

        //
        // C++: size_t Mat::elemSize1()
        //

        // javadoc: Mat::elemSize1()
        public long elemSize1()
        {

            long retVal = n_elemSize1(ptr);

            return retVal;
        }

        //
        // C++: bool Mat::empty()
        //

        // javadoc: Mat::empty()
        public bool empty()
        {

            bool retVal = n_empty(ptr);

            return retVal;
        }

        //
        // C++: static Mat Mat::eye(int rows, int cols, int type)
        //

        // javadoc: Mat::eye(rows, cols, type)
        public static Mat eye(int rows, int cols, int type)
        {

            Mat retVal = new Mat(n_eye(rows, cols, type));

            return retVal;
        }

        //
        // C++: static Mat Mat::eye(Size size, int type)
        //

        // javadoc: Mat::eye(size, type)
        public static Mat eye(Size size, int type)
        {

            Mat retVal = new Mat(n_eye(size.Width, size.Height, type));

            return retVal;
        }

        //
        // C++: Mat Mat::inv(int method = DECOMP_LU)
        //

        // javadoc: Mat::inv(method)
        public Mat inv(int method)
        {

            Mat retVal = new Mat(n_inv(ptr, method));

            return retVal;
        }

        // javadoc: Mat::inv()
        public Mat inv()
        {

            Mat retVal = new Mat(n_inv(ptr));

            return retVal;
        }

        //
        // C++: bool Mat::isContinuous()
        //

        // javadoc: Mat::isContinuous()
        public bool isContinuous()
        {

            bool retVal = n_isContinuous(ptr);

            return retVal;
        }

        //
        // C++: bool Mat::isSubmatrix()
        //

        // javadoc: Mat::isSubmatrix()
        public bool isSubmatrix()
        {

            bool retVal = n_isSubmatrix(ptr);

            return retVal;
        }

        // javadoc: Mat::locateROI(wholeSize, ofs)
        public void LocateROI(Size wholeSize, Point ofs)
        {
            double[] wholeSizeOut = new double[2];
            double[] ofsOut = new double[2];
            locateROI_0(ptr, wholeSizeOut, ofsOut);
            wholeSize.Width = wholeSizeOut[0];
            wholeSize.Height = wholeSizeOut[1];
            ofs.X = ofsOut[0];
            ofs.Y = ofsOut[1];
        }

        //
        // C++: Mat Mat::mul(Mat m, double scale = 1)
        //

        // javadoc: Mat::mul(m, scale)
        public Mat mul(Mat m, double scale)
        {

            Mat retVal = new Mat(n_mul(ptr, m.ptr, scale));

            return retVal;
        }

        // javadoc: Mat::mul(m)
        public Mat mul(Mat m)
        {

            Mat retVal = new Mat(n_mul(ptr, m.ptr));

            return retVal;
        }

        //
        // C++: static Mat Mat::ones(int rows, int cols, int type)
        //

        // javadoc: Mat::ones(rows, cols, type)
        public static Mat ones(int rows, int cols, int type)
        {

            Mat retVal = new Mat(n_ones(rows, cols, type));

            return retVal;
        }

        //
        // C++: static Mat Mat::ones(Size size, int type)
        //

        // javadoc: Mat::ones(size, type)
        public static Mat ones(Size size, int type)
        {

            Mat retVal = new Mat(n_ones(size.Width, size.Height, type));

            return retVal;
        }

        //
        // C++: void Mat::push_back(Mat m)
        //

        // javadoc: Mat::push_back(m)
        public void push_back(Mat m)
        {

            n_push_back(ptr, m.ptr);

            return;
        }

        //
        // C++: void Mat::release()
        //

        // javadoc: Mat::release()
        public void release()
        {
            n_release(ptr);
        }

        //
        // C++: Mat Mat::reshape(int cn, int rows = 0)
        //

        // javadoc: Mat::reshape(cn, rows)
        public Mat reshape(int cn, int rows)
        {

            Mat retVal = new Mat(n_reshape(ptr, cn, rows));

            return retVal;
        }

        // javadoc: Mat::reshape(cn)
        public Mat reshape(int cn)
        {

            Mat retVal = new Mat(n_reshape(ptr, cn));

            return retVal;
        }

        //
        // C++: Mat Mat::row(int y)
        //

        // javadoc: Mat::row(y)
        public Mat row(int y)
        {

            Mat retVal = new Mat(n_row(ptr, y));

            return retVal;
        }

        //
        // C++: Mat Mat::rowRange(int startrow, int endrow)
        //

        // javadoc: Mat::rowRange(startrow, endrow)
        public Mat rowRange(int startrow, int endrow)
        {
            Mat retVal = new Mat(n_rowRange(ptr, startrow, endrow));
            return retVal;
        }

        //
        // C++: Mat Mat::rowRange(Range r)
        //

        // javadoc: Mat::rowRange(r)
        public Mat EowRange(Range r)
        {
            Mat retVal = new Mat(n_rowRange(ptr, r.Start, r.End));
            return retVal;
        }

        //
        // C++: int Mat::rows()
        //

        // javadoc: Mat::rows()
        public int Rows()
        {
            int retVal = n_rows(ptr);
            return retVal;
        }

        //
        // C++: Mat Mat::operator =(Scalar s)
        //

        // javadoc: Mat::operator =(s)
        public Mat SetTo(Scalar s)
        {
            Mat retVal = new Mat(n_setTo(ptr, s.val[0], s.val[1], s.val[2], s.val[3]));
            return retVal;
        }

        //
        // C++: Mat Mat::setTo(Scalar value, Mat mask = Mat())
        //

        // javadoc: Mat::setTo(value, mask)
        public Mat SetTo(Scalar value, Mat mask)
        {
            Mat retVal =
                new Mat(n_setTo(ptr, value.val[0], value.val[1], value.val[2], value.val[3], mask.ptr));
            return retVal;
        }

        //
        // C++: Mat Mat::setTo(Mat value, Mat mask = Mat())
        //

        // javadoc: Mat::setTo(value, mask)
        public Mat SetTo(Mat value, Mat mask)
        {

            Mat retVal = new Mat(n_setTo(ptr, value.ptr, mask.ptr));

            return retVal;
        }

        // javadoc: Mat::setTo(value)
        public Mat SetTo(Mat value)
        {

            Mat retVal = new Mat(n_setTo(ptr, value.ptr));

            return retVal;
        }

        //
        // C++: Size Mat::size()
        //

        // javadoc: Mat::size()
        public Size Size()
        {

            Size retVal = new Size(n_size(ptr));

            return retVal;
        }

        //
        // C++: size_t Mat::step1(int i = 0)
        //

        // javadoc: Mat::step1(i)
        public long Step1(int i)
        {

            long retVal = n_step1(ptr, i);

            return retVal;
        }

        // javadoc: Mat::step1()
        public long step1()
        {

            long retVal = n_step1(ptr);

            return retVal;
        }

        // javadoc: Mat::operator()(rowStart, rowEnd, colStart, colEnd)
        public Mat SubMat(int rowStart, int rowEnd, int colStart, int colEnd)
        {

            Mat retVal = new Mat(n_submat_rr(ptr, rowStart, rowEnd, colStart, colEnd));

            return retVal;
        }

        // javadoc: Mat::operator()(rowRange, colRange)
        public Mat SubMat(Range rowRange, Range colRange)
        {

            Mat retVal = new Mat(n_submat_rr(ptr, rowRange.Start, rowRange.End, colRange.Start, colRange.End));

            return retVal;
        }

        // javadoc: Mat::operator()(roi)
        public Mat SubMat(Rect roi)
        {
            Mat retVal = new Mat(n_submat(ptr, roi.X, roi.Y, roi.Width, roi.Height));
            return retVal;
        }

        // javadoc: Mat::t()
        public Mat T()
        {
            Mat retVal = new Mat(n_t(ptr));
            return retVal;
        }

        // javadoc: Mat::total()
        public long Total()
        {
            long retVal = n_total(ptr);
            return retVal;
        }

        // javadoc: Mat::type()
        public int Type()
        {
            int retVal = n_type(ptr);
            return retVal;
        }

        //
        // C++: static Mat Mat::zeros(int rows, int cols, int type)
        //

        // javadoc: Mat::zeros(rows, cols, type)
        public static Mat zeros(int rows, int cols, int type)
        {

            Mat retVal = new Mat(n_zeros(rows, cols, type));

            return retVal;
        }

        //
        // C++: static Mat Mat::zeros(Size size, int type)
        //

        // javadoc: Mat::zeros(size, type)
        public static Mat zeros(Size size, int type)
        {
            Mat retVal = new Mat(n_zeros(size.Width, size.Height, type));
            return retVal;
        }

        protected override void Dispose(bool disposing)
        {
            n_delete(ptr);
            base.Dispose(disposing);
        }

        // javadoc:Mat::ToString()
        public override string ToString()
        {
            return "Mat [ " +
                   Rows() + "*" + cols() + "*" + CvType.typeToString(Type()) +
                   ", isCont=" + isContinuous() + ", isSubmat=" + isSubmatrix() +
                   ", nativeObj=0x" + Long.toHexString(ptr) +
                   ", dataAddr=0x" + Long.toHexString(dataAddr()) +
                   " ]";
        }

        // javadoc:Mat::dump()
        public String Dump()
        {
            return nDump(ptr);
        }

        // javadoc:Mat::put(row,col,data)
        public int Put(int row, int col, params double[] data)
        {
            int t = Type();
            if (data == null || data.Length % CvType.channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number (" +
                    (data == null ? 0 : data.Length) +
                    ") should be multiple of the Mat channels count (" +
                    CvType.channels(t) + ")");
            return nPutD(ptr, row, col, data.Length, data);
        }

        // javadoc:Mat::put(row,col,data)
        public int Put(int row, int col, float[] data)
        {
            int t = Type();
            if (data == null || data.Length % CvType.channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number (" +
                    (data == null ? 0 : data.Length) +
                    ") should be multiple of the Mat channels count (" +
                    CvType.channels(t) + ")");
            if (CvType.depth(t) == CvType.CV_32F)
            {
                return nPutF(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);
        }

        // javadoc:Mat::put(row,col,data)
        public int Put(int row, int col, int[] data)
        {
            int t = Type();
            if (data == null || data.Length % CvType.channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number (" +
                    (data == null ? 0 : data.Length) +
                    ") should be multiple of the Mat channels count (" +
                    CvType.channels(t) + ")");
            if (CvType.depth(t) == CvType.CV_32S)
            {
                return nPutI(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);
        }

        // javadoc:Mat::put(row,col,data)
        public int Put(int row, int col, short[] data)
        {
            int t = Type();
            if (data == null || data.Length % CvType.channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number (" +
                    (data == null ? 0 : data.Length) +
                    ") should be multiple of the Mat channels count (" +
                    CvType.channels(t) + ")");
            if (CvType.depth(t) == CvType.CV_16U || CvType.depth(t) == CvType.CV_16S)
            {
                return nPutS(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);
        }

        // javadoc:Mat::put(row,col,data)
        public int Put(int row, int col, byte[] data)
        {
            int t = Type();
            if (data == null || data.Length % CvType.channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number (" +
                    (data == null ? 0 : data.Length) +
                    ") should be multiple of the Mat channels count (" +
                    CvType.channels(t) + ")");
            if (CvType.depth(t) == CvType.CV_8U || CvType.depth(t) == CvType.CV_8S)
            {
                return nPutB(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);
        }

        // javadoc:Mat::get(row,col,data)
        public int Get(int row, int col, byte[] data)
        {
            int t = Type();
            if (data == null || data.Length % CvType.channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number (" +
                    (data == null ? 0 : data.Length) +
                    ") should be multiple of the Mat channels count (" +
                    CvType.channels(t) + ")");
            if (CvType.depth(t) == CvType.CV_8U || CvType.depth(t) == CvType.CV_8S)
            {
                return nGetB(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);
        }

        // javadoc:Mat::get(row,col,data)
        public int Get(int row, int col, short[] data)
        {
            int t = Type();
            if (data == null || data.Length % CvType.channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number (" +
                    (data == null ? 0 : data.Length) +
                    ") should be multiple of the Mat channels count (" +
                    CvType.channels(t) + ")");
            if (CvType.depth(t) == CvType.CV_16U || CvType.depth(t) == CvType.CV_16S)
            {
                return nGetS(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);
        }

        // javadoc:Mat::get(row,col,data)
        public int Get(int row, int col, int[] data)
        {
            int t = Type();
            if (data == null || data.length % CvType.channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number (" +
                    (data == null ? 0 : data.Length) +
                    ") should be multiple of the Mat channels count (" +
                    CvType.channels(t) + ")");
            if (CvType.depth(t) == CvType.CV_32S)
            {
                return nGetI(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);
        }

        // javadoc:Mat::get(row,col,data)
        public int Get(int row, int col, float[] data)
        {
            int t = Type();
            if (data == null || data.Length % CvType.channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number (" +
                    (data == null ? 0 : data.Length) +
                    ") should be multiple of the Mat channels count (" +
                    CvType.channels(t) + ")");
            if (CvType.depth(t) == CvType.CV_32F)
            {
                return nGetF(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);
        }

        // javadoc:Mat::get(row,col,data)
        public int Get(int row, int col, double[] data)
        {
            int t = Type();
            if (data == null || data.Length % CvType.channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number (" +
                    (data == null ? 0 : data.Length) +
                    ") should be multiple of the Mat channels count (" +
                    CvType.channels(t) + ")");
            if (CvType.depth(t) == CvType.CV_64F)
            {
                return nGetD(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);
        }

        // javadoc:Mat::get(row,col)
        public double[] get(int row, int col)
        {
            return nGet(ptr, row, col);
        }

        // javadoc:Mat::height()
        public int Height()
        {
            return Rows();
        }

        // javadoc:Mat::width()
        public int Width()
        {
            return cols();
        }

        // C++: Mat::Mat()
        private static extern IntPtr n_Mat();

        // C++: Mat::Mat(int rows, int cols, int type)
        private static extern IntPtr n_Mat(int rows, int cols, int type);

        // C++: Mat::Mat(Size size, int type)
        private static extern IntPtr n_Mat(double size_width, double size_height, int type);

        // C++: Mat::Mat(int rows, int cols, int type, Scalar s)
        private static extern IntPtr n_Mat(int rows, int cols, int type, double s_val0, double s_val1, double s_val2,
                                         double s_val3);

        // C++: Mat::Mat(Size size, int type, Scalar s)
        private static extern IntPtr n_Mat(double size_width, double size_height, int type, double s_val0, double s_val1,
                                         double s_val2, double s_val3);

        // C++: Mat::Mat(Mat m, Range rowRange, Range colRange = Range::all())
        private static extern IntPtr n_Mat(IntPtr m_nativeObj, int rowRange_start, int rowRange_end, int colRange_start,
                                         int colRange_end);

        private static extern IntPtr n_Mat(IntPtr IntPtrIntPtr, int rowRange_start, int rowRange_end);

        // C++: Mat Mat::adjustROI(int dtop, int dbottom, int dleft, int dright)
        private static extern IntPtr n_adjustROI(IntPtr nativeObj, int dtop, int dbottom, int dleft, int dright);

        // C++: void Mat::assignTo(Mat m, int type = -1)
        private static extern void n_assignTo(IntPtr nativeObj, long m_nativeObj, int type);

        private static extern void n_assignTo(IntPtr nativeObj, long m_nativeObj);

        // C++: int Mat::channels()
        private static extern int n_channels(IntPtr nativeObj);

        // C++: int Mat::checkVector(int elemChannels, int depth = -1, bool
        // requireContinuous = true)
        private static extern int n_checkVector(IntPtr nativeObj, int elemChannels, int depth, bool requireContinuous);

        private static extern int n_checkVector(IntPtr nativeObj, int elemChannels, int depth);

        private static extern int n_checkVector(IntPtr nativeObj, int elemChannels);

        // C++: Mat Mat::clone()
        private static extern long n_clone(IntPtr nativeObj);

        // C++: Mat Mat::col(int x)
        private static extern long n_col(IntPtr nativeObj, int x);

        // C++: Mat Mat::colRange(int startcol, int endcol)
        private static extern long n_colRange(IntPtr nativeObj, int startcol, int endcol);

        // C++: int Mat::dims()
        private static extern int n_dims(IntPtr nativeObj);

        // C++: int Mat::cols()
        private static extern int n_cols(IntPtr nativeObj);

        // C++: void Mat::convertTo(Mat& m, int rtype, double alpha = 1, double beta
        // = 0)
        private static extern void n_convertTo(IntPtr nativeObj, IntPtr m_nativeObj, int rtype, double alpha, double beta);

        private static extern void n_convertTo(long nativeObj, IntPtr m_nativeObj, int rtype, double alpha);

        private static extern void n_convertTo(IntPtr nativeObj, IntPtr m_nativeObj, int rtype);

        // C++: void Mat::copyTo(Mat& m)
        private static extern void n_copyTo(IntPtr nativeObj, IntPtr m_nativeObj);

        // C++: void Mat::copyTo(Mat& m, Mat mask)
        private static extern void n_copyTo(IntPtr nativeObj, long m_nativeObj, IntPtr mask_nativeObj);

        // C++: void Mat::create(int rows, int cols, int type)
        private static extern void n_create(IntPtr nativeObj, int rows, int cols, int type);

        // C++: void Mat::create(Size size, int type)
        private static extern void n_create(IntPtr nativeObj, double size_width, double size_height, int type);

        // C++: Mat Mat::cross(Mat m)
        private static extern long n_cross(IntPtr nativeObj, IntPtr m_nativeObj);

        // C++: long Mat::dataAddr()
        private static extern long n_dataAddr(IntPtr nativeObj);

        // C++: int Mat::depth()
        private static extern int n_depth(IntPtr nativeObj);

        // C++: Mat Mat::diag(int d = 0)
        private static extern long n_diag(IntPtr nativeObj, int d);

        // C++: static Mat Mat::diag(Mat d)
        private static extern long n_diag(long d_nativeObj);

        // C++: double Mat::dot(Mat m)
        private static extern double n_dot(IntPtr nativeObj, long m_nativeObj);

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
        private static extern long n_inv(IntPtr nativeObj, int method);

        private static extern long n_inv(IntPtr nativeObj);

        // C++: bool Mat::isContinuous()
        private static extern bool n_isContinuous(IntPtr nativeObj);

        // C++: bool Mat::isSubmatrix()
        private static extern bool n_isSubmatrix(IntPtr nativeObj);

        // C++: void Mat::locateROI(Size wholeSize, Point ofs)
        private static extern void locateROI_0(IntPtr nativeObj, double[] wholeSize_out, double[] ofs_out);

        // C++: Mat Mat::mul(Mat m, double scale = 1)
        private static extern long n_mul(IntPtr nativeObj, IntPtr m_nativeObj, double scale);

        private static extern long n_mul(IntPtr nativeObj, IntPtr m_nativeObj);

        // C++: static Mat Mat::ones(int rows, int cols, int type)
        private static extern IntPtr n_ones(int rows, int cols, int type);

        // C++: static Mat Mat::ones(Size size, int type)
        private static extern IntPtr n_ones(double size_width, double size_height, int type);

        // C++: void Mat::push_back(Mat m)
        private static extern void n_push_back(IntPtr nativeObj, long m_nativeObj);

        // C++: void Mat::release()
        private static extern void n_release(IntPtr nativeObj);

        // C++: Mat Mat::reshape(int cn, int rows = 0)
        private static extern long n_reshape(IntPtr nativeObj, int cn, int rows);

        private static extern long n_reshape(IntPtr nativeObj, int cn);

        // C++: Mat Mat::row(int y)
        private static extern IntPtr n_row(IntPtr nativeObj, int y);

        // C++: Mat Mat::rowRange(int startrow, int endrow)
        private static extern IntPtr n_rowRange(IntPtr nativeObj, int startrow, int endrow);

        // C++: int Mat::rows()
        private static extern IntPtr n_rows(IntPtr nativeObj);

        // C++: Mat Mat::operator =(Scalar s)
        private static extern IntPtr n_setTo(IntPtr nativeObj, double s_val0, double s_val1, double s_val2, double s_val3);

        // C++: Mat Mat::setTo(Scalar value, Mat mask = Mat())
        private static extern IntPtr n_setTo(IntPtr nativeObj, double s_val0, double s_val1, double s_val2, double s_val3,
                                           IntPtr mask_nativeObj);

        // C++: Mat Mat::setTo(Mat value, Mat mask = Mat())
        private static extern long n_setTo(IntPtr nativeObj, long value_nativeObj, long mask_nativeObj);

        private static extern long n_setTo(IntPtr nativeObj, long value_nativeObj);

        // C++: Size Mat::size()
        private static extern double[] n_size(IntPtr nativeObj);

        // C++: size_t Mat::step1(int i = 0)
        private static extern long n_step1(IntPtr nativeObj, int i);

        private static extern long n_step1(IntPtr nativeObj);

        // C++: Mat Mat::operator()(Range rowRange, Range colRange)
        private static extern long n_submat_rr(IntPtr nativeObj, int rowRange_start, int rowRange_end, int colRange_start,
                                               int colRange_end);

        // C++: Mat Mat::operator()(Rect roi)
        private static extern long n_submat(IntPtr nativeObj, int roi_x, int roi_y, int roi_width, int roi_height);

        // C++: Mat Mat::t()
        private static extern long n_t(IntPtr nativeObj);

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
    }

}

