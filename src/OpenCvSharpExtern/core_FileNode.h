#ifndef _CPP_CORE_FILENODE_H_
#define _CPP_CORE_FILENODE_H_

#include "include_opencv.h"

CVAPI(cv::FileNode*) core_FileNode_new1()
{
    return new cv::FileNode();
}
CVAPI(cv::FileNode*) core_FileNode_new2(CvFileStorage* fs, CvFileNode* node)
{
    return new cv::FileNode(fs, node);
}
CVAPI(cv::FileNode*) core_FileNode_new3(cv::FileNode *node)
{
    return new cv::FileNode(*node);
}

CVAPI(void) core_FileNode_delete(cv::FileNode *node)
{
    delete node;
}

CVAPI(cv::FileNode*) core_FileNode_operatorThis_byString(cv::FileNode *obj, const char *nodeName)
{
    cv::FileNode ret = (*obj)[nodeName];
    return new cv::FileNode(ret);
}
CVAPI(cv::FileNode*) core_FileNode_operatorThis_byInt(cv::FileNode *obj, int i)
{
    cv::FileNode ret = (*obj)[i];
    return new cv::FileNode(ret);
}
CVAPI(int) core_FileNode_type(cv::FileNode *obj)
{
    return obj->type();
}

CVAPI(int) core_FileNode_empty(cv::FileNode *obj)
{
    return obj->empty() ? 1 : 0;
}
CVAPI(int) core_FileNode_isNone(cv::FileNode *obj)
{
    return obj->isNone() ? 1 : 0;
}
CVAPI(int) core_FileNode_isSeq(cv::FileNode *obj)
{
    return obj->isSeq() ? 1 : 0;
}
CVAPI(int) core_FileNode_isMap(cv::FileNode *obj)
{
    return obj->isMap() ? 1 : 0;
}
CVAPI(int) core_FileNode_isInt(cv::FileNode *obj)
{
    return obj->isInt() ? 1 : 0;
}
CVAPI(int) core_FileNode_isReal(cv::FileNode *obj)
{
    return obj->isReal() ? 1 : 0;
}
CVAPI(int) core_FileNode_isString(cv::FileNode *obj)
{
    return obj->isString() ? 1 : 0;
}
CVAPI(int) core_FileNode_isNamed(cv::FileNode *obj)
{
    return obj->isNamed() ? 1 : 0;
}

CVAPI(void) core_FileNode_name(cv::FileNode *obj, char *buf, int bufLength)
{
    std::string str = obj->name();
    copyString(str, buf, bufLength);
}
CVAPI(size_t) core_FileNode_size(cv::FileNode *obj)
{
    return  obj->size();
}

CVAPI(int) core_FileNode_toInt(cv::FileNode *obj)
{
    return (int)(*obj);
}
CVAPI(float) core_FileNode_toFloat(cv::FileNode *obj)
{
    return (float)(*obj);
}
CVAPI(double) core_FileNode_toDouble(cv::FileNode *obj)
{
    return (double)(*obj);
}
CVAPI(void) core_FileNode_toString(cv::FileNode *obj, char *buf, int bufLength)
{
    std::string str = (std::string)(*obj);
    copyString(str, buf, bufLength);
}
CVAPI(void) core_FileNode_toMat(cv::FileNode *obj, cv::Mat *m)
{
    (*obj) >> (*m);
}

CVAPI(cv::FileNodeIterator*) core_FileNode_begin(cv::FileNode *obj)
{
    return new cv::FileNodeIterator(obj->begin());
}
CVAPI(cv::FileNodeIterator*) core_FileNode_end(cv::FileNode *obj)
{
    return new cv::FileNodeIterator(obj->end());
}

CVAPI(void) core_FileNode_readRaw(cv::FileNode *obj, const char *fmt, uchar* vec, size_t len)
{
    obj->readRaw(fmt, vec, len);
}
CVAPI(void*) core_FileNode_readObj(cv::FileNode *obj)
{
    return obj->readObj();
}

