#ifndef _CPP_VIDEO_H_
#define _CPP_VIDEO_H_

#include "include_opencv.h"


CVAPI(void) video_initModule_video()
{
    cv::initModule_video();
}

#endif