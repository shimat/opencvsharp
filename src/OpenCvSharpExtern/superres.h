#ifndef _CPP_SUPERRES_H_
#define _CPP_SUPERRES_H_

#ifndef _WINRT_DLL

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region FrameSource

CVAPI(ExceptionStatus) superres_FrameSource_nextFrame(
    cv::Ptr<cv::superres::FrameSource> *obj, cv::_OutputArray *frame)
{
    BEGIN_WRAP
    (*obj)->nextFrame(*frame);
    END_WRAP
}

CVAPI(ExceptionStatus) superres_FrameSource_reset(
    cv::Ptr<cv::superres::FrameSource> *obj)
{
    BEGIN_WRAP
    (*obj)->reset();
    END_WRAP
}

CVAPI(ExceptionStatus) superres_createFrameSource_Empty(cv::Ptr<cv::superres::FrameSource> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone( cv::superres::createFrameSource_Empty() );
    END_WRAP
}
CVAPI(ExceptionStatus) superres_createFrameSource_Video(const char *fileName, cv::Ptr<cv::superres::FrameSource> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone( cv::superres::createFrameSource_Video(fileName) );
    END_WRAP
}
CVAPI(ExceptionStatus) superres_createFrameSource_Video_CUDA(const char *fileName, cv::Ptr<cv::superres::FrameSource> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone( cv::superres::createFrameSource_Video_CUDA(fileName) );
    END_WRAP
}
CVAPI(ExceptionStatus) superres_createFrameSource_Camera(int deviceId, cv::Ptr<cv::superres::FrameSource> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone( cv::superres::createFrameSource_Camera(deviceId) );
    END_WRAP
}

