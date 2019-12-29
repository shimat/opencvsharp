#ifndef _CPP_PHOTO_TONEMAP_H_
#define _CPP_PHOTO_TONEMAP_H_

#include "include_opencv.h"

#pragma region Tonemap

CVAPI(ExceptionStatus) photo_Tonemap_process(cv::Tonemap *obj, cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    obj->process(*src, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_Tonemap_getGamma(cv::Tonemap *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getGamma();
    END_WRAP
}
CVAPI(ExceptionStatus) photo_Tonemap_setGamma(cv::Tonemap *obj, float gamma)
{
    BEGIN_WRAP
    obj->setGamma(gamma);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_createTonemap(float gamma, cv::Ptr<cv::Tonemap> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::createTonemap(gamma);
    *returnValue = clone(p);
    END_WRAP  
}

CVAPI(ExceptionStatus) photo_Ptr_Tonemap_delete(cv::Ptr<cv::Tonemap> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) photo_Ptr_Tonemap_get(cv::Ptr<cv::Tonemap> *ptr, cv::Tonemap **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

#pragma endregion

#pragma region TonemapDrago

CVAPI(ExceptionStatus) photo_TonemapDrago_getSaturation(cv::TonemapDrago *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getSaturation();
    END_WRAP
}
CVAPI(ExceptionStatus) photo_TonemapDrago_setSaturation(cv::TonemapDrago *obj, float saturation)
{
    BEGIN_WRAP
    obj->setSaturation(saturation);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_TonemapDrago_getBias(cv::TonemapDrago *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getBias();
    END_WRAP
}
CVAPI(ExceptionStatus) photo_TonemapDrago_setBias(cv::TonemapDrago *obj, float bias)
{
    BEGIN_WRAP
    obj->setBias(bias);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_createTonemapDrago(float gamma, float saturation, float bias, cv::Ptr<cv::TonemapDrago> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::createTonemapDrago(gamma, saturation, bias);
    *returnValue = clone(p);
    END_WRAP  
}

CVAPI(ExceptionStatus) photo_Ptr_TonemapDrago_delete(cv::Ptr<cv::TonemapDrago> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) photo_Ptr_TonemapDrago_get(cv::Ptr<cv::TonemapDrago> *ptr, cv::TonemapDrago **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

#pragma endregion

#pragma region TonemapReinhard

CVAPI(ExceptionStatus) photo_TonemapReinhard_getIntensity(cv::TonemapReinhard *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getIntensity();
    END_WRAP
}
CVAPI(ExceptionStatus) photo_TonemapReinhard_setIntensity(cv::TonemapReinhard *obj, float intensity)
{
    BEGIN_WRAP
    obj->setIntensity(intensity);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_TonemapReinhard_getLightAdaptation(cv::TonemapReinhard *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getLightAdaptation();
    END_WRAP
}
CVAPI(ExceptionStatus) photo_TonemapReinhard_setLightAdaptation(cv::TonemapReinhard *obj, float light_adapt)
{
    BEGIN_WRAP
    obj->setLightAdaptation(light_adapt);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_TonemapReinhard_getColorAdaptation(cv::TonemapReinhard *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getColorAdaptation();
    END_WRAP
}
CVAPI(ExceptionStatus) photo_TonemapReinhard_setColorAdaptation(cv::TonemapReinhard *obj, float color_adapt)
{
    BEGIN_WRAP
    obj->setColorAdaptation(color_adapt);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_createTonemapReinhard(float gamma, float intensity, float light_adapt, float color_adapt, cv::Ptr<cv::TonemapReinhard> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::createTonemapReinhard(gamma, intensity, light_adapt, color_adapt);
    *returnValue = clone(p);
    END_WRAP  
}

CVAPI(ExceptionStatus) photo_Ptr_TonemapReinhard_delete(cv::Ptr<cv::TonemapReinhard> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) photo_Ptr_TonemapReinhard_get(cv::Ptr<cv::TonemapReinhard> *ptr, cv::TonemapReinhard **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

#pragma endregion

#pragma region TonemapMantiuk

CVAPI(ExceptionStatus) photo_TonemapMantiuk_getScale(cv::TonemapMantiuk *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getScale();
    END_WRAP
}
CVAPI(ExceptionStatus) photo_TonemapMantiuk_setScale(cv::TonemapMantiuk *obj, float scale)
{
    BEGIN_WRAP
    obj->setScale(scale);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_TonemapMantiuk_getSaturation(cv::TonemapMantiuk *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getSaturation();
    END_WRAP
}
CVAPI(ExceptionStatus) photo_TonemapMantiuk_setSaturation(cv::TonemapMantiuk *obj, float saturation)
{
    BEGIN_WRAP
    obj->setSaturation(saturation);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_createTonemapMantiuk(float gamma, float scale, float saturation, cv::Ptr<cv::TonemapMantiuk> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::createTonemapMantiuk(gamma, scale, saturation);
    *returnValue = clone(p);
    END_WRAP  
}

CVAPI(ExceptionStatus) photo_Ptr_TonemapMantiuk_delete(cv::Ptr<cv::TonemapMantiuk> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) photo_Ptr_TonemapMantiuk_get(cv::Ptr<cv::TonemapMantiuk> *ptr, cv::TonemapMantiuk **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

#pragma endregion

#endif