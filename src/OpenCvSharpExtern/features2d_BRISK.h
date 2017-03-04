#ifndef _CPP_FEATURES2D_BRISK_H_
#define _CPP_FEATURES2D_BRISK_H_

#include "include_opencv.h"


CVAPI(cv::Ptr<cv::BRISK>*) features2d_BRISK_create1(int thresh, int octaves, float patternScale)
{
    cv::Ptr<cv::BRISK> ptr = cv::BRISK::create(thresh, octaves, patternScale);
    return new cv::Ptr<cv::BRISK>(ptr);
}
CVAPI(cv::Ptr<cv::BRISK>*) features2d_BRISK_create2(
    float *radiusList, int radiusListLength, int *numberList, int numberListLength,
    float dMax, float dMin,
    int *indexChange, int indexChangeLength)
{
    std::vector<float> radiusListVec(radiusList, radiusList + radiusListLength);
    std::vector<int> numberListVec(numberList, numberList + numberListLength);
    std::vector<int> indexChangeVec;
    if (indexChange == NULL)
        indexChangeVec = std::vector<int>(indexChange, indexChange + indexChangeLength);
    else
        indexChangeVec = std::vector<int>();

    cv::Ptr<cv::BRISK> ptr = cv::BRISK::create(radiusListVec, numberListVec, dMax, dMin, indexChangeVec);
    return new cv::Ptr<cv::BRISK>(ptr);
}

CVAPI(void) features2d_Ptr_BRISK_delete(cv::Ptr<cv::BRISK> *ptr)
{
    delete ptr;
}

CVAPI(cv::BRISK*) features2d_Ptr_BRISK_get(cv::Ptr<cv::BRISK> *ptr)
{
    return ptr->get();
}

#endif
