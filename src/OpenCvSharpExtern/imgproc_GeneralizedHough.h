#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// GeneralizedHough

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setTemplate1(
    cv::Ptr<cv::GeneralizedHough>* obj, cv::_InputArray *templ, MyCvPoint templCenter)
{
    BEGIN_WRAP
    (*obj)->setTemplate(*templ, cpp(templCenter));
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setTemplate2(
    cv::Ptr<cv::GeneralizedHough>* obj, cv::_InputArray *edges, cv::_InputArray *dx, cv::_InputArray *dy, MyCvPoint templCenter)
{
    BEGIN_WRAP
    (*obj)->setTemplate(*edges, *dx, *dy, cpp(templCenter));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_detect1(
    cv::Ptr<cv::GeneralizedHough>* obj, cv::_InputArray *image, cv::_OutputArray *positions, cv::_OutputArray *votes)
{
    BEGIN_WRAP
    (*obj)->detect(*image, *positions, entity(votes));
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_detect2(
    cv::Ptr<cv::GeneralizedHough>* obj, cv::_InputArray *edges, cv::_InputArray *dx, cv::_InputArray *dy, cv::_OutputArray *positions, cv::_OutputArray *votes)
{
    BEGIN_WRAP
    (*obj)->detect(*edges, *dx, *dy, *positions, entity(votes));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setCannyLowThresh(cv::Ptr<cv::GeneralizedHough>* obj, int val)
{
    BEGIN_WRAP
    (*obj)->setCannyLowThresh(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_getCannyLowThresh(cv::Ptr<cv::GeneralizedHough>* obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*obj)->getCannyLowThresh();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setCannyHighThresh(cv::Ptr<cv::GeneralizedHough>* obj, int val)
{
    BEGIN_WRAP
    (*obj)->setCannyHighThresh(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_getCannyHighThresh(cv::Ptr<cv::GeneralizedHough>* obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*obj)->getCannyHighThresh();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setMinDist(cv::Ptr<cv::GeneralizedHough>* obj, double val)
{
    BEGIN_WRAP
    (*obj)->setMinDist(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_getMinDist(cv::Ptr<cv::GeneralizedHough>* obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*obj)->getMinDist();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setDp(cv::Ptr<cv::GeneralizedHough>* obj, double val)
{
    BEGIN_WRAP
    (*obj)->setDp(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_getDp(cv::Ptr<cv::GeneralizedHough>* obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*obj)->getDp();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHough_setMaxBufferSize(cv::Ptr<cv::GeneralizedHough>* obj, int val)
{
    BEGIN_WRAP
    (*obj)->setMaxBufferSize(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHough_getMaxBufferSize(cv::Ptr<cv::GeneralizedHough>* obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*obj)->getMaxBufferSize();
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

CVAPI(ExceptionStatus) imgproc_Ptr_GeneralizedHoughBallard_delete(cv::Ptr<cv::GeneralizedHoughBallard> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughBallard_setLevels(cv::Ptr<cv::GeneralizedHoughBallard>* obj, int val)
{
    BEGIN_WRAP
    (*obj)->setLevels(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughBallard_getLevels(cv::Ptr<cv::GeneralizedHoughBallard>* obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*obj)->getLevels();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughBallard_setVotesThreshold(cv::Ptr<cv::GeneralizedHoughBallard>* obj, int val)
{
    BEGIN_WRAP
    (*obj)->setVotesThreshold(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughBallard_getVotesThreshold(cv::Ptr<cv::GeneralizedHoughBallard>* obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*obj)->getVotesThreshold();
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

CVAPI(ExceptionStatus) imgproc_Ptr_GeneralizedHoughGuil_delete(cv::Ptr<cv::GeneralizedHoughGuil> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}


CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setXi(cv::Ptr<cv::GeneralizedHoughGuil>* obj, double val)
{
    BEGIN_WRAP
    (*obj)->setXi(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getXi(cv::Ptr<cv::GeneralizedHoughGuil>* obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*obj)->getXi();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setLevels(cv::Ptr<cv::GeneralizedHoughGuil>* obj, int val)
{
    BEGIN_WRAP
    (*obj)->setLevels(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getLevels(cv::Ptr<cv::GeneralizedHoughGuil>* obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*obj)->getLevels();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setAngleEpsilon(cv::Ptr<cv::GeneralizedHoughGuil>* obj, double val)
{
    BEGIN_WRAP
    (*obj)->setAngleEpsilon(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getAngleEpsilon(cv::Ptr<cv::GeneralizedHoughGuil>* obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*obj)->getAngleEpsilon();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setMinAngle(cv::Ptr<cv::GeneralizedHoughGuil>* obj, double val)
{
    BEGIN_WRAP
    (*obj)->setMinAngle(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getMinAngle(cv::Ptr<cv::GeneralizedHoughGuil>* obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*obj)->getMinAngle();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setMaxAngle(cv::Ptr<cv::GeneralizedHoughGuil>* obj, double val)
{
    BEGIN_WRAP
    (*obj)->setMaxAngle(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getMaxAngle(cv::Ptr<cv::GeneralizedHoughGuil>* obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*obj)->getMaxAngle();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setAngleStep(cv::Ptr<cv::GeneralizedHoughGuil>* obj, double val)
{
    BEGIN_WRAP
    (*obj)->setAngleStep(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getAngleStep(cv::Ptr<cv::GeneralizedHoughGuil>* obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*obj)->getAngleStep();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setAngleThresh(cv::Ptr<cv::GeneralizedHoughGuil>* obj, int val)
{
    BEGIN_WRAP
    (*obj)->setAngleThresh(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getAngleThresh(cv::Ptr<cv::GeneralizedHoughGuil>* obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*obj)->getAngleThresh();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setMinScale(cv::Ptr<cv::GeneralizedHoughGuil>* obj, double val)
{
    BEGIN_WRAP
    (*obj)->setMinScale(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getMinScale(cv::Ptr<cv::GeneralizedHoughGuil>* obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*obj)->getMinScale();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setMaxScale(cv::Ptr<cv::GeneralizedHoughGuil>* obj, double val)
{
    BEGIN_WRAP
    (*obj)->setMaxScale(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getMaxScale(cv::Ptr<cv::GeneralizedHoughGuil>* obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*obj)->getMaxScale();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setScaleStep(cv::Ptr<cv::GeneralizedHoughGuil>* obj, double val)
{
    BEGIN_WRAP
    (*obj)->setScaleStep(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getScaleStep(cv::Ptr<cv::GeneralizedHoughGuil>* obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*obj)->getScaleStep();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setScaleThresh(cv::Ptr<cv::GeneralizedHoughGuil>* obj, int val)
{
    BEGIN_WRAP
    (*obj)->setScaleThresh(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getScaleThresh(cv::Ptr<cv::GeneralizedHoughGuil>* obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*obj)->getScaleThresh();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_setPosThresh(cv::Ptr<cv::GeneralizedHoughGuil>* obj, int val)
{
    BEGIN_WRAP
    (*obj)->setPosThresh(val);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_GeneralizedHoughGuil_getPosThresh(cv::Ptr<cv::GeneralizedHoughGuil>* obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*obj)->getPosThresh();
    END_WRAP
}
