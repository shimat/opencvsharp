/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_VIDEO_H_
#define _CPP_VIDEO_H_

#include "include_opencv.h"

#pragma region background_segm

// BackgroundSubtractor
CVAPI(void) video_BackgroundSubtractor_getBackgroundImage(cv::BackgroundSubtractor *obj, cv::_OutputArray *backgroundImage)
{
	obj->getBackgroundImage(*backgroundImage);
}
CVAPI(void) video_BackgroundSubtractor_operator(cv::BackgroundSubtractor *obj, cv::_InputArray *image, cv::_OutputArray *fgmask, double learningRate)
{
	(*obj)(*image, *fgmask, learningRate);
}  

CVAPI(void) video_Ptr_BackgroundSubtractor_delete(cv::Ptr<cv::BackgroundSubtractor> *ptr)
{
	delete ptr;
}
CVAPI(cv::BackgroundSubtractor*) video_Ptr_BackgroundSubtractor_obj(cv::Ptr<cv::BackgroundSubtractor> *ptr)
{
    return ptr->obj;
}

CVAPI(cv::AlgorithmInfo*) video_BackgroundSubtractor_info(cv::BackgroundSubtractor *obj)
{
	return obj->info();
}

// BackgroundSubtractorMOG
CVAPI(cv::Ptr<cv::BackgroundSubtractorMOG>*) video_BackgroundSubtractorMOG_new1()
{
	return wrap( new cv::BackgroundSubtractorMOG() );
}
CVAPI(cv::Ptr<cv::BackgroundSubtractorMOG>*) video_BackgroundSubtractorMOG_new2(int history, int nmixtures, double backgroundRatio, double noiseSigma)
{
	return wrap( new cv::BackgroundSubtractorMOG(history, nmixtures, backgroundRatio, noiseSigma) );
}
CVAPI(void) video_BackgroundSubtractorMOG_delete(cv::BackgroundSubtractorMOG *obj)
{
	delete obj;
}
CVAPI(void) video_BackgroundSubtractorMOG_operator(cv::BackgroundSubtractorMOG *obj, cv::_InputArray *image, cv::_OutputArray *fgmask, double learningRate)
{
	(*obj)(*image, *fgmask, learningRate);
}    
CVAPI(void) video_BackgroundSubtractorMOG_initialize(cv::BackgroundSubtractorMOG *obj, CvSize frameSize, int frameType)
{
	obj->initialize(frameSize, frameType);
}

CVAPI(void) video_Ptr_BackgroundSubtractorMOG_delete(cv::Ptr<cv::BackgroundSubtractorMOG> *ptr)
{
	delete ptr;
}
CVAPI(cv::BackgroundSubtractorMOG*) video_Ptr_BackgroundSubtractorMOG_obj(cv::Ptr<cv::BackgroundSubtractorMOG> *ptr)
{
    return ptr->obj;
}
	

// BackgroundSubtractorMOG2
CVAPI(cv::Ptr<cv::BackgroundSubtractorMOG2>*) video_BackgroundSubtractorMOG2_new1()
{
	return wrap( new cv::BackgroundSubtractorMOG2());
}
CVAPI(cv::Ptr<cv::BackgroundSubtractorMOG2>*) video_BackgroundSubtractorMOG2_new2(
    int history, float varThreshold, int bShadowDetection)
{
	return wrap( new cv::BackgroundSubtractorMOG2(history, varThreshold, bShadowDetection!=0) );
}
CVAPI(void) video_BackgroundSubtractorMOG2_delete(cv::BackgroundSubtractorMOG2 *obj)
{
	delete obj;
}
CVAPI(void) video_BackgroundSubtractorMOG2_operator(
    cv::BackgroundSubtractorMOG2 *obj, cv::_InputArray *image, cv::_OutputArray *fgmask, double learningRate)
{
	(*obj)(*image, *fgmask, learningRate);
}  
CVAPI(void) video_BackgroundSubtractorMOG2_getBackgroundImage(
    cv::BackgroundSubtractorMOG2 *obj, cv::_OutputArray *backgroundImage)
{
	obj->getBackgroundImage(*backgroundImage);
}
CVAPI(void) video_BackgroundSubtractorMOG2_initialize(
    cv::BackgroundSubtractorMOG2 *obj, CvSize frameSize, int frameType)
{
	obj->initialize(frameSize, frameType);
}

CVAPI(void) video_Ptr_BackgroundSubtractorMOG2_delete(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr)
{
	delete ptr;
}
CVAPI(cv::BackgroundSubtractorMOG2*) video_Ptr_BackgroundSubtractorMOG2_obj(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr)
{
    return ptr->obj;
}

#pragma endregion

#endif