#ifndef _CPP_SUPERRES_H_
#define _CPP_SUPERRES_H_

#include "include_opencv.h"

CVAPI(void) superres_FrameSource_nextFrame(
    cv::Ptr<cv::superres::FrameSource> *obj, cv::_OutputArray *frame)
{
    (*obj)->nextFrame(*frame);
}
CVAPI(void) superres_FrameSource_reset(
    cv::Ptr<cv::superres::FrameSource> *obj)
{
    (*obj)->reset();
}

CVAPI(cv::Ptr<cv::superres::FrameSource>*) superres_createFrameSource_Empty()
{
    return clone( cv::superres::createFrameSource_Empty() );
}
CVAPI(cv::Ptr<cv::superres::FrameSource>*) superres_createFrameSource_Video(const char *fileName)
{
    return clone( cv::superres::createFrameSource_Video(fileName) );
}
CVAPI(cv::Ptr<cv::superres::FrameSource>*) superres_createFrameSource_Video_CUDA(const char *fileName)
{
    return clone( cv::superres::createFrameSource_Video_CUDA(fileName) );
}
CVAPI(cv::Ptr<cv::superres::FrameSource>*) superres_createFrameSource_Camera(int deviceId)
{
    return clone( cv::superres::createFrameSource_Camera(deviceId) );
}

CVAPI(cv::superres::FrameSource*) superres_Ptr_FrameSource_get(cv::Ptr<cv::superres::FrameSource> *ptr)
{
    return ptr->get();
}
CVAPI(void) superres_Ptr_FrameSource_delete(cv::Ptr<cv::superres::FrameSource> *ptr)
{
    delete ptr;
}

#pragma region SuperResolution

CVAPI(void) superres_SuperResolution_setInput(
    cv::superres::SuperResolution *obj, cv::Ptr<cv::superres::FrameSource> *frameSource)
{
    obj->setInput(*frameSource);
}
CVAPI(void) superres_SuperResolution_nextFrame(
    cv::superres::SuperResolution *obj, cv::_OutputArray *frame)
{
    obj->nextFrame(*frame);
}
CVAPI(void) superres_SuperResolution_reset(cv::superres::SuperResolution *obj)
{
    obj->reset();
}
CVAPI(void) superres_SuperResolution_collectGarbage(cv::superres::SuperResolution *obj)
{
    obj->collectGarbage();
}

CVAPI(cv::Ptr<cv::superres::SuperResolution>*) superres_createSuperResolution_BTVL1()
{
    return clone( cv::superres::createSuperResolution_BTVL1() );
}
CVAPI(cv::Ptr<cv::superres::SuperResolution>*) superres_createSuperResolution_BTVL1_CUDA()
{
    return clone( cv::superres::createSuperResolution_BTVL1_CUDA() );
}

CVAPI(cv::superres::SuperResolution*) superres_Ptr_SuperResolution_get(
    cv::Ptr<cv::superres::SuperResolution> *ptr)
{
    return ptr->get();
}
CVAPI(void) superres_Ptr_SuperResolution_delete(cv::Ptr<cv::superres::SuperResolution> *ptr)
{
    delete ptr;
}

CVAPI(int) superres_SuperResolution_getScale(cv::superres::SuperResolution *obj) { return obj->getScale(); }
CVAPI(void) superres_SuperResolution_setScale(cv::superres::SuperResolution *obj, int val) { obj->setScale(val); }
CVAPI(int) superres_SuperResolution_getIterations(cv::superres::SuperResolution *obj) { return obj->getIterations(); }
CVAPI(void) superres_SuperResolution_setIterations(cv::superres::SuperResolution *obj, int val) { obj->setIterations(val); }
CVAPI(double) superres_SuperResolution_getTau(cv::superres::SuperResolution *obj) { return obj->getTau(); }
CVAPI(void) superres_SuperResolution_setTau(cv::superres::SuperResolution *obj, double val) { obj->setTau(val); }
CVAPI(double) superres_SuperResolution_getLabmda(cv::superres::SuperResolution *obj) { return obj->getLabmda(); } // TODO typo!
CVAPI(void) superres_SuperResolution_setLabmda(cv::superres::SuperResolution *obj, double val) { obj->setLabmda(val); } // TODO typo!
CVAPI(double) superres_SuperResolution_getAlpha(cv::superres::SuperResolution *obj) { return obj->getAlpha(); }
CVAPI(void) superres_SuperResolution_setAlpha(cv::superres::SuperResolution *obj, double val) { obj->setAlpha(val); }
CVAPI(int) superres_SuperResolution_getKernelSize(cv::superres::SuperResolution *obj) { return obj->getKernelSize(); }
CVAPI(void) superres_SuperResolution_setKernelSize(cv::superres::SuperResolution *obj, int val) { obj->setKernelSize(val); }
CVAPI(int) superres_SuperResolution_getBlurKernelSize(cv::superres::SuperResolution *obj) { return obj->getBlurKernelSize(); }
CVAPI(void) superres_SuperResolution_setBlurKernelSize(cv::superres::SuperResolution *obj, int val) { obj->setBlurKernelSize(val); }
CVAPI(double) superres_SuperResolution_getBlurSigma(cv::superres::SuperResolution *obj) { return obj->getBlurSigma(); }
CVAPI(void) superres_SuperResolution_setBlurSigma(cv::superres::SuperResolution *obj, double val) { obj->setBlurSigma(val); }
CVAPI(int) superres_SuperResolution_getTemporalAreaRadius(cv::superres::SuperResolution *obj) { return obj->getTemporalAreaRadius(); }
CVAPI(void) superres_SuperResolution_setTemporalAreaRadius(cv::superres::SuperResolution *obj, int val) { obj->setTemporalAreaRadius(val); }
CVAPI(cv::Ptr<cv::superres::DenseOpticalFlowExt>*) superres_SuperResolution_getOpticalFlow(cv::superres::SuperResolution *obj)
{
    return new cv::Ptr<cv::superres::DenseOpticalFlowExt>(obj->getOpticalFlow());
}
CVAPI(void) superres_SuperResolution_setOpticalFlow(cv::superres::SuperResolution *obj, cv::Ptr<cv::superres::DenseOpticalFlowExt> *val)
{
    obj->setOpticalFlow(*val);
}

