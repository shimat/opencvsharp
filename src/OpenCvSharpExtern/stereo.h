#pragma once

#ifndef NO_STEREO

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) stereo_stereoRectify_InputArray(
    cv::_InputArray *cameraMatrix1, cv::_InputArray *distCoeffs1,
    cv::_InputArray *cameraMatrix2, cv::_InputArray *distCoeffs2,
    MyCvSize imageSize, cv::_InputArray *R, cv::_InputArray *T,
    cv::_OutputArray *R1, cv::_OutputArray *R2,
    cv::_OutputArray *P1, cv::_OutputArray *P2,
    cv::_OutputArray *Q, int flags,
    double alpha, MyCvSize newImageSize,
    MyCvRect *validPixROI1, MyCvRect *validPixROI2)
{
    BEGIN_WRAP
    cv::Rect _validPixROI1, _validPixROI2;
    cv::stereoRectify(*cameraMatrix1, *distCoeffs1, *cameraMatrix2, *distCoeffs2,
        cpp(imageSize), *R, *T, *R1, *R2, *P1, *P2, *Q, flags, alpha, cpp(newImageSize),
        &_validPixROI1, &_validPixROI2);
    *validPixROI1 = c(_validPixROI1);
    *validPixROI2 = c(_validPixROI2);
    END_WRAP
}

CVAPI(ExceptionStatus) stereo_stereoRectify_array(double *cameraMatrix1,
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


CVAPI(ExceptionStatus) stereo_stereoRectifyUncalibrated_InputArray(cv::_InputArray *points1, cv::_InputArray *points2,
    cv::_InputArray *F, MyCvSize imgSize,
    cv::_OutputArray *H1, cv::_OutputArray *H2,
    double threshold,
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::stereoRectifyUncalibrated(*points1, *points2, *F, cpp(imgSize), *H1, *H2, threshold) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) stereo_stereoRectifyUncalibrated_array(cv::Point2d *points1, int points1Size,
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


CVAPI(ExceptionStatus) stereo_rectify3Collinear_InputArray(
    cv::_InputArray *cameraMatrix1, cv::_InputArray *distCoeffs1,
    cv::_InputArray *cameraMatrix2, cv::_InputArray *distCoeffs2,
    cv::_InputArray *cameraMatrix3, cv::_InputArray *distCoeffs3,
    cv::_InputArray **imgpt1, int imgpt1Size,
    cv::_InputArray **imgpt3, int imgpt3Size,
    MyCvSize imageSize, cv::_InputArray *R12, cv::_InputArray *T12,
    cv::_InputArray *R13, cv::_InputArray *T13,
    cv::_OutputArray *R1, cv::_OutputArray *R2, cv::_OutputArray *R3,
    cv::_OutputArray *P1, cv::_OutputArray *P2, cv::_OutputArray *P3,
    cv::_OutputArray *Q, double alpha, MyCvSize newImgSize,
    MyCvRect *roi1, MyCvRect *roi2, int flags,
    float *returnValue)
{
    BEGIN_WRAP
    std::vector<cv::Mat> imgpt1Vec(imgpt1Size);
    std::vector<cv::Mat> imgpt3Vec(imgpt3Size);
    for (auto i = 0; i < imgpt1Size; i++)
        imgpt1Vec[i] = imgpt1[i]->getMat();
    for (auto i = 0; i < imgpt3Size; i++)
        imgpt3Vec[i] = imgpt3[i]->getMat();
    cv::Rect _roi1, _roi2;

    const auto ret = cv::rectify3Collinear(*cameraMatrix1, *distCoeffs1,
        *cameraMatrix2, *distCoeffs2, *cameraMatrix3, *distCoeffs3,
        imgpt1Vec, imgpt3Vec, cpp(imageSize), *R12, *T12, *R13, *T13,
        *R1, *R2, *R3, *P1, *P2, *P3, *Q, alpha, cpp(newImgSize),
        &_roi1, &_roi2, flags);
    *roi1 = c(_roi1);
    *roi2 = c(_roi2);
    *returnValue = ret;
    END_WRAP
}



CVAPI(ExceptionStatus) stereo_filterSpeckles(
    cv::_InputOutputArray *img, double newVal, int maxSpeckleSize, double maxDiff, cv::_InputOutputArray *buf)
{
    BEGIN_WRAP
    cv::filterSpeckles(*img, newVal, maxSpeckleSize, maxDiff, entity(buf));
    END_WRAP
}


CVAPI(ExceptionStatus) stereo_getValidDisparityROI(
    MyCvRect roi1, MyCvRect roi2,
    int minDisparity, int numberOfDisparities, int SADWindowSize,
    MyCvRect *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(cv::getValidDisparityROI(
        cpp(roi1), cpp(roi2), minDisparity, numberOfDisparities, SADWindowSize));
    END_WRAP
}


CVAPI(ExceptionStatus) stereo_validateDisparity(
    cv::_InputOutputArray *disparity, cv::_InputArray *cost,
    int minDisparity, int numberOfDisparities, int disp12MaxDisp)
{
    BEGIN_WRAP
    cv::validateDisparity(*disparity, *cost, minDisparity, numberOfDisparities, disp12MaxDisp);
    END_WRAP
}


CVAPI(ExceptionStatus) stereo_reprojectImageTo3D(
    cv::_InputArray *disparity, cv::_OutputArray *_3dImage,
    cv::_InputArray *Q, int handleMissingValues, int ddepth)
{
    BEGIN_WRAP
    cv::reprojectImageTo3D(*disparity, *_3dImage, *Q, handleMissingValues != 0, ddepth);
    END_WRAP
}

#endif // NO_STEREO
