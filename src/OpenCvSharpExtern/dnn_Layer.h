#pragma once

#ifndef NO_DNN

#ifndef _WINRT_DLL

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) dnn_Layer_getBlobs(cv::dnn::Layer *obj, std::vector<cv::Mat> *outVec)
{
    return cvTry([&] {
        outVec->assign(obj->blobs.begin(), obj->blobs.end());
    });
}

CVAPI(ExceptionStatus) dnn_Layer_setBlobs(cv::dnn::Layer *obj, std::vector<cv::Mat> *blobs)
{
    return cvTry([&] {
        obj->blobs.assign(blobs->begin(), blobs->end());
    });
}

CVAPI(ExceptionStatus) dnn_Layer_getName(cv::dnn::Layer *obj, std::string *outString)
{
    return cvTry([&] {
        outString->assign(obj->name);
    });
}

CVAPI(ExceptionStatus) dnn_Layer_getType(cv::dnn::Layer *obj, std::string *outString)
{
    return cvTry([&] {
        outString->assign(obj->type);
    });
}

CVAPI(ExceptionStatus) dnn_Layer_getPreferableTarget(cv::dnn::Layer *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->preferableTarget;
    });
}

CVAPI(ExceptionStatus) dnn_Layer_outputNameToIndex(cv::dnn::Layer *obj, const char *outputName, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->outputNameToIndex(outputName);
    });
}

CVAPI(ExceptionStatus) dnn_Ptr_Layer_delete(cv::Ptr<cv::dnn::Layer> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) dnn_Ptr_Layer_get(cv::Ptr<cv::dnn::Layer>* obj, cv::dnn::Layer **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

#endif // _WINRT_DLL

#endif // NO_DNN
