#pragma once

#if !defined(NO_CONTRIB) && defined(HAVE_OPENCV_RAPID)
#include "include_opencv.h"
#include <opencv2/rapid.hpp>
#include <limits>

static void rapid_validateTriangleIndices(const cv::Mat& triangles, int vertexCount)
{
    const cv::Mat indices = triangles.reshape(1);
    double minimum, maximum;
    cv::minMaxIdx(indices, &minimum, &maximum);
    CV_Assert(minimum >= 0 && maximum < vertexCount);
}

CVAPI(ExceptionStatus) rapid_track(
    const cv::Mat* image, int num, int len, const cv::Mat* vertices,
    const cv::Mat* triangles, const cv::Mat* cameraMatrix,
    cv::Mat* rotation, cv::Mat* translation, float* matchRatio, double* rmsd)
{
    return cvTry([&] {
        rapid_validateTriangleIndices(*triangles, vertices->checkVector(3, CV_32F));
        *rmsd = std::numeric_limits<double>::quiet_NaN();
        *matchRatio = cv::rapid::rapid(*image, num, len, *vertices, *triangles,
                                      *cameraMatrix, *rotation, *translation, rmsd);
    });
}

CVAPI(ExceptionStatus) rapid_drawWireframe(
    cv::Mat* image, const cv::Mat* imagePoints, const cv::Mat* triangles,
    interop::Scalar color, int lineType, int cullBackface)
{
    return cvTry([&] {
        rapid_validateTriangleIndices(*triangles, imagePoints->checkVector(2, CV_32F));
        cv::rapid::drawWireframe(*image, *imagePoints, *triangles,
                                 cpp(color), lineType, cullBackface != 0);
    });
}
#endif // !NO_CONTRIB && HAVE_OPENCV_RAPID
