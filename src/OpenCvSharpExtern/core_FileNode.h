#pragma once

#include "include_opencv.h"

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

CVAPI(ExceptionStatus) core_FileNode_new1(cv::FileNode **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::FileNode();
    });
}

CVAPI(ExceptionStatus) core_FileNode_delete(cv::FileNode *node)
{
    return cvTry([&] {
        delete node;
    });
}

CVAPI(ExceptionStatus) core_FileNode_operatorThis_byString(cv::FileNode *obj, const char *nodeName, cv::FileNode **returnValue)
{
    return cvTry([&] {
        const auto ret = (*obj)[nodeName];
        *returnValue = new cv::FileNode(ret);
    });
}
CVAPI(ExceptionStatus) core_FileNode_operatorThis_byInt(cv::FileNode *obj, int i, cv::FileNode **returnValue)
{
    return cvTry([&] {
        const auto ret = (*obj)[i];
        *returnValue = new cv::FileNode(ret);
    });
}

CVAPI(ExceptionStatus) core_FileNode_type(cv::FileNode *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->type();
    });
}

CVAPI(ExceptionStatus) core_FileNode_empty(cv::FileNode *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->empty() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_FileNode_isNone(cv::FileNode *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->isNone() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) core_FileNode_isSeq(cv::FileNode *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->isSeq() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) core_FileNode_isMap(cv::FileNode *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->isMap() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) core_FileNode_isInt(cv::FileNode *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->isInt() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) core_FileNode_isReal(cv::FileNode *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->isReal() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) core_FileNode_isString(cv::FileNode *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->isString() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) core_FileNode_isNamed(cv::FileNode *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->isNamed() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_FileNode_name(cv::FileNode *obj, std::string *buf)
{
    return cvTry([&] {
        buf->assign(obj->name());
    });
}
CVAPI(ExceptionStatus) core_FileNode_size(cv::FileNode *obj, size_t *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->size();
    });
}

CVAPI(ExceptionStatus) core_FileNode_toInt(cv::FileNode *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = static_cast<int>(*obj);
    });
}
CVAPI(ExceptionStatus) core_FileNode_toFloat(cv::FileNode *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = static_cast<float>(*obj);
    });
}
CVAPI(ExceptionStatus) core_FileNode_toDouble(cv::FileNode *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = static_cast<double>(*obj);
    });
}
CVAPI(ExceptionStatus) core_FileNode_toString(cv::FileNode *obj, std::string *buf)
{
    return cvTry([&] {
        buf->assign(*obj);
    });
}
CVAPI(ExceptionStatus) core_FileNode_toMat(cv::FileNode *obj, cv::Mat *m)
{
    return cvTry([&] {
        (*obj) >> (*m);
    });
}

CVAPI(ExceptionStatus) core_FileNode_begin(cv::FileNode *obj, cv::FileNodeIterator **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::FileNodeIterator(obj->begin());
    });
}
CVAPI(ExceptionStatus) core_FileNode_end(cv::FileNode *obj, cv::FileNodeIterator **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::FileNodeIterator(obj->end());
    });
}

CVAPI(ExceptionStatus) core_FileNode_readRaw(cv::FileNode *obj, const char *fmt, uchar* vec, size_t len)
{
    return cvTry([&] {
        obj->readRaw(fmt, vec, len);
    });
}

