#pragma once

#if !defined(NO_CONTRIB) && defined(HAVE_OPENCV_BIOINSPIRED)
#include "include_opencv.h"
#include <opencv2/bioinspired.hpp>

CVAPI(ExceptionStatus) bioinspired_Ptr_RetinaFastToneMapping_delete(
    cv::Ptr<cv::bioinspired::RetinaFastToneMapping>* obj)
{
    return cvTry([&] { delete obj; });
}

CVAPI(ExceptionStatus) bioinspired_Ptr_RetinaFastToneMapping_get(
    cv::Ptr<cv::bioinspired::RetinaFastToneMapping>* ptr,
    cv::bioinspired::RetinaFastToneMapping** returnValue)
{
    return cvTry([&] { *returnValue = ptr->get(); });
}

CVAPI(ExceptionStatus) bioinspired_RetinaFastToneMapping_create(
    int width, int height, cv::Ptr<cv::bioinspired::RetinaFastToneMapping>** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Ptr<cv::bioinspired::RetinaFastToneMapping>(
            cv::bioinspired::RetinaFastToneMapping::create(cv::Size(width, height)));
    });
}

CVAPI(ExceptionStatus) bioinspired_RetinaFastToneMapping_setup(
    cv::bioinspired::RetinaFastToneMapping* obj, float photoreceptorsRadius,
    float ganglionCellsRadius, float meanLuminanceModulator)
{
    return cvTry([&] { obj->setup(photoreceptorsRadius, ganglionCellsRadius, meanLuminanceModulator); });
}

CVAPI(ExceptionStatus) bioinspired_RetinaFastToneMapping_apply(
    cv::bioinspired::RetinaFastToneMapping* obj,
    const interop::InputArrayProxy* input, const interop::OutputArrayProxy* output)
{
    return cvTry([&] { obj->applyFastToneMapping(InProxy(*input), OutProxy(*output)); });
}

CVAPI(ExceptionStatus) bioinspired_Ptr_Retina_delete(cv::Ptr<cv::bioinspired::Retina>* obj)
{
    return cvTry([&] { delete obj; });
}

CVAPI(ExceptionStatus) bioinspired_Ptr_Retina_get(
    cv::Ptr<cv::bioinspired::Retina>* ptr, cv::bioinspired::Retina** returnValue)
{
    return cvTry([&] { *returnValue = ptr->get(); });
}

CVAPI(ExceptionStatus) bioinspired_Retina_create(
    int width, int height, cv::Ptr<cv::bioinspired::Retina>** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Ptr<cv::bioinspired::Retina>(
            cv::bioinspired::Retina::create(cv::Size(width, height)));
    });
}

CVAPI(ExceptionStatus) bioinspired_Retina_run(
    cv::bioinspired::Retina* obj, const interop::InputArrayProxy* input)
{
    return cvTry([&] { obj->run(InProxy(*input)); });
}

CVAPI(ExceptionStatus) bioinspired_Retina_getParvo(
    cv::bioinspired::Retina* obj, const interop::OutputArrayProxy* output)
{
    return cvTry([&] { obj->getParvo(OutProxy(*output)); });
}

CVAPI(ExceptionStatus) bioinspired_Retina_getMagno(
    cv::bioinspired::Retina* obj, const interop::OutputArrayProxy* output)
{
    return cvTry([&] { obj->getMagno(OutProxy(*output)); });
}

CVAPI(ExceptionStatus) bioinspired_Retina_clearBuffers(cv::bioinspired::Retina* obj)
{
    return cvTry([&] { obj->clearBuffers(); });
}

CVAPI(ExceptionStatus) bioinspired_Ptr_TransientAreasSegmentation_delete(
    cv::Ptr<cv::bioinspired::TransientAreasSegmentationModule>* obj)
{
    return cvTry([&] { delete obj; });
}

CVAPI(ExceptionStatus) bioinspired_Ptr_TransientAreasSegmentation_get(
    cv::Ptr<cv::bioinspired::TransientAreasSegmentationModule>* ptr,
    cv::bioinspired::TransientAreasSegmentationModule** returnValue)
{
    return cvTry([&] { *returnValue = ptr->get(); });
}

CVAPI(ExceptionStatus) bioinspired_TransientAreasSegmentation_create(
    int width, int height,
    cv::Ptr<cv::bioinspired::TransientAreasSegmentationModule>** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Ptr<cv::bioinspired::TransientAreasSegmentationModule>(
            cv::bioinspired::TransientAreasSegmentationModule::create(cv::Size(width, height)));
    });
}

CVAPI(ExceptionStatus) bioinspired_TransientAreasSegmentation_run(
    cv::bioinspired::TransientAreasSegmentationModule* obj,
    const interop::InputArrayProxy* input, int channelIndex)
{
    return cvTry([&] { obj->run(InProxy(*input), channelIndex); });
}

CVAPI(ExceptionStatus) bioinspired_TransientAreasSegmentation_getPicture(
    cv::bioinspired::TransientAreasSegmentationModule* obj,
    const interop::OutputArrayProxy* output)
{
    return cvTry([&] { obj->getSegmentationPicture(OutProxy(*output)); });
}

CVAPI(ExceptionStatus) bioinspired_TransientAreasSegmentation_clearBuffers(
    cv::bioinspired::TransientAreasSegmentationModule* obj)
{
    return cvTry([&] { obj->clearAllBuffers(); });
}
#endif // !NO_CONTRIB && HAVE_OPENCV_BIOINSPIRED
