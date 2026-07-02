#pragma once

#ifndef NO_CONTRIB
#ifndef _WINRT_DLL

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region FrameSource

CVAPI(ExceptionStatus) superres_FrameSource_nextFrame(cv::superres::FrameSource *obj, const interop::OutputArrayProxy* frame)
{
    return cvTry([&] {
    obj->nextFrame(OutProxy(*frame));
    });
}

CVAPI(ExceptionStatus) superres_FrameSource_reset(cv::superres::FrameSource *obj)
{
    return cvTry([&] {
    obj->reset();
    });
}

CVAPI(ExceptionStatus) superres_createFrameSource_Empty(cv::Ptr<cv::superres::FrameSource> **returnValue)
{
    return cvTry([&] {
    *returnValue = clone( cv::superres::createFrameSource_Empty() );
    });
}
CVAPI(ExceptionStatus) superres_createFrameSource_Video(const char *fileName, cv::Ptr<cv::superres::FrameSource> **returnValue)
{
    return cvTry([&] {
    *returnValue = clone( cv::superres::createFrameSource_Video(fileName) );
    });
}
CVAPI(ExceptionStatus) superres_createFrameSource_Video_CUDA(const char *fileName, cv::Ptr<cv::superres::FrameSource> **returnValue)
{
    return cvTry([&] {
    *returnValue = clone( cv::superres::createFrameSource_Video_CUDA(fileName) );
    });
}
CVAPI(ExceptionStatus) superres_createFrameSource_Camera(int deviceId, cv::Ptr<cv::superres::FrameSource> **returnValue)
{
    return cvTry([&] {
    *returnValue = clone( cv::superres::createFrameSource_Camera(deviceId) );
    });
}


CVAPI(ExceptionStatus) superres_Ptr_FrameSource_delete(cv::Ptr<cv::superres::FrameSource> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) superres_Ptr_FrameSource_get(cv::Ptr<cv::superres::FrameSource> *obj, cv::superres::FrameSource **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}

#pragma endregion

#pragma region SuperResolution

CVAPI(ExceptionStatus) superres_SuperResolution_setInput(cv::superres::SuperResolution *obj, cv::Ptr<cv::superres::FrameSource> *frameSource)
{
    return cvTry([&] {
    obj->setInput(*frameSource);
    });
}

CVAPI(ExceptionStatus) superres_SuperResolution_nextFrame(cv::superres::SuperResolution *obj, const interop::OutputArrayProxy* frame)
{
    return cvTry([&] {
    obj->nextFrame(OutProxy(*frame));
    });
}

CVAPI(ExceptionStatus) superres_SuperResolution_reset(cv::superres::SuperResolution *obj)
{
    return cvTry([&] {
    obj->reset();
    });
}

CVAPI(ExceptionStatus) superres_SuperResolution_collectGarbage(cv::superres::SuperResolution *obj)
{
    return cvTry([&] {
    obj->collectGarbage();
    });
}

CVAPI(ExceptionStatus) superres_createSuperResolution_BTVL1(cv::Ptr<cv::superres::SuperResolution> **returnValue)
{
    return cvTry([&] {
    *returnValue = clone( cv::superres::createSuperResolution_BTVL1() );
    });
}
CVAPI(ExceptionStatus) superres_createSuperResolution_BTVL1_CUDA(cv::Ptr<cv::superres::SuperResolution> **returnValue)
{
    return cvTry([&] {
    *returnValue = clone( cv::superres::createSuperResolution_BTVL1_CUDA() );
    });
}


