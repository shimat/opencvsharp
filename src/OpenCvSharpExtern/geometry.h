#pragma once

#ifndef NO_GEOMETRY

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

struct CV_EXPORTS_W_SIMPLE MyUsacParams
{
    double confidence;
    int isParallel;
    int loIterations;
    cv::LocalOptimMethod loMethod;
    int loSampleSize;
    int maxIterations;
    cv::NeighborSearchMethod neighborsSearch;
    int randomGeneratorState;
    cv::SamplingMethod sampler;
    cv::ScoreMethod score;
    double threshold;
};

CVAPI(ExceptionStatus) geometry_Rodrigues(cv::_InputArray *src, cv::_OutputArray *dst, cv::_OutputArray *jacobian)
{
    BEGIN_WRAP
    cv::Rodrigues(*src, *dst, entity(jacobian));
    END_WRAP
}


CVAPI(ExceptionStatus) geometry_findHomography_InputArray(
    cv::_InputArray *srcPoints, cv::_InputArray *dstPoints,
    int method, double ransacReprojThreshold, cv::_OutputArray *mask,
    int maxIters, double confidence,
    cv::Mat** returnValue)
{
    BEGIN_WRAP
    const auto ret = cv::findHomography(*srcPoints, *dstPoints, method, ransacReprojThreshold, entity(mask), maxIters, confidence);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) geometry_findHomography_vector(
    cv::Point2d *srcPoints, int srcPointsLength,
    cv::Point2d *dstPoints, int dstPointsLength,
    int method, double ransacReprojThreshold, cv::_OutputArray *mask,
    int maxIters, double confidence,
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    const cv::Mat srcPointsMat(srcPointsLength, 1, CV_64FC2, srcPoints);
    const cv::Mat dstPointsMat(dstPointsLength, 1, CV_64FC2, dstPoints);

    const auto ret = cv::findHomography(srcPointsMat, dstPointsMat, method, ransacReprojThreshold, entity(mask), maxIters, confidence);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) geometry_findHomography_UsacParams(
    cv::_InputArray* srcPoints, cv::_InputArray* dstPoints, cv::_OutputArray* mask, MyUsacParams *params,
    cv::Mat** returnValue)
{
    BEGIN_WRAP
    cv::UsacParams p;
    p.confidence = params->confidence;
    p.isParallel = params->isParallel != 0;
    p.loIterations = params->loIterations;
    p.loMethod = params->loMethod;
    p.loSampleSize = params->loSampleSize;
    p.maxIterations = params->maxIterations;
    p.neighborsSearch = params->neighborsSearch;
    p.randomGeneratorState = params->randomGeneratorState;
    p.sampler = params->sampler;
    p.score = params->score;
    p.threshold = params->threshold;
    const auto ret = cv::findHomography(*srcPoints, *dstPoints, entity(mask), p);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}


CVAPI(ExceptionStatus) geometry_RQDecomp3x3_InputArray(
    cv::_InputArray *src, cv::_OutputArray *mtxR, cv::_OutputArray *mtxQ,
    cv::_OutputArray *qx, cv::_OutputArray *qy, cv::_OutputArray *qz, cv::Vec3d *outVec)
{
    BEGIN_WRAP
    *outVec = cv::RQDecomp3x3(*src, *mtxR, *mtxQ, entity(qx), entity(qy), entity(qz));
    END_WRAP
}

CVAPI(ExceptionStatus) geometry_RQDecomp3x3_Mat(
    cv::Mat *src, cv::Mat *mtxR, cv::Mat *mtxQ,
    cv::Mat *qx, cv::Mat *qy, cv::Mat *qz, cv::Vec3d *outVec)
{
    BEGIN_WRAP
    *outVec = cv::RQDecomp3x3(*src, *mtxR, *mtxQ, *qx, *qy, *qz);
    END_WRAP
}


CVAPI(ExceptionStatus) geometry_decomposeProjectionMatrix_InputArray(
    cv::_InputArray *projMatrix, cv::_OutputArray *cameraMatrix,
    cv::_OutputArray *rotMatrix, cv::_OutputArray *transVect, cv::_OutputArray *rotMatrixX,
    cv::_OutputArray *rotMatrixY, cv::_OutputArray *rotMatrixZ, cv::_OutputArray *eulerAngles)
{
    BEGIN_WRAP
    cv::decomposeProjectionMatrix(*projMatrix, *cameraMatrix, *rotMatrix,
        *transVect, entity(rotMatrixX), entity(rotMatrixY), entity(rotMatrixZ), entity(eulerAngles));
    END_WRAP
}

