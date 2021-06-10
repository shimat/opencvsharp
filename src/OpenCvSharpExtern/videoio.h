#pragma once

#include "include_opencv.h"

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile


#pragma region VideoCapture

CVAPI(ExceptionStatus) videoio_VideoCapture_new1(cv::VideoCapture **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::VideoCapture;
    END_WRAP
}
CVAPI(ExceptionStatus) videoio_VideoCapture_new2(const char *filename, int apiPreference, cv::VideoCapture **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::VideoCapture(filename, apiPreference);
    END_WRAP
}
CVAPI(ExceptionStatus) videoio_VideoCapture_new3(int device, int apiPreference, cv::VideoCapture **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::VideoCapture(device, apiPreference);
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoCapture_new4(const char* filename, int apiPreference, int* params, int paramsLength, cv::VideoCapture** returnValue)
{
    BEGIN_WRAP
        std::vector<int> paramsVec;
        paramsVec.assign(params, params + paramsLength);
        * returnValue = new cv::VideoCapture(filename, apiPreference, paramsVec);
    END_WRAP
}
CVAPI(ExceptionStatus) videoio_VideoCapture_new5(int device, int apiPreference, int* params, int paramsLength, cv::VideoCapture** returnValue)
{
    BEGIN_WRAP
        std::vector<int> paramsVec;
        paramsVec.assign(params, params + paramsLength);
        * returnValue = new cv::VideoCapture(device, apiPreference, paramsVec);
    END_WRAP
}


CVAPI(ExceptionStatus) videoio_VideoCapture_delete(cv::VideoCapture *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}


CVAPI(ExceptionStatus) videoio_VideoCapture_open1(cv::VideoCapture *obj, const char *filename, int apiPreference, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->open(filename, apiPreference) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoCapture_open2(cv::VideoCapture *obj, int device, int apiPreference, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->open(device, apiPreference) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoCapture_isOpened(cv::VideoCapture *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->isOpened() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoCapture_release(cv::VideoCapture *obj)
{
    BEGIN_WRAP
    obj->release();
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoCapture_grab(cv::VideoCapture *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->grab() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoCapture_retrieve_OutputArray(cv::VideoCapture *obj, cv::_OutputArray *image, int flag, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->retrieve(*image, flag) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoCapture_retrieve_Mat(cv::VideoCapture *obj, cv::Mat *image, int flag, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->retrieve(*image, flag) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoCapture_operatorRightShift_Mat(cv::VideoCapture *obj, cv::Mat *image)
{
    BEGIN_WRAP
    (*obj) >> (*image);
    END_WRAP
}
/*CVAPI(ExceptionStatus) videoio_VideoCapture_operatorRightShift_UMat(cv::VideoCapture *obj, cv::UMat *image)
{
    BEGIN_WRAP
    (*obj) >> (*image);
    END_WRAP
}*/

CVAPI(ExceptionStatus) videoio_VideoCapture_read_OutputArray(cv::VideoCapture *obj, cv::_OutputArray *image, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->read(*image) ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) videoio_VideoCapture_read_Mat(cv::VideoCapture *obj, cv::Mat *image, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->read(*image) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoCapture_set(cv::VideoCapture *obj, int propId, double value, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->set(propId, value) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoCapture_get(cv::VideoCapture *obj, int propId, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get(propId);
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoCapture_getBackendName(cv::VideoCapture *obj, std::string *returnValue)
{
    BEGIN_WRAP
    returnValue->assign(obj->getBackendName());
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoCapture_setExceptionMode(cv::VideoCapture *obj, int enable)
{
    BEGIN_WRAP
    obj->setExceptionMode(enable != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoCapture_getExceptionMode(cv::VideoCapture *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getExceptionMode() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoCapture_waitAny(
    cv::VideoCapture** streams, const size_t streamsSize,
    std::vector<int> *readyIndex, const int64 timeoutNs, int *returnValue)
{
    BEGIN_WRAP
    std::vector<cv::VideoCapture> streamsVec(streamsSize);
    for (size_t i = 0; i < streamsSize; i++)
        streamsVec[i] = *streams[i];

    *returnValue = cv::VideoCapture::waitAny(streamsVec, *readyIndex, timeoutNs) ? 1 : 0;
    END_WRAP
}

#pragma endregion

#pragma region VideoWriter

CVAPI(ExceptionStatus) videoio_VideoWriter_new1(cv::VideoWriter **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::VideoWriter;
    END_WRAP
}
CVAPI(ExceptionStatus) videoio_VideoWriter_new2(
    const char *filename, 
    int fourcc, double fps,
    MyCvSize frameSize, int isColor, 
    cv::VideoWriter **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::VideoWriter(filename, fourcc, fps, cpp(frameSize), isColor != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) videoio_VideoWriter_new3(
    const char *filename, int apiPreference, 
    int fourcc, double fps,
    MyCvSize frameSize, int isColor, 
    cv::VideoWriter **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::VideoWriter(filename, apiPreference, fourcc, fps, cpp(frameSize), isColor != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) videoio_VideoWriter_new4(
    const char* filename,
    int fourcc, double fps,
    MyCvSize frameSize, int* params, int paramsLength,
    cv::VideoWriter** returnValue)
{
    BEGIN_WRAP
        std::vector<int> paramsVec;
        paramsVec.assign(params, params + paramsLength);
        * returnValue = new cv::VideoWriter(filename, fourcc, fps, cpp(frameSize), paramsVec);
    END_WRAP
}
CVAPI(ExceptionStatus) videoio_VideoWriter_new5(
    const char* filename, int apiPreference,
    int fourcc, double fps,
    MyCvSize frameSize, int* params, int paramsLength,
    cv::VideoWriter** returnValue)
{
    BEGIN_WRAP
        std::vector<int> paramsVec;
        paramsVec.assign(params, params + paramsLength);
        * returnValue = new cv::VideoWriter(filename, apiPreference, fourcc, fps, cpp(frameSize), paramsVec);
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoWriter_delete(cv::VideoWriter *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoWriter_open1(
    cv::VideoWriter *obj, const char *filename, 
    int fourcc, double fps,
    MyCvSize frameSize, int isColor, 
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->open(filename, fourcc, fps, cpp(frameSize), isColor != 0) ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) videoio_VideoWriter_open2(
    cv::VideoWriter *obj, const char *filename, int apiPreference, 
    int fourcc, double fps,
    MyCvSize frameSize, int isColor, 
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->open(filename, apiPreference, fourcc, fps, cpp(frameSize), isColor != 0) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoWriter_isOpened(cv::VideoWriter *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->isOpened() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoWriter_release(cv::VideoWriter *obj)
{
    BEGIN_WRAP
    obj->release();
    END_WRAP
}

/*CVAPI(ExceptionStatus) videoio_VideoWriter_OperatorLeftShift(cv::VideoWriter *obj, cv::Mat *image)
{
    BEGIN_WRAP
    (*obj) << (*image);
    END_WRAP
}*/

CVAPI(ExceptionStatus) videoio_VideoWriter_write(cv::VideoWriter *obj, cv::_InputArray *image)
{
    BEGIN_WRAP
    obj->write(*image);
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoWriter_set(cv::VideoWriter *obj, int propId, double value, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->set(propId, value) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoWriter_get(cv::VideoWriter *obj, int propId, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get(propId);
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoWriter_fourcc(char c1, char c2, char c3, char c4, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::VideoWriter::fourcc(c1, c2, c3, c4);
    END_WRAP
}

CVAPI(ExceptionStatus) videoio_VideoWriter_getBackendName(cv::VideoWriter *obj, std::string *returnValue)
{
    BEGIN_WRAP
    returnValue->assign(obj->getBackendName());
    END_WRAP
}

#pragma endregion
