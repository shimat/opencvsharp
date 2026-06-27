#pragma once

#ifndef NO_DNN

#ifndef _WINRT_DLL

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) dnn_Net_new(cv::dnn::Net **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::dnn::Net;
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_delete(cv::dnn::Net* net)
{
    BEGIN_WRAP
    delete net;
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_readFromModelOptimizer(const char *xml, const char *bin, cv::dnn::Net **returnValue)
{
    BEGIN_WRAP
    const auto net = cv::dnn::Net::readFromModelOptimizer(xml, bin);
    *returnValue = new cv::dnn::Net(net);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_empty(cv::dnn::Net* net, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = net->empty() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_dump(cv::dnn::Net* net, std::string *outString)
{
    BEGIN_WRAP
    outString->assign(net->dump());
    END_WRAP    
}

CVAPI(ExceptionStatus) dnn_Net_dumpToFile(cv::dnn::Net* net, const char *path)
{
    BEGIN_WRAP
    net->dumpToFile(path);
    END_WRAP    
}

CVAPI(ExceptionStatus) dnn_Net_getLayerId(cv::dnn::Net* net, const char *layer, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = net->getLayerId(layer);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_getLayerNames(cv::dnn::Net* net, std::vector<cv::String> *outVec)
{
    BEGIN_WRAP
    const auto result = net->getLayerNames();
    outVec->assign(result.begin(), result.end());
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_connect1(cv::dnn::Net* net, const char *outPin, const char *inpPin)
{
    BEGIN_WRAP
    net->connect(outPin, inpPin);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_connect2(cv::dnn::Net* net, int outLayerId, int outNum, int inpLayerId, int inpNum)
{
    BEGIN_WRAP
    net->connect(outLayerId, outNum, inpLayerId, inpNum);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_setInputsNames(cv::dnn::Net* net, const char **inputBlobNames, int inputBlobNamesLength)
{
    BEGIN_WRAP
    std::vector<cv::String> inputBlobNamesVec(inputBlobNamesLength);
    for (auto i = 0; i < inputBlobNamesLength; i++)
    {
        inputBlobNamesVec[i] = inputBlobNames[i];
    }
    net->setInputsNames(inputBlobNamesVec);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_forward1(cv::dnn::Net* net, const char *outputName, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto outputNameStr = (outputName == nullptr) ? cv::String() : cv::String(outputName);
    const auto ret = net->forward(outputNameStr);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_forward2(
    cv::dnn::Net* net, cv::Mat **outputBlobs, int outputBlobsLength, const char *outputName)
{
    BEGIN_WRAP
    const auto outputNameStr = (outputName == nullptr) ? cv::String() : cv::String(outputName);
    std::vector<cv::Mat> outputBlobsVec;
    toVec(outputBlobs, outputBlobsLength, outputBlobsVec);

    net->forward(outputBlobsVec, outputNameStr);

    for (auto i = 0; i < outputBlobsLength; i++)
    {
        *outputBlobs[i] = outputBlobsVec[i];
    }
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_forward3(
    cv::dnn::Net* net, cv::Mat **outputBlobs, int outputBlobsLength, const char **outBlobNames, int outBlobNamesLength)
{
    BEGIN_WRAP
    std::vector<cv::Mat> outputBlobsVec;
    toVec(outputBlobs, outputBlobsLength, outputBlobsVec);

    std::vector<cv::String> outBlobNamesVec(outBlobNamesLength);
    for (auto i = 0; i < outBlobNamesLength; i++)
    {
        outBlobNamesVec[i] = outBlobNames[i];
    }

    net->forward(outputBlobsVec, outBlobNamesVec);

    for (auto i = 0; i < outputBlobsLength; i++)
    {
        *outputBlobs[i] = outputBlobsVec[i];
    }
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_setPreferableBackend(cv::dnn::Net* net, int backendId)
{
    BEGIN_WRAP
    net->setPreferableBackend(backendId);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_setPreferableTarget(cv::dnn::Net* net, int targetId)
{
    BEGIN_WRAP
    net->setPreferableTarget(targetId);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_setInput(cv::dnn::Net* net, const cv::Mat *blob, const char *name)
{
    BEGIN_WRAP
    const auto nameStr = (name == nullptr) ? "" : cv::String(name);
    net->setInput(*blob, nameStr);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_getUnconnectedOutLayers(cv::dnn::Net* net, std::vector<int> *result)
{
    BEGIN_WRAP
    const auto v = net->getUnconnectedOutLayers();
    result->clear();
    result->resize(v.size());
    for (size_t i = 0; i < v.size(); i++)
    {
        result->at(i) = v[i];
    }
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_getUnconnectedOutLayersNames(cv::dnn::Net* net, std::vector<std::string> *result)
{
    BEGIN_WRAP
    const auto v = net->getUnconnectedOutLayersNames();
    result->clear();
    result->resize(v.size());
    for (size_t i = 0; i < v.size(); i++)
    {
        result->at(i) = v[i];
    }
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_enableFusion(cv::dnn::Net* net, int fusion)
{
    BEGIN_WRAP
    net->enableFusion(fusion != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_getPerfProfile(cv::dnn::Net* net, std::vector<double> *timings, int64 *returnValue)
{
    BEGIN_WRAP
    *returnValue = net->getPerfProfile(*timings);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_setInputShape(cv::dnn::Net* net, const char *inputName, const int *shape, const int shapeLength)
{
    BEGIN_WRAP
    const cv::MatShape shapeObj(shape, shape + shapeLength);
    net->setInputShape(inputName, shapeObj);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_getParam(cv::dnn::Net* net, const int layer, const int numParam, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto m = net->getParam(layer, numParam);
    *returnValue = new cv::Mat(m);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_setParam(cv::dnn::Net* net, const int layer, const int numParam, cv::Mat *blob)
{
    BEGIN_WRAP
    net->setParam(layer, numParam, *blob);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_getLayerTypes(cv::dnn::Net* net, std::vector<cv::String> *outVec)
{
    BEGIN_WRAP
    std::vector<cv::String> result;
    net->getLayerTypes(result);
    outVec->assign(result.begin(), result.end());
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_getLayersCount(cv::dnn::Net* net, const char *layerType, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = net->getLayersCount(layerType);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_enableWinograd(cv::dnn::Net* net, const int useWinograd)
{
    BEGIN_WRAP
    net->enableWinograd(useWinograd != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_dumpToPbtxt(cv::dnn::Net* net, const char *path)
{
    BEGIN_WRAP
    net->dumpToPbtxt(path);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_getModelFormat(cv::dnn::Net* net, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<int>(net->getModelFormat());
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_enableKVCache(cv::dnn::Net* net)
{
    BEGIN_WRAP
    net->enableKVCache();
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_disableKVCache(cv::dnn::Net* net)
{
    BEGIN_WRAP
    net->disableKVCache();
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_resetKVCache(cv::dnn::Net* net)
{
    BEGIN_WRAP
    net->resetKVCache();
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_printPerfProfile(cv::dnn::Net* net)
{
    BEGIN_WRAP
    net->printPerfProfile();
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_finalizeNet(cv::dnn::Net* net)
{
    BEGIN_WRAP
    net->finalizeNet();
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_setTracingMode(cv::dnn::Net* net, int tracingMode)
{
    BEGIN_WRAP
    net->setTracingMode(static_cast<cv::dnn::TracingMode>(tracingMode));
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_getTracingMode(cv::dnn::Net* net, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<int>(net->getTracingMode());
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_setProfilingMode(cv::dnn::Net* net, int profilingMode)
{
    BEGIN_WRAP
    net->setProfilingMode(static_cast<cv::dnn::ProfilingMode>(profilingMode));
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_getProfilingMode(cv::dnn::Net* net, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<int>(net->getProfilingMode());
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_registerOutput(cv::dnn::Net* net, const char *outputName, int layerId, int outputPort, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = net->registerOutput(cv::String(outputName), layerId, outputPort);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Net_getPerfProfileDetailed(
    cv::dnn::Net* net, std::vector<std::string> *names, std::vector<std::string> *timems, std::vector<std::string> *counts)
{
    BEGIN_WRAP
    net->getPerfProfile(*names, *timems, *counts);
    END_WRAP
}

#endif // !#ifndef _WINRT_DLL

#endif // NO_DNN
