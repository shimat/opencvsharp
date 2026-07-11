#pragma once

#ifndef NO_OBJDETECT

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#ifndef _WINRT_DLL

#pragma region QRCodeDetectorAruco

extern "C"
{
    struct objdetect_QRCodeDetectorAruco_Params
    {
        float minModuleSizeInPyramid;
        float maxRotation;
        float maxModuleSizeMismatch;
        float maxTimingPatternMismatch;
        float maxPenalties;
        float maxColorsMismatch;
        float scaleTimingPatternScore;
    };

    // Mirrors cv::aruco::DetectorParameters (see aruco.h's aruco_DetectorParameters). Kept as an
    // independent local copy so this file has no compile-time dependency on aruco.h/NO_CONTRIB.
    struct objdetect_ArucoDetectorParams
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
        float minGroupDistance;
        int cornerRefinementMethod;
        int cornerRefinementWinSize;
        float relativeCornerRefinmentWinSize;
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
        int aprilTagMinWhiteBlackDiff;
        int aprilTagDeglitch;
        bool detectInvertedMarker;
        bool useAruco3Detection;
        int minSideLengthCanonicalImg;
        float minMarkerLengthRatioOriginalImg;
    };
}

static cv::QRCodeDetectorAruco::Params cpp(const objdetect_QRCodeDetectorAruco_Params& p)
{
    cv::QRCodeDetectorAruco::Params pp;
    pp.minModuleSizeInPyramid = p.minModuleSizeInPyramid;
    pp.maxRotation = p.maxRotation;
    pp.maxModuleSizeMismatch = p.maxModuleSizeMismatch;
    pp.maxTimingPatternMismatch = p.maxTimingPatternMismatch;
    pp.maxPenalties = p.maxPenalties;
    pp.maxColorsMismatch = p.maxColorsMismatch;
    pp.scaleTimingPatternScore = p.scaleTimingPatternScore;
    return pp;
}

static objdetect_QRCodeDetectorAruco_Params c(const cv::QRCodeDetectorAruco::Params& pp)
{
    objdetect_QRCodeDetectorAruco_Params p{};
    p.minModuleSizeInPyramid = pp.minModuleSizeInPyramid;
    p.maxRotation = pp.maxRotation;
    p.maxModuleSizeMismatch = pp.maxModuleSizeMismatch;
    p.maxTimingPatternMismatch = pp.maxTimingPatternMismatch;
    p.maxPenalties = pp.maxPenalties;
    p.maxColorsMismatch = pp.maxColorsMismatch;
    p.scaleTimingPatternScore = pp.scaleTimingPatternScore;
    return p;
}