CVAPI(ExceptionStatus) core_FileNode_read_int(cv::FileNode *node, int *value, int default_value)
{
    return cvTry([&] {
        int temp;
        cv::read(*node, temp, default_value);
        *value = temp;
    });
}
CVAPI(ExceptionStatus) core_FileNode_read_float(cv::FileNode *node, float *value, float default_value)
{
    return cvTry([&] {
        float temp;
        cv::read(*node, temp, default_value);
        *value = temp;
    });
}
CVAPI(ExceptionStatus) core_FileNode_read_double(cv::FileNode *node, double *value, double default_value)
{
    return cvTry([&] {
        double temp;
        cv::read(*node, temp, default_value);
        *value = temp;
    });
}
CVAPI(ExceptionStatus) core_FileNode_read_String(cv::FileNode *node, std::string *value, const char *default_value)
{
    return cvTry([&] {
        cv::String str;
        cv::read(*node, str, (default_value == nullptr) ? cv::String() : cv::String(default_value));
        value->assign(str);
    });
}
CVAPI(ExceptionStatus) core_FileNode_read_Mat(cv::FileNode *node, cv::Mat *mat, cv::Mat *default_mat)
{
    return cvTry([&] {
        cv::read(*node, *mat, entity(default_mat));
    });
}
CVAPI(ExceptionStatus) core_FileNode_read_SparseMat(cv::FileNode *node, cv::SparseMat *mat, cv::SparseMat *default_mat)
{
    return cvTry([&] {
        cv::read(*node, *mat, entity(default_mat));
    });
}
CVAPI(ExceptionStatus) core_FileNode_read_vectorOfKeyPoint(cv::FileNode *node, std::vector<cv::KeyPoint> *keypoints)
{
    return cvTry([&] {
        cv::read(*node, *keypoints);
    });
}
CVAPI(ExceptionStatus) core_FileNode_read_vectorOfDMatch(cv::FileNode *node, std::vector<cv::DMatch> *matches)
{
    return cvTry([&] {
        cv::read(*node, *matches);
    });
}


CVAPI(ExceptionStatus) core_FileNode_read_Range(cv::FileNode *node, interop::Range *returnValue)
{
    return cvTry([&] {
        cv::Range ret;
        (*node) >> ret;
        *returnValue = c(ret);
    });
}
CVAPI(ExceptionStatus) core_FileNode_read_KeyPoint(cv::FileNode *node, interop::KeyPoint *returnValue)
{   
    return cvTry([&] { 
        cv::KeyPoint ret;
        (*node) >> ret;
        *returnValue = c(ret);
    });
}
CVAPI(ExceptionStatus) core_FileNode_read_DMatch(cv::FileNode *node, interop::DMatch *returnValue)
{
    return cvTry([&] {
        cv::DMatch ret;
        (*node) >> ret;
        *returnValue = c(ret);
    });
}

CVAPI(ExceptionStatus) core_FileNode_read_Point2i(cv::FileNode *node, interop::Point *returnValue)
{
    return cvTry([&] {
        cv::Point2i ret;
        (*node) >> ret;
        *returnValue = interop::Point{ ret.x, ret.y };
    });
}
CVAPI(ExceptionStatus) core_FileNode_read_Point2f(cv::FileNode *node, interop::Point2f *returnValue)
{
    return cvTry([&] {
        cv::Point2f ret;
        (*node) >> ret;
        *returnValue = interop::Point2f{ ret.x, ret.y };
    });
}
CVAPI(ExceptionStatus) core_FileNode_read_Point2d(cv::FileNode *node, interop::Point2d *returnValue)
{
    return cvTry([&] {
        cv::Point2d ret;
        (*node) >> ret;
        *returnValue = interop::Point2d{ ret.x, ret.y };
    });
}

CVAPI(ExceptionStatus) core_FileNode_read_Point3i(cv::FileNode *node, interop::Point3i *returnValue)
{
    return cvTry([&] {
        cv::Point3i ret;
        (*node) >> ret;
        *returnValue = interop::Point3i{ ret.x, ret.y, ret.z };
    });
}
CVAPI(ExceptionStatus) core_FileNode_read_Point3f(cv::FileNode *node, interop::Point3f *returnValue)
{
    return cvTry([&] {
        cv::Point3f ret;
        (*node) >> ret;
        *returnValue = interop::Point3f{ ret.x, ret.y, ret.z };
    });
}
CVAPI(ExceptionStatus) core_FileNode_read_Point3d(cv::FileNode *node, interop::Point3d *returnValue)
{
    return cvTry([&] {
        cv::Point3d ret;
        (*node) >> ret;
        *returnValue = interop::Point3d{ ret.x, ret.y, ret.z };
    });
}