#pragma endregion

CVAPI(void) superres_DenseOpticalFlowExt_calc(cv::superres::DenseOpticalFlowExt *obj,
    cv::_InputArray *frame0, cv::_InputArray *frame1, cv::_OutputArray *flow1, cv::_OutputArray *flow2)
{
    obj->calc(*frame0, *frame1, *flow1, entity(flow2));
}
CVAPI(void) superres_DenseOpticalFlowExt_collectGarbage(cv::superres::DenseOpticalFlowExt *obj)
{
    obj->collectGarbage();
}

CVAPI(cv::superres::DenseOpticalFlowExt*) superres_Ptr_DenseOpticalFlowExt_get(
    cv::Ptr<cv::superres::DenseOpticalFlowExt> *ptr)
{
    return ptr->get();
}
CVAPI(void) superres_Ptr_DenseOpticalFlowExt_delete(
    cv::Ptr<cv::superres::DenseOpticalFlowExt> *ptr)
{
    delete ptr;
}

#pragma region FarnebackOpticalFlow
CVAPI(cv::Ptr<cv::superres::FarnebackOpticalFlow>*) superres_createOptFlow_Farneback()
{
    return clone(cv::superres::createOptFlow_Farneback());
}
CVAPI(cv::Ptr<cv::superres::FarnebackOpticalFlow>*) superres_createOptFlow_Farneback_CUDA()
{
    return clone(cv::superres::createOptFlow_Farneback_CUDA());
}
CVAPI(cv::superres::FarnebackOpticalFlow*) superres_Ptr_FarnebackOpticalFlow_get(
    cv::Ptr<cv::superres::FarnebackOpticalFlow> *ptr)
{
    return ptr->get();
}
CVAPI(void) superres_Ptr_FarnebackOpticalFlow_delete(
    cv::Ptr<cv::superres::FarnebackOpticalFlow> *ptr)
{
    delete ptr;
}

CVAPI(double) superres_FarnebackOpticalFlow_getPyrScale(cv::superres::FarnebackOpticalFlow *obj) { return obj->getPyrScale(); }
CVAPI(void) superres_FarnebackOpticalFlow_setPyrScale(cv::superres::FarnebackOpticalFlow *obj, double val) { obj->setPyrScale(val); }
CVAPI(int) superres_FarnebackOpticalFlow_getLevelsNumber(cv::superres::FarnebackOpticalFlow *obj) { return obj->getLevelsNumber(); }
CVAPI(void) superres_FarnebackOpticalFlow_setLevelsNumber(cv::superres::FarnebackOpticalFlow *obj, int val) { obj->setLevelsNumber(val); }
CVAPI(int) superres_FarnebackOpticalFlow_getWindowSize(cv::superres::FarnebackOpticalFlow *obj) { return obj->getWindowSize(); }
CVAPI(void) superres_FarnebackOpticalFlow_setWindowSize(cv::superres::FarnebackOpticalFlow *obj, int val) { obj->setWindowSize(val); }
CVAPI(int) superres_FarnebackOpticalFlow_getIterations(cv::superres::FarnebackOpticalFlow *obj) { return obj->getIterations(); }
CVAPI(void) superres_FarnebackOpticalFlow_setIterations(cv::superres::FarnebackOpticalFlow *obj, int val) { obj->setIterations(val); }
CVAPI(int) superres_FarnebackOpticalFlow_getPolyN(cv::superres::FarnebackOpticalFlow *obj) { return obj->getPolyN(); }
CVAPI(void) superres_FarnebackOpticalFlow_setPolyN(cv::superres::FarnebackOpticalFlow *obj, int val) { obj->setPolyN(val); }
CVAPI(double) superres_FarnebackOpticalFlow_getPolySigma(cv::superres::FarnebackOpticalFlow *obj) { return obj->getPolySigma(); }
CVAPI(void) superres_FarnebackOpticalFlow_setPolySigma(cv::superres::FarnebackOpticalFlow *obj, double val) { obj->setPolySigma(val); }
CVAPI(int) superres_FarnebackOpticalFlow_getFlags(cv::superres::FarnebackOpticalFlow *obj) { return obj->getFlags(); }
CVAPI(void) superres_FarnebackOpticalFlow_setFlags(cv::superres::FarnebackOpticalFlow *obj, int val) { obj->setFlags(val); }