CVAPI(void) core_FileNode_read_int(cv::FileNode *node, int *value, int default_value)
{
    int temp;
    cv::read(*node, temp, default_value);
    *value = temp;
}
CVAPI(void) core_FileNode_read_float(cv::FileNode *node, float *value, float default_value)
{
    float temp;
    cv::read(*node, temp, default_value);
    *value = temp;
}
CVAPI(void) core_FileNode_read_double(cv::FileNode *node, double *value, double default_value)
{
    double temp;
    cv::read(*node, temp, default_value);
    *value = temp;
}
CVAPI(void) core_FileNode_read_String(cv::FileNode *node, char *value, int valueCapacity, const char *default_value)
{
    cv::String str;
    cv::read(*node, str, (default_value == NULL) ? cv::String() : cv::String(default_value));
    copyString(str, value, valueCapacity);
}
CVAPI(void) core_FileNode_read_Mat(cv::FileNode *node, cv::Mat *mat, cv::Mat *default_mat)
{
    cv::read(*node, *mat, entity(default_mat));
}
CVAPI(void) core_FileNode_read_SparseMat(cv::FileNode *node, cv::SparseMat *mat, cv::SparseMat *default_mat)
{
    cv::read(*node, *mat, entity(default_mat));
}
CVAPI(void) core_FileNode_read_vectorOfKeyPoint(cv::FileNode *node, std::vector<cv::KeyPoint> *keypoints)
{
    cv::read(*node, *keypoints);
}
CVAPI(void) core_FileNode_read_vectorOfDMatch(cv::FileNode *node, std::vector<cv::DMatch> *matches)
{
    cv::read(*node, *matches);
}



CVAPI(MyCvSlice) core_FileNode_read_Range(cv::FileNode *node)
{
    cv::Range ret;
    (*node) >> ret;
    return c(ret);
}
CVAPI(MyKeyPoint) core_FileNode_read_KeyPoint(cv::FileNode *node)
{    
    cv::KeyPoint ret;
    (*node) >> ret;
    return c(ret);
}
CVAPI(MyDMatch) core_FileNode_read_DMatch(cv::FileNode *node)
{
    cv::DMatch ret;
    (*node) >> ret;
    return c(ret);
}
CVAPI(MyCvPoint) core_FileNode_read_Point2i(cv::FileNode *node)
{
    cv::Point2i ret;
    (*node) >> ret;
    return MyCvPoint{ ret.x, ret.y };
}
CVAPI(MyCvPoint2D32f) core_FileNode_read_Point2f(cv::FileNode *node)
{
    cv::Point2f ret;
    (*node) >> ret;
    return MyCvPoint2D32f{ ret.x, ret.y };
}
CVAPI(MyCvPoint2D64f) core_FileNode_read_Point2d(cv::FileNode *node)
{
    cv::Point2d ret;
    (*node) >> ret;
    return MyCvPoint2D64f{ ret.x, ret.y };
}
CVAPI(MyCvPoint3D32i) core_FileNode_read_Point3i(cv::FileNode *node)
{
    cv::Point3i ret;
    (*node) >> ret;
    return MyCvPoint3D32i{ ret.x, ret.y, ret.z };
}
CVAPI(MyCvPoint3D32f) core_FileNode_read_Point3f(cv::FileNode *node)
{
    cv::Point3f ret;
    (*node) >> ret;
    return MyCvPoint3D32f{ ret.x, ret.y, ret.z };
}
CVAPI(MyCvPoint3D64f) core_FileNode_read_Point3d(cv::FileNode *node)
{
    cv::Point3d ret;
    (*node) >> ret;
    return MyCvPoint3D64f{ ret.x, ret.y, ret.z };
}
CVAPI(MyCvSize) core_FileNode_read_Size2i(cv::FileNode *node)
{
    cv::Size2i ret;
    (*node) >> ret;
    return MyCvSize{ ret.width, ret.height };
}
CVAPI(MyCvSize2D32f) core_FileNode_read_Size2f(cv::FileNode *node)
{
    cv::Size2f ret;
    (*node) >> ret;
    return MyCvSize2D32f{ ret.width, ret.height };
}
CVAPI(MyCvSize2D64f) core_FileNode_read_Size2d(cv::FileNode *node)
{
    cv::Size2d ret;
    (*node) >> ret;
    return MyCvSize2D64f{ ret.width, ret.height };
}
CVAPI(MyCvRect) core_FileNode_read_Rect2i(cv::FileNode *node)
{
    cv::Rect2i ret;
    (*node) >> ret;
    return MyCvRect{ ret.x, ret.y, ret.width, ret.height };
}
CVAPI(MyCvRect2D32f) core_FileNode_read_Rect2f(cv::FileNode *node)
{
    cv::Rect2f ret;
    (*node) >> ret;
    return MyCvRect2D32f{ ret.x, ret.y, ret.width, ret.height };
}
CVAPI(MyCvRect2D64f) core_FileNode_read_Rect2d(cv::FileNode *node)
{
    cv::Rect2d ret;
    (*node) >> ret;
    return MyCvRect2D64f{ ret.x, ret.y, ret.width, ret.height };
}
CVAPI(MyCvScalar) core_FileNode_read_Scalar(cv::FileNode *node)
{
    cv::Scalar s;
    (*node) >> s;
    MyCvScalar ret;
    ret.val[0] = s.val[0];
    ret.val[1] = s.val[1];
    ret.val[2] = s.val[2];
    ret.val[3] = s.val[3];
    return ret;
}

