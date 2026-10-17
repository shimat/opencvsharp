#pragma once

#if !defined(NO_CONTRIB) && defined(HAVE_OPENCV_REG)
#include "include_opencv.h"
#include <opencv2/reg/mapaffine.hpp>
#include <opencv2/reg/mapprojec.hpp>
#include <opencv2/reg/mapshift.hpp>
#include <opencv2/reg/mappergradaffine.hpp>
#include <opencv2/reg/mappergradeuclid.hpp>
#include <opencv2/reg/mappergradproj.hpp>
#include <opencv2/reg/mappergradshift.hpp>
#include <opencv2/reg/mappergradsimilar.hpp>
#include <opencv2/reg/mapperpyramid.hpp>

CVAPI(ExceptionStatus) reg_estimateTransform(
    const cv::Mat* reference, const cv::Mat* moving, int model,
    int pyramidLevels, int iterationsPerLevel, cv::Mat* transform)
{
    return cvTry([&] {
        cv::Ptr<cv::reg::Mapper> mapper;
        switch (model) {
        case 0: mapper = cv::makePtr<cv::reg::MapperGradShift>(); break;
        case 1: mapper = cv::makePtr<cv::reg::MapperGradEuclid>(); break;
        case 2: mapper = cv::makePtr<cv::reg::MapperGradSimilar>(); break;
        case 3: mapper = cv::makePtr<cv::reg::MapperGradAffine>(); break;
        case 4: mapper = cv::makePtr<cv::reg::MapperGradProj>(); break;
        default: CV_Error(cv::Error::StsBadArg, "Unknown registration motion model");
        }

        cv::reg::MapperPyramid pyramid(mapper);
        pyramid.numLev_ = pyramidLevels;
        pyramid.numIterPerScale_ = iterationsPerLevel;
        const cv::Ptr<cv::reg::Map> result = pyramid.calculate(*reference, *moving);

        *transform = cv::Mat::eye(3, 3, CV_64FC1);
        if (const auto shift = result.dynamicCast<cv::reg::MapShift>()) {
            const auto displacement = shift->getShift();
            transform->at<double>(0, 2) = displacement[0];
            transform->at<double>(1, 2) = displacement[1];
        } else if (const auto affine = result.dynamicCast<cv::reg::MapAffine>()) {
            const auto linear = affine->getLinTr();
            const auto displacement = affine->getShift();
            for (int row = 0; row < 2; ++row) {
                for (int col = 0; col < 2; ++col)
                    transform->at<double>(row, col) = linear(row, col);
                transform->at<double>(row, 2) = displacement[row];
            }
        } else if (const auto projective = result.dynamicCast<cv::reg::MapProjec>()) {
            cv::Mat(projective->getProjTr()).copyTo(*transform);
        } else {
            CV_Error(cv::Error::StsError, "Unexpected registration map type");
        }
    });
}
#endif // !NO_CONTRIB && HAVE_OPENCV_REG
