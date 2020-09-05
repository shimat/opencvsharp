#ifndef _CPP_CORE_FILESTORAGE_H_
#define _CPP_CORE_FILESTORAGE_H_

#include "include_opencv.h"

#pragma region FileStorage

CVAPI(ExceptionStatus) core_FileStorage_new1(cv::FileStorage **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::FileStorage;
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_new2(const char *source, int flags, const char *encoding, cv::FileStorage **returnValue)
{
    BEGIN_WRAP
    std::string encodingStr;
    if (encoding != nullptr)
        encodingStr = std::string(encoding);
    *returnValue = new cv::FileStorage(source, flags, encodingStr);
    END_WRAP
}

CVAPI(ExceptionStatus) core_FileStorage_delete(cv::FileStorage *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) core_FileStorage_open(cv::FileStorage *obj,
                                 const char *filename, int flags, const char *encoding, int *returnValue)
{
    BEGIN_WRAP
    std::string encodingStr;
    if (encoding != nullptr)
        encodingStr = std::string(encoding);
    *returnValue = obj->open(filename, flags, encodingStr) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) core_FileStorage_isOpened(cv::FileStorage *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->isOpened() ? 1 : 0;
    END_WRAP
}

/*
CVAPI(ExceptionStatus) core_FileStorage_release(cv::FileStorage *obj)
{
    BEGIN_WRAP
    obj->release();
    END_WRAP
}*/

CVAPI(ExceptionStatus) core_FileStorage_releaseAndGetString(
    cv::FileStorage* obj, std::string * outString)
{
    BEGIN_WRAP
    outString->assign(obj->releaseAndGetString());
    END_WRAP
}

CVAPI(ExceptionStatus) core_FileStorage_getFirstTopLevelNode(cv::FileStorage *obj, cv::FileNode **returnValue)
{
    BEGIN_WRAP
    const auto node = obj->getFirstTopLevelNode();
    *returnValue = new cv::FileNode(node);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_root(cv::FileStorage *obj, int streamIdx, cv::FileNode **returnValue)
{
    BEGIN_WRAP
    const auto node = obj->root(streamIdx);
    *returnValue = new cv::FileNode(node);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_indexer(cv::FileStorage *obj, const char *nodeName, cv::FileNode **returnValue)
{
    BEGIN_WRAP
    const auto node = (*obj)[nodeName];
    *returnValue = new cv::FileNode(node);
    END_WRAP
}

CVAPI(ExceptionStatus) core_FileStorage_writeRaw(cv::FileStorage *obj, const char *fmt, const uchar *vec, size_t len)
{
    BEGIN_WRAP
    obj->writeRaw(fmt, vec, len);
    END_WRAP
}

CVAPI(ExceptionStatus) core_FileStorage_writeComment(cv::FileStorage *obj, const char *comment, int append)
{
    BEGIN_WRAP
    obj->writeComment(comment, append != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) core_FileStorage_getDefaultObjectName(const char *filename, std::string *buf)
{
    BEGIN_WRAP
    buf->assign(cv::FileStorage::getDefaultObjectName(filename));
    END_WRAP
}

CVAPI(ExceptionStatus) core_FileStorage_elname(cv::FileStorage *obj, std::string *returnValue)
{
    BEGIN_WRAP
    returnValue->assign(obj->elname);
    END_WRAP
}

CVAPI(ExceptionStatus) core_FileStorage_startWriteStruct(
    cv::FileStorage *obj, const char* name, int flags, const char *typeName)
{
    BEGIN_WRAP
    obj->startWriteStruct(name, flags, typeName);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_endWriteStruct(    cv::FileStorage *obj)
{
    BEGIN_WRAP
    obj->endWriteStruct();
    END_WRAP
}

CVAPI(ExceptionStatus) core_FileStorage_state(cv::FileStorage *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->state;
    END_WRAP
}

CVAPI(ExceptionStatus) core_FileStorage_write_int(cv::FileStorage *fs, const char *name, int value)
{
    BEGIN_WRAP
    cv::write(*fs, cv::String(name), value);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_write_float(cv::FileStorage *fs, const char *name, float value)
{
    BEGIN_WRAP
    cv::write(*fs, cv::String(name), value);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_write_double(cv::FileStorage *fs, const char *name, double value)
{
    BEGIN_WRAP
    cv::write(*fs, cv::String(name), value);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_write_String(cv::FileStorage *fs, const char *name, const char *value)
{
    BEGIN_WRAP
    cv::write(*fs, cv::String(name), value);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_write_Mat(cv::FileStorage *fs, const char *name, const cv::Mat *value)
{
    BEGIN_WRAP
    cv::write(*fs, cv::String(name), *value);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_write_SparseMat(cv::FileStorage *fs, const char *name, const cv::SparseMat *value)
{
    BEGIN_WRAP
    cv::write(*fs, cv::String(name), *value);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_write_vectorOfKeyPoint(cv::FileStorage *fs, const char *name, const std::vector<cv::KeyPoint> *value)
{
    BEGIN_WRAP
    cv::write(*fs, cv::String(name), *value);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_write_vectorOfDMatch(cv::FileStorage *fs, const char *name, const std::vector<cv::DMatch> *value)
{
    BEGIN_WRAP
    cv::write(*fs, cv::String(name), *value);
    END_WRAP
}

CVAPI(ExceptionStatus) core_FileStorage_writeScalar_int(cv::FileStorage *fs, int value)
{
    BEGIN_WRAP
    cv::writeScalar(*fs, value);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_writeScalar_float(cv::FileStorage *fs, float value)
{
    BEGIN_WRAP
    cv::writeScalar(*fs, value);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_writeScalar_double(cv::FileStorage *fs, double value)
{
    BEGIN_WRAP
    cv::writeScalar(*fs, value);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_writeScalar_String(cv::FileStorage *fs, const char *value)
{
    BEGIN_WRAP
    cv::writeScalar(*fs, cv::String(value));
    END_WRAP
}

CVAPI(ExceptionStatus) core_FileStorage_shift_String(cv::FileStorage *fs, const char *val)
{
    BEGIN_WRAP
    (*fs) << val;
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_int(cv::FileStorage *fs, int val)
{
    BEGIN_WRAP
    (*fs) << val;
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_float(cv::FileStorage *fs, float val)
{
    BEGIN_WRAP
    (*fs) << val;
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_double(cv::FileStorage *fs, double val)
{
    BEGIN_WRAP
    (*fs) << val;
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Mat(cv::FileStorage *fs, cv::Mat *val)
{
    BEGIN_WRAP
    (*fs) << *val;
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_SparseMat(cv::FileStorage *fs, cv::SparseMat *val)
{
    BEGIN_WRAP
    (*fs) << *val;
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Range(cv::FileStorage *fs, MyCvSlice val)
{
    BEGIN_WRAP
    (*fs) << cpp(val);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_KeyPoint(cv::FileStorage *fs, cv::KeyPoint val)
{
    BEGIN_WRAP
    (*fs) << val;
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_DMatch(cv::FileStorage *fs, cv::DMatch val)
{
    BEGIN_WRAP
    (*fs) << val;
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_vectorOfKeyPoint(cv::FileStorage *fs, std::vector<cv::KeyPoint> *val)
{
    BEGIN_WRAP
    (*fs) << *val;
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_vectorOfDMatch(cv::FileStorage *fs, std::vector<cv::DMatch> *val)
{
    BEGIN_WRAP
    (*fs) << *val;
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Point2i(cv::FileStorage *fs, MyCvPoint val)
{
    BEGIN_WRAP
    (*fs) << cv::Point2i(val.x, val.y);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Point2f(cv::FileStorage *fs, MyCvPoint2D32f val)
{
    BEGIN_WRAP
    (*fs) << cv::Point2f(val.x, val.y);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Point2d(cv::FileStorage *fs, MyCvPoint2D64f val)
{
    BEGIN_WRAP
    (*fs) << cv::Point2d(val.x, val.y);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Point3i(cv::FileStorage *fs, MyCvPoint3D32i val)
{
    BEGIN_WRAP
    (*fs) << cv::Point3i(val.x, val.y, val.z);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Point3f(cv::FileStorage *fs, MyCvPoint3D32f val)
{
    BEGIN_WRAP
    (*fs) << cv::Point3f(val.x, val.y, val.z);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Point3d(cv::FileStorage *fs, MyCvPoint3D64f val)
{
    BEGIN_WRAP
    (*fs) << cv::Point3d(val.x, val.y, val.z);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Size2i(cv::FileStorage *fs, MyCvSize val)
{
    BEGIN_WRAP
    (*fs) << cv::Size2i(val.width, val.height);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Size2f(cv::FileStorage *fs, MyCvSize2D32f val)
{
    BEGIN_WRAP
    (*fs) << cv::Size2f(val.width, val.height);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Size2d(cv::FileStorage *fs, MyCvSize2D64f val)
{
    BEGIN_WRAP
    (*fs) << cv::Size2d(val.width, val.height);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Rect2i(cv::FileStorage *fs, MyCvRect val)
{
    BEGIN_WRAP
    (*fs) << cv::Rect2i(val.x, val.y, val.width, val.height);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Rect2f(cv::FileStorage *fs, MyCvRect2D32f val)
{
    BEGIN_WRAP
    (*fs) << cv::Rect2f(val.x, val.y, val.width, val.height);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Rect2d(cv::FileStorage *fs, MyCvRect2D64f val)
{
    BEGIN_WRAP
    (*fs) << cv::Rect2d(val.x, val.y, val.width, val.height);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Scalar(cv::FileStorage *fs, MyCvScalar val)
{
    BEGIN_WRAP
    (*fs) << cpp(val);
    END_WRAP
}

CVAPI(ExceptionStatus) core_FileStorage_shift_Vec2i(cv::FileStorage *fs, CvVec2i v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec2i(v.val[0], v.val[1]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec3i(cv::FileStorage *fs, CvVec3i v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec3i(v.val[0], v.val[1], v.val[2]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec4i(cv::FileStorage *fs, CvVec4i v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec4i(v.val[0], v.val[1], v.val[2], v.val[3]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec6i(cv::FileStorage *fs, CvVec6i v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec6i(v.val[0], v.val[1], v.val[2], v.val[3], v.val[4], v.val[5]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec2d(cv::FileStorage *fs, CvVec2d v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec2d(v.val[0], v.val[1]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec3d(cv::FileStorage *fs, CvVec3d v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec3d(v.val[0], v.val[1], v.val[2]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec4d(cv::FileStorage *fs, CvVec4d v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec4d(v.val[0], v.val[1], v.val[2], v.val[3]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec6d(cv::FileStorage *fs, CvVec6d v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec6d(v.val[0], v.val[1], v.val[2], v.val[3], v.val[4], v.val[5]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec2f(cv::FileStorage *fs, CvVec2f v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec2f(v.val[0], v.val[1]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec3f(cv::FileStorage *fs, CvVec3f v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec3f(v.val[0], v.val[1], v.val[2]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec4f(cv::FileStorage *fs, CvVec4f v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec4f(v.val[0], v.val[1], v.val[2], v.val[3]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec6f(cv::FileStorage *fs, CvVec6f v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec6f(v.val[0], v.val[1], v.val[2], v.val[3], v.val[4], v.val[5]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec2b(cv::FileStorage *fs, CvVec2b v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec2b(v.val[0], v.val[1]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec3b(cv::FileStorage *fs, CvVec3b v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec3b(v.val[0], v.val[1], v.val[2]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec4b(cv::FileStorage *fs, CvVec4b v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec4b(v.val[0], v.val[1], v.val[2], v.val[3]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec6b(cv::FileStorage *fs, CvVec6b v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec6b(v.val[0], v.val[1], v.val[2], v.val[3], v.val[4], v.val[5]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec2s(cv::FileStorage *fs, CvVec2s v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec2s(v.val[0], v.val[1]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec3s(cv::FileStorage *fs, CvVec3s v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec3s(v.val[0], v.val[1], v.val[2]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec4s(cv::FileStorage *fs, CvVec4s v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec4s(v.val[0], v.val[1], v.val[2], v.val[3]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec6s(cv::FileStorage *fs, CvVec6s v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec6s(v.val[0], v.val[1], v.val[2], v.val[3], v.val[4], v.val[5]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec2w(cv::FileStorage *fs, CvVec2w v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec2w(v.val[0], v.val[1]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec3w(cv::FileStorage *fs, CvVec3w v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec3w(v.val[0], v.val[1], v.val[2]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec4w(cv::FileStorage *fs, CvVec4w v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec4w(v.val[0], v.val[1], v.val[2], v.val[3]);
    END_WRAP
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec6w(cv::FileStorage *fs, CvVec6w v)
{
    BEGIN_WRAP
    (*fs) << cv::Vec6w(v.val[0], v.val[1], v.val[2], v.val[3], v.val[4], v.val[5]);
    END_WRAP
}

#pragma endregion

#endif