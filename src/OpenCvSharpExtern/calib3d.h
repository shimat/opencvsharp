#ifndef _CPP_CALIB3D_H_
#define _CPP_CALIB3D_H_

#include "include_opencv.h"

CVAPI(void) calib3d_Rodrigues(cv::_InputArray *src, cv::_OutputArray *dst, cv::_OutputArray *jacobian)
{
    cv::Rodrigues(*src, *dst, entity(jacobian));
}
CVAPI(void) calib3d_Rodrigues_VecToMat(cv::Mat *vector, cv::Mat *matrix, cv::Mat *jacobian)
{
    cv::Mat vectorM(3, 1, CV_64FC1, vector);
    cv::Mat matrixM(3, 3, CV_64FC1, matrix);
    cv::Mat jacobianM(3, 9, CV_64FC1, jacobian);
    cv::Rodrigues(*vector, *matrix, *jacobian);
}
CVAPI(void) calib3d_Rodrigues_MatToVec(cv::Mat *matrix, cv::Mat *vector, cv::Mat *jacobian)
{
    cv::Mat matrixM(3, 3, CV_64FC1, matrix);
    cv::Mat vectorM(3, 1, CV_64FC1, vector);
    cv::Mat jacobianM(3, 9, CV_64FC1, jacobian);
    cv::Rodrigues(*matrix, *vector, *jacobian);
}

CVAPI(cv::Mat*) calib3d_findHomography_InputArray(cv::_InputArray *srcPoints, cv::_InputArray *dstPoints,
    int method, double ransacReprojThreshold, cv::_OutputArray *mask)
{
    cv::Mat ret = cv::findHomography(*srcPoints, *dstPoints, method, ransacReprojThreshold, entity(mask));
    return new cv::Mat(ret);
}
CVAPI(cv::Mat*) calib3d_findHomography_vector(cv::Point2d *srcPoints, int srcPointsLength,
    cv::Point2d *dstPoints, int dstPointsLength,
    int method, double ransacReprojThreshold, cv::_OutputArray *mask)
{
    cv::Mat srcPointsMat(srcPointsLength, 1, CV_64FC2, srcPoints);
    cv::Mat dstPointsMat(dstPointsLength, 1, CV_64FC2, dstPoints);

    cv::Mat ret = cv::findHomography(srcPointsMat, dstPointsMat, method, ransacReprojThreshold, entity(mask));
    return new cv::Mat(ret);
}

CVAPI(void) calib3d_RQDecomp3x3_InputArray(cv::_InputArray *src, cv::_OutputArray *mtxR, cv::_OutputArray *mtxQ,
    cv::_OutputArray *qx, cv::_OutputArray *qy, cv::_OutputArray *qz, cv::Vec3d *outVec)
{
    *outVec = cv::RQDecomp3x3(*src, *mtxR, *mtxQ, entity(qx), entity(qy), entity(qz));
}
CVAPI(void) calib3d_RQDecomp3x3_Mat(cv::Mat *src, cv::Mat *mtxR, cv::Mat *mtxQ,
    cv::Mat *qx, cv::Mat *qy, cv::Mat *qz, cv::Vec3d *outVec)
{
    *outVec = cv::RQDecomp3x3(*src, *mtxR, *mtxQ, *qx, *qy, *qz);
}

CVAPI(void) calib3d_decomposeProjectionMatrix_InputArray(cv::_InputArray *projMatrix, cv::_OutputArray *cameraMatrix,
    cv::_OutputArray *rotMatrix, cv::_OutputArray *transVect, cv::_OutputArray *rotMatrixX,
    cv::_OutputArray *rotMatrixY, cv::_OutputArray *rotMatrixZ, cv::_OutputArray *eulerAngles)
{
    cv::decomposeProjectionMatrix(*projMatrix, *cameraMatrix, *rotMatrix,
        *transVect, entity(rotMatrixX), entity(rotMatrixY), entity(rotMatrixZ), entity(eulerAngles));
}
CVAPI(void) calib3d_decomposeProjectionMatrix_Mat(cv::Mat *projMatrix, cv::Mat *cameraMatrix,
    cv::Mat *rotMatrix, cv::Mat *transVect, cv::Mat *rotMatrixX,
    cv::Mat *rotMatrixY, cv::Mat *rotMatrixZ, cv::Mat *eulerAngles)
{
    cv::decomposeProjectionMatrix(*projMatrix, *cameraMatrix, *rotMatrix,
        *transVect, *rotMatrixX, *rotMatrixY, *rotMatrixZ, *eulerAngles);
}

