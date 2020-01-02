#ifndef _CPP_IMGPROC_GENERALIZEDHOUGH_H_
#define _CPP_IMGPROC_GENERALIZEDHOUGH_H_

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// GeneralizedHough

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setTemplate1(
    cv::GeneralizedHough *obj, cv::_InputArray *templ, MyCvPoint templCenter)
{
    BEGIN_WRAP
    obj->setTemplate(*templ, cpp(templCenter));
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setTemplate2(
    cv::GeneralizedHough *obj, cv::_InputArray *edges, cv::_InputArray *dx, cv::_InputArray *dy, MyCvPoint templCenter)
{
    BEGIN_WRAP
    obj->setTemplate(*edges, *dx, *dy, cpp(templCenter));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_detect1(
    cv::GeneralizedHough *obj, cv::_InputArray *image, cv::_OutputArray *positions, cv::_OutputArray *votes)
{
    BEGIN_WRAP
    obj->detect(*image, *positions, entity(votes));
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_detect2(
    cv::GeneralizedHough *obj, cv::_InputArray *edges, cv::_InputArray *dx, cv::_InputArray *dy, cv::_OutputArray *positions, cv::_OutputArray *votes)
{
    BEGIN_WRAP
    obj->detect(*edges, *dx, *dy, *positions, entity(votes));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setCannyLowThresh(cv::GeneralizedHough *obj, int val)
{
    BEGIN_WRAP
    obj->setCannyLowThresh(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_getCannyLowThresh(cv::GeneralizedHough *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getCannyLowThresh();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setCannyHighThresh(cv::GeneralizedHough *obj, int val)
{
    BEGIN_WRAP
    obj->setCannyHighThresh(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_getCannyHighThresh(cv::GeneralizedHough *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getCannyHighThresh();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setMinDist(cv::GeneralizedHough *obj, double val)
{
    BEGIN_WRAP
    obj->setMinDist(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_getMinDist(cv::GeneralizedHough *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMinDist();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setDp(cv::GeneralizedHough *obj, double val)
{
    BEGIN_WRAP
    obj->setDp(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_getDp(cv::GeneralizedHough *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getDp();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setMaxBufferSize(cv::GeneralizedHough *obj, int val)
{
    BEGIN_WRAP
    obj->setMaxBufferSize(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_getMaxBufferSize(cv::GeneralizedHough *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMaxBufferSize();
    END_WRAP
}


// GeneralizedHoughBallard

CVAPI(ExceptionStatus) imgproc_createGeneralizedHoughBallard(cv::Ptr<cv::GeneralizedHoughBallard> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::createGeneralizedHoughBallard();
    *returnValue = new cv::Ptr<cv::GeneralizedHoughBallard>(ptr);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_Ptr_GeneralizedHoughBallard_get(
    cv::Ptr<cv::GeneralizedHoughBallard> *obj, cv::GeneralizedHoughBallard **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_Ptr_GeneralizedHoughBallard_delete(cv::Ptr<cv::GeneralizedHoughBallard> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughBallard_setLevels(cv::GeneralizedHoughBallard *obj, int val)
{
    BEGIN_WRAP
    obj->setLevels(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughBallard_getLevels(cv::GeneralizedHoughBallard *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getLevels();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughBallard_setVotesThreshold(cv::GeneralizedHoughBallard *obj, int val)
{
    BEGIN_WRAP
    obj->setVotesThreshold(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughBallard_getVotesThreshold(cv::GeneralizedHoughBallard *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getVotesThreshold();
    END_WRAP
}


// GeneralizedHoughGuil

CVAPI(ExceptionStatus) imgproc_createGeneralizedHoughGuil(cv::Ptr<cv::GeneralizedHoughGuil> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::createGeneralizedHoughGuil();
    *returnValue = new cv::Ptr<cv::GeneralizedHoughGuil>(ptr);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_Ptr_GeneralizedHoughGuil_get(
    cv::Ptr<cv::GeneralizedHoughGuil> *obj, cv::GeneralizedHoughGuil **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_Ptr_GeneralizedHoughGuil_delete(cv::Ptr<cv::GeneralizedHoughGuil> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}


CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setXi(cv::GeneralizedHoughGuil *obj, double val)
{
    BEGIN_WRAP
    obj->setXi(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getXi(cv::GeneralizedHoughGuil *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getXi();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setLevels(cv::GeneralizedHoughGuil *obj, int val)
{
    BEGIN_WRAP
    obj->setLevels(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getLevels(cv::GeneralizedHoughGuil *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getLevels();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setAngleEpsilon(cv::GeneralizedHoughGuil *obj, double val)
{
    BEGIN_WRAP
    obj->setAngleEpsilon(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getAngleEpsilon(cv::GeneralizedHoughGuil *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getAngleEpsilon();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setMinAngle(cv::GeneralizedHoughGuil *obj, double val)
{
    BEGIN_WRAP
    obj->setMinAngle(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getMinAngle(cv::GeneralizedHoughGuil *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMinAngle();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setMaxAngle(cv::GeneralizedHoughGuil *obj, double val)
{
    BEGIN_WRAP
    obj->setMaxAngle(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getMaxAngle(cv::GeneralizedHoughGuil *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMaxAngle();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setAngleStep(cv::GeneralizedHoughGuil *obj, double val)
{
    BEGIN_WRAP
    obj->setAngleStep(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getAngleStep(cv::GeneralizedHoughGuil *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getAngleStep();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setAngleThresh(cv::GeneralizedHoughGuil *obj, int val)
{
    BEGIN_WRAP
    obj->setAngleThresh(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getAngleThresh(cv::GeneralizedHoughGuil *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getAngleThresh();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setMinScale(cv::GeneralizedHoughGuil *obj, double val)
{
    BEGIN_WRAP
    obj->setMinScale(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getMinScale(cv::GeneralizedHoughGuil *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMinScale();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setMaxScale(cv::GeneralizedHoughGuil *obj, double val)
{
    BEGIN_WRAP
    obj->setMaxScale(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getMaxScale(cv::GeneralizedHoughGuil *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMaxScale();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setScaleStep(cv::GeneralizedHoughGuil *obj, double val)
{
    BEGIN_WRAP
    obj->setScaleStep(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getScaleStep(cv::GeneralizedHoughGuil *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getScaleStep();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setScaleThresh(cv::GeneralizedHoughGuil *obj, int val)
{
    BEGIN_WRAP
    obj->setScaleThresh(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getScaleThresh(cv::GeneralizedHoughGuil *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getScaleThresh();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setPosThresh(cv::GeneralizedHoughGuil *obj, int val)
{
    BEGIN_WRAP
    obj->setPosThresh(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getPosThresh(cv::GeneralizedHoughGuil *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getPosThresh();
    END_WRAP
}

#endif