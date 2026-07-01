#pragma once

#ifndef NO_STEREO

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) stereo_stereoRectify_InputArray(
    const interop::InputArrayProxy* cameraMatrix1,
    const interop::InputArrayProxy* distCoeffs1,
    const interop::InputArrayProxy* cameraMatrix2,
    const interop::InputArrayProxy* distCoeffs2,
    interop::Size imageSize,
    const interop::InputArrayProxy* R,
    const interop::InputArrayProxy* T,
    const interop::OutputArrayProxy* R1,
    const interop::OutputArrayProxy* R2,
    const interop::OutputArrayProxy* P1,
    const interop::OutputArrayProxy* P2,
    const interop::OutputArrayProxy* Q,
    int flags,
    double alpha,
    interop::Size newImageSize,
    interop::Rect *validPixROI1,
    interop::Rect *validPixROI2)
{
    return cvTry([&] {
    cv::Rect _validPixROI1, _validPixROI2;
    cv::stereoRectify(InProxy(*cameraMatrix1), InProxy(*distCoeffs1), InProxy(*cameraMatrix2), InProxy(*distCoeffs2),
        cpp(imageSize), InProxy(*R), InProxy(*T), OutProxy(*R1), OutProxy(*R2), OutProxy(*P1), OutProxy(*P2), OutProxy(*Q), flags, alpha, cpp(newImageSize),
        &_validPixROI1, &_validPixROI2);
    *validPixROI1 = c(_validPixROI1);
    *validPixROI2 = c(_validPixROI2);
    });
}

CVAPI(ExceptionStatus) stereo_stereoRectify_array(
    double *cameraMatrix1,
    double *distCoeffs1,
    int dc1Size,
    double *cameraMatrix2,
    double *distCoeffs2,
    int dc2Size,
    interop::Size imageSize,
    double *R,
    double *T,
    double *R1,
    double *R2,
    double *P1,
    double *P2,
    double *Q,
    int flags,
    double alpha,
    interop::Size newImageSize,
    interop::Rect *validPixROI1,
    interop::Rect *validPixROI2)
{
    return cvTry([&] {
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
    });
}


CVAPI(ExceptionStatus) stereo_stereoRectifyUncalibrated_InputArray(
    const interop::InputArrayProxy* points1,
    const interop::InputArrayProxy* points2,
    const interop::InputArrayProxy* F,
    interop::Size imgSize,
    const interop::OutputArrayProxy* H1,
    const interop::OutputArrayProxy* H2,
    double threshold,
    int *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::stereoRectifyUncalibrated(InProxy(*points1), InProxy(*points2), InProxy(*F), cpp(imgSize), OutProxy(*H1), OutProxy(*H2), threshold) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) stereo_stereoRectifyUncalibrated_array(
    cv::Point2d *points1,
    int points1Size,
    cv::Point2d *points2,
    int points2Size,
    double *F,
    interop::Size imgSize,
    double *H1,
    double *H2,
    double threshold,
    int *returnValue)
{
    return cvTry([&] {
    const cv::Mat points1Mat(points1Size, 1, CV_64FC2, points1);
    const cv::Mat points2Mat(points2Size, 1, CV_64FC2, points2);
    const cv::Mat FM(3, 3, CV_64FC1, F);
    cv::Mat H1M(3, 3, CV_64FC1, H1);
    cv::Mat H2M(3, 3, CV_64FC1, H2);
    *returnValue = cv::stereoRectifyUncalibrated(points1Mat, points2Mat, FM, cpp(imgSize), H1M, H2M, threshold) ? 1 : 0;
    });
}


