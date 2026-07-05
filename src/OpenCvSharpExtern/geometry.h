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
    cv::PolishingMethod finalPolisher;
    int finalPolisherIterations;
};

CVAPI(ExceptionStatus) geometry_Rodrigues(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    const interop::OutputArrayProxy* jacobian)
{
    return cvTry([&] {
        cv::Rodrigues(InProxy(*src), OutProxy(*dst), OutProxy(*jacobian));
    });
}


CVAPI(ExceptionStatus) geometry_findHomography_InputArray(
    const interop::InputArrayProxy* srcPoints,
    const interop::InputArrayProxy* dstPoints,
    int method,
    double ransacReprojThreshold,
    const interop::OutputArrayProxy* mask,
    int maxIters,
    double confidence,
    cv::Mat** returnValue)
{
    return cvTry([&] {
        const auto ret = cv::findHomography(InProxy(*srcPoints), InProxy(*dstPoints), method, ransacReprojThreshold, OutProxy(*mask), maxIters, confidence);
        *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) geometry_findHomography_vector(
    cv::Point2d *srcPoints,
    int srcPointsLength,
    cv::Point2d *dstPoints,
    int dstPointsLength,
    int method,
    double ransacReprojThreshold,
    const interop::OutputArrayProxy* mask,
    int maxIters,
    double confidence,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        const cv::Mat srcPointsMat(srcPointsLength, 1, CV_64FC2, srcPoints);
        const cv::Mat dstPointsMat(dstPointsLength, 1, CV_64FC2, dstPoints);

        const auto ret = cv::findHomography(srcPointsMat, dstPointsMat, method, ransacReprojThreshold, OutProxy(*mask), maxIters, confidence);
        *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) geometry_findHomography_UsacParams(
    const interop::InputArrayProxy* srcPoints,
    const interop::InputArrayProxy* dstPoints,
    const interop::OutputArrayProxy* mask,
    MyUsacParams *params,
    cv::Mat** returnValue)
{
    return cvTry([&] {
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
        p.final_polisher = params->finalPolisher;
        p.final_polisher_iterations = params->finalPolisherIterations;
        const auto ret = cv::findHomography(InProxy(*srcPoints), InProxy(*dstPoints), OutProxy(*mask), p);
        *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) geometry_findFundamentalMat_UsacParams(
    const interop::InputArrayProxy* points1,
    const interop::InputArrayProxy* points2,
    const interop::OutputArrayProxy* mask,
    MyUsacParams *params,
    cv::Mat** returnValue)
{
    return cvTry([&] {
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
        p.final_polisher = params->finalPolisher;
        p.final_polisher_iterations = params->finalPolisherIterations;
        const auto ret = cv::findFundamentalMat(InProxy(*points1), InProxy(*points2), OutProxy(*mask), p);
        *returnValue = new cv::Mat(ret);
    });
}


CVAPI(ExceptionStatus) geometry_RQDecomp3x3_InputArray(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* mtxR,
    const interop::OutputArrayProxy* mtxQ,
    const interop::OutputArrayProxy* qx,
    const interop::OutputArrayProxy* qy,
    const interop::OutputArrayProxy* qz,
    cv::Vec3d *outVec)
{
    return cvTry([&] {
        *outVec = cv::RQDecomp3x3(InProxy(*src), OutProxy(*mtxR), OutProxy(*mtxQ), OutProxy(*qx), OutProxy(*qy), OutProxy(*qz));
    });
}

CVAPI(ExceptionStatus) geometry_RQDecomp3x3_Mat(
    cv::Mat *src,
    cv::Mat *mtxR,
    cv::Mat *mtxQ,
    cv::Mat *qx,
    cv::Mat *qy,
    cv::Mat *qz,
    cv::Vec3d *outVec)
{
    return cvTry([&] {
        *outVec = cv::RQDecomp3x3(*src, *mtxR, *mtxQ, *qx, *qy, *qz);
    });
}


CVAPI(ExceptionStatus) geometry_decomposeProjectionMatrix_InputArray(
    const interop::InputArrayProxy* projMatrix,
    const interop::OutputArrayProxy* cameraMatrix,
    const interop::OutputArrayProxy* rotMatrix,
    const interop::OutputArrayProxy* transVect,
    const interop::OutputArrayProxy* rotMatrixX,
    const interop::OutputArrayProxy* rotMatrixY,
    const interop::OutputArrayProxy* rotMatrixZ,
    const interop::OutputArrayProxy* eulerAngles)
{
    return cvTry([&] {
        cv::decomposeProjectionMatrix(InProxy(*projMatrix), OutProxy(*cameraMatrix), OutProxy(*rotMatrix),
            OutProxy(*transVect), OutProxy(*rotMatrixX), OutProxy(*rotMatrixY), OutProxy(*rotMatrixZ), OutProxy(*eulerAngles));
    });
}

CVAPI(ExceptionStatus) geometry_decomposeProjectionMatrix_Mat(
    cv::Mat *projMatrix,
    cv::Mat *cameraMatrix,
    cv::Mat *rotMatrix,
    cv::Mat *transVect,
    cv::Mat *rotMatrixX,
    cv::Mat *rotMatrixY,
    cv::Mat *rotMatrixZ,
    cv::Mat *eulerAngles)
{
    return cvTry([&] {
        cv::decomposeProjectionMatrix(*projMatrix, *cameraMatrix, *rotMatrix,
            *transVect, *rotMatrixX, *rotMatrixY, *rotMatrixZ, *eulerAngles);
    });
}


CVAPI(ExceptionStatus) geometry_matMulDeriv(
    const interop::InputArrayProxy* a,
    const interop::InputArrayProxy* b,
    const interop::OutputArrayProxy* dABdA,
    const interop::OutputArrayProxy* dABdB)
{
    return cvTry([&] {
        cv::matMulDeriv(InProxy(*a), InProxy(*b), OutProxy(*dABdA), OutProxy(*dABdB));
    });
}


CVAPI(ExceptionStatus) geometry_composeRT_InputArray(
    const interop::InputArrayProxy* rvec1,
    const interop::InputArrayProxy* tvec1,
    const interop::InputArrayProxy* rvec2,
    const interop::InputArrayProxy* tvec2,
    const interop::OutputArrayProxy* rvec3,
    const interop::OutputArrayProxy* tvec3,
    const interop::OutputArrayProxy* dr3dr1,
    const interop::OutputArrayProxy* dr3dt1,
    const interop::OutputArrayProxy* dr3dr2,
    const interop::OutputArrayProxy* dr3dt2,
    const interop::OutputArrayProxy* dt3dr1,
    const interop::OutputArrayProxy* dt3dt1,
    const interop::OutputArrayProxy* dt3dr2,
    const interop::OutputArrayProxy* dt3dt2)
{
    return cvTry([&] {
        cv::composeRT(InProxy(*rvec1), InProxy(*tvec1), InProxy(*rvec2), InProxy(*tvec2), OutProxy(*rvec3), OutProxy(*tvec3),
            OutProxy(*dr3dr1), OutProxy(*dr3dt1), OutProxy(*dr3dr2), OutProxy(*dr3dt2),
            OutProxy(*dt3dr1), OutProxy(*dt3dt1), OutProxy(*dt3dr2), OutProxy(*dt3dt2));
    });
}


CVAPI(ExceptionStatus) geometry_composeRT_Mat(
    cv::Mat *rvec1,
    cv::Mat *tvec1,
    cv::Mat *rvec2,
    cv::Mat *tvec2,
    cv::Mat *rvec3,
    cv::Mat *tvec3,
    cv::Mat *dr3dr1,
    cv::Mat *dr3dt1,
    cv::Mat *dr3dr2,
    cv::Mat *dr3dt2,
    cv::Mat *dt3dr1,
    cv::Mat *dt3dt1,
    cv::Mat *dt3dr2,
    cv::Mat *dt3dt2)
{
    return cvTry([&] {
        cv::composeRT(*rvec1, *tvec1, *rvec2, *tvec2, *rvec3, *tvec3,
            entity(dr3dr1), entity(dr3dt1), entity(dr3dr2), entity(dr3dt2),
            entity(dt3dr1), entity(dt3dt1), entity(dt3dr2), entity(dt3dt2));
    });
}


CVAPI(ExceptionStatus) geometry_projectPoints_InputArray(
    const interop::InputArrayProxy* objectPoints,
    const interop::InputArrayProxy* rvec,
    const interop::InputArrayProxy* tvec,
    const interop::InputArrayProxy* cameraMatrix,
    const interop::InputArrayProxy* distCoeffs,
    const interop::OutputArrayProxy* imagePoints,
    const interop::OutputArrayProxy* jacobian,
    double aspectRatio)
{
    return cvTry([&] {
        cv::projectPoints(InProxy(*objectPoints), InProxy(*rvec), InProxy(*tvec), InProxy(*cameraMatrix), InProxy(*distCoeffs),
            OutProxy(*imagePoints), OutProxy(*jacobian), aspectRatio);
    });
}

CVAPI(ExceptionStatus) geometry_projectPoints_Mat(
    cv::Mat *objectPoints,
    cv::Mat *rvec,
    cv::Mat *tvec,
    cv::Mat *cameraMatrix,
    cv::Mat *distCoeffs,
    cv::Mat *imagePoints,
    cv::Mat *jacobian,
    double aspectRatio)
{
    return cvTry([&] {
        cv::projectPoints(*objectPoints, *rvec, *tvec, *cameraMatrix, *distCoeffs,
            *imagePoints, *jacobian, aspectRatio);
    });
}


CVAPI(ExceptionStatus) geometry_solvePnP_InputArray(
    const interop::InputArrayProxy* objectPoints,
    const interop::InputArrayProxy* imagePoints,
    const interop::InputArrayProxy* cameraMatrix,
    const interop::InputArrayProxy* distCoeffs,
    const interop::OutputArrayProxy* rvec,
    const interop::OutputArrayProxy* tvec,
    int useExtrinsicGuess,
    int flags)
{
    return cvTry([&] {
        cv::solvePnP(InProxy(*objectPoints), InProxy(*imagePoints), InProxy(*cameraMatrix), InProxy(*distCoeffs), OutProxy(*rvec), OutProxy(*tvec), useExtrinsicGuess != 0, flags);
    });
}

CVAPI(ExceptionStatus) geometry_solvePnP_vector(
    cv::Point3f *objectPoints,
    int objectPointsLength,
    cv::Point2f *imagePoints,
    int imagePointsLength,
    double *cameraMatrix,
    double *distCoeffs,
    int distCoeffsLength,
    double *rvec,
    double *tvec,
    int useExtrinsicGuess,
    int flags)
{
    return cvTry([&] {
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
    });
}


CVAPI(ExceptionStatus) geometry_solvePnPRansac_InputArray(
    const interop::InputArrayProxy* objectPoints,
    const interop::InputArrayProxy* imagePoints,
    const interop::InputArrayProxy* cameraMatrix,
    const interop::InputArrayProxy* distCoeffs,
    const interop::OutputArrayProxy* rvec,
    const interop::OutputArrayProxy* tvec,
    bool useExtrinsicGuess,
    int iterationsCount,
    float reprojectionError,
    double confidence,
    const interop::OutputArrayProxy* inliers,
    int flags)
{
    return cvTry([&] {
        cv::solvePnPRansac(InProxy(*objectPoints), InProxy(*imagePoints), InProxy(*cameraMatrix), InProxy(*distCoeffs), OutProxy(*rvec), OutProxy(*tvec),
            useExtrinsicGuess != 0, iterationsCount, reprojectionError, confidence,
            OutProxy(*inliers), flags);
    });
}

CVAPI(ExceptionStatus) geometry_solvePnPRansac_vector(
    cv::Point3f *objectPoints,
    int objectPointsLength,
    cv::Point2f *imagePoints,
    int imagePointsLength,
    double *cameraMatrix,
    double *distCoeffs,
    int distCoeffsLength,
    double *rvec,
    double *tvec,
    int useExtrinsicGuess,
    int iterationsCount,
    float reprojectionError,
    double confidence,
    std::vector<int> *inliers,
    int flags)
{
    return cvTry([&] {
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
    });
}


CVAPI(ExceptionStatus) geometry_calibrationMatrixValues_InputArray(
    const interop::InputArrayProxy* cameraMatrix,
    interop::Size imageSize,
    double apertureWidth,
    double apertureHeight,
    double *fovx,
    double *fovy,
    double *focalLength,
    cv::Point2d *principalPoint,
    double *aspectRatio)
{
    return cvTry([&] {
        double fovx0, fovy0, focalLength0, aspectRatio0;
        cv::Point2d principalPoint0;
        cv::calibrationMatrixValues(InProxy(*cameraMatrix), cpp(imageSize), apertureWidth, apertureHeight,
            fovx0, fovy0, focalLength0, principalPoint0, aspectRatio0);
        *fovx = fovx0;
        *fovy = fovy0;
        *principalPoint = principalPoint0;
        *focalLength = focalLength0;
        *aspectRatio = aspectRatio0;
    });
}

CVAPI(ExceptionStatus) geometry_calibrationMatrixValues_array(
    double *cameraMatrix,
    interop::Size imageSize,
    double apertureWidth,
    double apertureHeight,
    double *fovx,
    double *fovy,
    double *focalLength,
    cv::Point2d *principalPoint,
    double *aspectRatio)
{
    return cvTry([&] {
        const cv::Mat cameraMatrixM(3, 3, CV_64FC1, cameraMatrix);
        double fovx0, fovy0, focalLength0, aspectRatio0;
        cv::Point2d principalPoint0;
        cv::calibrationMatrixValues(cameraMatrixM, cpp(imageSize), apertureWidth, apertureHeight,
            fovx0, fovy0, focalLength0, principalPoint0, aspectRatio0);
        *fovx = fovx0;
        *fovy = fovy0;
        *principalPoint = principalPoint0;
        *focalLength = focalLength0;
        *aspectRatio = aspectRatio0;
    });
}


CVAPI(ExceptionStatus) geometry_getOptimalNewCameraMatrix_InputArray(
    const interop::InputArrayProxy* cameraMatrix,
    const interop::InputArrayProxy* distCoeffs,
    interop::Size imageSize,
    double alpha,
    interop::Size newImgSize,
    interop::Rect* validPixROI,
    int centerPrincipalPoint,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        cv::Rect _validPixROI;
        const auto mat = cv::getOptimalNewCameraMatrix(InProxy(*cameraMatrix), InProxy(*distCoeffs),
            cpp(imageSize), alpha, cpp(newImgSize), &_validPixROI, centerPrincipalPoint != 0);
        *validPixROI = c(_validPixROI);
        *returnValue = new cv::Mat(mat);
    });
}

CVAPI(ExceptionStatus) geometry_getOptimalNewCameraMatrix_array(
    double *cameraMatrix,
    double *distCoeffs,
    int distCoeffsSize,
    interop::Size imageSize,
    double alpha,
    interop::Size newImgSize,
    interop::Rect* validPixROI,
    int centerPrincipalPoint,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        const cv::Mat cameraMatrixM(3, 3, CV_64FC1, cameraMatrix);
        const auto distCoeffsM = (distCoeffs == nullptr) ? cv::Mat() : cv::Mat(distCoeffsSize, 1, CV_64FC1, distCoeffs);

        cv::Rect _validPixROI;
        const auto mat = cv::getOptimalNewCameraMatrix(cameraMatrixM, distCoeffsM, cpp(imageSize),
            alpha, cpp(newImgSize), &_validPixROI, centerPrincipalPoint != 0);
        *validPixROI = c(_validPixROI);
        *returnValue = new cv::Mat(mat);
    });
}


