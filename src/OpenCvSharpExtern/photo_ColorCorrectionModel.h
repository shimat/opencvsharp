#pragma once

#ifndef NO_PHOTO

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) photo_ccm_gammaCorrection(
    const interop::InputArrayProxy* src, const interop::OutputArrayProxy* dst, double gamma)
{
    return cvTry([&] {
        cv::ccm::gammaCorrection(InProxy(*src), OutProxy(*dst), gamma);
    });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_delete(cv::ccm::ColorCorrectionModel* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_new1(cv::ccm::ColorCorrectionModel** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::ccm::ColorCorrectionModel();
    });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_new2(
    const interop::InputArrayProxy* src, int constColor, cv::ccm::ColorCorrectionModel** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::ccm::ColorCorrectionModel(InProxy(*src), constColor);
    });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_new3(
    const interop::InputArrayProxy* src, const interop::InputArrayProxy* colors, int refColorSpace,
    cv::ccm::ColorCorrectionModel** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::ccm::ColorCorrectionModel(
            InProxy(*src), InProxy(*colors), static_cast<cv::ccm::ColorSpace>(refColorSpace));
    });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_new4(
    const interop::InputArrayProxy* src, const interop::InputArrayProxy* colors, int refColorSpace,
    const interop::InputArrayProxy* coloredPatchesMask, cv::ccm::ColorCorrectionModel** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::ccm::ColorCorrectionModel(
            InProxy(*src), InProxy(*colors), static_cast<cv::ccm::ColorSpace>(refColorSpace), InProxy(*coloredPatchesMask));
    });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_setColorSpace(cv::ccm::ColorCorrectionModel* obj, int cs)
{
    return cvTry([&] { obj->setColorSpace(static_cast<cv::ccm::ColorSpace>(cs)); });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_setCcmType(cv::ccm::ColorCorrectionModel* obj, int ccmType)
{
    return cvTry([&] { obj->setCcmType(static_cast<cv::ccm::CcmType>(ccmType)); });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_setDistance(cv::ccm::ColorCorrectionModel* obj, int distance)
{
    return cvTry([&] { obj->setDistance(static_cast<cv::ccm::DistanceType>(distance)); });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_setLinearization(cv::ccm::ColorCorrectionModel* obj, int linearizationType)
{
    return cvTry([&] { obj->setLinearization(static_cast<cv::ccm::LinearizationType>(linearizationType)); });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_setLinearizationGamma(cv::ccm::ColorCorrectionModel* obj, double gamma)
{
    return cvTry([&] { obj->setLinearizationGamma(gamma); });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_setLinearizationDegree(cv::ccm::ColorCorrectionModel* obj, int deg)
{
    return cvTry([&] { obj->setLinearizationDegree(deg); });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_setSaturatedThreshold(cv::ccm::ColorCorrectionModel* obj, double lower, double upper)
{
    return cvTry([&] { obj->setSaturatedThreshold(lower, upper); });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_setWeightsList(cv::ccm::ColorCorrectionModel* obj, cv::Mat* weightsList)
{
    return cvTry([&] { obj->setWeightsList(*weightsList); });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_setWeightCoeff(cv::ccm::ColorCorrectionModel* obj, double weightsCoeff)
{
    return cvTry([&] { obj->setWeightCoeff(weightsCoeff); });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_setInitialMethod(cv::ccm::ColorCorrectionModel* obj, int initialMethodType)
{
    return cvTry([&] { obj->setInitialMethod(static_cast<cv::ccm::InitialMethodType>(initialMethodType)); });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_setMaxCount(cv::ccm::ColorCorrectionModel* obj, int maxCount)
{
    return cvTry([&] { obj->setMaxCount(maxCount); });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_setEpsilon(cv::ccm::ColorCorrectionModel* obj, double epsilon)
{
    return cvTry([&] { obj->setEpsilon(epsilon); });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_setRGB(cv::ccm::ColorCorrectionModel* obj, int rgb)
{
    return cvTry([&] { obj->setRGB(rgb != 0); });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_compute(cv::ccm::ColorCorrectionModel* obj, cv::Mat** returnValue)
{
    return cvTry([&] { *returnValue = new cv::Mat(obj->compute()); });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_getColorCorrectionMatrix(cv::ccm::ColorCorrectionModel* obj, cv::Mat** returnValue)
{
    return cvTry([&] { *returnValue = new cv::Mat(obj->getColorCorrectionMatrix()); });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_getLoss(cv::ccm::ColorCorrectionModel* obj, double* returnValue)
{
    return cvTry([&] { *returnValue = obj->getLoss(); });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_getSrcLinearRGB(cv::ccm::ColorCorrectionModel* obj, cv::Mat** returnValue)
{
    return cvTry([&] { *returnValue = new cv::Mat(obj->getSrcLinearRGB()); });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_getRefLinearRGB(cv::ccm::ColorCorrectionModel* obj, cv::Mat** returnValue)
{
    return cvTry([&] { *returnValue = new cv::Mat(obj->getRefLinearRGB()); });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_getMask(cv::ccm::ColorCorrectionModel* obj, cv::Mat** returnValue)
{
    return cvTry([&] { *returnValue = new cv::Mat(obj->getMask()); });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_getWeights(cv::ccm::ColorCorrectionModel* obj, cv::Mat** returnValue)
{
    return cvTry([&] { *returnValue = new cv::Mat(obj->getWeights()); });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_correctImage(
    cv::ccm::ColorCorrectionModel* obj, const interop::InputArrayProxy* src, const interop::OutputArrayProxy* dst, int islinear)
{
    return cvTry([&] {
        obj->correctImage(InProxy(*src), OutProxy(*dst), islinear != 0);
    });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_write(cv::ccm::ColorCorrectionModel* obj, cv::FileStorage* fs)
{
    return cvTry([&] {
        obj->write(*fs);
    });
}

CVAPI(ExceptionStatus) photo_ccm_ColorCorrectionModel_read(cv::ccm::ColorCorrectionModel* obj, cv::FileNode* node)
{
    return cvTry([&] {
        obj->read(*node);
    });
}

#endif // NO_PHOTO
