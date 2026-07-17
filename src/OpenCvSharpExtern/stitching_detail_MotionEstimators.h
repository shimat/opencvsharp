#pragma once

#ifndef NO_STITCHING

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

static void toImageFeaturesVec(
    detail_ImageFeatures *features, int size, std::vector<cv::detail::ImageFeatures> &outVec)
{
    outVec.reserve(size);
    for (int i = 0; i < size; i++)
    {
        cv::detail::ImageFeatures f{
            features[i].img_idx,
            cpp(features[i].img_size),
            *features[i].keypoints,
            cv::UMat() };
        features[i].descriptors->copyTo(f.descriptors);
        outVec.push_back(f);
    }
}

static void toMatchesInfoVec(
    detail_MatchesInfo *matches, int size, std::vector<cv::detail::MatchesInfo> &outVec)
{
    outVec.reserve(size);
    for (int i = 0; i < size; i++)
    {
        cv::detail::MatchesInfo m;
        m.src_img_idx = matches[i].src_img_idx;
        m.dst_img_idx = matches[i].dst_img_idx;
        m.matches = *matches[i].matches;
        m.inliers_mask = *matches[i].inliers_mask;
        m.num_inliers = matches[i].num_inliers;
        matches[i].h->copyTo(m.H);
        m.confidence = matches[i].confidence;
        outVec.push_back(m);
    }
}


// Estimator

CVAPI(ExceptionStatus) stitching_Estimator_apply(
    cv::detail::Estimator *obj,
    detail_ImageFeatures *features, int featuresSize,
    detail_MatchesInfo *pairwiseMatches, int pairwiseMatchesSize,
    detail_CameraParams *cameras, int camerasSize,
    int *returnValue)
{
    return cvTry([&] {
        std::vector<cv::detail::ImageFeatures> featuresVec;
        toImageFeaturesVec(features, featuresSize, featuresVec);

        std::vector<cv::detail::MatchesInfo> matchesVec;
        toMatchesInfoVec(pairwiseMatches, pairwiseMatchesSize, matchesVec);

        std::vector<cv::detail::CameraParams> camerasVec(static_cast<size_t>(camerasSize));
        for (int i = 0; i < camerasSize; i++)
        {
            camerasVec[static_cast<size_t>(i)].focal = cameras[i].focal;
            camerasVec[static_cast<size_t>(i)].aspect = cameras[i].aspect;
            camerasVec[static_cast<size_t>(i)].ppx = cameras[i].ppx;
            camerasVec[static_cast<size_t>(i)].ppy = cameras[i].ppy;
            cameras[i].r->copyTo(camerasVec[static_cast<size_t>(i)].R);
            cameras[i].t->copyTo(camerasVec[static_cast<size_t>(i)].t);
        }

        const bool ok = (*obj)(featuresVec, matchesVec, camerasVec);
        *returnValue = ok ? 1 : 0;

        for (int i = 0; i < camerasSize && i < static_cast<int>(camerasVec.size()); i++)
        {
            const auto &c = camerasVec[static_cast<size_t>(i)];
            cameras[i].focal = c.focal;
            cameras[i].aspect = c.aspect;
            cameras[i].ppx = c.ppx;
            cameras[i].ppy = c.ppy;
            c.R.copyTo(*cameras[i].r);
            c.t.copyTo(*cameras[i].t);
        }
    });
}


// HomographyBasedEstimator

CVAPI(ExceptionStatus) stitching_HomographyBasedEstimator_new(
    int isFocalsEstimated, cv::detail::HomographyBasedEstimator **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::detail::HomographyBasedEstimator(isFocalsEstimated != 0);
    });
}

CVAPI(ExceptionStatus) stitching_HomographyBasedEstimator_delete(cv::detail::HomographyBasedEstimator *obj)
{
    return cvTry([&] {
        delete obj;
    });
}


// AffineBasedEstimator

CVAPI(ExceptionStatus) stitching_AffineBasedEstimator_new(cv::detail::AffineBasedEstimator **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::detail::AffineBasedEstimator();
    });
}

CVAPI(ExceptionStatus) stitching_AffineBasedEstimator_delete(cv::detail::AffineBasedEstimator *obj)
{
    return cvTry([&] {
        delete obj;
    });
}


// BundleAdjusterBase

