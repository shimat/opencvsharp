/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_WHIGHGUI_H_
#define _CPP_WHIGHGUI_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#pragma warning(disable: 4996)
#endif
#include <opencv2/highgui/highgui.hpp>

CVAPI(void) cv_namedWindow( const char* winname, int flags )
{
	std::string winname_str(winname);
	cv::namedWindow(winname_str, flags);
}
CVAPI(void) cv_imshow( const char* winname, cv::Mat* mat )
{
	std::string winname_str(winname);
	cv::imshow(winname_str, *mat);
}
CVAPI(void) cv_imread( const char* filename, int flags, cv::Mat* outValue )
{
	std::string filename_str(filename);
	cv::Mat mat = cv::imread(filename_str, flags);
	mat.addref();
	*outValue = mat;
}
CVAPI(bool) cv_imwrite( const char* filename, cv::Mat* img, const int* params, int params_length)
{
	std::string filename_str(filename);
	std::vector<int> params_v(params, params + params_length);
	cv::Mat& imgRef = *img;
	return cv::imwrite(filename_str, imgRef, params_v);
}
CVAPI(void) cv_imdecode( cv::Mat* buf, int flags, cv::Mat* outValue )
{
	cv::Mat& bufRef = *buf;
	*outValue = cv::imdecode(bufRef, flags);
}
CVAPI(bool) cv_imencode( const char* ext, cv::Mat* img, std::vector<uchar>* buf, const int* params, int params_length)
{
	std::string ext_str(ext);
	std::vector<int> params_v(params, params + params_length);
	cv::Mat& imgRef = *img;
	return cv::imencode(ext_str, imgRef, *buf, params_v);
}
CVAPI(int) cv_waitKey(int delay)
{
	return cv::waitKey(delay);
}

#endif