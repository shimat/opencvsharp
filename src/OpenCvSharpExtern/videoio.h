#ifndef _CPP_VIDEOIO_H_
#define _CPP_VIDEOIO_H_

#include "include_opencv.h"


#pragma region VideoCapture

CVAPI(cv::VideoCapture*) videoio_VideoCapture_new1()
{
    return new cv::VideoCapture;
}
CVAPI(cv::VideoCapture*) videoio_VideoCapture_new2(const char *filename)
{
    return new cv::VideoCapture(filename);
}
CVAPI(cv::VideoCapture*) videoio_VideoCapture_new3(int device)
{
    return new cv::VideoCapture(device);
}

CVAPI(void) videoio_VideoCapture_delete(cv::VideoCapture *obj)
{
    delete obj;
}


CVAPI(int) videoio_VideoCapture_open1(cv::VideoCapture *obj, const char *filename)
{
    return obj->open(filename) ? 1 : 0;
}

CVAPI(int) videoio_VideoCapture_open2(cv::VideoCapture *obj, int device)
{
    return obj->open(device) ? 1 : 0;
}

CVAPI(int) videoio_VideoCapture_isOpened(cv::VideoCapture *obj)
{
    return obj->isOpened() ? 1 : 0;
}

CVAPI(void) videoio_VideoCapture_release(cv::VideoCapture *obj)
{
    obj->release();
}

CVAPI(int) videoio_VideoCapture_grab(cv::VideoCapture *obj)
{
    return obj->grab() ? 1 : 0;
}

CVAPI(int) videoio_VideoCapture_retrieve(cv::VideoCapture *obj, cv::_OutputArray *image, int flag)
{
    return obj->retrieve(*image, flag) ? 1 : 0;
}

CVAPI(void) videoio_VideoCapture_operatorRightShift_Mat(cv::VideoCapture *obj, cv::Mat *image)
{
    (*obj) >> (*image);
}
CVAPI(void) videoio_VideoCapture_operatorRightShift_UMat(cv::VideoCapture *obj, cv::UMat *image)
{
    (*obj) >> (*image);
}

CVAPI(int) videoio_VideoCapture_read(cv::VideoCapture *obj, cv::_OutputArray *image)
{
    return obj->read(*image) ? 1 : 0;
}

CVAPI(int) videoio_VideoCapture_set(cv::VideoCapture *obj, int propId, double value)
{
    return obj->set(propId, value) ? 1 : 0;
}

CVAPI(double) videoio_VideoCapture_get(cv::VideoCapture *obj, int propId)
{
    return obj->get(propId);
}

#pragma endregion

#pragma region VideoWriter

CVAPI(cv::VideoWriter*) videoio_VideoWriter_new1()
{
    return new cv::VideoWriter;
}
CVAPI(cv::VideoWriter*) videoio_VideoWriter_new2(const char *filename, int fourcc, double fps,
    MyCvSize frameSize, int isColor)
{
    return new cv::VideoWriter(filename, fourcc, fps, cpp(frameSize), isColor != 0);
}

CVAPI(void) videoio_VideoWriter_delete(cv::VideoWriter *obj)
{
    delete obj;
}

CVAPI(int) videoio_VideoWriter_open(cv::VideoWriter *obj, const char *filename, int fourcc, double fps,
    MyCvSize frameSize, int isColor)
{
    return obj->open(filename, fourcc, fps, cpp(frameSize), isColor != 0) ? 1 : 0;
}

CVAPI(int) videoio_VideoWriter_isOpened(cv::VideoWriter *obj)
{
    return obj->isOpened() ? 1 : 0;
}

CVAPI(void) videoio_VideoWriter_release(cv::VideoWriter *obj)
{
    obj->release();
}

CVAPI(void) videoio_VideoWriter_OperatorLeftShift(cv::VideoWriter *obj, cv::Mat *image)
{
    (*obj) << (*image);
}

CVAPI(void) videoio_VideoWriter_write(cv::VideoWriter *obj, cv::Mat *image)
{
    obj->write(*image);
}

CVAPI(int) videoio_VideoWriter_set(cv::VideoWriter *obj, int propId, double value)
{
    return obj->set(propId, value) ? 1 : 0;
}

CVAPI(double) videoio_VideoWriter_get(cv::VideoWriter *obj, int propId)
{
    return obj->get(propId);
}

CVAPI(int) videoio_VideoWriter_fourcc(char c1, char c2, char c3, char c4)
{
    return cv::VideoWriter::fourcc(c1, c2, c3, c4);
}

#pragma endregion

#endif