CVAPI(ExceptionStatus) core_FileNode_read_Size2i(cv::FileNode *node, interop::Size *returnValue)
{
    return cvTry([&] {
        cv::Size2i ret;
        (*node) >> ret;
        *returnValue = interop::Size{ ret.width, ret.height };
    });
}
CVAPI(ExceptionStatus) core_FileNode_read_Size2f(cv::FileNode *node, interop::Size2f *returnValue)
{
    return cvTry([&] {
        cv::Size2f ret;
        (*node) >> ret;
        *returnValue = interop::Size2f{ ret.width, ret.height };
    });
}
CVAPI(ExceptionStatus) core_FileNode_read_Size2d(cv::FileNode *node, interop::Size2d *returnValue)
{
    return cvTry([&] {
        cv::Size2d ret;
        (*node) >> ret;
        *returnValue = interop::Size2d{ ret.width, ret.height };
    });
}

CVAPI(ExceptionStatus) core_FileNode_read_Rect2i(cv::FileNode *node, interop::Rect *returnValue)
{
    return cvTry([&] {
        cv::Rect2i ret;
        (*node) >> ret;
        *returnValue = interop::Rect{ ret.x, ret.y, ret.width, ret.height };
    });
}
CVAPI(ExceptionStatus) core_FileNode_read_Rect2f(cv::FileNode *node, interop::Rect2f *returnValue)
{
    return cvTry([&] {
        cv::Rect2f ret;
        (*node) >> ret;
        *returnValue = interop::Rect2f{ ret.x, ret.y, ret.width, ret.height };
    });
}
CVAPI(ExceptionStatus) core_FileNode_read_Rect2d(cv::FileNode *node, interop::Rect2d *returnValue)
{
    return cvTry([&] {
        cv::Rect2d ret;
        (*node) >> ret;
        *returnValue = interop::Rect2d{ ret.x, ret.y, ret.width, ret.height };
    });
}

CVAPI(ExceptionStatus) core_FileNode_read_Scalar(cv::FileNode *node, interop::Scalar *returnValue)
{
    return cvTry([&] {
        cv::Scalar s;
        (*node) >> s;
        *returnValue = interop::Scalar{};
        returnValue->val[0] = s.val[0];
        returnValue->val[1] = s.val[1];
        returnValue->val[2] = s.val[2];
        returnValue->val[3] = s.val[3];
    });
}

