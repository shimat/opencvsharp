#pragma once

#ifndef NO_CALIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

extern "C"
{
    // cv::CirclesGridFinderParameters (declared in objdetect.hpp; only consumed here by
    // findCirclesGrid, so kept local rather than shared across translation units).
    struct calib_CirclesGridFinderParameters
    {
        interop::Size2f densityNeighborhoodSize;
        float minDensity;
        int kmeansAttempts;
        int minDistanceToAddKeypoint;
        int keypointScale;
        float minGraphConfidence;
        float vertexGain;
        float vertexPenalty;
        float existingVertexGain;
        float edgeGain;
        float edgePenalty;
        float convexHullFactor;
        float minRNGEdgeSwitchDist;
        int gridType;
        float squareSize;
        float maxRectifiedDistance;
    };
}

static cv::CirclesGridFinderParameters cpp(const calib_CirclesGridFinderParameters& p)
{
    cv::CirclesGridFinderParameters pp;
    pp.densityNeighborhoodSize = cpp(p.densityNeighborhoodSize);
    pp.minDensity = p.minDensity;
    pp.kmeansAttempts = p.kmeansAttempts;
    pp.minDistanceToAddKeypoint = p.minDistanceToAddKeypoint;
    pp.keypointScale = p.keypointScale;
    pp.minGraphConfidence = p.minGraphConfidence;
    pp.vertexGain = p.vertexGain;
    pp.vertexPenalty = p.vertexPenalty;
    pp.existingVertexGain = p.existingVertexGain;
    pp.edgeGain = p.edgeGain;
    pp.edgePenalty = p.edgePenalty;
    pp.convexHullFactor = p.convexHullFactor;
    pp.minRNGEdgeSwitchDist = p.minRNGEdgeSwitchDist;
    pp.gridType = static_cast<cv::CirclesGridFinderParameters::GridType>(p.gridType);
    pp.squareSize = p.squareSize;
    pp.maxRectifiedDistance = p.maxRectifiedDistance;
    return pp;
}

CVAPI(ExceptionStatus) calib_initCameraMatrix2D_Mat(
    cv::Mat **objectPoints,
    int objectPointsLength,
    cv::Mat **imagePoints,
    int imagePointsLength,
    interop::Size imageSize,
    double aspectRatio,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        std::vector<cv::Mat> objectPointsVec(objectPointsLength);
        for (auto i = 0; i < objectPointsLength; i++)
            objectPointsVec[i] = *objectPoints[i];
        std::vector<cv::Mat> imagePointsVec(imagePointsLength);
        for (auto i = 0; i < imagePointsLength; i++)
            imagePointsVec[i] = *imagePoints[i];

        const auto ret = cv::initCameraMatrix2D(objectPointsVec, imagePointsVec, cpp(imageSize), aspectRatio);
        *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) calib_initCameraMatrix2D_array(
    cv::Point3f **objectPoints,
    int opSize1,
    int *opSize2,
    cv::Point2f **imagePoints,
    int ipSize1,
    int *ipSize2,
    interop::Size imageSize,
    double aspectRatio,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        std::vector<std::vector<cv::Point3f> > objectPointsVec(opSize1);
        for (auto i = 0; i < opSize1; i++)
            objectPointsVec[i] = std::vector<cv::Point3f>(objectPoints[i], objectPoints[i] + opSize2[i]);
        std::vector<std::vector<cv::Point2f> > imagePointsVec(ipSize1);
        for (auto i = 0; i < ipSize1; i++)
            imagePointsVec[i] = std::vector<cv::Point2f>(imagePoints[i], imagePoints[i] + ipSize2[i]);

        const auto ret = cv::initCameraMatrix2D(objectPointsVec, imagePointsVec, cpp(imageSize), aspectRatio);
        *returnValue = new cv::Mat(ret);
    });
}


CVAPI(ExceptionStatus) calib_findChessboardCorners_InputArray(
    const interop::InputArrayProxy* image,
    interop::Size patternSize,
    const interop::OutputArrayProxy* corners,
    int flags,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::findChessboardCorners(InProxy(*image), cpp(patternSize), OutProxy(*corners), flags) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) calib_findChessboardCorners_vector(
    const interop::InputArrayProxy* image,
    interop::Size patternSize,
    std::vector<cv::Point2f> *corners,
    int flags,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::findChessboardCorners(InProxy(*image), cpp(patternSize), *corners, flags) ? 1 : 0;
    });
}



static void BlobDetectorDeleter(cv::FeatureDetector *) {}

