#ifndef _CPP_ARUCO_H_
#define _CPP_ARUCO_H_

#include "include_opencv.h"

CVAPI(cv::Ptr<cv::aruco::DetectorParameters>*) aruco_DetectorParameters_create()
{
    cv::Ptr<cv::aruco::DetectorParameters> p = cv::aruco::DetectorParameters::create();

    // This code corrupt memory
    //return c(*p);
    return new cv::Ptr<cv::aruco::DetectorParameters>(p);
}

CVAPI(void) aruco_drawDetectedMarkers(
    cv::_InputOutputArray *image,
    cv::Point2f **corners,
    int cornerSize1,
    int *cornerSize2,
    int *idx, int idxCount, MyCvScalar borderColor)
{
    std::vector<std::vector<cv::Point2f>> cornerVec(cornerSize1);
    std::vector<int> idxVec;

    for (int i = 0; i < cornerSize1; i++)
        cornerVec[i] = std::vector<cv::Point2f>(corners[i], corners[i] + cornerSize2[i]);
    if (idx != NULL)
        idxVec = std::vector<int>(idx, idx + idxCount);

    cv::aruco::drawDetectedMarkers(*image, cornerVec, idxVec, cpp(borderColor));
}

CVAPI(void) aruco_drawMarker(cv::Ptr<cv::aruco::Dictionary> *dictionary, int id, int sidePixels, cv::_OutputArray *img, int borderBits)
{
    cv::aruco::drawMarker(*dictionary, id, sidePixels, *img, borderBits);
}

CVAPI(void) aruco_detectMarkers(cv::_InputArray *image, 
    cv::Ptr<cv::aruco::Dictionary> *dictionary, 
    std::vector<std::vector<cv::Point2f>> *corners,
    std::vector<int> *ids, 
    cv::Ptr<cv::aruco::DetectorParameters> *parameters,
    std::vector<std::vector<cv::Point2f>> *rejectedImgPoints)
{
    //*corners = new std::vector<std::vector<cv::Point2f>>();
    //*ids = new std::vector<int>();
    //*rejectedImgPoints = new std::vector<std::vector<cv::Point2f>>();
    cv::aruco::detectMarkers(*image, *dictionary, *corners, *ids, *parameters, *rejectedImgPoints);
}

CVAPI(void) aruco_estimatePoseSingleMarkers(cv::_InputArray *corners, float markerLength,
    cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
    cv::_OutputArray *rvecs, cv::_OutputArray *tvecs)
{
    cv::aruco::estimatePoseSingleMarkers(*corners, markerLength, *cameraMatrix, *distCoeffs, *rvecs, *tvecs);
}

CVAPI(cv::Ptr<cv::aruco::Dictionary>*) aruco_getPredefinedDictionary(cv::aruco::PREDEFINED_DICTIONARY_NAME name)
{
    cv::Ptr<cv::aruco::Dictionary> dictionary = cv::aruco::getPredefinedDictionary(name);

    return new cv::Ptr<cv::aruco::Dictionary>(dictionary);
}

CVAPI(void) aruco_Ptr_DetectorParameters_delete(cv::Ptr<cv::aruco::DetectorParameters> *ptr)
{
    delete ptr;
}

CVAPI(cv::aruco::DetectorParameters*) aruco_Ptr_DetectorParameters_get(cv::Ptr<cv::aruco::DetectorParameters> *ptr)
{
    return ptr->get();
}