CVAPI(ExceptionStatus) superres_Ptr_SuperResolution_get(cv::Ptr<cv::superres::SuperResolution> *obj, cv::superres::SuperResolution **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) superres_Ptr_SuperResolution_delete(cv::Ptr<cv::superres::SuperResolution> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) superres_SuperResolution_getScale(cv::superres::SuperResolution *obj, int *returnValue)              { return cvTry([&] { *returnValue = obj->getScale(); }); }
CVAPI(ExceptionStatus) superres_SuperResolution_setScale(cv::superres::SuperResolution *obj, int val)                       { return cvTry([&] { obj->setScale(val); }); }
CVAPI(ExceptionStatus) superres_SuperResolution_getIterations(cv::superres::SuperResolution *obj, int *returnValue)         { return cvTry([&] { *returnValue = obj->getIterations(); }); }
CVAPI(ExceptionStatus) superres_SuperResolution_setIterations(cv::superres::SuperResolution *obj, int val)                  { return cvTry([&] { obj->setIterations(val); }); }
CVAPI(ExceptionStatus) superres_SuperResolution_getTau(cv::superres::SuperResolution *obj, double *returnValue)             { return cvTry([&] { *returnValue = obj->getTau(); }); }
CVAPI(ExceptionStatus) superres_SuperResolution_setTau(cv::superres::SuperResolution *obj, double val)                      { return cvTry([&] { obj->setTau(val); }); }
CVAPI(ExceptionStatus) superres_SuperResolution_getLambda(cv::superres::SuperResolution *obj, double *returnValue)          { return cvTry([&] { *returnValue = obj->getLambda(); }); } 
CVAPI(ExceptionStatus) superres_SuperResolution_setLambda(cv::superres::SuperResolution *obj, double val)                   { return cvTry([&] { obj->setLambda(val); }); } 
CVAPI(ExceptionStatus) superres_SuperResolution_getAlpha(cv::superres::SuperResolution *obj, double *returnValue)           { return cvTry([&] { *returnValue = obj->getAlpha(); }); }
CVAPI(ExceptionStatus) superres_SuperResolution_setAlpha(cv::superres::SuperResolution *obj, double val)                    { return cvTry([&] { obj->setAlpha(val); }); }
CVAPI(ExceptionStatus) superres_SuperResolution_getKernelSize(cv::superres::SuperResolution *obj, int *returnValue)         { return cvTry([&] { *returnValue = obj->getKernelSize(); }); }
CVAPI(ExceptionStatus) superres_SuperResolution_setKernelSize(cv::superres::SuperResolution *obj, int val)                  { return cvTry([&] { obj->setKernelSize(val); }); }
CVAPI(ExceptionStatus) superres_SuperResolution_getBlurKernelSize(cv::superres::SuperResolution *obj, int *returnValue)     { return cvTry([&] { *returnValue = obj->getBlurKernelSize(); }); }
CVAPI(ExceptionStatus) superres_SuperResolution_setBlurKernelSize(cv::superres::SuperResolution *obj, int val)              { return cvTry([&] { obj->setBlurKernelSize(val); }); }
CVAPI(ExceptionStatus) superres_SuperResolution_getBlurSigma(cv::superres::SuperResolution *obj, double *returnValue)       { return cvTry([&] { *returnValue = obj->getBlurSigma(); }); }
CVAPI(ExceptionStatus) superres_SuperResolution_setBlurSigma(cv::superres::SuperResolution *obj, double val)                { return cvTry([&] { obj->setBlurSigma(val); }); }
CVAPI(ExceptionStatus) superres_SuperResolution_getTemporalAreaRadius(cv::superres::SuperResolution *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getTemporalAreaRadius(); }); }
CVAPI(ExceptionStatus) superres_SuperResolution_setTemporalAreaRadius(cv::superres::SuperResolution *obj, int val)          { return cvTry([&] { obj->setTemporalAreaRadius(val); }); }

CVAPI(ExceptionStatus) superres_SuperResolution_getOpticalFlow(cv::superres::SuperResolution *obj, cv::Ptr<cv::superres::DenseOpticalFlowExt> **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Ptr<cv::superres::DenseOpticalFlowExt>(obj->getOpticalFlow());
    });
}
CVAPI(ExceptionStatus) superres_SuperResolution_setOpticalFlow(cv::superres::SuperResolution *obj, cv::Ptr<cv::superres::DenseOpticalFlowExt> *val)
{
    return cvTry([&] {
    obj->setOpticalFlow(*val);
    });
}

