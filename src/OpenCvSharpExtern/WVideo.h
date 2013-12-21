/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */


#ifndef _CPP_WCV_H_
#define _CPP_WCV_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/video/background_segm.hpp>

// BackgroundSubtractor
CVAPI(int) BackgroundSubtractor_sizeof()
{
	return sizeof(cv::BackgroundSubtractor);
}
CVAPI(void) BackgroundSubtractor_getBackgroundImage(cv::BackgroundSubtractor* obj, cv::_OutputArray* backgroundImage)
{
	obj->getBackgroundImage(*backgroundImage);
}


// BackgroundSubtractorMOG
CVAPI(int) BackgroundSubtractorMOG_sizeof()
{
	return sizeof(cv::BackgroundSubtractorMOG);
}
CVAPI(cv::BackgroundSubtractorMOG*) BackgroundSubtractorMOG_new1()
{
	return new cv::BackgroundSubtractorMOG();
}
CVAPI(cv::BackgroundSubtractorMOG*) BackgroundSubtractorMOG_new2(int history, int nmixtures, double backgroundRatio, double noiseSigma)
{
	return new cv::BackgroundSubtractorMOG(history, nmixtures, backgroundRatio, noiseSigma);
}
CVAPI(void) BackgroundSubtractorMOG_delete(cv::BackgroundSubtractorMOG* obj)
{
	delete obj;
}
CVAPI(void) BackgroundSubtractorMOG_operator(cv::BackgroundSubtractorMOG* obj, cv::Mat* image, cv::Mat* fgmask, double learningRate)
{
	(*obj)(*image, *fgmask, learningRate);
}    
CVAPI(void) BackgroundSubtractorMOG_initialize(cv::BackgroundSubtractorMOG* obj, CvSize frameSize, int frameType)
{
	obj->initialize(frameSize, frameType);
}
/*
CVAPI(CvSize) BackgroundSubtractorMOG_frameSize_get(cv::BackgroundSubtractorMOG* obj)
{
	return obj->frameSize;
}
CVAPI(void) BackgroundSubtractorMOG_frameSize_set(cv::BackgroundSubtractorMOG* obj, CvSize value)
{
	obj->frameSize = value;
}
CVAPI(int*) BackgroundSubtractorMOG_frameType(cv::BackgroundSubtractorMOG* obj)
{
	return &(obj->frameType);
}
CVAPI(cv::Mat*) BackgroundSubtractorMOG_bgmodel(cv::BackgroundSubtractorMOG* obj)
{
	return &(obj->bgmodel);
}
CVAPI(int*) BackgroundSubtractorMOG_nframes(cv::BackgroundSubtractorMOG* obj)
{
	return &(obj->nframes);
}
CVAPI(int*) BackgroundSubtractorMOG_history(cv::BackgroundSubtractorMOG* obj)
{
	return &(obj->history);
}
CVAPI(int*) BackgroundSubtractorMOG_nmixtures(cv::BackgroundSubtractorMOG* obj)
{
	return &(obj->nmixtures);
}
CVAPI(double*) BackgroundSubtractorMOG_varThreshold(cv::BackgroundSubtractorMOG* obj)
{
	return &(obj->varThreshold);
}
CVAPI(double*) BackgroundSubtractorMOG_backgroundRatio(cv::BackgroundSubtractorMOG* obj)
{
	return &(obj->backgroundRatio);
}
CVAPI(double*) BackgroundSubtractorMOG_noiseSigma(cv::BackgroundSubtractorMOG* obj)
{
	return &(obj->noiseSigma);
}
*/
	

