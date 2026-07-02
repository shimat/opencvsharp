#pragma once

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


#pragma region std::string
CVAPI(std::vector<std::string>*) vector_string_new1()
{
    return new std::vector<std::string>;
}
CVAPI(std::vector<std::string>*) vector_string_new2(size_t size)
{
    return new std::vector<std::string>(size);
}
CVAPI(size_t) vector_string_getSize(std::vector<std::string>* vec)
{
    return vec->size();
}
CVAPI(void) vector_string_getElements(std::vector<std::string>* vector, const char** cStringPointers, int32_t* stringLengths)
{
    for (size_t i = 0; i < vector->size(); i++)
    {
        const auto& elem = vector->at(i);
        cStringPointers[i] = elem.c_str();
        stringLengths[i] = static_cast<int32_t>(elem.size());
    }
}
CVAPI(void) vector_string_delete(std::vector<std::string>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region Generated blittable std::vector<T> wrappers
// POD element types reached from managed code via StdVector<T>.
// The macros expand to the same extern "C" symbols/signatures as the former
// hand-written blocks. Special element types (std::string, cv::Mat, ml::DTrees::*,
// cv::detail::ImageFeatures, line_descriptor::KeyLine) keep their bespoke
// definitions and are not generated here. The scalar primitives (uchar/int/int64/
// float/double) are generated here too; only vector_uchar_copy stays bespoke.

#define CV_VECTOR_CORE(SUFFIX, ELEM) \
    CVAPI(std::vector<ELEM>*) vector_##SUFFIX##_new1() { return new std::vector<ELEM>; } \
    CVAPI(size_t) vector_##SUFFIX##_getSize(std::vector<ELEM>* vector) { return vector->size(); } \
    CVAPI(ELEM*) vector_##SUFFIX##_getPointer(std::vector<ELEM>* vector) { return &(vector->at(0)); } \
    CVAPI(void) vector_##SUFFIX##_delete(std::vector<ELEM>* vector) { delete vector; }

#define CV_VECTOR_NEW2(SUFFIX, ELEM) \
    CVAPI(std::vector<ELEM>*) vector_##SUFFIX##_new2(size_t size) { return new std::vector<ELEM>(size); }

#define CV_VECTOR_NEW3(SUFFIX, ELEM) \
    CVAPI(std::vector<ELEM>*) vector_##SUFFIX##_new3(ELEM* data, size_t dataLength) { return new std::vector<ELEM>(data, data + dataLength); }

// Scalar primitives (StdVector<byte/int/long/float/double>).
CV_VECTOR_CORE(uchar, uchar)
CV_VECTOR_NEW2(uchar, uchar)
CV_VECTOR_NEW3(uchar, uchar)
CVAPI(void) vector_uchar_copy(std::vector<uchar>* vector, uchar* dst)
{
    const size_t length = sizeof(uchar) * vector->size();
    memcpy(dst, &(vector->at(0)), length);
}

CV_VECTOR_CORE(int32, int)
CV_VECTOR_NEW2(int32, int)
CV_VECTOR_NEW3(int32, int)

CV_VECTOR_CORE(int64, int64)
CV_VECTOR_NEW2(int64, int64)
CV_VECTOR_NEW3(int64, int64)

CV_VECTOR_CORE(float, float)
CV_VECTOR_NEW2(float, float)
CV_VECTOR_NEW3(float, float)

CV_VECTOR_CORE(double, double)
CV_VECTOR_NEW2(double, double)
CV_VECTOR_NEW3(double, double)

CV_VECTOR_CORE(Vec2f, cv::Vec2f)

CV_VECTOR_CORE(Vec3f, cv::Vec3f)

CV_VECTOR_CORE(Vec4f, cv::Vec4f)
CV_VECTOR_NEW3(Vec4f, cv::Vec4f)

CV_VECTOR_CORE(Vec4i, cv::Vec4i)
CV_VECTOR_NEW3(Vec4i, cv::Vec4i)

CV_VECTOR_CORE(Vec6f, cv::Vec6f)

CV_VECTOR_CORE(Vec6d, cv::Vec6d)

CV_VECTOR_CORE(Point2i, cv::Point)
CV_VECTOR_NEW2(Point2i, cv::Point)
CV_VECTOR_NEW3(Point2i, cv::Point)

CV_VECTOR_CORE(Point2f, cv::Point2f)
CV_VECTOR_NEW2(Point2f, cv::Point2f)
CV_VECTOR_NEW3(Point2f, cv::Point2f)

CV_VECTOR_CORE(Point2d, cv::Point2d)

CV_VECTOR_CORE(Point3f, cv::Point3f)
CV_VECTOR_NEW2(Point3f, cv::Point3f)
CV_VECTOR_NEW3(Point3f, cv::Point3f)

CV_VECTOR_CORE(Rect, cv::Rect)
CV_VECTOR_NEW2(Rect, cv::Rect)
CV_VECTOR_NEW3(Rect, cv::Rect)

CV_VECTOR_CORE(Rect2d, cv::Rect2d)
CV_VECTOR_NEW2(Rect2d, cv::Rect2d)
CV_VECTOR_NEW3(Rect2d, cv::Rect2d)

CV_VECTOR_CORE(RotatedRect, cv::RotatedRect)
CV_VECTOR_NEW2(RotatedRect, cv::RotatedRect)
CV_VECTOR_NEW3(RotatedRect, cv::RotatedRect)

CV_VECTOR_CORE(KeyPoint, cv::KeyPoint)
CV_VECTOR_NEW2(KeyPoint, cv::KeyPoint)
CV_VECTOR_NEW3(KeyPoint, cv::KeyPoint)

CV_VECTOR_CORE(DMatch, cv::DMatch)
CV_VECTOR_NEW2(DMatch, cv::DMatch)
CV_VECTOR_NEW3(DMatch, cv::DMatch)

#undef CV_VECTOR_NEW3
#undef CV_VECTOR_NEW2
#undef CV_VECTOR_CORE

#pragma endregion

#pragma region cv::Mat
CVAPI(std::vector<cv::Mat>*) vector_Mat_new1()
{
    return new std::vector<cv::Mat>;
}
CVAPI(std::vector<cv::Mat>*) vector_Mat_new2(uint32_t size)
{
    return new std::vector<cv::Mat>(size);
}
CVAPI(std::vector<cv::Mat>*) vector_Mat_new3(cv::Mat **data, uint32_t dataLength)
{
    auto *vec = new std::vector<cv::Mat>(dataLength);
    for (size_t i = 0; i < dataLength; i++)
    {
        (*vec)[i] = *(data[i]);
    }
    return vec;
}

CVAPI(size_t) vector_Mat_getSize(std::vector<cv::Mat>* vector)
{
    return vector->size();
}

CVAPI(cv::Mat*) vector_Mat_getPointer(std::vector<cv::Mat>* vector)
{
    return &(vector->at(0));
}

CVAPI(void) vector_Mat_assignToArray(std::vector<cv::Mat>* vector, cv::Mat** arr)
{
    for (size_t i = 0; i < vector->size(); i++)
    {
        (vector->at(i)).assignTo(*(arr[i]));
    }
}

CVAPI(void) vector_Mat_delete(std::vector<cv::Mat>* vector)
{
    //vector->~vector();
    delete vector;
}
#pragma endregion

#ifndef NO_ML
#pragma region cv::ml::DTrees::Node

CVAPI(std::vector<cv::ml::DTrees::Node>*) vector_DTrees_Node_new1()
{
    return new std::vector<cv::ml::DTrees::Node>;
}

CVAPI(size_t) vector_DTrees_Node_getSize(std::vector<cv::ml::DTrees::Node> *vector)
{
    return vector->size();
}

CVAPI(cv::ml::DTrees::Node*) vector_DTrees_Node_getPointer(std::vector<cv::ml::DTrees::Node> *vector)
{
    return &(vector->at(0));
}

CVAPI(void) vector_DTrees_Node_delete(std::vector<cv::ml::DTrees::Node> *vector)
{
    delete vector;
}

#pragma endregion

#pragma region cv::ml::DTrees::Split

CVAPI(std::vector<cv::ml::DTrees::Split>*) vector_DTrees_Split_new1()
{
    return new std::vector<cv::ml::DTrees::Split>;
}

CVAPI(size_t) vector_DTrees_Split_getSize(std::vector<cv::ml::DTrees::Split> *vector)
{
    return vector->size();
}

CVAPI(cv::ml::DTrees::Split*) vector_DTrees_Split_getPointer(std::vector<cv::ml::DTrees::Split> *vector)
{
    return &(vector->at(0));
}

CVAPI(void) vector_DTrees_Split_delete(std::vector<cv::ml::DTrees::Split> *vector)
{
    delete vector;
}

#pragma endregion
#endif // NO_ML

#ifndef NO_STITCHING
#pragma region cv::detail::ImageFeatures

CVAPI(std::vector<cv::detail::ImageFeatures>*) vector_ImageFeatures_new1()
{
    return new std::vector<cv::detail::ImageFeatures>;
}

CVAPI(size_t) vector_ImageFeatures_getSize(
    std::vector<cv::detail::ImageFeatures>* vector)
{
    return vector->size();
}

CVAPI(void) vector_ImageFeatures_getKeypointsSize(
    std::vector<cv::detail::ImageFeatures>* vector, size_t *dst)
{
    for (size_t i = 0; i < vector->size(); i++) 
    {
        dst[i] = vector->at(i).keypoints.size();
    }
}

CVAPI(void) vector_ImageFeatures_getElements(
    std::vector<cv::detail::ImageFeatures>* vector, detail_ImageFeatures* dstArray)
{
    for (size_t i = 0; i < vector->size(); i++)
    {
        const auto &src = vector->at(i);
        auto &dst = dstArray[i];
        dst.img_idx = src.img_idx;
        dst.img_size = c(src.img_size);
        //std::memcpy(dst.keypoints, &src.keypoints[0], sizeof(cv::KeyPoint)*src.keypoints.size());
        std::copy(src.keypoints.begin(), src.keypoints.end(), std::back_inserter(*dst.keypoints));
        src.descriptors.copyTo(*dst.descriptors);
    }
}

CVAPI(void) vector_ImageFeatures_delete(std::vector<cv::detail::ImageFeatures>* vector)
{
    delete vector;
}

#pragma endregion
#endif // NO_STITCHING

#pragma region cv::line_descriptor::KeyLine
#if 0
CVAPI(std::vector<cv::line_descriptor::KeyLine>*) vector_KeyLine_new1()
{
    return new std::vector<cv::line_descriptor::KeyLine>;
}

CVAPI(size_t) vector_KeyLine_getSize(std::vector<cv::line_descriptor::KeyLine>* vector)
{
    return vector->size();
}

/*
CVAPI(void) vector_KeyLine_getElements(
    std::vector<cv::line_descriptor::KeyLine>* vector, line_descriptor_KeyLine* dst)
{
    for (size_t i = 0; i < vector->size(); i++)
    {
        const auto &k = vector->at(i);
        const line_descriptor_KeyLine kl{
            k.angle, k.class_id, k.octave,
            {k.pt.x, k.pt.y},
            k.response,  k.size,
            k.startPointX, k.startPointY,
            k.endPointX, k.endPointY,
            k.sPointInOctaveX, k.sPointInOctaveY,
            k.ePointInOctaveX, k.ePointInOctaveY,
            k.lineLength, k.numOfPixels };
        dst[i] = kl;
    }
}*/

CVAPI(cv::line_descriptor::KeyLine*) vector_KeyLine_getPointer(std::vector<cv::line_descriptor::KeyLine>* vector)
{
    return &(vector->at(0));
}

CVAPI(void) vector_KeyLine_delete(std::vector<cv::line_descriptor::KeyLine>* vector)
{
    delete vector;
}
#endif
#pragma endregion