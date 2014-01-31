/*
* (C) 2008-2014 Schima
* This code is licenced under the LGPL.
*/

#ifndef _CPP_CORE_MAT_H_
#define _CPP_CORE_MAT_H_

#include <opencv2/core/core.hpp>
#include <iostream>

#pragma region Init & Release
CVAPI(uint64) core_Mat_sizeof()
{
	return sizeof(cv::Mat);
}

CVAPI(cv::Mat*) core_Mat_new1()
{
	return new cv::Mat();
}
CVAPI(cv::Mat*) core_Mat_new2(int rows, int cols, int type)
{
	return new cv::Mat(rows, cols, type); CvScalar s;
}
CVAPI(cv::Mat*) core_Mat_new3(int rows, int cols, int type, CvScalar scalar)
{
	return new cv::Mat(rows, cols, type, scalar);
}
CVAPI(cv::Mat*) core_Mat_new4(cv::Mat *mat, CvSlice rowRange, CvSlice colRange)
{
	return new cv::Mat(*mat, rowRange, colRange);
}
CVAPI(cv::Mat*) core_Mat_new5(cv::Mat *mat, CvSlice rowRange)
{
	return new cv::Mat(*mat, rowRange);
}
CVAPI(cv::Mat*) core_Mat_new6(cv::Mat *mat, CvRect roi)
{
	return new cv::Mat(*mat, roi);
}

CVAPI(void) core_Mat_release(cv::Mat *obj)
{
	obj->release();
}
CVAPI(void) core_Mat_delete(cv::Mat *obj)
{
	delete obj;
}
#pragma endregion

#pragma region Functions
CVAPI(cv::Mat*) core_Mat_adjustROI(cv::Mat *obj, int dtop, int dbottom, int dleft, int dright)
{
	cv::Mat ret = obj->adjustROI(dtop, dbottom, dleft, dright);
	return new cv::Mat(ret);
}

CVAPI(void) core_Mat_assignTo1(cv::Mat *obj, cv::Mat *m)
{
	obj->assignTo(*m);
}
CVAPI(void) core_Mat_assignTo2(cv::Mat *obj, cv::Mat *m, int type)
{
	obj->assignTo(*m, type);
}

CVAPI(int) core_Mat_channels(cv::Mat *obj)
{
	return obj->channels();
}

CVAPI(int) core_Mat_checkVector1(cv::Mat *obj, int elemChannels)
{
	return obj->checkVector(elemChannels);
}
CVAPI(int) core_Mat_checkVector2(cv::Mat *obj, int elemChannels, int depth)
{
	return obj->checkVector(elemChannels, depth);
}
CVAPI(int) core_Mat_checkVector3(cv::Mat *obj, int elemChannels, int depth, int requireContinuous)
{
	return obj->checkVector(elemChannels, depth, requireContinuous != 0);
}

CVAPI(cv::Mat*) core_Mat_clone(cv::Mat *obj)
{
	cv::Mat ret = obj->clone();
	return new cv::Mat(ret);
}

CVAPI(cv::Mat*) core_Mat_col(cv::Mat *obj, int x)
{
	cv::Mat ret = obj->col(x);
	return new cv::Mat(ret);
}

CVAPI(int) core_Mat_cols(cv::Mat *obj)
{
	return obj->cols;
}

CVAPI(cv::Mat*) core_Mat_colRange(cv::Mat *obj, int startCol, int endCol)
{ 
	cv::Mat ret = obj->colRange(startCol, endCol);
    return new cv::Mat(ret);
}


CVAPI(int) core_Mat_dims(cv::Mat *obj)
{
	return obj->dims;
}

CVAPI(void) core_Mat_convertTo1(cv::Mat *obj, cv::Mat *m, int rtype)
{
	obj->convertTo(*m, rtype);
}
CVAPI(void) core_Mat_convertTo2(cv::Mat *obj, cv::Mat *m, int rtype, double alpha)
{
	obj->convertTo(*m, rtype, alpha);
}
CVAPI(void) core_Mat_convertTo3(cv::Mat *obj, cv::Mat *m, int rtype, double alpha, double beta)
{
	obj->convertTo(*m, rtype, alpha, beta);
}

CVAPI(void) core_Mat_copyTo(cv::Mat *obj, cv::Mat *m, cv::Mat *mask)
{
	cv::Mat &maskMat = (mask == NULL) ? cv::Mat() : *mask;
	obj->copyTo(*m, maskMat);
}


CVAPI(void) core_Mat_create1(cv::Mat *obj, int rows, int cols, int type)
{
	obj->create(rows, cols, type);
}
CVAPI(void) core_Mat_create2(cv::Mat *obj, int ndims, const int *sizes, int type)
{
	obj->create(ndims, sizes, type);
}

CVAPI(cv::Mat*) core_Mat_cross(cv::Mat *obj, cv::Mat *m)
{
	cv::Mat ret = obj->cross(*m);
    return new cv::Mat(ret);
}


