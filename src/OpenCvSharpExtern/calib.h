#pragma once

#ifndef NO_CALIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) calib_initCameraMatrix2D_Mat(
    cv::Mat **objectPoints, int objectPointsLength,
    cv::Mat **imagePoints, int imagePointsLength, 
    MyCvSize imageSize, double aspectRatio,
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    std::vector<cv::Mat> objectPointsVec(objectPointsLength);
    for (auto i = 0; i < objectPointsLength; i++)
        objectPointsVec[i] = *objectPoints[i];
    std::vector<cv::Mat> imagePointsVec(imagePointsLength);
    for (auto i = 0; i < objectPointsLength; i++)
        imagePointsVec[i] = *imagePoints[i];

    const auto ret = cv::initCameraMatrix2D(objectPointsVec, imagePointsVec, cpp(imageSize), aspectRatio);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) calib_initCameraMatrix2D_array(
    cv::Point3f **objectPoints, int opSize1, int *opSize2,
    cv::Point2f **imagePoints, int ipSize1, int *ipSize2, MyCvSize imageSize, double aspectRatio,
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    std::vector<std::vector<cv::Point3f> > objectPointsVec(opSize1);
    for (auto i = 0; i < opSize1; i++)
        objectPointsVec[i] = std::vector<cv::Point3f>(objectPoints[i], objectPoints[i] + opSize2[i]);
    std::vector<std::vector<cv::Point2f> > imagePointsVec(ipSize1);
    for (auto i = 0; i < ipSize1; i++)
        imagePointsVec[i] = std::vector<cv::Point2f>(imagePoints[i], imagePoints[i] + ipSize2[i]);

    const auto ret = cv::initCameraMatrix2D(objectPointsVec, imagePointsVec, cpp(imageSize), aspectRatio);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}


CVAPI(ExceptionStatus) calib_findChessboardCorners_InputArray(
    cv::_InputArray *image, MyCvSize patternSize,
    cv::_OutputArray *corners, int flags, 
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::findChessboardCorners(*image, cpp(patternSize), *corners, flags) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) calib_findChessboardCorners_vector(
    cv::_InputArray *image, MyCvSize patternSize,
    std::vector<cv::Point2f> *corners, int flags, 
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::findChessboardCorners(*image, cpp(patternSize), *corners, flags) ? 1 : 0;
    END_WRAP
}



static void BlobDetectorDeleter(cv::FeatureDetector *) {}

CVAPI(ExceptionStatus) calib_findCirclesGrid_InputArray(
    cv::_InputArray *image, MyCvSize patternSize,
    cv::_OutputArray *centers, int flags, cv::FeatureDetector* blobDetector,
    int *returnValue)
{
    BEGIN_WRAP
    if (blobDetector == nullptr)
    {
        *returnValue = cv::findCirclesGrid(*image, cpp(patternSize), *centers, flags) ? 1 : 0;
    }
    else
    {
        const cv::Ptr<cv::FeatureDetector> detectorPtr(blobDetector, BlobDetectorDeleter); // don't delete
        *returnValue = cv::findCirclesGrid(*image, cpp(patternSize), *centers, flags, detectorPtr) ? 1 : 0;
    }
    END_WRAP
}

CVAPI(ExceptionStatus) calib_findCirclesGrid_vector(
    cv::_InputArray *image, MyCvSize patternSize,
    std::vector<cv::Point2f> *centers, int flags, cv::FeatureDetector* blobDetector,
    int *returnValue)
{
    BEGIN_WRAP
    if (blobDetector == nullptr)
    {
        *returnValue = cv::findCirclesGrid(*image, cpp(patternSize), *centers, flags) ? 1 : 0;
    }
    else
    {
        const cv::Ptr<cv::FeatureDetector> detectorPtr(blobDetector, BlobDetectorDeleter); // don't delete
        *returnValue = cv::findCirclesGrid(*image, cpp(patternSize), *centers, flags, detectorPtr) ? 1 : 0;
    }
    END_WRAP
}


CVAPI(ExceptionStatus) calib_calibrateCamera_InputArray(
    cv::Mat **objectPoints, int objectPointsSize,
    cv::Mat **imagePoints, int imagePointsSize,
    MyCvSize imageSize,
    cv::_InputOutputArray *cameraMatrix,
    cv::_InputOutputArray *distCoeffs,
    std::vector<cv::Mat> *rvecs, std::vector<cv::Mat> *tvecs,
    int flags,
    MyCvTermCriteria criteria,
    double *returnValue)
{
    BEGIN_WRAP
    std::vector<cv::Mat> objectPointsVec(objectPointsSize);
    for (auto i = 0; i < objectPointsSize; i++)
        objectPointsVec[i] = *objectPoints[i];
    std::vector<cv::Mat> imagePointsVec(imagePointsSize);
    for (auto i = 0; i < imagePointsSize; i++)
        imagePointsVec[i] = *imagePoints[i];

    *returnValue = cv::calibrateCamera(objectPointsVec, imagePointsVec, cpp(imageSize),
        *cameraMatrix, *distCoeffs, *rvecs, *tvecs, flags, cpp(criteria));
    END_WRAP
}

CVAPI(ExceptionStatus) calib_calibrateCamera_vector(
    cv::Point3f **objectPoints, int opSize1, int *opSize2,
    cv::Point2f **imagePoints, int ipSize1, int *ipSize2,
    MyCvSize imageSize,
    double *cameraMatrix,
    double *distCoeffs, int distCoeffsSize,
    std::vector<cv::Mat> *rvecs, std::vector<cv::Mat> *tvecs,
    int flags,
    MyCvTermCriteria criteria,
    double *returnValue)
{
    BEGIN_WRAP
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
    END_WRAP
}