CVAPI(ExceptionStatus) geometry_convertPointsToHomogeneous_InputArray(const interop::InputArrayProxy* src, const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        cv::convertPointsToHomogeneous(InProxy(*src), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) geometry_convertPointsToHomogeneous_array1(
    cv::Vec2f *src,
    cv::Vec3f *dst,
    int length)
{
    return cvTry([&] {
        const cv::Mat srcMat(length, 1, CV_64FC2, src);
        cv::Mat dstMat(length, 1, CV_64FC3, dst);
        cv::convertPointsFromHomogeneous(srcMat, dstMat);
    });
}

CVAPI(ExceptionStatus) geometry_convertPointsToHomogeneous_array2(
    cv::Vec3f *src,
    cv::Vec4f *dst,
    int length)
{
    return cvTry([&] {
        const cv::Mat srcMat(length, 1, CV_64FC3, src);
        cv::Mat dstMat(length, 1, CV_64FC4, dst);
        cv::convertPointsFromHomogeneous(srcMat, dstMat);
    });
}


CVAPI(ExceptionStatus) geometry_convertPointsFromHomogeneous_InputArray(const interop::InputArrayProxy* src, const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        cv::convertPointsFromHomogeneous(InProxy(*src), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) geometry_convertPointsFromHomogeneous_array1(
    cv::Vec3f *src,
    cv::Vec2f *dst,
    int length)
{
    return cvTry([&] {
        const cv::Mat srcMat(length, 1, CV_64FC3, src);
        cv::Mat dstMat(length, 1, CV_64FC2, dst);
        cv::convertPointsFromHomogeneous(srcMat, dstMat);
    });
}

CVAPI(ExceptionStatus) geometry_convertPointsFromHomogeneous_array2(
    cv::Vec4f *src,
    cv::Vec3f *dst,
    int length)
{
    return cvTry([&] {
        const cv::Mat srcMat(length, 1, CV_64FC4, src);
        cv::Mat dstMat(length, 1, CV_64FC3, dst);
        cv::convertPointsFromHomogeneous(srcMat, dstMat);
    });
}


CVAPI(ExceptionStatus) geometry_convertPointsHomogeneous(const interop::InputArrayProxy* src, const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        cv::convertPointsHomogeneous(InProxy(*src), OutProxy(*dst));
    });
}


