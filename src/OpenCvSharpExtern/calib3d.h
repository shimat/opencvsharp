#ifndef _CPP_CALIB3D_H_
#define _CPP_CALIB3D_H_

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) calib3d_Rodrigues(cv::_InputArray *src, cv::_OutputArray *dst, cv::_OutputArray *jacobian)
{
    BEGIN_WRAP
    cv::Rodrigues(*src, *dst, entity(jacobian));
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_findHomography_InputArray(
    cv::_InputArray *srcPoints, cv::_InputArray *dstPoints,
    int method, double ransacReprojThreshold, cv::_OutputArray *mask,
    cv::Mat** returnValue)
{
    BEGIN_WRAP
    const auto ret = cv::findHomography(*srcPoints, *dstPoints, method, ransacReprojThreshold, entity(mask));
    *returnValue = new cv::Mat(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_findHomography_vector(
    cv::Point2d *srcPoints, int srcPointsLength,
    cv::Point2d *dstPoints, int dstPointsLength,
    int method, double ransacReprojThreshold, cv::_OutputArray *mask, 
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    const cv::Mat srcPointsMat(srcPointsLength, 1, CV_64FC2, srcPoints);
    const cv::Mat dstPointsMat(dstPointsLength, 1, CV_64FC2, dstPoints);

    const auto ret = cv::findHomography(srcPointsMat, dstPointsMat, method, ransacReprojThreshold, entity(mask));
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_RQDecomp3x3_InputArray(
    cv::_InputArray *src, cv::_OutputArray *mtxR, cv::_OutputArray *mtxQ,
    cv::_OutputArray *qx, cv::_OutputArray *qy, cv::_OutputArray *qz, cv::Vec3d *outVec)
{
    BEGIN_WRAP
    *outVec = cv::RQDecomp3x3(*src, *mtxR, *mtxQ, entity(qx), entity(qy), entity(qz));
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_RQDecomp3x3_Mat(
    cv::Mat *src, cv::Mat *mtxR, cv::Mat *mtxQ,
    cv::Mat *qx, cv::Mat *qy, cv::Mat *qz, cv::Vec3d *outVec)
{
    BEGIN_WRAP
    *outVec = cv::RQDecomp3x3(*src, *mtxR, *mtxQ, *qx, *qy, *qz);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_decomposeProjectionMatrix_InputArray(
    cv::_InputArray *projMatrix, cv::_OutputArray *cameraMatrix,
    cv::_OutputArray *rotMatrix, cv::_OutputArray *transVect, cv::_OutputArray *rotMatrixX,
    cv::_OutputArray *rotMatrixY, cv::_OutputArray *rotMatrixZ, cv::_OutputArray *eulerAngles)
{
    BEGIN_WRAP
    cv::decomposeProjectionMatrix(*projMatrix, *cameraMatrix, *rotMatrix,
        *transVect, entity(rotMatrixX), entity(rotMatrixY), entity(rotMatrixZ), entity(eulerAngles));
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_decomposeProjectionMatrix_Mat(
    cv::Mat *projMatrix, cv::Mat *cameraMatrix,
    cv::Mat *rotMatrix, cv::Mat *transVect, cv::Mat *rotMatrixX,
    cv::Mat *rotMatrixY, cv::Mat *rotMatrixZ, cv::Mat *eulerAngles)
{
    BEGIN_WRAP
    cv::decomposeProjectionMatrix(*projMatrix, *cameraMatrix, *rotMatrix,
        *transVect, *rotMatrixX, *rotMatrixY, *rotMatrixZ, *eulerAngles);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_matMulDeriv(
    cv::_InputArray *a, cv::_InputArray *b,
    cv::_OutputArray *dABdA, cv::_OutputArray *dABdB)
{
    BEGIN_WRAP
    cv::matMulDeriv(*a, *b, *dABdA, *dABdB);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_composeRT_InputArray(
    cv::_InputArray *rvec1, cv::_InputArray *tvec1,
    cv::_InputArray *rvec2, cv::_InputArray *tvec2,
    cv::_OutputArray *rvec3, cv::_OutputArray *tvec3,
    cv::_OutputArray *dr3dr1, cv::_OutputArray *dr3dt1,
    cv::_OutputArray *dr3dr2, cv::_OutputArray *dr3dt2,
    cv::_OutputArray *dt3dr1, cv::_OutputArray *dt3dt1,
    cv::_OutputArray *dt3dr2, cv::_OutputArray *dt3dt2)
{
    BEGIN_WRAP
    cv::composeRT(*rvec1, *tvec1, *rvec2, *tvec2, *rvec3, *tvec3,
        entity(dr3dr1), entity(dr3dt1), entity(dr3dr2), entity(dr3dt2),
        entity(dt3dr1), entity(dt3dt1), entity(dt3dr2), entity(dt3dt2));
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_composeRT_Mat(
    cv::Mat *rvec1, cv::Mat *tvec1,
    cv::Mat *rvec2, cv::Mat *tvec2,
    cv::Mat *rvec3, cv::Mat *tvec3,
    cv::Mat *dr3dr1, cv::Mat *dr3dt1,
    cv::Mat *dr3dr2, cv::Mat *dr3dt2,
    cv::Mat *dt3dr1, cv::Mat *dt3dt1,
    cv::Mat *dt3dr2, cv::Mat *dt3dt2)
{
    BEGIN_WRAP
    cv::composeRT(*rvec1, *tvec1, *rvec2, *tvec2, *rvec3, *tvec3,
        entity(dr3dr1), entity(dr3dt1), entity(dr3dr2), entity(dr3dt2),
        entity(dt3dr1), entity(dt3dt1), entity(dt3dr2), entity(dt3dt2));
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_projectPoints_InputArray(
    cv::_InputArray *objectPoints,
    cv::_InputArray *rvec, cv::_InputArray *tvec,
    cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
    cv::_OutputArray *imagePoints,
    cv::_OutputArray *jacobian,
    double aspectRatio)
{
    BEGIN_WRAP
    cv::projectPoints(*objectPoints, *rvec, *tvec, *cameraMatrix, *distCoeffs,
        *imagePoints, entity(jacobian), aspectRatio);
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_projectPoints_Mat(
    cv::Mat *objectPoints,
    cv::Mat *rvec, cv::Mat *tvec,
    cv::Mat *cameraMatrix, cv::Mat *distCoeffs,
    cv::Mat *imagePoints,
    cv::Mat *jacobian,
    double aspectRatio)
{
    BEGIN_WRAP
    cv::projectPoints(*objectPoints, *rvec, *tvec, *cameraMatrix, *distCoeffs,
        *imagePoints, *jacobian, aspectRatio);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_solvePnP_InputArray(
    cv::_InputArray *objectPoints, cv::_InputArray *imagePoints, cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
    cv::_OutputArray *rvec, cv::_OutputArray *tvec, int useExtrinsicGuess, int flags)
{
    BEGIN_WRAP
    cv::solvePnP(*objectPoints, *imagePoints, *cameraMatrix, entity(distCoeffs), *rvec, *tvec, useExtrinsicGuess != 0, flags);
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_solvePnP_vector(cv::Point3f *objectPoints, int objectPointsLength,
    cv::Point2f *imagePoints, int imagePointsLength,
    double *cameraMatrix, double *distCoeffs, int distCoeffsLength,
    double *rvec, double *tvec, int useExtrinsicGuess,
    int flags)
{
    BEGIN_WRAP
    const cv::Mat objectPointsMat(objectPointsLength, 1, CV_32FC3, objectPoints);
    const cv::Mat imagePointsMat(imagePointsLength, 1, CV_32FC2, imagePoints);
    cv::Mat distCoeffsMat;
    if (distCoeffs != nullptr)
        distCoeffsMat = cv::Mat(distCoeffsLength, 1, CV_64FC1, distCoeffs);

    const cv::Matx<double, 3, 3> cameraMatrixMat(cameraMatrix);
    cv::Matx<double, 3, 1> rvecMat, tvecMat;
    cv::solvePnP(objectPointsMat, imagePointsMat, cameraMatrixMat, distCoeffsMat, rvecMat, tvecMat, useExtrinsicGuess != 0, flags);
    memcpy(rvec, rvecMat.val, sizeof(double) * 3);
    memcpy(tvec, tvecMat.val, sizeof(double) * 3);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_solvePnPRansac_InputArray(
    cv::_InputArray *objectPoints, cv::_InputArray *imagePoints,
    cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs, cv::_OutputArray *rvec, cv::_OutputArray *tvec,
    bool useExtrinsicGuess, int iterationsCount, float reprojectionError, double confidence,
    cv::_OutputArray *inliers, int flags)
{
    BEGIN_WRAP
    cv::solvePnPRansac(*objectPoints, *imagePoints, *cameraMatrix, entity(distCoeffs), *rvec, *tvec,
        useExtrinsicGuess != 0, iterationsCount, reprojectionError, confidence,
        entity(inliers), flags);
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_solvePnPRansac_vector(
    cv::Point3f *objectPoints, int objectPointsLength,
    cv::Point2f *imagePoints, int imagePointsLength,
    double *cameraMatrix,
    double *distCoeffs, int distCoeffsLength,
    double *rvec, double *tvec,
    int useExtrinsicGuess, int iterationsCount, float reprojectionError, double confidence,
    std::vector<int> *inliers, int flags)
{
    BEGIN_WRAP
    const cv::Mat objectPointsMat(objectPointsLength, 1, CV_64FC3, objectPoints);
    const cv::Mat imagePointsMat(imagePointsLength, 1, CV_64FC2, imagePoints);
    cv::Mat distCoeffsMat;
    if (distCoeffs != nullptr)
        distCoeffsMat = cv::Mat(distCoeffsLength, 1, CV_64FC1, distCoeffs);

    cv::Matx<double, 3, 1> rvecM, tvecM;

    cv::solvePnPRansac(objectPointsMat, imagePointsMat, *cameraMatrix, distCoeffsMat, rvecM, tvecM,
        useExtrinsicGuess != 0, iterationsCount, reprojectionError, confidence,
        *inliers, flags);

    memcpy(rvec, rvecM.val, sizeof(double) * 3);
    memcpy(tvec, tvecM.val, sizeof(double) * 3);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_initCameraMatrix2D_Mat(
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
CVAPI(ExceptionStatus) calib3d_initCameraMatrix2D_array(
    cv::Point3f **objectPoints, int opSize1, int *opSize2,
    cv::Point2f **imagePoints, int ipSize1, int *ipSize2, MyCvSize imageSize, double aspectRatio,
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    std::vector<std::vector<cv::Point3f> > objectPointsVec(opSize1);
    for (auto i = 0; i < opSize1; i++)
        objectPointsVec[i] = std::vector<cv::Point3f>(objectPoints[i], objectPoints[i] + opSize2[i]);
    std::vector<std::vector<cv::Point3f> > imagePointsVec(ipSize1);
    for (auto i = 0; i < ipSize1; i++)
        imagePointsVec[i] = std::vector<cv::Point3f>(imagePoints[i], imagePoints[i] + ipSize2[i]);

    const auto ret = cv::initCameraMatrix2D(objectPointsVec, imagePointsVec, cpp(imageSize), aspectRatio);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_findChessboardCorners_InputArray(
    cv::_InputArray *image, MyCvSize patternSize,
    cv::_OutputArray *corners, int flags, 
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::findChessboardCorners(*image, cpp(patternSize), *corners, flags) ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_findChessboardCorners_vector(
    cv::_InputArray *image, MyCvSize patternSize,
    std::vector<cv::Point2f> *corners, int flags, 
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::findChessboardCorners(*image, cpp(patternSize), *corners, flags) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_checkChessboard(
    cv::_InputArray *img, MyCvSize size, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::checkChessboard(*img, cpp(size)) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_findChessboardCornersSB_OutputArray(
    cv::_InputArray *image, MyCvSize patternSize, cv::_OutputArray *corners, int flags, 
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::findChessboardCornersSB(*image, cpp(patternSize), *corners, flags) ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_findChessboardCornersSB_vector(
    cv::_InputArray *image, MyCvSize patternSize, std::vector<cv::Point2f> *corners, int flags, 
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::findChessboardCornersSB(*image, cpp(patternSize), *corners, flags) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_find4QuadCornerSubpix_InputArray(
    cv::_InputArray *img, cv::_InputOutputArray *corners, MyCvSize regionSize, 
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::find4QuadCornerSubpix(*img, *corners, cpp(regionSize)) ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_find4QuadCornerSubpix_vector(
    cv::_InputArray *img, std::vector<cv::Point2f> *corners, MyCvSize regionSize, 
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::find4QuadCornerSubpix(*img, *corners, cpp(regionSize)) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_drawChessboardCorners_InputArray(
    cv::_InputOutputArray *image, MyCvSize patternSize,
    cv::_InputArray *corners, int patternWasFound)
{
    BEGIN_WRAP
    cv::drawChessboardCorners(*image, cpp(patternSize), *corners, patternWasFound != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_drawChessboardCorners_array(
    cv::_InputOutputArray *image, MyCvSize patternSize,
    cv::Point2f *corners, int cornersLength, int patternWasFound)
{
    BEGIN_WRAP
    const std::vector<cv::Point2f> cornersVec(corners, corners + cornersLength);
    cv::drawChessboardCorners(*image, cpp(patternSize), cornersVec, patternWasFound != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_drawFrameAxes(
    cv::_InputOutputArray *image, cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
    cv::_InputArray *rvec, cv::_InputArray *tvec, float length, int thickness)
{
    BEGIN_WRAP
    cv::drawFrameAxes(*image, *cameraMatrix, *distCoeffs, *rvec, *tvec, length, thickness);
    END_WRAP
}


static void BlobDetectorDeleter(cv::FeatureDetector *p) {}

CVAPI(ExceptionStatus) calib3d_findCirclesGrid_InputArray(
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
CVAPI(ExceptionStatus) calib3d_findCirclesGrid_vector(
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

CVAPI(ExceptionStatus) calib3d_calibrateCamera_InputArray(
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
CVAPI(ExceptionStatus) calib3d_calibrateCamera_vector(
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

CVAPI(ExceptionStatus) calib3d_calibrationMatrixValues_InputArray(cv::_InputArray *cameraMatrix, MyCvSize imageSize,
    double apertureWidth, double apertureHeight, double *fovx, double *fovy, double *focalLength,
    cv::Point2d *principalPoint, double *aspectRatio)
{
    BEGIN_WRAP
    double fovx0, fovy0, focalLength0, aspectRatio0;
    cv::Point2d principalPoint0;
    cv::calibrationMatrixValues(*cameraMatrix, cpp(imageSize), apertureWidth, apertureHeight,
        fovx0, fovy0, focalLength0, principalPoint0, aspectRatio0);
    *fovx = fovx0;
    *fovy = fovy0;
    *principalPoint = principalPoint0;
    *focalLength = focalLength0;
    *aspectRatio = aspectRatio0;
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_calibrationMatrixValues_array(double *cameraMatrix, MyCvSize imageSize,
    double apertureWidth, double apertureHeight, double *fovx, double *fovy, double *focalLength,
    cv::Point2d *principalPoint, double *aspectRatio)
{
    BEGIN_WRAP
    const cv::Mat cameraMatrixM(3, 3, CV_64FC1, cameraMatrix);
    cv::_InputArray cameraMatrixI(cameraMatrixM);
    calib3d_calibrationMatrixValues_InputArray(&cameraMatrixI, imageSize, apertureWidth, apertureHeight,
        fovx, fovy, focalLength, principalPoint, aspectRatio);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_stereoCalibrate_InputArray(
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
    std::vector<cv::_InputArray> objectPointsVec(opSize);
    std::vector<cv::_InputArray> imagePoints1Vec(ip1Size);
    std::vector<cv::_InputArray> imagePoints2Vec(ip2Size);
    for (auto i = 0; i < opSize; i++)
        objectPointsVec[i] = *objectPoints[i];
    for (auto i = 0; i < ip1Size; i++)
        imagePoints1Vec[i] = *imagePoints1[i];
    for (auto i = 0; i < ip2Size; i++)
        imagePoints2Vec[i] = *imagePoints2[i];

    *returnValue = cv::stereoCalibrate(objectPointsVec, imagePoints1Vec, imagePoints2Vec,
        *cameraMatrix1, *distCoeffs1,
        *cameraMatrix2, *distCoeffs2,
        cpp(imageSize), entity(R), entity(T), entity(E), entity(F), flags, cpp(criteria));
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_stereoCalibrate_array(
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

CVAPI(ExceptionStatus) calib3d_stereoRectify_InputArray(
    cv::_InputArray *cameraMatrix1, cv::_InputArray *distCoeffs1,
    cv::_InputArray *cameraMatrix2, cv::_InputArray *distCoeffs2,
    MyCvSize imageSize, cv::_InputArray *R, cv::_InputArray *T,
    cv::_OutputArray *R1, cv::_OutputArray *R2,
    cv::_OutputArray *P1, cv::_OutputArray *P2,
    cv::_OutputArray *Q, int flags,
    double alpha, CvSize newImageSize,
    MyCvRect *validPixROI1, MyCvRect *validPixROI2)
{
    BEGIN_WRAP
    cv::Rect _validPixROI1, _validPixROI2;
    cv::stereoRectify(*cameraMatrix1, *distCoeffs1, *cameraMatrix2, *distCoeffs2,
        cpp(imageSize), *R, *T, *R1, *R2, *P1, *P2, *Q, flags, alpha, newImageSize,
        &_validPixROI1, &_validPixROI2);
    *validPixROI1 = c(_validPixROI1);
    *validPixROI2 = c(_validPixROI2);
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_stereoRectify_array(double *cameraMatrix1,
    double *distCoeffs1, int dc1Size,
    double *cameraMatrix2,
    double *distCoeffs2, int dc2Size,
    MyCvSize imageSize,
    double *R, double *T,
    double *R1, double *R2, double *P1, double *P2,
    double *Q, int flags, double alpha, MyCvSize newImageSize,
    MyCvRect *validPixROI1, MyCvRect *validPixROI2)
{
    BEGIN_WRAP
    cv::Mat cameraMatrix1M(3, 3, CV_64FC1, cameraMatrix1);
    cv::Mat cameraMatrix2M(3, 3, CV_64FC1, cameraMatrix2);
    cv::Mat distCoeffs1M(dc1Size, 1, CV_64FC1, distCoeffs1);
    cv::Mat distCoeffs2M(dc2Size, 1, CV_64FC1, distCoeffs2);
    cv::Mat RM(3, 3, CV_64FC1, R);
    cv::Mat TM(1, 3, CV_64FC1, T);

    cv::Mat R1M(3, 3, CV_64FC1, R1);
    cv::Mat R2M(3, 3, CV_64FC1, R2);
    cv::Mat P1M(3, 4, CV_64FC1, P1);
    cv::Mat P2M(3, 4, CV_64FC1, P2);
    cv::Mat QM(4, 4, CV_64FC1, Q);

    cv::Rect _validPixROI1, _validPixROI2;
    cv::stereoRectify(cameraMatrix1M, distCoeffs1M, cameraMatrix2M, distCoeffs2M,
        cpp(imageSize), RM, TM, R1M, R2M, P1M, P2M, QM, flags, alpha, cpp(newImageSize),
        &_validPixROI1, &_validPixROI2);
    *validPixROI1 = c(_validPixROI1);
    *validPixROI2 = c(_validPixROI2);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_stereoRectifyUncalibrated_InputArray(cv::_InputArray *points1, cv::_InputArray *points2,
    cv::_InputArray *F, MyCvSize imgSize,
    cv::_OutputArray *H1, cv::_OutputArray *H2,
    double threshold,
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::stereoRectifyUncalibrated(*points1, *points2, *F, cpp(imgSize), *H1, *H2, threshold) ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_stereoRectifyUncalibrated_array(cv::Point2d *points1, int points1Size,
    cv::Point2d *points2, int points2Size,
    cv::_InputArray *F, MyCvSize imgSize,
    double *H1, double *H2,
    double threshold,
    int *returnValue)
{
    BEGIN_WRAP
    const cv::Mat points1Mat(points1Size, 1, CV_64FC2, points1);
    const cv::Mat points2Mat(points2Size, 1, CV_64FC2, points2);
    cv::Mat H1M(3, 3, CV_64FC1, H1);
    cv::Mat H2M(3, 3, CV_64FC1, H2);
    *returnValue = cv::stereoRectifyUncalibrated(points1Mat, points2Mat, *F, cpp(imgSize), H1M, H2M, threshold) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_rectify3Collinear_InputArray(
    cv::_InputArray *cameraMatrix1, cv::_InputArray *distCoeffs1,
    cv::_InputArray *cameraMatrix2, cv::_InputArray *distCoeffs2,
    cv::_InputArray *cameraMatrix3, cv::_InputArray *distCoeffs3,
    cv::_InputArray **imgpt1, int imgpt1Size,
    cv::_InputArray **imgpt3, int imgpt3Size,
    MyCvSize imageSize, cv::_InputArray *R12, cv::_InputArray *T12,
    cv::_InputArray *R13, cv::_InputArray *T13,
    cv::_OutputArray *R1, cv::_OutputArray *R2, cv::_OutputArray *R3,
    cv::_OutputArray *P1, cv::_OutputArray *P2, cv::_OutputArray *P3,
    cv::_OutputArray *Q, double alpha, CvSize newImgSize,
    MyCvRect *roi1, MyCvRect *roi2, int flags,
    float *returnValue)
{
    BEGIN_WRAP
    std::vector<cv::_InputArray> imgpt1Vec(imgpt1Size);
    std::vector<cv::_InputArray> imgpt3Vec(imgpt3Size);
    for (auto i = 0; i < imgpt1Size; i++)
        imgpt1Vec[i] = *(imgpt1[i]);
    for (auto i = 0; i < imgpt1Size; i++)
        imgpt3Vec[i] = *(imgpt3[i]);
    cv::Rect _roi1, _roi2;

    const auto ret = cv::rectify3Collinear(*cameraMatrix1, *distCoeffs1,
        *cameraMatrix2, *distCoeffs2, *cameraMatrix3, *distCoeffs3,
        imgpt1Vec, imgpt3Vec, cpp(imageSize), *R12, *T12, *R13, *T13,
        *R1, *R2, *R3, *P1, *P2, *P3, *Q, alpha, newImgSize,
        &_roi1, &_roi2, flags);
    *roi1 = c(_roi1);
    *roi2 = c(_roi2);
    *returnValue = ret;
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_getOptimalNewCameraMatrix_InputArray(
    cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
    MyCvSize imageSize, double alpha, MyCvSize newImgSize,
    MyCvRect* validPixROI, int centerPrincipalPoint,
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    cv::Rect _validPixROI;
    const auto mat = cv::getOptimalNewCameraMatrix(*cameraMatrix, entity(distCoeffs),
        cpp(imageSize), alpha, cpp(newImgSize), &_validPixROI, centerPrincipalPoint != 0);
    *validPixROI = c(_validPixROI);
    *returnValue = new cv::Mat(mat);
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_getOptimalNewCameraMatrix_array(
    double *cameraMatrix,
    double *distCoeffs, int distCoeffsSize,
    MyCvSize imageSize, double alpha, MyCvSize newImgSize,
    MyCvRect* validPixROI, int centerPrincipalPoint,
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    const cv::Mat cameraMatrixM(3, 3, CV_64FC1, cameraMatrix);
    const auto distCoeffsM = (distCoeffs == nullptr) ? cv::Mat() : cv::Mat(distCoeffsSize, 1, CV_64FC1, distCoeffs);

    cv::Rect _validPixROI;
    const auto mat = cv::getOptimalNewCameraMatrix(cameraMatrixM, distCoeffsM, cpp(imageSize),
        alpha, cpp(newImgSize), &_validPixROI, centerPrincipalPoint != 0);
    *validPixROI = c(_validPixROI);
    *returnValue = new cv::Mat(mat);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_calibrateHandEye(
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

CVAPI(ExceptionStatus) calib3d_convertPointsToHomogeneous_InputArray(cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::convertPointsToHomogeneous(*src, *dst);
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_convertPointsToHomogeneous_array1(cv::Vec2f *src, cv::Vec3f *dst, int length)
{
    BEGIN_WRAP
    const cv::Mat srcMat(length, 1, CV_64FC2, src);
    cv::Mat dstMat(length, 1, CV_64FC3, dst);
    cv::convertPointsFromHomogeneous(srcMat, dstMat);
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_convertPointsToHomogeneous_array2(cv::Vec3f *src, cv::Vec4f *dst, int length)
{
    BEGIN_WRAP
    const cv::Mat srcMat(length, 1, CV_64FC3, src);
    cv::Mat dstMat(length, 1, CV_64FC4, dst);
    cv::convertPointsFromHomogeneous(srcMat, dstMat);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_convertPointsFromHomogeneous_InputArray(cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::convertPointsFromHomogeneous(*src, *dst);
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_convertPointsFromHomogeneous_array1(cv::Vec3f *src, cv::Vec2f *dst, int length)
{
    BEGIN_WRAP
    const cv::Mat srcMat(length, 1, CV_64FC3, src);
    cv::Mat dstMat(length, 1, CV_64FC2, dst);
    cv::convertPointsFromHomogeneous(srcMat, dstMat);
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_convertPointsFromHomogeneous_array2(cv::Vec4f *src, cv::Vec3f *dst, int length)
{
    BEGIN_WRAP
    const cv::Mat srcMat(length, 1, CV_64FC4, src);
    cv::Mat dstMat(length, 1, CV_64FC3, dst);
    cv::convertPointsFromHomogeneous(srcMat, dstMat);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_convertPointsHomogeneous(cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::convertPointsHomogeneous(*src, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_findFundamentalMat_InputArray(
    cv::_InputArray *points1, cv::_InputArray *points2,
    int method, double param1, double param2,
    cv::_OutputArray *mask,
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto mat = cv::findFundamentalMat(
        *points1, *points2, method, param1, param2, entity(mask));
    *returnValue = new cv::Mat(mat);
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_findFundamentalMat_arrayF64(
    cv::Point2d *points1, int points1Size,
    cv::Point2d *points2, int points2Size,
    int method, double param1, double param2,
    cv::_OutputArray *mask,
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    const cv::Mat points1M(points1Size, 1, CV_64FC2, points1);
    const cv::Mat points2M(points2Size, 1, CV_64FC2, points2);
    const auto mat = cv::findFundamentalMat(
        points1M, points2M, method, param1, param2, entity(mask));
    *returnValue = new cv::Mat(mat);
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_findFundamentalMat_arrayF32(
    cv::Point2f *points1, int points1Size,
    cv::Point2f *points2, int points2Size,
    int method, double param1, double param2,
    cv::_OutputArray *mask,
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    const cv::Mat points1M(points1Size, 1, CV_32FC2, points1);
    const cv::Mat points2M(points2Size, 1, CV_32FC2, points2);
    const auto mat = cv::findFundamentalMat(
        points1M, points2M, method, param1, param2, entity(mask));
    *returnValue = new cv::Mat(mat);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_computeCorrespondEpilines_InputArray(
    cv::_InputArray *points,
    int whichImage, cv::_InputArray *F,
    cv::_OutputArray *lines)
{
    BEGIN_WRAP
    cv::computeCorrespondEpilines(*points, whichImage, *F, *lines);
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_computeCorrespondEpilines_array2d(
    cv::Point2d *points, int pointsSize,
    int whichImage, double *F,
    cv::Point3f *lines)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point2d> pointsM(pointsSize, 1, points);
    const cv::Mat_<double> FM(3, 3, F);
    cv::Mat_<cv::Point3f> linesM(pointsSize, 1, lines);
    cv::computeCorrespondEpilines(pointsM, whichImage, FM, linesM);
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_computeCorrespondEpilines_array3d(
    cv::Point3d *points, int pointsSize,
    int whichImage, double *F,
    cv::Point3f *lines)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point3d> pointsM(pointsSize, 1, points);
    const cv::Mat_<double> FM(3, 3, F);
    cv::Mat_<cv::Point3f> linesM(pointsSize, 1, lines);
    cv::computeCorrespondEpilines(pointsM, whichImage, FM, linesM);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_triangulatePoints_InputArray(
    cv::_InputArray *projMatr1, cv::_InputArray *projMatr2,
    cv::_InputArray *projPoints1, cv::_InputArray *projPoints2,
    cv::_OutputArray *points4D)
{
    BEGIN_WRAP
    cv::triangulatePoints(*projMatr1, *projMatr2, *projPoints1, *projPoints2, *points4D);
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_triangulatePoints_array(
    double *projMatr1, double *projMatr2,
    cv::Point2d *projPoints1, int projPoints1Size,
    cv::Point2d *projPoints2, int projPoints2Size,
    cv::Vec4d *points4D)
{
    BEGIN_WRAP
    const cv::Mat_<double> projMatr1M(3, 4, projMatr1);
    const cv::Mat_<double> projMatr2M(3, 4, projMatr2);
    const cv::Mat_<cv::Point2d> projPoints1M(projPoints1Size, 1, projPoints1);
    const cv::Mat_<cv::Point2d> projPoints2M(projPoints2Size, 1, projPoints2);
    cv::Mat_<cv::Vec4d> points4DM(1, projPoints1Size, points4D);
    cv::triangulatePoints(projMatr1M, projMatr2M,
        projPoints1M, projPoints2M, points4DM);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_correctMatches_InputArray(
    cv::_InputArray *F, cv::_InputArray *points1, cv::_InputArray *points2,
    cv::_OutputArray *newPoints1, cv::_OutputArray *newPoints2)
{
    BEGIN_WRAP
    cv::correctMatches(*F, *points1, *points2, *newPoints1, *newPoints2);
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_correctMatches_array(
    double *F,
    cv::Point2d *points1, int points1Size,
    cv::Point2d *points2, int points2Size,
    cv::Point2d *newPoints1, cv::Point2d *newPoints2)
{
    BEGIN_WRAP
    cv::Mat_<double> FM(3, 3, F);
    cv::Mat_<cv::Point2d> points1M(points1Size, 1, points1);
    cv::Mat_<cv::Point2d> points2M(points2Size, 1, points2);
    cv::Mat_<double> points1MM = points1M.reshape(2);
    cv::Mat_<double> points2MM = points2M.reshape(2);
    cv::Mat_<cv::Point2d> newPoints1M(points1Size, 1, newPoints1);
    cv::Mat_<cv::Point2d> newPoints2M(points2Size, 1, newPoints2);
    cv::Mat_<double> newPoints1MM = points1M.reshape(2);
    cv::Mat_<double> newPoints2MM = points2M.reshape(2);
    cv::correctMatches(FM, points1MM, points2MM, newPoints1MM, newPoints2MM);
    END_WRAP
}


CVAPI(ExceptionStatus) calib3d_filterSpeckles(
    cv::_InputOutputArray *img, double newVal, int maxSpeckleSize, double maxDiff, cv::_InputOutputArray *buf)
{
    BEGIN_WRAP
    cv::filterSpeckles(*img, newVal, maxSpeckleSize, maxDiff, entity(buf));
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_getValidDisparityROI(
    MyCvRect roi1, MyCvRect roi2,
    int minDisparity, int numberOfDisparities, int SADWindowSize,
    MyCvRect *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(cv::getValidDisparityROI(
        cpp(roi1), cpp(roi2), minDisparity, numberOfDisparities, SADWindowSize));
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_validateDisparity(
    cv::_InputOutputArray *disparity, cv::_InputArray *cost,
    int minDisparity, int numberOfDisparities, int disp12MaxDisp)
{
    BEGIN_WRAP
    cv::validateDisparity(*disparity, *cost, minDisparity, numberOfDisparities, disp12MaxDisp);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_reprojectImageTo3D(
    cv::_InputArray *disparity, cv::_OutputArray *_3dImage,
    cv::_InputArray *Q, int handleMissingValues, int ddepth)
{
    BEGIN_WRAP
    cv::reprojectImageTo3D(*disparity, *_3dImage, *Q, handleMissingValues != 0, ddepth);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_estimateAffine3D(cv::_InputArray *src, cv::_InputArray *dst,
    cv::_OutputArray *out, cv::_OutputArray *inliers,
    double ransacThreshold, double confidence,
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::estimateAffine3D(*src, *dst, *out, *inliers, ransacThreshold, confidence);
    END_WRAP
}


CVAPI(ExceptionStatus) calib3d_sampsonDistance_InputArray(
    cv::_InputArray *pt1, cv::_InputArray *pt2, cv::_InputArray *F,
    double *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::sampsonDistance(*pt1, *pt2, *F);
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_sampsonDistance_Point3d(
    MyCvPoint3D64f pt1, MyCvPoint3D64f pt2, MyCvPoint3D64f *F,
    double *returnValue)
{
    BEGIN_WRAP
    std::vector<cv::Point3d> f(9);
    for (size_t i = 0; i < 9; i++)
    {
        f[i] = cpp(F[i]);
    }
    *returnValue = cv::sampsonDistance(cv::Mat(cpp(pt1)), cv::Mat(cpp(pt2)), f);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_estimateAffine2D(
    cv::_InputArray *from, cv::_InputArray *to, cv::_OutputArray *inliers,
    int method, double ransacReprojThreshold,
    uint64_t maxIters, double confidence, uint64_t refineIters,
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto result = cv::estimateAffine2D(
        *from, *to, entity(inliers), method, ransacReprojThreshold, static_cast<size_t>(maxIters), confidence, static_cast<size_t>(refineIters));
    *returnValue = new cv::Mat(result);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_estimateAffinePartial2D(
    cv::_InputArray *from, cv::_InputArray *to, cv::_OutputArray *inliers,
    int method, double ransacReprojThreshold,
    uint64_t maxIters, double confidence, uint64_t refineIters,
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto result = cv::estimateAffinePartial2D(
        *from, *to, entity(inliers), method, ransacReprojThreshold, static_cast<size_t>(maxIters), confidence, static_cast<size_t>(refineIters));
    *returnValue = new cv::Mat(result);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_decomposeHomographyMat(
    cv::_InputArray *H,
    cv::_InputArray *K,
    std::vector<cv::Mat> *rotations,
    std::vector<cv::Mat> *translations,
    std::vector<cv::Mat> *normals,
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::decomposeHomographyMat(*H, *K, *rotations, *translations, *normals);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_filterHomographyDecompByVisibleRefpoints(
    std::vector<cv::Mat> *rotations,
    std::vector<cv::Mat> *normals,
    cv::_InputArray *beforePoints,
    cv::_InputArray *afterPoints,
    cv::_OutputArray *possibleSolutions,
    cv::_InputArray *pointsMask)
{
    BEGIN_WRAP
    cv::filterHomographyDecompByVisibleRefpoints(*rotations, *normals, *beforePoints, *afterPoints, *possibleSolutions, entity(pointsMask));
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_undistort(
    cv::_InputArray *src, cv::_OutputArray *dst,
    cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs, cv::_InputArray *newCameraMatrix)
{
    BEGIN_WRAP
    cv::undistort(*src, *dst, *cameraMatrix, entity(distCoeffs), entity(newCameraMatrix));
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_initUndistortRectifyMap(
    cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
    cv::_InputArray *R, cv::_InputArray *newCameraMatrix,
    MyCvSize size, int m1type, cv::_OutputArray *map1, cv::_OutputArray *map2)
{
    BEGIN_WRAP
    cv::initUndistortRectifyMap(*cameraMatrix, *distCoeffs, *R, *newCameraMatrix, cpp(size), m1type, *map1, *map2);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_initWideAngleProjMap(
    cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
    MyCvSize imageSize, int destImageWidth,
    int m1type, cv::_OutputArray *map1, cv::_OutputArray *map2,
    int projType, double alpha,
    float *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::initWideAngleProjMap(*cameraMatrix, *distCoeffs, cpp(imageSize), destImageWidth, m1type, 
        *map1, *map2, static_cast<cv::UndistortTypes>(projType), alpha);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_getDefaultNewCameraMatrix(
    cv::_InputArray *cameraMatrix, MyCvSize imgsize, int centerPrincipalPoint,
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto result = cv::getDefaultNewCameraMatrix(*cameraMatrix, cpp(imgsize), centerPrincipalPoint != 0);
    *returnValue = new cv::Mat(result);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_undistortPoints(
    cv::_InputArray *src, cv::_OutputArray *dst,
    cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
    cv::_InputArray *R, cv::_InputArray *P)
{
    BEGIN_WRAP
    cv::undistortPoints(*src, *dst, *cameraMatrix, *distCoeffs, entity(R), entity(P));
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_undistortPointsIter(
    cv::_InputArray *src, cv::_OutputArray *dst,
    cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
    cv::_InputArray *R, cv::_InputArray *P, MyCvTermCriteria criteria)
{
    BEGIN_WRAP
    cv::undistortPoints(*src, *dst, *cameraMatrix, *distCoeffs, entity(R), entity(P), cpp(criteria));
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_recoverPose_InputArray1(
    cv::_InputArray *E, cv::_InputArray *points1, cv::_InputArray *points2,
    cv::_InputArray *cameraMatrix,
    cv::_OutputArray *R, cv::_OutputArray *t, cv::_InputOutputArray *mask,
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::recoverPose(*E, *points1, *points2, *cameraMatrix, *R, *t, entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_recoverPose_InputArray2(
    cv::_InputArray *E, cv::_InputArray *points1, cv::_InputArray *points2,
    cv::_OutputArray *R, cv::_OutputArray *t, double focal, MyCvPoint2D64f pp,
    cv::_InputOutputArray *mask,
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::recoverPose(*E, *points1, *points2, *R, *t, focal, cpp(pp), entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_recoverPose_InputArray3(
    cv::_InputArray *E, cv::_InputArray *points1, cv::_InputArray *points2,
    cv::_InputArray *cameraMatrix, double distanceTresh,
    cv::_OutputArray *R, cv::_OutputArray *t, cv::_InputOutputArray *mask, cv::_OutputArray *triangulatedPoints,
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::recoverPose(*E, *points1, *points2, *cameraMatrix, *R, *t, distanceTresh, entity(mask), entity(triangulatedPoints));
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_findEssentialMat_InputArray1(
    cv::_InputArray *points1, cv::_InputArray *points2, cv::_InputArray *cameraMatrix,
    int method, double prob, double threshold,
    cv::_OutputArray *mask,
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto mat = cv::findEssentialMat(
        *points1, *points2, *cameraMatrix, method, prob, threshold, entity(mask));
    *returnValue = new cv::Mat(mat);
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_findEssentialMat_InputArray2(
    cv::_InputArray *points1, cv::_InputArray *points2, double focal, MyCvPoint2D64f pp,
    int method, double prob, double threshold,
    cv::_OutputArray *mask,
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto mat = cv::findEssentialMat(
        *points1, *points2, focal, cpp(pp), method, prob, threshold, entity(mask));
    *returnValue = new cv::Mat(mat);
    END_WRAP
}

#endif