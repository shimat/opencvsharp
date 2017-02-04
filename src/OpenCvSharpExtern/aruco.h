#ifndef _CPP_ARUCO_H_
#define _CPP_ARUCO_H_

#include "include_opencv.h"

CVAPI(aruco_DetectorParameters) aruco_DetectorParameters_create()
{
    cv::Ptr<cv::aruco::DetectorParameters> p = cv::aruco::DetectorParameters::create();
    return c(*p);
}

CVAPI(void) aruco_detectMarkers(cv::_InputArray *image, cv::aruco::Dictionary *dictionary, cv::_OutputArray *corners,
                          cv::_OutputArray *ids, aruco_DetectorParameters *parameters,
                          cv::_OutputArray *rejectedImgPoints)
{
    cv::aruco::DetectorParameters parametersCpp = cpp(*parameters);
    cv::aruco::detectMarkers(*image, dictionary, *corners, *ids, &parametersCpp, *rejectedImgPoints);
}

CVAPI(void) aruco_estimatePoseSingleMarkers(cv::_InputArray *corners, float markerLength,
                                            cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
                                            cv::_OutputArray *rvecs, cv::_OutputArray *tvecs)
{
    cv::aruco::estimatePoseSingleMarkers(*corners, markerLength, *cameraMatrix, *distCoeffs, *rvecs, *tvecs);
}

#endif