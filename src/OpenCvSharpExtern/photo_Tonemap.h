#pragma once

#ifndef NO_PHOTO

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region Tonemap

CVAPI(ExceptionStatus) photo_Tonemap_process(cv::Tonemap *obj, cv::_InputArray *src, cv::_OutputArray *dst)
{
    return cvTry([&] {
    obj->process(*src, *dst);
    });
}

CVAPI(ExceptionStatus) photo_Tonemap_getGamma(cv::Tonemap *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getGamma();
    });
}
CVAPI(ExceptionStatus) photo_Tonemap_setGamma(cv::Tonemap *obj, float gamma)
{
    return cvTry([&] {
    obj->setGamma(gamma);
    });
}

CVAPI(ExceptionStatus) photo_createTonemap(float gamma, cv::Ptr<cv::Tonemap> **returnValue)
{
    return cvTry([&] {
    const auto p = cv::createTonemap(gamma);
    *returnValue = clone(p);
    });  
}

CVAPI(ExceptionStatus) photo_Ptr_Tonemap_delete(cv::Ptr<cv::Tonemap> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) photo_Ptr_Tonemap_get(cv::Ptr<cv::Tonemap> *ptr, cv::Tonemap **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

#pragma endregion

#pragma region TonemapDrago

CVAPI(ExceptionStatus) photo_TonemapDrago_getSaturation(cv::TonemapDrago *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getSaturation();
    });
}
CVAPI(ExceptionStatus) photo_TonemapDrago_setSaturation(cv::TonemapDrago *obj, float saturation)
{
    return cvTry([&] {
    obj->setSaturation(saturation);
    });
}

CVAPI(ExceptionStatus) photo_TonemapDrago_getBias(cv::TonemapDrago *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getBias();
    });
}
CVAPI(ExceptionStatus) photo_TonemapDrago_setBias(cv::TonemapDrago *obj, float bias)
{
    return cvTry([&] {
    obj->setBias(bias);
    });
}

CVAPI(ExceptionStatus) photo_createTonemapDrago(float gamma, float saturation, float bias, cv::Ptr<cv::TonemapDrago> **returnValue)
{
    return cvTry([&] {
    const auto p = cv::createTonemapDrago(gamma, saturation, bias);
    *returnValue = clone(p);
    });  
}

CVAPI(ExceptionStatus) photo_Ptr_TonemapDrago_delete(cv::Ptr<cv::TonemapDrago> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) photo_Ptr_TonemapDrago_get(cv::Ptr<cv::TonemapDrago> *ptr, cv::TonemapDrago **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

#pragma endregion

#pragma region TonemapReinhard

CVAPI(ExceptionStatus) photo_TonemapReinhard_getIntensity(cv::TonemapReinhard *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getIntensity();
    });
}
CVAPI(ExceptionStatus) photo_TonemapReinhard_setIntensity(cv::TonemapReinhard *obj, float intensity)
{
    return cvTry([&] {
    obj->setIntensity(intensity);
    });
}

CVAPI(ExceptionStatus) photo_TonemapReinhard_getLightAdaptation(cv::TonemapReinhard *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getLightAdaptation();
    });
}
CVAPI(ExceptionStatus) photo_TonemapReinhard_setLightAdaptation(cv::TonemapReinhard *obj, float light_adapt)
{
    return cvTry([&] {
    obj->setLightAdaptation(light_adapt);
    });
}

CVAPI(ExceptionStatus) photo_TonemapReinhard_getColorAdaptation(cv::TonemapReinhard *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getColorAdaptation();
    });
}
CVAPI(ExceptionStatus) photo_TonemapReinhard_setColorAdaptation(cv::TonemapReinhard *obj, float color_adapt)
{
    return cvTry([&] {
    obj->setColorAdaptation(color_adapt);
    });
}

CVAPI(ExceptionStatus) photo_createTonemapReinhard(float gamma, float intensity, float light_adapt, float color_adapt, cv::Ptr<cv::TonemapReinhard> **returnValue)
{
    return cvTry([&] {
    const auto p = cv::createTonemapReinhard(gamma, intensity, light_adapt, color_adapt);
    *returnValue = clone(p);
    });  
}

CVAPI(ExceptionStatus) photo_Ptr_TonemapReinhard_delete(cv::Ptr<cv::TonemapReinhard> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) photo_Ptr_TonemapReinhard_get(cv::Ptr<cv::TonemapReinhard> *ptr, cv::TonemapReinhard **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

#pragma endregion

#pragma region TonemapMantiuk

CVAPI(ExceptionStatus) photo_TonemapMantiuk_getScale(cv::TonemapMantiuk *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getScale();
    });
}
CVAPI(ExceptionStatus) photo_TonemapMantiuk_setScale(cv::TonemapMantiuk *obj, float scale)
{
    return cvTry([&] {
    obj->setScale(scale);
    });
}

CVAPI(ExceptionStatus) photo_TonemapMantiuk_getSaturation(cv::TonemapMantiuk *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getSaturation();
    });
}
CVAPI(ExceptionStatus) photo_TonemapMantiuk_setSaturation(cv::TonemapMantiuk *obj, float saturation)
{
    return cvTry([&] {
    obj->setSaturation(saturation);
    });
}

CVAPI(ExceptionStatus) photo_createTonemapMantiuk(float gamma, float scale, float saturation, cv::Ptr<cv::TonemapMantiuk> **returnValue)
{
    return cvTry([&] {
    const auto p = cv::createTonemapMantiuk(gamma, scale, saturation);
    *returnValue = clone(p);
    });  
}

CVAPI(ExceptionStatus) photo_Ptr_TonemapMantiuk_delete(cv::Ptr<cv::TonemapMantiuk> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) photo_Ptr_TonemapMantiuk_get(cv::Ptr<cv::TonemapMantiuk> *ptr, cv::TonemapMantiuk **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

#pragma endregion

#endif // NO_PHOTO