#pragma endregion

#pragma region DualTVL1OpticalFlow
CVAPI(cv::Ptr<cv::superres::DualTVL1OpticalFlow>*) superres_createOptFlow_DualTVL1()
{
    return clone(cv::superres::createOptFlow_DualTVL1());
}
CVAPI(cv::Ptr<cv::superres::DualTVL1OpticalFlow>*) superres_createOptFlow_DualTVL1_CUDA()
{
    return clone(cv::superres::createOptFlow_DualTVL1_CUDA());
}
CVAPI(cv::superres::DualTVL1OpticalFlow*) superres_Ptr_DualTVL1OpticalFlow_get(
    cv::Ptr<cv::superres::DualTVL1OpticalFlow> *ptr)
{
    return ptr->get();
}
CVAPI(void) superres_Ptr_DualTVL1OpticalFlow_delete(
    cv::Ptr<cv::superres::DualTVL1OpticalFlow> *ptr)
{
    delete ptr;
}

CVAPI(double) superres_DualTVL1OpticalFlow_getTau(cv::superres::DualTVL1OpticalFlow *obj) { return obj->getTau(); }
CVAPI(void) superres_DualTVL1OpticalFlow_setTau(cv::superres::DualTVL1OpticalFlow *obj, double val) { obj->setTau(val); }
CVAPI(double) superres_DualTVL1OpticalFlow_getLambda(cv::superres::DualTVL1OpticalFlow *obj) { return obj->getLambda(); }
CVAPI(void) superres_DualTVL1OpticalFlow_setLambda(cv::superres::DualTVL1OpticalFlow *obj, double val) { obj->setLambda(val); }
CVAPI(double) superres_DualTVL1OpticalFlow_getTheta(cv::superres::DualTVL1OpticalFlow *obj) { return obj->getTheta(); }
CVAPI(void) superres_DualTVL1OpticalFlow_setTheta(cv::superres::DualTVL1OpticalFlow *obj, double val) { obj->setTheta(val); }
CVAPI(int) superres_DualTVL1OpticalFlow_getScalesNumber(cv::superres::DualTVL1OpticalFlow *obj) { return obj->getScalesNumber(); }
CVAPI(void) superres_DualTVL1OpticalFlow_setScalesNumber(cv::superres::DualTVL1OpticalFlow *obj, int val) { obj->setScalesNumber(val); }
CVAPI(int) superres_DualTVL1OpticalFlow_getWarpingsNumber(cv::superres::DualTVL1OpticalFlow *obj) { return obj->getWarpingsNumber(); }
CVAPI(void) superres_DualTVL1OpticalFlow_setWarpingsNumber(cv::superres::DualTVL1OpticalFlow *obj, int val) { obj->setWarpingsNumber(val); }
CVAPI(double) superres_DualTVL1OpticalFlow_getEpsilon(cv::superres::DualTVL1OpticalFlow *obj) { return obj->getEpsilon(); }
CVAPI(void) superres_DualTVL1OpticalFlow_setEpsilon(cv::superres::DualTVL1OpticalFlow *obj, double val) { obj->setEpsilon(val); }
CVAPI(int) superres_DualTVL1OpticalFlow_getIterations(cv::superres::DualTVL1OpticalFlow *obj) { return obj->getIterations(); }
CVAPI(void) superres_DualTVL1OpticalFlow_setIterations(cv::superres::DualTVL1OpticalFlow *obj, int val) { obj->setIterations(val); }
CVAPI(int) superres_DualTVL1OpticalFlow_getUseInitialFlow(cv::superres::DualTVL1OpticalFlow *obj) { return obj->getUseInitialFlow() ? 1 : 0; }
CVAPI(void) superres_DualTVL1OpticalFlow_setUseInitialFlow(cv::superres::DualTVL1OpticalFlow *obj, int val) { obj->setUseInitialFlow(val != 0); }

