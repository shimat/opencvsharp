#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) optflow_calcOpticalFlowSF1(
    const interop::InputArrayProxy* from,
    const interop::InputArrayProxy* to,
    const interop::OutputArrayProxy* flow,
    int layers,
    int averagingBlockSize,
    int maxFlow)
{
    return cvTry([&] {
        cv::optflow::calcOpticalFlowSF(InProxy(*from), InProxy(*to), OutProxy(*flow), layers, averagingBlockSize, maxFlow);
    });
}

CVAPI(ExceptionStatus) optflow_calcOpticalFlowSF2(
    const interop::InputArrayProxy* from,
    const interop::InputArrayProxy* to,
    const interop::OutputArrayProxy* flow,
    int layers,
    int averagingBlockSize,
    int maxFlow,
    double sigmaDist,
    double sigmaColor,
    int postprocessWindow,
    double sigmaDistFix,
    double sigmaColorFix,
    double occThr,
    int upscaleAveragingRadius,
    double upscaleSigmaDist,
    double upscaleSigmaColor,
    double speedUpThr)
{
    return cvTry([&] {
        cv::optflow::calcOpticalFlowSF(InProxy(*from), InProxy(*to), OutProxy(*flow), layers, averagingBlockSize, maxFlow,
            sigmaDist, sigmaColor, postprocessWindow, sigmaDistFix, sigmaColorFix,
            occThr, upscaleAveragingRadius, upscaleSigmaDist, upscaleSigmaColor, speedUpThr);
    });
}

CVAPI(ExceptionStatus) optflow_calcOpticalFlowSparseToDense(
    const interop::InputArrayProxy* from,
    const interop::InputArrayProxy* to,
    const interop::OutputArrayProxy* flow,
    int grid_step,
    int k,
    float sigma,
    int use_post_proc,
    float fgs_lambda,
    float fgs_sigma)
{
    return cvTry([&] {
        cv::optflow::calcOpticalFlowSparseToDense(
            InProxy(*from), InProxy(*to), OutProxy(*flow),
            grid_step, k, sigma, use_post_proc != 0, fgs_lambda, fgs_sigma);
    });
}

#pragma region createOptFlow_* factories returning the opaque base Ptr<DenseOpticalFlow>/Ptr<SparseOpticalFlow>

// These factories return the concrete DeepFlow/SimpleFlow/Farneback/SparseToDense/PCAFlow/DenseRLOF/SparseRLOF
// implementation, but typed as Ptr<cv::DenseOpticalFlow> (or Ptr<cv::SparseOpticalFlow>) by the OpenCV API itself,
// so they are exposed on the managed side as plain OpenCvSharp.DenseOpticalFlow/SparseOpticalFlow instances via
// DenseOpticalFlow.FromPtr/SparseOpticalFlow.FromPtr, reusing the existing video_Ptr_DenseOpticalFlow_get/delete
// and video_Ptr_SparseOpticalFlow_get/delete bindings already defined in video_tracking.h for the base type.

CVAPI(ExceptionStatus) optflow_createOptFlow_DeepFlow(cv::Ptr<cv::DenseOpticalFlow> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::optflow::createOptFlow_DeepFlow());
    });
}

CVAPI(ExceptionStatus) optflow_createOptFlow_SimpleFlow(cv::Ptr<cv::DenseOpticalFlow> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::optflow::createOptFlow_SimpleFlow());
    });
}

CVAPI(ExceptionStatus) optflow_createOptFlow_Farneback(cv::Ptr<cv::DenseOpticalFlow> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::optflow::createOptFlow_Farneback());
    });
}

CVAPI(ExceptionStatus) optflow_createOptFlow_SparseToDense(cv::Ptr<cv::DenseOpticalFlow> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::optflow::createOptFlow_SparseToDense());
    });
}

#pragma endregion

#pragma region DualTVL1OpticalFlow

CVAPI(ExceptionStatus) optflow_Ptr_DualTVL1OpticalFlow_delete(cv::Ptr<cv::optflow::DualTVL1OpticalFlow> *obj)
{
    return cvTry([&] { delete obj; });
}

CVAPI(ExceptionStatus) optflow_Ptr_DualTVL1OpticalFlow_get(
    cv::Ptr<cv::optflow::DualTVL1OpticalFlow> *ptr, cv::optflow::DualTVL1OpticalFlow **returnValue)
{
    return cvTry([&] { *returnValue = ptr->get(); });
}

CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_create(
    double tau, double lambda, double theta, int nscales, int warps, double epsilon,
    int innerIterations, int outerIterations, double scaleStep, double gamma,
    int medianFiltering, int useInitialFlow,
    cv::Ptr<cv::optflow::DualTVL1OpticalFlow> **returnValue)
{
    return cvTry([&] {
        const auto p = cv::optflow::DualTVL1OpticalFlow::create(
            tau, lambda, theta, nscales, warps, epsilon,
            innerIterations, outerIterations, scaleStep, gamma,
            medianFiltering, useInitialFlow != 0);
        *returnValue = new cv::Ptr<cv::optflow::DualTVL1OpticalFlow>(p);
    });
}

CVAPI(ExceptionStatus) optflow_createOptFlow_DualTVL1(cv::Ptr<cv::optflow::DualTVL1OpticalFlow> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::optflow::createOptFlow_DualTVL1());
    });
}

CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_getTau(cv::optflow::DualTVL1OpticalFlow *obj, double *returnValue) { return cvTry([&] { *returnValue = obj->getTau(); }); }
CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_setTau(cv::optflow::DualTVL1OpticalFlow *obj, double value) { return cvTry([&] { obj->setTau(value); }); }

CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_getLambda(cv::optflow::DualTVL1OpticalFlow *obj, double *returnValue) { return cvTry([&] { *returnValue = obj->getLambda(); }); }
CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_setLambda(cv::optflow::DualTVL1OpticalFlow *obj, double value) { return cvTry([&] { obj->setLambda(value); }); }

CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_getTheta(cv::optflow::DualTVL1OpticalFlow *obj, double *returnValue) { return cvTry([&] { *returnValue = obj->getTheta(); }); }
CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_setTheta(cv::optflow::DualTVL1OpticalFlow *obj, double value) { return cvTry([&] { obj->setTheta(value); }); }

CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_getGamma(cv::optflow::DualTVL1OpticalFlow *obj, double *returnValue) { return cvTry([&] { *returnValue = obj->getGamma(); }); }
CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_setGamma(cv::optflow::DualTVL1OpticalFlow *obj, double value) { return cvTry([&] { obj->setGamma(value); }); }

CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_getScalesNumber(cv::optflow::DualTVL1OpticalFlow *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getScalesNumber(); }); }
CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_setScalesNumber(cv::optflow::DualTVL1OpticalFlow *obj, int value) { return cvTry([&] { obj->setScalesNumber(value); }); }

CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_getWarpingsNumber(cv::optflow::DualTVL1OpticalFlow *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getWarpingsNumber(); }); }
CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_setWarpingsNumber(cv::optflow::DualTVL1OpticalFlow *obj, int value) { return cvTry([&] { obj->setWarpingsNumber(value); }); }

CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_getEpsilon(cv::optflow::DualTVL1OpticalFlow *obj, double *returnValue) { return cvTry([&] { *returnValue = obj->getEpsilon(); }); }
CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_setEpsilon(cv::optflow::DualTVL1OpticalFlow *obj, double value) { return cvTry([&] { obj->setEpsilon(value); }); }

CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_getInnerIterations(cv::optflow::DualTVL1OpticalFlow *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getInnerIterations(); }); }
CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_setInnerIterations(cv::optflow::DualTVL1OpticalFlow *obj, int value) { return cvTry([&] { obj->setInnerIterations(value); }); }

CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_getOuterIterations(cv::optflow::DualTVL1OpticalFlow *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getOuterIterations(); }); }
CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_setOuterIterations(cv::optflow::DualTVL1OpticalFlow *obj, int value) { return cvTry([&] { obj->setOuterIterations(value); }); }

CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_getUseInitialFlow(cv::optflow::DualTVL1OpticalFlow *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getUseInitialFlow() ? 1 : 0; }); }
CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_setUseInitialFlow(cv::optflow::DualTVL1OpticalFlow *obj, int value) { return cvTry([&] { obj->setUseInitialFlow(value != 0); }); }

CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_getScaleStep(cv::optflow::DualTVL1OpticalFlow *obj, double *returnValue) { return cvTry([&] { *returnValue = obj->getScaleStep(); }); }
CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_setScaleStep(cv::optflow::DualTVL1OpticalFlow *obj, double value) { return cvTry([&] { obj->setScaleStep(value); }); }

CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_getMedianFiltering(cv::optflow::DualTVL1OpticalFlow *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getMedianFiltering(); }); }
CVAPI(ExceptionStatus) optflow_DualTVL1OpticalFlow_setMedianFiltering(cv::optflow::DualTVL1OpticalFlow *obj, int value) { return cvTry([&] { obj->setMedianFiltering(value); }); }

#pragma endregion

#pragma region PCAPrior

CVAPI(ExceptionStatus) optflow_Ptr_PCAPrior_delete(cv::Ptr<cv::optflow::PCAPrior> *obj)
{
    return cvTry([&] { delete obj; });
}

CVAPI(ExceptionStatus) optflow_Ptr_PCAPrior_get(cv::Ptr<cv::optflow::PCAPrior> *ptr, cv::optflow::PCAPrior **returnValue)
{
    return cvTry([&] { *returnValue = ptr->get(); });
}

CVAPI(ExceptionStatus) optflow_PCAPrior_new(const char *pathToPrior, cv::Ptr<cv::optflow::PCAPrior> **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Ptr<cv::optflow::PCAPrior>(cv::makePtr<cv::optflow::PCAPrior>(pathToPrior));
    });
}

CVAPI(ExceptionStatus) optflow_PCAPrior_getPadding(cv::optflow::PCAPrior *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getPadding(); });
}

CVAPI(ExceptionStatus) optflow_PCAPrior_getBasisSize(cv::optflow::PCAPrior *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getBasisSize(); });
}

#pragma endregion

#pragma region OpticalFlowPCAFlow

CVAPI(ExceptionStatus) optflow_Ptr_OpticalFlowPCAFlow_delete(cv::Ptr<cv::optflow::OpticalFlowPCAFlow> *obj)
{
    return cvTry([&] { delete obj; });
}

CVAPI(ExceptionStatus) optflow_Ptr_OpticalFlowPCAFlow_get(
    cv::Ptr<cv::optflow::OpticalFlowPCAFlow> *ptr, cv::optflow::OpticalFlowPCAFlow **returnValue)
{
    return cvTry([&] { *returnValue = ptr->get(); });
}

// prior may be null (no learned prior). basisSize is passed as separate width/height ints rather than
// interop::Size to keep this entry point trivial to call with a default-constructed cv::Size(18, 14).
CVAPI(ExceptionStatus) optflow_OpticalFlowPCAFlow_new(
    cv::Ptr<cv::optflow::PCAPrior> *prior,
    int basisSizeWidth, int basisSizeHeight,
    float sparseRate, float retainedCornersFraction, float occlusionsThreshold,
    float dampingFactor, float claheClip,
    cv::Ptr<cv::optflow::OpticalFlowPCAFlow> **returnValue)
{
    return cvTry([&] {
        const cv::Ptr<const cv::optflow::PCAPrior> priorPtr = prior
            ? cv::Ptr<const cv::optflow::PCAPrior>(*prior)
            : cv::Ptr<const cv::optflow::PCAPrior>();
        *returnValue = new cv::Ptr<cv::optflow::OpticalFlowPCAFlow>(
            cv::makePtr<cv::optflow::OpticalFlowPCAFlow>(
                priorPtr, cv::Size(basisSizeWidth, basisSizeHeight),
                sparseRate, retainedCornersFraction, occlusionsThreshold, dampingFactor, claheClip));
    });
}

CVAPI(ExceptionStatus) optflow_createOptFlow_PCAFlow(cv::Ptr<cv::DenseOpticalFlow> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::optflow::createOptFlow_PCAFlow());
    });
}

#pragma endregion

#pragma region RLOFOpticalFlowParameter

CVAPI(ExceptionStatus) optflow_Ptr_RLOFOpticalFlowParameter_delete(cv::Ptr<cv::optflow::RLOFOpticalFlowParameter> *obj)
{
    return cvTry([&] { delete obj; });
}

CVAPI(ExceptionStatus) optflow_Ptr_RLOFOpticalFlowParameter_get(
    cv::Ptr<cv::optflow::RLOFOpticalFlowParameter> *ptr, cv::optflow::RLOFOpticalFlowParameter **returnValue)
{
    return cvTry([&] { *returnValue = ptr->get(); });
}

CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_create(cv::Ptr<cv::optflow::RLOFOpticalFlowParameter> **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Ptr<cv::optflow::RLOFOpticalFlowParameter>(cv::optflow::RLOFOpticalFlowParameter::create());
    });
}

CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_setUseMEstimator(cv::optflow::RLOFOpticalFlowParameter *obj, int val)
{
    return cvTry([&] { obj->setUseMEstimator(val != 0); });
}

CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_getSolverType(cv::optflow::RLOFOpticalFlowParameter *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getSolverType(); }); }
CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_setSolverType(cv::optflow::RLOFOpticalFlowParameter *obj, int value) { return cvTry([&] { obj->setSolverType(static_cast<cv::optflow::SolverType>(value)); }); }

CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_getSupportRegionType(cv::optflow::RLOFOpticalFlowParameter *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getSupportRegionType(); }); }
CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_setSupportRegionType(cv::optflow::RLOFOpticalFlowParameter *obj, int value) { return cvTry([&] { obj->setSupportRegionType(static_cast<cv::optflow::SupportRegionType>(value)); }); }

CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_getNormSigma0(cv::optflow::RLOFOpticalFlowParameter *obj, float *returnValue) { return cvTry([&] { *returnValue = obj->getNormSigma0(); }); }
CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_setNormSigma0(cv::optflow::RLOFOpticalFlowParameter *obj, float value) { return cvTry([&] { obj->setNormSigma0(value); }); }

CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_getNormSigma1(cv::optflow::RLOFOpticalFlowParameter *obj, float *returnValue) { return cvTry([&] { *returnValue = obj->getNormSigma1(); }); }
CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_setNormSigma1(cv::optflow::RLOFOpticalFlowParameter *obj, float value) { return cvTry([&] { obj->setNormSigma1(value); }); }

CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_getSmallWinSize(cv::optflow::RLOFOpticalFlowParameter *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getSmallWinSize(); }); }
CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_setSmallWinSize(cv::optflow::RLOFOpticalFlowParameter *obj, int value) { return cvTry([&] { obj->setSmallWinSize(value); }); }

CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_getLargeWinSize(cv::optflow::RLOFOpticalFlowParameter *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getLargeWinSize(); }); }
CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_setLargeWinSize(cv::optflow::RLOFOpticalFlowParameter *obj, int value) { return cvTry([&] { obj->setLargeWinSize(value); }); }

CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_getCrossSegmentationThreshold(cv::optflow::RLOFOpticalFlowParameter *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getCrossSegmentationThreshold(); }); }
CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_setCrossSegmentationThreshold(cv::optflow::RLOFOpticalFlowParameter *obj, int value) { return cvTry([&] { obj->setCrossSegmentationThreshold(value); }); }

CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_getMaxLevel(cv::optflow::RLOFOpticalFlowParameter *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getMaxLevel(); }); }
CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_setMaxLevel(cv::optflow::RLOFOpticalFlowParameter *obj, int value) { return cvTry([&] { obj->setMaxLevel(value); }); }

CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_getUseInitialFlow(cv::optflow::RLOFOpticalFlowParameter *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getUseInitialFlow() ? 1 : 0; }); }
CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_setUseInitialFlow(cv::optflow::RLOFOpticalFlowParameter *obj, int value) { return cvTry([&] { obj->setUseInitialFlow(value != 0); }); }

CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_getUseIlluminationModel(cv::optflow::RLOFOpticalFlowParameter *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getUseIlluminationModel() ? 1 : 0; }); }
CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_setUseIlluminationModel(cv::optflow::RLOFOpticalFlowParameter *obj, int value) { return cvTry([&] { obj->setUseIlluminationModel(value != 0); }); }

CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_getUseGlobalMotionPrior(cv::optflow::RLOFOpticalFlowParameter *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getUseGlobalMotionPrior() ? 1 : 0; }); }
CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_setUseGlobalMotionPrior(cv::optflow::RLOFOpticalFlowParameter *obj, int value) { return cvTry([&] { obj->setUseGlobalMotionPrior(value != 0); }); }

CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_getMaxIteration(cv::optflow::RLOFOpticalFlowParameter *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getMaxIteration(); }); }
CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_setMaxIteration(cv::optflow::RLOFOpticalFlowParameter *obj, int value) { return cvTry([&] { obj->setMaxIteration(value); }); }

CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_getMinEigenValue(cv::optflow::RLOFOpticalFlowParameter *obj, float *returnValue) { return cvTry([&] { *returnValue = obj->getMinEigenValue(); }); }
CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_setMinEigenValue(cv::optflow::RLOFOpticalFlowParameter *obj, float value) { return cvTry([&] { obj->setMinEigenValue(value); }); }

CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_getGlobalMotionRansacThreshold(cv::optflow::RLOFOpticalFlowParameter *obj, float *returnValue) { return cvTry([&] { *returnValue = obj->getGlobalMotionRansacThreshold(); }); }
CVAPI(ExceptionStatus) optflow_RLOFOpticalFlowParameter_setGlobalMotionRansacThreshold(cv::optflow::RLOFOpticalFlowParameter *obj, float value) { return cvTry([&] { obj->setGlobalMotionRansacThreshold(value); }); }

#pragma endregion

#pragma region DenseRLOFOpticalFlow

CVAPI(ExceptionStatus) optflow_Ptr_DenseRLOFOpticalFlow_delete(cv::Ptr<cv::optflow::DenseRLOFOpticalFlow> *obj)
{
    return cvTry([&] { delete obj; });
}

CVAPI(ExceptionStatus) optflow_Ptr_DenseRLOFOpticalFlow_get(
    cv::Ptr<cv::optflow::DenseRLOFOpticalFlow> *ptr, cv::optflow::DenseRLOFOpticalFlow **returnValue)
{
    return cvTry([&] { *returnValue = ptr->get(); });
}

CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_create(
    cv::Ptr<cv::optflow::RLOFOpticalFlowParameter> *rlofParam,
    float forwardBackwardThreshold,
    interop::Size gridStep,
    int interpType,
    int epicK, float epicSigma, float epicLambda,
    int ricSPSize, int ricSLICType,
    int usePostProc, float fgsLambda, float fgsSigma,
    int useVariationalRefinement,
    cv::Ptr<cv::optflow::DenseRLOFOpticalFlow> **returnValue)
{
    return cvTry([&] {
        const cv::Ptr<cv::optflow::RLOFOpticalFlowParameter> param =
            rlofParam ? *rlofParam : cv::Ptr<cv::optflow::RLOFOpticalFlowParameter>();
        *returnValue = new cv::Ptr<cv::optflow::DenseRLOFOpticalFlow>(
            cv::optflow::DenseRLOFOpticalFlow::create(
                param, forwardBackwardThreshold, cpp(gridStep),
                static_cast<cv::optflow::InterpolationType>(interpType),
                epicK, epicSigma, epicLambda, ricSPSize, ricSLICType,
                usePostProc != 0, fgsLambda, fgsSigma, useVariationalRefinement != 0));
    });
}

CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_getRLOFOpticalFlowParameter(
    cv::optflow::DenseRLOFOpticalFlow *obj, cv::Ptr<cv::optflow::RLOFOpticalFlowParameter> **returnValue)
{
    return cvTry([&] { *returnValue = clone(obj->getRLOFOpticalFlowParameter()); });
}

CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_setRLOFOpticalFlowParameter(
    cv::optflow::DenseRLOFOpticalFlow *obj, cv::Ptr<cv::optflow::RLOFOpticalFlowParameter> *val)
{
    return cvTry([&] {
        obj->setRLOFOpticalFlowParameter(val ? *val : cv::Ptr<cv::optflow::RLOFOpticalFlowParameter>());
    });
}

CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_getForwardBackward(cv::optflow::DenseRLOFOpticalFlow *obj, float *returnValue) { return cvTry([&] { *returnValue = obj->getForwardBackward(); }); }
CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_setForwardBackward(cv::optflow::DenseRLOFOpticalFlow *obj, float value) { return cvTry([&] { obj->setForwardBackward(value); }); }

CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_getGridStep(cv::optflow::DenseRLOFOpticalFlow *obj, interop::Size *returnValue) { return cvTry([&] { *returnValue = c(obj->getGridStep()); }); }
CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_setGridStep(cv::optflow::DenseRLOFOpticalFlow *obj, interop::Size value) { return cvTry([&] { obj->setGridStep(cpp(value)); }); }

CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_getInterpolation(cv::optflow::DenseRLOFOpticalFlow *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getInterpolation(); }); }
CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_setInterpolation(cv::optflow::DenseRLOFOpticalFlow *obj, int value) { return cvTry([&] { obj->setInterpolation(static_cast<cv::optflow::InterpolationType>(value)); }); }

CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_getEPICK(cv::optflow::DenseRLOFOpticalFlow *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getEPICK(); }); }
CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_setEPICK(cv::optflow::DenseRLOFOpticalFlow *obj, int value) { return cvTry([&] { obj->setEPICK(value); }); }

CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_getEPICSigma(cv::optflow::DenseRLOFOpticalFlow *obj, float *returnValue) { return cvTry([&] { *returnValue = obj->getEPICSigma(); }); }
CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_setEPICSigma(cv::optflow::DenseRLOFOpticalFlow *obj, float value) { return cvTry([&] { obj->setEPICSigma(value); }); }

CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_getEPICLambda(cv::optflow::DenseRLOFOpticalFlow *obj, float *returnValue) { return cvTry([&] { *returnValue = obj->getEPICLambda(); }); }
CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_setEPICLambda(cv::optflow::DenseRLOFOpticalFlow *obj, float value) { return cvTry([&] { obj->setEPICLambda(value); }); }

CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_getFgsLambda(cv::optflow::DenseRLOFOpticalFlow *obj, float *returnValue) { return cvTry([&] { *returnValue = obj->getFgsLambda(); }); }
CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_setFgsLambda(cv::optflow::DenseRLOFOpticalFlow *obj, float value) { return cvTry([&] { obj->setFgsLambda(value); }); }

CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_getFgsSigma(cv::optflow::DenseRLOFOpticalFlow *obj, float *returnValue) { return cvTry([&] { *returnValue = obj->getFgsSigma(); }); }
CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_setFgsSigma(cv::optflow::DenseRLOFOpticalFlow *obj, float value) { return cvTry([&] { obj->setFgsSigma(value); }); }

CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_getUsePostProc(cv::optflow::DenseRLOFOpticalFlow *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getUsePostProc() ? 1 : 0; }); }
CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_setUsePostProc(cv::optflow::DenseRLOFOpticalFlow *obj, int value) { return cvTry([&] { obj->setUsePostProc(value != 0); }); }

CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_getUseVariationalRefinement(cv::optflow::DenseRLOFOpticalFlow *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getUseVariationalRefinement() ? 1 : 0; }); }
CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_setUseVariationalRefinement(cv::optflow::DenseRLOFOpticalFlow *obj, int value) { return cvTry([&] { obj->setUseVariationalRefinement(value != 0); }); }

CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_getRICSPSize(cv::optflow::DenseRLOFOpticalFlow *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getRICSPSize(); }); }
CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_setRICSPSize(cv::optflow::DenseRLOFOpticalFlow *obj, int value) { return cvTry([&] { obj->setRICSPSize(value); }); }

CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_getRICSLICType(cv::optflow::DenseRLOFOpticalFlow *obj, int *returnValue) { return cvTry([&] { *returnValue = obj->getRICSLICType(); }); }
CVAPI(ExceptionStatus) optflow_DenseRLOFOpticalFlow_setRICSLICType(cv::optflow::DenseRLOFOpticalFlow *obj, int value) { return cvTry([&] { obj->setRICSLICType(value); }); }

CVAPI(ExceptionStatus) optflow_createOptFlow_DenseRLOF(cv::Ptr<cv::DenseOpticalFlow> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::optflow::createOptFlow_DenseRLOF());
    });
}

#pragma endregion

#pragma region SparseRLOFOpticalFlow

CVAPI(ExceptionStatus) optflow_Ptr_SparseRLOFOpticalFlow_delete(cv::Ptr<cv::optflow::SparseRLOFOpticalFlow> *obj)
{
    return cvTry([&] { delete obj; });
}

CVAPI(ExceptionStatus) optflow_Ptr_SparseRLOFOpticalFlow_get(
    cv::Ptr<cv::optflow::SparseRLOFOpticalFlow> *ptr, cv::optflow::SparseRLOFOpticalFlow **returnValue)
{
    return cvTry([&] { *returnValue = ptr->get(); });
}

CVAPI(ExceptionStatus) optflow_SparseRLOFOpticalFlow_create(
    cv::Ptr<cv::optflow::RLOFOpticalFlowParameter> *rlofParam,
    float forwardBackwardThreshold,
    cv::Ptr<cv::optflow::SparseRLOFOpticalFlow> **returnValue)
{
    return cvTry([&] {
        const cv::Ptr<cv::optflow::RLOFOpticalFlowParameter> param =
            rlofParam ? *rlofParam : cv::Ptr<cv::optflow::RLOFOpticalFlowParameter>();
        *returnValue = new cv::Ptr<cv::optflow::SparseRLOFOpticalFlow>(
            cv::optflow::SparseRLOFOpticalFlow::create(param, forwardBackwardThreshold));
    });
}