// BackgroundSubtractorMOG2
CVAPI(int) BackgroundSubtractorMOG2_sizeof()
{
	return sizeof(cv::BackgroundSubtractorMOG2);
}
CVAPI(cv::BackgroundSubtractorMOG2*) BackgroundSubtractorMOG2_new1()
{
	return new cv::BackgroundSubtractorMOG2();
}
CVAPI(cv::BackgroundSubtractorMOG2*) BackgroundSubtractorMOG2_new2(int history, float varThreshold, int bShadowDetection)
{
	return new cv::BackgroundSubtractorMOG2(history, varThreshold, bShadowDetection!=0);
}
CVAPI(void) BackgroundSubtractorMOG2_delete(cv::BackgroundSubtractorMOG2* obj)
{
	delete obj;
}
CVAPI(void) BackgroundSubtractorMOG2_operator(cv::BackgroundSubtractorMOG2* obj, cv::_InputArray* image, cv::_OutputArray* fgmask, double learningRate)
{
	(*obj)(*image, *fgmask, learningRate);
}  
CVAPI(void) BackgroundSubtractorMOG2_getBackgroundImage(cv::BackgroundSubtractorMOG2* obj, cv::_OutputArray* backgroundImage)
{
	obj->getBackgroundImage(*backgroundImage);
}
CVAPI(void) BackgroundSubtractorMOG2_initialize(cv::BackgroundSubtractorMOG2* obj, CvSize frameSize, int frameType)
{
	obj->initialize(frameSize, frameType);
}
/*
CVAPI(CvSize) BackgroundSubtractorMOG2_frameSize_get(cv::BackgroundSubtractorMOG2* obj)
{
	return obj->frameSize;
}
CVAPI(void) BackgroundSubtractorMOG2_frameSize_set(cv::BackgroundSubtractorMOG2* obj, CvSize value)
{
	obj->frameSize = value;
}
CVAPI(int*) BackgroundSubtractorMOG2_frameType(cv::BackgroundSubtractorMOG2* obj)
{
	return &(obj->frameType);
}
CVAPI(cv::Mat*) BackgroundSubtractorMOG2_bgmodel(cv::BackgroundSubtractorMOG2* obj)
{
	return &(obj->bgmodel);
}
CVAPI(cv::Mat*) BackgroundSubtractorMOG2_bgmodelUsedModes(cv::BackgroundSubtractorMOG2* obj)
{
	return &(obj->bgmodelUsedModes);
}
CVAPI(int*) BackgroundSubtractorMOG2_nframes(cv::BackgroundSubtractorMOG2* obj)
{
	return &(obj->nframes);
}
CVAPI(int*) BackgroundSubtractorMOG2_history(cv::BackgroundSubtractorMOG2* obj)
{
	return &(obj->history);
}
CVAPI(int*) BackgroundSubtractorMOG2_nmixtures(cv::BackgroundSubtractorMOG2* obj)
{
	return &(obj->nmixtures);
}
CVAPI(float*) BackgroundSubtractorMOG2_varThreshold(cv::BackgroundSubtractorMOG2* obj)
{
	return &(obj->varThreshold);
}
CVAPI(float*) BackgroundSubtractorMOG2_backgroundRatio(cv::BackgroundSubtractorMOG2* obj)
{
	return &(obj->backgroundRatio);
}
CVAPI(float*) BackgroundSubtractorMOG2_varThresholdGen(cv::BackgroundSubtractorMOG2* obj)
{
	return &(obj->varThresholdGen);
}
CVAPI(float*) BackgroundSubtractorMOG2_fVarInit(cv::BackgroundSubtractorMOG2* obj)
{
	return &(obj->fVarInit);
}
CVAPI(float*) BackgroundSubtractorMOG2_fVarMin(cv::BackgroundSubtractorMOG2* obj)
{
	return &(obj->fVarMin);
}
CVAPI(float*) BackgroundSubtractorMOG2_fVarMax(cv::BackgroundSubtractorMOG2* obj)
{
	return &(obj->fVarMax);
}
CVAPI(float*) BackgroundSubtractorMOG2_fCT(cv::BackgroundSubtractorMOG2* obj)
{
	return &(obj->fCT);
}
CVAPI(bool*) BackgroundSubtractorMOG2_bShadowDetection(cv::BackgroundSubtractorMOG2* obj)
{
	return &(obj->bShadowDetection);
}
CVAPI(unsigned char*) BackgroundSubtractorMOG2_nShadowDetection(cv::BackgroundSubtractorMOG2* obj)
{
	return &(obj->nShadowDetection);
}
CVAPI(float*) BackgroundSubtractorMOG2_fTau(cv::BackgroundSubtractorMOG2* obj)
{
	return &(obj->fTau);
}
*/
#endif