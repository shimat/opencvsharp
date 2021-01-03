#pragma once

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


#pragma region vector<uchar>

CVAPI(std::vector<std::vector<uchar> >*) vector_vector_uchar_new1()
{
    return new std::vector<std::vector<uchar> >;
}

CVAPI(size_t) vector_vector_uchar_getSize1(std::vector<std::vector<uchar> >* vec)
{
    return vec->size();
}

CVAPI(void) vector_vector_uchar_getSize2(std::vector<std::vector<uchar> >* vec, size_t* sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}

CVAPI(void) vector_vector_uchar_copy(std::vector<std::vector<uchar> >* vec, uchar** dst)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        auto& elem = vec->at(i);
        void* src = &elem[0];
        const auto length = sizeof(int) * elem.size();
        memcpy(dst[i], src, length);
    }
}

CVAPI(void) vector_vector_uchar_delete(std::vector<std::vector<uchar> >* vec)
{
    delete vec;
}

#pragma endregion

#pragma region vector<int>

CVAPI(std::vector<std::vector<int> >*) vector_vector_int_new1()
{
    return new std::vector<std::vector<int> >;
}

CVAPI(size_t) vector_vector_int_getSize1(std::vector<std::vector<int> >* vec)
{
    return vec->size();
}

CVAPI(void) vector_vector_int_getSize2(std::vector<std::vector<int> >* vec, size_t* sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}

CVAPI(void) vector_vector_int_copy(std::vector<std::vector<int> >* vec, int** dst)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        auto& elem = vec->at(i);
        void* src = &elem[0];
        const auto length = sizeof(int) * elem.size();
        memcpy(dst[i], src, length);
    }
}

CVAPI(void) vector_vector_int_delete(std::vector<std::vector<int> >* vec)
{
    delete vec;
}

#pragma endregion

#pragma region vector<double>

CVAPI(std::vector<std::vector<double> >*) vector_vector_double_new1()
{
    return new std::vector<std::vector<double> >;
}

CVAPI(size_t) vector_vector_double_getSize1(std::vector<std::vector<double> >* vec)
{
    return vec->size();
}

CVAPI(void) vector_vector_double_getSize2(std::vector<std::vector<double> >* vec, size_t* sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}

CVAPI(void) vector_vector_double_copy(std::vector<std::vector<double> >* vec, double** dst)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        std::vector<double>& elem = vec->at(i);
        void* src = &elem[0];
        const size_t length = sizeof(double) * elem.size();
        memcpy(dst[i], src, length);
    }
}

CVAPI(void) vector_vector_double_delete(std::vector<std::vector<double> >* vec)
{
    delete vec;
}

#pragma endregion

#pragma region vector<cv::KeyPoint>

CVAPI(std::vector<std::vector<cv::KeyPoint> >*) vector_vector_KeyPoint_new1()
{
    return new std::vector<std::vector<cv::KeyPoint> >;
}

CVAPI(std::vector<std::vector<cv::KeyPoint> >*) vector_vector_KeyPoint_new3(
    cv::KeyPoint** values, int size1, int* size2)
{
    std::vector<std::vector<cv::KeyPoint> >* vec = new std::vector<std::vector<cv::KeyPoint> >(size1);
    for (int i = 0; i < size1; i++)
    {
        vec->at(i) = std::vector<cv::KeyPoint>(values[i], values[i] + size2[i]);
    }
    return vec;
}

CVAPI(size_t) vector_vector_KeyPoint_getSize1(std::vector<std::vector<cv::KeyPoint> >* vec)
{
    return vec->size();
}

CVAPI(void) vector_vector_KeyPoint_getSize2(std::vector<std::vector<cv::KeyPoint> >* vec, size_t* sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}

CVAPI(void) vector_vector_KeyPoint_copy(std::vector<std::vector<cv::KeyPoint> >* vec, cv::KeyPoint** dst)
{
    copyFromVectorToArray(vec, dst);
}

