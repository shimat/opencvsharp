#ifndef _CPP_ARUCO_H_
#define _CPP_ARUCO_H_

#include "include_opencv.h"

extern "C" 
{
    struct aruco_DetectorParameters 
    {
        int adaptiveThreshWinSizeMin;
        int adaptiveThreshWinSizeMax;
        int adaptiveThreshWinSizeStep;
        double adaptiveThreshConstant;
        double minMarkerPerimeterRate;
        double maxMarkerPerimeterRate;
        double polygonalApproxAccuracyRate;
        double minCornerDistanceRate;
        int minDistanceToBorder;
        double minMarkerDistanceRate;
        int cornerRefinementMethod;
        int cornerRefinementWinSize;
        int cornerRefinementMaxIterations;
        double cornerRefinementMinAccuracy;
        int markerBorderBits;
        int perspectiveRemovePixelPerCell;
        double perspectiveRemoveIgnoredMarginPerCell;
        double maxErroneousBitsInBorderRate;
        double minOtsuStdDev;
        double errorCorrectionRate;
        float aprilTagQuadDecimate;
        float aprilTagQuadSigma;
        int aprilTagMinClusterPixels;
        int aprilTagMaxNmaxima;
        float aprilTagCriticalRad;
        float aprilTagMaxLineFitMse;
        int aprilTagDeglitch;
        int aprilTagMinWhiteBlackDiff;
        bool detectInvertedMarker;
    };
}

static cv::Ptr<cv::aruco::DetectorParameters> cpp(const aruco_DetectorParameters &p)
{
    auto pp = cv::aruco::DetectorParameters::create();
    pp->adaptiveThreshWinSizeMin = p.adaptiveThreshWinSizeMin;
    pp->adaptiveThreshWinSizeMax = p.adaptiveThreshWinSizeMax;
    pp->adaptiveThreshWinSizeStep = p.adaptiveThreshWinSizeStep;
    pp->adaptiveThreshConstant = p.adaptiveThreshConstant;
    pp->minMarkerPerimeterRate = p.minMarkerPerimeterRate;
    pp->maxMarkerPerimeterRate = p.maxMarkerPerimeterRate;
    pp->polygonalApproxAccuracyRate = p.polygonalApproxAccuracyRate;
    pp->minCornerDistanceRate = p.minCornerDistanceRate;
    pp->minDistanceToBorder = p.minDistanceToBorder;
    pp->minMarkerDistanceRate = p.minMarkerDistanceRate;
    pp->cornerRefinementMethod = p.cornerRefinementMethod;
    pp->cornerRefinementWinSize = p.cornerRefinementWinSize;
    pp->cornerRefinementMaxIterations = p.cornerRefinementMaxIterations;
    pp->cornerRefinementMinAccuracy = p.cornerRefinementMinAccuracy;
    pp->markerBorderBits = p.markerBorderBits;
    pp->perspectiveRemovePixelPerCell = p.perspectiveRemovePixelPerCell;
    pp->perspectiveRemoveIgnoredMarginPerCell = p.perspectiveRemoveIgnoredMarginPerCell;
    pp->maxErroneousBitsInBorderRate = p.maxErroneousBitsInBorderRate;
    pp->minOtsuStdDev = p.minOtsuStdDev;
    pp->errorCorrectionRate = p.errorCorrectionRate;
    pp->aprilTagQuadDecimate = p.aprilTagQuadDecimate;
    pp->aprilTagQuadSigma = p.aprilTagQuadSigma;
    pp->aprilTagMinClusterPixels = p.aprilTagMinClusterPixels;
    pp->aprilTagMaxNmaxima = p.aprilTagMaxNmaxima;
    pp->aprilTagCriticalRad = p.aprilTagCriticalRad;
    pp->aprilTagMaxLineFitMse = p.aprilTagMaxLineFitMse;
    pp->aprilTagDeglitch = p.aprilTagDeglitch;
    pp->aprilTagMinWhiteBlackDiff = p.aprilTagMinWhiteBlackDiff;
    pp->detectInvertedMarker = p.detectInvertedMarker;
    return pp;
}
static aruco_DetectorParameters c(const cv::Ptr<cv::aruco::DetectorParameters> p)
{
    aruco_DetectorParameters pp{};
    pp.adaptiveThreshWinSizeMin = p->adaptiveThreshWinSizeMin;
    pp.adaptiveThreshWinSizeMax = p->adaptiveThreshWinSizeMax;
    pp.adaptiveThreshWinSizeStep = p->adaptiveThreshWinSizeStep;
    pp.adaptiveThreshConstant = p->adaptiveThreshConstant;
    pp.minMarkerPerimeterRate = p->minMarkerPerimeterRate;
    pp.maxMarkerPerimeterRate = p->maxMarkerPerimeterRate;
    pp.polygonalApproxAccuracyRate = p->polygonalApproxAccuracyRate;
    pp.minCornerDistanceRate = p->minCornerDistanceRate;
    pp.minDistanceToBorder = p->minDistanceToBorder;
    pp.minMarkerDistanceRate = p->minMarkerDistanceRate;
    pp.cornerRefinementMethod = p->cornerRefinementMethod;
    pp.cornerRefinementWinSize = p->cornerRefinementWinSize;
    pp.cornerRefinementMaxIterations = p->cornerRefinementMaxIterations;
    pp.cornerRefinementMinAccuracy = p->cornerRefinementMinAccuracy;
    pp.markerBorderBits = p->markerBorderBits;
    pp.perspectiveRemovePixelPerCell = p->perspectiveRemovePixelPerCell;
    pp.perspectiveRemoveIgnoredMarginPerCell = p->perspectiveRemoveIgnoredMarginPerCell;
    pp.maxErroneousBitsInBorderRate = p->maxErroneousBitsInBorderRate;
    pp.minOtsuStdDev = p->minOtsuStdDev;
    pp.errorCorrectionRate = p->errorCorrectionRate;
    pp.aprilTagQuadDecimate = p->aprilTagQuadDecimate;
    pp.aprilTagQuadSigma = p->aprilTagQuadSigma;
    pp.aprilTagMinClusterPixels = p->aprilTagMinClusterPixels;
    pp.aprilTagMaxNmaxima = p->aprilTagMaxNmaxima;
    pp.aprilTagCriticalRad = p->aprilTagCriticalRad;
    pp.aprilTagMaxLineFitMse = p->aprilTagMaxLineFitMse;
    pp.aprilTagDeglitch = p->aprilTagDeglitch;
    pp.aprilTagMinWhiteBlackDiff = p->aprilTagMinWhiteBlackDiff;
    pp.detectInvertedMarker = p->detectInvertedMarker;
    return pp;
}

