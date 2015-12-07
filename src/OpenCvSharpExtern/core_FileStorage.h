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
    return obj->fs.obj;
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
    std::string &elname = obj->elname;
    return (elname.c_str());
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

CVAPI(CvFileNode*) core_FileNode_toLegacy(cv::FileNode *obj)
{
    return *(*obj);
}

CVAPI(void) core_FileNode_readRaw(cv::FileNode *obj, const char *fmt, uchar* vec, size_t len)
{
    obj->readRaw(fmt, vec, len);
}
CVAPI(void*) core_FileNode_readObj(cv::FileNode *obj)
{
    return obj->readObj();
}

#pragma endregion

#endif