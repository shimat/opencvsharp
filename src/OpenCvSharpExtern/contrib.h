#if WIN32
#pragma once
#endif

#ifndef _CPP_CONTRIB_H_
#define _CPP_CONTRIB_H_

#include "include_opencv.h"

CVAPI(int) contrib_initModule_contrib()
{
    return cv::initModule_contrib() ? 1 : 0;
}

CVAPI(void) contrib_applyColorMap(cv::_InputArray *src, cv::_OutputArray *dst, int colormap)
{
    cv::applyColorMap(*src, *dst, colormap);
}

#pragma region CvAdaptiveSkinDetector
CVAPI(CvAdaptiveSkinDetector*) contrib_CvAdaptiveSkinDetector_new(int samplingDivider, int morphingMethod)
{
	return new CvAdaptiveSkinDetector(samplingDivider, morphingMethod);
}
CVAPI(void) contrib_CvAdaptiveSkinDetector_delete(CvAdaptiveSkinDetector *obj)
{
	delete obj;
}
CVAPI(void) contrib_CvAdaptiveSkinDetector_process(CvAdaptiveSkinDetector *obj, IplImage *inputBGRImage, IplImage *outputHueMask)
{
	obj->process(inputBGRImage, outputHueMask);
}
#pragma endregion

#pragma region FaceRecognizer

CVAPI(void) contrib_FaceRecognizer_delete(cv::FaceRecognizer *obj) 
{
    delete obj;
}

CVAPI(void) contrib_FaceRecognizer_train(
    cv::FaceRecognizer *obj, cv::Mat **src, int srcLength, int *labels, int labelsLength)
{
    std::vector<cv::Mat> srcVec(srcLength);
    for (int i = 0; i < srcLength; i++)
        srcVec[i] = *src[i];
    std::vector<int> labelsVec(labels, labels + labelsLength);
    obj->train(srcVec, labelsVec);
}

CVAPI(void) contrib_FaceRecognizer_update(
    cv::FaceRecognizer *obj, cv::Mat **src, int srcLength, int *labels, int labelsLength)
{
    std::vector<cv::Mat> srcVec(srcLength);
    for (int i = 0; i < srcLength; i++)
        srcVec[i] = *src[i];
    std::vector<int> labelsVec(labels, labels + labelsLength);
    obj->update(srcVec, labelsVec);
}
CVAPI(int) contrib_FaceRecognizer_predict1(cv::FaceRecognizer *obj, cv::_InputArray *src)
{
    return obj->predict(*src);
}
CVAPI(void) contrib_FaceRecognizer_predict2(
    cv::FaceRecognizer *obj, cv::_InputArray *src, int *label, double *confidence)
{
    obj->predict(*src, *label, *confidence);
}

CVAPI(void) contrib_FaceRecognizer_save1(cv::FaceRecognizer *obj, const char *filename)
{
    obj->save(filename);
}
CVAPI(void) contrib_FaceRecognizer_load1(cv::FaceRecognizer *obj, const char *filename)
{
    obj->load(filename);
}
CVAPI(void) contrib_FaceRecognizer_save2(cv::FaceRecognizer *obj, cv::FileStorage *fs)
{
    obj->save(*fs);
}
CVAPI(void) contrib_FaceRecognizer_load2(cv::FaceRecognizer *obj, cv::FileStorage *fs)
{
    obj->load(*fs);
}
CVAPI(cv::AlgorithmInfo*) contrib_FaceRecognizer_info(cv::FaceRecognizer *obj)
{
    return obj->info();
}

CVAPI(cv::Ptr<cv::FaceRecognizer>*) contrib_createEigenFaceRecognizer(int numComponents, double threshold)
{
    return clone(cv::createEigenFaceRecognizer(numComponents, threshold));
}
CVAPI(cv::Ptr<cv::FaceRecognizer>*) contrib_createFisherFaceRecognizer(int numComponents, double threshold)
{
    return clone(cv::createFisherFaceRecognizer(numComponents, threshold));
}
CVAPI(cv::Ptr<cv::FaceRecognizer>*) contrib_createLBPHFaceRecognizer(
    int radius, int neighbors, int gridX, int gridY, double threshold)
{
    return clone(cv::createLBPHFaceRecognizer(radius, neighbors, gridX, gridY, threshold));
}

CVAPI(cv::FaceRecognizer*) contrib_Ptr_FaceRecognizer_obj(cv::Ptr<cv::FaceRecognizer> *obj)
{
    return obj->obj;
}
CVAPI(void) contrib_Ptr_FaceRecognizer_delete(cv::Ptr<cv::FaceRecognizer> *obj)
{
    delete obj;
}


#pragma endregion

#endif