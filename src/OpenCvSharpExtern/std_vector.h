#ifndef _CPP_WVECTOR_H_
#define _CPP_WVECTOR_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

template <typename T>
static void copyFromVectorToArray(std::vector<std::vector<T> > *src, T **dst)
{
    for (size_t i = 0; i < src->size(); ++i)
    {
        const auto& srcI = src->at(i);
        const auto dstI = dst[i];
        for (size_t j = 0; j < srcI.size(); ++j)
        {
            dstI[j] = srcI[j];
        }
    }
}

#pragma region uchar
CVAPI(std::vector<uchar>*) vector_uchar_new1()
{
    return new std::vector<uchar>;
}
CVAPI(std::vector<uchar>*) vector_uchar_new2(size_t size)
{
    return new std::vector<uchar>(size);
}
CVAPI(std::vector<uchar>*) vector_uchar_new3(uchar* data, size_t dataLength)
{
    return new std::vector<uchar>(data, data + dataLength);
}
CVAPI(size_t) vector_uchar_getSize(std::vector<uchar>* vector)
{
    return vector->size();
}
CVAPI(uchar*) vector_uchar_getPointer(std::vector<uchar>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_vector_uchar_copy(std::vector<uchar> *vector, uchar *dst)
{
    const size_t length = sizeof(uchar)* vector->size();
    memcpy(dst, &(vector->at(0)), length);
}
CVAPI(void) vector_uchar_delete(std::vector<uchar>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region char
CVAPI(std::vector<char>*) vector_char_new1()
{
    return new std::vector<char>;
}
CVAPI(std::vector<char>*) vector_char_new2(size_t size)
{
    return new std::vector<char>(size);
}
CVAPI(std::vector<char>*) vector_char_new3(char* data, size_t dataLength)
{
    return new std::vector<char>(data, data + dataLength);
}
CVAPI(size_t) vector_char_getSize(std::vector<char>* vector)
{
    return vector->size();
}
CVAPI(char*) vector_char_getPointer(std::vector<char>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_vector_char_copy(std::vector<char> *vector, char *dst)
{
    const size_t length = sizeof(char)* vector->size();
    memcpy(dst, &(vector->at(0)), length);
}
CVAPI(void) vector_char_delete(std::vector<char>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region int
CVAPI(std::vector<int>*) vector_int32_new1()
{
    return new std::vector<int>;
}
CVAPI(std::vector<int>*) vector_int32_new2(size_t size)
{
    return new std::vector<int>(size);
}
CVAPI(std::vector<int>*) vector_int32_new3(int* data, size_t dataLength)
{
    return new std::vector<int>(data, data + dataLength);
}
CVAPI(size_t) vector_int32_getSize(std::vector<int>* vector)
{
    return vector->size();
}
CVAPI(int*) vector_int32_getPointer(std::vector<int>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_int32_delete(std::vector<int>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region float
CVAPI(std::vector<float>*) vector_float_new1()
{
    return new std::vector<float>;
}
CVAPI(std::vector<float>*) vector_float_new2(size_t size)
{
    return new std::vector<float>(size);
}
CVAPI(std::vector<float>*) vector_float_new3(float* data, size_t dataLength)
{
    return new std::vector<float>(data, data + dataLength);
}
CVAPI(size_t) vector_float_getSize(std::vector<float>* vector)
{
    return vector->size();
}
CVAPI(float*) vector_float_getPointer(std::vector<float>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_float_delete(std::vector<float>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region double
CVAPI(std::vector<double>*) vector_double_new1()
{
    return new std::vector<double>;
}
CVAPI(std::vector<double>*) vector_double_new2(size_t size)
{
    return new std::vector<double>(size);
}
CVAPI(std::vector<double>*) vector_double_new3(double* data, size_t dataLength)
{
    return new std::vector<double>(data, data + dataLength);
}
CVAPI(size_t) vector_double_getSize(std::vector<double>* vector)
{
    return vector->size();
}
CVAPI(double*) vector_double_getPointer(std::vector<double>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_double_delete(std::vector<double>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Vec2f
CVAPI(std::vector<cv::Vec2f>*) vector_Vec2f_new1()
{
    return new std::vector<cv::Vec2f>;
}
CVAPI(std::vector<cv::Vec2f>*) vector_Vec2f_new2(size_t size)
{
    return new std::vector<cv::Vec2f>(size);
}
CVAPI(std::vector<cv::Vec2f>*) vector_Vec2f_new3(cv::Vec2f* data, size_t dataLength)
{
    return new std::vector<cv::Vec2f>(data, data + dataLength);
}
CVAPI(size_t) vector_Vec2f_getSize(std::vector<cv::Vec2f>* vector)
{
    return vector->size();
}
CVAPI(cv::Vec2f*) vector_Vec2f_getPointer(std::vector<cv::Vec2f>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Vec2f_delete(std::vector<cv::Vec2f>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Vec3f
CVAPI(std::vector<cv::Vec3f>*) vector_Vec3f_new1()
{
    return new std::vector<cv::Vec3f>;
}
CVAPI(std::vector<cv::Vec3f>*) vector_Vec3f_new2(size_t size)
{
    return new std::vector<cv::Vec3f>(size);
}
CVAPI(std::vector<cv::Vec3f>*) vector_Vec3f_new3(cv::Vec3f* data, size_t dataLength)
{
    return new std::vector<cv::Vec3f>(data, data + dataLength);
}
CVAPI(size_t) vector_Vec3f_getSize(std::vector<cv::Vec3f>* vector)
{
    return vector->size();
}
CVAPI(cv::Vec3f*) vector_Vec3f_getPointer(std::vector<cv::Vec3f>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Vec3f_delete(std::vector<cv::Vec3f>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Vec4f
CVAPI(std::vector<cv::Vec4f>*) vector_Vec4f_new1()
{
    return new std::vector<cv::Vec4f>;
}
CVAPI(std::vector<cv::Vec4f>*) vector_Vec4f_new2(size_t size)
{
    return new std::vector<cv::Vec4f>(size);
}
CVAPI(std::vector<cv::Vec4f>*) vector_Vec4f_new3(cv::Vec4f* data, size_t dataLength)
{
    return new std::vector<cv::Vec4f>(data, data + dataLength);
}
CVAPI(size_t) vector_Vec4f_getSize(std::vector<cv::Vec4f>* vector)
{
    return vector->size();
}
CVAPI(cv::Vec4f*) vector_Vec4f_getPointer(std::vector<cv::Vec4f>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Vec4f_delete(std::vector<cv::Vec4f>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Vec4i
CVAPI(std::vector<cv::Vec4i>*) vector_Vec4i_new1()
{
    return new std::vector<cv::Vec4i>;
}
CVAPI(std::vector<cv::Vec4i>*) vector_Vec4i_new2(size_t size)
{
    return new std::vector<cv::Vec4i>(size);
}
CVAPI(std::vector<cv::Vec4i>*) vector_Vec4i_new3(cv::Vec4i* data, size_t dataLength)
{
    return new std::vector<cv::Vec4i>(data, data + dataLength);
}
CVAPI(size_t) vector_Vec4i_getSize(std::vector<cv::Vec4i>* vector)
{
    return vector->size();
}
CVAPI(cv::Vec4i*) vector_Vec4i_getPointer(std::vector<cv::Vec4i>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Vec4i_delete(std::vector<cv::Vec4i>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Vec6f
CVAPI(std::vector<cv::Vec6f>*) vector_Vec6f_new1()
{
    return new std::vector<cv::Vec6f>;
}
CVAPI(std::vector<cv::Vec6f>*) vector_Vec6f_new2(size_t size)
{
    return new std::vector<cv::Vec6f>(size);
}
CVAPI(std::vector<cv::Vec6f>*) vector_Vec6f_new3(cv::Vec6f* data, size_t dataLength)
{
    return new std::vector<cv::Vec6f>(data, data + dataLength);;
}
CVAPI(size_t) vector_Vec6f_getSize(std::vector<cv::Vec6f>* vector)
{
    return vector->size();
}
CVAPI(cv::Vec6f*) vector_Vec6f_getPointer(std::vector<cv::Vec6f>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Vec6f_delete(std::vector<cv::Vec6f>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Vec6d
CVAPI(std::vector<cv::Vec6d>*) vector_Vec6d_new1()
{
    return new std::vector<cv::Vec6d>;
}
CVAPI(std::vector<cv::Vec6d>*) vector_Vec6d_new2(size_t size)
{
    return new std::vector<cv::Vec6d>(size);
}
CVAPI(std::vector<cv::Vec6d>*) vector_Vec6d_new3(cv::Vec6d* data, size_t dataLength)
{
    return new std::vector<cv::Vec6d>(data, data + dataLength);
}
CVAPI(size_t) vector_Vec6d_getSize(std::vector<cv::Vec6d>* vector)
{
    return vector->size();
}
CVAPI(cv::Vec6d*) vector_Vec6d_getPointer(std::vector<cv::Vec6d>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Vec6d_delete(std::vector<cv::Vec6d>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Point2i
CVAPI(std::vector<cv::Point>*) vector_Point2i_new1()
{
    return new std::vector<cv::Point>;
}
CVAPI(std::vector<cv::Point>*) vector_Point2i_new2(size_t size)
{
    return new std::vector<cv::Point>(size);
}
CVAPI(std::vector<cv::Point>*) vector_Point2i_new3(cv::Point* data, size_t dataLength)
{
    return new std::vector<cv::Point>(data, data + dataLength);
}
CVAPI(size_t) vector_Point2i_getSize(std::vector<cv::Point>* vector)
{
    return vector->size();
}
CVAPI(cv::Point*) vector_Point2i_getPointer(std::vector<cv::Point>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Point2i_delete(std::vector<cv::Point>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Point2f
CVAPI(std::vector<cv::Point2f>*) vector_Point2f_new1()
{
    return new std::vector<cv::Point2f>;
}
CVAPI(std::vector<cv::Point2f>*) vector_Point2f_new2(size_t size)
{
    return new std::vector<cv::Point2f>(size);
}
CVAPI(std::vector<cv::Point2f>*) vector_Point2f_new3(cv::Point2f* data, size_t dataLength)
{
    return new std::vector<cv::Point2f>(data, data + dataLength);
}
CVAPI(size_t) vector_Point2f_getSize(std::vector<cv::Point2f>* vector)
{
    return vector->size();
}
CVAPI(cv::Point2f*) vector_Point2f_getPointer(std::vector<cv::Point2f>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Point2f_delete(std::vector<cv::Point2f>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Point2d
CVAPI(std::vector<cv::Point2d>*) vector_Point2d_new1()
{
    return new std::vector<cv::Point2d>;
}
CVAPI(std::vector<cv::Point2d>*) vector_Point2d_new2(size_t size)
{
    return new std::vector<cv::Point2d>(size);
}
CVAPI(std::vector<cv::Point2d>*) vector_Point2d_new3(cv::Point2d* data, size_t dataLength)
{
    return new std::vector<cv::Point2d>(data, data + dataLength);
}
CVAPI(size_t) vector_Point2d_getSize(std::vector<cv::Point2d>* vector)
{
    return vector->size();
}
CVAPI(cv::Point2d*) vector_Point2d_getPointer(std::vector<cv::Point2d>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Point2d_delete(std::vector<cv::Point2d>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Point3f
CVAPI(std::vector<cv::Point3f>*) vector_Point3f_new1()
{
    return new std::vector<cv::Point3f>;
}
CVAPI(std::vector<cv::Point3f>*) vector_Point3f_new2(size_t size)
{
    return new std::vector<cv::Point3f>(size);
}
CVAPI(std::vector<cv::Point3f>*) vector_Point3f_new3(cv::Point3f* data, size_t dataLength)
{
    return new std::vector<cv::Point3f>(data, data + dataLength);
}
CVAPI(size_t) vector_Point3f_getSize(std::vector<cv::Point3f>* vector)
{
    return vector->size();
}
CVAPI(cv::Point3f*) vector_Point3f_getPointer(std::vector<cv::Point3f>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Point3f_delete(std::vector<cv::Point3f>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Rect
CVAPI(std::vector<cv::Rect>*) vector_Rect_new1()
{
    return new std::vector<cv::Rect>;
}
CVAPI(std::vector<cv::Rect>*) vector_Rect_new2(size_t size)
{
    return new std::vector<cv::Rect>(size);
}
CVAPI(std::vector<cv::Rect>*) vector_Rect_new3(cv::Rect* data, size_t dataLength)
{
    return new std::vector<cv::Rect>(data, data + dataLength);
}
CVAPI(size_t) vector_Rect_getSize(std::vector<cv::Rect>* vector)
{
    return vector->size();
}
CVAPI(cv::Rect*) vector_Rect_getPointer(std::vector<cv::Rect> *vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Rect_delete(std::vector<cv::Rect> *vector)
{    
    //vector->~vector();
    delete vector;
}

#pragma endregion

#pragma region cv::Rect2d
CVAPI(std::vector<cv::Rect2d>*) vector_Rect2d_new1()
{
    return new std::vector<cv::Rect2d>;
}
CVAPI(std::vector<cv::Rect2d>*) vector_Rect2d_new2(size_t size)
{
    return new std::vector<cv::Rect2d>(size);
}
CVAPI(std::vector<cv::Rect2d>*) vector_Rect2d_new3(cv::Rect2d* data, size_t dataLength)
{
    return new std::vector<cv::Rect2d>(data, data + dataLength);
}
CVAPI(size_t) vector_Rect2d_getSize(std::vector<cv::Rect2d>* vector)
{
    return vector->size();
}
CVAPI(cv::Rect2d*) vector_Rect2d_getPointer(std::vector<cv::Rect2d> *vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Rect2d_delete(std::vector<cv::Rect2d> *vector)
{
    delete vector;
}

#pragma endregion

#pragma region cv::RotatedRect
CVAPI(std::vector<cv::RotatedRect>*) vector_RotatedRect_new1()
{
    return new std::vector<cv::RotatedRect>;
}
CVAPI(std::vector<cv::RotatedRect>*) vector_RotatedRect_new2(size_t size)
{
    return new std::vector<cv::RotatedRect>(size);
}
CVAPI(std::vector<cv::RotatedRect>*) vector_RotatedRect_new3(cv::RotatedRect* data, size_t dataLength)
{
    return new std::vector<cv::RotatedRect>(data, data + dataLength);
}
CVAPI(size_t) vector_RotatedRect_getSize(std::vector<cv::RotatedRect>* vector)
{
    return vector->size();
}
CVAPI(cv::RotatedRect*) vector_RotatedRect_getPointer(std::vector<cv::RotatedRect> *vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_RotatedRect_delete(std::vector<cv::RotatedRect> *vector)
{
    delete vector;
}

#pragma endregion

#pragma region cv::KeyPoint
CVAPI(std::vector<cv::KeyPoint>*) vector_KeyPoint_new1()
{
    return new std::vector<cv::KeyPoint>;
}
CVAPI(std::vector<cv::KeyPoint>*) vector_KeyPoint_new2(size_t size)
{
    return new std::vector<cv::KeyPoint>(size);
}
CVAPI(std::vector<cv::KeyPoint>*) vector_KeyPoint_new3(cv::KeyPoint *data, size_t dataLength)
{
    return new std::vector<cv::KeyPoint>(data, data + dataLength);
}
CVAPI(size_t) vector_KeyPoint_getSize(std::vector<cv::KeyPoint>* vector)
{
    return vector->size();
}
CVAPI(cv::KeyPoint*) vector_KeyPoint_getPointer(std::vector<cv::KeyPoint>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_KeyPoint_delete(std::vector<cv::KeyPoint>* vector)
{    
    //vector->~vector();
    delete vector;
}
#pragma endregion

#pragma region cv::DMatch
CVAPI(std::vector<cv::DMatch>*) vector_DMatch_new1()
{
    return new std::vector<cv::DMatch>;
}
CVAPI(std::vector<cv::DMatch>*) vector_DMatch_new2(size_t size)
{
    return new std::vector<cv::DMatch>(size);
}
CVAPI(std::vector<cv::DMatch>*) vector_DMatch_new3(cv::DMatch *data, size_t dataLength)
{
    return new std::vector<cv::DMatch>(data, data + dataLength);
}
CVAPI(size_t) vector_DMatch_getSize(std::vector<cv::DMatch>* vector)
{
    return vector->size();
}
CVAPI(cv::DMatch*) vector_DMatch_getPointer(std::vector<cv::DMatch>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_DMatch_delete(std::vector<cv::DMatch>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region vector<int>
CVAPI(std::vector<std::vector<int> >*) vector_vector_int_new1()
{
    return new std::vector<std::vector<int> >;
}
CVAPI(std::vector<std::vector<int> >*) vector_vector_int_new2(size_t size)
{
    return new std::vector<std::vector<int> >(size);
}
CVAPI(size_t) vector_vector_int_getSize1(std::vector<std::vector<int> >* vec)
{
    return vec->size();
}
CVAPI(void) vector_vector_int_getSize2(std::vector<std::vector<int> >* vec, size_t *sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}
CVAPI(void) vector_vector_int_copy(std::vector<std::vector<int> > *vec, int **dst)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        std::vector<int> &elem = vec->at(i);
        void *src = &elem[0];
        size_t length = sizeof(int) * elem.size();
        memcpy(dst[i], src, length);
    }
}
CVAPI(void) vector_vector_int_delete(std::vector<std::vector<int> >* vec)
{
    delete vec;
}
#pragma endregion

#pragma region vector<float>
CVAPI(std::vector<std::vector<float> >*) vector_vector_float_new1()
{
    return new std::vector<std::vector<float> >;
}
CVAPI(std::vector<std::vector<float> >*) vector_vector_float_new2(size_t size)
{
    return new std::vector<std::vector<float> >(size);
}
CVAPI(size_t) vector_vector_float_getSize1(std::vector<std::vector<float> >* vec)
{
    return vec->size();
}
CVAPI(void) vector_vector_float_getSize2(std::vector<std::vector<float> >* vec, size_t *sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}
CVAPI(void) vector_vector_float_copy(std::vector<std::vector<float> > *vec, float **dst)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        std::vector<float> &elem = vec->at(i);
        void *src = &elem[0];
        const size_t length = sizeof(float) * elem.size();
        memcpy(dst[i], src, length);
    }
}
CVAPI(void) vector_vector_float_delete(std::vector<std::vector<float> >* vec)
{
    delete vec;
}
#pragma endregion

#pragma region vector<double>
CVAPI(std::vector<std::vector<double> >*) vector_vector_double_new1()
{
    return new std::vector<std::vector<double> >;
}
CVAPI(std::vector<std::vector<double> >*) vector_vector_double_new2(size_t size)
{
    return new std::vector<std::vector<double> >(size);
}
CVAPI(size_t) vector_vector_double_getSize1(std::vector<std::vector<double> >* vec)
{
    return vec->size();
}
CVAPI(void) vector_vector_double_getSize2(std::vector<std::vector<double> >* vec, size_t *sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}
CVAPI(void) vector_vector_double_copy(std::vector<std::vector<double> > *vec, double **dst)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        std::vector<double> &elem = vec->at(i);
        void *src = &elem[0];
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
CVAPI(std::vector<std::vector<cv::KeyPoint> >*) vector_vector_KeyPoint_new2(size_t size)
{
    return new std::vector<std::vector<cv::KeyPoint> >(size);
}
CVAPI(std::vector<std::vector<cv::KeyPoint> >*) vector_vector_KeyPoint_new3(
    cv::KeyPoint **values, int size1, int *size2)
{
    std::vector<std::vector<cv::KeyPoint> > *vec = new std::vector<std::vector<cv::KeyPoint> >(size1);
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
CVAPI(void) vector_vector_KeyPoint_getSize2(std::vector<std::vector<cv::KeyPoint> >* vec, size_t *sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}
CVAPI(void) vector_vector_KeyPoint_copy(std::vector<std::vector<cv::KeyPoint> > *vec, cv::KeyPoint **dst)
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
CVAPI(std::vector<std::vector<cv::DMatch> >*) vector_vector_DMatch_new2(size_t size)
{
    return new std::vector<std::vector<cv::DMatch> >(size);
}
CVAPI(size_t) vector_vector_DMatch_getSize1(std::vector<std::vector<cv::DMatch> >* vec)
{
    return vec->size();
}
CVAPI(void) vector_vector_DMatch_getSize2(std::vector<std::vector<cv::DMatch> >* vec, size_t *sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}
CVAPI(void) vector_vector_DMatch_copy(std::vector<std::vector<cv::DMatch> > *vec, cv::DMatch **dst)
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
CVAPI(void) vector_vector_Point_getSize2(std::vector<std::vector<cv::Point> >* vec, size_t *sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}
CVAPI(void) vector_vector_Point_copy(std::vector<std::vector<cv::Point> > *vec, cv::Point **dst)
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
CVAPI(std::vector<std::vector<cv::Point2f> >*) vector_vector_Point2f_new2(size_t size)
{
    return new std::vector<std::vector<cv::Point2f> >(size);
}
CVAPI(size_t) vector_vector_Point2f_getSize1(std::vector<std::vector<cv::Point2f> >* vec)
{
    return vec->size();
}
CVAPI(void) vector_vector_Point2f_getSize2(std::vector<std::vector<cv::Point2f> >* vec, size_t *sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}
CVAPI(void) vector_vector_Point2f_copy(std::vector<std::vector<cv::Point2f> > *vec, cv::Point2f **dst)
{
    copyFromVectorToArray(vec, dst);
}
CVAPI(void) vector_vector_Point2f_delete(std::vector<std::vector<cv::Point2f> >* vec)
{
    delete vec;
}

#pragma endregion

#pragma region std::string
CVAPI(std::vector<std::string>*) vector_string_new1()
{
    return new std::vector<std::string>;
}
CVAPI(std::vector<std::string>*) vector_string_new2(size_t size)
{
    return new std::vector<std::string>(size);
}
CVAPI(size_t) vector_string_getSize(std::vector<std::string> *vec)
{
    return vec->size();
}
CVAPI(void) vector_string_getElements(std::vector<std::string> *vector, const char **cStringPointers, int32_t *stringLengths)
{
    for (size_t i = 0; i < vector->size(); i++)
    {
        const auto& elem = vector->at(i);
        cStringPointers[i] = elem.c_str();
        stringLengths[i] = static_cast<int32_t>(elem.size());
    }
}
CVAPI(void) vector_string_delete(std::vector<std::string> *vector)
{    
    delete vector;
}
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
    const auto vec = new std::vector<cv::Mat>(dataLength);
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
CVAPI(void) vector_Mat_addref(std::vector<cv::Mat>* vector)
{
    for (auto m = vector->begin(); m != vector->end(); ++m)
    {
        m->addref();
    }
}
CVAPI(void) vector_Mat_delete(std::vector<cv::Mat>* vector)
{
    //vector->~vector();
    delete vector;
}
#pragma endregion

#pragma region cv::ml::DTrees::Node
CVAPI(std::vector<cv::ml::DTrees::Node>*) vector_DTrees_Node_new1()
{
    return new std::vector<cv::ml::DTrees::Node>;
}
CVAPI(std::vector<cv::ml::DTrees::Node>*) vector_DTrees_Node_new2(size_t size)
{
    return new std::vector<cv::ml::DTrees::Node>(size);
}
CVAPI(std::vector<cv::ml::DTrees::Node>*) vector_DTrees_Node_new3(cv::ml::DTrees::Node *data, size_t dataLength)
{
    return new std::vector<cv::ml::DTrees::Node>(data, data + dataLength);
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
CVAPI(std::vector<cv::ml::DTrees::Split>*) vector_DTrees_Split_new2(size_t size)
{
    return new std::vector<cv::ml::DTrees::Split>(size);
}
CVAPI(std::vector<cv::ml::DTrees::Split>*) vector_DTrees_Split_new3(cv::ml::DTrees::Split *data, size_t dataLength)
{
    return new std::vector<cv::ml::DTrees::Split>(data, data + dataLength);
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

#endif