CVAPI(ExceptionStatus) geometry_findFundamentalMat_InputArray(
    const interop::InputArrayProxy* points1,
    const interop::InputArrayProxy* points2,
    int method,
    double param1,
    double param2,
    const interop::OutputArrayProxy* mask,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        const auto mat = cv::findFundamentalMat(
            InProxy(*points1), InProxy(*points2), method, param1, param2, OutProxy(*mask));
        *returnValue = new cv::Mat(mat);
    });
}

CVAPI(ExceptionStatus) geometry_findFundamentalMat_arrayF64(
    cv::Point2d *points1,
    int points1Size,
    cv::Point2d *points2,
    int points2Size,
    int method,
    double param1,
    double param2,
    const interop::OutputArrayProxy* mask,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        const cv::Mat points1M(points1Size, 1, CV_64FC2, points1);
        const cv::Mat points2M(points2Size, 1, CV_64FC2, points2);
        const auto mat = cv::findFundamentalMat(
            points1M, points2M, method, param1, param2, OutProxy(*mask));
        *returnValue = new cv::Mat(mat);
    });
}

CVAPI(ExceptionStatus) geometry_findFundamentalMat_arrayF32(
    cv::Point2f *points1,
    int points1Size,
    cv::Point2f *points2,
    int points2Size,
    int method,
    double param1,
    double param2,
    const interop::OutputArrayProxy* mask,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        const cv::Mat points1M(points1Size, 1, CV_32FC2, points1);
        const cv::Mat points2M(points2Size, 1, CV_32FC2, points2);
        const auto mat = cv::findFundamentalMat(
            points1M, points2M, method, param1, param2, OutProxy(*mask));
        *returnValue = new cv::Mat(mat);
    });
}


CVAPI(ExceptionStatus) geometry_computeCorrespondEpilines_InputArray(
    const interop::InputArrayProxy* points,
    int whichImage,
    const interop::InputArrayProxy* F,
    const interop::OutputArrayProxy* lines)
{
    return cvTry([&] {
        cv::computeCorrespondEpilines(InProxy(*points), whichImage, InProxy(*F), OutProxy(*lines));
    });
}

CVAPI(ExceptionStatus) geometry_computeCorrespondEpilines_array2d(
    cv::Point2d *points,
    int pointsSize,
    int whichImage,
    double *F,
    cv::Point3f *lines)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point2d> pointsM(pointsSize, 1, points);
        const cv::Mat_<double> FM(3, 3, F);
        cv::Mat_<cv::Point3f> linesM(pointsSize, 1, lines);
        cv::computeCorrespondEpilines(pointsM, whichImage, FM, linesM);
    });
}

CVAPI(ExceptionStatus) geometry_computeCorrespondEpilines_array3d(
    cv::Point3d *points,
    int pointsSize,
    int whichImage,
    double *F,
    cv::Point3f *lines)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point3d> pointsM(pointsSize, 1, points);
        const cv::Mat_<double> FM(3, 3, F);
        cv::Mat_<cv::Point3f> linesM(pointsSize, 1, lines);
        cv::computeCorrespondEpilines(pointsM, whichImage, FM, linesM);
    });
}


CVAPI(ExceptionStatus) geometry_triangulatePoints_InputArray(
    const interop::InputArrayProxy* projMatr1,
    const interop::InputArrayProxy* projMatr2,
    const interop::InputArrayProxy* projPoints1,
    const interop::InputArrayProxy* projPoints2,
    const interop::OutputArrayProxy* points4D)
{
    return cvTry([&] {
        cv::triangulatePoints(InProxy(*projMatr1), InProxy(*projMatr2), InProxy(*projPoints1), InProxy(*projPoints2), OutProxy(*points4D));
    });
}

CVAPI(ExceptionStatus) geometry_triangulatePoints_array(
    double *projMatr1,
    double *projMatr2,
    cv::Point2d *projPoints1,
    int projPoints1Size,
    cv::Point2d *projPoints2,
    int projPoints2Size,
    cv::Vec4d *points4D)
{
    return cvTry([&] {
        const cv::Mat_<double> projMatr1M(3, 4, projMatr1);
        const cv::Mat_<double> projMatr2M(3, 4, projMatr2);
        const cv::Mat_<cv::Point2d> projPoints1M(projPoints1Size, 1, projPoints1);
        const cv::Mat_<cv::Point2d> projPoints2M(projPoints2Size, 1, projPoints2);
        cv::Mat_<cv::Vec4d> points4DM(1, projPoints1Size, points4D);
        cv::triangulatePoints(projMatr1M, projMatr2M,
            projPoints1M, projPoints2M, points4DM);
    });
}


CVAPI(ExceptionStatus) geometry_correctMatches_InputArray(
    const interop::InputArrayProxy* F,
    const interop::InputArrayProxy* points1,
    const interop::InputArrayProxy* points2,
    const interop::OutputArrayProxy* newPoints1,
    const interop::OutputArrayProxy* newPoints2)
{
    return cvTry([&] {
        cv::correctMatches(InProxy(*F), InProxy(*points1), InProxy(*points2), OutProxy(*newPoints1), OutProxy(*newPoints2));
    });
}

CVAPI(ExceptionStatus) geometry_correctMatches_array(
    double *F,
    cv::Point2d *points1,
    int points1Size,
    cv::Point2d *points2,
    int points2Size,
    cv::Point2d *newPoints1,
    cv::Point2d *newPoints2)
{
    return cvTry([&] {
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
    });
}


CVAPI(ExceptionStatus) geometry_estimateAffine3D(
    const interop::InputArrayProxy* src,
    const interop::InputArrayProxy* dst,
    const interop::OutputArrayProxy* out,
    const interop::OutputArrayProxy* inliers,
    double ransacThreshold,
    double confidence,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::estimateAffine3D(InProxy(*src), InProxy(*dst), OutProxy(*out), OutProxy(*inliers), ransacThreshold, confidence);
    });
}



CVAPI(ExceptionStatus) geometry_sampsonDistance_InputArray(
    const interop::InputArrayProxy* pt1,
    const interop::InputArrayProxy* pt2,
    const interop::InputArrayProxy* F,
    double *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::sampsonDistance(InProxy(*pt1), InProxy(*pt2), InProxy(*F));
    });
}

CVAPI(ExceptionStatus) geometry_sampsonDistance_Point3d(
    interop::Point3d pt1,
    interop::Point3d pt2,
    interop::Point3d *F,
    double *returnValue)
{
    return cvTry([&] {
        std::vector<cv::Point3d> f(9);
        for (size_t i = 0; i < 9; i++)
        {
            f[i] = cpp(F[i]);
        }
        *returnValue = cv::sampsonDistance(cv::Mat(cpp(pt1)), cv::Mat(cpp(pt2)), f);
    });
}


CVAPI(ExceptionStatus) geometry_estimateAffine2D(
    const interop::InputArrayProxy* from,
    const interop::InputArrayProxy* to,
    const interop::OutputArrayProxy* inliers,
    int method,
    double ransacReprojThreshold,
    uint64_t maxIters,
    double confidence,
    uint64_t refineIters,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        const auto result = cv::estimateAffine2D(
            InProxy(*from), InProxy(*to), OutProxy(*inliers), method, ransacReprojThreshold, static_cast<size_t>(maxIters), confidence, static_cast<size_t>(refineIters));
        *returnValue = new cv::Mat(result);
    });
}


CVAPI(ExceptionStatus) geometry_estimateAffinePartial2D(
    const interop::InputArrayProxy* from,
    const interop::InputArrayProxy* to,
    const interop::OutputArrayProxy* inliers,
    int method,
    double ransacReprojThreshold,
    uint64_t maxIters,
    double confidence,
    uint64_t refineIters,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        const auto result = cv::estimateAffinePartial2D(
            InProxy(*from), InProxy(*to), OutProxy(*inliers), method, ransacReprojThreshold, static_cast<size_t>(maxIters), confidence, static_cast<size_t>(refineIters));
        *returnValue = new cv::Mat(result);
    });
}


