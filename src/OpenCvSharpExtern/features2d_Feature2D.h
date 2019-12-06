#ifndef _CPP_FEATURES2DFEATUREDETECTOR_H_
#define _CPP_FEATURES2DFEATUREDETECTOR_H_

#include "include_opencv.h"

#pragma region Feature2D

/*CVAPI(ExceptionStatus) features2d_Ptr_Feature2D_get(cv::Ptr<cv::Feature2D>* ptr, cv::Feature2D **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}*/
/*CVAPI(ExceptionStatus) features2d_Ptr_Feature2D_delete(cv::Ptr<cv::Feature2D>* ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}*/

CVAPI(ExceptionStatus) features2d_Feature2D_detect_Mat1(
    cv::Feature2D *detector,
    cv::Mat *image,
    std::vector<cv::KeyPoint> *keypoints,
    cv::Mat *mask)
{
    BEGIN_WRAP
    detector->detect(*image, *keypoints, entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Feature2D_detect_Mat2(
    cv::Feature2D *detector,
    cv::Mat **images, int imageLength,
    std::vector<std::vector<cv::KeyPoint> > *keypoints, 
    cv::Mat **mask)
{
    BEGIN_WRAP
    std::vector<cv::Mat> imageVec(imageLength);
    std::vector<cv::Mat> maskVec;
    
    for (int i = 0; i < imageLength; i++)
        imageVec.push_back(*images[i]);
    
    if (mask != nullptr)
    {
        maskVec.reserve(imageLength);
        for (int i = 0; i < imageLength; i++)
            maskVec.push_back(*mask[i]);
    }

    detector->detect(imageVec, *keypoints, maskVec);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Feature2D_detect_InputArray(
    cv::Feature2D *obj, cv::_InputArray *image, std::vector<cv::KeyPoint> *keypoints, cv::Mat *mask)
{
    BEGIN_WRAP
    obj->detect(*image, *keypoints, entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Feature2D_compute1(
    cv::Feature2D *obj,
    cv::_InputArray *image, std::vector<cv::KeyPoint> *keypoints, cv::_OutputArray *descriptors)
{
    BEGIN_WRAP
    obj->compute(*image, *keypoints, *descriptors);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Feature2D_compute2(
    cv::Feature2D *detector, cv::Mat **images, int imageLength,
    std::vector<std::vector<cv::KeyPoint> > *keypoints, cv::Mat **descriptors, int descriptorsLength)
{
    BEGIN_WRAP
    std::vector<cv::Mat> imageVec(imageLength);
    std::vector<cv::Mat> descriptorsVec(descriptorsLength);
    
    for (int i = 0; i < imageLength; i++)
        imageVec.push_back(*images[i]);
    for (int i = 0; i < descriptorsLength; i++)
        descriptorsVec.push_back(*descriptors[i]);

    detector->compute(imageVec, *keypoints, descriptorsVec);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Feature2D_detectAndCompute(
    cv::Feature2D *detector, cv::_InputArray *image, cv::_InputArray *mask, 
    std::vector<cv::KeyPoint> *keypoints, cv::_OutputArray *descriptors, int useProvidedKeypoints)
{
    BEGIN_WRAP
    detector->detectAndCompute(entity(image), entity(mask), *keypoints, *descriptors, useProvidedKeypoints != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Feature2D_descriptorSize(cv::Feature2D *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->descriptorSize();
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_Feature2D_descriptorType(cv::Feature2D *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->descriptorType();
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_Feature2D_defaultNorm(cv::Feature2D *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->defaultNorm();
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_Feature2D_empty(cv::Feature2D *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->empty() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Feature2D_write(cv::Feature2D *obj, const char *fileName)
{
    BEGIN_WRAP
    const cv::String fileNameString(fileName);
    obj->write(fileNameString);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Feature2D_read(cv::Feature2D *obj, const char *fileName)
{
    BEGIN_WRAP
    obj->read(fileName);
    END_WRAP 
}

CVAPI(ExceptionStatus) features2d_Feature2D_getDefaultName(cv::Feature2D *obj, std::string *returnValue)
{
    BEGIN_WRAP
    returnValue->assign(obj->getDefaultName());
    END_WRAP 
}

#pragma endregion

#pragma region BRISK

CVAPI(ExceptionStatus) features2d_BRISK_create1(
    int thresh, int octaves, float patternScale, cv::Ptr<cv::BRISK> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::BRISK::create(thresh, octaves, patternScale);
    *returnValue = clone(ptr);
    END_WRAP 
}
CVAPI(ExceptionStatus) features2d_BRISK_create2(
    float *radiusList, int radiusListLength, 
    int *numberList, int numberListLength,
    float dMax, float dMin,
    int *indexChange, int indexChangeLength, 
    cv::Ptr<cv::BRISK> **returnValue)
{
    BEGIN_WRAP
    const std::vector<float> radiusListVec(radiusList, radiusList + radiusListLength);
    const std::vector<int> numberListVec(numberList, numberList + numberListLength);
    std::vector<int> indexChangeVec;
    if (indexChange != nullptr)
        indexChangeVec = std::vector<int>(indexChange, indexChange + indexChangeLength);

    const auto ptr = cv::BRISK::create(radiusListVec, numberListVec, dMax, dMin, indexChangeVec);
    *returnValue = clone(ptr);
    END_WRAP 
}

CVAPI(ExceptionStatus) features2d_BRISK_create3(
    int thresh, int octaves, 
    float *radiusList, int radiusListLength,
    int *numberList, int numberListLength,
    float dMax, float dMin,
    int *indexChange, int indexChangeLength, 
    cv::Ptr<cv::BRISK> **returnValue)
{
    BEGIN_WRAP
    const std::vector<float> radiusListVec(radiusList, radiusList + radiusListLength);
    const std::vector<int> numberListVec(numberList, numberList + numberListLength);
    std::vector<int> indexChangeVec;
    if (indexChange != nullptr)
        indexChangeVec = std::vector<int>(indexChange, indexChange + indexChangeLength);

    const auto ptr = cv::BRISK::create(thresh, octaves, radiusListVec, numberListVec, dMax, dMin, indexChangeVec);
    *returnValue = clone(ptr);
    END_WRAP    
}

CVAPI(ExceptionStatus) features2d_Ptr_BRISK_delete(cv::Ptr<cv::BRISK> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP 
}

CVAPI(ExceptionStatus) features2d_Ptr_BRISK_get(cv::Ptr<cv::BRISK> *ptr, cv::BRISK **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP 
}

#pragma endregion

#pragma region ORB

#pragma endregion

#endif