CVAPI(void) calib3d_matMulDeriv(cv::_InputArray *a, cv::_InputArray *b,
    cv::_OutputArray *dABdA, cv::_OutputArray *dABdB)
{
    cv::matMulDeriv(*a, *b, *dABdA, *dABdB);
}

CVAPI(void) calib3d_composeRT_InputArray(cv::_InputArray *rvec1, cv::_InputArray *tvec1,
    cv::_InputArray *rvec2, cv::_InputArray *tvec2,
    cv::_OutputArray *rvec3, cv::_OutputArray *tvec3,
    cv::_OutputArray *dr3dr1, cv::_OutputArray *dr3dt1,
    cv::_OutputArray *dr3dr2, cv::_OutputArray *dr3dt2,
    cv::_OutputArray *dt3dr1, cv::_OutputArray *dt3dt1,
    cv::_OutputArray *dt3dr2, cv::_OutputArray *dt3dt2)
{
    cv::composeRT(*rvec1, *tvec1, *rvec2, *tvec2, *rvec3, *tvec3,
        entity(dr3dr1), entity(dr3dt1), entity(dr3dr2), entity(dr3dt2),
        entity(dt3dr1), entity(dt3dt1), entity(dt3dr2), entity(dt3dt2));
}

CVAPI(void) calib3d_composeRT_Mat(cv::Mat *rvec1, cv::Mat *tvec1,
    cv::Mat *rvec2, cv::Mat *tvec2,
    cv::Mat *rvec3, cv::Mat *tvec3,
    cv::Mat *dr3dr1, cv::Mat *dr3dt1,
    cv::Mat *dr3dr2, cv::Mat *dr3dt2,
    cv::Mat *dt3dr1, cv::Mat *dt3dt1,
    cv::Mat *dt3dr2, cv::Mat *dt3dt2)
{
    cv::composeRT(*rvec1, *tvec1, *rvec2, *tvec2, *rvec3, *tvec3,
        entity(dr3dr1), entity(dr3dt1), entity(dr3dr2), entity(dr3dt2),
        entity(dt3dr1), entity(dt3dt1), entity(dt3dr2), entity(dt3dt2));
}

CVAPI(void) calib3d_projectPoints_InputArray(cv::_InputArray *objectPoints,
    cv::_InputArray *rvec, cv::_InputArray *tvec,
    cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
    cv::_OutputArray *imagePoints,
    cv::_OutputArray *jacobian,
    double aspectRatio)
{
    cv::projectPoints(*objectPoints, *rvec, *tvec, *cameraMatrix, *distCoeffs,
        *imagePoints, *jacobian, aspectRatio);
}
CVAPI(void) calib3d_projectPoints_Mat(cv::Mat *objectPoints,
    cv::Mat *rvec, cv::Mat *tvec,
    cv::Mat *cameraMatrix, cv::Mat *distCoeffs,
    cv::Mat *imagePoints,
    cv::Mat *jacobian,
    double aspectRatio)
{
    cv::projectPoints(*objectPoints, *rvec, *tvec, *cameraMatrix, *distCoeffs,
        *imagePoints, *jacobian, aspectRatio);
}


CVAPI(void) calib3d_solvePnP_InputArray(cv::_InputArray *objectPoints, cv::_InputArray *imagePoints, cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
    cv::_OutputArray *rvec, cv::_OutputArray *tvec, int useExtrinsicGuess, int flags)
{
    cv::solvePnP(*objectPoints, *imagePoints, *cameraMatrix, entity(distCoeffs), *rvec, *tvec, useExtrinsicGuess != 0, flags);
}
CVAPI(void) calib3d_solvePnP_vector(cv::Point3f *objectPoints, int objectPointsLength,
    cv::Point2f *imagePoints, int imagePointsLength,
    double *cameraMatrix, double *distCoeffs, int distCoeffsLength,
    double *rvec, double *tvec, int useExtrinsicGuess,
    int flags)
{
    cv::Mat objectPointsMat(objectPointsLength, 1, CV_64FC3, objectPoints);
    cv::Mat imagePointsMat(imagePointsLength, 1, CV_64FC2, imagePoints);
    cv::Mat distCoeffsMat;
    if (distCoeffs != NULL)
        distCoeffsMat = cv::Mat(distCoeffsLength, 1, CV_64FC1, distCoeffs);

    cv::Matx<double, 3, 1> rvecM, tvecM;
    cv::solvePnP(objectPointsMat, imagePointsMat, *cameraMatrix, distCoeffsMat, rvecM, tvecM, useExtrinsicGuess != 0, flags);
    memcpy(rvec, rvecM.val, sizeof(double) * 3);
    memcpy(tvec, tvecM.val, sizeof(double) * 3);
}