static cv::aruco::DetectorParameters cpp(const objdetect_ArucoDetectorParams& p)
{
    cv::aruco::DetectorParameters pp;
    pp.adaptiveThreshWinSizeMin = p.adaptiveThreshWinSizeMin;
    pp.adaptiveThreshWinSizeMax = p.adaptiveThreshWinSizeMax;
    pp.adaptiveThreshWinSizeStep = p.adaptiveThreshWinSizeStep;
    pp.adaptiveThreshConstant = p.adaptiveThreshConstant;
    pp.minMarkerPerimeterRate = p.minMarkerPerimeterRate;
    pp.maxMarkerPerimeterRate = p.maxMarkerPerimeterRate;
    pp.polygonalApproxAccuracyRate = p.polygonalApproxAccuracyRate;
    pp.minCornerDistanceRate = p.minCornerDistanceRate;
    pp.minDistanceToBorder = p.minDistanceToBorder;
    pp.minMarkerDistanceRate = p.minMarkerDistanceRate;
    pp.minGroupDistance = p.minGroupDistance;
    pp.cornerRefinementMethod = static_cast<cv::aruco::CornerRefineMethod>(p.cornerRefinementMethod);
    pp.cornerRefinementWinSize = p.cornerRefinementWinSize;
    pp.relativeCornerRefinmentWinSize = p.relativeCornerRefinmentWinSize;
    pp.cornerRefinementMaxIterations = p.cornerRefinementMaxIterations;
    pp.cornerRefinementMinAccuracy = p.cornerRefinementMinAccuracy;
    pp.markerBorderBits = p.markerBorderBits;
    pp.perspectiveRemovePixelPerCell = p.perspectiveRemovePixelPerCell;
    pp.perspectiveRemoveIgnoredMarginPerCell = p.perspectiveRemoveIgnoredMarginPerCell;
    pp.maxErroneousBitsInBorderRate = p.maxErroneousBitsInBorderRate;
    pp.minOtsuStdDev = p.minOtsuStdDev;
    pp.errorCorrectionRate = p.errorCorrectionRate;
    pp.aprilTagQuadDecimate = p.aprilTagQuadDecimate;
    pp.aprilTagQuadSigma = p.aprilTagQuadSigma;
    pp.aprilTagMinClusterPixels = p.aprilTagMinClusterPixels;
    pp.aprilTagMaxNmaxima = p.aprilTagMaxNmaxima;
    pp.aprilTagCriticalRad = p.aprilTagCriticalRad;
    pp.aprilTagMaxLineFitMse = p.aprilTagMaxLineFitMse;
    pp.aprilTagDeglitch = p.aprilTagDeglitch;
    pp.aprilTagMinWhiteBlackDiff = p.aprilTagMinWhiteBlackDiff;
    pp.detectInvertedMarker = p.detectInvertedMarker;
    pp.useAruco3Detection = p.useAruco3Detection;
    pp.minSideLengthCanonicalImg = p.minSideLengthCanonicalImg;
    pp.minMarkerLengthRatioOriginalImg = p.minMarkerLengthRatioOriginalImg;
    return pp;
}

