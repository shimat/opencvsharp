#ifndef _CPP_TRACKING_H_
#define _CPP_TRACKING_H_

#include "include_opencv.h"

/*
CVAPI(cv::Ptr<cv::Tracker>*) tracking_Tracker_create(const char* trackerType)
{
    std::string type(trackerType);
    cv::Ptr<cv::Tracker> p = cv::Tracker::create(type);
    return new cv::Ptr<cv::Tracker>(p);
}*/

CVAPI(int) tracking_Tracker_init(cv::Tracker* tracker, const cv::Mat* image, MyCvRect2D boundingBox)
{
    bool ret = tracker->init(*image, cpp(boundingBox));
    return ret ? 1 : 0;
}

CVAPI(int) tracking_Tracker_update(cv::Tracker* tracker, const cv::Mat* image, MyCvRect2D* boundingBox)
{
    cv::Rect2d bb = cpp(*boundingBox);
    bool ret = tracker->update(*image, bb);
    if (ret)
    {
        boundingBox->x = bb.x;
        boundingBox->y = bb.y;
        boundingBox->width = bb.width;
        boundingBox->height = bb.height;
    }

    return ret ? 1 : 0;
}

CVAPI(void) tracking_Ptr_Tracker_delete(cv::Ptr<cv::Tracker> *ptr)
{
    delete ptr;
}

CVAPI(cv::Tracker*) tracking_Ptr_Tracker_get(cv::Ptr<cv::Tracker> *ptr)
{
    return ptr->get();
}

// TrackerKCF

CVAPI(cv::Ptr<cv::TrackerKCF>*) tracking_TrackerKCF_create1()
{	
	cv::Ptr<cv::TrackerKCF> p = cv::TrackerKCF::create();
	return clone(p);
}
CVAPI(cv::Ptr<cv::TrackerKCF>*) tracking_TrackerKCF_create2(cv::TrackerKCF::Params *parameters)
{
	cv::Ptr<cv::TrackerKCF> p = cv::TrackerKCF::create(*parameters);
	return clone(p);
}

CVAPI(void) tracking_Ptr_TrackerKCF_delete(cv::Ptr<cv::TrackerKCF> *ptr)
{
	delete ptr;
}

CVAPI(cv::Tracker*) tracking_Ptr_TrackerKCF_get(cv::Ptr<cv::TrackerKCF> *ptr)
{
	return ptr->get();
}

#endif