#ifndef _CPP_TEXT_TEXTDETECTOR_H_
#define _CPP_TEXT_TEXTDETECTOR_H_

#include "include_opencv.h"

CVAPI(void) text_TextDetector_detect(cv::text::TextDetector *obj, cv::_InputArray *inputImage, std::vector<cv::Rect> *Bbox, std::vector<float> *confidence)
{
    obj->detect(*inputImage, *Bbox, *confidence);
}

CVAPI(void) text_TextDetectorCNN_detect(cv::text::TextDetectorCNN *obj, cv::_InputArray *inputImage, std::vector<cv::Rect> *Bbox, std::vector<float> *confidence)
{
    obj->detect(*inputImage, *Bbox, *confidence);
}

CVAPI(cv::Ptr<cv::text::TextDetectorCNN>*) text_TextDetectorCNN_create1(
    const char *modelArchFilename, const char *modelWeightsFilename, MyCvSize *detectionSizes, int detectionSizesLength)
{
    std::vector<cv::Size> detectionSizesVec;
    if (detectionSizes != nullptr)
    {
        detectionSizesVec.resize(detectionSizesLength);
        for (int i = 0; i < detectionSizesLength; i++)
            detectionSizesVec[i] = cpp(detectionSizes[i]);
    }

    const auto ptr = cv::text::TextDetectorCNN::create(modelArchFilename, modelWeightsFilename, detectionSizesVec);
    return new cv::Ptr<cv::text::TextDetectorCNN>(ptr);
}

CVAPI(cv::Ptr<cv::text::TextDetectorCNN>*) text_TextDetectorCNN_create2(
    const char *modelArchFilename, const char *modelWeightsFilename)
{
    const auto ptr = cv::text::TextDetectorCNN::create(modelArchFilename, modelWeightsFilename);
    return new cv::Ptr<cv::text::TextDetectorCNN>(ptr);
}

CVAPI(void) text_Ptr_TextDetectorCNN_delete(cv::Ptr<cv::text::TextDetectorCNN> *obj)
{
    delete obj;
}

CVAPI(cv::text::TextDetectorCNN*) text_Ptr_TextDetectorCNN_get(cv::Ptr<cv::text::TextDetectorCNN>* obj)
{
    return obj->get();
}

#endif