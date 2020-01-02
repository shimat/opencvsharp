#ifndef _CPP_PHOTO_HDR_H_
#define _CPP_PHOTO_HDR_H_

#include "include_opencv.h"

CVAPI(ExceptionStatus) photo_createCalibrateDebevec(
    int samples, float lambda, int random, cv::Ptr<cv::CalibrateDebevec> **returnValue) 
{
    BEGIN_WRAP
    *returnValue = clone(cv::createCalibrateDebevec(samples, lambda, random != 0));
    END_WRAP
}

CVAPI(ExceptionStatus) photo_createCalibrateRobertson(
    int max_iter, float threshold, cv::Ptr<cv::CalibrateRobertson> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::createCalibrateRobertson(max_iter, threshold));
    END_WRAP
}

CVAPI(ExceptionStatus) photo_Ptr_CalibrateDebevec_delete(cv::Ptr<cv::CalibrateDebevec> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}
CVAPI(ExceptionStatus) photo_Ptr_CalibrateRobertson_delete(cv::Ptr<cv::CalibrateRobertson> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) photo_Ptr_CalibrateDebevec_get(cv::Ptr<cv::CalibrateDebevec> *obj, cv::CalibrateDebevec **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}
CVAPI(ExceptionStatus) photo_Ptr_CalibrateRobertson_get(cv::Ptr<cv::CalibrateRobertson> *obj, cv::CalibrateRobertson **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

CVAPI(ExceptionStatus) photo_CalibrateCRF_process(
    cv::CalibrateCRF *obj, 
    cv::Mat ** srcImgs, int srcImgsLength, cv::_OutputArray *dst, float* times)
{
    BEGIN_WRAP

    // Build Mat Vector of images
    std::vector<cv::Mat> srcImgsVec(srcImgsLength);

    // Build float Vector of times
    std::vector<float> times_vec(srcImgsLength);
    
    for (int i = 0; i < srcImgsLength; i++) {
        srcImgsVec[i] = *srcImgs[i];
        times_vec[i] = times[i];
    }

    obj->process(srcImgsVec, *dst, times_vec);
    END_WRAP
}

#endif