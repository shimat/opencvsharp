#ifndef _CPP_CORE_FILESTORAGE_H_
#define _CPP_CORE_FILESTORAGE_H_

#include "include_opencv.h"

#pragma region FileStorage

CVAPI(cv::FileStorage*) core_FileStorage_new1()
{
    return new cv::FileStorage();
}
CVAPI(cv::FileStorage*) core_FileStorage_new2(const char *source, int flags, const char *encoding)
{
    std::string encodingStr;
    if (encoding != NULL)
        encodingStr = std::string(encoding);
    return new cv::FileStorage(source, flags, encodingStr);
}
CVAPI(cv::FileStorage*) core_FileStorage_newFromLegacy(CvFileStorage *fs)
{
    return new cv::FileStorage(fs);
}

CVAPI(void) core_FileStorage_delete(cv::FileStorage *obj)
{
    delete obj;
}

CVAPI(int) core_FileStorage_open(cv::FileStorage *obj,
                                 const char *filename, int flags, const char *encoding)
{
    std::string encodingStr;
    if (encoding != NULL)
        encodingStr = std::string(encoding);
    return obj->open(filename, flags, encodingStr) ? 1 : 0;
}
CVAPI(int) core_FileStorage_isOpened(cv::FileStorage *obj)
{
    return obj->isOpened() ? 1 : 0;
}
CVAPI(void) core_FileStorage_release(cv::FileStorage *obj)
{
    return obj->release();
}
CVAPI(void) core_FileStorage_releaseAndGetString(cv::FileStorage *obj,
                                                 char *buf, int bufLength)
{
    std::string result = obj->releaseAndGetString();
    copyString(result, buf, bufLength);
}

CVAPI(cv::FileNode*) core_FileStorage_getFirstTopLevelNode(cv::FileStorage *obj)
{
    cv::FileNode node = obj->getFirstTopLevelNode();
    return new cv::FileNode(node);
}
CVAPI(cv::FileNode*) core_FileStorage_root(cv::FileStorage *obj, int streamIdx)
{
    cv::FileNode node = obj->root(streamIdx);
    return new cv::FileNode(node);
}
CVAPI(cv::FileNode*) core_FileStorage_indexer(cv::FileStorage *obj, const char *nodeName)
{
    cv::FileNode node = (*obj)[nodeName];
    return new cv::FileNode(node);
}

CVAPI(CvFileStorage*) core_FileStorage_toLegacy(cv::FileStorage *obj)
{
    return obj->fs.get();
}
CVAPI(void) core_FileStorage_writeRaw(cv::FileStorage *obj, const char *fmt, const uchar *vec, size_t len)
{
    obj->writeRaw(fmt, vec, len);
}
CVAPI(void) core_FileStorage_writeObj(cv::FileStorage *obj, const char *name, const void *value)
{
    obj->writeObj(name, value);
}

CVAPI(void) core_FileStorage_getDefaultObjectName(const char *filename, char *buf, int bufLength)
{
    std::string ret = cv::FileStorage::getDefaultObjectName(filename);
    copyString(ret, buf, bufLength);
}

CVAPI(const char*) core_FileStorage_elname(cv::FileStorage *obj)
{
    return obj->elname.c_str();
}
CVAPI(const char*) core_FileStorage_structs(cv::FileStorage *obj, size_t* resultLength)
{
    std::vector<char> &structs = obj->structs;
    *resultLength = structs.size();
    return &(structs[0]);
}
CVAPI(int) core_FileStorage_state(cv::FileStorage *obj)
{
    return obj->state;
}

CVAPI(void) core_FileStorage_write_int(cv::FileStorage *fs, const char *name, int value)
{
    cv::write(*fs, cv::String(name), value);
}
CVAPI(void) core_FileStorage_write_float(cv::FileStorage *fs, const char *name, float value)
{
    cv::write(*fs, cv::String(name), value);
}
CVAPI(void) core_FileStorage_write_double(cv::FileStorage *fs, const char *name, double value)
{
    cv::write(*fs, cv::String(name), value);
}
CVAPI(void) core_FileStorage_write_String(cv::FileStorage *fs, const char *name, const char *value)
{
    cv::write(*fs, cv::String(name), value);
}
CVAPI(void) core_FileStorage_write_Mat(cv::FileStorage *fs, const char *name, const cv::Mat *value)
{
    cv::write(*fs, cv::String(name), *value);
}
CVAPI(void) core_FileStorage_write_SparseMat(cv::FileStorage *fs, const char *name, const cv::SparseMat *value)
{
    cv::write(*fs, cv::String(name), *value);
}
CVAPI(void) core_FileStorage_write_vectorOfKeyPoint(cv::FileStorage *fs, const char *name, const std::vector<cv::KeyPoint> *value)
{
    cv::write(*fs, cv::String(name), *value);
}
CVAPI(void) core_FileStorage_write_vectorOfDMatch(cv::FileStorage *fs, const char *name, const std::vector<cv::DMatch> *value)
{
    cv::write(*fs, cv::String(name), *value);
}

