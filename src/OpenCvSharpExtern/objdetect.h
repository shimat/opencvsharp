/*
* (C) 2008-2014 shimat
* This code is licenced under the LGPL.
*/

#ifndef _CPP_OBJDETECT_H_
#define _CPP_OBJDETECT_H_

#include "include_opencv.h"

CVAPI(cv::LatentSvmDetector*) objdetect_LatentSvmDetector_new1()
{
	return new cv::LatentSvmDetector();
}
CVAPI(cv::LatentSvmDetector*) objdetect_LatentSvmDetector_new2(
	const char** fileNames, int fileNamesLength,
	const char** classNames, int classNamesLength)
{
	std::vector<std::string> fileNamesVec(fileNames, fileNames + fileNamesLength);
	std::vector<std::string> classNamesVec(classNames, classNames + classNamesLength);
	return new cv::LatentSvmDetector(fileNamesVec, classNamesVec);
}

#endif