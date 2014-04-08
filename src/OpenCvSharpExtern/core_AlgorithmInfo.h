/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_CORE_ALGORITHM_H_
#define _CPP_CORE_ALGORITHM_H_

#include "include_opencv.h"

CVAPI(int) core_AlgorithmInfo_paramHelp(cv::AlgorithmInfo *obj, char *name, char *dst, int dstLength)
{
	std::string srcStr = obj->paramHelp(name);
	if(srcStr.empty())
		return 0;
	const char *src = srcStr.c_str();
	memcpy(dst, src, std::min(srcStr.size() + 1, (size_t)dstLength));
	return (int)srcStr.size();
}
CVAPI(int) core_AlgorithmInfo_paramType(cv::AlgorithmInfo *obj, char *name)
{
	return (int)obj->paramType(name);
}
CVAPI(int) core_AlgorithmInfo_name(cv::AlgorithmInfo *obj, char *dst, int dstLength) 
{
	std::string srcStr = obj->name();
	if(srcStr.empty())
		return 0;
	const char *src = srcStr.c_str();
	memcpy(dst, src, std::min(srcStr.size() + 1, (size_t)dstLength));
	return (int)srcStr.size();
}

#endif