CVAPI(ExceptionStatus) geometry_decomposeHomographyMat(
    const interop::InputArrayProxy* H,
    const interop::InputArrayProxy* K,
    std::vector<cv::Mat> *rotations,
    std::vector<cv::Mat> *translations,
    std::vector<cv::Mat> *normals,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::decomposeHomographyMat(InProxy(*H), InProxy(*K), *rotations, *translations, *normals);
    });
}


CVAPI(ExceptionStatus) geometry_filterHomographyDecompByVisibleRefpoints(
    std::vector<cv::Mat> *rotations,
    std::vector<cv::Mat> *normals,
    const interop::InputArrayProxy* beforePoints,
    const interop::InputArrayProxy* afterPoints,
    const interop::OutputArrayProxy* possibleSolutions,
    const interop::InputArrayProxy* pointsMask)
{
    return cvTry([&] {
        cv::filterHomographyDecompByVisibleRefpoints(*rotations, *normals, InProxy(*beforePoints), InProxy(*afterPoints), OutProxy(*possibleSolutions), InProxy(*pointsMask));
    });
}


CVAPI(ExceptionStatus) geometry_getDefaultNewCameraMatrix(
    const interop::InputArrayProxy* cameraMatrix,
    interop::Size imgsize,
    int centerPrincipalPoint,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        const auto result = cv::getDefaultNewCameraMatrix(InProxy(*cameraMatrix), cpp(imgsize), centerPrincipalPoint != 0);
        *returnValue = new cv::Mat(result);
    });
}


CVAPI(ExceptionStatus) geometry_undistortPoints(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    const interop::InputArrayProxy* cameraMatrix,
    const interop::InputArrayProxy* distCoeffs,
    const interop::InputArrayProxy* R,
    const interop::InputArrayProxy* P)
{
    return cvTry([&] {
        cv::undistortPoints(InProxy(*src), OutProxy(*dst), InProxy(*cameraMatrix), InProxy(*distCoeffs), InProxy(*R), InProxy(*P));
    });
}


CVAPI(ExceptionStatus) geometry_undistortPointsIter(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    const interop::InputArrayProxy* cameraMatrix,
    const interop::InputArrayProxy* distCoeffs,
    const interop::InputArrayProxy* R,
    const interop::InputArrayProxy* P,
    interop::TermCriteria criteria)
{
    return cvTry([&] {
        cv::undistortPoints(InProxy(*src), OutProxy(*dst), InProxy(*cameraMatrix), InProxy(*distCoeffs), InProxy(*R), InProxy(*P), cpp(criteria));
    });
}


CVAPI(ExceptionStatus) geometry_recoverPose_InputArray1(
    const interop::InputArrayProxy* E,
    const interop::InputArrayProxy* points1,
    const interop::InputArrayProxy* points2,
    const interop::InputArrayProxy* cameraMatrix,
    const interop::OutputArrayProxy* R,
    const interop::OutputArrayProxy* t,
    const interop::InputOutputArrayProxy* mask,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::recoverPose(InProxy(*E), InProxy(*points1), InProxy(*points2), InProxy(*cameraMatrix), OutProxy(*R), OutProxy(*t), IoProxy(*mask));
    });
}


CVAPI(ExceptionStatus) geometry_recoverPose_InputArray2(
    const interop::InputArrayProxy* E,
    const interop::InputArrayProxy* points1,
    const interop::InputArrayProxy* points2,
    const interop::OutputArrayProxy* R,
    const interop::OutputArrayProxy* t,
    double focal,
    interop::Point2d pp,
    const interop::InputOutputArrayProxy* mask,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::recoverPose(InProxy(*E), InProxy(*points1), InProxy(*points2), OutProxy(*R), OutProxy(*t), focal, cpp(pp), IoProxy(*mask));
    });
}


CVAPI(ExceptionStatus) geometry_recoverPose_InputArray3(
    const interop::InputArrayProxy* E,
    const interop::InputArrayProxy* points1,
    const interop::InputArrayProxy* points2,
    const interop::InputArrayProxy* cameraMatrix,
    const interop::OutputArrayProxy* R,
    const interop::OutputArrayProxy* t,
    double distanceTresh,
    const interop::InputOutputArrayProxy* mask,
    const interop::OutputArrayProxy* triangulatedPoints,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::recoverPose(InProxy(*E), InProxy(*points1), InProxy(*points2), InProxy(*cameraMatrix), OutProxy(*R), OutProxy(*t), distanceTresh, IoProxy(*mask), OutProxy(*triangulatedPoints));
    });
}


CVAPI(ExceptionStatus) geometry_findEssentialMat_InputArray1(
    const interop::InputArrayProxy* points1,
    const interop::InputArrayProxy* points2,
    const interop::InputArrayProxy* cameraMatrix,
    int method,
    double prob,
    double threshold,
    const interop::OutputArrayProxy* mask,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        const auto mat = cv::findEssentialMat(
            InProxy(*points1), InProxy(*points2), InProxy(*cameraMatrix), method, prob, threshold, 1000, OutProxy(*mask));
        *returnValue = new cv::Mat(mat);
    });
}

CVAPI(ExceptionStatus) geometry_findEssentialMat_InputArray2(
    const interop::InputArrayProxy* points1,
    const interop::InputArrayProxy* points2,
    double focal,
    interop::Point2d pp,
    int method,
    double prob,
    double threshold,
    const interop::OutputArrayProxy* mask,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        const auto mat = cv::findEssentialMat(
            InProxy(*points1), InProxy(*points2), focal, cpp(pp), method, prob, threshold, 1000, OutProxy(*mask));
        *returnValue = new cv::Mat(mat);
    });
}


CVAPI(ExceptionStatus) geometry_solvePnPRefineLM(
    const interop::InputArrayProxy* objectPoints,
    const interop::InputArrayProxy* imagePoints,
    const interop::InputArrayProxy* cameraMatrix,
    const interop::InputArrayProxy* distCoeffs,
    const interop::InputOutputArrayProxy* rvec,
    const interop::InputOutputArrayProxy* tvec,
    interop::TermCriteria criteria)
{
    return cvTry([&] {
        cv::solvePnPRefineLM(InProxy(*objectPoints), InProxy(*imagePoints), InProxy(*cameraMatrix), InProxy(*distCoeffs), IoProxy(*rvec), IoProxy(*tvec), cpp(criteria));
    });
}

CVAPI(ExceptionStatus) geometry_solvePnPRefineVVS(
    const interop::InputArrayProxy* objectPoints,
    const interop::InputArrayProxy* imagePoints,
    const interop::InputArrayProxy* cameraMatrix,
    const interop::InputArrayProxy* distCoeffs,
    const interop::InputOutputArrayProxy* rvec,
    const interop::InputOutputArrayProxy* tvec,
    interop::TermCriteria criteria,
    double vvsLambda)
{
    return cvTry([&] {
        cv::solvePnPRefineVVS(InProxy(*objectPoints), InProxy(*imagePoints), InProxy(*cameraMatrix), InProxy(*distCoeffs), IoProxy(*rvec), IoProxy(*tvec), cpp(criteria), vvsLambda);
    });
}

CVAPI(ExceptionStatus) geometry_decomposeEssentialMat(
    const interop::InputArrayProxy* e,
    const interop::OutputArrayProxy* r1,
    const interop::OutputArrayProxy* r2,
    const interop::OutputArrayProxy* t)
{
    return cvTry([&] {
        cv::decomposeEssentialMat(InProxy(*e), OutProxy(*r1), OutProxy(*r2), OutProxy(*t));
    });
}

CVAPI(ExceptionStatus) geometry_estimateTranslation3D(
    const interop::InputArrayProxy* src,
    const interop::InputArrayProxy* dst,
    const interop::OutputArrayProxy* out,
    const interop::OutputArrayProxy* inliers,
    double ransacThreshold,
    double confidence,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::estimateTranslation3D(InProxy(*src), InProxy(*dst), OutProxy(*out), OutProxy(*inliers), ransacThreshold, confidence) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) geometry_estimateTranslation2D(
    const interop::InputArrayProxy* from,
    const interop::InputArrayProxy* to,
    const interop::OutputArrayProxy* inliers,
    int method,
    double ransacReprojThreshold,
    uint64_t maxIters,
    double confidence,
    uint64_t refineIters,
    cv::Vec2d *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::estimateTranslation2D(
            InProxy(*from), InProxy(*to), OutProxy(*inliers), method, ransacReprojThreshold,
            static_cast<size_t>(maxIters), confidence, static_cast<size_t>(refineIters));
    });
}