CVAPI(ExceptionStatus) superres_Ptr_FrameSource_get(cv::Ptr<cv::superres::FrameSource> *ptr, cv::superres::FrameSource **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) superres_Ptr_FrameSource_delete(cv::Ptr<cv::superres::FrameSource> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

#pragma endregion

#pragma region SuperResolution

CVAPI(ExceptionStatus) superres_SuperResolution_setInput(
    cv::superres::SuperResolution *obj, cv::Ptr<cv::superres::FrameSource> *frameSource)
{
    BEGIN_WRAP
    obj->setInput(*frameSource);
    END_WRAP
}

CVAPI(ExceptionStatus) superres_SuperResolution_nextFrame(
    cv::superres::SuperResolution *obj, cv::_OutputArray *frame)
{
    BEGIN_WRAP
    obj->nextFrame(*frame);
    END_WRAP
}

CVAPI(ExceptionStatus) superres_SuperResolution_reset(cv::superres::SuperResolution *obj)
{
    BEGIN_WRAP
    obj->reset();
    END_WRAP
}

CVAPI(ExceptionStatus) superres_SuperResolution_collectGarbage(cv::superres::SuperResolution *obj)
{
    BEGIN_WRAP
    obj->collectGarbage();
    END_WRAP
}

CVAPI(ExceptionStatus) superres_createSuperResolution_BTVL1(cv::Ptr<cv::superres::SuperResolution> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone( cv::superres::createSuperResolution_BTVL1() );
    END_WRAP
}
CVAPI(ExceptionStatus) superres_createSuperResolution_BTVL1_CUDA(cv::Ptr<cv::superres::SuperResolution> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone( cv::superres::createSuperResolution_BTVL1_CUDA() );
    END_WRAP
}

CVAPI(ExceptionStatus) superres_Ptr_SuperResolution_get(
    cv::Ptr<cv::superres::SuperResolution> *ptr, cv::superres::SuperResolution **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) superres_Ptr_SuperResolution_delete(cv::Ptr<cv::superres::SuperResolution> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) superres_SuperResolution_getScale(cv::superres::SuperResolution *obj, int *returnValue)              { BEGIN_WRAP *returnValue = obj->getScale(); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_setScale(cv::superres::SuperResolution *obj, int val)                       { BEGIN_WRAP obj->setScale(val); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_getIterations(cv::superres::SuperResolution *obj, int *returnValue)         { BEGIN_WRAP *returnValue = obj->getIterations(); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_setIterations(cv::superres::SuperResolution *obj, int val)                  { BEGIN_WRAP obj->setIterations(val); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_getTau(cv::superres::SuperResolution *obj, double *returnValue)             { BEGIN_WRAP *returnValue = obj->getTau(); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_setTau(cv::superres::SuperResolution *obj, double val)                      { BEGIN_WRAP obj->setTau(val); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_getLambda(cv::superres::SuperResolution *obj, double *returnValue)          { BEGIN_WRAP *returnValue = obj->getLambda(); END_WRAP } 
CVAPI(ExceptionStatus) superres_SuperResolution_setLambda(cv::superres::SuperResolution *obj, double val)                   { BEGIN_WRAP obj->setLambda(val); END_WRAP } 
CVAPI(ExceptionStatus) superres_SuperResolution_getAlpha(cv::superres::SuperResolution *obj, double *returnValue)           { BEGIN_WRAP *returnValue = obj->getAlpha(); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_setAlpha(cv::superres::SuperResolution *obj, double val)                    { BEGIN_WRAP obj->setAlpha(val); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_getKernelSize(cv::superres::SuperResolution *obj, int *returnValue)         { BEGIN_WRAP *returnValue = obj->getKernelSize(); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_setKernelSize(cv::superres::SuperResolution *obj, int val)                  { BEGIN_WRAP obj->setKernelSize(val); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_getBlurKernelSize(cv::superres::SuperResolution *obj, int *returnValue)     { BEGIN_WRAP *returnValue = obj->getBlurKernelSize(); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_setBlurKernelSize(cv::superres::SuperResolution *obj, int val)              { BEGIN_WRAP obj->setBlurKernelSize(val); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_getBlurSigma(cv::superres::SuperResolution *obj, double *returnValue)       { BEGIN_WRAP *returnValue = obj->getBlurSigma(); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_setBlurSigma(cv::superres::SuperResolution *obj, double val)                { BEGIN_WRAP obj->setBlurSigma(val); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_getTemporalAreaRadius(cv::superres::SuperResolution *obj, int *returnValue) { BEGIN_WRAP *returnValue = obj->getTemporalAreaRadius(); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_setTemporalAreaRadius(cv::superres::SuperResolution *obj, int val)          { BEGIN_WRAP obj->setTemporalAreaRadius(val); END_WRAP }

CVAPI(ExceptionStatus) superres_SuperResolution_getOpticalFlow(cv::superres::SuperResolution *obj, cv::Ptr<cv::superres::DenseOpticalFlowExt> **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Ptr<cv::superres::DenseOpticalFlowExt>(obj->getOpticalFlow());
    END_WRAP
}
CVAPI(ExceptionStatus) superres_SuperResolution_setOpticalFlow(cv::superres::SuperResolution *obj, cv::Ptr<cv::superres::DenseOpticalFlowExt> *val)
{
    BEGIN_WRAP
    obj->setOpticalFlow(*val);
    END_WRAP
}

#pragma endregion

CVAPI(ExceptionStatus) superres_DenseOpticalFlowExt_calc(cv::superres::DenseOpticalFlowExt *obj,
    cv::_InputArray *frame0, cv::_InputArray *frame1, cv::_OutputArray *flow1, cv::_OutputArray *flow2)
{
    BEGIN_WRAP
    obj->calc(*frame0, *frame1, *flow1, entity(flow2));
    END_WRAP
}

CVAPI(ExceptionStatus) superres_DenseOpticalFlowExt_collectGarbage(cv::superres::DenseOpticalFlowExt *obj)
{
    BEGIN_WRAP
    obj->collectGarbage();
    END_WRAP
}

#pragma region FarnebackOpticalFlow

CVAPI(ExceptionStatus) superres_createOptFlow_Farneback(cv::Ptr<cv::superres::FarnebackOpticalFlow> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::superres::createOptFlow_Farneback());
    END_WRAP
}
CVAPI(ExceptionStatus) superres_createOptFlow_Farneback_CUDA(cv::Ptr<cv::superres::FarnebackOpticalFlow> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::superres::createOptFlow_Farneback_CUDA());
    END_WRAP
}

CVAPI(ExceptionStatus) superres_Ptr_FarnebackOpticalFlow_get(
    cv::Ptr<cv::superres::FarnebackOpticalFlow> *ptr, cv::superres::FarnebackOpticalFlow **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) superres_Ptr_FarnebackOpticalFlow_delete(
    cv::Ptr<cv::superres::FarnebackOpticalFlow> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getPyrScale(cv::superres::FarnebackOpticalFlow *obj, double *returnValue)  { BEGIN_WRAP *returnValue = obj->getPyrScale(); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setPyrScale(cv::superres::FarnebackOpticalFlow *obj, double val)           { BEGIN_WRAP obj->setPyrScale(val); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getLevelsNumber(cv::superres::FarnebackOpticalFlow *obj, int *returnValue) { BEGIN_WRAP *returnValue = obj->getLevelsNumber(); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setLevelsNumber(cv::superres::FarnebackOpticalFlow *obj, int val)          { BEGIN_WRAP obj->setLevelsNumber(val); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getWindowSize(cv::superres::FarnebackOpticalFlow *obj, int *returnValue)   { BEGIN_WRAP *returnValue = obj->getWindowSize(); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setWindowSize(cv::superres::FarnebackOpticalFlow *obj, int val)            { BEGIN_WRAP obj->setWindowSize(val); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getIterations(cv::superres::FarnebackOpticalFlow *obj, int *returnValue)   { BEGIN_WRAP *returnValue = obj->getIterations(); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setIterations(cv::superres::FarnebackOpticalFlow *obj, int val)            { BEGIN_WRAP obj->setIterations(val); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getPolyN(cv::superres::FarnebackOpticalFlow *obj, int *returnValue)        { BEGIN_WRAP *returnValue = obj->getPolyN(); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setPolyN(cv::superres::FarnebackOpticalFlow *obj, int val)                 { BEGIN_WRAP obj->setPolyN(val); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getPolySigma(cv::superres::FarnebackOpticalFlow *obj, double *returnValue) { BEGIN_WRAP *returnValue = obj->getPolySigma(); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setPolySigma(cv::superres::FarnebackOpticalFlow *obj, double val)          { BEGIN_WRAP obj->setPolySigma(val); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getFlags(cv::superres::FarnebackOpticalFlow *obj, int *returnValue)        { BEGIN_WRAP *returnValue = obj->getFlags(); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setFlags(cv::superres::FarnebackOpticalFlow *obj, int val)                 { BEGIN_WRAP obj->setFlags(val); END_WRAP }

#pragma endregion

#pragma region DualTVL1OpticalFlow

CVAPI(ExceptionStatus) superres_createOptFlow_DualTVL1(cv::Ptr<cv::superres::DualTVL1OpticalFlow> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::superres::createOptFlow_DualTVL1());
    END_WRAP
}
CVAPI(ExceptionStatus) superres_createOptFlow_DualTVL1_CUDA(cv::Ptr<cv::superres::DualTVL1OpticalFlow> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::superres::createOptFlow_DualTVL1_CUDA());
    END_WRAP
}

CVAPI(ExceptionStatus) superres_Ptr_DualTVL1OpticalFlow_get(
    cv::Ptr<cv::superres::DualTVL1OpticalFlow> *ptr, cv::superres::DualTVL1OpticalFlow **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) superres_Ptr_DualTVL1OpticalFlow_delete(
    cv::Ptr<cv::superres::DualTVL1OpticalFlow> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getTau(cv::superres::DualTVL1OpticalFlow *obj, double *returnValue)         { BEGIN_WRAP *returnValue = obj->getTau(); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setTau(cv::superres::DualTVL1OpticalFlow *obj, double val)                  { BEGIN_WRAP obj->setTau(val); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getLambda(cv::superres::DualTVL1OpticalFlow *obj, double *returnValue)      { BEGIN_WRAP *returnValue = obj->getLambda(); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setLambda(cv::superres::DualTVL1OpticalFlow *obj, double val)               { BEGIN_WRAP obj->setLambda(val); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getTheta(cv::superres::DualTVL1OpticalFlow *obj, double *returnValue)       { BEGIN_WRAP *returnValue = obj->getTheta(); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setTheta(cv::superres::DualTVL1OpticalFlow *obj, double val)                { BEGIN_WRAP obj->setTheta(val); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getScalesNumber(cv::superres::DualTVL1OpticalFlow *obj, int *returnValue)   { BEGIN_WRAP *returnValue = obj->getScalesNumber(); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setScalesNumber(cv::superres::DualTVL1OpticalFlow *obj, int val)            { BEGIN_WRAP obj->setScalesNumber(val); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getWarpingsNumber(cv::superres::DualTVL1OpticalFlow *obj, int *returnValue) { BEGIN_WRAP *returnValue = obj->getWarpingsNumber(); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setWarpingsNumber(cv::superres::DualTVL1OpticalFlow *obj, int val)          { BEGIN_WRAP obj->setWarpingsNumber(val); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getEpsilon(cv::superres::DualTVL1OpticalFlow *obj, double *returnValue)     { BEGIN_WRAP *returnValue = obj->getEpsilon(); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setEpsilon(cv::superres::DualTVL1OpticalFlow *obj, double val)              { BEGIN_WRAP obj->setEpsilon(val); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getIterations(cv::superres::DualTVL1OpticalFlow *obj, int *returnValue)     { BEGIN_WRAP *returnValue = obj->getIterations(); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setIterations(cv::superres::DualTVL1OpticalFlow *obj, int val)              { BEGIN_WRAP obj->setIterations(val); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getUseInitialFlow(cv::superres::DualTVL1OpticalFlow *obj, int *returnValue) { BEGIN_WRAP *returnValue = obj->getUseInitialFlow() ? 1 : 0; END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setUseInitialFlow(cv::superres::DualTVL1OpticalFlow *obj, int val)          { BEGIN_WRAP obj->setUseInitialFlow(val != 0); END_WRAP }

#pragma endregion

#pragma region BroxOpticalFlow

CVAPI(ExceptionStatus) superres_createOptFlow_Brox_CUDA(cv::Ptr<cv::superres::BroxOpticalFlow> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::superres::createOptFlow_Brox_CUDA());
    END_WRAP
}

CVAPI(ExceptionStatus) superres_Ptr_BroxOpticalFlow_get(
    cv::Ptr<cv::superres::BroxOpticalFlow> *ptr, cv::superres::BroxOpticalFlow **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) superres_Ptr_BroxOpticalFlow_delete(
    cv::Ptr<cv::superres::BroxOpticalFlow> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) superres_BroxOpticalFlow_getAlpha(cv::superres::BroxOpticalFlow *obj, double *returnValue)         { BEGIN_WRAP *returnValue = obj->getAlpha(); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_setAlpha(cv::superres::BroxOpticalFlow *obj, double val)                  { BEGIN_WRAP obj->setAlpha(val); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_getGamma(cv::superres::BroxOpticalFlow *obj, double *returnValue)         { BEGIN_WRAP *returnValue = obj->getGamma(); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_setGamma(cv::superres::BroxOpticalFlow *obj, double val)                  { BEGIN_WRAP obj->setGamma(val); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_getScaleFactor(cv::superres::BroxOpticalFlow *obj, double *returnValue)   { BEGIN_WRAP *returnValue = obj->getScaleFactor(); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_setScaleFactor(cv::superres::BroxOpticalFlow *obj, double val)            { BEGIN_WRAP obj->setScaleFactor(val); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_getInnerIterations(cv::superres::BroxOpticalFlow *obj, int *returnValue)  { BEGIN_WRAP *returnValue = obj->getInnerIterations(); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_setInnerIterations(cv::superres::BroxOpticalFlow *obj, int val)           { BEGIN_WRAP obj->setInnerIterations(val); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_getOuterIterations(cv::superres::BroxOpticalFlow *obj, int *returnValue)  { BEGIN_WRAP *returnValue = obj->getOuterIterations(); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_setOuterIterations(cv::superres::BroxOpticalFlow *obj, int val)           { BEGIN_WRAP obj->setOuterIterations(val); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_getSolverIterations(cv::superres::BroxOpticalFlow *obj, int *returnValue) { BEGIN_WRAP *returnValue = obj->getSolverIterations(); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_setSolverIterations(cv::superres::BroxOpticalFlow *obj, int val)          { BEGIN_WRAP obj->setSolverIterations(val); END_WRAP }

#pragma endregion

#pragma region PyrLKOpticalFlow

CVAPI(ExceptionStatus) superres_createOptFlow_PyrLK_CUDA(cv::Ptr<cv::superres::PyrLKOpticalFlow> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::superres::createOptFlow_PyrLK_CUDA());
    END_WRAP
}

CVAPI(ExceptionStatus) superres_Ptr_PyrLKOpticalFlow_get(
    cv::Ptr<cv::superres::PyrLKOpticalFlow> *ptr, cv::superres::PyrLKOpticalFlow **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) superres_Ptr_PyrLKOpticalFlow_delete(
    cv::Ptr<cv::superres::PyrLKOpticalFlow> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) superres_PyrLKOpticalFlow_getWindowSize(cv::superres::PyrLKOpticalFlow *obj, int *returnValue) { BEGIN_WRAP *returnValue = obj->getWindowSize(); END_WRAP }
CVAPI(ExceptionStatus) superres_PyrLKOpticalFlow_setWindowSize(cv::superres::PyrLKOpticalFlow *obj, int val)          { BEGIN_WRAP obj->setWindowSize(val); END_WRAP }
CVAPI(ExceptionStatus) superres_PyrLKOpticalFlow_getMaxLevel(cv::superres::PyrLKOpticalFlow *obj, int *returnValue)   { BEGIN_WRAP *returnValue = obj->getMaxLevel(); END_WRAP }
CVAPI(ExceptionStatus) superres_PyrLKOpticalFlow_setMaxLevel(cv::superres::PyrLKOpticalFlow *obj, int val)            { BEGIN_WRAP obj->setMaxLevel(val); END_WRAP }
CVAPI(ExceptionStatus) superres_PyrLKOpticalFlow_getIterations(cv::superres::PyrLKOpticalFlow *obj, int *returnValue) { BEGIN_WRAP *returnValue = obj->getIterations(); END_WRAP }
CVAPI(ExceptionStatus) superres_PyrLKOpticalFlow_setIterations(cv::superres::PyrLKOpticalFlow *obj, int val)          { BEGIN_WRAP obj->setIterations(val); END_WRAP }

#pragma endregion


#endif // !#ifndef _WINRT_DLL


#endif