CVAPI(void) vector_vector_KeyPoint_delete(std::vector<std::vector<cv::KeyPoint> >* vec)
{
    delete vec;
}

#pragma endregion

#pragma region vector<cv::DMatch>

CVAPI(std::vector<std::vector<cv::DMatch> >*) vector_vector_DMatch_new1()
{
    return new std::vector<std::vector<cv::DMatch> >;
}

CVAPI(size_t) vector_vector_DMatch_getSize1(std::vector<std::vector<cv::DMatch> >* vec)
{
    return vec->size();
}

CVAPI(void) vector_vector_DMatch_getSize2(std::vector<std::vector<cv::DMatch> >* vec, size_t* sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}

CVAPI(void) vector_vector_DMatch_copy(std::vector<std::vector<cv::DMatch> >* vec, cv::DMatch** dst)
{
    copyFromVectorToArray(vec, dst);
}

CVAPI(void) vector_vector_DMatch_delete(std::vector<std::vector<cv::DMatch> >* vec)
{
    delete vec;
}

#pragma endregion

#pragma region vector<cv::Point>
CVAPI(std::vector<std::vector<cv::Point> >*) vector_vector_Point_new1()
{
    return new std::vector<std::vector<cv::Point> >;
}
CVAPI(std::vector<std::vector<cv::Point> >*) vector_vector_Point_new2(size_t size)
{
    return new std::vector<std::vector<cv::Point> >(size);
}
CVAPI(size_t) vector_vector_Point_getSize1(std::vector<std::vector<cv::Point> >* vec)
{
    return vec->size();
}
CVAPI(void) vector_vector_Point_getSize2(std::vector<std::vector<cv::Point> >* vec, size_t* sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}
CVAPI(void) vector_vector_Point_copy(std::vector<std::vector<cv::Point> >* vec, cv::Point** dst)
{
    copyFromVectorToArray(vec, dst);
}
CVAPI(void) vector_vector_Point_delete(std::vector<std::vector<cv::Point> >* vec)
{
    delete vec;
}
#pragma endregion

#pragma region vector<cv::Point2f>

CVAPI(std::vector<std::vector<cv::Point2f> >*) vector_vector_Point2f_new1()
{
    return new std::vector<std::vector<cv::Point2f> >;
}

CVAPI(size_t) vector_vector_Point2f_getSize1(std::vector<std::vector<cv::Point2f> >* vec)
{
    return vec->size();
}

CVAPI(void) vector_vector_Point2f_getSize2(std::vector<std::vector<cv::Point2f> >* vec, size_t* sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}

CVAPI(void) vector_vector_Point2f_copy(std::vector<std::vector<cv::Point2f> >* vec, cv::Point2f** dst)
{
    copyFromVectorToArray(vec, dst);
}

CVAPI(void) vector_vector_Point2f_delete(std::vector<std::vector<cv::Point2f> >* vec)
{
    delete vec;
}

#pragma endregion

#pragma region vector<cv::line_descriptor::KeyLine>

#if 0
CVAPI(std::vector<std::vector<cv::line_descriptor::KeyLine> >*) vector_vector_KeyLine_new1()
{
    return new std::vector<std::vector<cv::line_descriptor::KeyLine> >;
}

CVAPI(size_t) vector_vector_KeyLine_getSize1(std::vector<std::vector<cv::line_descriptor::KeyLine> >* vec)
{
    return vec->size();
}

CVAPI(void) vector_vector_KeyLine_getSize2(std::vector<std::vector<cv::line_descriptor::KeyLine> >* vec, size_t* sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}

CVAPI(void) vector_vector_KeyLine_copy(std::vector<std::vector<cv::line_descriptor::KeyLine> >* vec, cv::line_descriptor::KeyLine** dst)
{
    copyFromVectorToArray(vec, dst);
}

CVAPI(void) vector_vector_KeyLine_delete(std::vector<std::vector<cv::line_descriptor::KeyLine> >* vec)
{
    delete vec;
}
#endif
#pragma endregion