CVAPI(ExceptionStatus) calib_findCirclesGrid_InputArray(
    const interop::InputArrayProxy* image,
    interop::Size patternSize,
    const interop::OutputArrayProxy* centers,
    int flags,
    cv::FeatureDetector* blobDetector,
    int *returnValue)
{
    return cvTry([&] {
        if (blobDetector == nullptr)
        {
            *returnValue = cv::findCirclesGrid(InProxy(*image), cpp(patternSize), OutProxy(*centers), flags) ? 1 : 0;
        }
        else
        {
            const cv::Ptr<cv::FeatureDetector> detectorPtr(blobDetector, BlobDetectorDeleter); // don't delete
            *returnValue = cv::findCirclesGrid(InProxy(*image), cpp(patternSize), OutProxy(*centers), flags, detectorPtr) ? 1 : 0;
        }
    });
}

CVAPI(ExceptionStatus) calib_findCirclesGrid_vector(
    const interop::InputArrayProxy* image,
    interop::Size patternSize,
    std::vector<cv::Point2f> *centers,
    int flags,
    cv::FeatureDetector* blobDetector,
    int *returnValue)
{
    return cvTry([&] {
        if (blobDetector == nullptr)
        {
            *returnValue = cv::findCirclesGrid(InProxy(*image), cpp(patternSize), *centers, flags) ? 1 : 0;
        }
        else
        {
            const cv::Ptr<cv::FeatureDetector> detectorPtr(blobDetector, BlobDetectorDeleter); // don't delete
            *returnValue = cv::findCirclesGrid(InProxy(*image), cpp(patternSize), *centers, flags, detectorPtr) ? 1 : 0;
        }
    });
}