CVAPI(void) core_FileStorage_writeScalar_int(cv::FileStorage *fs, int value)
{
    cv::writeScalar(*fs, value);
}
CVAPI(void) core_FileStorage_writeScalar_float(cv::FileStorage *fs, float value)
{
    cv::writeScalar(*fs, value);
}
CVAPI(void) core_FileStorage_writeScalar_double(cv::FileStorage *fs, double value)
{
    cv::writeScalar(*fs, value);
}
CVAPI(void) core_FileStorage_writeScalar_String(cv::FileStorage *fs, const char *value)
{
    cv::writeScalar(*fs, cv::String(value));
}

CVAPI(void) core_FileStorage_shift_String(cv::FileStorage *fs, const char *val)
{
    (*fs) << val;
}
CVAPI(void) core_FileStorage_shift_int(cv::FileStorage *fs, int val)
{
    (*fs) << val;
}
CVAPI(void) core_FileStorage_shift_float(cv::FileStorage *fs, float val)
{
    (*fs) << val;
}
CVAPI(void) core_FileStorage_shift_double(cv::FileStorage *fs, double val)
{
    (*fs) << val;
}
CVAPI(void) core_FileStorage_shift_Mat(cv::FileStorage *fs, cv::Mat *val)
{
    (*fs) << *val;
}
CVAPI(void) core_FileStorage_shift_SparseMat(cv::FileStorage *fs, cv::SparseMat *val)
{
    (*fs) << *val;
}
CVAPI(void) core_FileStorage_shift_Range(cv::FileStorage *fs, MyCvSlice val)
{
    (*fs) << cpp(val);
}
CVAPI(void) core_FileStorage_shift_KeyPoint(cv::FileStorage *fs, cv::KeyPoint val)
{
    (*fs) << val;
}
CVAPI(void) core_FileStorage_shift_DMatch(cv::FileStorage *fs, cv::DMatch val)
{
    (*fs) << val;
}
CVAPI(void) core_FileStorage_shift_vectorOfKeyPoint(cv::FileStorage *fs, std::vector<cv::KeyPoint> *val)
{
    (*fs) << *val;
}
CVAPI(void) core_FileStorage_shift_vectorOfDMatch(cv::FileStorage *fs, std::vector<cv::DMatch> *val)
{
    (*fs) << *val;
}
CVAPI(void) core_FileStorage_shift_Point2i(cv::FileStorage *fs, MyCvPoint val)
{
    (*fs) << cv::Point2i(val.x, val.y);
}
CVAPI(void) core_FileStorage_shift_Point2f(cv::FileStorage *fs, MyCvPoint2D32f val)
{
    (*fs) << cv::Point2f(val.x, val.y);
}
CVAPI(void) core_FileStorage_shift_Point2d(cv::FileStorage *fs, MyCvPoint2D64f val)
{
    (*fs) << cv::Point2d(val.x, val.y);
}
CVAPI(void) core_FileStorage_shift_Point3i(cv::FileStorage *fs, MyCvPoint3D32i val)
{
    (*fs) << cv::Point3i(val.x, val.y, val.z);
}
CVAPI(void) core_FileStorage_shift_Point3f(cv::FileStorage *fs, MyCvPoint3D32f val)
{
    (*fs) << cv::Point3f(val.x, val.y, val.z);
}
CVAPI(void) core_FileStorage_shift_Point3d(cv::FileStorage *fs, MyCvPoint3D64f val)
{
    (*fs) << cv::Point3d(val.x, val.y, val.z);
}
CVAPI(void) core_FileStorage_shift_Size2i(cv::FileStorage *fs, MyCvSize val)
{
    (*fs) << cv::Size2i(val.width, val.height);
}
CVAPI(void) core_FileStorage_shift_Size2f(cv::FileStorage *fs, MyCvSize2D32f val)
{
    (*fs) << cv::Size2f(val.width, val.height);
}
CVAPI(void) core_FileStorage_shift_Size2d(cv::FileStorage *fs, MyCvSize2D64f val)
{
    (*fs) << cv::Size2d(val.width, val.height);
}
CVAPI(void) core_FileStorage_shift_Rect2i(cv::FileStorage *fs, MyCvRect val)
{
    (*fs) << cv::Rect2i(val.x, val.y, val.width, val.height);
}
CVAPI(void) core_FileStorage_shift_Rect2f(cv::FileStorage *fs, MyCvRect2D32f val)
{
    (*fs) << cv::Rect2f(val.x, val.y, val.width, val.height);
}
CVAPI(void) core_FileStorage_shift_Rect2d(cv::FileStorage *fs, MyCvRect2D64f val)
{
    (*fs) << cv::Rect2d(val.x, val.y, val.width, val.height);
}
CVAPI(void) core_FileStorage_shift_Scalar(cv::FileStorage *fs, MyCvScalar val)
{
    (*fs) << cpp(val);
}

