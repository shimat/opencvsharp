#ifndef _CPP_PHOTO_HDR_H_
#define _CPP_PHOTO_HDR_H_

#include "include_opencv.h"

CVAPI(cv::Ptr<cv::CalibrateDebevec>*) photo_createCalibrateDebevec(
    int samples, float lambda, int random) 
{
    return clone(cv::createCalibrateDebevec(samples, lambda, random != 0));
}

CVAPI(cv::Ptr<cv::CalibrateRobertson>*) photo_createCalibrateRobertson(
    int max_iter, float threshold)
{
    return clone(cv::createCalibrateRobertson(max_iter, threshold));
}

CVAPI(void) photo_Ptr_CalibrateDebevec_delete(cv::Ptr<cv::CalibrateDebevec> *obj)
{
    delete obj;
}
CVAPI(void) photo_Ptr_CalibrateRobertson_delete(cv::Ptr<cv::CalibrateRobertson> *obj)
{
    delete obj;
}

CVAPI(cv::CalibrateDebevec*) photo_Ptr_CalibrateDebevec_get(cv::Ptr<cv::CalibrateDebevec> *obj)
{
    return obj->get();
}
CVAPI(cv::CalibrateRobertson*) photo_Ptr_CalibrateRobertson_get(cv::Ptr<cv::CalibrateRobertson> *obj)
{
    return obj->get();
}

CVAPI(void) photo_CalibrateCRF_process(
    cv::CalibrateCRF *obj, 
    cv::Mat ** srcImgs, int srcImgsLength, cv::_OutputArray *dst, float* times)
{
    // Build Mat Vector of images
    std::vector<cv::Mat> srcImgsVec(srcImgsLength);

    // Build float Vector of times
    std::vector<float> times_vec(srcImgsLength);
    
    for (int i = 0; i < srcImgsLength; i++) {
        srcImgsVec[i] = *srcImgs[i];
        times_vec[i] = times[i];
    }

    obj->process(srcImgsVec, *dst, times_vec);
}

#endif