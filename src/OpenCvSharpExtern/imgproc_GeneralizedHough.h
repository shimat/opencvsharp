#ifndef _CPP_IMGPROC_GENERALIZEDHOUGH_H_
#define _CPP_IMGPROC_GENERALIZEDHOUGH_H_

#include "include_opencv.h"

// GeneralizedHough

CVAPI(void) imgproc_GeneralizedHough_setTemplate1(
    cv::GeneralizedHough *obj, cv::_InputArray *templ, MyCvPoint templCenter)
{
    obj->setTemplate(*templ, cpp(templCenter));
}
CVAPI(void) imgproc_GeneralizedHough_setTemplate2(
    cv::GeneralizedHough *obj, cv::_InputArray *edges, cv::_InputArray *dx, cv::_InputArray *dy, MyCvPoint templCenter)
{
    obj->setTemplate(*edges, *dx, *dy, cpp(templCenter));
}

CVAPI(void) imgproc_GeneralizedHough_detect1(
    cv::GeneralizedHough *obj, cv::_InputArray *image, cv::_OutputArray *positions, cv::_OutputArray *votes)
{
    obj->detect(*image, *positions, entity(votes));
}
CVAPI(void) imgproc_GeneralizedHough_detect2(
    cv::GeneralizedHough *obj, cv::_InputArray *edges, cv::_InputArray *dx, cv::_InputArray *dy, cv::_OutputArray *positions, cv::_OutputArray *votes)
{
    obj->detect(*edges, *dx, *dy, *positions, entity(votes));
}

CVAPI(void) imgproc_GeneralizedHough_setCannyLowThresh(cv::GeneralizedHough *obj, int val)
{
    obj->setCannyLowThresh(val);
}
CVAPI(int) imgproc_GeneralizedHough_getCannyLowThresh(cv::GeneralizedHough *obj)
{
    return obj->getCannyLowThresh();
}

CVAPI(void) imgproc_GeneralizedHough_setCannyHighThresh(cv::GeneralizedHough *obj, int val)
{
    obj->setCannyHighThresh(val);
}
CVAPI(int) imgproc_GeneralizedHough_getCannyHighThresh(cv::GeneralizedHough *obj)
{
    return obj->getCannyHighThresh();
}

CVAPI(void) imgproc_GeneralizedHough_setMinDist(cv::GeneralizedHough *obj, double val)
{
    obj->setMinDist(val);
}
CVAPI(double) imgproc_GeneralizedHough_getMinDist(cv::GeneralizedHough *obj)
{
    return obj->getMinDist();
}

CVAPI(void) imgproc_GeneralizedHough_setDp(cv::GeneralizedHough *obj, double val)
{
    obj->setDp(val);
}
CVAPI(double) imgproc_GeneralizedHough_getDp(cv::GeneralizedHough *obj)
{
    return obj->getDp();
}

CVAPI(void) imgproc_GeneralizedHough_setMaxBufferSize(cv::GeneralizedHough *obj, int val)
{
    obj->setMaxBufferSize(val);
}
CVAPI(int) imgproc_GeneralizedHough_getMaxBufferSize(cv::GeneralizedHough *obj)
{
    return obj->getMaxBufferSize();
}


// GeneralizedHoughBallard

CVAPI(cv::Ptr<cv::GeneralizedHoughBallard>*) imgproc_createGeneralizedHoughBallard()
{
    cv::Ptr<cv::GeneralizedHoughBallard> ptr = cv::createGeneralizedHoughBallard();
    return new cv::Ptr<cv::GeneralizedHoughBallard>(ptr);
}
CVAPI(cv::GeneralizedHoughBallard*) imgproc_Ptr_GeneralizedHoughBallard_get(
    cv::Ptr<cv::GeneralizedHoughBallard> *obj)
{
    return obj->get();
}
CVAPI(void) imgproc_Ptr_GeneralizedHoughBallard_delete(cv::Ptr<cv::GeneralizedHoughBallard> *obj)
{
    delete obj;
}

CVAPI(void) imgproc_GeneralizedHoughBallard_setLevels(cv::GeneralizedHoughBallard *obj, int val)
{
    obj->setLevels(val);
}
CVAPI(int) imgproc_GeneralizedHoughBallard_getLevels(cv::GeneralizedHoughBallard *obj)
{
    return obj->getLevels();
}

CVAPI(void) imgproc_GeneralizedHoughBallard_setVotesThreshold(cv::GeneralizedHoughBallard *obj, int val)
{
    obj->setVotesThreshold(val);
}
CVAPI(int) imgproc_GeneralizedHoughBallard_getVotesThreshold(cv::GeneralizedHoughBallard *obj)
{
    return obj->getVotesThreshold();
}


// GeneralizedHoughGuil

