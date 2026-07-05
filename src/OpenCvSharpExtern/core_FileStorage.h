#pragma once

#include "include_opencv.h"

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#pragma region FileStorage

CVAPI(ExceptionStatus) core_FileStorage_new1(cv::FileStorage **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::FileStorage;
    });
}
CVAPI(ExceptionStatus) core_FileStorage_new2(const char *source, int flags, const char *encoding, cv::FileStorage **returnValue)
{
    return cvTry([&] {
        std::string encodingStr;
        if (encoding != nullptr)
            encodingStr = std::string(encoding);
        *returnValue = new cv::FileStorage(source, flags, encodingStr);
    });
}

CVAPI(ExceptionStatus) core_FileStorage_delete(cv::FileStorage *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) core_FileStorage_open(cv::FileStorage *obj,
                                 const char *filename, int flags, const char *encoding, int *returnValue)
{
    return cvTry([&] {
        std::string encodingStr;
        if (encoding != nullptr)
            encodingStr = std::string(encoding);
        *returnValue = obj->open(filename, flags, encodingStr) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_FileStorage_isOpened(cv::FileStorage *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->isOpened() ? 1 : 0;
    });
}

/*
CVAPI(ExceptionStatus) core_FileStorage_release(cv::FileStorage *obj)
{
    return cvTry([&] {
        obj->release();
    });
}*/

CVAPI(ExceptionStatus) core_FileStorage_releaseAndGetString(
    cv::FileStorage* obj, std::string * outString)
{
    return cvTry([&] {
        outString->assign(obj->releaseAndGetString());
    });
}

CVAPI(ExceptionStatus) core_FileStorage_getFirstTopLevelNode(cv::FileStorage *obj, cv::FileNode **returnValue)
{
    return cvTry([&] {
        const auto node = obj->getFirstTopLevelNode();
        *returnValue = new cv::FileNode(node);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_root(cv::FileStorage *obj, int streamIdx, cv::FileNode **returnValue)
{
    return cvTry([&] {
        const auto node = obj->root(streamIdx);
        *returnValue = new cv::FileNode(node);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_indexer(cv::FileStorage *obj, const char *nodeName, cv::FileNode **returnValue)
{
    return cvTry([&] {
        const auto node = (*obj)[nodeName];
        *returnValue = new cv::FileNode(node);
    });
}

CVAPI(ExceptionStatus) core_FileStorage_writeRaw(cv::FileStorage *obj, const char *fmt, const uchar *vec, size_t len)
{
    return cvTry([&] {
        obj->writeRaw(fmt, vec, len);
    });
}

CVAPI(ExceptionStatus) core_FileStorage_writeComment(cv::FileStorage *obj, const char *comment, int append)
{
    return cvTry([&] {
        obj->writeComment(comment, append != 0);
    });
}

CVAPI(ExceptionStatus) core_FileStorage_getDefaultObjectName(const char *filename, std::string *buf)
{
    return cvTry([&] {
        buf->assign(cv::FileStorage::getDefaultObjectName(filename));
    });
}

CVAPI(ExceptionStatus) core_FileStorage_elname(cv::FileStorage *obj, std::string *returnValue)
{
    return cvTry([&] {
        returnValue->assign(obj->elname);
    });
}

CVAPI(ExceptionStatus) core_FileStorage_startWriteStruct(
    cv::FileStorage *obj, const char* name, int flags, const char *typeName)
{
    return cvTry([&] {
        obj->startWriteStruct(name, flags, typeName);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_endWriteStruct(    cv::FileStorage *obj)
{
    return cvTry([&] {
        obj->endWriteStruct();
    });
}

CVAPI(ExceptionStatus) core_FileStorage_state(cv::FileStorage *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->state;
    });
}

CVAPI(ExceptionStatus) core_FileStorage_write_int(cv::FileStorage *fs, const char *name, int value)
{
    return cvTry([&] {
        cv::write(*fs, cv::String(name), value);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_write_float(cv::FileStorage *fs, const char *name, float value)
{
    return cvTry([&] {
        cv::write(*fs, cv::String(name), value);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_write_double(cv::FileStorage *fs, const char *name, double value)
{
    return cvTry([&] {
        cv::write(*fs, cv::String(name), value);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_write_String(cv::FileStorage *fs, const char *name, const char *value)
{
    return cvTry([&] {
        cv::write(*fs, cv::String(name), value);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_write_Mat(cv::FileStorage *fs, const char *name, const cv::Mat *value)
{
    return cvTry([&] {
        cv::write(*fs, cv::String(name), *value);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_write_SparseMat(cv::FileStorage *fs, const char *name, const cv::SparseMat *value)
{
    return cvTry([&] {
        cv::write(*fs, cv::String(name), *value);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_write_vectorOfKeyPoint(cv::FileStorage *fs, const char *name, const std::vector<cv::KeyPoint> *value)
{
    return cvTry([&] {
        cv::write(*fs, cv::String(name), *value);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_write_vectorOfDMatch(cv::FileStorage *fs, const char *name, const std::vector<cv::DMatch> *value)
{
    return cvTry([&] {
        cv::write(*fs, cv::String(name), *value);
    });
}

CVAPI(ExceptionStatus) core_FileStorage_writeScalar_int(cv::FileStorage *fs, int value)
{
    return cvTry([&] {
        cv::writeScalar(*fs, value);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_writeScalar_float(cv::FileStorage *fs, float value)
{
    return cvTry([&] {
        cv::writeScalar(*fs, value);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_writeScalar_double(cv::FileStorage *fs, double value)
{
    return cvTry([&] {
        cv::writeScalar(*fs, value);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_writeScalar_String(cv::FileStorage *fs, const char *value)
{
    return cvTry([&] {
        cv::writeScalar(*fs, cv::String(value));
    });
}

CVAPI(ExceptionStatus) core_FileStorage_shift_String(cv::FileStorage *fs, const char *val)
{
    return cvTry([&] {
        (*fs) << val;
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_int(cv::FileStorage *fs, int val)
{
    return cvTry([&] {
        (*fs) << val;
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_float(cv::FileStorage *fs, float val)
{
    return cvTry([&] {
        (*fs) << val;
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_double(cv::FileStorage *fs, double val)
{
    return cvTry([&] {
        (*fs) << val;
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Mat(cv::FileStorage *fs, cv::Mat *val)
{
    return cvTry([&] {
        (*fs) << *val;
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_SparseMat(cv::FileStorage *fs, cv::SparseMat *val)
{
    return cvTry([&] {
        (*fs) << *val;
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Range(cv::FileStorage *fs, interop::Range val)
{
    return cvTry([&] {
        (*fs) << cpp(val);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_KeyPoint(cv::FileStorage *fs, cv::KeyPoint val)
{
    return cvTry([&] {
        (*fs) << val;
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_DMatch(cv::FileStorage *fs, cv::DMatch val)
{
    return cvTry([&] {
        (*fs) << val;
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_vectorOfKeyPoint(cv::FileStorage *fs, std::vector<cv::KeyPoint> *val)
{
    return cvTry([&] {
        (*fs) << *val;
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_vectorOfDMatch(cv::FileStorage *fs, std::vector<cv::DMatch> *val)
{
    return cvTry([&] {
        (*fs) << *val;
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Point2i(cv::FileStorage *fs, interop::Point val)
{
    return cvTry([&] {
        (*fs) << cv::Point2i(val.x, val.y);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Point2f(cv::FileStorage *fs, interop::Point2f val)
{
    return cvTry([&] {
        (*fs) << cv::Point2f(val.x, val.y);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Point2d(cv::FileStorage *fs, interop::Point2d val)
{
    return cvTry([&] {
        (*fs) << cv::Point2d(val.x, val.y);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Point3i(cv::FileStorage *fs, interop::Point3i val)
{
    return cvTry([&] {
        (*fs) << cv::Point3i(val.x, val.y, val.z);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Point3f(cv::FileStorage *fs, interop::Point3f val)
{
    return cvTry([&] {
        (*fs) << cv::Point3f(val.x, val.y, val.z);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Point3d(cv::FileStorage *fs, interop::Point3d val)
{
    return cvTry([&] {
        (*fs) << cv::Point3d(val.x, val.y, val.z);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Size2i(cv::FileStorage *fs, interop::Size val)
{
    return cvTry([&] {
        (*fs) << cv::Size2i(val.width, val.height);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Size2f(cv::FileStorage *fs, interop::Size2f val)
{
    return cvTry([&] {
        (*fs) << cv::Size2f(val.width, val.height);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Size2d(cv::FileStorage *fs, interop::Size2d val)
{
    return cvTry([&] {
        (*fs) << cv::Size2d(val.width, val.height);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Rect2i(cv::FileStorage *fs, interop::Rect val)
{
    return cvTry([&] {
        (*fs) << cv::Rect2i(val.x, val.y, val.width, val.height);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Rect2f(cv::FileStorage *fs, interop::Rect2f val)
{
    return cvTry([&] {
        (*fs) << cv::Rect2f(val.x, val.y, val.width, val.height);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Rect2d(cv::FileStorage *fs, interop::Rect2d val)
{
    return cvTry([&] {
        (*fs) << cv::Rect2d(val.x, val.y, val.width, val.height);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Scalar(cv::FileStorage *fs, interop::Scalar val)
{
    return cvTry([&] {
        (*fs) << cpp(val);
    });
}

CVAPI(ExceptionStatus) core_FileStorage_shift_Vec2i(cv::FileStorage *fs, interop::Vec2i v)
{
    return cvTry([&] {
        (*fs) << cv::Vec2i(v.val[0], v.val[1]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec3i(cv::FileStorage *fs, interop::Vec3i v)
{
    return cvTry([&] {
        (*fs) << cv::Vec3i(v.val[0], v.val[1], v.val[2]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec4i(cv::FileStorage *fs, interop::Vec4i v)
{
    return cvTry([&] {
        (*fs) << cv::Vec4i(v.val[0], v.val[1], v.val[2], v.val[3]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec6i(cv::FileStorage *fs, interop::Vec6i v)
{
    return cvTry([&] {
        (*fs) << cv::Vec6i(v.val[0], v.val[1], v.val[2], v.val[3], v.val[4], v.val[5]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec2d(cv::FileStorage *fs, interop::Vec2d v)
{
    return cvTry([&] {
        (*fs) << cv::Vec2d(v.val[0], v.val[1]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec3d(cv::FileStorage *fs, interop::Vec3d v)
{
    return cvTry([&] {
        (*fs) << cv::Vec3d(v.val[0], v.val[1], v.val[2]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec4d(cv::FileStorage *fs, interop::Vec4d v)
{
    return cvTry([&] {
        (*fs) << cv::Vec4d(v.val[0], v.val[1], v.val[2], v.val[3]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec6d(cv::FileStorage *fs, interop::Vec6d v)
{
    return cvTry([&] {
        (*fs) << cv::Vec6d(v.val[0], v.val[1], v.val[2], v.val[3], v.val[4], v.val[5]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec2f(cv::FileStorage *fs, interop::Vec2f v)
{
    return cvTry([&] {
        (*fs) << cv::Vec2f(v.val[0], v.val[1]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec3f(cv::FileStorage *fs, interop::Vec3f v)
{
    return cvTry([&] {
        (*fs) << cv::Vec3f(v.val[0], v.val[1], v.val[2]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec4f(cv::FileStorage *fs, interop::Vec4f v)
{
    return cvTry([&] {
        (*fs) << cv::Vec4f(v.val[0], v.val[1], v.val[2], v.val[3]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec6f(cv::FileStorage *fs, interop::Vec6f v)
{
    return cvTry([&] {
        (*fs) << cv::Vec6f(v.val[0], v.val[1], v.val[2], v.val[3], v.val[4], v.val[5]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec2b(cv::FileStorage *fs, interop::Vec2b v)
{
    return cvTry([&] {
        (*fs) << cv::Vec2b(v.val[0], v.val[1]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec3b(cv::FileStorage *fs, interop::Vec3b v)
{
    return cvTry([&] {
        (*fs) << cv::Vec3b(v.val[0], v.val[1], v.val[2]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec4b(cv::FileStorage *fs, interop::Vec4b v)
{
    return cvTry([&] {
        (*fs) << cv::Vec4b(v.val[0], v.val[1], v.val[2], v.val[3]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec6b(cv::FileStorage *fs, interop::Vec6b v)
{
    return cvTry([&] {
        (*fs) << cv::Vec6b(v.val[0], v.val[1], v.val[2], v.val[3], v.val[4], v.val[5]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec2s(cv::FileStorage *fs, interop::Vec2s v)
{
    return cvTry([&] {
        (*fs) << cv::Vec2s(v.val[0], v.val[1]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec3s(cv::FileStorage *fs, interop::Vec3s v)
{
    return cvTry([&] {
        (*fs) << cv::Vec3s(v.val[0], v.val[1], v.val[2]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec4s(cv::FileStorage *fs, interop::Vec4s v)
{
    return cvTry([&] {
        (*fs) << cv::Vec4s(v.val[0], v.val[1], v.val[2], v.val[3]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec6s(cv::FileStorage *fs, interop::Vec6s v)
{
    return cvTry([&] {
        (*fs) << cv::Vec6s(v.val[0], v.val[1], v.val[2], v.val[3], v.val[4], v.val[5]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec2w(cv::FileStorage *fs, interop::Vec2w v)
{
    return cvTry([&] {
        (*fs) << cv::Vec2w(v.val[0], v.val[1]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec3w(cv::FileStorage *fs, interop::Vec3w v)
{
    return cvTry([&] {
        (*fs) << cv::Vec3w(v.val[0], v.val[1], v.val[2]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec4w(cv::FileStorage *fs, interop::Vec4w v)
{
    return cvTry([&] {
        (*fs) << cv::Vec4w(v.val[0], v.val[1], v.val[2], v.val[3]);
    });
}
CVAPI(ExceptionStatus) core_FileStorage_shift_Vec6w(cv::FileStorage *fs, interop::Vec6w v)
{
    return cvTry([&] {
        (*fs) << cv::Vec6w(v.val[0], v.val[1], v.val[2], v.val[3], v.val[4], v.val[5]);
    });
}

#pragma endregion