CVAPI(ExceptionStatus) geometry_approxPolyN(
    const interop::InputArrayProxy* curve,
    const interop::OutputArrayProxy* approxCurve,
    int nsides,
    float epsilonPercentage,
    int ensureConvex)
{
    return cvTry([&] {
        cv::approxPolyN(InProxy(*curve), OutProxy(*approxCurve), nsides, epsilonPercentage, ensureConvex != 0);
    });
}

CVAPI(ExceptionStatus) geometry_minEnclosingConvexPolygon(
    const interop::InputArrayProxy* points,
    const interop::OutputArrayProxy* polygon,
    int k,
    double *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::minEnclosingConvexPolygon(InProxy(*points), OutProxy(*polygon), k);
    });
}

CVAPI(ExceptionStatus) geometry_getClosestEllipsePoints(
    interop::RotatedRect ellipseParams,
    const interop::InputArrayProxy* points,
    const interop::OutputArrayProxy* closestPts)
{
    return cvTry([&] {
        cv::getClosestEllipsePoints(cpp(ellipseParams), InProxy(*points), OutProxy(*closestPts));
    });
}

CVAPI(ExceptionStatus) geometry_buildMST(
    int numNodes,
    const interop::MSTEdge* inputEdges,
    int inputEdgesLength,
    int algorithm,
    int root,
    interop::MSTEdge* resultingEdges,
    int* resultingEdgesCount,
    int* returnValue)
{
    return cvTry([&] {
        std::vector<cv::MSTEdge> inVec(inputEdgesLength);
        for (int i = 0; i < inputEdgesLength; i++)
            inVec[i] = cpp(inputEdges[i]);

        std::vector<cv::MSTEdge> outVec;
        const bool ok = cv::buildMST(numNodes, inVec, outVec, static_cast<cv::MSTAlgorithm>(algorithm), root);
        *returnValue = ok ? 1 : 0;
        *resultingEdgesCount = static_cast<int>(outVec.size());
        for (size_t i = 0; i < outVec.size(); i++)
            resultingEdges[i] = c(outVec[i]);
    });
}

CVAPI(ExceptionStatus) geometry_voxelGridSampling(
    const interop::OutputArrayProxy* sampledPointFlags,
    const interop::InputArrayProxy* inputPts,
    float length,
    float width,
    float height,
    int* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::voxelGridSampling(OutProxy(*sampledPointFlags), InProxy(*inputPts), length, width, height);
    });
}

CVAPI(ExceptionStatus) geometry_randomSampling_Size(
    const interop::OutputArrayProxy* sampledPts,
    const interop::InputArrayProxy* inputPts,
    int sampledPtsSize)
{
    return cvTry([&] {
        cv::randomSampling(OutProxy(*sampledPts), InProxy(*inputPts), sampledPtsSize, nullptr);
    });
}

CVAPI(ExceptionStatus) geometry_randomSampling_Scale(
    const interop::OutputArrayProxy* sampledPts,
    const interop::InputArrayProxy* inputPts,
    float sampledScale)
{
    return cvTry([&] {
        cv::randomSampling(OutProxy(*sampledPts), InProxy(*inputPts), sampledScale, nullptr);
    });
}

CVAPI(ExceptionStatus) geometry_farthestPointSampling_Size(
    const interop::OutputArrayProxy* sampledPointFlags,
    const interop::InputArrayProxy* inputPts,
    int sampledPtsSize,
    float distLowerLimit,
    int* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::farthestPointSampling(OutProxy(*sampledPointFlags), InProxy(*inputPts), sampledPtsSize, distLowerLimit, nullptr);
    });
}

CVAPI(ExceptionStatus) geometry_farthestPointSampling_Scale(
    const interop::OutputArrayProxy* sampledPointFlags,
    const interop::InputArrayProxy* inputPts,
    float sampledScale,
    float distLowerLimit,
    int* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::farthestPointSampling(OutProxy(*sampledPointFlags), InProxy(*inputPts), sampledScale, distLowerLimit, nullptr);
    });
}

CVAPI(ExceptionStatus) geometry_normalEstimate(
    const interop::OutputArrayProxy* normals,
    const interop::OutputArrayProxy* curvatures,
    const interop::InputArrayProxy* inputPts,
    const interop::InputArrayProxy* nnIdx,
    int maxNeighborNum)
{
    return cvTry([&] {
        cv::normalEstimate(OutProxy(*normals), OutProxy(*curvatures), InProxy(*inputPts), InProxy(*nnIdx), maxNeighborNum);
    });
}

CVAPI(ExceptionStatus) geometry_getRotationMatrix2D(
    interop::Point2f center,
    double angle,
    double scale,
    cv::Mat** returnValue)
{
    return cvTry([&] {
        const auto ret = cv::getRotationMatrix2D(cpp(center), angle, scale);
        *returnValue = new cv::Mat(ret);
    });

}

CVAPI(ExceptionStatus) geometry_invertAffineTransform(const interop::InputArrayProxy* M, const interop::OutputArrayProxy* iM)
{
    return cvTry([&] {
        cv::invertAffineTransform(InProxy(*M), OutProxy(*iM));
    });
}

CVAPI(ExceptionStatus) geometry_getPerspectiveTransform1(
    cv::Point2f *src,
    cv::Point2f *dst,
    cv::Mat** returnValue)
{
    return cvTry([&] {
        const auto ret = cv::getPerspectiveTransform(src, dst);
        *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) geometry_getPerspectiveTransform2(
    const interop::InputArrayProxy* src,
    const interop::InputArrayProxy* dst,
    cv::Mat** returnValue)
{
    return cvTry([&] {
        const auto ret = cv::getPerspectiveTransform(InProxy(*src), InProxy(*dst));
        *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) geometry_getAffineTransform1(
    cv::Point2f *src,
    cv::Point2f *dst,
    cv::Mat** returnValue)
{
    return cvTry([&] {
        const auto ret = cv::getAffineTransform(src, dst);
        *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) geometry_getAffineTransform2(
    const interop::InputArrayProxy* src,
    const interop::InputArrayProxy* dst,
    cv::Mat** returnValue)
{
    return cvTry([&] {
        const auto ret = cv::getAffineTransform(InProxy(*src), InProxy(*dst));
        *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) geometry_moments(
    const interop::InputArrayProxy* arr,
    int binaryImage,
    interop::Moments *returnValue)
{
    return cvTry([&] {
        const auto m = cv::moments(InProxy(*arr), binaryImage != 0);
        *returnValue = c(m);
    });
}
/*

CVAPI(ExceptionStatus) geometry_HuMoments(interop::Moments *moments, double hu[7])
{
    return cvTry([&] {
        cv::HuMoments(cpp(*moments), hu);
    });
}
*/

CVAPI(ExceptionStatus) geometry_approxPolyDP_InputArray(
    const interop::InputArrayProxy* curve,
    const interop::OutputArrayProxy* approxCurve,
    double epsilon,
    int closed)
{
    return cvTry([&] {
        cv::approxPolyDP(InProxy(*curve), OutProxy(*approxCurve), epsilon, closed != 0);
    });
}

CVAPI(ExceptionStatus) geometry_approxPolyDP_Point(
    cv::Point *curve,
    int curveLength,
    std::vector<cv::Point> *approxCurve,
    double epsilon,
    int closed)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point> curveMat(curveLength, 1, curve);
        cv::approxPolyDP(curveMat, *approxCurve, epsilon, closed != 0);
    });
}

CVAPI(ExceptionStatus) geometry_approxPolyDP_Point2f(
    cv::Point2f *curve,
    int curveLength,
    std::vector<cv::Point2f> *approxCurve,
    double epsilon,
    int closed)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point2f> curveMat(curveLength, 1, curve);
        cv::approxPolyDP(curveMat, *approxCurve, epsilon, closed != 0);
    });
}

CVAPI(ExceptionStatus) geometry_arcLength_InputArray(
    const interop::InputArrayProxy* curve,
    int closed,
    double *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::arcLength(InProxy(*curve), closed != 0);
    });
}

CVAPI(ExceptionStatus) geometry_arcLength_Point(
    cv::Point *curve,
    int curveLength,
    int closed,
    double* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point> curveMat(curveLength, 1, curve);
        *returnValue = cv::arcLength(curveMat, closed != 0);
    });
}

CVAPI(ExceptionStatus) geometry_arcLength_Point2f(
    cv::Point2f *curve,
    int curveLength,
    int closed,
    double* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point2f> curveMat(curveLength, 1, curve);
        *returnValue = cv::arcLength(curveMat, closed != 0);
    });
}

CVAPI(ExceptionStatus) geometry_boundingRect_InputArray(const interop::InputArrayProxy* curve, interop::Rect* returnValue)
{
    return cvTry([&] {
        *returnValue = c(cv::boundingRect(InProxy(*curve)));
    });
}