CVAPI(ExceptionStatus) core_FileNode_read_Vec2i(cv::FileNode *node, interop::Vec2i *returnValue) { return cvTry([&] { cv::Vec2i v; (*node) >> v; interop::Vec2i ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec3i(cv::FileNode *node, interop::Vec3i *returnValue) { return cvTry([&] { cv::Vec3i v; (*node) >> v; interop::Vec3i ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec4i(cv::FileNode *node, interop::Vec4i *returnValue) { return cvTry([&] { cv::Vec4i v; (*node) >> v; interop::Vec4i ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec6i(cv::FileNode *node, interop::Vec6i *returnValue) { return cvTry([&] { cv::Vec6i v; (*node) >> v; interop::Vec6i ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec2d(cv::FileNode *node, interop::Vec2d *returnValue) { return cvTry([&] { cv::Vec2d v; (*node) >> v; interop::Vec2d ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec3d(cv::FileNode *node, interop::Vec3d *returnValue) { return cvTry([&] { cv::Vec3d v; (*node) >> v; interop::Vec3d ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec4d(cv::FileNode *node, interop::Vec4d *returnValue) { return cvTry([&] { cv::Vec4d v; (*node) >> v; interop::Vec4d ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec6d(cv::FileNode *node, interop::Vec6d *returnValue) { return cvTry([&] { cv::Vec6d v; (*node) >> v; interop::Vec6d ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec2f(cv::FileNode *node, interop::Vec2f *returnValue) { return cvTry([&] { cv::Vec2f v; (*node) >> v; interop::Vec2f ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec3f(cv::FileNode *node, interop::Vec3f *returnValue) { return cvTry([&] { cv::Vec3f v; (*node) >> v; interop::Vec3f ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec4f(cv::FileNode *node, interop::Vec4f *returnValue) { return cvTry([&] { cv::Vec4f v; (*node) >> v; interop::Vec4f ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec6f(cv::FileNode *node, interop::Vec6f *returnValue) { return cvTry([&] { cv::Vec6f v; (*node) >> v; interop::Vec6f ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec2b(cv::FileNode *node, interop::Vec2b *returnValue) { return cvTry([&] { cv::Vec2b v; (*node) >> v; interop::Vec2b ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec3b(cv::FileNode *node, interop::Vec3b *returnValue) { return cvTry([&] { cv::Vec3b v; (*node) >> v; interop::Vec3b ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec4b(cv::FileNode *node, interop::Vec4b *returnValue) { return cvTry([&] { cv::Vec4b v; (*node) >> v; interop::Vec4b ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec6b(cv::FileNode *node, interop::Vec6b *returnValue) { return cvTry([&] { cv::Vec6b v; (*node) >> v; interop::Vec6b ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec2s(cv::FileNode *node, interop::Vec2s *returnValue) { return cvTry([&] { cv::Vec2s v; (*node) >> v; interop::Vec2s ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec3s(cv::FileNode *node, interop::Vec3s *returnValue) { return cvTry([&] { cv::Vec3s v; (*node) >> v; interop::Vec3s ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec4s(cv::FileNode *node, interop::Vec4s *returnValue) { return cvTry([&] { cv::Vec4s v; (*node) >> v; interop::Vec4s ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec6s(cv::FileNode *node, interop::Vec6s *returnValue) { return cvTry([&] { cv::Vec6s v; (*node) >> v; interop::Vec6s ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec2w(cv::FileNode *node, interop::Vec2w *returnValue) { return cvTry([&] { cv::Vec2w v; (*node) >> v; interop::Vec2w ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec3w(cv::FileNode *node, interop::Vec3w *returnValue) { return cvTry([&] { cv::Vec3w v; (*node) >> v; interop::Vec3w ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec4w(cv::FileNode *node, interop::Vec4w *returnValue) { return cvTry([&] { cv::Vec4w v; (*node) >> v; interop::Vec4w ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }
CVAPI(ExceptionStatus) core_FileNode_read_Vec6w(cv::FileNode *node, interop::Vec6w *returnValue) { return cvTry([&] { cv::Vec6w v; (*node) >> v; interop::Vec6w ret; std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val)); *returnValue = ret; }); }


#pragma region FileNodeIterator

CVAPI(ExceptionStatus) core_FileNodeIterator_new1(cv::FileNodeIterator **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::FileNodeIterator;
    });
}

CVAPI(ExceptionStatus) core_FileNodeIterator_delete(cv::FileNodeIterator *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) core_FileNodeIterator_operatorAsterisk(cv::FileNodeIterator *obj, cv::FileNode **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::FileNode(*(*obj));
    });
}

CVAPI(ExceptionStatus) core_FileNodeIterator_operatorIncrement(cv::FileNodeIterator *obj, int *returnValue)
{
    return cvTry([&] {
        const size_t prev_remaining = obj->remaining(); 
        ++(*obj);
        *returnValue = (prev_remaining == obj->remaining()) ? 0 : 1;
    });
}

CVAPI(ExceptionStatus) core_FileNodeIterator_operatorPlusEqual(cv::FileNodeIterator *obj, int ofs, int *returnValue)
{
    return cvTry([&] {
        const size_t prev_remaining = obj->remaining();
        (*obj) += ofs;
        *returnValue = (prev_remaining == obj->remaining()) ? 0 : 1;
    });
}

CVAPI(ExceptionStatus) core_FileNodeIterator_readRaw(
    cv::FileNodeIterator *obj, const char *fmt, uchar* vec, size_t maxCount)
{
    return cvTry([&] {
        obj->readRaw(fmt, vec, maxCount);
    });
}

CVAPI(ExceptionStatus) core_FileNodeIterator_operatorEqual(cv::FileNodeIterator *it1, cv::FileNodeIterator *it2, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ((*it1) == (*it2)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_FileNodeIterator_operatorMinus(cv::FileNodeIterator *it1, cv::FileNodeIterator *it2, ptrdiff_t *returnValue)
{
    return cvTry([&] {
        *returnValue = (*it1) - (*it2);
    });
}

CVAPI(ExceptionStatus) core_FileNodeIterator_operatorLessThan(cv::FileNodeIterator *it1, cv::FileNodeIterator *it2, int *returnValue)
{
    return cvTry([&] {
        *returnValue = (*it1) < (*it2);
    });
}

#pragma endregion 
