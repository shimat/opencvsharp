#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// GeneralizedHough

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setTemplate1(
    cv::GeneralizedHough *obj,
    const interop::InputArrayProxy* templ,
    interop::Point templCenter)
{
    return cvTry([&] {
    obj->setTemplate(InProxy(*templ), cpp(templCenter));
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setTemplate2(
    cv::GeneralizedHough *obj,
    const interop::InputArrayProxy* edges,
    const interop::InputArrayProxy* dx,
    const interop::InputArrayProxy* dy,
    interop::Point templCenter)
{
    return cvTry([&] {
    obj->setTemplate(InProxy(*edges), InProxy(*dx), InProxy(*dy), cpp(templCenter));
    });
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_detect1(
    cv::GeneralizedHough *obj,
    const interop::InputArrayProxy* image,
    const interop::OutputArrayProxy* positions,
    const interop::OutputArrayProxy* votes)
{
    return cvTry([&] {
    obj->detect(InProxy(*image), OutProxy(*positions), OutProxy(*votes));
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_detect2(
    cv::GeneralizedHough *obj,
    const interop::InputArrayProxy* edges,
    const interop::InputArrayProxy* dx,
    const interop::InputArrayProxy* dy,
    const interop::OutputArrayProxy* positions,
    const interop::OutputArrayProxy* votes)
{
    return cvTry([&] {
    obj->detect(InProxy(*edges), InProxy(*dx), InProxy(*dy), OutProxy(*positions), OutProxy(*votes));
    });
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setCannyLowThresh(cv::GeneralizedHough *obj, int val)
{
    return cvTry([&] {
    obj->setCannyLowThresh(val);
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_getCannyLowThresh(cv::GeneralizedHough *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getCannyLowThresh();
    });
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setCannyHighThresh(cv::GeneralizedHough *obj, int val)
{
    return cvTry([&] {
    obj->setCannyHighThresh(val);
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_getCannyHighThresh(cv::GeneralizedHough *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getCannyHighThresh();
    });
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setMinDist(cv::GeneralizedHough *obj, double val)
{
    return cvTry([&] {
    obj->setMinDist(val);
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_getMinDist(cv::GeneralizedHough *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMinDist();
    });
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setDp(cv::GeneralizedHough *obj, double val)
{
    return cvTry([&] {
    obj->setDp(val);
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_getDp(cv::GeneralizedHough *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getDp();
    });
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setMaxBufferSize(cv::GeneralizedHough *obj, int val)
{
    return cvTry([&] {
    obj->setMaxBufferSize(val);
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_getMaxBufferSize(cv::GeneralizedHough *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMaxBufferSize();
    });
}


// GeneralizedHoughBallard

CVAPI(ExceptionStatus) imgproc_createGeneralizedHoughBallard(cv::Ptr<cv::GeneralizedHoughBallard> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::createGeneralizedHoughBallard();
    *returnValue = new cv::Ptr<cv::GeneralizedHoughBallard>(ptr);
    });
}
CVAPI(ExceptionStatus) imgproc_Ptr_GeneralizedHoughBallard_get(cv::Ptr<cv::GeneralizedHoughBallard> *obj, cv::GeneralizedHoughBallard **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}
CVAPI(ExceptionStatus) imgproc_Ptr_GeneralizedHoughBallard_delete(cv::Ptr<cv::GeneralizedHoughBallard> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughBallard_setLevels(cv::GeneralizedHoughBallard *obj, int val)
{
    return cvTry([&] {
    obj->setLevels(val);
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughBallard_getLevels(cv::GeneralizedHoughBallard *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getLevels();
    });
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughBallard_setVotesThreshold(cv::GeneralizedHoughBallard *obj, int val)
{
    return cvTry([&] {
    obj->setVotesThreshold(val);
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughBallard_getVotesThreshold(cv::GeneralizedHoughBallard *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getVotesThreshold();
    });
}


// GeneralizedHoughGuil

CVAPI(ExceptionStatus) imgproc_createGeneralizedHoughGuil(cv::Ptr<cv::GeneralizedHoughGuil> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::createGeneralizedHoughGuil();
    *returnValue = new cv::Ptr<cv::GeneralizedHoughGuil>(ptr);
    });
}
CVAPI(ExceptionStatus) imgproc_Ptr_GeneralizedHoughGuil_get(cv::Ptr<cv::GeneralizedHoughGuil> *obj, cv::GeneralizedHoughGuil **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}
CVAPI(ExceptionStatus) imgproc_Ptr_GeneralizedHoughGuil_delete(cv::Ptr<cv::GeneralizedHoughGuil> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}


CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setXi(cv::GeneralizedHoughGuil *obj, double val)
{
    return cvTry([&] {
    obj->setXi(val);
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getXi(cv::GeneralizedHoughGuil *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getXi();
    });
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setLevels(cv::GeneralizedHoughGuil *obj, int val)
{
    return cvTry([&] {
    obj->setLevels(val);
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getLevels(cv::GeneralizedHoughGuil *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getLevels();
    });
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setAngleEpsilon(cv::GeneralizedHoughGuil *obj, double val)
{
    return cvTry([&] {
    obj->setAngleEpsilon(val);
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getAngleEpsilon(cv::GeneralizedHoughGuil *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getAngleEpsilon();
    });
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setMinAngle(cv::GeneralizedHoughGuil *obj, double val)
{
    return cvTry([&] {
    obj->setMinAngle(val);
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getMinAngle(cv::GeneralizedHoughGuil *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMinAngle();
    });
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setMaxAngle(cv::GeneralizedHoughGuil *obj, double val)
{
    return cvTry([&] {
    obj->setMaxAngle(val);
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getMaxAngle(cv::GeneralizedHoughGuil *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMaxAngle();
    });
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setAngleStep(cv::GeneralizedHoughGuil *obj, double val)
{
    return cvTry([&] {
    obj->setAngleStep(val);
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getAngleStep(cv::GeneralizedHoughGuil *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getAngleStep();
    });
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setAngleThresh(cv::GeneralizedHoughGuil *obj, int val)
{
    return cvTry([&] {
    obj->setAngleThresh(val);
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getAngleThresh(cv::GeneralizedHoughGuil *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getAngleThresh();
    });
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setMinScale(cv::GeneralizedHoughGuil *obj, double val)
{
    return cvTry([&] {
    obj->setMinScale(val);
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getMinScale(cv::GeneralizedHoughGuil *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMinScale();
    });
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setMaxScale(cv::GeneralizedHoughGuil *obj, double val)
{
    return cvTry([&] {
    obj->setMaxScale(val);
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getMaxScale(cv::GeneralizedHoughGuil *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMaxScale();
    });
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setScaleStep(cv::GeneralizedHoughGuil *obj, double val)
{
    return cvTry([&] {
    obj->setScaleStep(val);
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getScaleStep(cv::GeneralizedHoughGuil *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getScaleStep();
    });
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setScaleThresh(cv::GeneralizedHoughGuil *obj, int val)
{
    return cvTry([&] {
    obj->setScaleThresh(val);
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getScaleThresh(cv::GeneralizedHoughGuil *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getScaleThresh();
    });
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setPosThresh(cv::GeneralizedHoughGuil *obj, int val)
{
    return cvTry([&] {
    obj->setPosThresh(val);
    });
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getPosThresh(cv::GeneralizedHoughGuil *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getPosThresh();
    });
}