CVAPI(ExceptionStatus) calib_findCirclesGrid_InputArray_Params(
    const interop::InputArrayProxy* image,
    interop::Size patternSize,
    const interop::OutputArrayProxy* centers,
    int flags,
    cv::FeatureDetector* blobDetector,
    const calib_CirclesGridFinderParameters* parameters,
    int *returnValue)
{
    return cvTry([&] {
        cv::Ptr<cv::FeatureDetector> detectorPtr;
        if (blobDetector == nullptr)
            detectorPtr = cv::SimpleBlobDetector::create();
        else
            detectorPtr = cv::Ptr<cv::FeatureDetector>(blobDetector, BlobDetectorDeleter); // don't delete
        *returnValue = cv::findCirclesGrid(
            InProxy(*image), cpp(patternSize), OutProxy(*centers), flags, detectorPtr, cpp(*parameters)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) calib_findCirclesGrid_vector_Params(
    const interop::InputArrayProxy* image,
    interop::Size patternSize,
    std::vector<cv::Point2f> *centers,
    int flags,
    cv::FeatureDetector* blobDetector,
    const calib_CirclesGridFinderParameters* parameters,
    int *returnValue)
{
    return cvTry([&] {
        cv::Ptr<cv::FeatureDetector> detectorPtr;
        if (blobDetector == nullptr)
            detectorPtr = cv::SimpleBlobDetector::create();
        else
            detectorPtr = cv::Ptr<cv::FeatureDetector>(blobDetector, BlobDetectorDeleter); // don't delete
        *returnValue = cv::findCirclesGrid(
            InProxy(*image), cpp(patternSize), *centers, flags, detectorPtr, cpp(*parameters)) ? 1 : 0;
    });
}


CVAPI(ExceptionStatus) calib_calibrateCamera_InputArray(
    cv::Mat **objectPoints,
    int objectPointsSize,
    cv::Mat **imagePoints,
    int imagePointsSize,
    interop::Size imageSize,
    const interop::InputOutputArrayProxy* cameraMatrix,
    const interop::InputOutputArrayProxy* distCoeffs,
    std::vector<cv::Mat> *rvecs,
    std::vector<cv::Mat> *tvecs,
    int flags,
    interop::TermCriteria criteria,
    double *returnValue)
{
    return cvTry([&] {
        std::vector<cv::Mat> objectPointsVec(objectPointsSize);
        for (auto i = 0; i < objectPointsSize; i++)
            objectPointsVec[i] = *objectPoints[i];
        std::vector<cv::Mat> imagePointsVec(imagePointsSize);
        for (auto i = 0; i < imagePointsSize; i++)
            imagePointsVec[i] = *imagePoints[i];

        *returnValue = cv::calibrateCamera(objectPointsVec, imagePointsVec, cpp(imageSize),
            IoProxy(*cameraMatrix), IoProxy(*distCoeffs), *rvecs, *tvecs, flags, cpp(criteria));
    });
}

CVAPI(ExceptionStatus) calib_calibrateCameraRO_InputArray(
    cv::Mat **objectPoints,
    int objectPointsSize,
    cv::Mat **imagePoints,
    int imagePointsSize,
    interop::Size imageSize,
    int iFixedPoint,
    const interop::InputOutputArrayProxy* cameraMatrix,
    const interop::InputOutputArrayProxy* distCoeffs,
    std::vector<cv::Mat> *rvecs,
    std::vector<cv::Mat> *tvecs,
    const interop::OutputArrayProxy* newObjPoints,
    int flags,
    interop::TermCriteria criteria,
    double *returnValue)
{
    return cvTry([&] {
        std::vector<cv::Mat> objectPointsVec(objectPointsSize);
        for (auto i = 0; i < objectPointsSize; i++)
            objectPointsVec[i] = *objectPoints[i];
        std::vector<cv::Mat> imagePointsVec(imagePointsSize);
        for (auto i = 0; i < imagePointsSize; i++)
            imagePointsVec[i] = *imagePoints[i];

        *returnValue = cv::calibrateCameraRO(objectPointsVec, imagePointsVec, cpp(imageSize), iFixedPoint,
            IoProxy(*cameraMatrix), IoProxy(*distCoeffs), *rvecs, *tvecs, OutProxy(*newObjPoints), flags, cpp(criteria));
    });
}

CVAPI(ExceptionStatus) calib_calibrateCamera_vector(
    cv::Point3f **objectPoints,
    int opSize1,
    int *opSize2,
    cv::Point2f **imagePoints,
    int ipSize1,
    int *ipSize2,
    interop::Size imageSize,
    double *cameraMatrix,
    double *distCoeffs,
    int distCoeffsSize,
    std::vector<cv::Mat> *rvecs,
    std::vector<cv::Mat> *tvecs,
    int flags,
    interop::TermCriteria criteria,
    double *returnValue)
{
    return cvTry([&] {
        std::vector<std::vector<cv::Point3f> > objectPointsVec(opSize1);
        for (auto i = 0; i < opSize1; i++)
            objectPointsVec[i] = std::vector<cv::Point3f>(objectPoints[i], objectPoints[i] + opSize2[i]);

        std::vector<std::vector<cv::Point2f> > imagePointsVec(ipSize1);
        for (auto i = 0; i < ipSize1; i++)
            imagePointsVec[i] = std::vector<cv::Point2f>(imagePoints[i], imagePoints[i] + ipSize2[i]);

        cv::Mat cametaMatrixM(3, 3, CV_64FC1, cameraMatrix);
        cv::Mat distCoeffsM(distCoeffsSize, 1, CV_64FC1, distCoeffs);

        *returnValue = cv::calibrateCamera(objectPointsVec, imagePointsVec, cpp(imageSize),
            cametaMatrixM, distCoeffsM, *rvecs, *tvecs, flags, cpp(criteria));
    });
}


CVAPI(ExceptionStatus) calib_stereoCalibrate_InputArray(
    cv::Mat **objectPoints, int opSize,
    cv::Mat **imagePoints1, int ip1Size,
    cv::Mat **imagePoints2, int ip2Size,
    const interop::InputOutputArrayProxy* cameraMatrix1,
    const interop::InputOutputArrayProxy* distCoeffs1,
    const interop::InputOutputArrayProxy* cameraMatrix2,
    const interop::InputOutputArrayProxy* distCoeffs2,
    interop::Size imageSize,
    const interop::OutputArrayProxy* R,
    const interop::OutputArrayProxy* T,
    const interop::OutputArrayProxy* E,
    const interop::OutputArrayProxy* F,
    int flags,
    interop::TermCriteria criteria,
    double *returnValue)
{
    return cvTry([&] {
        std::vector<cv::Mat> objectPointsVec(opSize);
        std::vector<cv::Mat> imagePoints1Vec(ip1Size);
        std::vector<cv::Mat> imagePoints2Vec(ip2Size);
        for (auto i = 0; i < opSize; i++)
            objectPointsVec[i] = *objectPoints[i];
        for (auto i = 0; i < ip1Size; i++)
            imagePoints1Vec[i] = *imagePoints1[i];
        for (auto i = 0; i < ip2Size; i++)
            imagePoints2Vec[i] = *imagePoints2[i];

        *returnValue = cv::stereoCalibrate(objectPointsVec, imagePoints1Vec, imagePoints2Vec,
            IoProxy(*cameraMatrix1), IoProxy(*distCoeffs1),
            IoProxy(*cameraMatrix2), IoProxy(*distCoeffs2),
            cpp(imageSize), OutProxy(*R), OutProxy(*T), OutProxy(*E), OutProxy(*F), flags, cpp(criteria));
    });
}

CVAPI(ExceptionStatus) calib_stereoCalibrate_array(
    cv::Point3f **objectPoints,
    int opSize1,
    int *opSizes2,
    cv::Point2f **imagePoints1,
    int ip1Size1,
    int *ip1Sizes2,
    cv::Point2f **imagePoints2,
    int ip2Size1,
    int *ip2Sizes2,
    double *cameraMatrix1,
    double *distCoeffs1,
    int dc1Size,
    double *cameraMatrix2,
    double *distCoeffs2,
    int dc2Size,
    interop::Size imageSize,
    const interop::OutputArrayProxy* R,
    const interop::OutputArrayProxy* T,
    const interop::OutputArrayProxy* E,
    const interop::OutputArrayProxy* F,
    int flags,
    interop::TermCriteria criteria,
    double *returnValue)
{
    return cvTry([&] {
        std::vector<std::vector<cv::Point3f> > objectPointsVec(opSize1);
        std::vector<std::vector<cv::Point2f> > imagePoints1Vec(ip1Size1);
        std::vector<std::vector<cv::Point2f> > imagePoints2Vec(ip2Size1);
        for (auto i = 0; i < opSize1; i++)
            objectPointsVec[i] = std::vector<cv::Point3f>(
            objectPoints[i], objectPoints[i] + opSizes2[i]);
        for (auto i = 0; i < ip1Size1; i++)
            imagePoints1Vec[i] = std::vector<cv::Point2f>(
            imagePoints1[i], imagePoints1[i] + ip1Sizes2[i]);
        for (auto i = 0; i < ip2Size1; i++)
            imagePoints2Vec[i] = std::vector<cv::Point2f>(
            imagePoints2[i], imagePoints2[i] + ip2Sizes2[i]);

        cv::Mat cameraMatrix1M(3, 3, CV_64FC1, cameraMatrix1);
        cv::Mat cameraMatrix2M(3, 3, CV_64FC1, cameraMatrix2);
        cv::Mat distCoeffs1M(dc1Size, 1, CV_64FC1, distCoeffs1);
        cv::Mat distCoeffs2M(dc2Size, 1, CV_64FC1, distCoeffs2);

        *returnValue = cv::stereoCalibrate(objectPointsVec, imagePoints1Vec, imagePoints2Vec,
            cameraMatrix1M, distCoeffs1M,
            cameraMatrix2M, distCoeffs2M,
            cpp(imageSize), OutProxy(*R), OutProxy(*T), OutProxy(*E), OutProxy(*F), flags, cpp(criteria));
    });
}


CVAPI(ExceptionStatus) calib_calibrateHandEye(
    cv::Mat **R_gripper2baseMats,
    const int32_t R_gripper2baseMatsSize,
    cv::Mat **t_gripper2baseMats,
    const int32_t t_gripper2baseMatsSize,
    cv::Mat **R_target2camMats,
    const int32_t R_target2camMatsSize,
    cv::Mat **t_target2camMats,
    const int32_t t_target2camMatsSize,
    const interop::OutputArrayProxy* R_cam2gripper,
    const interop::OutputArrayProxy* t_cam2gripper,
    int32_t method)
{
    return cvTry([&] {
        std::vector<cv::Mat> R_gripper2base;
        std::vector<cv::Mat> t_gripper2base;
        std::vector<cv::Mat> R_target2cam;
        std::vector<cv::Mat> t_target2cam;
        toVec(R_gripper2baseMats, R_gripper2baseMatsSize, R_gripper2base);
        toVec(t_gripper2baseMats, t_gripper2baseMatsSize, t_gripper2base);
        toVec(R_target2camMats, R_target2camMatsSize, R_target2cam);
        toVec(t_target2camMats, t_target2camMatsSize, t_target2cam);
        cv::calibrateHandEye(
            R_gripper2base, t_gripper2base, 
            R_target2cam, t_target2cam, 
            OutProxy(*R_cam2gripper), OutProxy(*t_cam2gripper),
            static_cast<cv::HandEyeCalibrationMethod>(method));
    });    
}


/*
static void calibrateRobotWorldHandEyeShah(const std::vector<Mat_<double>>& cRw, const std::vector<Mat_<double>>& ctw,
                                           const std::vector<Mat_<double>>& gRb, const std::vector<Mat_<double>>& gtb,
                                           Matx33d& wRb, Matx31d& wtb, Matx33d& cRg, Matx31d& ctg)
static void calibrateRobotWorldHandEyeLi(const std::vector<Mat_<double>>& cRw, const std::vector<Mat_<double>>& ctw,
    const std::vector<Mat_<double>>& gRb, const std::vector<Mat_<double>>& gtb,
    Matx33d& wRb, Matx31d& wtb, Matx33d& cRg, Matx31d& ctg)
 */
CVAPI(ExceptionStatus) calib_calibrateRobotWorldHandEye_OutputArray(
    cv::Mat** R_world2camMats,
    int32_t R_world2camMatsSize,
    cv::Mat** t_world2camMats,
    int32_t t_world2camMatsSize,
    cv::Mat** R_base2gripperMats,
    int32_t R_base2gripperMatsSize,
    cv::Mat** t_base2gripperMats,
    int32_t t_base2gripperMatsSize,
    const interop::OutputArrayProxy* R_base2world,
    const interop::OutputArrayProxy* t_base2world,
    const interop::OutputArrayProxy* R_gripper2cam,
    const interop::OutputArrayProxy* t_gripper2cam,
    int32_t method)
{
    return cvTry([&] {
        std::vector<cv::Mat> R_gripper2base;
        std::vector<cv::Mat> t_gripper2base;
        std::vector<cv::Mat> R_target2cam;
        std::vector<cv::Mat> t_target2cam;
        toVec(R_world2camMats, R_world2camMatsSize, R_gripper2base);
        toVec(t_world2camMats, t_world2camMatsSize, t_gripper2base);
        toVec(R_base2gripperMats, R_base2gripperMatsSize, R_target2cam);
        toVec(t_base2gripperMats, t_base2gripperMatsSize, t_target2cam);
        cv::calibrateRobotWorldHandEye(
            R_gripper2base, t_gripper2base,
            R_target2cam, t_target2cam,
            OutProxy(*R_base2world), OutProxy(*t_base2world),
            OutProxy(*R_gripper2cam), OutProxy(*t_gripper2cam),
            static_cast<cv::RobotWorldHandEyeCalibrationMethod>(method));
    });
}


CVAPI(ExceptionStatus) calib_calibrateRobotWorldHandEye_Pointer(
    cv::Mat** R_world2camMats,
    int32_t R_world2camMatsSize,
    cv::Mat** t_world2camMats,
    int32_t t_world2camMatsSize,
    cv::Mat** R_base2gripperMats,
    int32_t R_base2gripperMatsSize,
    cv::Mat** t_base2gripperMats,
    int32_t t_base2gripperMatsSize,
    double* R_base2world,
    double* t_base2world,
    double* R_gripper2cam,
    double* t_gripper2cam,
    int32_t method)
{
    return cvTry([&] {
        std::vector<cv::Mat> R_gripper2base;
        std::vector<cv::Mat> t_gripper2base;
        std::vector<cv::Mat> R_target2cam;
        std::vector<cv::Mat> t_target2cam;
        toVec(R_world2camMats, R_world2camMatsSize, R_gripper2base);
        toVec(t_world2camMats, t_world2camMatsSize, t_gripper2base);
        toVec(R_base2gripperMats, R_base2gripperMatsSize, R_target2cam);
        toVec(t_base2gripperMats, t_base2gripperMatsSize, t_target2cam);
        cv::Matx33d R_base2worldM;
        cv::Matx31d t_base2worldM;
        cv::Matx33d R_gripper2camM;
        cv::Matx31d t_gripper2camM;
        cv::calibrateRobotWorldHandEye(
            R_gripper2base, t_gripper2base,
            R_target2cam, t_target2cam,
            R_base2worldM, t_base2worldM,
            R_gripper2camM, t_gripper2camM,
            static_cast<cv::RobotWorldHandEyeCalibrationMethod>(method));

        std::memcpy(R_base2world, R_base2worldM.val, 9 * sizeof(double));
        std::memcpy(t_base2world, t_base2worldM.val, 3 * sizeof(double));
        std::memcpy(R_gripper2cam, R_gripper2camM.val, 9 * sizeof(double));
        std::memcpy(t_gripper2cam, t_gripper2camM.val, 3 * sizeof(double));

    });
}

#endif // NO_CALIB