CVAPI(void) calib3d_solvePnPRansac_InputArray(cv::_InputArray *objectPoints, cv::_InputArray *imagePoints,
    cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs, cv::_OutputArray *rvec, cv::_OutputArray *tvec,
    bool useExtrinsicGuess, int iterationsCount, float reprojectionError, double confidence,
    cv::_OutputArray *inliers, int flags)
{
    cv::solvePnPRansac(*objectPoints, *imagePoints, *cameraMatrix, entity(distCoeffs), *rvec, *tvec,
        useExtrinsicGuess != 0, iterationsCount, reprojectionError, confidence,
        entity(inliers), flags);
}
CVAPI(void) calib3d_solvePnPRansac_vector(cv::Point3f *objectPoints, int objectPointsLength,
    cv::Point2f *imagePoints, int imagePointsLength,
    double *cameraMatrix, double *distCoeffs, int distCoeffsLength,
    double *rvec, double *tvec,
    int useExtrinsicGuess, int iterationsCount, float reprojectionError, double confidence,
    std::vector<int> *inliers, int flags)
{
    cv::Mat objectPointsMat(objectPointsLength, 1, CV_64FC3, objectPoints);
    cv::Mat imagePointsMat(imagePointsLength, 1, CV_64FC2, imagePoints);
    cv::Mat distCoeffsMat;
    if (distCoeffs != NULL)
        distCoeffsMat = cv::Mat(distCoeffsLength, 1, CV_64FC1, distCoeffs);

    cv::Matx<double, 3, 1> rvecM, tvecM;

    cv::solvePnPRansac(objectPointsMat, imagePointsMat, *cameraMatrix, distCoeffsMat, rvecM, tvecM,
        useExtrinsicGuess != 0, iterationsCount, reprojectionError, confidence,
        *inliers, flags);

    memcpy(rvec, rvecM.val, sizeof(double) * 3);
    memcpy(tvec, tvecM.val, sizeof(double) * 3);
}

CVAPI(cv::Mat*) calib3d_initCameraMatrix2D_Mat(cv::Mat **objectPoints, int objectPointsLength,
    cv::Mat **imagePoints, int imagePointsLength, CvSize imageSize, double aspectRatio)
{
    std::vector<cv::Mat> objectPointsVec(objectPointsLength);
    for (int i = 0; i < objectPointsLength; i++)
        objectPointsVec[i] = *objectPoints[i];
    std::vector<cv::Mat> imagePointsVec(imagePointsLength);
    for (int i = 0; i < objectPointsLength; i++)
        imagePointsVec[i] = *imagePoints[i];

    cv::Mat ret = cv::initCameraMatrix2D(objectPointsVec, imagePointsVec, imageSize, aspectRatio);
    return new cv::Mat(ret);
}
CVAPI(cv::Mat*) calib3d_initCameraMatrix2D_array(cv::Point3d **objectPoints, int opSize1, int *opSize2,
    cv::Point2d **imagePoints, int ipSize1, int *ipSize2, CvSize imageSize, double aspectRatio)
{
    std::vector<std::vector<cv::Point3d> > objectPointsVec(opSize1);
    for (int i = 0; i < opSize1; i++)
        objectPointsVec[i] = std::vector<cv::Point3d>(objectPoints[i], objectPoints[i] + opSize2[i]);
    std::vector<std::vector<cv::Point3d> > imagePointsVec(ipSize1);
    for (int i = 0; i < ipSize1; i++)
        imagePointsVec[i] = std::vector<cv::Point3d>(imagePoints[i], imagePoints[i] + ipSize2[i]);

    cv::Mat ret = cv::initCameraMatrix2D(objectPointsVec, imagePointsVec, imageSize, aspectRatio);
    return new cv::Mat(ret);
}

CVAPI(int) calib3d_findChessboardCorners_InputArray(cv::_InputArray *image, CvSize patternSize,
    cv::_OutputArray *corners, int flags)
{
    return cv::findChessboardCorners(*image, patternSize, *corners, flags) ? 1 : 0;
}
CVAPI(int) calib3d_findChessboardCorners_vector(cv::_InputArray *image, CvSize patternSize,
    std::vector<cv::Point2f> *corners, int flags)
{
    return cv::findChessboardCorners(*image, patternSize, *corners, flags) ? 1 : 0;
}

CVAPI(int) calib3d_find4QuadCornerSubpix_InputArray(cv::_InputArray *img, cv::_InputOutputArray *corners, CvSize regionSize)
{
    return cv::find4QuadCornerSubpix(*img, *corners, regionSize) ? 1 : 0;
}
CVAPI(int) calib3d_find4QuadCornerSubpix_vector(cv::_InputArray *img, std::vector<cv::Point2f> *corners, CvSize regionSize)
{
    return cv::find4QuadCornerSubpix(*img, *corners, regionSize) ? 1 : 0;
}

