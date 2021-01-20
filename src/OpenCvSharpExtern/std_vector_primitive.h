#pragma once

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


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
CVAPI(void) vector_uchar_copy(std::vector<uchar>* vector, uchar* dst)
{
    const size_t length = sizeof(uchar) * vector->size();
    memcpy(dst, &(vector->at(0)), length);
}
CVAPI(void) vector_uchar_delete(std::vector<uchar>* vector)
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