CVAPI(ExceptionStatus) calib_stereoCalibrate_InputArray(
    cv::_InputArray **objectPoints, int opSize,
    cv::_InputArray **imagePoints1, int ip1Size,
    cv::_InputArray **imagePoints2, int ip2Size,
    cv::_InputOutputArray *cameraMatrix1,
    cv::_InputOutputArray *distCoeffs1,
    cv::_InputOutputArray *cameraMatrix2,
    cv::_InputOutputArray *distCoeffs2,
    MyCvSize imageSize,
    cv::_OutputArray *R, cv::_OutputArray *T,
    cv::_OutputArray *E, cv::_OutputArray *F,
    int flags, 
    MyCvTermCriteria criteria,
    double *returnValue)
{
    BEGIN_WRAP
    std::vector<cv::Mat> objectPointsVec(opSize);
    std::vector<cv::Mat> imagePoints1Vec(ip1Size);
    std::vector<cv::Mat> imagePoints2Vec(ip2Size);
    for (auto i = 0; i < opSize; i++)
        objectPointsVec[i] = objectPoints[i]->getMat();
    for (auto i = 0; i < ip1Size; i++)
        imagePoints1Vec[i] = imagePoints1[i]->getMat();
    for (auto i = 0; i < ip2Size; i++)
        imagePoints2Vec[i] = imagePoints2[i]->getMat();

    *returnValue = cv::stereoCalibrate(objectPointsVec, imagePoints1Vec, imagePoints2Vec,
        *cameraMatrix1, *distCoeffs1,
        *cameraMatrix2, *distCoeffs2,
        cpp(imageSize), entity(R), entity(T), entity(E), entity(F), flags, cpp(criteria));
    END_WRAP
}

CVAPI(ExceptionStatus) calib_stereoCalibrate_Mat(
    cv::Mat **objectPoints, int opSize,
    cv::Mat **imagePoints1, int ip1Size,
    cv::Mat **imagePoints2, int ip2Size,
    cv::Mat *cameraMatrix1,
    cv::Mat *distCoeffs1,
    cv::Mat *cameraMatrix2,
    cv::Mat *distCoeffs2,
    MyCvSize imageSize,
    cv::Mat *R, cv::Mat *T,
    cv::Mat *E, cv::Mat *F,
    int flags,
    MyCvTermCriteria criteria,
    double *returnValue)
{
    BEGIN_WRAP
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
        *cameraMatrix1, *distCoeffs1,
        *cameraMatrix2, *distCoeffs2,
        cpp(imageSize), *R, *T, *E, *F, flags, cpp(criteria));
    END_WRAP
}

CVAPI(ExceptionStatus) calib_stereoCalibrate_array(
    cv::Point3f **objectPoints, int opSize1, int *opSizes2,
    cv::Point2f **imagePoints1, int ip1Size1, int *ip1Sizes2,
    cv::Point2f **imagePoints2, int ip2Size1, int *ip2Sizes2,
    double *cameraMatrix1,
    double *distCoeffs1, int dc1Size,
    double *cameraMatrix2,
    double *distCoeffs2, int dc2Size,
    MyCvSize imageSize,
    cv::_OutputArray *R, cv::_OutputArray *T,
    cv::_OutputArray *E, cv::_OutputArray *F,
    int flags, 
    MyCvTermCriteria criteria,
    double *returnValue)
{
    BEGIN_WRAP
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
        cpp(imageSize), entity(R), entity(T), entity(E), entity(F), flags, cpp(criteria));
    END_WRAP
}


CVAPI(ExceptionStatus) calib_calibrateHandEye(
    cv::Mat **R_gripper2baseMats, const int32_t R_gripper2baseMatsSize,
    cv::Mat **t_gripper2baseMats, const int32_t t_gripper2baseMatsSize,
    cv::Mat **R_target2camMats, const int32_t R_target2camMatsSize,
    cv::Mat **t_target2camMats, const int32_t t_target2camMatsSize,
    cv::_OutputArray *R_cam2gripper, 
    cv::_OutputArray *t_cam2gripper,
    int32_t method)
{
    BEGIN_WRAP
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
        *R_cam2gripper, *t_cam2gripper,
        static_cast<cv::HandEyeCalibrationMethod>(method));
    END_WRAP    
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
    cv::Mat** R_world2camMats, int32_t R_world2camMatsSize,
    cv::Mat** t_world2camMats, int32_t t_world2camMatsSize,
    cv::Mat** R_base2gripperMats, int32_t R_base2gripperMatsSize,
    cv::Mat** t_base2gripperMats, int32_t t_base2gripperMatsSize,
    cv::_OutputArray* R_base2world, cv::_OutputArray* t_base2world,
    cv::_OutputArray* R_gripper2cam, cv::_OutputArray* t_gripper2cam,
    int32_t method)
{
    BEGIN_WRAP
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
        *R_base2world, *t_base2world,
        *R_gripper2cam, *t_gripper2cam,
        static_cast<cv::RobotWorldHandEyeCalibrationMethod>(method));
    END_WRAP
}


CVAPI(ExceptionStatus) calib_calibrateRobotWorldHandEye_Pointer(
    cv::Mat** R_world2camMats, int32_t R_world2camMatsSize,
    cv::Mat** t_world2camMats, int32_t t_world2camMatsSize,
    cv::Mat** R_base2gripperMats, int32_t R_base2gripperMatsSize,
    cv::Mat** t_base2gripperMats, int32_t t_base2gripperMatsSize,
    double* R_base2world, double* t_base2world,
    double* R_gripper2cam, double* t_gripper2cam,
    int32_t method)
{
    BEGIN_WRAP
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

    END_WRAP
}

#endif // NO_CALIB
