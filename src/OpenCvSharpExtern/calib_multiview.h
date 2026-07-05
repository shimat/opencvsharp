#pragma once

#ifndef NO_CALIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// registerCameras (OpenCV 5): registers a pair of cameras (possibly with different camera models).
CVAPI(ExceptionStatus) calib_registerCameras(
    cv::Mat **objectPoints1,
    int objectPoints1Size,
    cv::Mat **objectPoints2,
    int objectPoints2Size,
    cv::Mat **imagePoints1,
    int imagePoints1Size,
    cv::Mat **imagePoints2,
    int imagePoints2Size,
    const interop::InputArrayProxy* cameraMatrix1,
    const interop::InputArrayProxy* distCoeffs1,
    int cameraModel1,
    const interop::InputArrayProxy* cameraMatrix2,
    const interop::InputArrayProxy* distCoeffs2,
    int cameraModel2,
    const interop::InputOutputArrayProxy* R,
    const interop::InputOutputArrayProxy* T,
    const interop::OutputArrayProxy* E,
    const interop::OutputArrayProxy* F,
    const interop::OutputArrayProxy* perViewErrors,
    int flags,
    interop::TermCriteria criteria,
    double *returnValue)
{
    return cvTry([&] {
        std::vector<cv::Mat> op1(objectPoints1Size), op2(objectPoints2Size), ip1(imagePoints1Size), ip2(imagePoints2Size);
        for (int i = 0; i < objectPoints1Size; i++) op1[i] = *objectPoints1[i];
        for (int i = 0; i < objectPoints2Size; i++) op2[i] = *objectPoints2[i];
        for (int i = 0; i < imagePoints1Size; i++) ip1[i] = *imagePoints1[i];
        for (int i = 0; i < imagePoints2Size; i++) ip2[i] = *imagePoints2[i];

        *returnValue = cv::registerCameras(
            op1, op2, ip1, ip2,
            InProxy(*cameraMatrix1), InProxy(*distCoeffs1), static_cast<cv::CameraModel>(cameraModel1),
            InProxy(*cameraMatrix2), InProxy(*distCoeffs2), static_cast<cv::CameraModel>(cameraModel2),
            IoProxy(*R), IoProxy(*T), OutProxy(*E), OutProxy(*F), OutProxy(*perViewErrors), flags, cpp(criteria));
    });
}

// calibrateMultiview (OpenCV 5): intrinsics + extrinsics for a multi-camera system.
// imagePoints is a flat array of NUM_CAMERAS x framesPerCamera[i] matrices.
// Ks / distortions / Rs / Ts are InputOutputArrayOfArrays; pass empty vectors to receive the outputs.
CVAPI(ExceptionStatus) calib_calibrateMultiview(
    cv::Mat **objPoints,
    int objPointsSize,
    cv::Mat **imagePoints,
    int numCameras,
    int *framesPerCamera,
    interop::Size *imageSize,
    int imageSizeSize,
    const interop::InputArrayProxy* detectionMask,
    const interop::InputArrayProxy* models,
    std::vector<cv::Mat> *Ks,
    std::vector<cv::Mat> *distortions,
    std::vector<cv::Mat> *Rs,
    std::vector<cv::Mat> *Ts,
    const interop::InputArrayProxy* flagsForIntrinsics,
    int flags,
    interop::TermCriteria criteria,
    double *returnValue)
{
    return cvTry([&] {
        std::vector<cv::Mat> objPointsVec(objPointsSize);
        for (int i = 0; i < objPointsSize; i++)
            objPointsVec[i] = *objPoints[i];

        std::vector<std::vector<cv::Mat>> imagePointsVec(numCameras);
        int idx = 0;
        for (int c = 0; c < numCameras; c++)
        {
            imagePointsVec[c].resize(framesPerCamera[c]);
            for (int f = 0; f < framesPerCamera[c]; f++)
                imagePointsVec[c][f] = *imagePoints[idx++];
        }

        std::vector<cv::Size> imageSizeVec(imageSizeSize);
        for (int i = 0; i < imageSizeSize; i++)
            imageSizeVec[i] = cpp(imageSize[i]);

        *returnValue = cv::calibrateMultiview(
            objPointsVec, imagePointsVec, imageSizeVec,
            InProxy(*detectionMask), InProxy(*models),
            *Ks, *distortions, *Rs, *Ts,
            InProxy(*flagsForIntrinsics), flags, cpp(criteria));
    });
}

#endif // NO_CALIB