CVAPI(ExceptionStatus) stitching_BundleAdjusterBase_delete(cv::detail::BundleAdjusterBase *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) stitching_BundleAdjusterBase_refinementMask(cv::detail::BundleAdjusterBase *obj, cv::Mat *returnValue)
{
    return cvTry([&] {
        obj->refinementMask().copyTo(*returnValue);
    });
}
CVAPI(ExceptionStatus) stitching_BundleAdjusterBase_setRefinementMask(cv::detail::BundleAdjusterBase *obj, cv::Mat *mask)
{
    return cvTry([&] {
        obj->setRefinementMask(*mask);
    });
}
CVAPI(ExceptionStatus) stitching_BundleAdjusterBase_confThresh(cv::detail::BundleAdjusterBase *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->confThresh();
    });
}
CVAPI(ExceptionStatus) stitching_BundleAdjusterBase_setConfThresh(cv::detail::BundleAdjusterBase *obj, double confThresh)
{
    return cvTry([&] {
        obj->setConfThresh(confThresh);
    });
}
CVAPI(ExceptionStatus) stitching_BundleAdjusterBase_termCriteria(cv::detail::BundleAdjusterBase *obj, interop::TermCriteria *returnValue)
{
    return cvTry([&] {
        *returnValue = c(obj->termCriteria());
    });
}
CVAPI(ExceptionStatus) stitching_BundleAdjusterBase_setTermCriteria(cv::detail::BundleAdjusterBase *obj, interop::TermCriteria termCriteria)
{
    return cvTry([&] {
        obj->setTermCriteria(cpp(termCriteria));
    });
}


// NoBundleAdjuster

CVAPI(ExceptionStatus) stitching_NoBundleAdjuster_new(cv::detail::NoBundleAdjuster **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::detail::NoBundleAdjuster();
    });
}


// BundleAdjusterReproj

CVAPI(ExceptionStatus) stitching_BundleAdjusterReproj_new(cv::detail::BundleAdjusterReproj **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::detail::BundleAdjusterReproj();
    });
}


// BundleAdjusterRay

CVAPI(ExceptionStatus) stitching_BundleAdjusterRay_new(cv::detail::BundleAdjusterRay **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::detail::BundleAdjusterRay();
    });
}


// BundleAdjusterAffine

CVAPI(ExceptionStatus) stitching_BundleAdjusterAffine_new(cv::detail::BundleAdjusterAffine **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::detail::BundleAdjusterAffine();
    });
}


// BundleAdjusterAffinePartial

CVAPI(ExceptionStatus) stitching_BundleAdjusterAffinePartial_new(cv::detail::BundleAdjusterAffinePartial **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::detail::BundleAdjusterAffinePartial();
    });
}


// Auxiliary functions

CVAPI(ExceptionStatus) stitching_waveCorrect(cv::Mat **rmats, int rmatsLength, int kind)
{
    return cvTry([&] {
        std::vector<cv::Mat> rmatsVec;
        toVec(rmats, rmatsLength, rmatsVec);

        cv::detail::waveCorrect(rmatsVec, static_cast<cv::detail::WaveCorrectKind>(kind));

        for (int i = 0; i < rmatsLength && i < static_cast<int>(rmatsVec.size()); i++)
            rmatsVec[static_cast<size_t>(i)].copyTo(*rmats[i]);
    });
}

// Note: upstream matchesGraphAsString() takes a `paths` label per image, but there's no established
// cross-platform-safe convention in this codebase for marshaling string arrays across the P/Invoke
// boundary (individual strings need the Windows-LPStr/non-Windows-LPUTF8Str split used elsewhere).
// Since the labels are cosmetic (DOT graph node text), numImages is used to generate empty placeholders.
CVAPI(ExceptionStatus) stitching_matchesGraphAsString(
    int numImages,
    detail_MatchesInfo *pairwiseMatches, int pairwiseMatchesSize,
    float confThreshold,
    std::string *buf)
{
    return cvTry([&] {
        std::vector<cv::String> pathsVec(static_cast<size_t>(numImages));

        std::vector<cv::detail::MatchesInfo> matchesVec;
        toMatchesInfoVec(pairwiseMatches, pairwiseMatchesSize, matchesVec);

        buf->assign(cv::detail::matchesGraphAsString(pathsVec, matchesVec, confThreshold));
    });
}

CVAPI(ExceptionStatus) stitching_leaveBiggestComponent(
    detail_ImageFeatures *features, int featuresSize,
    detail_MatchesInfo *pairwiseMatches, int pairwiseMatchesSize,
    float confThreshold,
    std::vector<int> *returnValue)
{
    return cvTry([&] {
        std::vector<cv::detail::ImageFeatures> featuresVec;
        toImageFeaturesVec(features, featuresSize, featuresVec);

        std::vector<cv::detail::MatchesInfo> matchesVec;
        toMatchesInfoVec(pairwiseMatches, pairwiseMatchesSize, matchesVec);

        const auto indices = cv::detail::leaveBiggestComponent(featuresVec, matchesVec, confThreshold);
        std::copy(indices.begin(), indices.end(), std::back_inserter(*returnValue));
    });
}

#endif // NO_STITCHING