CVAPI(void) core_FileStorage_shift_Vec2i(cv::FileStorage *fs, CvVec2i v)
{
    (*fs) << cv::Vec2i(v.val[0], v.val[1]);
}
CVAPI(void) core_FileStorage_shift_Vec3i(cv::FileStorage *fs, CvVec3i v)
{
    (*fs) << cv::Vec3i(v.val[0], v.val[1], v.val[2]);
}
CVAPI(void) core_FileStorage_shift_Vec4i(cv::FileStorage *fs, CvVec4i v)
{
    (*fs) << cv::Vec4i(v.val[0], v.val[1], v.val[2], v.val[3]);
}
CVAPI(void) core_FileStorage_shift_Vec6i(cv::FileStorage *fs, CvVec6i v)
{
    (*fs) << cv::Vec6i(v.val[0], v.val[1], v.val[2], v.val[3], v.val[4], v.val[5]);
}
CVAPI(void) core_FileStorage_shift_Vec2d(cv::FileStorage *fs, CvVec2d v)
{
    (*fs) << cv::Vec2d(v.val[0], v.val[1]);
}
CVAPI(void) core_FileStorage_shift_Vec3d(cv::FileStorage *fs, CvVec3d v)
{
    (*fs) << cv::Vec3d(v.val[0], v.val[1], v.val[2]);
}
CVAPI(void) core_FileStorage_shift_Vec4d(cv::FileStorage *fs, CvVec4d v)
{
    (*fs) << cv::Vec4d(v.val[0], v.val[1], v.val[2], v.val[3]);
}
CVAPI(void) core_FileStorage_shift_Vec6d(cv::FileStorage *fs, CvVec6d v)
{
    (*fs) << cv::Vec6d(v.val[0], v.val[1], v.val[2], v.val[3], v.val[4], v.val[5]);
}
CVAPI(void) core_FileStorage_shift_Vec2f(cv::FileStorage *fs, CvVec2f v)
{
    (*fs) << cv::Vec2f(v.val[0], v.val[1]);
}
CVAPI(void) core_FileStorage_shift_Vec3f(cv::FileStorage *fs, CvVec3f v)
{
    (*fs) << cv::Vec3f(v.val[0], v.val[1], v.val[2]);
}
CVAPI(void) core_FileStorage_shift_Vec4f(cv::FileStorage *fs, CvVec4f v)
{
    (*fs) << cv::Vec4f(v.val[0], v.val[1], v.val[2], v.val[3]);
}
CVAPI(void) core_FileStorage_shift_Vec6f(cv::FileStorage *fs, CvVec6f v)
{
    (*fs) << cv::Vec6f(v.val[0], v.val[1], v.val[2], v.val[3], v.val[4], v.val[5]);
}
CVAPI(void) core_FileStorage_shift_Vec2b(cv::FileStorage *fs, CvVec2b v)
{
    (*fs) << cv::Vec2b(v.val[0], v.val[1]);
}
CVAPI(void) core_FileStorage_shift_Vec3b(cv::FileStorage *fs, CvVec3b v)
{
    (*fs) << cv::Vec3b(v.val[0], v.val[1], v.val[2]);
}
CVAPI(void) core_FileStorage_shift_Vec4b(cv::FileStorage *fs, CvVec4b v)
{
    (*fs) << cv::Vec4b(v.val[0], v.val[1], v.val[2], v.val[3]);
}
CVAPI(void) core_FileStorage_shift_Vec6b(cv::FileStorage *fs, CvVec6b v)
{
    (*fs) << cv::Vec6b(v.val[0], v.val[1], v.val[2], v.val[3], v.val[4], v.val[5]);
}
CVAPI(void) core_FileStorage_shift_Vec2s(cv::FileStorage *fs, CvVec2s v)
{
    (*fs) << cv::Vec2s(v.val[0], v.val[1]);
}
CVAPI(void) core_FileStorage_shift_Vec3s(cv::FileStorage *fs, CvVec3s v)
{
    (*fs) << cv::Vec3s(v.val[0], v.val[1], v.val[2]);
}
CVAPI(void) core_FileStorage_shift_Vec4s(cv::FileStorage *fs, CvVec4s v)
{
    (*fs) << cv::Vec4s(v.val[0], v.val[1], v.val[2], v.val[3]);
}
CVAPI(void) core_FileStorage_shift_Vec6s(cv::FileStorage *fs, CvVec6s v)
{
    (*fs) << cv::Vec6s(v.val[0], v.val[1], v.val[2], v.val[3], v.val[4], v.val[5]);
}
CVAPI(void) core_FileStorage_shift_Vec2w(cv::FileStorage *fs, CvVec2w v)
{
    (*fs) << cv::Vec2w(v.val[0], v.val[1]);
}
CVAPI(void) core_FileStorage_shift_Vec3w(cv::FileStorage *fs, CvVec3w v)
{
    (*fs) << cv::Vec3w(v.val[0], v.val[1], v.val[2]);
}
CVAPI(void) core_FileStorage_shift_Vec4w(cv::FileStorage *fs, CvVec4w v)
{
    (*fs) << cv::Vec4w(v.val[0], v.val[1], v.val[2], v.val[3]);
}
CVAPI(void) core_FileStorage_shift_Vec6w(cv::FileStorage *fs, CvVec6w v)
{
    (*fs) << cv::Vec6w(v.val[0], v.val[1], v.val[2], v.val[3], v.val[4], v.val[5]);
}