CVAPI(cv::Ptr<cv::GeneralizedHoughGuil>*) imgproc_createGeneralizedHoughGuil()
{
    cv::Ptr<cv::GeneralizedHoughGuil> ptr = cv::createGeneralizedHoughGuil();
    return new cv::Ptr<cv::GeneralizedHoughGuil>(ptr);
}
CVAPI(cv::GeneralizedHoughGuil*) imgproc_Ptr_GeneralizedHoughGuil_get(
    cv::Ptr<cv::GeneralizedHoughGuil> *obj)
{
    return obj->get();
}
CVAPI(void) imgproc_Ptr_GeneralizedHoughGuil_delete(cv::Ptr<cv::GeneralizedHoughGuil> *obj)
{
    delete obj;
}


CVAPI(void) imgproc_GeneralizedHoughGuil_setXi(cv::GeneralizedHoughGuil *obj, double val)
{
    obj->setXi(val);
}
CVAPI(double) imgproc_GeneralizedHoughGuil_getXi(cv::GeneralizedHoughGuil *obj)
{
    return obj->getXi();
}

CVAPI(void) imgproc_GeneralizedHoughGuil_setLevels(cv::GeneralizedHoughGuil *obj, int val)
{
    obj->setLevels(val);
}
CVAPI(int) imgproc_GeneralizedHoughGuil_getLevels(cv::GeneralizedHoughGuil *obj)
{
    return obj->getLevels();
}

CVAPI(void) imgproc_GeneralizedHoughGuil_setAngleEpsilon(cv::GeneralizedHoughGuil *obj, double val)
{
    obj->setAngleEpsilon(val);
}
CVAPI(double) imgproc_GeneralizedHoughGuil_getAngleEpsilon(cv::GeneralizedHoughGuil *obj)
{
    return obj->getAngleEpsilon();
}

CVAPI(void) imgproc_GeneralizedHoughGuil_setMinAngle(cv::GeneralizedHoughGuil *obj, double val)
{
    obj->setMinAngle(val);
}
CVAPI(double) imgproc_GeneralizedHoughGuil_getMinAngle(cv::GeneralizedHoughGuil *obj)
{
    return obj->getMinAngle();
}

CVAPI(void) imgproc_GeneralizedHoughGuil_setMaxAngle(cv::GeneralizedHoughGuil *obj, double val)
{
    obj->setMaxAngle(val);
}
CVAPI(double) imgproc_GeneralizedHoughGuil_getMaxAngle(cv::GeneralizedHoughGuil *obj)
{
    return obj->getMaxAngle();
}

CVAPI(void) imgproc_GeneralizedHoughGuil_setAngleStep(cv::GeneralizedHoughGuil *obj, double val)
{
    obj->setAngleStep(val);
}
CVAPI(double) imgproc_GeneralizedHoughGuil_getAngleStep(cv::GeneralizedHoughGuil *obj)
{
    return obj->getAngleStep();
}

CVAPI(void) imgproc_GeneralizedHoughGuil_setAngleThresh(cv::GeneralizedHoughGuil *obj, int val)
{
    obj->setAngleThresh(val);
}
CVAPI(int) imgproc_GeneralizedHoughGuil_getAngleThresh(cv::GeneralizedHoughGuil *obj)
{
    return obj->getAngleThresh();
}

CVAPI(void) imgproc_GeneralizedHoughGuil_setMinScale(cv::GeneralizedHoughGuil *obj, double val)
{
    obj->setMinScale(val);
}
CVAPI(double) imgproc_GeneralizedHoughGuil_getMinScale(cv::GeneralizedHoughGuil *obj)
{
    return obj->getMinScale();
}

CVAPI(void) imgproc_GeneralizedHoughGuil_setMaxScale(cv::GeneralizedHoughGuil *obj, double val)
{
    obj->setMaxScale(val);
}
CVAPI(double) imgproc_GeneralizedHoughGuil_getMaxScale(cv::GeneralizedHoughGuil *obj)
{
    return obj->getMaxScale();
}

CVAPI(void) imgproc_GeneralizedHoughGuil_setScaleStep(cv::GeneralizedHoughGuil *obj, double val)
{
    obj->setScaleStep(val);
}
CVAPI(double) imgproc_GeneralizedHoughGuil_getScaleStep(cv::GeneralizedHoughGuil *obj)
{
    return obj->getScaleStep();
}

CVAPI(void) imgproc_GeneralizedHoughGuil_setScaleThresh(cv::GeneralizedHoughGuil *obj, int val)
{
    obj->setScaleThresh(val);
}
CVAPI(int) imgproc_GeneralizedHoughGuil_getScaleThresh(cv::GeneralizedHoughGuil *obj)
{
    return obj->getScaleThresh();
}

CVAPI(void) imgproc_GeneralizedHoughGuil_setPosThresh(cv::GeneralizedHoughGuil *obj, int val)
{
    obj->setPosThresh(val);
}
CVAPI(int) imgproc_GeneralizedHoughGuil_getPosThresh(cv::GeneralizedHoughGuil *obj)
{
    return obj->getPosThresh();
}

#endif