#pragma endregion

CVAPI(ExceptionStatus) superres_DenseOpticalFlowExt_calc(
    cv::superres::DenseOpticalFlowExt* obj,
    const interop::InputArrayProxy* frame0,
    const interop::InputArrayProxy* frame1,
    const interop::OutputArrayProxy* flow1,
    const interop::OutputArrayProxy* flow2)
{
    return cvTry([&] {
    obj->calc(InProxy(*frame0), InProxy(*frame1), OutProxy(*flow1), OutProxy(*flow2));
    });
}

CVAPI(ExceptionStatus) superres_DenseOpticalFlowExt_collectGarbage(cv::superres::DenseOpticalFlowExt* obj)
{
    return cvTry([&] {
    obj->collectGarbage();
    });
}

#pragma region FarnebackOpticalFlow

CVAPI(ExceptionStatus) superres_createOptFlow_Farneback(cv::Ptr<cv::superres::FarnebackOpticalFlow> **returnValue)
{
    return cvTry([&] {
    *returnValue = clone(cv::superres::createOptFlow_Farneback());
    });
}
CVAPI(ExceptionStatus) superres_createOptFlow_Farneback_CUDA(cv::Ptr<cv::superres::FarnebackOpticalFlow> **returnValue)
{
    return cvTry([&] {
    *returnValue = clone(cv::superres::createOptFlow_Farneback_CUDA());
    });
}


CVAPI(ExceptionStatus) superres_Ptr_FarnebackOpticalFlow_get(cv::Ptr<cv::superres::FarnebackOpticalFlow> *obj, cv::superres::FarnebackOpticalFlow **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) superres_Ptr_FarnebackOpticalFlow_delete(cv::Ptr<cv::superres::FarnebackOpticalFlow> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getPyrScale(cv::superres::FarnebackOpticalFlow *obj, double *returnValue)  { return cvTry([&] { *returnValue = obj->getPyrScale(); }); }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setPyrScale(cv::superres::FarnebackOpticalFlow *obj, double val)           { return cvTry([&] { obj->setPyrScale(val); }); }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getLevelsNumber(cv::superres::FarnebackOpticalFlow *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getLevelsNumber(); }); }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setLevelsNumber(cv::superres::FarnebackOpticalFlow *obj, int val)          { return cvTry([&] { obj->setLevelsNumber(val); }); }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getWindowSize(cv::superres::FarnebackOpticalFlow *obj, int *returnValue)   { return cvTry([&] { *returnValue = obj->getWindowSize(); }); }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setWindowSize(cv::superres::FarnebackOpticalFlow *obj, int val)            { return cvTry([&] { obj->setWindowSize(val); }); }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getIterations(cv::superres::FarnebackOpticalFlow *obj, int *returnValue)   { return cvTry([&] { *returnValue = obj->getIterations(); }); }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setIterations(cv::superres::FarnebackOpticalFlow *obj, int val)            { return cvTry([&] { obj->setIterations(val); }); }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getPolyN(cv::superres::FarnebackOpticalFlow *obj, int *returnValue)        { return cvTry([&] { *returnValue = obj->getPolyN(); }); }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setPolyN(cv::superres::FarnebackOpticalFlow *obj, int val)                 { return cvTry([&] { obj->setPolyN(val); }); }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getPolySigma(cv::superres::FarnebackOpticalFlow *obj, double *returnValue) { return cvTry([&] { *returnValue = obj->getPolySigma(); }); }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setPolySigma(cv::superres::FarnebackOpticalFlow *obj, double val)          { return cvTry([&] { obj->setPolySigma(val); }); }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getFlags(cv::superres::FarnebackOpticalFlow *obj, int *returnValue)        { return cvTry([&] { *returnValue = obj->getFlags(); }); }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setFlags(cv::superres::FarnebackOpticalFlow *obj, int val)                 { return cvTry([&] { obj->setFlags(val); }); }

#pragma endregion

#pragma region DualTVL1OpticalFlow