CVAPI(void) calib3d_drawChessboardCorners_InputArray(cv::_InputOutputArray *image, CvSize patternSize,
    cv::_InputArray *corners, int patternWasFound)
{
    cv::drawChessboardCorners(*image, patternSize, *corners, patternWasFound != 0);
}
CVAPI(void) calib3d_drawChessboardCorners_array(cv::_InputOutputArray *image, CvSize patternSize,
    cv::Point2f *corners, int cornersLength, int patternWasFound)
{
    std::vector<cv::Point2f> cornersVec(corners, corners + cornersLength);
    cv::drawChessboardCorners(*image, patternSize, cornersVec, patternWasFound != 0);
}

static void BlobDetectorDeleter(cv::FeatureDetector *p) {}

CVAPI(int) calib3d_findCirclesGrid_InputArray(cv::_InputArray *image, CvSize patternSize,
    cv::_OutputArray *centers, int flags, cv::FeatureDetector* blobDetector)
{
    if (blobDetector == NULL)
        return cv::findCirclesGrid(*image, patternSize, *centers, flags) ? 1 : 0;

    cv::Ptr<cv::FeatureDetector> detectorPtr(blobDetector, BlobDetectorDeleter); // don't delete
    return cv::findCirclesGrid(*image, patternSize, *centers, flags, detectorPtr) ? 1 : 0;
}
CVAPI(int) calib3d_findCirclesGrid_vector(cv::_InputArray *image, CvSize patternSize,
    std::vector<cv::Point2f> *centers, int flags, cv::FeatureDetector* blobDetector)
{
    if (blobDetector == NULL)
        return cv::findCirclesGrid(*image, patternSize, *centers, flags) ? 1 : 0;

    cv::Ptr<cv::FeatureDetector> detectorPtr(blobDetector, BlobDetectorDeleter); // don't delete
    return cv::findCirclesGrid(*image, patternSize, *centers, flags, detectorPtr) ? 1 : 0;
}

CVAPI(double) calib3d_calibrateCamera_InputArray(
    cv::Mat **objectPoints, int objectPointsSize,
    cv::Mat **imagePoints, int imagePointsSize,
    CvSize imageSize,
    cv::_InputOutputArray *cameraMatrix,
    cv::_InputOutputArray *distCoeffs,
    std::vector<cv::Mat> *rvecs, std::vector<cv::Mat> *tvecs,
    int flags,
    CvTermCriteria criteria)
{
    std::vector<cv::Mat> objectPointsVec(objectPointsSize);
    for (int i = 0; i < objectPointsSize; i++)
        objectPointsVec[i] = *objectPoints[i];
    std::vector<cv::Mat> imagePointsVec(imagePointsSize);
    for (int i = 0; i < imagePointsSize; i++)
        imagePointsVec[i] = *imagePoints[i];

    return cv::calibrateCamera(objectPointsVec, imagePointsVec, imageSize,
        *cameraMatrix, *distCoeffs, *rvecs, *tvecs, flags, criteria);
}
CVAPI(double) calib3d_calibrateCamera_vector(
    cv::Point3f **objectPoints, int opSize1, int *opSize2,
    cv::Point2f **imagePoints, int ipSize1, int *ipSize2,
    CvSize imageSize,
    double *cameraMatrix,
    double *distCoeffs, int distCoeffsSize,
    std::vector<cv::Mat> *rvecs, std::vector<cv::Mat> *tvecs,
    int flags,
    CvTermCriteria criteria)
{
    std::vector<std::vector<cv::Point3f> > objectPointsVec(opSize1);
    for (int i = 0; i < opSize1; i++)
        objectPointsVec[i] = std::vector<cv::Point3f>(objectPoints[i], objectPoints[i] + opSize2[i]);

    std::vector<std::vector<cv::Point2f> > imagePointsVec(ipSize1);
    for (int i = 0; i < ipSize1; i++)
        imagePointsVec[i] = std::vector<cv::Point2f>(imagePoints[i], imagePoints[i] + ipSize2[i]);

    cv::Mat cametaMatrixM(3, 3, CV_64FC1, cameraMatrix);
    cv::Mat distCoeffsM(distCoeffsSize, 1, CV_64FC1, distCoeffs);

    return cv::calibrateCamera(objectPointsVec, imagePointsVec, imageSize,
        cametaMatrixM, distCoeffsM, *rvecs, *tvecs, flags, criteria);
}

