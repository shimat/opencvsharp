/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_SUPERRES_H_
#define _CPP_SUPERRES_H_

#include "include_opencv.h"

CVAPI(int) superres_initModule_superres()
{
    return cv::superres::initModule_superres() ? 1 : 0;
}

CVAPI(void) superres_FrameSource_delete(cv::superres::FrameSource *obj)
{
    delete obj;
}

CVAPI(cv::Ptr<cv::superres::FrameSource>*) superres_createFrameSource_Empty()
{
    cv::Ptr<cv::superres::FrameSource> obj = cv::superres::createFrameSource_Empty();
    cv::Ptr<cv::superres::FrameSource> *ret = new cv::Ptr<cv::superres::FrameSource>(obj);
    return ret;
}
CVAPI(cv::Ptr<cv::superres::FrameSource>*) superres_createFrameSource_Video(const char *fileName)
{
    cv::Ptr<cv::superres::FrameSource> obj = cv::superres::createFrameSource_Video(fileName);
    cv::Ptr<cv::superres::FrameSource> *ret = new cv::Ptr<cv::superres::FrameSource>(obj);
    return ret;
}
CVAPI(cv::Ptr<cv::superres::FrameSource>*) superres_createFrameSource_Video_GPU(const char *fileName)
{
    cv::Ptr<cv::superres::FrameSource> obj = cv::superres::createFrameSource_Video_GPU(fileName);
    cv::Ptr<cv::superres::FrameSource> *ret = new cv::Ptr<cv::superres::FrameSource>(obj);
    return ret;
}
CVAPI(cv::Ptr<cv::superres::FrameSource>*) superres_createFrameSource_Camera(int deviceId)
{
    cv::Ptr<cv::superres::FrameSource> obj = cv::superres::createFrameSource_Camera(deviceId);
    cv::Ptr<cv::superres::FrameSource> *ret = new cv::Ptr<cv::superres::FrameSource>(obj);
    return ret;
}

CVAPI(cv::superres::FrameSource*) superres_Ptr_FrameSource_obj(cv::Ptr<cv::superres::FrameSource> *ptr)
{
    return ptr->obj;
}
CVAPI(void) superres_Ptr_FrameSource_delete(cv::Ptr<cv::superres::FrameSource> *ptr)
{
	delete ptr;
}

CVAPI(void) superres_SuperResolution_setInput(
    cv::superres::SuperResolution *obj, cv::superres::FrameSource *frameSource)
{
    obj->setInput(frameSource);
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

// S. Farsiu , D. Robinson, M. Elad, P. Milanfar. Fast and robust multiframe super resolution.
// Dennis Mitzel, Thomas Pock, Thomas Schoenemann, Daniel Cremers. Video Super Resolution using Duality Based TV-L1 Optical Flow.
CVAPI(cv::Ptr<cv::superres::SuperResolution>*) superres_createSuperResolution_BTVL1()
{
    cv::Ptr<cv::superres::SuperResolution> obj = cv::superres::createSuperResolution_BTVL1();
    cv::Ptr<cv::superres::SuperResolution> *ret = new cv::Ptr<cv::superres::SuperResolution>(obj);
    return ret;
}
CVAPI(cv::Ptr<cv::superres::SuperResolution>*) superres_createSuperResolution_BTVL1_GPU()
{
    cv::Ptr<cv::superres::SuperResolution> obj = cv::superres::createSuperResolution_BTVL1_GPU();
    cv::Ptr<cv::superres::SuperResolution> *ret = new cv::Ptr<cv::superres::SuperResolution>(obj);
    return ret;
}
CVAPI(cv::Ptr<cv::superres::SuperResolution>*) superres_createSuperResolution_BTVL1_OCL()
{
    cv::Ptr<cv::superres::SuperResolution> obj = cv::superres::createSuperResolution_BTVL1_OCL();
    cv::Ptr<cv::superres::SuperResolution> *ret = new cv::Ptr<cv::superres::SuperResolution>(obj);
    return ret;
}


#endif