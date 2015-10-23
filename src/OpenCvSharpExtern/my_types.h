// Additional types

#ifndef _MY_TYPES_H_
#define _MY_TYPES_H_

typedef unsigned int uint32;
typedef unsigned short uint16;
namespace cv
{
    typedef cv::Vec<uchar, 6> Vec6b;
    typedef cv::Vec<short, 6> Vec6s;
    typedef cv::Vec<ushort, 6> Vec6w;
}

extern "C" 
{
    typedef struct CvPoint3D
    {
        int x;
        int y;
        int z;
	} CvPoint3D; 

    typedef struct CvVec2b { uchar val[2]; } CvVec2b;
    typedef struct CvVec3b { uchar val[3]; } CvVec3b;
    typedef struct CvVec4b { uchar val[4]; } CvVec4b;
    typedef struct CvVec6b { uchar val[6]; } CvVec6b;
    typedef struct CvVec2s { short val[2]; } CvVec2s;
    typedef struct CvVec3s { short val[3]; } CvVec3s;
    typedef struct CvVec4s { short val[4]; } CvVec4s;
    typedef struct CvVec6s { short val[6]; } CvVec6s;
    typedef struct CvVec2w { ushort val[2]; } CvVec2w;
    typedef struct CvVec3w { ushort val[3]; } CvVec3w;
    typedef struct CvVec4w { ushort val[4]; } CvVec4w;
    typedef struct CvVec6w { ushort val[6]; } CvVec6w;
    typedef struct CvVec2i { int val[2]; } CvVec2i;
    typedef struct CvVec3i { int val[3]; } CvVec3i;
    typedef struct CvVec4i { int val[4]; } CvVec4i;
    typedef struct CvVec6i { int val[6]; } CvVec6i;
    typedef struct CvVec2f { float val[2]; } CvVec2f;
    typedef struct CvVec3f { float val[3]; } CvVec3f;
    typedef struct CvVec4f { float val[4]; } CvVec4f;
    typedef struct CvVec6f { float val[6]; } CvVec6f;
    typedef struct CvVec2d { double val[2]; } CvVec2d;
    typedef struct CvVec3d { double val[3]; } CvVec3d;
    typedef struct CvVec4d { double val[4]; } CvVec4d;
    typedef struct CvVec6d { double val[6]; } CvVec6d;
}

#endif