CVAPI(void) calib3d_calibrationMatrixValues_InputArray(cv::_InputArray *cameraMatrix, CvSize imageSize,
    double apertureWidth, double apertureHeight, double *fovx, double *fovy, double *focalLength,
    cv::Point2d *principalPoint, double *aspectRatio)
{
    double fovx0, fovy0, focalLength0, aspectRatio0;
    cv::Point2d principalPoint0;
    cv::calibrationMatrixValues(*cameraMatrix, imageSize, apertureWidth, apertureHeight,
        fovx0, fovy0, focalLength0, principalPoint0, aspectRatio0);
    *fovx = fovx0;
    *fovy = fovy0;
    *principalPoint = principalPoint0;
    *focalLength = focalLength0;
    *aspectRatio = aspectRatio0;
}
CVAPI(void) calib3d_calibrationMatrixValues_array(double *cameraMatrix, CvSize imageSize,
    double apertureWidth, double apertureHeight, double *fovx, double *fovy, double *focalLength,
    cv::Point2d *principalPoint, double *aspectRatio)
{
    cv::Mat cameraMatrixM(3, 3, CV_64FC1, cameraMatrix);
    cv::_InputArray cameraMatrixI(cameraMatrixM);
    calib3d_calibrationMatrixValues_InputArray(&cameraMatrixI, imageSize, apertureWidth, apertureHeight,
        fovx, fovy, focalLength, principalPoint, aspectRatio);
}

CVAPI(double) calib3d_stereoCalibrate_InputArray(cv::_InputArray **objectPoints, int opSize,
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
    MyCvTermCriteria criteria)
{
    std::vector<cv::_InputArray> objectPointsVec(opSize);
    std::vector<cv::_InputArray> imagePoints1Vec(ip1Size);
    std::vector<cv::_InputArray> imagePoints2Vec(ip2Size);
    for (int i = 0; i < opSize; i++)
        objectPointsVec[i] = *objectPoints[i];
    for (int i = 0; i < ip1Size; i++)
        imagePoints1Vec[i] = *imagePoints1[i];
    for (int i = 0; i < ip2Size; i++)
        imagePoints2Vec[i] = *imagePoints2[i];

    return cv::stereoCalibrate(objectPointsVec, imagePoints1Vec, imagePoints2Vec,
        *cameraMatrix1, *distCoeffs1,
        *cameraMatrix2, *distCoeffs2,
        cpp(imageSize), entity(R), entity(T), entity(E), entity(F), flags, cpp(criteria));
}
CVAPI(double) calib3d_stereoCalibrate_array(
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
    MyCvTermCriteria criteria    )
{
    std::vector<std::vector<cv::Point3f> > objectPointsVec(opSize1);
    std::vector<std::vector<cv::Point2f> > imagePoints1Vec(ip1Size1);
    std::vector<std::vector<cv::Point2f> > imagePoints2Vec(ip2Size1);
    for (int i = 0; i < opSize1; i++)
        objectPointsVec[i] = std::vector<cv::Point3f>(
        objectPoints[i], objectPoints[i] + opSizes2[i]);
    for (int i = 0; i < ip1Size1; i++)
        imagePoints1Vec[i] = std::vector<cv::Point2f>(
        imagePoints1[i], imagePoints1[i] + ip1Sizes2[i]);
    for (int i = 0; i < ip2Size1; i++)
        imagePoints2Vec[i] = std::vector<cv::Point2f>(
        imagePoints2[i], imagePoints2[i] + ip2Sizes2[i]);

    cv::Mat cameraMatrix1M(3, 3, CV_64FC1, cameraMatrix1);
    cv::Mat cameraMatrix2M(3, 3, CV_64FC1, cameraMatrix2);
    cv::Mat distCoeffs1M(dc1Size, 1, CV_64FC1, distCoeffs1);
    cv::Mat distCoeffs2M(dc2Size, 1, CV_64FC1, distCoeffs2);

    return cv::stereoCalibrate(objectPointsVec, imagePoints1Vec, imagePoints2Vec,
        cameraMatrix1M, distCoeffs1M,
        cameraMatrix2M, distCoeffs2M,
        cpp(imageSize), entity(R), entity(T), entity(E), entity(F), flags, cpp(criteria));
}