CVAPI(void) aruco_DetectorParameters_setAdaptiveThreshWinSizeMin(cv::aruco::DetectorParameters *obj, int value)
{
    obj->adaptiveThreshWinSizeMin = value;
}
CVAPI(void) aruco_DetectorParameters_setAdaptiveThreshWinSizeMax(cv::aruco::DetectorParameters *obj, int value)
{
    obj->adaptiveThreshWinSizeMax = value;
}
CVAPI(void) aruco_DetectorParameters_setAdaptiveThreshWinSizeStep(cv::aruco::DetectorParameters *obj, int value)
{
    obj->adaptiveThreshWinSizeStep = value;
}
CVAPI(void) aruco_DetectorParameters_setAdaptiveThreshConstant(cv::aruco::DetectorParameters *obj, double value)
{
    obj->adaptiveThreshConstant = value;
}
CVAPI(void) aruco_DetectorParameters_setMinMarkerPerimeterRate(cv::aruco::DetectorParameters *obj, double value)
{
    obj->minMarkerPerimeterRate = value;
}
CVAPI(void) aruco_DetectorParameters_setMaxMarkerPerimeterRate(cv::aruco::DetectorParameters *obj, double value)
{
    obj->maxMarkerPerimeterRate = value;
}
CVAPI(void) aruco_DetectorParameters_setPolygonalApproxAccuracyRate(cv::aruco::DetectorParameters *obj, double value)
{
    obj->polygonalApproxAccuracyRate = value;
}
CVAPI(void) aruco_DetectorParameters_setMinCornerDistanceRate(cv::aruco::DetectorParameters *obj, double value)
{
    obj->minCornerDistanceRate = value;
}
CVAPI(void) aruco_DetectorParameters_setMinDistanceToBorder(cv::aruco::DetectorParameters *obj, int value)
{
    obj->minDistanceToBorder = value;
}
CVAPI(void) aruco_DetectorParameters_setMinMarkerDistanceRate(cv::aruco::DetectorParameters *obj, double value)
{
    obj->minMarkerDistanceRate = value;
}
CVAPI(void) aruco_DetectorParameters_setDoCornerRefinement(cv::aruco::DetectorParameters *obj, bool value)
{
    obj->doCornerRefinement = value;
}
CVAPI(void) aruco_DetectorParameters_setCornerRefinementWinSize(cv::aruco::DetectorParameters *obj, int value)
{
    obj->cornerRefinementWinSize = value;
}
CVAPI(void) aruco_DetectorParameters_setCornerRefinementMaxIterations(cv::aruco::DetectorParameters *obj, int value)
{
    obj->cornerRefinementMaxIterations = value;
}
CVAPI(void) aruco_DetectorParameters_setCornerRefinementMinAccuracy(cv::aruco::DetectorParameters *obj, double value)
{
    obj->cornerRefinementMinAccuracy = value;
}
CVAPI(void) aruco_DetectorParameters_setMarkerBorderBits(cv::aruco::DetectorParameters *obj, int value)
{
    obj->markerBorderBits = value;
}
CVAPI(void) aruco_DetectorParameters_setPerspectiveRemovePixelPerCell(cv::aruco::DetectorParameters *obj, int value)
{
    obj->perspectiveRemovePixelPerCell = value;
}
CVAPI(void) aruco_DetectorParameters_setPerspectiveRemoveIgnoredMarginPerCell(cv::aruco::DetectorParameters *obj, double value)
{
    obj->perspectiveRemoveIgnoredMarginPerCell = value;
}
CVAPI(void) aruco_DetectorParameters_setMaxErroneousBitsInBorderRate(cv::aruco::DetectorParameters *obj, double value)
{
    obj->maxErroneousBitsInBorderRate = value;
}
CVAPI(void) aruco_DetectorParameters_setMinOtsuStdDev(cv::aruco::DetectorParameters *obj, double value)
{
    obj->minOtsuStdDev = value;
}
CVAPI(void) aruco_DetectorParameters_setErrorCorrectionRate(cv::aruco::DetectorParameters *obj, double value)
{
    obj->errorCorrectionRate = value;
}
CVAPI(int) aruco_DetectorParameters_getAdaptiveThreshWinSizeMin(cv::aruco::DetectorParameters *obj)
{
    return obj->adaptiveThreshWinSizeMin;
}
CVAPI(int) aruco_DetectorParameters_getAdaptiveThreshWinSizeMax(cv::aruco::DetectorParameters *obj)
{
    return obj->adaptiveThreshWinSizeMax;
}
CVAPI(int) aruco_DetectorParameters_getAdaptiveThreshWinSizeStep(cv::aruco::DetectorParameters *obj)
{
    return obj->adaptiveThreshWinSizeStep;
}
CVAPI(double) aruco_DetectorParameters_getAdaptiveThreshConstant(cv::aruco::DetectorParameters *obj)
{
    return obj->adaptiveThreshConstant;
}
CVAPI(double) aruco_DetectorParameters_getMinMarkerPerimeterRate(cv::aruco::DetectorParameters *obj)
{
    return obj->minMarkerPerimeterRate;
}
CVAPI(double) aruco_DetectorParameters_getMaxMarkerPerimeterRate(cv::aruco::DetectorParameters *obj)
{
    return obj->maxMarkerPerimeterRate;
}
CVAPI(double) aruco_DetectorParameters_getPolygonalApproxAccuracyRate(cv::aruco::DetectorParameters *obj)
{
    return obj->polygonalApproxAccuracyRate;
}
CVAPI(double) aruco_DetectorParameters_getMinCornerDistanceRate(cv::aruco::DetectorParameters *obj)
{
    return obj->minCornerDistanceRate;
}
CVAPI(int) aruco_DetectorParameters_getMinDistanceToBorder(cv::aruco::DetectorParameters *obj)
{
    return obj->minDistanceToBorder;
}
CVAPI(double) aruco_DetectorParameters_getMinMarkerDistanceRate(cv::aruco::DetectorParameters *obj)
{
    return obj->minMarkerDistanceRate;
}
CVAPI(bool) aruco_DetectorParameters_getDoCornerRefinement(cv::aruco::DetectorParameters *obj)
{
    return obj->doCornerRefinement;
}
CVAPI(int) aruco_DetectorParameters_getCornerRefinementWinSize(cv::aruco::DetectorParameters *obj)
{
    return obj->cornerRefinementWinSize;
}
CVAPI(int) aruco_DetectorParameters_getCornerRefinementMaxIterations(cv::aruco::DetectorParameters *obj)
{
    return obj->cornerRefinementMaxIterations;
}
CVAPI(double) aruco_DetectorParameters_getCornerRefinementMinAccuracy(cv::aruco::DetectorParameters *obj)
{
    return obj->cornerRefinementMinAccuracy;
}
CVAPI(int) aruco_DetectorParameters_getMarkerBorderBits(cv::aruco::DetectorParameters *obj)
{
    return obj->markerBorderBits;
}
CVAPI(int) aruco_DetectorParameters_getPerspectiveRemovePixelPerCell(cv::aruco::DetectorParameters *obj)
{
    return obj->perspectiveRemovePixelPerCell;
}
CVAPI(double) aruco_DetectorParameters_getPerspectiveRemoveIgnoredMarginPerCell(cv::aruco::DetectorParameters *obj)
{
    return obj->perspectiveRemoveIgnoredMarginPerCell;
}
CVAPI(double) aruco_DetectorParameters_getMaxErroneousBitsInBorderRate(cv::aruco::DetectorParameters *obj)
{
    return obj->maxErroneousBitsInBorderRate;
}
CVAPI(double) aruco_DetectorParameters_getMinOtsuStdDev(cv::aruco::DetectorParameters *obj)
{
    return obj->minOtsuStdDev;
}
CVAPI(double) aruco_DetectorParameters_getErrorCorrectionRate(cv::aruco::DetectorParameters *obj)
{
    return obj->errorCorrectionRate;
}

CVAPI(void) aruco_Ptr_Dictionary_delete(cv::Ptr<cv::aruco::Dictionary> *ptr)
{
    delete ptr;
}

CVAPI(cv::aruco::Dictionary*) aruco_Ptr_Dictionary_get(cv::Ptr<cv::aruco::Dictionary> *ptr)
{
    return ptr->get();
}
CVAPI(void) aruco_Dictionary_setMarkerSize(cv::aruco::Dictionary *obj, int value)
{
    obj->markerSize = value;
}
CVAPI(void) aruco_Dictionary_setMaxCorrectionBits(cv::aruco::Dictionary *obj, int value)
{
    obj->maxCorrectionBits = value;
}
CVAPI(cv::Mat*) aruco_Dictionary_getBytesList(cv::aruco::Dictionary *obj)
{
    return new cv::Mat(obj->bytesList);
}
CVAPI(int) aruco_Dictionary_getMarkerSize(cv::aruco::Dictionary *obj)
{
    return obj->markerSize;
}
CVAPI(int) aruco_Dictionary_getMaxCorrectionBits(cv::aruco::Dictionary *obj)
{
    return obj->maxCorrectionBits;
}

#endif