CVAPI(ExceptionStatus) superres_createOptFlow_DualTVL1(cv::Ptr<cv::superres::DualTVL1OpticalFlow> **returnValue)
{
    return cvTry([&] {
    *returnValue = clone(cv::superres::createOptFlow_DualTVL1());
    });
}
CVAPI(ExceptionStatus) superres_createOptFlow_DualTVL1_CUDA(cv::Ptr<cv::superres::DualTVL1OpticalFlow> **returnValue)
{
    return cvTry([&] {
    *returnValue = clone(cv::superres::createOptFlow_DualTVL1_CUDA());
    });
}


CVAPI(ExceptionStatus) superres_Ptr_DualTVL1OpticalFlow_get(cv::Ptr<cv::superres::DualTVL1OpticalFlow> *obj, cv::superres::DualTVL1OpticalFlow **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) superres_Ptr_DualTVL1OpticalFlow_delete(cv::Ptr<cv::superres::DualTVL1OpticalFlow> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getTau(cv::superres::DualTVL1OpticalFlow *obj, double *returnValue)         { return cvTry([&] { *returnValue = obj->getTau(); }); }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setTau(cv::superres::DualTVL1OpticalFlow *obj, double val)                  { return cvTry([&] { obj->setTau(val); }); }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getLambda(cv::superres::DualTVL1OpticalFlow *obj, double *returnValue)      { return cvTry([&] { *returnValue = obj->getLambda(); }); }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setLambda(cv::superres::DualTVL1OpticalFlow *obj, double val)               { return cvTry([&] { obj->setLambda(val); }); }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getTheta(cv::superres::DualTVL1OpticalFlow *obj, double *returnValue)       { return cvTry([&] { *returnValue = obj->getTheta(); }); }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setTheta(cv::superres::DualTVL1OpticalFlow *obj, double val)                { return cvTry([&] { obj->setTheta(val); }); }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getScalesNumber(cv::superres::DualTVL1OpticalFlow *obj, int *returnValue)   { return cvTry([&] { *returnValue = obj->getScalesNumber(); }); }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setScalesNumber(cv::superres::DualTVL1OpticalFlow *obj, int val)            { return cvTry([&] { obj->setScalesNumber(val); }); }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getWarpingsNumber(cv::superres::DualTVL1OpticalFlow *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getWarpingsNumber(); }); }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setWarpingsNumber(cv::superres::DualTVL1OpticalFlow *obj, int val)          { return cvTry([&] { obj->setWarpingsNumber(val); }); }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getEpsilon(cv::superres::DualTVL1OpticalFlow *obj, double *returnValue)     { return cvTry([&] { *returnValue = obj->getEpsilon(); }); }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setEpsilon(cv::superres::DualTVL1OpticalFlow *obj, double val)              { return cvTry([&] { obj->setEpsilon(val); }); }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getIterations(cv::superres::DualTVL1OpticalFlow *obj, int *returnValue)     { return cvTry([&] { *returnValue = obj->getIterations(); }); }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setIterations(cv::superres::DualTVL1OpticalFlow *obj, int val)              { return cvTry([&] { obj->setIterations(val); }); }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getUseInitialFlow(cv::superres::DualTVL1OpticalFlow *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getUseInitialFlow() ? 1 : 0; }); }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setUseInitialFlow(cv::superres::DualTVL1OpticalFlow *obj, int val)          { return cvTry([&] { obj->setUseInitialFlow(val != 0); }); }

#pragma endregion

#pragma region BroxOpticalFlow

CVAPI(ExceptionStatus) superres_createOptFlow_Brox_CUDA(cv::Ptr<cv::superres::BroxOpticalFlow> **returnValue)
{
    return cvTry([&] {
    *returnValue = clone(cv::superres::createOptFlow_Brox_CUDA());
    });
}


