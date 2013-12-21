/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_WHOGDESCRIPTOR_H_
#define _CPP_WHOGDESCRIPTOR_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#pragma warning(disable: 4996)
#endif
#include <opencv2/opencv.hpp>

CVAPI(CvAdaptiveSkinDetector*) CvAdaptiveSkinDetector_new(int samplingDivider, int morphingMethod)
{
	return new CvAdaptiveSkinDetector(samplingDivider, morphingMethod);
}
CVAPI(void) CvAdaptiveSkinDetector_delete(CvAdaptiveSkinDetector* obj)
{
	delete obj;
}
CVAPI(void) CvAdaptiveSkinDetector_process(CvAdaptiveSkinDetector* obj, IplImage *inputBGRImage, IplImage *outputHueMask)
{
	obj->process(inputBGRImage, outputHueMask);
}

#endif