CVAPI(ExceptionStatus) stereo_rectify3Collinear_InputArray(
    const interop::InputArrayProxy* cameraMatrix1,
    const interop::InputArrayProxy* distCoeffs1,
    const interop::InputArrayProxy* cameraMatrix2,
    const interop::InputArrayProxy* distCoeffs2,
    const interop::InputArrayProxy* cameraMatrix3,
    const interop::InputArrayProxy* distCoeffs3,
    cv::Mat **imgpt1,
    int imgpt1Size,
    cv::Mat **imgpt3,
    int imgpt3Size,
    interop::Size imageSize,
    const interop::InputArrayProxy* R12,
    const interop::InputArrayProxy* T12,
    const interop::InputArrayProxy* R13,
    const interop::InputArrayProxy* T13,
    const interop::OutputArrayProxy* R1,
    const interop::OutputArrayProxy* R2,
    const interop::OutputArrayProxy* R3,
    const interop::OutputArrayProxy* P1,
    const interop::OutputArrayProxy* P2,
    const interop::OutputArrayProxy* P3,
    const interop::OutputArrayProxy* Q,
    double alpha,
    interop::Size newImgSize,
    interop::Rect *roi1,
    interop::Rect *roi2,
    int flags,
    float *returnValue)
{
    return cvTry([&] {
    std::vector<cv::Mat> imgpt1Vec(imgpt1Size);
    std::vector<cv::Mat> imgpt3Vec(imgpt3Size);
    for (auto i = 0; i < imgpt1Size; i++)
        imgpt1Vec[i] = *imgpt1[i];
    for (auto i = 0; i < imgpt3Size; i++)
        imgpt3Vec[i] = *imgpt3[i];
    cv::Rect _roi1, _roi2;

    const auto ret = cv::rectify3Collinear(InProxy(*cameraMatrix1), InProxy(*distCoeffs1),
        InProxy(*cameraMatrix2), InProxy(*distCoeffs2), InProxy(*cameraMatrix3), InProxy(*distCoeffs3),
        imgpt1Vec, imgpt3Vec, cpp(imageSize), InProxy(*R12), InProxy(*T12), InProxy(*R13), InProxy(*T13),
        OutProxy(*R1), OutProxy(*R2), OutProxy(*R3), OutProxy(*P1), OutProxy(*P2), OutProxy(*P3), OutProxy(*Q), alpha, cpp(newImgSize),
        &_roi1, &_roi2, flags);
    *roi1 = c(_roi1);
    *roi2 = c(_roi2);
    *returnValue = ret;
    });
}



CVAPI(ExceptionStatus) stereo_filterSpeckles(
    const interop::InputOutputArrayProxy* img,
    double newVal,
    int maxSpeckleSize,
    double maxDiff,
    const interop::InputOutputArrayProxy* buf)
{
    return cvTry([&] {
    cv::filterSpeckles(IoProxy(*img), newVal, maxSpeckleSize, maxDiff, IoProxy(*buf));
    });
}


CVAPI(ExceptionStatus) stereo_getValidDisparityROI(
    interop::Rect roi1,
    interop::Rect roi2,
    int minDisparity,
    int numberOfDisparities,
    int SADWindowSize,
    interop::Rect *returnValue)
{
    return cvTry([&] {
    *returnValue = c(cv::getValidDisparityROI(
        cpp(roi1), cpp(roi2), minDisparity, numberOfDisparities, SADWindowSize));
    });
}


CVAPI(ExceptionStatus) stereo_validateDisparity(
    const interop::InputOutputArrayProxy* disparity,
    const interop::InputArrayProxy* cost,
    int minDisparity,
    int numberOfDisparities,
    int disp12MaxDisp)
{
    return cvTry([&] {
    cv::validateDisparity(IoProxy(*disparity), InProxy(*cost), minDisparity, numberOfDisparities, disp12MaxDisp);
    });
}


CVAPI(ExceptionStatus) stereo_reprojectImageTo3D(
    const interop::InputArrayProxy* disparity,
    const interop::OutputArrayProxy* _3dImage,
    const interop::InputArrayProxy* Q,
    int handleMissingValues,
    int ddepth)
{
    return cvTry([&] {
    cv::reprojectImageTo3D(InProxy(*disparity), OutProxy(*_3dImage), InProxy(*Q), handleMissingValues != 0, ddepth);
    });
}

#endif // NO_STEREO
