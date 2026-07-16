#pragma once

#ifndef NO_CONTRIB

#include "include_opencv.h"
#include <opencv2/face/bif.hpp>

#ifndef _WINRT_DLL

#pragma region BIF

CVAPI(ExceptionStatus) face_BIF_create(
    const int numBands, const int numRotations, cv::Ptr<cv::face::BIF> **returnValue)
{
    return cvTry([&] { *returnValue = clone(cv::face::BIF::create(numBands, numRotations)); });
}

CVAPI(ExceptionStatus) face_Ptr_BIF_get(
    cv::Ptr<cv::face::BIF> *obj, cv::face::BIF **returnValue)
{
    return cvTry([&] { *returnValue = obj->get(); });
}

CVAPI(ExceptionStatus) face_Ptr_BIF_delete(cv::Ptr<cv::face::BIF> *obj)
{
    return cvTry([&] { delete obj; });
}

CVAPI(ExceptionStatus) face_BIF_getNumBands(cv::face::BIF *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getNumBands(); });
}

CVAPI(ExceptionStatus) face_BIF_getNumRotations(cv::face::BIF *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getNumRotations(); });
}

CVAPI(ExceptionStatus) face_BIF_compute(
    cv::face::BIF *obj,
    const interop::InputArrayProxy *image,
    const interop::OutputArrayProxy *features)
{
    return cvTry([&] { obj->compute(InProxy(*image), OutProxy(*features)); });
}

#pragma endregion

#pragma region MACE

CVAPI(ExceptionStatus) face_MACE_create(const int imageSize, cv::Ptr<cv::face::MACE> **returnValue)
{
    return cvTry([&] { *returnValue = clone(cv::face::MACE::create(imageSize)); });
}

CVAPI(ExceptionStatus) face_MACE_load(
    const char *filename, const char *objName, cv::Ptr<cv::face::MACE> **returnValue)
{
    return cvTry([&] { *returnValue = clone(cv::face::MACE::load(filename, objName)); });
}

CVAPI(ExceptionStatus) face_Ptr_MACE_get(
    cv::Ptr<cv::face::MACE> *obj, cv::face::MACE **returnValue)
{
    return cvTry([&] { *returnValue = obj->get(); });
}

CVAPI(ExceptionStatus) face_Ptr_MACE_delete(cv::Ptr<cv::face::MACE> *obj)
{
    return cvTry([&] { delete obj; });
}

CVAPI(ExceptionStatus) face_MACE_salt(cv::face::MACE *obj, const char *passphrase)
{
    return cvTry([&] { obj->salt(passphrase); });
}

CVAPI(ExceptionStatus) face_MACE_train(
    cv::face::MACE *obj, cv::Mat **images, const int imagesLength)
{
    return cvTry([&] {
        std::vector<cv::Mat> imageVector(imagesLength);
        for (auto i = 0; i < imagesLength; i++)
            imageVector[i] = *images[i];
        obj->train(imageVector);
    });
}

CVAPI(ExceptionStatus) face_MACE_same(
    cv::face::MACE *obj, const interop::InputArrayProxy *query, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->same(InProxy(*query)) ? 1 : 0; });
}

#pragma endregion

#pragma region PredictCollector

CVAPI(ExceptionStatus) face_PredictCollector_init(
    cv::face::PredictCollector *obj, const size_t size)
{
    return cvTry([&] { obj->init(size); });
}

CVAPI(ExceptionStatus) face_PredictCollector_collect(
    cv::face::PredictCollector *obj, const int label, const double distance, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->collect(label, distance) ? 1 : 0; });
}

CVAPI(ExceptionStatus) face_StandardCollector_create(
    const double threshold, cv::Ptr<cv::face::StandardCollector> **returnValue)
{
    return cvTry([&] { *returnValue = clone(cv::face::StandardCollector::create(threshold)); });
}

CVAPI(ExceptionStatus) face_Ptr_StandardCollector_get(
    cv::Ptr<cv::face::StandardCollector> *obj, cv::face::StandardCollector **returnValue)
{
    return cvTry([&] { *returnValue = obj->get(); });
}

CVAPI(ExceptionStatus) face_Ptr_StandardCollector_delete(
    cv::Ptr<cv::face::StandardCollector> *obj)
{
    return cvTry([&] { delete obj; });
}

CVAPI(ExceptionStatus) face_StandardCollector_getMinLabel(
    cv::face::StandardCollector *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getMinLabel(); });
}

CVAPI(ExceptionStatus) face_StandardCollector_getMinDist(
    cv::face::StandardCollector *obj, double *returnValue)
{
    return cvTry([&] { *returnValue = obj->getMinDist(); });
}

CVAPI(ExceptionStatus) face_StandardCollector_getResults(
    cv::face::StandardCollector *obj,
    const int sorted,
    std::vector<int> *labels,
    std::vector<double> *distances)
{
    return cvTry([&] {
        const auto results = obj->getResults(sorted != 0);
        labels->clear();
        distances->clear();
        labels->reserve(results.size());
        distances->reserve(results.size());
        for (const auto &result : results)
        {
            labels->push_back(result.first);
            distances->push_back(result.second);
        }
    });
}

CVAPI(ExceptionStatus) face_StandardCollector_getResultsMap(
    cv::face::StandardCollector *obj,
    std::vector<int> *labels,
    std::vector<double> *distances)
{
    return cvTry([&] {
        const auto results = obj->getResultsMap();
        labels->clear();
        distances->clear();
        labels->reserve(results.size());
        distances->reserve(results.size());
        for (const auto &result : results)
        {
            labels->push_back(result.first);
            distances->push_back(result.second);
        }
    });
}

#pragma endregion

#endif // !_WINRT_DLL
#endif // NO_CONTRIB