#define DEFINE_FILENODE_READ_VEC(name) \
    CVAPI(Cv##name) core_FileNode_read_##name(cv::FileNode *node) \
    { \
        cv::##name v; \
        (*node) >> v; \
        Cv##name ret; \
        std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); \
        return ret; \
    }

DEFINE_FILENODE_READ_VEC(Vec2i)
DEFINE_FILENODE_READ_VEC(Vec3i)
DEFINE_FILENODE_READ_VEC(Vec4i)
DEFINE_FILENODE_READ_VEC(Vec6i)
DEFINE_FILENODE_READ_VEC(Vec2d)
DEFINE_FILENODE_READ_VEC(Vec3d)
DEFINE_FILENODE_READ_VEC(Vec4d)
DEFINE_FILENODE_READ_VEC(Vec6d)
DEFINE_FILENODE_READ_VEC(Vec2f)
DEFINE_FILENODE_READ_VEC(Vec3f)
DEFINE_FILENODE_READ_VEC(Vec4f)
DEFINE_FILENODE_READ_VEC(Vec6f)
DEFINE_FILENODE_READ_VEC(Vec2b)
//DEFINE_FILENODE_READ_VEC(Vec3b)

CVAPI(CvVec3b) core_FileNode_read_Vec3b(cv::FileNode *node)
{
    cv::Vec3b v; 
    (*node) >> v; 
    CvVec3b ret; 
    std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); 
    return ret; 
}

DEFINE_FILENODE_READ_VEC(Vec4b)
DEFINE_FILENODE_READ_VEC(Vec6b)
DEFINE_FILENODE_READ_VEC(Vec2s)
DEFINE_FILENODE_READ_VEC(Vec3s)
DEFINE_FILENODE_READ_VEC(Vec4s)
DEFINE_FILENODE_READ_VEC(Vec6s)
DEFINE_FILENODE_READ_VEC(Vec2w)
DEFINE_FILENODE_READ_VEC(Vec3w)
DEFINE_FILENODE_READ_VEC(Vec4w)
DEFINE_FILENODE_READ_VEC(Vec6w)

/*
CVAPI(CvVec2f) core_FileNode_read_Vec2f(cv::FileNode *node);
CVAPI(CvVec3f) core_FileNode_read_Vec3f(cv::FileNode *node);
CVAPI(CvVec4f) core_FileNode_read_Vec4f(cv::FileNode *node);
CVAPI(CvVec6f) core_FileNode_read_Vec6f(cv::FileNode *node);
//*/
#endif