#pragma endregion

#pragma region FileNode

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

#pragma endregion

#pragma region FileNodeIterator

CVAPI(cv::FileNodeIterator*) core_FileNodeIterator_new1()
{
    return new cv::FileNodeIterator;
}
CVAPI(cv::FileNodeIterator*) core_FileNodeIterator_new2(cv::FileNodeIterator *obj)
{
    return new cv::FileNodeIterator(*obj);
}

CVAPI(void) core_FileNodeIterator_delete(cv::FileNodeIterator *obj)
{
    delete obj;
}

CVAPI(cv::FileNode*) core_FileNodeIterator_operatorAsterisk(cv::FileNodeIterator *obj)
{
    return new cv::FileNode(*(*obj));
}

CVAPI(void) core_FileNodeIterator_operatorIncrement(cv::FileNodeIterator *obj)
{
    ++(*obj);
}
CVAPI(void) core_FileNodeIterator_operatorDecrement(cv::FileNodeIterator *obj)
{
    --(*obj);
}

CVAPI(void) core_FileNodeIterator_operatorPlusEqual(cv::FileNodeIterator *obj, int ofs)
{
    (*obj) += ofs;
}
CVAPI(void) core_FileNodeIterator_operatorMinusEqual(cv::FileNodeIterator *obj, int ofs)
{
    (*obj) -= ofs;
}

CVAPI(cv::FileNodeIterator*) core_FileNodeIterator_readRaw(
    cv::FileNodeIterator *obj, const char *fmt, uchar* vec, size_t maxCount)
{
    return &(obj->readRaw(fmt, vec, maxCount));
}

CVAPI(int) core_FileNodeIterator_operatorEqual(cv::FileNodeIterator *it1, cv::FileNodeIterator *it2)
{
    return ((*it1) == (*it2)) ? 1 : 0;
}

CVAPI(int) core_FileNodeIterator_operatorNotEqual(cv::FileNodeIterator *it1, cv::FileNodeIterator *it2)
{
    return ((*it1) != (*it2)) ? 1 : 0;
}

CVAPI(ptrdiff_t) core_FileNodeIterator_operatorMinus(cv::FileNodeIterator *it1, cv::FileNodeIterator *it2)
{
    return (*it1) - (*it2);
}

CVAPI(int) core_FileNodeIterator_operatorLessThan(cv::FileNodeIterator *it1, cv::FileNodeIterator *it2)
{
    return (*it1) < (*it2);
}

#pragma endregion 

#endif