CVAPI(void) calib3d_stereoRectify_InputArray(
    cv::_InputArray *cameraMatrix1, cv::_InputArray *distCoeffs1,
    cv::_InputArray *cameraMatrix2, cv::_InputArray *distCoeffs2,
    MyCvSize imageSize, cv::_InputArray *R, cv::_InputArray *T,
    cv::_OutputArray *R1, cv::_OutputArray *R2,
    cv::_OutputArray *P1, cv::_OutputArray *P2,
    cv::_OutputArray *Q, int flags,
    double alpha, CvSize newImageSize,
    CvRect *validPixROI1, CvRect *validPixROI2)
{
    cv::Rect _validPixROI1, _validPixROI2;
    cv::stereoRectify(*cameraMatrix1, *distCoeffs1, *cameraMatrix2, *distCoeffs2,
        cpp(imageSize), *R, *T, *R1, *R2, *P1, *P2, *Q, flags, alpha, newImageSize,
        &_validPixROI1, &_validPixROI2);
    *validPixROI1 = _validPixROI1;
    *validPixROI2 = _validPixROI2;
}
CVAPI(void) calib3d_stereoRectify_array(double *cameraMatrix1,
    double *distCoeffs1, int dc1Size,
    double *cameraMatrix2,
    double *distCoeffs2, int dc2Size,
    MyCvSize imageSize,
    double *R, double *T,
    double *R1, double *R2, double *P1, double *P2,
    double *Q, int flags, double alpha, MyCvSize newImageSize,
    CvRect *validPixROI1, CvRect *validPixROI2)
{
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
    *validPixROI1 = _validPixROI1;
    *validPixROI2 = _validPixROI2;
}

CVAPI(int) calib3d_stereoRectifyUncalibrated_InputArray(cv::_InputArray *points1, cv::_InputArray *points2,
    cv::_InputArray *F, MyCvSize imgSize,
    cv::_OutputArray *H1, cv::_OutputArray *H2,
    double threshold)
{
    return cv::stereoRectifyUncalibrated(*points1, *points2, *F, cpp(imgSize), *H1, *H2, threshold) ? 1 : 0;
}
CVAPI(int) calib3d_stereoRectifyUncalibrated_array(cv::Point2d *points1, int points1Size,
    cv::Point2d *points2, int points2Size,
    cv::_InputArray *F, MyCvSize imgSize,
    double *H1, double *H2,
    double threshold)
{
    cv::Mat points1Mat(points1Size, 1, CV_64FC2, points1);
    cv::Mat points2Mat(points2Size, 1, CV_64FC2, points2);
    cv::Mat H1M(3, 3, CV_64FC1, H1);
    cv::Mat H2M(3, 3, CV_64FC1, H2);
    return cv::stereoRectifyUncalibrated(points1Mat, points2Mat, *F, cpp(imgSize), H1M, H2M, threshold) ? 1 : 0;
}

CVAPI(float) calib3d_rectify3Collinear_InputArray(
    cv::_InputArray *cameraMatrix1, cv::_InputArray *distCoeffs1,
    cv::_InputArray *cameraMatrix2, cv::_InputArray *distCoeffs2,
    cv::_InputArray *cameraMatrix3, cv::_InputArray *distCoeffs3,
    cv::_InputArray **imgpt1, int imgpt1Size,
    cv::_InputArray **imgpt3, int imgpt3Size,
    CvSize imageSize, cv::_InputArray *R12, cv::_InputArray *T12,
    cv::_InputArray *R13, cv::_InputArray *T13,
    cv::_OutputArray *R1, cv::_OutputArray *R2, cv::_OutputArray *R3,
    cv::_OutputArray *P1, cv::_OutputArray *P2, cv::_OutputArray *P3,
    cv::_OutputArray *Q, double alpha, CvSize newImgSize,
    CvRect *roi1, CvRect *roi2, int flags)
{
    std::vector<cv::_InputArray> imgpt1Vec(imgpt1Size);
    std::vector<cv::_InputArray> imgpt3Vec(imgpt3Size);
    for (int i = 0; i < imgpt1Size; i++)
        imgpt1Vec[i] = *(imgpt1[i]);
    for (int i = 0; i < imgpt1Size; i++)
        imgpt3Vec[i] = *(imgpt3[i]);
    cv::Rect _roi1, _roi2;

    float ret = cv::rectify3Collinear(*cameraMatrix1, *distCoeffs1,
        *cameraMatrix2, *distCoeffs2, *cameraMatrix3, *distCoeffs3,
        imgpt1Vec, imgpt3Vec, imageSize, *R12, *T12, *R13, *T13,
        *R1, *R2, *R3, *P1, *P2, *P3, *Q, alpha, newImgSize,
        &_roi1, &_roi2, flags);
    *roi1 = _roi1;
    *roi2 = _roi2;
    return ret;
}

