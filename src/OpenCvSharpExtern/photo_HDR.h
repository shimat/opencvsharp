#pragma once

#ifndef NO_PHOTO

#include "include_opencv.h"

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

CVAPI(ExceptionStatus) photo_createCalibrateDebevec(
    int samples,
    float lambda,
    int random,
    cv::Ptr<cv::CalibrateDebevec> **returnValue) 
{
    return cvTry([&] {
        *returnValue = clone(cv::createCalibrateDebevec(samples, lambda, random != 0));
    });
}

CVAPI(ExceptionStatus) photo_Ptr_CalibrateDebevec_delete(cv::Ptr<cv::CalibrateDebevec> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) photo_Ptr_CalibrateDebevec_get(cv::Ptr<cv::CalibrateDebevec> *obj, cv::CalibrateDebevec **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) photo_CalibrateDebevec_getLambda(cv::CalibrateDebevec *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getLambda();
    });
}
CVAPI(ExceptionStatus) photo_CalibrateDebevec_setLambda(cv::CalibrateDebevec *obj, float value)
{
    return cvTry([&] {
        obj->setLambda(value);
    });
}

CVAPI(ExceptionStatus) photo_CalibrateDebevec_getSamples(cv::CalibrateDebevec *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getSamples();
    });
}
CVAPI(ExceptionStatus) photo_CalibrateDebevec_setSamples(cv::CalibrateDebevec *obj, int value)
{
    return cvTry([&] {
        obj->setSamples(value);
    });
}

CVAPI(ExceptionStatus) photo_CalibrateDebevec_getRandom(cv::CalibrateDebevec *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getRandom() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) photo_CalibrateDebevec_setRandom(cv::CalibrateDebevec *obj, int value)
{
    return cvTry([&] {
        obj->setRandom(value != 0);
    });
}

CVAPI(ExceptionStatus) photo_createCalibrateRobertson(
    int max_iter,
    float threshold,
    cv::Ptr<cv::CalibrateRobertson> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::createCalibrateRobertson(max_iter, threshold));
    });
}

CVAPI(ExceptionStatus) photo_Ptr_CalibrateRobertson_delete(cv::Ptr<cv::CalibrateRobertson> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) photo_Ptr_CalibrateRobertson_get(cv::Ptr<cv::CalibrateRobertson> *obj, cv::CalibrateRobertson **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) photo_CalibrateRobertson_getMaxIter(cv::CalibrateRobertson *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getMaxIter();
    });
}
CVAPI(ExceptionStatus) photo_CalibrateRobertson_setMaxIter(cv::CalibrateRobertson *obj, int value)
{
    return cvTry([&] {
        obj->setMaxIter(value);
    });
}

CVAPI(ExceptionStatus) photo_CalibrateRobertson_getThreshold(cv::CalibrateRobertson *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getThreshold();
    });
}
CVAPI(ExceptionStatus) photo_CalibrateRobertson_setThreshold(cv::CalibrateRobertson *obj, float value)
{
    return cvTry([&] {
        obj->setThreshold(value);
    });
}

CVAPI(ExceptionStatus) photo_CalibrateRobertson_getRadiance(cv::CalibrateRobertson *obj, cv::Mat *returnValue)
{
    return cvTry([&] {
        obj->getRadiance().copyTo(*returnValue);
    });
}


CVAPI(ExceptionStatus) photo_CalibrateCRF_process(
    cv::CalibrateCRF *obj,
    cv::Mat ** srcImgs,
    int srcImgsLength,
    const interop::OutputArrayProxy* dst,
    float* times)
{
    return cvTry([&] {

        // Build Mat Vector of images
        std::vector<cv::Mat> srcImgsVec(srcImgsLength);

        // Build float Vector of times
        std::vector<float> times_vec(srcImgsLength);
    
        for (int i = 0; i < srcImgsLength; i++) {
            srcImgsVec[i] = *srcImgs[i];
            times_vec[i] = times[i];
        }

        obj->process(srcImgsVec, OutProxy(*dst), times_vec);
    });
}

CVAPI(ExceptionStatus) photo_createMergeDebevec(cv::Ptr<cv::MergeDebevec>** returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::createMergeDebevec());
    });
}
CVAPI(ExceptionStatus) photo_Ptr_MergeDebevec_delete(cv::Ptr<cv::MergeDebevec>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}
CVAPI(ExceptionStatus) photo_Ptr_MergeDebevec_get(cv::Ptr<cv::MergeDebevec>* obj, cv::MergeDebevec **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) photo_createMergeMertens(cv::Ptr<cv::MergeMertens>** returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::createMergeMertens());
    });
}
CVAPI(ExceptionStatus) photo_Ptr_MergeMertens_delete(cv::Ptr<cv::MergeMertens>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}
CVAPI(ExceptionStatus) photo_Ptr_MergeMertens_get(cv::Ptr<cv::MergeMertens>* obj, cv::MergeMertens **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) photo_MergeExposures_process(
    cv::MergeExposures* obj,
    cv::Mat** srcImgs,
    int srcImgsLength,
    const interop::OutputArrayProxy* dst,
    float* times,
    const interop::InputArrayProxy* response)
{
    return cvTry([&] {
        std::vector<cv::Mat> srcImgsVec(srcImgsLength);
        std::vector<float> times_vec(srcImgsLength);
        for (int i = 0; i < srcImgsLength; i++) {
            srcImgsVec[i] = *srcImgs[i];
            times_vec[i] = times[i];
        }
        obj->process(srcImgsVec, OutProxy(*dst), times_vec, InProxy(*response));
    });
}

CVAPI(ExceptionStatus) photo_MergeMertens_process(
    cv::MergeMertens* obj,
    cv::Mat** srcImgs,
    int srcImgsLength,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        std::vector<cv::Mat> srcImgsVec(srcImgsLength);
        for (int i = 0; i < srcImgsLength; i++) {
            srcImgsVec[i] = *srcImgs[i];
        }
        obj->process(srcImgsVec, OutProxy(*dst));
    });
}

#endif // NO_PHOTO
