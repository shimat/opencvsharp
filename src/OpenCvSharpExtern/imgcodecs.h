#ifndef _CPP_IMGCODECS_H_
#define _CPP_IMGCODECS_H_

#include "include_opencv.h"

CVAPI(cv::Mat*) imgcodecs_imread(const char *filename, int flags)
{
    cv::Mat ret = cv::imread(filename, flags);
    return new cv::Mat(ret);
}

CVAPI(int) imgcodecs_imreadmulti(const char *filename, std::vector<cv::Mat> *mats, int flags)
{
    return cv::imreadmulti(filename, *mats, flags) ? 1 : 0;
}

CVAPI(int) imgcodecs_imwrite(const char *filename, cv::Mat *img, int *params, int paramsLength)
{
    std::vector<int> paramsVec;
    paramsVec.assign(params, params + paramsLength);
    return cv::imwrite(filename, *img, paramsVec) ? 1 : 0;
}

CVAPI(cv::Mat*) imgcodecs_imdecode_Mat(cv::Mat *buf, int flags)
{
    cv::Mat ret = cv::imdecode(*buf, flags);
    return new cv::Mat(ret);
}
CVAPI(cv::Mat*) imgcodecs_imdecode_vector(uchar *buf, size_t bufLength, int flags)
{
    std::vector<uchar> bufVec(buf, buf + bufLength);
    cv::Mat ret = cv::imdecode(bufVec, flags);
    return new cv::Mat(ret);
}
CVAPI(cv::Mat*) imgcodecs_imdecode_InputArray(cv::_InputArray *buf, int flags)
{
    cv::Mat ret = cv::imdecode(*buf, flags);
    return new cv::Mat(ret);
}

CVAPI(int) imgcodecs_imencode_vector(const char *ext, cv::_InputArray *img,
    std::vector<uchar> *buf, int *params, int paramsLength)
{
    std::vector<int> paramsVec;
    if (params != NULL)
        paramsVec = std::vector<int>(params, params + paramsLength);
    return cv::imencode(ext, *img, *buf, paramsVec) ? 1 : 0;
}



CVAPI(void) imgcodecs_cvConvertImage_CvArr(CvArr *src, CvArr *dst, int flags)
{
    cvConvertImage(src, dst, flags);
}
CVAPI(void) imgcodecs_cvConvertImage_Mat(cv::Mat *src, cv::Mat *dst, int flags)
{
    IplImage srcImg = (IplImage)*src;
    IplImage dstImg = (IplImage)*dst;
    cvConvertImage(&srcImg, &dstImg, flags);
}

CVAPI(int) imgcodecs_cvHaveImageReader(const char *filename)
{
    return cvHaveImageReader(filename);
}

CVAPI(int) imgcodecs_cvHaveImageWriter(const char *filename)
{
    return cvHaveImageWriter(filename);
}

#endif