CVAPI(ExceptionStatus) aruco_DetectorParameters_create(aruco_DetectorParameters *returnValue)
{
    BEGIN_WRAP
    const auto p = cv::aruco::DetectorParameters::create();
    *returnValue = c(p);
    END_WRAP
}

CVAPI(ExceptionStatus) aruco_drawDetectedMarkers(
    cv::_InputOutputArray *image,
    cv::Point2f **corners,
    int cornerSize1,
    int *cornerSize2,
    int *idx, int idxCount, MyCvScalar borderColor)
{
    BEGIN_WRAP
    std::vector< std::vector<cv::Point2f> > cornerVec(cornerSize1);
    std::vector<int> idxVec;

    for (int i = 0; i < cornerSize1; i++)
        cornerVec[i] = std::vector<cv::Point2f>(corners[i], corners[i] + cornerSize2[i]);
    if (idx != nullptr)
        idxVec = std::vector<int>(idx, idx + idxCount);

    cv::aruco::drawDetectedMarkers(*image, cornerVec, idxVec, cpp(borderColor));
    END_WRAP
}

CVAPI(ExceptionStatus) aruco_drawMarker(
    cv::Ptr<cv::aruco::Dictionary> *dictionary, int id, int sidePixels, cv::_OutputArray *img, int borderBits)
{
    BEGIN_WRAP
    cv::aruco::drawMarker(*dictionary, id, sidePixels, *img, borderBits);
    END_WRAP
}

CVAPI(ExceptionStatus) aruco_detectMarkers(
    cv::_InputArray *image, 
    cv::Ptr<cv::aruco::Dictionary> *dictionary, 
    std::vector< std::vector<cv::Point2f> > *corners,
    std::vector<int> *ids, 
    aruco_DetectorParameters *parameters,
    std::vector< std::vector<cv::Point2f> > *rejectedImgPoints)
{
    BEGIN_WRAP
    const auto p = cpp(*parameters);
    cv::aruco::detectMarkers(*image, *dictionary, *corners, *ids, p, *rejectedImgPoints);
    END_WRAP
}