CVAPI(cv::Mat*) calib3d_getOptimalNewCameraMatrix_InputArray(
    cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
    MyCvSize imageSize, double alpha, MyCvSize newImgSize,
    CvRect* validPixROI, int centerPrincipalPoint)
{
    cv::Rect _validPixROI;
    cv::Mat mat = cv::getOptimalNewCameraMatrix(*cameraMatrix, entity(distCoeffs),
        cpp(imageSize), alpha, cpp(newImgSize), &_validPixROI, centerPrincipalPoint != 0);
    *validPixROI = _validPixROI;
    return new cv::Mat(mat);
}
CVAPI(void) calib3d_getOptimalNewCameraMatrix_array(
    double *cameraMatrix,
    double *distCoeffs, int distCoeffsSize,
    MyCvSize imageSize, double alpha, MyCvSize newImgSize,
    CvRect* validPixROI, int centerPrincipalPoint,
    double *outValues)
{
    CvMat cameraMatrixM = cvMat(3, 3, CV_64FC1, cameraMatrix);
    CvMat distCoeffsM = cvMat(distCoeffsSize, 1, CV_64FC1, distCoeffs);
    CvMat *pdistCoeffsM = (distCoeffs == NULL) ? NULL : &distCoeffsM;
    CvMat newCameraMatrix = cvMat(3, 3, CV_64FC1, outValues);

    cvGetOptimalNewCameraMatrix(&cameraMatrixM, pdistCoeffsM, cpp(imageSize),
        alpha, &newCameraMatrix, cpp(newImgSize), validPixROI, centerPrincipalPoint != 0);
}

CVAPI(void) calib3d_convertPointsToHomogeneous_InputArray(cv::_InputArray *src, cv::_OutputArray *dst)
{
    cv::convertPointsToHomogeneous(*src, *dst);
}
CVAPI(void) calib3d_convertPointsToHomogeneous_array1(cv::Vec2f *src, cv::Vec3f *dst, int length)
{
    cv::Mat srcMat(length, 1, CV_64FC2, src);
    cv::Mat dstMat(length, 1, CV_64FC3, dst);
    cv::convertPointsFromHomogeneous(srcMat, dstMat);
}
CVAPI(void) calib3d_convertPointsToHomogeneous_array2(cv::Vec3f *src, cv::Vec4f *dst, int length)
{
    cv::Mat srcMat(length, 1, CV_64FC3, src);
    cv::Mat dstMat(length, 1, CV_64FC4, dst);
    cv::convertPointsFromHomogeneous(srcMat, dstMat);
}

CVAPI(void) calib3d_convertPointsFromHomogeneous_InputArray(cv::_InputArray *src, cv::_OutputArray *dst)
{
    cv::convertPointsFromHomogeneous(*src, *dst);
}
CVAPI(void) calib3d_convertPointsFromHomogeneous_array1(cv::Vec3f *src, cv::Vec2f *dst, int length)
{
    cv::Mat srcMat(length, 1, CV_64FC3, src);
    cv::Mat dstMat(length, 1, CV_64FC2, dst);
    cv::convertPointsFromHomogeneous(srcMat, dstMat);
}
CVAPI(void) calib3d_convertPointsFromHomogeneous_array2(cv::Vec4f *src, cv::Vec3f *dst, int length)
{
    cv::Mat srcMat(length, 1, CV_64FC4, src);
    cv::Mat dstMat(length, 1, CV_64FC3, dst);
    cv::convertPointsFromHomogeneous(srcMat, dstMat);
}

CVAPI(void) calib3d_convertPointsHomogeneous(cv::_InputArray *src, cv::_OutputArray *dst)
{
    cv::convertPointsHomogeneous(*src, *dst);
}

CVAPI(cv::Mat*) calib3d_findFundamentalMat_InputArray(
    cv::_InputArray *points1, cv::_InputArray *points2,
    int method, double param1, double param2,
    cv::_OutputArray *mask)
{
    cv::Mat mat = cv::findFundamentalMat(
        *points1, *points2, method, param1, param2, entity(mask));
    return new cv::Mat(mat);
}
CVAPI(cv::Mat*) calib3d_findFundamentalMat_array(
    cv::Point2d *points1, int points1Size,
    cv::Point2d *points2, int points2Size,
    int method, double param1, double param2,
    cv::_OutputArray *mask)
{
    cv::Mat points1M(points1Size, 1, CV_64FC2, points1);
    cv::Mat points2M(points2Size, 1, CV_64FC2, points2);
    cv::Mat mat = cv::findFundamentalMat(
        points1M, points2M, method, param1, param2, entity(mask));
    return new cv::Mat(mat);
}