CVAPI(ExceptionStatus) optflow_SparseRLOFOpticalFlow_getRLOFOpticalFlowParameter(
    cv::optflow::SparseRLOFOpticalFlow *obj, cv::Ptr<cv::optflow::RLOFOpticalFlowParameter> **returnValue)
{
    return cvTry([&] { *returnValue = clone(obj->getRLOFOpticalFlowParameter()); });
}

CVAPI(ExceptionStatus) optflow_SparseRLOFOpticalFlow_setRLOFOpticalFlowParameter(
    cv::optflow::SparseRLOFOpticalFlow *obj, cv::Ptr<cv::optflow::RLOFOpticalFlowParameter> *val)
{
    return cvTry([&] {
        obj->setRLOFOpticalFlowParameter(val ? *val : cv::Ptr<cv::optflow::RLOFOpticalFlowParameter>());
    });
}

CVAPI(ExceptionStatus) optflow_SparseRLOFOpticalFlow_getForwardBackward(cv::optflow::SparseRLOFOpticalFlow *obj, float *returnValue) { return cvTry([&] { *returnValue = obj->getForwardBackward(); }); }
CVAPI(ExceptionStatus) optflow_SparseRLOFOpticalFlow_setForwardBackward(cv::optflow::SparseRLOFOpticalFlow *obj, float value) { return cvTry([&] { obj->setForwardBackward(value); }); }

CVAPI(ExceptionStatus) optflow_createOptFlow_SparseRLOF(cv::Ptr<cv::SparseOpticalFlow> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::optflow::createOptFlow_SparseRLOF());
    });
}

#pragma endregion

#pragma region calcOpticalFlowDenseRLOF / calcOpticalFlowSparseRLOF free functions

CVAPI(ExceptionStatus) optflow_calcOpticalFlowDenseRLOF(
    const interop::InputArrayProxy* I0,
    const interop::InputArrayProxy* I1,
    const interop::InputOutputArrayProxy* flow,
    cv::Ptr<cv::optflow::RLOFOpticalFlowParameter> *rlofParam,
    float forwardBackwardThreshold,
    interop::Size gridStep,
    int interpType,
    int epicK, float epicSigma, float epicLambda,
    int ricSPSize, int ricSLICType,
    int usePostProc, float fgsLambda, float fgsSigma,
    int useVariationalRefinement)
{
    return cvTry([&] {
        const cv::Ptr<cv::optflow::RLOFOpticalFlowParameter> param =
            rlofParam ? *rlofParam : cv::Ptr<cv::optflow::RLOFOpticalFlowParameter>();
        cv::optflow::calcOpticalFlowDenseRLOF(
            InProxy(*I0), InProxy(*I1), IoProxy(*flow),
            param, forwardBackwardThreshold, cpp(gridStep),
            static_cast<cv::optflow::InterpolationType>(interpType),
            epicK, epicSigma, epicLambda, ricSPSize, ricSLICType,
            usePostProc != 0, fgsLambda, fgsSigma, useVariationalRefinement != 0);
    });
}

CVAPI(ExceptionStatus) optflow_calcOpticalFlowSparseRLOF(
    const interop::InputArrayProxy* prevImg,
    const interop::InputArrayProxy* nextImg,
    const interop::InputArrayProxy* prevPts,
    const interop::InputOutputArrayProxy* nextPts,
    const interop::OutputArrayProxy* status,
    const interop::OutputArrayProxy* err,
    cv::Ptr<cv::optflow::RLOFOpticalFlowParameter> *rlofParam,
    float forwardBackwardThreshold)
{
    return cvTry([&] {
        const cv::Ptr<cv::optflow::RLOFOpticalFlowParameter> param =
            rlofParam ? *rlofParam : cv::Ptr<cv::optflow::RLOFOpticalFlowParameter>();
        cv::optflow::calcOpticalFlowSparseRLOF(
            InProxy(*prevImg), InProxy(*nextImg), InProxy(*prevPts), IoProxy(*nextPts),
            OutProxy(*status), OutProxy(*err), param, forwardBackwardThreshold);
    });
}

#pragma endregion

#endif // NO_CONTRIB