CVAPI(ExceptionStatus) aruco_estimatePoseSingleMarkers(
    cv::Point2f **corners, int cornersLength1,
    int *cornersLengths2, float markerLength,
    cv::_InputArray *cameraMatrix,
    cv::_InputArray *distCoeffs,
    cv::_OutputArray *rvecs, 
    cv::_OutputArray *tvecs,
    cv::_OutputArray *objPoints)
{
    BEGIN_WRAP
    std::vector<std::vector<cv::Point2f> > cornersVec(cornersLength1);
    for (int i = 0; i < cornersLength1; i++)    
        cornersVec[i] = std::vector<cv::Point2f>(corners[i], corners[i] + cornersLengths2[i]);    

    cv::aruco::estimatePoseSingleMarkers(cornersVec, markerLength, *cameraMatrix, *distCoeffs, *rvecs, *tvecs, entity(objPoints));
    END_WRAP
}

CVAPI(ExceptionStatus) aruco_drawAxis(
    cv::_InputOutputArray *image,
    cv::_InputArray *cameraMatrix,
    cv::_InputArray *distCoeffs,
    cv::_InputArray *rvec,
    cv::_InputArray *tvec,
    float length)
{
    BEGIN_WRAP
    cv::aruco::drawAxis(*image, *cameraMatrix, *distCoeffs, *rvec, *tvec, length);
    END_WRAP
}

CVAPI(ExceptionStatus) aruco_getPredefinedDictionary(int name, cv::Ptr<cv::aruco::Dictionary>** returnValue)
{
    BEGIN_WRAP
    const auto dictionary = cv::aruco::getPredefinedDictionary(static_cast<cv::aruco::PREDEFINED_DICTIONARY_NAME>(name));
    *returnValue = new cv::Ptr<cv::aruco::Dictionary>(dictionary);
    END_WRAP
}


CVAPI(ExceptionStatus) aruco_Ptr_Dictionary_delete(cv::Ptr<cv::aruco::Dictionary> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) aruco_Ptr_Dictionary_get(cv::Ptr<cv::aruco::Dictionary> *ptr, cv::aruco::Dictionary **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}
CVAPI(ExceptionStatus) aruco_Dictionary_setMarkerSize(cv::aruco::Dictionary *obj, int value)
{
    BEGIN_WRAP
    obj->markerSize = value;
    END_WRAP
}
CVAPI(ExceptionStatus) aruco_Dictionary_setMaxCorrectionBits(cv::aruco::Dictionary *obj, int value)
{
    BEGIN_WRAP
    obj->maxCorrectionBits = value;
    END_WRAP
}
CVAPI(ExceptionStatus) aruco_Dictionary_getBytesList(cv::aruco::Dictionary *obj, cv::Mat** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(obj->bytesList);
    END_WRAP
}
CVAPI(ExceptionStatus) aruco_Dictionary_getMarkerSize(cv::aruco::Dictionary *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->markerSize;
    END_WRAP
}
CVAPI(ExceptionStatus) aruco_Dictionary_getMaxCorrectionBits(cv::aruco::Dictionary *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxCorrectionBits;
    END_WRAP
}


CVAPI(ExceptionStatus) aruco_detectCharucoDiamond(
    cv::_InputArray *image,
    cv::Point2f **markerCorners,
    int markerCornersSize1,
    int *markerCornersSize2,
    std::vector<int> *markerIds,
    float squareMarkerLengthRate,
    std::vector< std::vector<cv::Point2f> > *diamondCorners,
    std::vector<cv::Vec4i> *diamondIds,
    cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs)
{
    BEGIN_WRAP
    std::vector< std::vector<cv::Point2f> > markerCornerVec(markerCornersSize1);
    for (int i = 0; i < markerCornersSize1; i++)
        markerCornerVec[i] = std::vector<cv::Point2f>(markerCorners[i], markerCorners[i] + markerCornersSize2[i]);

    cv::aruco::detectCharucoDiamond(*image, markerCornerVec, *markerIds, squareMarkerLengthRate,
        *diamondCorners, *diamondIds, entity(cameraMatrix), entity(distCoeffs));
    END_WRAP
}

CVAPI(ExceptionStatus) aruco_drawDetectedDiamonds(
    cv::_InputOutputArray *image,
    cv::Point2f **corners,
    int cornerSize1,
    int *cornerSize2,
    std::vector<cv::Vec4i> *ids,
    MyCvScalar borderColor)
{
    BEGIN_WRAP
    std::vector< std::vector<cv::Point2f> > cornerVec(cornerSize1);

    for (int i = 0; i < cornerSize1; i++)
        cornerVec[i] = std::vector<cv::Point2f>(corners[i], corners[i] + cornerSize2[i]);

    cv::_InputArray idArray = (ids != nullptr) ? *ids : static_cast<cv::_InputArray>(cv::noArray());

    cv::aruco::drawDetectedDiamonds(*image, cornerVec, idArray, cpp(borderColor));
    END_WRAP
}

#endif