CVAPI(ExceptionStatus) superres_Ptr_BroxOpticalFlow_get(cv::Ptr<cv::superres::BroxOpticalFlow> *obj, cv::superres::BroxOpticalFlow **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) superres_Ptr_BroxOpticalFlow_delete(cv::Ptr<cv::superres::BroxOpticalFlow> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) superres_BroxOpticalFlow_getAlpha(cv::superres::BroxOpticalFlow *obj, double *returnValue)         { return cvTry([&] { *returnValue = obj->getAlpha(); }); }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_setAlpha(cv::superres::BroxOpticalFlow *obj, double val)                  { return cvTry([&] { obj->setAlpha(val); }); }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_getGamma(cv::superres::BroxOpticalFlow *obj, double *returnValue)         { return cvTry([&] { *returnValue = obj->getGamma(); }); }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_setGamma(cv::superres::BroxOpticalFlow *obj, double val)                  { return cvTry([&] { obj->setGamma(val); }); }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_getScaleFactor(cv::superres::BroxOpticalFlow *obj, double *returnValue)   { return cvTry([&] { *returnValue = obj->getScaleFactor(); }); }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_setScaleFactor(cv::superres::BroxOpticalFlow *obj, double val)            { return cvTry([&] { obj->setScaleFactor(val); }); }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_getInnerIterations(cv::superres::BroxOpticalFlow *obj, int *returnValue)  { return cvTry([&] { *returnValue = obj->getInnerIterations(); }); }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_setInnerIterations(cv::superres::BroxOpticalFlow *obj, int val)           { return cvTry([&] { obj->setInnerIterations(val); }); }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_getOuterIterations(cv::superres::BroxOpticalFlow *obj, int *returnValue)  { return cvTry([&] { *returnValue = obj->getOuterIterations(); }); }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_setOuterIterations(cv::superres::BroxOpticalFlow *obj, int val)           { return cvTry([&] { obj->setOuterIterations(val); }); }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_getSolverIterations(cv::superres::BroxOpticalFlow *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getSolverIterations(); }); }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_setSolverIterations(cv::superres::BroxOpticalFlow *obj, int val)          { return cvTry([&] { obj->setSolverIterations(val); }); }

#pragma endregion

#pragma region PyrLKOpticalFlow

CVAPI(ExceptionStatus) superres_createOptFlow_PyrLK_CUDA(cv::Ptr<cv::superres::PyrLKOpticalFlow> **returnValue)
{
    return cvTry([&] {
    *returnValue = clone(cv::superres::createOptFlow_PyrLK_CUDA());
    });
}


CVAPI(ExceptionStatus) superres_Ptr_PyrLKOpticalFlow_get(cv::Ptr<cv::superres::PyrLKOpticalFlow> *obj, cv::superres::PyrLKOpticalFlow **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) superres_Ptr_PyrLKOpticalFlow_delete(cv::Ptr<cv::superres::PyrLKOpticalFlow> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) superres_PyrLKOpticalFlow_getWindowSize(cv::superres::PyrLKOpticalFlow *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getWindowSize(); }); }
CVAPI(ExceptionStatus) superres_PyrLKOpticalFlow_setWindowSize(cv::superres::PyrLKOpticalFlow *obj, int val)          { return cvTry([&] { obj->setWindowSize(val); }); }
CVAPI(ExceptionStatus) superres_PyrLKOpticalFlow_getMaxLevel(cv::superres::PyrLKOpticalFlow *obj, int *returnValue)   { return cvTry([&] { *returnValue = obj->getMaxLevel(); }); }
CVAPI(ExceptionStatus) superres_PyrLKOpticalFlow_setMaxLevel(cv::superres::PyrLKOpticalFlow *obj, int val)            { return cvTry([&] { obj->setMaxLevel(val); }); }
CVAPI(ExceptionStatus) superres_PyrLKOpticalFlow_getIterations(cv::superres::PyrLKOpticalFlow *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getIterations(); }); }
CVAPI(ExceptionStatus) superres_PyrLKOpticalFlow_setIterations(cv::superres::PyrLKOpticalFlow *obj, int val)          { return cvTry([&] { obj->setIterations(val); }); }

#pragma endregion

#endif // _WINRT_DLL

#endif // NO_CONTRIB
