#ifndef _CPP_TRACKING_MULTITRACKER_H_
#define _CPP_TRACKING_MULTITRACKER_H_

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) tracking_MultiTracker_create(cv::Ptr<cv::MultiTracker> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::MultiTracker::create();
    *returnValue = clone(p);
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_MultiTracker_delete(cv::Ptr<cv::MultiTracker> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_MultiTracker_get(cv::Ptr<cv::MultiTracker> *ptr, cv::MultiTracker **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_MultiTracker_add1(
    cv::MultiTracker *obj, cv::Ptr<cv::Tracker> *newTracker, cv::_InputArray *image, MyCvRect2D64f boundingBox, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->add(*newTracker, *image, cpp(boundingBox)) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_MultiTracker_add2(
    cv::MultiTracker *obj, cv::Ptr<cv::Tracker> **newTrackers, int newTrackersLength, cv::_InputArray *image, 
    MyCvRect2D64f *boundingBox, int boundingBoxLength, int *returnValue)
{
    BEGIN_WRAP
    std::vector<cv::Ptr<cv::Tracker> > newTrackersVec(newTrackersLength);
    for (int i = 0; i < newTrackersLength; i++)
    {
        newTrackersVec[i] = *newTrackers[i];
    }

    std::vector<cv::Rect2d> boundingBoxVec(boundingBoxLength);
    for (int i = 0; i < boundingBoxLength; i++)
    {
        boundingBoxVec[i] = cpp(boundingBox[i]);
    }

    *returnValue = obj->add(newTrackersVec, *image, boundingBoxVec) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_MultiTracker_update1(cv::MultiTracker *obj, cv::_InputArray *image, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->update(*image) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_MultiTracker_update2(cv::MultiTracker *obj, cv::_InputArray *image, std::vector<cv::Rect2d> *boundingBox, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->update(*image, *boundingBox) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_MultiTracker_getObjects(cv::MultiTracker *obj, std::vector<cv::Rect2d> *boundingBox)
{
    BEGIN_WRAP
    const auto& result = obj->getObjects();
    std::copy(result.begin(), result.end(), std::back_inserter(*boundingBox));
    END_WRAP
}


#endif