CVAPI(ExceptionStatus) geometry_boundingRect_Point(
    cv::Point *curve,
    int curveLength,
    interop::Rect* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point> curveMat(curveLength, 1, curve);
        *returnValue = c(cv::boundingRect(curveMat));
    });
}

CVAPI(ExceptionStatus) geometry_boundingRect_Point2f(
    cv::Point2f *curve,
    int curveLength,
    interop::Rect* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point2f> curveMat(curveLength, 1, curve);
        *returnValue = c(cv::boundingRect(curveMat));
    });
}

CVAPI(ExceptionStatus) geometry_contourArea_InputArray(
    const interop::InputArrayProxy* contour,
    int oriented,
    double* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::contourArea(InProxy(*contour), oriented != 0);
    });
}

CVAPI(ExceptionStatus) geometry_contourArea_Point(
    cv::Point *contour,
    int contourLength,
    int oriented,
    double* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point> contourMat(contourLength, 1, contour);
        *returnValue = cv::contourArea(contourMat, oriented != 0);
    });
}

CVAPI(ExceptionStatus) geometry_contourArea_Point2f(
    cv::Point2f *contour,
    int contourLength,
    int oriented,
    double* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point2f> contourMat(contourLength, 1, contour);
        *returnValue = cv::contourArea(contourMat, oriented != 0);
    });
}

CVAPI(ExceptionStatus) geometry_minAreaRect_InputArray(const interop::InputArrayProxy* points, interop::RotatedRect* returnValue)
{
    return cvTry([&] {
        *returnValue = c(cv::minAreaRect(InProxy(*points)));
    });
}

CVAPI(ExceptionStatus) geometry_minAreaRect_Point(
    cv::Point *points,
    int pointsLength,
    interop::RotatedRect* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point> pointsMat(pointsLength, 1, points);
        *returnValue = c(cv::minAreaRect(pointsMat));
    });
}

CVAPI(ExceptionStatus) geometry_minAreaRect_Point2f(
    cv::Point2f *points,
    int pointsLength,
    interop::RotatedRect* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point2f> pointsMat(pointsLength, 1, points);
        *returnValue = c(cv::minAreaRect(pointsMat));
    });
}

CVAPI(ExceptionStatus) geometry_boxPoints_OutputArray(interop::RotatedRect box, const interop::OutputArrayProxy* points)
{
    return cvTry([&] {
        cv::boxPoints(cpp(box), OutProxy(*points));
    });
}

CVAPI(ExceptionStatus) geometry_boxPoints_Point2f(interop::RotatedRect box, cv::Point2f points[4])
{
    return cvTry([&] {
        cpp(box).points(points);
    });
}

CVAPI(ExceptionStatus) geometry_minEnclosingCircle_InputArray(
    const interop::InputArrayProxy* points,
    interop::Point2f *center,
    float *radius)
{
    return cvTry([&] {
        cv::Point2f center0;
        float radius0;
        cv::minEnclosingCircle(InProxy(*points), center0, radius0);
        *center = c(center0);
        *radius = radius0;
    });
}

CVAPI(ExceptionStatus) geometry_minEnclosingCircle_Point(
    cv::Point *points,
    int pointsLength,
    interop::Point2f*center,
    float *radius)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point> pointsMat(pointsLength, 1, points);
        cv::Point2f center0;
        float radius0;
        cv::minEnclosingCircle(pointsMat, center0, radius0);
        *center = c(center0);
        *radius = radius0;
    });
}

CVAPI(ExceptionStatus) geometry_minEnclosingCircle_Point2f(
    cv::Point2f *points,
    int pointsLength,
    interop::Point2f*center,
    float *radius)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point2f> pointsMat(pointsLength, 1, points);
        cv::Point2f center0;
        float radius0;
        cv::minEnclosingCircle(pointsMat, center0, radius0);
        *center = c(center0);
        *radius = radius0;
    });
}

CVAPI(ExceptionStatus) geometry_minEnclosingTriangle_InputOutputArray(
    const interop::InputArrayProxy* points,
    const interop::OutputArrayProxy* triangle,
    double *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::minEnclosingTriangle(InProxy(*points), OutProxy(*triangle));
    });
}

CVAPI(ExceptionStatus) geometry_minEnclosingTriangle_Point(
    cv::Point* points,
    int pointsLength,
    std::vector<cv::Point2f>* triangle,
    double* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point> pointsMat(pointsLength, 1, points);
        *returnValue = cv::minEnclosingTriangle(pointsMat, *triangle);
    });
}

CVAPI(ExceptionStatus) geometry_minEnclosingTriangle_Point2f(
    cv::Point2f* points,
    int pointsLength,
    std::vector<cv::Point2f>* triangle,
    double* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point2f> pointsMat(pointsLength, 1, points);
        *returnValue = cv::minEnclosingTriangle(pointsMat, *triangle);
    });
}

CVAPI(ExceptionStatus) geometry_matchShapes_InputArray(
    const interop::InputArrayProxy* contour1,
    const interop::InputArrayProxy* contour2,
    int method,
    double parameter,
    double* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::matchShapes(InProxy(*contour1), InProxy(*contour2), method, parameter);
    });
}

CVAPI(ExceptionStatus) geometry_matchShapes_Point(
    cv::Point *contour1,
    int contour1Length,
    cv::Point *contour2,
    int contour2Length,
    int method,
    double parameter,
    double* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point> contour1Mat(contour1Length, 1, contour1);
        const cv::Mat_<cv::Point> contour2Mat(contour2Length, 1, contour2);
        *returnValue = cv::matchShapes(contour1Mat, contour2Mat, method, parameter);
    });
}

CVAPI(ExceptionStatus) geometry_convexHull_InputArray(
    const interop::InputArrayProxy* points,
    const interop::OutputArrayProxy* hull,
    int clockwise,
    int returnPoints)
{
    return cvTry([&] {
        cv::convexHull(InProxy(*points), OutProxy(*hull), clockwise != 0, returnPoints != 0);
    });
}

CVAPI(ExceptionStatus) geometry_convexHull_Point_ReturnsPoints(
    cv::Point *points,
    int pointsLength,
    std::vector<cv::Point> *hull,
    int clockwise)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point> pointsMat(pointsLength, 1, points);
        cv::convexHull(pointsMat, *hull, clockwise != 0, true);
    });
}

CVAPI(ExceptionStatus) geometry_convexHull_Point2f_ReturnsPoints(
    cv::Point2f *points,
    int pointsLength,
    std::vector<cv::Point2f> *hull,
    int clockwise)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point2f> pointsMat(pointsLength, 1, points);
        cv::convexHull(pointsMat, *hull, clockwise != 0, true);
    });
}

CVAPI(ExceptionStatus) geometry_convexHull_Point_ReturnsIndices(
    cv::Point *points,
    int pointsLength,
    std::vector<int> *hull,
    int clockwise)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point> pointsMat(pointsLength, 1, points);
        cv::convexHull(pointsMat, *hull, clockwise != 0, false);
    });
}

CVAPI(ExceptionStatus) geometry_convexHull_Point2f_ReturnsIndices(
    cv::Point2f *points,
    int pointsLength,
    std::vector<int> *hull,
    int clockwise)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point2f> pointsMat(pointsLength, 1, points);
        cv::convexHull(pointsMat, *hull, clockwise != 0, false);
    });
}

CVAPI(ExceptionStatus) geometry_convexityDefects_InputArray(
    const interop::InputArrayProxy* contour,
    const interop::InputArrayProxy* convexHull,
    const interop::OutputArrayProxy* convexityDefects)
{
    return cvTry([&] {
        cv::convexityDefects(InProxy(*contour), InProxy(*convexHull), OutProxy(*convexityDefects));
    });
}

CVAPI(ExceptionStatus) geometry_convexityDefects_Point(
    cv::Point *contour,
    int contourLength,
    int *convexHull,
    int convexHullLength,
    std::vector<cv::Vec4i> *convexityDefects)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point> contourMat(contourLength, 1, contour);
        const cv::Mat_<int> convexHullMat(convexHullLength, 1,  convexHull);
        cv::convexityDefects(contourMat, convexHullMat, *convexityDefects);
    });
}

CVAPI(ExceptionStatus) geometry_convexityDefects_Point2f(
    cv::Point2f *contour,
    int contourLength,
    int *convexHull,
    int convexHullLength,
    std::vector<cv::Vec4i> *convexityDefects)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point2f> contourMat(contourLength, 1, contour);
        const cv::Mat_<int> convexHullMat(convexHullLength, 1, convexHull);
        cv::convexityDefects(contourMat, convexHullMat, *convexityDefects);
    });
}

