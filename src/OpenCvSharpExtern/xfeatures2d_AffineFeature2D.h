#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region AffineFeature2D

namespace
{
    interop::EllipticKeyPoint toInterop(const cv::xfeatures2d::Elliptic_KeyPoint &kp)
    {
        interop::EllipticKeyPoint ekp{};
        ekp.base.pt = interop::Point2f{ kp.pt.x, kp.pt.y };
        ekp.base.size = kp.size;
        ekp.base.angle = kp.angle;
        ekp.base.response = kp.response;
        ekp.base.octave = kp.octave;
        ekp.base.class_id = kp.class_id;
        ekp.axes = interop::Size2f{ kp.axes.width, kp.axes.height };
        ekp.si = kp.si;
        ekp.transf[0] = kp.transf(0, 0); ekp.transf[1] = kp.transf(0, 1); ekp.transf[2] = kp.transf(0, 2);
        ekp.transf[3] = kp.transf(1, 0); ekp.transf[4] = kp.transf(1, 1); ekp.transf[5] = kp.transf(1, 2);
        return ekp;
    }

    cv::xfeatures2d::Elliptic_KeyPoint fromInterop(const interop::EllipticKeyPoint &ekp)
    {
        cv::xfeatures2d::Elliptic_KeyPoint kp;
        kp.pt = cv::Point2f(ekp.base.pt.x, ekp.base.pt.y);
        kp.size = ekp.base.size;
        kp.angle = ekp.base.angle;
        kp.response = ekp.base.response;
        kp.octave = ekp.base.octave;
        kp.class_id = ekp.base.class_id;
        kp.axes = cv::Size2f(ekp.axes.width, ekp.axes.height);
        kp.si = ekp.si;
        kp.transf = cv::Matx23f(
            ekp.transf[0], ekp.transf[1], ekp.transf[2],
            ekp.transf[3], ekp.transf[4], ekp.transf[5]);
        return kp;
    }
}

CVAPI(ExceptionStatus) xfeatures2d_AffineFeature2D_create1(
    cv::Ptr<cv::Feature2D> *keypointDetector, cv::Ptr<cv::Feature2D> *descriptorExtractor,
    cv::Ptr<cv::xfeatures2d::AffineFeature2D> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::xfeatures2d::AffineFeature2D::create(*keypointDetector, *descriptorExtractor);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_AffineFeature2D_create2(
    cv::Ptr<cv::Feature2D> *keypointDetector,
    cv::Ptr<cv::xfeatures2d::AffineFeature2D> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::xfeatures2d::AffineFeature2D::create(*keypointDetector);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_AffineFeature2D_delete(cv::Ptr<cv::xfeatures2d::AffineFeature2D> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_AffineFeature2D_get(
    cv::Ptr<cv::xfeatures2d::AffineFeature2D> *obj, cv::xfeatures2d::AffineFeature2D **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_AffineFeature2D_detect(
    cv::xfeatures2d::AffineFeature2D *obj, const interop::InputArrayProxy *image,
    std::vector<interop::EllipticKeyPoint> *keypoints, const interop::InputArrayProxy *mask)
{
    return cvTry([&] {
        std::vector<cv::xfeatures2d::Elliptic_KeyPoint> kpVec;
        obj->detect(InProxy(*image), kpVec, InProxy(*mask));
        keypoints->clear();
        keypoints->reserve(kpVec.size());
        for (const auto &kp : kpVec)
            keypoints->push_back(toInterop(kp));
    });
}

CVAPI(ExceptionStatus) xfeatures2d_AffineFeature2D_detectAndCompute(
    cv::xfeatures2d::AffineFeature2D *obj, const interop::InputArrayProxy *image, const interop::InputArrayProxy *mask,
    std::vector<interop::EllipticKeyPoint> *keypoints, const interop::OutputArrayProxy *descriptors, int useProvidedKeypoints)
{
    return cvTry([&] {
        std::vector<cv::xfeatures2d::Elliptic_KeyPoint> kpVec;
        if (useProvidedKeypoints != 0)
        {
            kpVec.reserve(keypoints->size());
            for (const auto &ekp : *keypoints)
                kpVec.push_back(fromInterop(ekp));
        }
        obj->detectAndCompute(InProxy(*image), InProxy(*mask), kpVec, OutProxy(*descriptors), useProvidedKeypoints != 0);
        keypoints->clear();
        keypoints->reserve(kpVec.size());
        for (const auto &kp : kpVec)
            keypoints->push_back(toInterop(kp));
    });
}

#pragma endregion

#endif // NO_CONTRIB
