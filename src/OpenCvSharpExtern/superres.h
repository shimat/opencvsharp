#pragma once

#ifndef NO_CONTRIB
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


CVAPI(ExceptionStatus) superres_Ptr_FrameSource_delete(cv::Ptr<cv::superres::FrameSource> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

#pragma endregion

#pragma region SuperResolution

CVAPI(ExceptionStatus) superres_SuperResolution_setInput(
    cv::Ptr<cv::superres::SuperResolution>* obj, cv::Ptr<cv::superres::FrameSource> *frameSource)
{
    BEGIN_WRAP
    (*obj)->setInput(*frameSource);
    END_WRAP
}

CVAPI(ExceptionStatus) superres_SuperResolution_nextFrame(
    cv::Ptr<cv::superres::SuperResolution>* obj, cv::_OutputArray *frame)
{
    BEGIN_WRAP
    (*obj)->nextFrame(*frame);
    END_WRAP
}

CVAPI(ExceptionStatus) superres_SuperResolution_reset(cv::Ptr<cv::superres::SuperResolution>* obj)
{
    BEGIN_WRAP
    (*obj)->reset();
    END_WRAP
}

CVAPI(ExceptionStatus) superres_SuperResolution_collectGarbage(cv::Ptr<cv::superres::SuperResolution>* obj)
{
    BEGIN_WRAP
    (*obj)->collectGarbage();
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


CVAPI(ExceptionStatus) superres_Ptr_SuperResolution_delete(cv::Ptr<cv::superres::SuperResolution> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) superres_SuperResolution_getScale(cv::Ptr<cv::superres::SuperResolution>* obj, int *returnValue)              { BEGIN_WRAP *returnValue = (*obj)->getScale(); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_setScale(cv::Ptr<cv::superres::SuperResolution>* obj, int val)                       { BEGIN_WRAP (*obj)->setScale(val); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_getIterations(cv::Ptr<cv::superres::SuperResolution>* obj, int *returnValue)         { BEGIN_WRAP *returnValue = (*obj)->getIterations(); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_setIterations(cv::Ptr<cv::superres::SuperResolution>* obj, int val)                  { BEGIN_WRAP (*obj)->setIterations(val); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_getTau(cv::Ptr<cv::superres::SuperResolution>* obj, double *returnValue)             { BEGIN_WRAP *returnValue = (*obj)->getTau(); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_setTau(cv::Ptr<cv::superres::SuperResolution>* obj, double val)                      { BEGIN_WRAP (*obj)->setTau(val); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_getLambda(cv::Ptr<cv::superres::SuperResolution>* obj, double *returnValue)          { BEGIN_WRAP *returnValue = (*obj)->getLambda(); END_WRAP } 
CVAPI(ExceptionStatus) superres_SuperResolution_setLambda(cv::Ptr<cv::superres::SuperResolution>* obj, double val)                   { BEGIN_WRAP (*obj)->setLambda(val); END_WRAP } 
CVAPI(ExceptionStatus) superres_SuperResolution_getAlpha(cv::Ptr<cv::superres::SuperResolution>* obj, double *returnValue)           { BEGIN_WRAP *returnValue = (*obj)->getAlpha(); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_setAlpha(cv::Ptr<cv::superres::SuperResolution>* obj, double val)                    { BEGIN_WRAP (*obj)->setAlpha(val); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_getKernelSize(cv::Ptr<cv::superres::SuperResolution>* obj, int *returnValue)         { BEGIN_WRAP *returnValue = (*obj)->getKernelSize(); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_setKernelSize(cv::Ptr<cv::superres::SuperResolution>* obj, int val)                  { BEGIN_WRAP (*obj)->setKernelSize(val); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_getBlurKernelSize(cv::Ptr<cv::superres::SuperResolution>* obj, int *returnValue)     { BEGIN_WRAP *returnValue = (*obj)->getBlurKernelSize(); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_setBlurKernelSize(cv::Ptr<cv::superres::SuperResolution>* obj, int val)              { BEGIN_WRAP (*obj)->setBlurKernelSize(val); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_getBlurSigma(cv::Ptr<cv::superres::SuperResolution>* obj, double *returnValue)       { BEGIN_WRAP *returnValue = (*obj)->getBlurSigma(); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_setBlurSigma(cv::Ptr<cv::superres::SuperResolution>* obj, double val)                { BEGIN_WRAP (*obj)->setBlurSigma(val); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_getTemporalAreaRadius(cv::Ptr<cv::superres::SuperResolution>* obj, int *returnValue) { BEGIN_WRAP *returnValue = (*obj)->getTemporalAreaRadius(); END_WRAP }
CVAPI(ExceptionStatus) superres_SuperResolution_setTemporalAreaRadius(cv::Ptr<cv::superres::SuperResolution>* obj, int val)          { BEGIN_WRAP (*obj)->setTemporalAreaRadius(val); END_WRAP }

CVAPI(ExceptionStatus) superres_SuperResolution_getOpticalFlow(cv::Ptr<cv::superres::SuperResolution>* obj, cv::Ptr<cv::superres::DenseOpticalFlowExt> **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Ptr<cv::superres::DenseOpticalFlowExt>(obj->getOpticalFlow());
    END_WRAP
}
CVAPI(ExceptionStatus) superres_SuperResolution_setOpticalFlow(cv::Ptr<cv::superres::SuperResolution>* obj, cv::Ptr<cv::superres::DenseOpticalFlowExt> *val)
{
    BEGIN_WRAP
    (*obj)->setOpticalFlow(*val);
    END_WRAP
}

#pragma endregion

CVAPI(ExceptionStatus) superres_DenseOpticalFlowExt_calc(cv::Ptr<cv::superres::DenseOpticalFlowExt>* obj,
    cv::_InputArray *frame0, cv::_InputArray *frame1, cv::_OutputArray *flow1, cv::_OutputArray *flow2)
{
    BEGIN_WRAP
    (*obj)->calc(*frame0, *frame1, *flow1, entity(flow2));
    END_WRAP
}

CVAPI(ExceptionStatus) superres_DenseOpticalFlowExt_collectGarbage(cv::Ptr<cv::superres::DenseOpticalFlowExt>* obj)
{
    BEGIN_WRAP
    (*obj)->collectGarbage();
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


CVAPI(ExceptionStatus) superres_Ptr_FarnebackOpticalFlow_delete(
    cv::Ptr<cv::superres::FarnebackOpticalFlow> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getPyrScale(cv::Ptr<cv::superres::FarnebackOpticalFlow>* obj, double *returnValue)  { BEGIN_WRAP *returnValue = (*obj)->getPyrScale(); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setPyrScale(cv::Ptr<cv::superres::FarnebackOpticalFlow>* obj, double val)           { BEGIN_WRAP (*obj)->setPyrScale(val); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getLevelsNumber(cv::Ptr<cv::superres::FarnebackOpticalFlow>* obj, int *returnValue) { BEGIN_WRAP *returnValue = (*obj)->getLevelsNumber(); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setLevelsNumber(cv::Ptr<cv::superres::FarnebackOpticalFlow>* obj, int val)          { BEGIN_WRAP (*obj)->setLevelsNumber(val); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getWindowSize(cv::Ptr<cv::superres::FarnebackOpticalFlow>* obj, int *returnValue)   { BEGIN_WRAP *returnValue = (*obj)->getWindowSize(); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setWindowSize(cv::Ptr<cv::superres::FarnebackOpticalFlow>* obj, int val)            { BEGIN_WRAP (*obj)->setWindowSize(val); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getIterations(cv::Ptr<cv::superres::FarnebackOpticalFlow>* obj, int *returnValue)   { BEGIN_WRAP *returnValue = (*obj)->getIterations(); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setIterations(cv::Ptr<cv::superres::FarnebackOpticalFlow>* obj, int val)            { BEGIN_WRAP (*obj)->setIterations(val); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getPolyN(cv::Ptr<cv::superres::FarnebackOpticalFlow>* obj, int *returnValue)        { BEGIN_WRAP *returnValue = (*obj)->getPolyN(); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setPolyN(cv::Ptr<cv::superres::FarnebackOpticalFlow>* obj, int val)                 { BEGIN_WRAP (*obj)->setPolyN(val); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getPolySigma(cv::Ptr<cv::superres::FarnebackOpticalFlow>* obj, double *returnValue) { BEGIN_WRAP *returnValue = (*obj)->getPolySigma(); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setPolySigma(cv::Ptr<cv::superres::FarnebackOpticalFlow>* obj, double val)          { BEGIN_WRAP (*obj)->setPolySigma(val); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_getFlags(cv::Ptr<cv::superres::FarnebackOpticalFlow>* obj, int *returnValue)        { BEGIN_WRAP *returnValue = (*obj)->getFlags(); END_WRAP }
CVAPI(ExceptionStatus) superres_FarnebackOpticalFlow_setFlags(cv::Ptr<cv::superres::FarnebackOpticalFlow>* obj, int val)                 { BEGIN_WRAP (*obj)->setFlags(val); END_WRAP }

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


CVAPI(ExceptionStatus) superres_Ptr_DualTVL1OpticalFlow_delete(
    cv::Ptr<cv::superres::DualTVL1OpticalFlow> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getTau(cv::Ptr<cv::superres::DualTVL1OpticalFlow>* obj, double *returnValue)         { BEGIN_WRAP *returnValue = (*obj)->getTau(); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setTau(cv::Ptr<cv::superres::DualTVL1OpticalFlow>* obj, double val)                  { BEGIN_WRAP (*obj)->setTau(val); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getLambda(cv::Ptr<cv::superres::DualTVL1OpticalFlow>* obj, double *returnValue)      { BEGIN_WRAP *returnValue = (*obj)->getLambda(); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setLambda(cv::Ptr<cv::superres::DualTVL1OpticalFlow>* obj, double val)               { BEGIN_WRAP (*obj)->setLambda(val); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getTheta(cv::Ptr<cv::superres::DualTVL1OpticalFlow>* obj, double *returnValue)       { BEGIN_WRAP *returnValue = (*obj)->getTheta(); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setTheta(cv::Ptr<cv::superres::DualTVL1OpticalFlow>* obj, double val)                { BEGIN_WRAP (*obj)->setTheta(val); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getScalesNumber(cv::Ptr<cv::superres::DualTVL1OpticalFlow>* obj, int *returnValue)   { BEGIN_WRAP *returnValue = (*obj)->getScalesNumber(); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setScalesNumber(cv::Ptr<cv::superres::DualTVL1OpticalFlow>* obj, int val)            { BEGIN_WRAP (*obj)->setScalesNumber(val); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getWarpingsNumber(cv::Ptr<cv::superres::DualTVL1OpticalFlow>* obj, int *returnValue) { BEGIN_WRAP *returnValue = (*obj)->getWarpingsNumber(); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setWarpingsNumber(cv::Ptr<cv::superres::DualTVL1OpticalFlow>* obj, int val)          { BEGIN_WRAP (*obj)->setWarpingsNumber(val); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getEpsilon(cv::Ptr<cv::superres::DualTVL1OpticalFlow>* obj, double *returnValue)     { BEGIN_WRAP *returnValue = (*obj)->getEpsilon(); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setEpsilon(cv::Ptr<cv::superres::DualTVL1OpticalFlow>* obj, double val)              { BEGIN_WRAP (*obj)->setEpsilon(val); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getIterations(cv::Ptr<cv::superres::DualTVL1OpticalFlow>* obj, int *returnValue)     { BEGIN_WRAP *returnValue = (*obj)->getIterations(); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setIterations(cv::Ptr<cv::superres::DualTVL1OpticalFlow>* obj, int val)              { BEGIN_WRAP (*obj)->setIterations(val); END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_getUseInitialFlow(cv::Ptr<cv::superres::DualTVL1OpticalFlow>* obj, int *returnValue) { BEGIN_WRAP *returnValue = (*obj)->getUseInitialFlow() ? 1 : 0; END_WRAP }
CVAPI(ExceptionStatus) superres_DualTVL1OpticalFlow_setUseInitialFlow(cv::Ptr<cv::superres::DualTVL1OpticalFlow>* obj, int val)          { BEGIN_WRAP (*obj)->setUseInitialFlow(val != 0); END_WRAP }

#pragma endregion

#pragma region BroxOpticalFlow

CVAPI(ExceptionStatus) superres_createOptFlow_Brox_CUDA(cv::Ptr<cv::superres::BroxOpticalFlow> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::superres::createOptFlow_Brox_CUDA());
    END_WRAP
}


CVAPI(ExceptionStatus) superres_Ptr_BroxOpticalFlow_delete(
    cv::Ptr<cv::superres::BroxOpticalFlow> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) superres_BroxOpticalFlow_getAlpha(cv::Ptr<cv::superres::BroxOpticalFlow>* obj, double *returnValue)         { BEGIN_WRAP *returnValue = (*obj)->getAlpha(); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_setAlpha(cv::Ptr<cv::superres::BroxOpticalFlow>* obj, double val)                  { BEGIN_WRAP (*obj)->setAlpha(val); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_getGamma(cv::Ptr<cv::superres::BroxOpticalFlow>* obj, double *returnValue)         { BEGIN_WRAP *returnValue = (*obj)->getGamma(); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_setGamma(cv::Ptr<cv::superres::BroxOpticalFlow>* obj, double val)                  { BEGIN_WRAP (*obj)->setGamma(val); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_getScaleFactor(cv::Ptr<cv::superres::BroxOpticalFlow>* obj, double *returnValue)   { BEGIN_WRAP *returnValue = (*obj)->getScaleFactor(); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_setScaleFactor(cv::Ptr<cv::superres::BroxOpticalFlow>* obj, double val)            { BEGIN_WRAP (*obj)->setScaleFactor(val); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_getInnerIterations(cv::Ptr<cv::superres::BroxOpticalFlow>* obj, int *returnValue)  { BEGIN_WRAP *returnValue = (*obj)->getInnerIterations(); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_setInnerIterations(cv::Ptr<cv::superres::BroxOpticalFlow>* obj, int val)           { BEGIN_WRAP (*obj)->setInnerIterations(val); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_getOuterIterations(cv::Ptr<cv::superres::BroxOpticalFlow>* obj, int *returnValue)  { BEGIN_WRAP *returnValue = (*obj)->getOuterIterations(); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_setOuterIterations(cv::Ptr<cv::superres::BroxOpticalFlow>* obj, int val)           { BEGIN_WRAP (*obj)->setOuterIterations(val); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_getSolverIterations(cv::Ptr<cv::superres::BroxOpticalFlow>* obj, int *returnValue) { BEGIN_WRAP *returnValue = (*obj)->getSolverIterations(); END_WRAP }
CVAPI(ExceptionStatus) superres_BroxOpticalFlow_setSolverIterations(cv::Ptr<cv::superres::BroxOpticalFlow>* obj, int val)          { BEGIN_WRAP (*obj)->setSolverIterations(val); END_WRAP }

#pragma endregion

#pragma region PyrLKOpticalFlow

CVAPI(ExceptionStatus) superres_createOptFlow_PyrLK_CUDA(cv::Ptr<cv::superres::PyrLKOpticalFlow> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::superres::createOptFlow_PyrLK_CUDA());
    END_WRAP
}


CVAPI(ExceptionStatus) superres_Ptr_PyrLKOpticalFlow_delete(
    cv::Ptr<cv::superres::PyrLKOpticalFlow> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) superres_PyrLKOpticalFlow_getWindowSize(cv::Ptr<cv::superres::PyrLKOpticalFlow>* obj, int *returnValue) { BEGIN_WRAP *returnValue = (*obj)->getWindowSize(); END_WRAP }
CVAPI(ExceptionStatus) superres_PyrLKOpticalFlow_setWindowSize(cv::Ptr<cv::superres::PyrLKOpticalFlow>* obj, int val)          { BEGIN_WRAP (*obj)->setWindowSize(val); END_WRAP }
CVAPI(ExceptionStatus) superres_PyrLKOpticalFlow_getMaxLevel(cv::Ptr<cv::superres::PyrLKOpticalFlow>* obj, int *returnValue)   { BEGIN_WRAP *returnValue = (*obj)->getMaxLevel(); END_WRAP }
CVAPI(ExceptionStatus) superres_PyrLKOpticalFlow_setMaxLevel(cv::Ptr<cv::superres::PyrLKOpticalFlow>* obj, int val)            { BEGIN_WRAP (*obj)->setMaxLevel(val); END_WRAP }
CVAPI(ExceptionStatus) superres_PyrLKOpticalFlow_getIterations(cv::Ptr<cv::superres::PyrLKOpticalFlow>* obj, int *returnValue) { BEGIN_WRAP *returnValue = (*obj)->getIterations(); END_WRAP }
CVAPI(ExceptionStatus) superres_PyrLKOpticalFlow_setIterations(cv::Ptr<cv::superres::PyrLKOpticalFlow>* obj, int val)          { BEGIN_WRAP (*obj)->setIterations(val); END_WRAP }

#pragma endregion

#endif // _WINRT_DLL
#endif // NO_CONTRIB