CVAPI(void) calib3d_computeCorrespondEpilines_InputArray(
    cv::_InputArray *points,
    int whichImage, cv::_InputArray *F,
    cv::_OutputArray *lines)
{
    cv::computeCorrespondEpilines(*points, whichImage, *F, *lines);
}
CVAPI(void) calib3d_computeCorrespondEpilines_array2d(
    cv::Point2d *points, int pointsSize,
    int whichImage, double *F,
    cv::Point3f *lines)
{
    cv::Mat_<cv::Point2d> pointsM(pointsSize, 1, points);
    cv::Mat_<double> FM(3, 3, F);
    cv::Mat_<cv::Point3f> linesM(pointsSize, 1, lines);
    cv::computeCorrespondEpilines(pointsM, whichImage, FM, linesM);
}
CVAPI(void) calib3d_computeCorrespondEpilines_array3d(
    cv::Point3d *points, int pointsSize,
    int whichImage, double *F,
    cv::Point3f *lines)
{
    cv::Mat_<cv::Point3d> pointsM(pointsSize, 1, points);
    cv::Mat_<double> FM(3, 3, F);
    cv::Mat_<cv::Point3f> linesM(pointsSize, 1, lines);
    cv::computeCorrespondEpilines(pointsM, whichImage, FM, linesM);
}

CVAPI(void) calib3d_triangulatePoints_InputArray(
    cv::_InputArray *projMatr1, cv::_InputArray *projMatr2,
    cv::_InputArray *projPoints1, cv::_InputArray *projPoints2,
    cv::_OutputArray *points4D)
{
    cv::triangulatePoints(*projMatr1, *projMatr2, *projPoints1, *projPoints2, *points4D);
}
CVAPI(void) calib3d_triangulatePoints_array(
    double *projMatr1, double *projMatr2,
    cv::Point2d *projPoints1, int projPoints1Size,
    cv::Point2d *projPoints2, int projPoints2Size,
    cv::Vec4d *points4D)
{
    cv::Mat_<double> projMatr1M(3, 4, projMatr1);
    cv::Mat_<double> projMatr2M(3, 4, projMatr2);
    cv::Mat_<cv::Point2d> projPoints1M(projPoints1Size, 1, projPoints1);
    cv::Mat_<cv::Point2d> projPoints2M(projPoints2Size, 1, projPoints2);
    cv::Mat_<cv::Vec4d> points4DM(1, projPoints1Size, points4D);
    cv::triangulatePoints(projMatr1M, projMatr2M,
        projPoints1M, projPoints2M, points4DM);
}

CVAPI(void) calib3d_correctMatches_InputArray(
    cv::_InputArray *F, cv::_InputArray *points1, cv::_InputArray *points2,
    cv::_OutputArray *newPoints1, cv::_OutputArray *newPoints2)
{
    cv::correctMatches(*F, *points1, *points2, *newPoints1, *newPoints2);
}
CVAPI(void) calib3d_correctMatches_array(double *F,
    cv::Point2d *points1, int points1Size,
    cv::Point2d *points2, int points2Size,
    cv::Point2d *newPoints1, cv::Point2d *newPoints2)
{
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
}


CVAPI(void) calib3d_filterSpeckles(cv::_InputOutputArray *img, double newVal, int maxSpeckleSize, double maxDiff,
    cv::_InputOutputArray *buf)
{
    cv::filterSpeckles(*img, newVal, maxSpeckleSize, maxDiff, entity(buf));
}

CVAPI(MyCvRect) calib3d_getValidDisparityROI(MyCvRect roi1, MyCvRect roi2,
    int minDisparity, int numberOfDisparities, int SADWindowSize)
{
    return c(cv::getValidDisparityROI(
        cpp(roi1), cpp(roi2), minDisparity, numberOfDisparities, SADWindowSize));
}

CVAPI(void) calib3d_validateDisparity(cv::_InputOutputArray *disparity, cv::_InputArray *cost,
    int minDisparity, int numberOfDisparities, int disp12MaxDisp)
{
    cv::validateDisparity(*disparity, *cost, minDisparity, numberOfDisparities, disp12MaxDisp);
}

CVAPI(void) calib3d_reprojectImageTo3D(cv::_InputArray *disparity, cv::_OutputArray *_3dImage,
    cv::_InputArray *Q, int handleMissingValues, int ddepth)
{
    cv::reprojectImageTo3D(*disparity, *_3dImage, *Q, handleMissingValues != 0, ddepth);
}

CVAPI(int) calib3d_estimateAffine3D(cv::_InputArray *src, cv::_InputArray *dst,
    cv::_OutputArray *out, cv::_OutputArray *inliers,
    double ransacThreshold, double confidence)
{
    return cv::estimateAffine3D(*src, *dst, *out, *inliers, ransacThreshold, confidence);
}

#endif