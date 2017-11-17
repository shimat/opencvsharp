#ifndef _CPP_TRACKING_H_
#define _CPP_TRACKING_H_

#include "include_opencv.h"


CVAPI(int) tracking_Tracker_init(cv::Tracker* tracker, const cv::Mat* image, const MyCvRect2D boundingBox)
{
    bool ret = tracker->init(*image, cpp(boundingBox));
    return ret ? 1 : 0;
}

/*
CVAPI(int) tracking_Tracker_init2(cv::Tracker* tracker, const cv::Mat* image, const MyCvRect2D boundingBox, std::string *outMessage)
{
	try
	{
		bool ret = tracker->init(*image, cpp(boundingBox));
		return ret ? 1 : 0;
	}
	catch (cv::Exception &ex)
	{
		std::string message = "err:" + ex.err + " file:" + ex.file + " func:" + ex.func + " msg:" + ex.msg;
		outMessage->assign(message);
		return 0;
	}
	catch (std::exception &ex)
	{
		std::string message = ex.what();
		outMessage->assign(message);
		return 0;
	}
}*/

CVAPI(int) tracking_Tracker_update(cv::Tracker* tracker, const cv::Mat* image, MyCvRect2D* boundingBox)
{
    cv::Rect2d bb = cpp(*boundingBox);
	const bool ret = tracker->update(*image, bb);
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
	const auto p = cv::TrackerKCF::create();
	return clone(p);
}
CVAPI(cv::Ptr<cv::TrackerKCF>*) tracking_TrackerKCF_create2(cv::TrackerKCF::Params *parameters)
{
	const auto p = cv::TrackerKCF::create(*parameters);
	return clone(p);
}

CVAPI(void) tracking_Ptr_TrackerKCF_delete(cv::Ptr<cv::TrackerKCF> *ptr)
{
	delete ptr;
}

CVAPI(cv::TrackerKCF*) tracking_Ptr_TrackerKCF_get(cv::Ptr<cv::TrackerKCF> *ptr)
{
	return ptr->get();
}

// TrackerMIL

CVAPI(cv::Ptr<cv::TrackerMIL>*) tracking_TrackerMIL_create1()
{
	const auto p = cv::TrackerMIL::create();
	return clone(p);
}
CVAPI(cv::Ptr<cv::TrackerMIL>*) tracking_TrackerMIL_create2(cv::TrackerMIL::Params *parameters)
{
	const auto p = cv::TrackerMIL::create(*parameters);
	return clone(p);
}

CVAPI(void) tracking_Ptr_TrackerMIL_delete(cv::Ptr<cv::TrackerMIL> *ptr)
{
	delete ptr;
}

CVAPI(cv::TrackerMIL*) tracking_Ptr_TrackerMIL_get(cv::Ptr<cv::TrackerMIL> *ptr)
{
	return ptr->get();
}

// TrackerBoosting

CVAPI(cv::Ptr<cv::TrackerBoosting>*) tracking_TrackerBoosting_create1()
{
	const auto p = cv::TrackerBoosting::create();
	return clone(p);
}
CVAPI(cv::Ptr<cv::TrackerBoosting>*) tracking_TrackerBoosting_create2(cv::TrackerBoosting::Params *parameters)
{
	const auto p = cv::TrackerBoosting::create(*parameters);
	return clone(p);
}

CVAPI(void) tracking_Ptr_TrackerBoosting_delete(cv::Ptr<cv::TrackerBoosting> *ptr)
{
	delete ptr;
}

CVAPI(cv::TrackerBoosting*) tracking_Ptr_TrackerBoosting_get(cv::Ptr<cv::TrackerBoosting> *ptr)
{
	return ptr->get();
}

// TrackerMedianFlow

CVAPI(cv::Ptr<cv::TrackerMedianFlow>*) tracking_TrackerMedianFlow_create1()
{
	const auto p = cv::TrackerMedianFlow::create();
	return clone(p);
}
CVAPI(cv::Ptr<cv::TrackerMedianFlow>*) tracking_TrackerMedianFlow_create2(cv::TrackerMedianFlow::Params *parameters)
{
	const auto p = cv::TrackerMedianFlow::create(*parameters);
	return clone(p);
}

CVAPI(void) tracking_Ptr_TrackerMedianFlow_delete(cv::Ptr<cv::TrackerMedianFlow> *ptr)
{
	delete ptr;
}

CVAPI(cv::TrackerMedianFlow*) tracking_Ptr_TrackerMedianFlow_get(cv::Ptr<cv::TrackerMedianFlow> *ptr)
{
	return ptr->get();
}

// TrackerTLD

CVAPI(cv::Ptr<cv::TrackerTLD>*) tracking_TrackerTLD_create1()
{
	const auto p = cv::TrackerTLD::create();
	return clone(p);
}
CVAPI(cv::Ptr<cv::TrackerTLD>*) tracking_TrackerTLD_create2(cv::TrackerTLD::Params *parameters)
{
	const auto p = cv::TrackerTLD::create(*parameters);
	return clone(p);
}

CVAPI(void) tracking_Ptr_TrackerTLD_delete(cv::Ptr<cv::TrackerTLD> *ptr)
{
	delete ptr;
}

CVAPI(cv::TrackerTLD*) tracking_Ptr_TrackerTLD_get(cv::Ptr<cv::TrackerTLD> *ptr)
{
	return ptr->get();
}

// TrackerGOTURN

CVAPI(cv::Ptr<cv::TrackerGOTURN>*) tracking_TrackerGOTURN_create1()
{
	const auto p = cv::TrackerGOTURN::create();
	return clone(p);
}
CVAPI(cv::Ptr<cv::TrackerGOTURN>*) tracking_TrackerGOTURN_create2(cv::TrackerGOTURN::Params *parameters)
{
	const auto p = cv::TrackerGOTURN::create(*parameters);
	return clone(p);
}

CVAPI(void) tracking_Ptr_TrackerGOTURN_delete(cv::Ptr<cv::TrackerGOTURN> *ptr)
{
	delete ptr;
}

CVAPI(cv::TrackerGOTURN*) tracking_Ptr_TrackerGOTURN_get(cv::Ptr<cv::TrackerGOTURN> *ptr)
{
	return ptr->get();
}

#endif