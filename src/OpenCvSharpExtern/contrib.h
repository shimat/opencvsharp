/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_CONTRIB_H_
#define _CPP_CONTRIB_H_

#include "include_opencv.h"

CVAPI(CvAdaptiveSkinDetector*) contrib_CvAdaptiveSkinDetector_new(int samplingDivider, int morphingMethod)
{
	return new CvAdaptiveSkinDetector(samplingDivider, morphingMethod);
}
CVAPI(void) contrib_CvAdaptiveSkinDetector_delete(CvAdaptiveSkinDetector* obj)
{
	delete obj;
}
CVAPI(void) contrib_CvAdaptiveSkinDetector_process(CvAdaptiveSkinDetector* obj, IplImage *inputBGRImage, IplImage *outputHueMask)
{
	obj->process(inputBGRImage, outputHueMask);
}

#endif