static objdetect_ArucoDetectorParams c(const cv::aruco::DetectorParameters& pp)
{
    objdetect_ArucoDetectorParams p{};
    p.adaptiveThreshWinSizeMin = pp.adaptiveThreshWinSizeMin;
    p.adaptiveThreshWinSizeMax = pp.adaptiveThreshWinSizeMax;
    p.adaptiveThreshWinSizeStep = pp.adaptiveThreshWinSizeStep;
    p.adaptiveThreshConstant = pp.adaptiveThreshConstant;
    p.minMarkerPerimeterRate = pp.minMarkerPerimeterRate;
    p.maxMarkerPerimeterRate = pp.maxMarkerPerimeterRate;
    p.polygonalApproxAccuracyRate = pp.polygonalApproxAccuracyRate;
    p.minCornerDistanceRate = pp.minCornerDistanceRate;
    p.minDistanceToBorder = pp.minDistanceToBorder;
    p.minMarkerDistanceRate = pp.minMarkerDistanceRate;
    p.minGroupDistance = pp.minGroupDistance;
    p.cornerRefinementMethod = static_cast<int>(pp.cornerRefinementMethod);
    p.cornerRefinementWinSize = pp.cornerRefinementWinSize;
    p.relativeCornerRefinmentWinSize = pp.relativeCornerRefinmentWinSize;
    p.cornerRefinementMaxIterations = pp.cornerRefinementMaxIterations;
    p.cornerRefinementMinAccuracy = pp.cornerRefinementMinAccuracy;
    p.markerBorderBits = pp.markerBorderBits;
    p.perspectiveRemovePixelPerCell = pp.perspectiveRemovePixelPerCell;
    p.perspectiveRemoveIgnoredMarginPerCell = pp.perspectiveRemoveIgnoredMarginPerCell;
    p.maxErroneousBitsInBorderRate = pp.maxErroneousBitsInBorderRate;
    p.minOtsuStdDev = pp.minOtsuStdDev;
    p.errorCorrectionRate = pp.errorCorrectionRate;
    p.aprilTagQuadDecimate = pp.aprilTagQuadDecimate;
    p.aprilTagQuadSigma = pp.aprilTagQuadSigma;
    p.aprilTagMinClusterPixels = pp.aprilTagMinClusterPixels;
    p.aprilTagMaxNmaxima = pp.aprilTagMaxNmaxima;
    p.aprilTagCriticalRad = pp.aprilTagCriticalRad;
    p.aprilTagMaxLineFitMse = pp.aprilTagMaxLineFitMse;
    p.aprilTagDeglitch = pp.aprilTagDeglitch;
    p.aprilTagMinWhiteBlackDiff = pp.aprilTagMinWhiteBlackDiff;
    p.detectInvertedMarker = pp.detectInvertedMarker;
    p.useAruco3Detection = pp.useAruco3Detection;
    p.minSideLengthCanonicalImg = pp.minSideLengthCanonicalImg;
    p.minMarkerLengthRatioOriginalImg = pp.minMarkerLengthRatioOriginalImg;
    return p;
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetectorAruco_new(cv::QRCodeDetectorAruco** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::QRCodeDetectorAruco();
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetectorAruco_new_Params(
    const objdetect_QRCodeDetectorAruco_Params* params,
    cv::QRCodeDetectorAruco** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::QRCodeDetectorAruco(cpp(*params));
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetectorAruco_delete(cv::QRCodeDetectorAruco* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetectorAruco_getDetectorParameters(
    const cv::QRCodeDetectorAruco* obj, objdetect_QRCodeDetectorAruco_Params* returnValue)
{
    return cvTry([&] {
        *returnValue = c(obj->getDetectorParameters());
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetectorAruco_setDetectorParameters(
    cv::QRCodeDetectorAruco* obj, const objdetect_QRCodeDetectorAruco_Params* params)
{
    return cvTry([&] {
        obj->setDetectorParameters(cpp(*params));
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetectorAruco_getArucoParameters(
    const cv::QRCodeDetectorAruco* obj, objdetect_ArucoDetectorParams* returnValue)
{
    return cvTry([&] {
        *returnValue = c(obj->getArucoParameters());
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetectorAruco_setArucoParameters(
    cv::QRCodeDetectorAruco* obj, const objdetect_ArucoDetectorParams* params)
{
    return cvTry([&] {
        obj->setArucoParameters(cpp(*params));
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetectorAruco_detect(
    const cv::QRCodeDetectorAruco* obj,
    const interop::InputArrayProxy* img,
    std::vector<cv::Point2f>* points,
    int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->detect(InProxy(*img), *points) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetectorAruco_decode(
    const cv::QRCodeDetectorAruco* obj,
    const interop::InputArrayProxy* img,
    std::vector<cv::Point2f>* points,
    const interop::OutputArrayProxy* straightQrCode,
    std::string* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->decode(InProxy(*img), *points, OutProxy(*straightQrCode));
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetectorAruco_detectAndDecode(
    const cv::QRCodeDetectorAruco* obj,
    const interop::InputArrayProxy* img,
    std::vector<cv::Point2f>* points,
    const interop::OutputArrayProxy* straightQrCode,
    std::string* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->detectAndDecode(InProxy(*img), *points, OutProxy(*straightQrCode));
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetectorAruco_detectMulti(
    const cv::QRCodeDetectorAruco* obj,
    const interop::InputArrayProxy* img,
    std::vector<cv::Point2f>* points,
    int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->detectMulti(InProxy(*img), *points) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetectorAruco_decodeMulti(
    const cv::QRCodeDetectorAruco* obj,
    const interop::InputArrayProxy* img,
    std::vector<cv::Point2f>* points,
    std::vector<std::string>* decodedInfo,
    std::vector<cv::Mat>* straightQrCode,
    int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->decodeMulti(InProxy(*img), *points, *decodedInfo, *straightQrCode) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetectorAruco_decodeMulti_NoStraightQrCode(
    const cv::QRCodeDetectorAruco* obj,
    const interop::InputArrayProxy* img,
    std::vector<cv::Point2f>* points,
    std::vector<std::string>* decodedInfo,
    int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->decodeMulti(InProxy(*img), *points, *decodedInfo) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetectorAruco_detectAndDecodeMulti(
    const cv::QRCodeDetectorAruco* obj,
    const interop::InputArrayProxy* img,
    std::vector<std::string>* decodedInfo,
    std::vector<cv::Point2f>* points,
    std::vector<cv::Mat>* straightQrCode,
    int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->detectAndDecodeMulti(InProxy(*img), *decodedInfo, *points, *straightQrCode) ? 1 : 0;
    });
}

#pragma endregion

#endif

#endif // NO_OBJDETECT