CVAPI(ExceptionStatus) geometry_decomposeProjectionMatrix_Mat(
    cv::Mat *projMatrix, cv::Mat *cameraMatrix,
    cv::Mat *rotMatrix, cv::Mat *transVect, cv::Mat *rotMatrixX,
    cv::Mat *rotMatrixY, cv::Mat *rotMatrixZ, cv::Mat *eulerAngles)
{
    BEGIN_WRAP
    cv::decomposeProjectionMatrix(*projMatrix, *cameraMatrix, *rotMatrix,
        *transVect, *rotMatrixX, *rotMatrixY, *rotMatrixZ, *eulerAngles);
    END_WRAP
}


CVAPI(ExceptionStatus) geometry_matMulDeriv(
    cv::_InputArray *a, cv::_InputArray *b,
    cv::_OutputArray *dABdA, cv::_OutputArray *dABdB)
{
    BEGIN_WRAP
    cv::matMulDeriv(*a, *b, *dABdA, *dABdB);
    END_WRAP
}


CVAPI(ExceptionStatus) geometry_composeRT_InputArray(
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


CVAPI(ExceptionStatus) geometry_composeRT_Mat(
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


CVAPI(ExceptionStatus) geometry_projectPoints_InputArray(
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

CVAPI(ExceptionStatus) geometry_projectPoints_Mat(
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


CVAPI(ExceptionStatus) geometry_solvePnP_InputArray(
    cv::_InputArray *objectPoints, cv::_InputArray *imagePoints, cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
    cv::_OutputArray *rvec, cv::_OutputArray *tvec, int useExtrinsicGuess, int flags)
{
    BEGIN_WRAP
    cv::solvePnP(*objectPoints, *imagePoints, *cameraMatrix, entity(distCoeffs), *rvec, *tvec, useExtrinsicGuess != 0, flags);
    END_WRAP
}

CVAPI(ExceptionStatus) geometry_solvePnP_vector(cv::Point3f *objectPoints, int objectPointsLength,
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
    cv::Matx<double, 3, 1> rvecMat(rvec), tvecMat(tvec);
    cv::solvePnP(objectPointsMat, imagePointsMat, cameraMatrixMat, distCoeffsMat, rvecMat, tvecMat, useExtrinsicGuess != 0, flags);
    memcpy(rvec, rvecMat.val, sizeof(double) * 3);
    memcpy(tvec, tvecMat.val, sizeof(double) * 3);
    END_WRAP
}


CVAPI(ExceptionStatus) geometry_solvePnPRansac_InputArray(
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

CVAPI(ExceptionStatus) geometry_solvePnPRansac_vector(
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


CVAPI(ExceptionStatus) geometry_calibrationMatrixValues_InputArray(cv::_InputArray *cameraMatrix, MyCvSize imageSize,
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

CVAPI(ExceptionStatus) geometry_calibrationMatrixValues_array(double *cameraMatrix, MyCvSize imageSize,
    double apertureWidth, double apertureHeight, double *fovx, double *fovy, double *focalLength,
    cv::Point2d *principalPoint, double *aspectRatio)
{
    BEGIN_WRAP
    const cv::Mat cameraMatrixM(3, 3, CV_64FC1, cameraMatrix);
    cv::_InputArray cameraMatrixI(cameraMatrixM);
    geometry_calibrationMatrixValues_InputArray(&cameraMatrixI, imageSize, apertureWidth, apertureHeight,
        fovx, fovy, focalLength, principalPoint, aspectRatio);
    END_WRAP
}


CVAPI(ExceptionStatus) geometry_getOptimalNewCameraMatrix_InputArray(
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

CVAPI(ExceptionStatus) geometry_getOptimalNewCameraMatrix_array(
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


CVAPI(ExceptionStatus) geometry_convertPointsToHomogeneous_InputArray(cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::convertPointsToHomogeneous(*src, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) geometry_convertPointsToHomogeneous_array1(cv::Vec2f *src, cv::Vec3f *dst, int length)
{
    BEGIN_WRAP
    const cv::Mat srcMat(length, 1, CV_64FC2, src);
    cv::Mat dstMat(length, 1, CV_64FC3, dst);
    cv::convertPointsFromHomogeneous(srcMat, dstMat);
    END_WRAP
}

CVAPI(ExceptionStatus) geometry_convertPointsToHomogeneous_array2(cv::Vec3f *src, cv::Vec4f *dst, int length)
{
    BEGIN_WRAP
    const cv::Mat srcMat(length, 1, CV_64FC3, src);
    cv::Mat dstMat(length, 1, CV_64FC4, dst);
    cv::convertPointsFromHomogeneous(srcMat, dstMat);
    END_WRAP
}


CVAPI(ExceptionStatus) geometry_convertPointsFromHomogeneous_InputArray(cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::convertPointsFromHomogeneous(*src, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) geometry_convertPointsFromHomogeneous_array1(cv::Vec3f *src, cv::Vec2f *dst, int length)
{
    BEGIN_WRAP
    const cv::Mat srcMat(length, 1, CV_64FC3, src);
    cv::Mat dstMat(length, 1, CV_64FC2, dst);
    cv::convertPointsFromHomogeneous(srcMat, dstMat);
    END_WRAP
}

CVAPI(ExceptionStatus) geometry_convertPointsFromHomogeneous_array2(cv::Vec4f *src, cv::Vec3f *dst, int length)
{
    BEGIN_WRAP
    const cv::Mat srcMat(length, 1, CV_64FC4, src);
    cv::Mat dstMat(length, 1, CV_64FC3, dst);
    cv::convertPointsFromHomogeneous(srcMat, dstMat);
    END_WRAP
}


CVAPI(ExceptionStatus) geometry_convertPointsHomogeneous(cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::convertPointsHomogeneous(*src, *dst);
    END_WRAP
}


CVAPI(ExceptionStatus) geometry_findFundamentalMat_InputArray(
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

CVAPI(ExceptionStatus) geometry_findFundamentalMat_arrayF64(
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

CVAPI(ExceptionStatus) geometry_findFundamentalMat_arrayF32(
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


CVAPI(ExceptionStatus) geometry_computeCorrespondEpilines_InputArray(
    cv::_InputArray *points,
    int whichImage, cv::_InputArray *F,
    cv::_OutputArray *lines)
{
    BEGIN_WRAP
    cv::computeCorrespondEpilines(*points, whichImage, *F, *lines);
    END_WRAP
}

CVAPI(ExceptionStatus) geometry_computeCorrespondEpilines_array2d(
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

CVAPI(ExceptionStatus) geometry_computeCorrespondEpilines_array3d(
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


CVAPI(ExceptionStatus) geometry_triangulatePoints_InputArray(
    cv::_InputArray *projMatr1, cv::_InputArray *projMatr2,
    cv::_InputArray *projPoints1, cv::_InputArray *projPoints2,
    cv::_OutputArray *points4D)
{
    BEGIN_WRAP
    cv::triangulatePoints(*projMatr1, *projMatr2, *projPoints1, *projPoints2, *points4D);
    END_WRAP
}

CVAPI(ExceptionStatus) geometry_triangulatePoints_array(
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


CVAPI(ExceptionStatus) geometry_correctMatches_InputArray(
    cv::_InputArray *F, cv::_InputArray *points1, cv::_InputArray *points2,
    cv::_OutputArray *newPoints1, cv::_OutputArray *newPoints2)
{
    BEGIN_WRAP
    cv::correctMatches(*F, *points1, *points2, *newPoints1, *newPoints2);
    END_WRAP
}

CVAPI(ExceptionStatus) geometry_correctMatches_array(
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


CVAPI(ExceptionStatus) geometry_estimateAffine3D(cv::_InputArray *src, cv::_InputArray *dst,
    cv::_OutputArray *out, cv::_OutputArray *inliers,
    double ransacThreshold, double confidence,
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::estimateAffine3D(*src, *dst, *out, *inliers, ransacThreshold, confidence);
    END_WRAP
}



CVAPI(ExceptionStatus) geometry_sampsonDistance_InputArray(
    cv::_InputArray *pt1, cv::_InputArray *pt2, cv::_InputArray *F,
    double *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::sampsonDistance(*pt1, *pt2, *F);
    END_WRAP
}

CVAPI(ExceptionStatus) geometry_sampsonDistance_Point3d(
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


CVAPI(ExceptionStatus) geometry_estimateAffine2D(
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


CVAPI(ExceptionStatus) geometry_estimateAffinePartial2D(
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


CVAPI(ExceptionStatus) geometry_decomposeHomographyMat(
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


CVAPI(ExceptionStatus) geometry_filterHomographyDecompByVisibleRefpoints(
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


CVAPI(ExceptionStatus) geometry_getDefaultNewCameraMatrix(
    cv::_InputArray *cameraMatrix, MyCvSize imgsize, int centerPrincipalPoint,
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto result = cv::getDefaultNewCameraMatrix(*cameraMatrix, cpp(imgsize), centerPrincipalPoint != 0);
    *returnValue = new cv::Mat(result);
    END_WRAP
}


CVAPI(ExceptionStatus) geometry_undistortPoints(
    cv::_InputArray *src, cv::_OutputArray *dst,
    cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
    cv::_InputArray *R, cv::_InputArray *P)
{
    BEGIN_WRAP
    cv::undistortPoints(*src, *dst, *cameraMatrix, *distCoeffs, entity(R), entity(P));
    END_WRAP
}


CVAPI(ExceptionStatus) geometry_undistortPointsIter(
    cv::_InputArray *src, cv::_OutputArray *dst,
    cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
    cv::_InputArray *R, cv::_InputArray *P, MyCvTermCriteria criteria)
{
    BEGIN_WRAP
    cv::undistortPoints(*src, *dst, *cameraMatrix, *distCoeffs, entity(R), entity(P), cpp(criteria));
    END_WRAP
}


CVAPI(ExceptionStatus) geometry_recoverPose_InputArray1(
    cv::_InputArray *E, cv::_InputArray *points1, cv::_InputArray *points2,
    cv::_InputArray *cameraMatrix,
    cv::_OutputArray *R, cv::_OutputArray *t, cv::_InputOutputArray *mask,
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::recoverPose(*E, *points1, *points2, *cameraMatrix, *R, *t, entity(mask));
    END_WRAP
}


CVAPI(ExceptionStatus) geometry_recoverPose_InputArray2(
    cv::_InputArray *E, cv::_InputArray *points1, cv::_InputArray *points2,
    cv::_OutputArray *R, cv::_OutputArray *t, double focal, MyCvPoint2D64f pp,
    cv::_InputOutputArray *mask,
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::recoverPose(*E, *points1, *points2, *R, *t, focal, cpp(pp), entity(mask));
    END_WRAP
}


CVAPI(ExceptionStatus) geometry_recoverPose_InputArray3(
    cv::_InputArray *E, cv::_InputArray *points1, cv::_InputArray *points2,
    cv::_InputArray *cameraMatrix,
    cv::_OutputArray *R, cv::_OutputArray *t, double distanceTresh,
    cv::_InputOutputArray *mask, cv::_OutputArray *triangulatedPoints,
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::recoverPose(*E, *points1, *points2, *cameraMatrix, *R, *t, distanceTresh, entity(mask), entity(triangulatedPoints));
    END_WRAP
}


CVAPI(ExceptionStatus) geometry_findEssentialMat_InputArray1(
    cv::_InputArray *points1, cv::_InputArray *points2, cv::_InputArray *cameraMatrix,
    int method, double prob, double threshold,
    cv::_OutputArray *mask,
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto mat = cv::findEssentialMat(
        *points1, *points2, *cameraMatrix, method, prob, threshold, 1000, entity(mask));
    *returnValue = new cv::Mat(mat);
    END_WRAP
}

CVAPI(ExceptionStatus) geometry_findEssentialMat_InputArray2(
    cv::_InputArray *points1, cv::_InputArray *points2, double focal, MyCvPoint2D64f pp,
    int method, double prob, double threshold,
    cv::_OutputArray *mask,
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto mat = cv::findEssentialMat(
        *points1, *points2, focal, cpp(pp), method, prob, threshold, 1000, entity(mask));
    *returnValue = new cv::Mat(mat);
    END_WRAP
}


CVAPI(ExceptionStatus) geometry_solvePnPRefineLM(
    cv::_InputArray *objectPoints, cv::_InputArray *imagePoints, cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
    cv::_InputOutputArray *rvec, cv::_InputOutputArray *tvec, MyCvTermCriteria criteria)
{
    BEGIN_WRAP
    cv::solvePnPRefineLM(*objectPoints, *imagePoints, *cameraMatrix, *distCoeffs, *rvec, *tvec, cpp(criteria));
    END_WRAP
}

CVAPI(ExceptionStatus) geometry_solvePnPRefineVVS(
    cv::_InputArray *objectPoints, cv::_InputArray *imagePoints, cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
    cv::_InputOutputArray *rvec, cv::_InputOutputArray *tvec, MyCvTermCriteria criteria, double vvsLambda)
{
    BEGIN_WRAP
    cv::solvePnPRefineVVS(*objectPoints, *imagePoints, *cameraMatrix, *distCoeffs, *rvec, *tvec, cpp(criteria), vvsLambda);
    END_WRAP
}

CVAPI(ExceptionStatus) geometry_decomposeEssentialMat(
    cv::_InputArray *e, cv::_OutputArray *r1, cv::_OutputArray *r2, cv::_OutputArray *t)
{
    BEGIN_WRAP
    cv::decomposeEssentialMat(*e, *r1, *r2, *t);
    END_WRAP
}

CVAPI(ExceptionStatus) geometry_estimateTranslation3D(
    cv::_InputArray *src, cv::_InputArray *dst, cv::_OutputArray *out, cv::_OutputArray *inliers,
    double ransacThreshold, double confidence, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::estimateTranslation3D(*src, *dst, *out, *inliers, ransacThreshold, confidence) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) geometry_estimateTranslation2D(
    cv::_InputArray *from, cv::_InputArray *to, cv::_OutputArray *inliers,
    int method, double ransacReprojThreshold, uint64_t maxIters, double confidence, uint64_t refineIters,
    cv::Vec2d *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::estimateTranslation2D(
        *from, *to, entity(inliers), method, ransacReprojThreshold,
        static_cast<size_t>(maxIters), confidence, static_cast<size_t>(refineIters));
    END_WRAP
}

#endif // NO_GEOMETRY
