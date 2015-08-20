#ifndef _CPP_VIDEO_BACKGROUND_SEGM_H_
#define _CPP_VIDEO_BACKGROUND_SEGM_H_

#include "include_opencv.h"


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
	return new cv::Ptr<cv::BackgroundSubtractorMOG>(new cv::BackgroundSubtractorMOG());
}
CVAPI(cv::Ptr<cv::BackgroundSubtractorMOG>*) video_BackgroundSubtractorMOG_new2(int history, int nmixtures, double backgroundRatio, double noiseSigma)
{
	return new cv::Ptr<cv::BackgroundSubtractorMOG>(new cv::BackgroundSubtractorMOG(history, nmixtures, backgroundRatio, noiseSigma));
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

CVAPI(cv::AlgorithmInfo*) video_BackgroundSubtractorMOG_info(cv::BackgroundSubtractorMOG *obj)
{
	return obj->info();
}


// BackgroundSubtractorMOG2
CVAPI(cv::Ptr<cv::BackgroundSubtractorMOG2>*) video_BackgroundSubtractorMOG2_new1()
{
	return new cv::Ptr<cv::BackgroundSubtractorMOG2>(new cv::BackgroundSubtractorMOG2());
}
CVAPI(cv::Ptr<cv::BackgroundSubtractorMOG2>*) video_BackgroundSubtractorMOG2_new2(
	int history, float varThreshold, int bShadowDetection)
{
	return new cv::Ptr<cv::BackgroundSubtractorMOG2>(new cv::BackgroundSubtractorMOG2(history, varThreshold, bShadowDetection != 0));
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
CVAPI(cv::BackgroundSubtractorMOG2*) video_Ptr_BackgroundSubtractorMOG2_obj(
	cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr)
{
	return ptr->obj;
}

CVAPI(cv::AlgorithmInfo*) video_BackgroundSubtractorMOG2_info(cv::BackgroundSubtractorMOG2 *obj)
{
	return obj->info();
}


// BackgroundSubtractorGMG
CVAPI(cv::Ptr<cv::BackgroundSubtractorGMG>*) video_BackgroundSubtractorGMG_new()
{
	return new cv::Ptr<cv::BackgroundSubtractorGMG>(new cv::BackgroundSubtractorGMG());
}
CVAPI(void) video_BackgroundSubtractorGMG_delete(cv::BackgroundSubtractorGMG *obj)
{
	delete obj;
}
CVAPI(void) video_BackgroundSubtractorGMG_operator(
	cv::BackgroundSubtractorGMG *obj, cv::_InputArray *image, cv::_OutputArray *fgmask, double learningRate)
{
	(*obj)(*image, *fgmask, learningRate);
}
CVAPI(void) video_BackgroundSubtractorGMG_release(cv::BackgroundSubtractorGMG *obj)
{
	obj->release();
}
CVAPI(void) video_BackgroundSubtractorGMG_initialize(
	cv::BackgroundSubtractorGMG *obj, CvSize frameSize, double min, double max)
{
	obj->initialize(frameSize, min, max);
}

CVAPI(void) video_Ptr_BackgroundSubtractorGMG_delete(cv::Ptr<cv::BackgroundSubtractorGMG> *ptr)
{
	delete ptr;
}
CVAPI(cv::BackgroundSubtractorGMG*) video_Ptr_BackgroundSubtractorGMG_obj(
	cv::Ptr<cv::BackgroundSubtractorGMG> *ptr)
{
	return ptr->obj;
}

CVAPI(cv::AlgorithmInfo*) video_BackgroundSubtractorGMG_info(cv::BackgroundSubtractorGMG *obj)
{
	return obj->info();
}


CVAPI(int*) video_BackgroundSubtractorGMG_maxFeatures(cv::BackgroundSubtractorGMG *obj)
{
	return &(obj->maxFeatures);
}
CVAPI(double*) video_BackgroundSubtractorGMG_learningRate(cv::BackgroundSubtractorGMG *obj)
{
	return &(obj->learningRate);
}
CVAPI(int*) video_BackgroundSubtractorGMG_numInitializationFrames(cv::BackgroundSubtractorGMG *obj)
{
	return &(obj->numInitializationFrames);
}
CVAPI(int*) video_BackgroundSubtractorGMG_quantizationLevels(cv::BackgroundSubtractorGMG *obj)
{
	return &(obj->quantizationLevels);
}
CVAPI(double*) video_BackgroundSubtractorGMG_backgroundPrior(cv::BackgroundSubtractorGMG *obj)
{
	return &(obj->backgroundPrior);
}
CVAPI(double*) video_BackgroundSubtractorGMG_decisionThreshold(cv::BackgroundSubtractorGMG *obj)
{
	return &(obj->decisionThreshold);
}
CVAPI(int*) video_BackgroundSubtractorGMG_smoothingRadius(cv::BackgroundSubtractorGMG *obj)
{
	return &(obj->smoothingRadius);
}
CVAPI(int) video_BackgroundSubtractorGMG_updateBackgroundModel_get(cv::BackgroundSubtractorGMG *obj)
{
	return obj->updateBackgroundModel ? 1 : 0;
}
CVAPI(void) video_BackgroundSubtractorGMG_updateBackgroundModel_set(cv::BackgroundSubtractorGMG *obj, int value)
{
	obj->updateBackgroundModel = (value != 0);
}

#endif