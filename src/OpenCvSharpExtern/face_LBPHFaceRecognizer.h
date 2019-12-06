#ifndef _CPP_FACE_LBPHFACERECOGNIZER_H_
#define _CPP_FACE_LBPHFACERECOGNIZER_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(cv::Ptr<cv::face::LBPHFaceRecognizer>*) face_LBPHFaceRecognizer_create(
	const int radius, const int neighbors, const int gridX, const int gridY, const double threshold)
{
	const auto r = cv::face::LBPHFaceRecognizer::create(radius, neighbors, gridX, gridY, threshold);
	return clone(r);
}

CVAPI(int) face_LBPHFaceRecognizer_getGridX(cv::face::LBPHFaceRecognizer *obj)
{
    return obj->getGridX();
}
CVAPI(void) face_LBPHFaceRecognizer_setGridX(cv::face::LBPHFaceRecognizer *obj, int val)
{
    obj->setGridX(val);
}
CVAPI(int) face_LBPHFaceRecognizer_getGridY(cv::face::LBPHFaceRecognizer *obj)
{
    return obj->getGridY();
}
CVAPI(void) face_LBPHFaceRecognizer_setGridY(cv::face::LBPHFaceRecognizer *obj, int val)
{
    obj->setGridY(val);
}
CVAPI(int) face_LBPHFaceRecognizer_getRadius(cv::face::LBPHFaceRecognizer *obj)
{
    return obj->getRadius();
}
CVAPI(void) face_LBPHFaceRecognizer_setRadius(cv::face::LBPHFaceRecognizer *obj, int val)
{
    obj->setRadius(val);
}
CVAPI(int) face_LBPHFaceRecognizer_getNeighbors(cv::face::LBPHFaceRecognizer *obj)
{
    return obj->getNeighbors();
}
CVAPI(void) face_LBPHFaceRecognizer_setNeighbors(cv::face::LBPHFaceRecognizer *obj, int val)
{
    obj->setNeighbors(val);
}
CVAPI(double) face_LBPHFaceRecognizer_getThreshold(cv::face::LBPHFaceRecognizer *obj)
{
    return obj->getThreshold();
}
CVAPI(void) face_LBPHFaceRecognizer_setThreshold(cv::face::LBPHFaceRecognizer *obj, double val)
{
    obj->setThreshold(val);
}
CVAPI(void) face_LBPHFaceRecognizer_getHistograms(cv::face::LBPHFaceRecognizer *obj, std::vector<cv::Mat> *dst)
{
    std::vector<cv::Mat> result = obj->getHistograms();
    dst->clear();
    dst->reserve(result.size());
    for (size_t i = 0; i < result.size(); i++)
    {
        dst->at(i) = result[i];
    }
}
CVAPI(void) face_LBPHFaceRecognizer_getLabels(cv::face::LBPHFaceRecognizer *obj, cv::Mat *dst)
{
    cv::Mat result = obj->getLabels();
    result.copyTo(*dst);
}


CVAPI(cv::face::LBPHFaceRecognizer*) face_Ptr_LBPHFaceRecognizer_get(cv::Ptr<cv::face::LBPHFaceRecognizer> *obj)
{
    return obj->get();
}
CVAPI(void) face_Ptr_LBPHFaceRecognizer_delete(cv::Ptr<cv::face::LBPHFaceRecognizer> *obj)
{
    delete obj;
}


#endif