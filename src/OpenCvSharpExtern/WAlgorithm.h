/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_CORE_WALGORITHM_H_
#define _CPP_CORE_WALGORITHM_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/core/core.hpp>
#include <vector>
#include <algorithm>
#include <iterator>

CVAPI(cv::Algorithm*) cv_Algorithm_new()
{
	return new cv::Algorithm();
}
CVAPI(void) cv_Algorithm_delete(cv::Algorithm* obj)
{
	delete obj;
}
CVAPI(void) cv_Algorithm_name(cv::Algorithm* obj, char* buf)
{
	strcpy(buf, obj->name().c_str());
}
CVAPI(int) cv_Algorithm_sizeof()
{
	return sizeof(cv::Algorithm);
}

CVAPI(int) cv_Algorithm_getInt(cv::Algorithm* obj, const char* name)
{
	return obj->getInt(name);
}
CVAPI(double) cv_Algorithm_getDouble(cv::Algorithm* obj, const char* name)
{
	return obj->getDouble(name);
}
CVAPI(bool) cv_Algorithm_getBool(cv::Algorithm* obj, const char* name)
{
	return obj->getBool(name);
}
CVAPI(void) cv_Algorithm_getString(cv::Algorithm* obj, const char* name, char* buf) 
{
	std::string str = obj->getString(name);
	strcpy(buf, str.c_str());
}
CVAPI(void) cv_Algorithm_getMat(cv::Algorithm* obj, const char* name, cv::Mat* outMat) 
{
	cv::Mat mat = obj->getMat(name);
	outMat = new cv::Mat(mat);
}
CVAPI(void) cv_Algorithm_getMatVector(cv::Algorithm* obj, const char* name, std::vector<cv::Mat>* outVec)
{
	std::vector<cv::Mat> vec = obj->getMatVector(name);
	outVec = new std::vector<cv::Mat>(vec.size());
	std::copy(vec.begin(), vec.end(), std::back_inserter(*outVec));
}
CVAPI(cv::Algorithm*) cv_Algorithm_getAlgorithm(cv::Algorithm* obj, const char* name)
{
	return obj->getAlgorithm(name);
}

CVAPI(void) cv_Algorithm_setInt(cv::Algorithm* obj, const char* name, int value)
{
	obj->set(name, value);
}
CVAPI(void) cv_Algorithm_setDouble(cv::Algorithm* obj, const char* name, double value)
{
	obj->set(name, value);
}
CVAPI(void) cv_Algorithm_setBool(cv::Algorithm* obj, const char* name, bool value)
{
	obj->set(name, value);
}
CVAPI(void) cv_Algorithm_setString(cv::Algorithm* obj, const char* name, const char* value)
{
	std::string str(value);
	obj->set(name, str);
}
CVAPI(void) cv_Algorithm_setMat(cv::Algorithm* obj, const char* name, const cv::Mat* value)
{
	obj->set(name, *value);
}
CVAPI(void) cv_Algorithm_setMatVector(cv::Algorithm* obj, const char* name, const std::vector<cv::Mat>* value)
{
	obj->set(name, *value);
}
CVAPI(void) cv_Algorithm_setAlgorithm(cv::Algorithm* obj, const char* name, const cv::Algorithm* value)
{
	obj->set(name, value);
}

#endif