CVAPI(ExceptionStatus) geometry_isContourConvex_InputArray(const interop::InputArrayProxy* contour, int* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::isContourConvex(InProxy(*contour)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) geometry_isContourConvex_Point(
    cv::Point *contour,
    int contourLength,
    int* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point> contourMat(contourLength, 1, contour);
        *returnValue = cv::isContourConvex(contourMat) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) geometry_isContourConvex_Point2f(
    cv::Point2f *contour,
    int contourLength,
    int* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point2f> contourMat(contourLength, 1, contour);
        *returnValue = cv::isContourConvex(contourMat) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) geometry_intersectConvexConvex_InputArray(
    const interop::InputArrayProxy* p1,
    const interop::InputArrayProxy* p2,
    const interop::OutputArrayProxy* p12,
    int handleNested,
    float* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::intersectConvexConvex(InProxy(*p1), InProxy(*p2), OutProxy(*p12), handleNested != 0);
    });
}

CVAPI(ExceptionStatus) geometry_intersectConvexConvex_Point(
    cv::Point *p1,
    int p1Length,
    cv::Point *p2,
    int p2Length,
    std::vector<cv::Point> *p12,
    int handleNested,
    float* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point> p1Vec(p1Length, 1, p1);
        const cv::Mat_<cv::Point> p2Vec(p2Length, 1, p2);
        *returnValue = cv::intersectConvexConvex(p1Vec, p2Vec, *p12, handleNested != 0);
    });
}

CVAPI(ExceptionStatus) geometry_intersectConvexConvex_Point2f(
    cv::Point2f *p1,
    int p1Length,
    cv::Point2f *p2,
    int p2Length,
    std::vector<cv::Point2f> *p12,
    int handleNested,
    float *returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point2f> p1Vec(p1Length, 1, p1);
        const cv::Mat_<cv::Point2f> p2Vec(p2Length, 1, p2);
        *returnValue = cv::intersectConvexConvex(p1Vec, p2Vec, *p12, handleNested != 0);
    });
}

CVAPI(ExceptionStatus) geometry_fitEllipse_InputArray(const interop::InputArrayProxy* points, interop::RotatedRect* returnValue)
{
    return cvTry([&] {
        *returnValue = c(cv::fitEllipse(InProxy(*points)));
    });
}

CVAPI(ExceptionStatus) geometry_fitEllipse_Point(
    cv::Point *points,
    int pointsLength,
    interop::RotatedRect* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point> pointsVec(pointsLength, 1, points);
        *returnValue = c(cv::fitEllipse(pointsVec));
    });
}

CVAPI(ExceptionStatus) geometry_fitEllipse_Point2f(
    cv::Point2f *points,
    int pointsLength,
    interop::RotatedRect* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point2f> pointsVec(pointsLength, 1, points);
        *returnValue = c(cv::fitEllipse(pointsVec));
    });
}

CVAPI(ExceptionStatus) geometry_fitEllipseAMS_InputArray(const interop::InputArrayProxy* points, interop::RotatedRect* returnValue)
{
    return cvTry([&] {
        *returnValue = c(cv::fitEllipseAMS(InProxy(*points)));
    });
}

CVAPI(ExceptionStatus) geometry_fitEllipseAMS_Point(
    cv::Point* points,
    int pointsLength,
    interop::RotatedRect* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point> pointsVec(pointsLength, 1, points);
        *returnValue = c(cv::fitEllipseAMS(pointsVec));
    });
}

CVAPI(ExceptionStatus) geometry_fitEllipseAMS_Point2f(
    cv::Point2f* points,
    int pointsLength,
    interop::RotatedRect* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point2f> pointsVec(pointsLength, 1, points);
        *returnValue = c(cv::fitEllipseAMS(pointsVec));
    });
}

CVAPI(ExceptionStatus) geometry_fitEllipseDirect_InputArray(const interop::InputArrayProxy* points, interop::RotatedRect* returnValue)
{
    return cvTry([&] {
        *returnValue = c(cv::fitEllipseDirect(InProxy(*points)));
    });
}

CVAPI(ExceptionStatus) geometry_fitEllipseDirect_Point(
    cv::Point* points,
    int pointsLength,
    interop::RotatedRect* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point> pointsVec(pointsLength, 1, points);
        *returnValue = c(cv::fitEllipseDirect(pointsVec));
    });
}

CVAPI(ExceptionStatus) geometry_fitEllipseDirect_Point2f(
    cv::Point2f* points,
    int pointsLength,
    interop::RotatedRect* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point2f> pointsVec(pointsLength, 1, points);
        *returnValue = c(cv::fitEllipseDirect(pointsVec));
    });
}

CVAPI(ExceptionStatus) geometry_fitLine_InputArray(
    const interop::InputArrayProxy* points,
    const interop::OutputArrayProxy* line,
    int distType,
    double param,
    double reps,
    double aeps)
{
    return cvTry([&] {
        cv::fitLine(InProxy(*points), OutProxy(*line), distType, param, reps, aeps);
    });
}

CVAPI(ExceptionStatus) geometry_fitLine_Point(
    cv::Point *points,
    int pointsLength,
    float *line,
    int distType,
    double param,
    double reps,
    double aeps)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point> pointsVec(pointsLength, 1, points);
        cv::Mat_<float> lineVec(4, 1, line);
        cv::fitLine(pointsVec, lineVec, distType, param, reps, aeps);
    });
}

CVAPI(ExceptionStatus) geometry_fitLine_Point2f(
    cv::Point2f *points,
    int pointsLength,
    float *line,
    int distType,
    double param,
    double reps,
    double aeps)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point2f> pointsVec(pointsLength, 1, points);
        cv::Mat_<float> lineVec(4, 1, line);
        cv::fitLine(pointsVec, lineVec, distType, param, reps, aeps);
    });
}

CVAPI(ExceptionStatus) geometry_fitLine_Point3i(
    cv::Point3i *points,
    int pointsLength,
    float *line,
    int distType,
    double param,
    double reps,
    double aeps)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point3i> pointsVec(pointsLength, 1, points);
        cv::Mat_<float> lineVec(6, 1, line);
        cv::fitLine(pointsVec, lineVec, distType, param, reps, aeps);
    });
}

CVAPI(ExceptionStatus) geometry_fitLine_Point3f(
    cv::Point3f *points,
    int pointsLength,
    float *line,
    int distType,
    double param,
    double reps,
    double aeps)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point3f> pointsVec(pointsLength, 1, points);
        cv::Mat_<float> lineVec(6, 1, line);
        cv::fitLine(pointsVec, lineVec, distType, param, reps, aeps);
    });
}

CVAPI(ExceptionStatus) geometry_pointPolygonTest_InputArray(
    const interop::InputArrayProxy* contour,
    interop::Point2f pt,
    int measureDist,
    double *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::pointPolygonTest(InProxy(*contour), cpp(pt), measureDist != 0);
    });
}

CVAPI(ExceptionStatus) geometry_pointPolygonTest_Point(
    cv::Point *contour,
    int contourLength,
    interop::Point2f pt,
    int measureDist,
    double* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point> contourVec(contourLength, 1, contour);
        *returnValue = cv::pointPolygonTest(contourVec, cpp(pt), measureDist != 0);
    });
}

CVAPI(ExceptionStatus) geometry_pointPolygonTest_Point2f(
    cv::Point2f *contour,
    int contourLength,
    interop::Point2f pt,
    int measureDist,
    double* returnValue)
{
    return cvTry([&] {
        const cv::Mat_<cv::Point2f> contourVec(contourLength, 1, contour);
        *returnValue = cv::pointPolygonTest(contourVec, cpp(pt), measureDist != 0);
    });
}

CVAPI(ExceptionStatus) geometry_rotatedRectangleIntersection_OutputArray(
    interop::RotatedRect rect1,
    interop::RotatedRect rect2,
    const interop::OutputArrayProxy* intersectingRegion,
    int* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::rotatedRectangleIntersection(cpp(rect1), cpp(rect2), OutProxy(*intersectingRegion));
    });
}

CVAPI(ExceptionStatus) geometry_rotatedRectangleIntersection_vector(
    interop::RotatedRect rect1,
    interop::RotatedRect rect2,
    std::vector<cv::Point2f> *intersectingRegion,
    int* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::rotatedRectangleIntersection(cpp(rect1), cpp(rect2), *intersectingRegion);
    });
}


// SACSegmentation

typedef int (*SacModelConstraintNativeCallback)(const double *coefficients, int length);

CVAPI(ExceptionStatus) geometry_createSACSegmentation(
    int sacModelType,
    int sacMethod,
    double threshold,
    int maxIterations,
    cv::Ptr<cv::SACSegmentation> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::SACSegmentation::create(
            static_cast<cv::SacModelType>(sacModelType), static_cast<cv::SacMethod>(sacMethod), threshold, maxIterations));
    });
}

