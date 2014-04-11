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

CVAPI(void) superres_FrameSource_nextFrame(cv::superres::FrameSource *obj, cv::_OutputArray *frame)
{
    obj->nextFrame(*frame);
}
CVAPI(void) superres_FrameSource_reset(cv::superres::FrameSource *obj)
{
    obj->reset();
}

CVAPI(cv::Ptr<cv::superres::FrameSource>*) superres_createFrameSource_Empty()
{
    return clone( cv::superres::createFrameSource_Empty() );
}
CVAPI(cv::Ptr<cv::superres::FrameSource>*) superres_createFrameSource_Video(const char *fileName)
{
    return clone( cv::superres::createFrameSource_Video(fileName) );
}
CVAPI(cv::Ptr<cv::superres::FrameSource>*) superres_createFrameSource_Video_GPU(const char *fileName)
{
    return clone( cv::superres::createFrameSource_Video_GPU(fileName) );
}
CVAPI(cv::Ptr<cv::superres::FrameSource>*) superres_createFrameSource_Camera(int deviceId)
{
    return clone( cv::superres::createFrameSource_Camera(deviceId) );
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


CVAPI(cv::Ptr<cv::superres::SuperResolution>*) superres_createSuperResolution_BTVL1()
{
    return clone( cv::superres::createSuperResolution_BTVL1() );
}
CVAPI(cv::Ptr<cv::superres::SuperResolution>*) superres_createSuperResolution_BTVL1_GPU()
{
    return clone( cv::superres::createSuperResolution_BTVL1_GPU() );
}
CVAPI(cv::Ptr<cv::superres::SuperResolution>*) superres_createSuperResolution_BTVL1_OCL()
{
    return clone( cv::superres::createSuperResolution_BTVL1_OCL() );
}

CVAPI(cv::superres::SuperResolution*) superres_Ptr_SuperResolution_obj(cv::Ptr<cv::superres::SuperResolution> *ptr)
{
    return ptr->obj;
}
CVAPI(void) superres_Ptr_SuperResolution_delete(cv::Ptr<cv::superres::SuperResolution> *ptr)
{
	delete ptr;
}

CVAPI(cv::AlgorithmInfo*) superres_SuperResolution_info(cv::superres::SuperResolution *obj)
{
	return obj->info();
}

#endif