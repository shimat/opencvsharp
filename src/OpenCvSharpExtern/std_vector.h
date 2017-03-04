#ifndef _CPP_WVECTOR_H_
#define _CPP_WVECTOR_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

using namespace std;

#pragma region uchar
CVAPI(vector<uchar>*) vector_uchar_new1()
{
    return new vector<uchar>;
}
CVAPI(vector<uchar>*) vector_uchar_new2(size_t size)
{
    return new vector<uchar>(size);
}
CVAPI(vector<uchar>*) vector_uchar_new3(uchar* data, size_t dataLength)
{
    return new vector<uchar>(data, data + dataLength);
}
CVAPI(size_t) vector_uchar_getSize(vector<uchar>* vector)
{
    return vector->size();
}
CVAPI(uchar*) vector_uchar_getPointer(vector<uchar>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_vector_uchar_copy(vector<uchar> *vector, uchar *dst)
{
    size_t length = sizeof(uchar)* vector->size();
    memcpy(dst, &(vector->at(0)), length);
}
CVAPI(void) vector_uchar_delete(vector<uchar>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region char
CVAPI(vector<char>*) vector_char_new1()
{
    return new vector<char>;
}
CVAPI(vector<char>*) vector_char_new2(size_t size)
{
    return new vector<char>(size);
}
CVAPI(vector<char>*) vector_char_new3(char* data, size_t dataLength)
{
    return new vector<char>(data, data + dataLength);
}
CVAPI(size_t) vector_char_getSize(vector<char>* vector)
{
    return vector->size();
}
CVAPI(char*) vector_char_getPointer(vector<char>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_vector_char_copy(vector<char> *vector, char *dst)
{
    size_t length = sizeof(char)* vector->size();
    memcpy(dst, &(vector->at(0)), length);
}
CVAPI(void) vector_char_delete(vector<char>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region int
CVAPI(vector<int>*) vector_int32_new1()
{
    return new vector<int>;
}
CVAPI(vector<int>*) vector_int32_new2(size_t size)
{
    return new vector<int>(size);
}
CVAPI(vector<int>*) vector_int32_new3(int* data, size_t dataLength)
{
    return new vector<int>(data, data + dataLength);
}
CVAPI(size_t) vector_int32_getSize(vector<int>* vector)
{
    return vector->size();
}
CVAPI(int*) vector_int32_getPointer(vector<int>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_int32_delete(vector<int>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region float
CVAPI(vector<float>*) vector_float_new1()
{
    return new vector<float>;
}
CVAPI(vector<float>*) vector_float_new2(size_t size)
{
    return new vector<float>(size);
}
CVAPI(vector<float>*) vector_float_new3(float* data, size_t dataLength)
{
    return new vector<float>(data, data + dataLength);
}
CVAPI(size_t) vector_float_getSize(vector<float>* vector)
{
    return vector->size();
}
CVAPI(float*) vector_float_getPointer(vector<float>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_float_delete(vector<float>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region double
CVAPI(vector<double>*) vector_double_new1()
{
    return new vector<double>;
}
CVAPI(vector<double>*) vector_double_new2(size_t size)
{
    return new vector<double>(size);
}
CVAPI(vector<double>*) vector_double_new3(float* data, size_t dataLength)
{
    return new vector<double>(data, data + dataLength);
}
CVAPI(size_t) vector_double_getSize(vector<double>* vector)
{
    return vector->size();
}
CVAPI(double*) vector_double_getPointer(vector<double>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_double_delete(vector<double>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Vec2f
CVAPI(vector<cv::Vec2f>*) vector_Vec2f_new1()
{
    return new vector<cv::Vec2f>;
}
CVAPI(vector<cv::Vec2f>*) vector_Vec2f_new2(size_t size)
{
    return new vector<cv::Vec2f>(size);
}
CVAPI(vector<cv::Vec2f>*) vector_Vec2f_new3(cv::Vec2f* data, size_t dataLength)
{
    return new vector<cv::Vec2f>(data, data + dataLength);
}
CVAPI(size_t) vector_Vec2f_getSize(vector<cv::Vec2f>* vector)
{
    return vector->size();
}
CVAPI(cv::Vec2f*) vector_Vec2f_getPointer(vector<cv::Vec2f>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Vec2f_delete(vector<cv::Vec2f>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Vec3f
CVAPI(vector<cv::Vec3f>*) vector_Vec3f_new1()
{
    return new vector<cv::Vec3f>;
}
CVAPI(vector<cv::Vec3f>*) vector_Vec3f_new2(size_t size)
{
    return new vector<cv::Vec3f>(size);
}
CVAPI(vector<cv::Vec3f>*) vector_Vec3f_new3(cv::Vec3f* data, size_t dataLength)
{
    return new vector<cv::Vec3f>(data, data + dataLength);
}
CVAPI(size_t) vector_Vec3f_getSize(vector<cv::Vec3f>* vector)
{
    return vector->size();
}
CVAPI(cv::Vec3f*) vector_Vec3f_getPointer(vector<cv::Vec3f>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Vec3f_delete(vector<cv::Vec3f>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Vec4f
CVAPI(vector<cv::Vec4f>*) vector_Vec4f_new1()
{
    return new vector<cv::Vec4f>;
}
CVAPI(vector<cv::Vec4f>*) vector_Vec4f_new2(size_t size)
{
    return new vector<cv::Vec4f>(size);
}
CVAPI(vector<cv::Vec4f>*) vector_Vec4f_new3(cv::Vec4f* data, size_t dataLength)
{
    return new vector<cv::Vec4f>(data, data + dataLength);
}
CVAPI(size_t) vector_Vec4f_getSize(vector<cv::Vec4f>* vector)
{
    return vector->size();
}
CVAPI(cv::Vec4f*) vector_Vec4f_getPointer(vector<cv::Vec4f>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Vec4f_delete(vector<cv::Vec4f>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Vec4i
CVAPI(vector<cv::Vec4i>*) vector_Vec4i_new1()
{
    return new vector<cv::Vec4i>;
}
CVAPI(vector<cv::Vec4i>*) vector_Vec4i_new2(size_t size)
{
    return new vector<cv::Vec4i>(size);
}
CVAPI(vector<cv::Vec4i>*) vector_Vec4i_new3(cv::Vec4i* data, size_t dataLength)
{
    return new vector<cv::Vec4i>(data, data + dataLength);
}
CVAPI(size_t) vector_Vec4i_getSize(vector<cv::Vec4i>* vector)
{
    return vector->size();
}
CVAPI(cv::Vec4i*) vector_Vec4i_getPointer(vector<cv::Vec4i>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Vec4i_delete(vector<cv::Vec4i>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Vec6f
CVAPI(vector<cv::Vec6f>*) vector_Vec6f_new1()
{
    return new vector<cv::Vec6f>;
}
CVAPI(vector<cv::Vec6f>*) vector_Vec6f_new2(size_t size)
{
    return new vector<cv::Vec6f>(size);
}
CVAPI(vector<cv::Vec6f>*) vector_Vec6f_new3(cv::Vec6f* data, size_t dataLength)
{
    return new vector<cv::Vec6f>(data, data + dataLength);;
}
CVAPI(size_t) vector_Vec6f_getSize(vector<cv::Vec6f>* vector)
{
    return vector->size();
}
CVAPI(cv::Vec6f*) vector_Vec6f_getPointer(vector<cv::Vec6f>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Vec6f_delete(vector<cv::Vec6f>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Vec6d
CVAPI(vector<cv::Vec6d>*) vector_Vec6d_new1()
{
    return new vector<cv::Vec6d>;
}
CVAPI(vector<cv::Vec6d>*) vector_Vec6d_new2(size_t size)
{
    return new vector<cv::Vec6d>(size);
}
CVAPI(vector<cv::Vec6d>*) vector_Vec6d_new3(cv::Vec6d* data, size_t dataLength)
{
    return new vector<cv::Vec6d>(data, data + dataLength);
}
CVAPI(size_t) vector_Vec6d_getSize(vector<cv::Vec6d>* vector)
{
    return vector->size();
}
CVAPI(cv::Vec6d*) vector_Vec6d_getPointer(vector<cv::Vec6d>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Vec6d_delete(vector<cv::Vec6d>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Point2i
CVAPI(vector<cv::Point>*) vector_Point2i_new1()
{
    return new vector<cv::Point>;
}
CVAPI(vector<cv::Point>*) vector_Point2i_new2(size_t size)
{
    return new vector<cv::Point>(size);
}
CVAPI(vector<cv::Point>*) vector_Point2i_new3(cv::Point* data, size_t dataLength)
{
    return new vector<cv::Point>(data, data + dataLength);
}
CVAPI(size_t) vector_Point2i_getSize(vector<cv::Point>* vector)
{
    return vector->size();
}
CVAPI(cv::Point*) vector_Point2i_getPointer(vector<cv::Point>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Point2i_delete(vector<cv::Point>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Point2f
CVAPI(vector<cv::Point2f>*) vector_Point2f_new1()
{
    return new vector<cv::Point2f>;
}
CVAPI(vector<cv::Point2f>*) vector_Point2f_new2(size_t size)
{
    return new vector<cv::Point2f>(size);
}
CVAPI(vector<cv::Point2f>*) vector_Point2f_new3(cv::Point2f* data, size_t dataLength)
{
    return new vector<cv::Point2f>(data, data + dataLength);
}
CVAPI(size_t) vector_Point2f_getSize(vector<cv::Point2f>* vector)
{
    return vector->size();
}
CVAPI(cv::Point2f*) vector_Point2f_getPointer(vector<cv::Point2f>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Point2f_delete(vector<cv::Point2f>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Point3f
CVAPI(vector<cv::Point3f>*) vector_Point3f_new1()
{
    return new vector<cv::Point3f>;
}
CVAPI(vector<cv::Point3f>*) vector_Point3f_new2(size_t size)
{
    return new vector<cv::Point3f>(size);
}
CVAPI(vector<cv::Point3f>*) vector_Point3f_new3(cv::Point3f* data, size_t dataLength)
{
    return new vector<cv::Point3f>(data, data + dataLength);
}
CVAPI(size_t) vector_Point3f_getSize(vector<cv::Point3f>* vector)
{
    return vector->size();
}
CVAPI(cv::Point3f*) vector_Point3f_getPointer(vector<cv::Point3f>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Point3f_delete(vector<cv::Point3f>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::Rect
CVAPI(vector<cv::Rect>*) vector_Rect_new1()
{
    return new vector<cv::Rect>;
}
CVAPI(vector<cv::Rect>*) vector_Rect_new2(size_t size)
{
    return new vector<cv::Rect>(size);
}
CVAPI(vector<cv::Rect>*) vector_Rect_new3(cv::Rect* data, size_t dataLength)
{
    return new vector<cv::Rect>(data, data + dataLength);
}
CVAPI(size_t) vector_Rect_getSize(vector<cv::Rect>* vector)
{
    return vector->size();
}
CVAPI(cv::Rect*) vector_Rect_getPointer(vector<cv::Rect> *vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Rect_delete(vector<cv::Rect> *vector)
{    
    //vector->~vector();
    delete vector;
}

#pragma endregion

#pragma region cv::KeyPoint
CVAPI(vector<cv::KeyPoint>*) vector_KeyPoint_new1()
{
    return new vector<cv::KeyPoint>;
}
CVAPI(vector<cv::KeyPoint>*) vector_KeyPoint_new2(size_t size)
{
    return new vector<cv::KeyPoint>(size);
}
CVAPI(vector<cv::KeyPoint>*) vector_KeyPoint_new3(cv::KeyPoint *data, size_t dataLength)
{
    return new vector<cv::KeyPoint>(data, data + dataLength);
}
CVAPI(size_t) vector_KeyPoint_getSize(vector<cv::KeyPoint>* vector)
{
    return vector->size();
}
CVAPI(cv::KeyPoint*) vector_KeyPoint_getPointer(vector<cv::KeyPoint>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_KeyPoint_delete(vector<cv::KeyPoint>* vector)
{    
    //vector->~vector();
    delete vector;
}
#pragma endregion

#pragma region cv::DMatch
CVAPI(vector<cv::DMatch>*) vector_DMatch_new1()
{
    return new vector<cv::DMatch>;
}
CVAPI(vector<cv::DMatch>*) vector_DMatch_new2(size_t size)
{
    return new vector<cv::DMatch>(size);
}
CVAPI(vector<cv::DMatch>*) vector_DMatch_new3(cv::DMatch *data, size_t dataLength)
{
    return new vector<cv::DMatch>(data, data + dataLength);
}
CVAPI(size_t) vector_DMatch_getSize(vector<cv::DMatch>* vector)
{
    return vector->size();
}
CVAPI(cv::DMatch*) vector_DMatch_getPointer(vector<cv::DMatch>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_DMatch_delete(vector<cv::DMatch>* vector)
{
    delete vector;
}
#pragma endregion

#pragma region vector<int>
CVAPI(vector<vector<int> >*) vector_vector_int_new1()
{
    return new vector<vector<int> >;
}
CVAPI(vector<vector<int> >*) vector_vector_int_new2(size_t size)
{
    return new vector<vector<int> >(size);
}
CVAPI(size_t) vector_vector_int_getSize1(vector<vector<int> >* vec)
{
    return vec->size();
}
CVAPI(void) vector_vector_int_getSize2(vector<vector<int> >* vec, size_t *sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}
CVAPI(vector<int>*) vector_vector_int_getPointer(vector<vector<int> >* vec)
{
    return &(vec->at(0));
}
CVAPI(void) vector_vector_int_copy(vector<vector<int> > *vec, int **dst)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        vector<int> &elem = vec->at(i);
        void *src = &elem[0];
        size_t length = sizeof(int) * elem.size();
        memcpy(dst[i], src, length);
    }
}
CVAPI(void) vector_vector_int_delete(vector<vector<int> >* vec)
{
    delete vec;
}
#pragma endregion

#pragma region vector<float>
CVAPI(vector<vector<float> >*) vector_vector_float_new1()
{
    return new vector<vector<float> >;
}
CVAPI(vector<vector<float> >*) vector_vector_float_new2(size_t size)
{
    return new vector<vector<float> >(size);
}
CVAPI(size_t) vector_vector_float_getSize1(vector<vector<float> >* vec)
{
    return vec->size();
}
CVAPI(void) vector_vector_float_getSize2(vector<vector<float> >* vec, size_t *sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}
CVAPI(vector<float>*) vector_vector_float_getPointer(vector<vector<float> >* vec)
{
    return &(vec->at(0));
}
CVAPI(void) vector_vector_float_copy(vector<vector<float> > *vec, float **dst)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        vector<float> &elem = vec->at(i);
        void *src = &elem[0];
        size_t length = sizeof(float) * elem.size();
        memcpy(dst[i], src, length);
    }
}
CVAPI(void) vector_vector_float_delete(vector<vector<float> >* vec)
{
    delete vec;
}
#pragma endregion

#pragma region vector<double>
CVAPI(vector<vector<double> >*) vector_vector_double_new1()
{
    return new vector<vector<double> >;
}
CVAPI(vector<vector<double> >*) vector_vector_double_new2(size_t size)
{
    return new vector<vector<double> >(size);
}
CVAPI(size_t) vector_vector_double_getSize1(vector<vector<double> >* vec)
{
    return vec->size();
}
CVAPI(void) vector_vector_double_getSize2(vector<vector<double> >* vec, size_t *sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}
CVAPI(vector<double>*) vector_vector_double_getPointer(vector<vector<double> >* vec)
{
    return &(vec->at(0));
}
CVAPI(void) vector_vector_double_copy(vector<vector<double> > *vec, double **dst)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        vector<double> &elem = vec->at(i);
        void *src = &elem[0];
        size_t length = sizeof(double) * elem.size();
        memcpy(dst[i], src, length);
    }
}
CVAPI(void) vector_vector_double_delete(vector<vector<double> >* vec)
{
    delete vec;
}
#pragma endregion

#pragma region vector<cv::KeyPoint>
CVAPI(vector<vector<cv::KeyPoint> >*) vector_vector_KeyPoint_new1()
{
    return new vector<vector<cv::KeyPoint> >;
}
CVAPI(vector<vector<cv::KeyPoint> >*) vector_vector_KeyPoint_new2(size_t size)
{
    return new vector<vector<cv::KeyPoint> >(size);
}
CVAPI(vector<vector<cv::KeyPoint> >*) vector_vector_KeyPoint_new3(
    cv::KeyPoint **values, int size1, int *size2)
{
    vector<vector<cv::KeyPoint> > *vec = new std::vector<vector<cv::KeyPoint> >(size1);
    for (int i = 0; i < size1; i++)
    {
        vec->at(i) = std::vector<cv::KeyPoint>(values[i], values[i] + size2[i]);
    }
    return vec;
}

CVAPI(size_t) vector_vector_KeyPoint_getSize1(vector<vector<cv::KeyPoint> >* vec)
{
    return vec->size();
}
CVAPI(void) vector_vector_KeyPoint_getSize2(vector<vector<cv::KeyPoint> >* vec, size_t *sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}
CVAPI(vector<cv::KeyPoint>*) vector_vector_KeyPoint_getPointer(vector<vector<cv::KeyPoint> >* vec)
{
    return &(vec->at(0));
}
CVAPI(void) vector_vector_KeyPoint_copy(vector<vector<cv::KeyPoint> > *vec, cv::KeyPoint **dst)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        vector<cv::KeyPoint> &elem = vec->at(i);
        void *src = &elem[0];
        size_t length = sizeof(cv::KeyPoint) * elem.size();
        memcpy(dst[i], src, length);
    }
}
CVAPI(void) vector_vector_KeyPoint_delete(vector<vector<cv::KeyPoint> >* vec)
{
    delete vec;
}
#pragma endregion

#pragma region vector<cv::DMatch>
CVAPI(vector<vector<cv::DMatch> >*) vector_vector_DMatch_new1()
{
    return new vector<vector<cv::DMatch> >;
}
CVAPI(vector<vector<cv::DMatch> >*) vector_vector_DMatch_new2(size_t size)
{
    return new vector<vector<cv::DMatch> >(size);
}
CVAPI(size_t) vector_vector_DMatch_getSize1(vector<vector<cv::DMatch> >* vec)
{
    return vec->size();
}
CVAPI(void) vector_vector_DMatch_getSize2(vector<vector<cv::DMatch> >* vec, size_t *sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}
CVAPI(vector<cv::DMatch>*) vector_vector_DMatch_getPointer(vector<vector<cv::DMatch> >* vec)
{
    return &(vec->at(0));
}
CVAPI(void) vector_vector_DMatch_copy(vector<vector<cv::DMatch> > *vec, cv::DMatch **dst)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        vector<cv::DMatch> &elem = vec->at(i);
        void *src = &elem[0];
        size_t length = sizeof(cv::DMatch) * elem.size();
        memcpy(dst[i], src, length);
    }
}
CVAPI(void) vector_vector_DMatch_delete(vector<vector<cv::DMatch> >* vec)
{
    delete vec;
}
#pragma endregion

#pragma region vector<cv::Point>
CVAPI(vector<vector<cv::Point> >*) vector_vector_Point_new1()
{
    return new vector<vector<cv::Point> >;
}
CVAPI(vector<vector<cv::Point> >*) vector_vector_Point_new2(size_t size)
{
    return new vector<vector<cv::Point> >(size);
}
CVAPI(size_t) vector_vector_Point_getSize1(vector<vector<cv::Point> >* vec)
{
    return vec->size();
}
CVAPI(void) vector_vector_Point_getSize2(vector<vector<cv::Point> >* vec, size_t *sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}
CVAPI(vector<cv::Point>*) vector_vector_Point_getPointer(vector<vector<cv::Point> >* vec)
{
    return &(vec->at(0));
}
CVAPI(void) vector_vector_Point_copy(vector<vector<cv::Point> > *vec, cv::Point **dst)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        vector<cv::Point> &elem = vec->at(i);
        void *src = &elem[0];
        size_t length = sizeof(cv::Point) * elem.size();
        memcpy(dst[i], src, length);
    }
}
CVAPI(void) vector_vector_Point_delete(vector<vector<cv::Point> >* vec)
{
    delete vec;
}
#pragma endregion

#pragma region vector<cv::Point2f>
CVAPI(vector<vector<cv::Point2f> >*) vector_vector_Point2f_new1()
{
    return new vector<vector<cv::Point2f> >;
}
CVAPI(vector<vector<cv::Point2f> >*) vector_vector_Point2f_new2(size_t size)
{
    return new vector<vector<cv::Point2f> >(size);
}
CVAPI(size_t) vector_vector_Point2f_getSize1(vector<vector<cv::Point2f> >* vec)
{
    return vec->size();
}
CVAPI(void) vector_vector_Point2f_getSize2(vector<vector<cv::Point2f> >* vec, size_t *sizes)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        sizes[i] = vec->at(i).size();
    }
}
CVAPI(vector<cv::Point2f>*) vector_vector_Point2f_getPointer(vector<vector<cv::Point2f> >* vec)
{
    return &(vec->at(0));
}
CVAPI(void) vector_vector_Point2f_copy(vector<vector<cv::Point2f> > *vec, cv::Point2f **dst)
{
    for (size_t i = 0; i < vec->size(); i++)
    {
        vector<cv::Point2f> &elem = vec->at(i);
        void *src = &elem[0];
        size_t length = sizeof(cv::Point2f) * elem.size();
        memcpy(dst[i], src, length);
    }
}
CVAPI(void) vector_vector_Point2f_delete(vector<vector<cv::Point2f> >* vec)
{
    delete vec;
}
#pragma endregion

#pragma region std::string
CVAPI(vector<string>*) vector_string_new1()
{
    return new vector<string>;
}
CVAPI(vector<string>*) vector_string_new2(size_t size)
{
    return new vector<string>(size);
}
CVAPI(size_t) vector_string_getSize(vector<string> *vec)
{
    return vec->size();
}
CVAPI(string*) vector_string_getPointer(vector<string> *vector)
{
    return &(vector->at(0));
}
CVAPI(const char*) vector_string_elemAt(vector<string> *vector, int i)
{
    return vector->at(i).c_str();
}
CVAPI(void) vector_string_delete(vector<string> *vector)
{    
    delete vector;
}
#pragma endregion

#pragma region cv::Mat
CVAPI(vector<cv::Mat>*) vector_Mat_new1()
{
    return new vector<cv::Mat>;
}
CVAPI(vector<cv::Mat>*) vector_Mat_new2(size_t size)
{
    return new vector<cv::Mat>(size);
}
CVAPI(vector<cv::Mat>*) vector_Mat_new3(cv::Mat *data, size_t dataLength)
{
    vector<cv::Mat>* vec = new vector<cv::Mat>(dataLength);
    for (size_t i = 0; i<dataLength; i++)
    {
        vec->push_back(data[i]);
    }
    return vec;
}
CVAPI(size_t) vector_Mat_getSize(vector<cv::Mat>* vector)
{
    return vector->size();
}
CVAPI(cv::Mat*) vector_Mat_getPointer(vector<cv::Mat>* vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_Mat_assignToArray(vector<cv::Mat>* vector, cv::Mat** arr)
{
    for (size_t i = 0; i < vector->size(); i++)
    {
        (vector->at(i)).assignTo(*(arr[i]));
    }
}
CVAPI(void) vector_Mat_addref(vector<cv::Mat>* vector)
{
    for (std::vector<cv::Mat>::iterator m = vector->begin(); m != vector->end(); m++)
    {
        m->addref();
    }
}
CVAPI(void) vector_Mat_delete(vector<cv::Mat>* vector)
{
    //vector->~vector();
    delete vector;
}
#pragma endregion

#pragma region cv::ml::DTrees::Node
CVAPI(vector<cv::ml::DTrees::Node>*) vector_DTrees_Node_new1()
{
    return new vector<cv::ml::DTrees::Node>;
}
CVAPI(vector<cv::ml::DTrees::Node>*) vector_DTrees_Node_new2(size_t size)
{
    return new vector<cv::ml::DTrees::Node>(size);
}
CVAPI(vector<cv::ml::DTrees::Node>*) vector_DTrees_Node_new3(cv::ml::DTrees::Node *data, size_t dataLength)
{
    return new vector<cv::ml::DTrees::Node>(data, data + dataLength);
}
CVAPI(size_t) vector_DTrees_Node_getSize(vector<cv::ml::DTrees::Node> *vector)
{
    return vector->size();
}
CVAPI(cv::ml::DTrees::Node*) vector_DTrees_Node_getPointer(vector<cv::ml::DTrees::Node> *vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_DTrees_Node_delete(vector<cv::ml::DTrees::Node> *vector)
{
    delete vector;
}
#pragma endregion

#pragma region cv::ml::DTrees::Split
CVAPI(vector<cv::ml::DTrees::Split>*) vector_DTrees_Split_new1()
{
    return new vector<cv::ml::DTrees::Split>;
}
CVAPI(vector<cv::ml::DTrees::Split>*) vector_DTrees_Split_new2(size_t size)
{
    return new vector<cv::ml::DTrees::Split>(size);
}
CVAPI(vector<cv::ml::DTrees::Split>*) vector_DTrees_Split_new3(cv::ml::DTrees::Split *data, size_t dataLength)
{
    return new vector<cv::ml::DTrees::Split>(data, data + dataLength);
}
CVAPI(size_t) vector_DTrees_Split_getSize(vector<cv::ml::DTrees::Split> *vector)
{
    return vector->size();
}
CVAPI(cv::ml::DTrees::Split*) vector_DTrees_Split_getPointer(vector<cv::ml::DTrees::Split> *vector)
{
    return &(vector->at(0));
}
CVAPI(void) vector_DTrees_Split_delete(vector<cv::ml::DTrees::Split> *vector)
{
    delete vector;
}
#pragma endregion

#endif