CVAPI(uchar*) core_Mat_data(cv::Mat *obj)
{
	return obj->data;
}
CVAPI(uchar*) core_Mat_datastart(cv::Mat *obj)
{
	return obj->datastart;
}
CVAPI(uchar*) core_Mat_dataend(cv::Mat *obj)
{
	return obj->dataend;
}

CVAPI(int) core_Mat_depth(cv::Mat *obj)
{
	return obj->depth();
}

     
CVAPI(cv::Mat*) core_Mat_diag(cv::Mat *obj)
{
	cv::Mat ret = obj->diag();
    return new cv::Mat(ret);
}
CVAPI(cv::Mat*) core_Mat_diag(cv::Mat *obj, int d)
{
	cv::Mat ret = obj->diag(d);
    return new cv::Mat(ret);
}

CVAPI(double) core_Mat_Dot(Mat m)
        {
            
            //double retVal = n_dot(ptr, m.ptr);
            //return retVal;
        }

        // javadoc: Mat::elemSize()
CVAPI(long) core_Mat_ElemSize()
        {
            
            //long retVal = n_elemSize(ptr);
            //return retVal;
        }

        // javadoc: Mat::elemSize1()
CVAPI( long core_Mat_ElemSize1()
        {
            
            //long retVal = n_elemSize1(ptr);
            //return retVal;
        }

        // javadoc: Mat::empty()
CVAPI(bool core_Mat_Empty()
        {
            
            //bool retVal = n_empty(ptr);
            //return retVal;
        }

        // javadoc: Mat::eye(rows, cols, type)
CVAPI(Mat core_Mat_Eye(int rows, int cols, int type)
        {
            
            //Mat retVal = new Mat(n_eye(rows, cols, type));
            //return retVal;
        }

        // javadoc: Mat::inv(method)
CVAPI(Mat core_Mat_Inv(int method)
        {
            
            //Mat retVal = new Mat(n_inv(ptr, method));
            //return retVal;
        }

        // javadoc: Mat::inv()
CVAPI(Mat core_Mat_Inv()
        {
            
            //Mat retVal = new Mat(n_inv(ptr));
            //return retVal;
        }

        // javadoc: Mat::isContinuous()
CVAPI(bool core_Mat_IsContinuous()
        {
            
            //bool retVal = n_isContinuous(ptr);
            //return retVal;
        }

        // javadoc: Mat::isSubmatrix()
CVAPI(bool core_Mat_IsSubmatrix()
        {
            
            //bool retVal = n_isSubmatrix(ptr);
            //return retVal;
        }

        // javadoc: Mat::locateROI(wholeSize, ofs)
CVAPI(void core_Mat_LocateROI(Size wholeSize, Point ofs)
        {
            /*double[] wholeSizeOut = new double[2];
            double[] ofsOut = new double[2];
            locateROI_0(ptr, wholeSizeOut, ofsOut);
            wholeSize.Width = wholeSizeOut[0];
            wholeSize.Height = wholeSizeOut[1];
            ofs.X = ofsOut[0];
            ofs.Y = ofsOut[1];*/
            
        }
 
        // javadoc: Mat::mul(m, scale)
CVAPI(Mat core_Mat_Mul(Mat m, double scale)
        {
            
            //Mat retVal = new Mat(n_mul(ptr, m.ptr, scale));
            //return retVal;
        }

        // javadoc: Mat::mul(m)
CVAPI(Mat core_Mat_Mul(Mat m)
        {
            
            //Mat retVal = new Mat(n_mul(ptr, m.ptr));
            //return retVal;
        }

        // javadoc: Mat::ones(rows, cols, type)
CVAPI(Mat core_Mat_Ones(int rows, int cols, int type)
        {
            
            //Mat retVal = new Mat(n_ones(rows, cols, type));
            //return retVal;
        }

        // javadoc: Mat::ones(size, type)
CVAPI(Mat core_Mat_Ones(Size size, int type)
        {
            
            //Mat retVal = new Mat(n_ones(size.Width, size.Height, type));
            //return retVal;
        }

        // javadoc: Mat::push_back(m)
CVAPI(void core_Mat_PushBack(Mat m)
        {
            
            //n_push_back(ptr, m.ptr);
        }

        // javadoc: Mat::reshape(cn, rows)
CVAPI(Mat core_Mat_Reshape(int cn, int rows)
        {
            
            //Mat retVal = new Mat(n_reshape(ptr, cn, rows));
            //return retVal;
        }

        // javadoc: Mat::reshape(cn)
CVAPI(Mat core_Mat_Reshape(int cn)
        {
            
            //Mat retVal = new Mat(n_reshape(ptr, cn));
            //return retVal;
        }

        // javadoc: Mat::row(y)
CVAPI(Mat core_Mat_Row(int y)
        {
            
            //Mat retVal = new Mat(n_row(ptr, y));
            //return retVal;
        }

        // javadoc: Mat::rowRange(startrow, endrow)
CVAPI(Mat core_Mat_RowRange(int startrow, int endrow)
        {
            
            //Mat retVal = new Mat(n_rowRange(ptr, startrow, endrow));
            //return retVal;
        }

        // javadoc: Mat::rowRange(r)
CVAPI( Mat core_Mat_RowRange(Range r)
        {
            
            //Mat retVal = new Mat(n_rowRange(ptr, r.Start, r.End));
            //return retVal;
        }

        // javadoc: Mat::rows()
CVAPI(int core_Mat_Rows()
        {
            
            //int retVal = n_rows(ptr);
            //return retVal;
        }

        // javadoc: Mat::operator =(s)
CVAPI(Mat core_Mat_SetTo(Scalar s)
        {
            
            //Mat retVal = new Mat(n_setTo(ptr, s[0], s[1], s[2], s[3]));
            //return retVal;
        }

        // javadoc: Mat::setTo(value, mask)
CVAPI(Mat core_Mat_SetTo(Scalar value, Mat mask)
        {
            
            //Mat retVal = new Mat(n_setTo(ptr, value[0], value[1], value[2], value[3], mask.ptr));
            //return retVal;
        }

        // javadoc: Mat::setTo(value, mask)
CVAPI(Mat core_Mat_SetTo(Mat value, Mat mask)
        {
            
            //Mat retVal = new Mat(n_setTo(ptr, value.ptr, mask.ptr));
            //return retVal;
        }

        // javadoc: Mat::setTo(value)
CVAPI(Mat core_Mat_SetTo(Mat value)
        {
            
            //Mat retVal = new Mat(n_setTo(ptr, value.ptr));
            //return retVal;
        }

        // javadoc: Mat::size()
CVAPI(Size Size()
        {
            
            //double[] size = n_size(ptr);
            //Size retVal = new Size(size[0], size[1]);
            //return retVal;
        }

        //
        // C++: size_t Mat::step1(int i = 0)
        //

        // javadoc: Mat::step1(i)
CVAPI(long Step1(int i)
        {
            
            //long retVal = n_step1(ptr, i);
            //return retVal;
        }

        // javadoc: Mat::step1()
CVAPI(long Step1()
        {
            
            //long retVal = n_step1(ptr);
            //return retVal;
        }

        // javadoc: Mat::operator()(rowStart, rowEnd, colStart, colEnd)
CVAPI(Mat SubMat(int rowStart, int rowEnd, int colStart, int colEnd)
        {
            
            //Mat retVal = new Mat(n_submat_rr(ptr, rowStart, rowEnd, colStart, colEnd));
            //return retVal;
        }

        // javadoc: Mat::operator()(rowRange, colRange)
CVAPI(Mat SubMat(Range rowRange, Range colRange)
        {
            
            //Mat retVal = new Mat(n_submat_rr(ptr, rowRange.Start, rowRange.End, colRange.Start, colRange.End));
            //return retVal;
        }

        // javadoc: Mat::operator()(roi)
CVAPI(Mat SubMat(Rect roi)
        {
            
            //Mat retVal = new Mat(n_submat(ptr, roi.X, roi.Y, roi.Width, roi.Height));
            //return retVal;
        }

        // javadoc: Mat::t()
CVAPI(Mat T()
        {
            
            //Mat retVal = new Mat(n_t(ptr));
            //return retVal;
        }

        // javadoc: Mat::total()
CVAPI(long Total()
        {
            
            //long retVal = n_total(ptr);
            //return retVal;
        }

        // javadoc: Mat::type()
CVAPI(int Type()
        {
            
            //int retVal = n_type(ptr);
            //return retVal;
        }

        // javadoc: Mat::zeros(rows, cols, type)
CVAPI(Mat Zeros(int rows, int cols, int type)
        {
            
            //Mat retVal = new Mat(n_zeros(rows, cols, type));
            //return retVal;
        }

        // javadoc: Mat::zeros(size, type)
CVAPI( Mat Zeros(Size size, int type)
        {
            
            //Mat retVal = new Mat(n_zeros(size.Width, size.Height, type));
            //return retVal;
        }

        // javadoc:Mat::dump()
CVAPI(String Dump()
        {
            
            //return nDump(ptr);
        }

        // javadoc:Mat::put(row,col,data)
CVAPI(int Put(int row, int col, params double[] data)
        {
            
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            return nPutD(ptr, row, col, data.Length, data);*/
        }

        // javadoc:Mat::put(row,col,data)
CVAPI(int Put(int row, int col, float[] data)
        {
            
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
CVAPI(int Put(int row, int col, int[] data)
        {
            
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
CVAPI(int Put(int row, int col, short[] data)
        {
            
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
CVAPI(int Put(int row, int col, byte[] data)
        {
            
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
CVAPI(int Get(int row, int col, byte[] data)
        {
            
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
CVAPI(int Get(int row, int col, short[] data)
        {
            
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
CVAPI( int Get(int row, int col, int[] data)
        {
            
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
CVAPI(int Get(int row, int col, float[] data)
        {
            
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
CVAPI( int Get(int row, int col, double[] data)
        {
            
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
CVAPI( double[] Get(int row, int col)
        {
            
            //return nGet(ptr, row, col);
        }


#pragma endregion

#endif