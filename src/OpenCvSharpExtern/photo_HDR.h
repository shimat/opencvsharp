#pragma once

#include "include_opencv.h"

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

CVAPI(ExceptionStatus) photo_createCalibrateDebevec(
    int samples, float lambda, int random, cv::Ptr<cv::CalibrateDebevec> **returnValue) 
{
    BEGIN_WRAP
    *returnValue = clone(cv::createCalibrateDebevec(samples, lambda, random != 0));
    END_WRAP
}

CVAPI(ExceptionStatus) photo_Ptr_CalibrateDebevec_delete(cv::Ptr<cv::CalibrateDebevec> *obj)
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

CVAPI(ExceptionStatus) photo_CalibrateDebevec_getLambda(cv::CalibrateDebevec *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getLambda();
    END_WRAP
}
CVAPI(ExceptionStatus) photo_CalibrateDebevec_setLambda(cv::CalibrateDebevec *obj, float value)
{
    BEGIN_WRAP
    obj->setLambda(value);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_CalibrateDebevec_getSamples(cv::CalibrateDebevec *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getLambda();
    END_WRAP
}
CVAPI(ExceptionStatus) photo_CalibrateDebevec_setSamples(cv::CalibrateDebevec *obj, float value)
{
    BEGIN_WRAP
    obj->setLambda(value);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_CalibrateDebevec_getRandom(cv::CalibrateDebevec *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getRandom() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) photo_CalibrateDebevec_setRandom(cv::CalibrateDebevec *obj, int value)
{
    BEGIN_WRAP
    obj->setRandom(value != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_createCalibrateRobertson(
    int max_iter, float threshold, cv::Ptr<cv::CalibrateRobertson> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::createCalibrateRobertson(max_iter, threshold));
    END_WRAP
}

CVAPI(ExceptionStatus) photo_Ptr_CalibrateRobertson_delete(cv::Ptr<cv::CalibrateRobertson> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) photo_Ptr_CalibrateRobertson_get(cv::Ptr<cv::CalibrateRobertson> *obj, cv::CalibrateRobertson **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

CVAPI(ExceptionStatus) photo_CalibrateRobertson_getMaxIter(cv::CalibrateRobertson *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMaxIter();
    END_WRAP
}
CVAPI(ExceptionStatus) photo_CalibrateRobertson_setMaxIter(cv::CalibrateRobertson *obj, int value)
{
    BEGIN_WRAP
    obj->setMaxIter(value);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_CalibrateRobertson_getThreshold(cv::CalibrateRobertson *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) photo_CalibrateRobertson_setThreshold(cv::CalibrateRobertson *obj, float value)
{
    BEGIN_WRAP
    obj->setThreshold(value);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_CalibrateRobertson_getRadiance(cv::CalibrateRobertson *obj, cv::Mat *returnValue)
{
    BEGIN_WRAP
    obj->getRadiance().copyTo(*returnValue);
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

// TODO Exception Handling

CVAPI(cv::Ptr<cv::MergeDebevec>*) photo_createMergeDebevec()
{
    return clone(cv::createMergeDebevec());
}
CVAPI(void) photo_Ptr_MergeDebevec_delete(cv::Ptr<cv::MergeDebevec>* obj)
{
    delete obj;
}
CVAPI(cv::MergeDebevec*) photo_Ptr_MergeDebevec_get(cv::Ptr<cv::MergeDebevec>* obj)
{
    return obj->get();
}

CVAPI(cv::Ptr<cv::MergeMertens>*) photo_createMergeMertens()
{
    return clone(cv::createMergeMertens());
}
CVAPI(void) photo_Ptr_MergeMertens_delete(cv::Ptr<cv::MergeMertens>* obj)
{
    delete obj;
}
CVAPI(cv::MergeMertens*) photo_Ptr_MergeMertens_get(cv::Ptr<cv::MergeMertens>* obj)
{
    return obj->get();
}

CVAPI(void) photo_MergeExposures_process(
    cv::MergeExposures* obj,
    cv::Mat** srcImgs, int srcImgsLength, cv::_OutputArray* dst, float* times, cv::_InputArray* response)
{
    // Build Mat Vector of images
    std::vector<cv::Mat> srcImgsVec(srcImgsLength);

    // Build float Vector of times
    std::vector<float> times_vec(srcImgsLength);

    for (int i = 0; i < srcImgsLength; i++) {
        srcImgsVec[i] = *srcImgs[i];
        times_vec[i] = times[i];
    }

    obj->process(srcImgsVec, *dst, times_vec, *response);
}

CVAPI(void) photo_MergeMertens_process(
    cv::MergeMertens* obj,
    cv::Mat** srcImgs, int srcImgsLength, cv::_OutputArray* dst)
{
    // Build Mat Vector of images
    std::vector<cv::Mat> srcImgsVec(srcImgsLength);

    // Build float Vector of times
    std::vector<float> times_vec(srcImgsLength);

    for (int i = 0; i < srcImgsLength; i++) {
        srcImgsVec[i] = *srcImgs[i];
    }

    obj->process(srcImgsVec, *dst);
}
