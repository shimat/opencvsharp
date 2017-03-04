#ifndef _CPP_FEATURES2D_SIMPLEBLOBDETECTOR_H_
#define _CPP_FEATURES2D_SIMPLEBLOBDETECTOR_H_

#include "include_opencv.h"


struct SimpleBlobDetector_Params
{
    float thresholdStep;
    float minThreshold;
    float maxThreshold;
    uint32 minRepeatability; // size_t
    float minDistBetweenBlobs;

    int filterByColor;
    uchar blobColor;

    int filterByArea;
    float minArea, maxArea;

    int filterByCircularity;
    float minCircularity, maxCircularity;

    int filterByInertia;
    float minInertiaRatio, maxInertiaRatio;

    int filterByConvexity;
    float minConvexity, maxConvexity;
};

CVAPI(cv::Ptr<cv::SimpleBlobDetector>*) features2d_SimpleBlobDetector_create(
    SimpleBlobDetector_Params *p)
{
    cv::SimpleBlobDetector::Params p2;
    if (p != NULL)
    {
        p2.thresholdStep = p->thresholdStep;
        p2.minThreshold = p->minThreshold;
        p2.maxThreshold = p->maxThreshold;
        p2.minRepeatability = (size_t)p->minRepeatability;
        p2.minDistBetweenBlobs = p->minDistBetweenBlobs;
        p2.filterByColor = p->filterByColor != 0;
        p2.blobColor = p->blobColor;
        p2.filterByArea = p->filterByArea != 0;
        p2.minArea = p->minArea;
        p2.maxArea = p->maxArea;
        p2.filterByCircularity = p->filterByCircularity != 0;
        p2.minCircularity = p->minCircularity;
        p2.maxCircularity = p->maxCircularity;
        p2.filterByInertia = p->filterByInertia != 0;
        p2.minInertiaRatio = p->minInertiaRatio;
        p2.maxInertiaRatio = p->maxInertiaRatio;
        p2.filterByConvexity = p->filterByConvexity != 0;
        p2.minConvexity = p->minConvexity;
        p2.maxConvexity = p->maxConvexity;
    }
    cv::Ptr<cv::SimpleBlobDetector> ptr = cv::SimpleBlobDetector::create(p2);
    return new cv::Ptr<cv::SimpleBlobDetector>(ptr);
}
CVAPI(void) features2d_Ptr_SimpleBlobDetector_delete(cv::Ptr<cv::SimpleBlobDetector> *ptr)
{
    delete ptr;
}

CVAPI(cv::SimpleBlobDetector*) features2d_Ptr_SimpleBlobDetector_get(cv::Ptr<cv::SimpleBlobDetector> *ptr)
{
    return ptr->get();
}
#endif