CVAPI(ExceptionStatus) geometry_Ptr_SACSegmentation_delete(cv::Ptr<cv::SACSegmentation> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) geometry_Ptr_SACSegmentation_get(cv::Ptr<cv::SACSegmentation> *ptr, cv::SACSegmentation **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) geometry_SACSegmentation_segment(
    cv::SACSegmentation *obj,
    const interop::InputArrayProxy* inputPts,
    const interop::OutputArrayProxy* labels,
    const interop::OutputArrayProxy* modelsCoefficients,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->segment(InProxy(*inputPts), OutProxy(*labels), OutProxy(*modelsCoefficients));
    });
}

CVAPI(ExceptionStatus) geometry_SACSegmentation_setSacModelType(cv::SACSegmentation *obj, int value)
{
    return cvTry([&] {
        obj->setSacModelType(static_cast<cv::SacModelType>(value));
    });
}

CVAPI(ExceptionStatus) geometry_SACSegmentation_getSacModelType(cv::SACSegmentation *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = static_cast<int>(obj->getSacModelType());
    });
}

CVAPI(ExceptionStatus) geometry_SACSegmentation_setSacMethodType(cv::SACSegmentation *obj, int value)
{
    return cvTry([&] {
        obj->setSacMethodType(static_cast<cv::SacMethod>(value));
    });
}

CVAPI(ExceptionStatus) geometry_SACSegmentation_getSacMethodType(cv::SACSegmentation *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = static_cast<int>(obj->getSacMethodType());
    });
}

CVAPI(ExceptionStatus) geometry_SACSegmentation_setDistanceThreshold(cv::SACSegmentation *obj, double value)
{
    return cvTry([&] {
        obj->setDistanceThreshold(value);
    });
}

CVAPI(ExceptionStatus) geometry_SACSegmentation_getDistanceThreshold(cv::SACSegmentation *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getDistanceThreshold();
    });
}

CVAPI(ExceptionStatus) geometry_SACSegmentation_setRadiusLimits(cv::SACSegmentation *obj, double radiusMin, double radiusMax)
{
    return cvTry([&] {
        obj->setRadiusLimits(radiusMin, radiusMax);
    });
}

CVAPI(ExceptionStatus) geometry_SACSegmentation_getRadiusLimits(cv::SACSegmentation *obj, double *radiusMin, double *radiusMax)
{
    return cvTry([&] {
        obj->getRadiusLimits(*radiusMin, *radiusMax);
    });
}

CVAPI(ExceptionStatus) geometry_SACSegmentation_setMaxIterations(cv::SACSegmentation *obj, int value)
{
    return cvTry([&] {
        obj->setMaxIterations(value);
    });
}

CVAPI(ExceptionStatus) geometry_SACSegmentation_getMaxIterations(cv::SACSegmentation *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getMaxIterations();
    });
}

CVAPI(ExceptionStatus) geometry_SACSegmentation_setConfidence(cv::SACSegmentation *obj, double value)
{
    return cvTry([&] {
        obj->setConfidence(value);
    });
}

CVAPI(ExceptionStatus) geometry_SACSegmentation_getConfidence(cv::SACSegmentation *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getConfidence();
    });
}

CVAPI(ExceptionStatus) geometry_SACSegmentation_setNumberOfModelsExpected(cv::SACSegmentation *obj, int value)
{
    return cvTry([&] {
        obj->setNumberOfModelsExpected(value);
    });
}

CVAPI(ExceptionStatus) geometry_SACSegmentation_getNumberOfModelsExpected(cv::SACSegmentation *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNumberOfModelsExpected();
    });
}

CVAPI(ExceptionStatus) geometry_SACSegmentation_setParallel(cv::SACSegmentation *obj, int value)
{
    return cvTry([&] {
        obj->setParallel(value != 0);
    });
}

CVAPI(ExceptionStatus) geometry_SACSegmentation_isParallel(cv::SACSegmentation *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->isParallel() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) geometry_SACSegmentation_setRandomGeneratorState(cv::SACSegmentation *obj, uint64_t value)
{
    return cvTry([&] {
        obj->setRandomGeneratorState(value);
    });
}

CVAPI(ExceptionStatus) geometry_SACSegmentation_getRandomGeneratorState(cv::SACSegmentation *obj, uint64_t *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getRandomGeneratorState();
    });
}

CVAPI(ExceptionStatus) geometry_SACSegmentation_setCustomModelConstraints(
    cv::SACSegmentation *obj,
    SacModelConstraintNativeCallback callback)
{
    return cvTry([&] {
        if (callback == nullptr)
        {
            obj->setCustomModelConstraints(cv::SACSegmentation::ModelConstraintFunction());
        }
        else
        {
            obj->setCustomModelConstraints([callback](const std::vector<double> &coefficients) -> bool {
                return callback(coefficients.data(), static_cast<int>(coefficients.size())) != 0;
            });
        }
    });
}


// RegionGrowing3D

CVAPI(ExceptionStatus) geometry_createRegionGrowing3D(cv::Ptr<cv::RegionGrowing3D> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::RegionGrowing3D::create());
    });
}

CVAPI(ExceptionStatus) geometry_Ptr_RegionGrowing3D_delete(cv::Ptr<cv::RegionGrowing3D> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) geometry_Ptr_RegionGrowing3D_get(cv::Ptr<cv::RegionGrowing3D> *ptr, cv::RegionGrowing3D **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_segment(
    cv::RegionGrowing3D *obj,
    std::vector<std::vector<int>> *regionsIdx,
    const interop::OutputArrayProxy* labels,
    const interop::InputArrayProxy* inputPts,
    const interop::InputArrayProxy* normals,
    const interop::InputArrayProxy* nnIdx,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->segment(*regionsIdx, OutProxy(*labels), InProxy(*inputPts), InProxy(*normals), InProxy(*nnIdx));
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_setMinSize(cv::RegionGrowing3D *obj, int value)
{
    return cvTry([&] {
        obj->setMinSize(value);
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_getMinSize(cv::RegionGrowing3D *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getMinSize();
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_setMaxSize(cv::RegionGrowing3D *obj, int value)
{
    return cvTry([&] {
        obj->setMaxSize(value);
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_getMaxSize(cv::RegionGrowing3D *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getMaxSize();
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_setSmoothModeFlag(cv::RegionGrowing3D *obj, int value)
{
    return cvTry([&] {
        obj->setSmoothModeFlag(value != 0);
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_getSmoothModeFlag(cv::RegionGrowing3D *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getSmoothModeFlag() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_setSmoothnessThreshold(cv::RegionGrowing3D *obj, double value)
{
    return cvTry([&] {
        obj->setSmoothnessThreshold(value);
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_getSmoothnessThreshold(cv::RegionGrowing3D *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getSmoothnessThreshold();
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_setCurvatureThreshold(cv::RegionGrowing3D *obj, double value)
{
    return cvTry([&] {
        obj->setCurvatureThreshold(value);
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_getCurvatureThreshold(cv::RegionGrowing3D *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getCurvatureThreshold();
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_setMaxNumberOfNeighbors(cv::RegionGrowing3D *obj, int value)
{
    return cvTry([&] {
        obj->setMaxNumberOfNeighbors(value);
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_getMaxNumberOfNeighbors(cv::RegionGrowing3D *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getMaxNumberOfNeighbors();
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_setNumberOfRegions(cv::RegionGrowing3D *obj, int value)
{
    return cvTry([&] {
        obj->setNumberOfRegions(value);
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_getNumberOfRegions(cv::RegionGrowing3D *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNumberOfRegions();
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_setNeedSort(cv::RegionGrowing3D *obj, int value)
{
    return cvTry([&] {
        obj->setNeedSort(value != 0);
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_getNeedSort(cv::RegionGrowing3D *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNeedSort() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_setSeeds(cv::RegionGrowing3D *obj, const interop::InputArrayProxy* seeds)
{
    return cvTry([&] {
        obj->setSeeds(InProxy(*seeds));
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_getSeeds(cv::RegionGrowing3D *obj, const interop::OutputArrayProxy* seeds)
{
    return cvTry([&] {
        obj->getSeeds(OutProxy(*seeds));
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_setCurvatures(cv::RegionGrowing3D *obj, const interop::InputArrayProxy* curvatures)
{
    return cvTry([&] {
        obj->setCurvatures(InProxy(*curvatures));
    });
}

CVAPI(ExceptionStatus) geometry_RegionGrowing3D_getCurvatures(cv::RegionGrowing3D *obj, const interop::OutputArrayProxy* curvatures)
{
    return cvTry([&] {
        obj->getCurvatures(OutProxy(*curvatures));
    });
}

#endif // NO_GEOMETRY