#pragma endregion

#pragma region BroxOpticalFlow
CVAPI(cv::Ptr<cv::superres::BroxOpticalFlow>*) superres_createOptFlow_Brox_CUDA()
{
    return clone(cv::superres::createOptFlow_Brox_CUDA());
}
CVAPI(cv::superres::BroxOpticalFlow*) superres_Ptr_BroxOpticalFlow_get(
    cv::Ptr<cv::superres::BroxOpticalFlow> *ptr)
{
    return ptr->get();
}
CVAPI(void) superres_Ptr_BroxOpticalFlow_delete(
    cv::Ptr<cv::superres::BroxOpticalFlow> *ptr)
{
    delete ptr;
}

CVAPI(double) superres_BroxOpticalFlow_getAlpha(cv::superres::BroxOpticalFlow *obj) { return obj->getAlpha(); }
CVAPI(void) superres_BroxOpticalFlow_setAlpha(cv::superres::BroxOpticalFlow *obj, double val) { obj->setAlpha(val); }
CVAPI(double) superres_BroxOpticalFlow_getGamma(cv::superres::BroxOpticalFlow *obj) { return obj->getGamma(); }
CVAPI(void) superres_BroxOpticalFlow_setGamma(cv::superres::BroxOpticalFlow *obj, double val) { obj->setGamma(val); }
CVAPI(double) superres_BroxOpticalFlow_getScaleFactor(cv::superres::BroxOpticalFlow *obj) { return obj->getScaleFactor(); }
CVAPI(void) superres_BroxOpticalFlow_setScaleFactor(cv::superres::BroxOpticalFlow *obj, double val) { obj->setScaleFactor(val); }
CVAPI(int) superres_BroxOpticalFlow_getInnerIterations(cv::superres::BroxOpticalFlow *obj) { return obj->getInnerIterations(); }
CVAPI(void) superres_BroxOpticalFlow_setInnerIterations(cv::superres::BroxOpticalFlow *obj, int val) { obj->setInnerIterations(val); }
CVAPI(int) superres_BroxOpticalFlow_getOuterIterations(cv::superres::BroxOpticalFlow *obj) { return obj->getOuterIterations(); }
CVAPI(void) superres_BroxOpticalFlow_setOuterIterations(cv::superres::BroxOpticalFlow *obj, int val) { obj->setOuterIterations(val); }
CVAPI(int) superres_BroxOpticalFlow_getSolverIterations(cv::superres::BroxOpticalFlow *obj) { return obj->getSolverIterations(); }
CVAPI(void) superres_BroxOpticalFlow_setSolverIterations(cv::superres::BroxOpticalFlow *obj, int val) { obj->setSolverIterations(val); }
#pragma endregion

#pragma region PyrLKOpticalFlow
CVAPI(cv::Ptr<cv::superres::PyrLKOpticalFlow>*) superres_createOptFlow_PyrLK_CUDA()
{
    return clone(cv::superres::createOptFlow_PyrLK_CUDA());
}
CVAPI(cv::superres::PyrLKOpticalFlow*) superres_Ptr_PyrLKOpticalFlow_get(
    cv::Ptr<cv::superres::PyrLKOpticalFlow> *ptr)
{
    return ptr->get();
}
CVAPI(void) superres_Ptr_PyrLKOpticalFlow_delete(
    cv::Ptr<cv::superres::PyrLKOpticalFlow> *ptr)
{
    delete ptr;
}

CVAPI(int) superres_PyrLKOpticalFlow_getWindowSize(cv::superres::PyrLKOpticalFlow *obj) { return obj->getWindowSize(); }
CVAPI(void) superres_PyrLKOpticalFlow_setWindowSize(cv::superres::PyrLKOpticalFlow *obj, int val) { obj->setWindowSize(val); }
CVAPI(int) superres_PyrLKOpticalFlow_getMaxLevel(cv::superres::PyrLKOpticalFlow *obj) { return obj->getMaxLevel(); }
CVAPI(void) superres_PyrLKOpticalFlow_setMaxLevel(cv::superres::PyrLKOpticalFlow *obj, int val) { obj->setMaxLevel(val); }
CVAPI(int) superres_PyrLKOpticalFlow_getIterations(cv::superres::PyrLKOpticalFlow *obj) { return obj->getIterations(); }
CVAPI(void) superres_PyrLKOpticalFlow_setIterations(cv::superres::PyrLKOpticalFlow *obj, int val) { obj->setIterations(val); }
#pragma endregion


#endif