#pragma once

#ifndef NO_STITCHING

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


// PyRotationWarper

CVAPI(ExceptionStatus) stitching_PyRotationWarper_new(const char *type, float scale, cv::PyRotationWarper **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::PyRotationWarper(cv::String(type), scale);
    });
}

CVAPI(ExceptionStatus) stitching_PyRotationWarper_delete(cv::PyRotationWarper *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) stitching_PyRotationWarper_warpPoint(
    cv::PyRotationWarper *obj, interop::Point2f pt,
    const interop::InputArrayProxy *k, const interop::InputArrayProxy *r,
    interop::Point2f *returnValue)
{
    return cvTry([&] {
        *returnValue = c(obj->warpPoint(cpp(pt), InProxy(*k), InProxy(*r)));
    });
}

CVAPI(ExceptionStatus) stitching_PyRotationWarper_warpPointBackward(
    cv::PyRotationWarper *obj, interop::Point2f pt,
    const interop::InputArrayProxy *k, const interop::InputArrayProxy *r,
    interop::Point2f *returnValue)
{
    return cvTry([&] {
        *returnValue = c(obj->warpPointBackward(cpp(pt), InProxy(*k), InProxy(*r)));
    });
}

CVAPI(ExceptionStatus) stitching_PyRotationWarper_buildMaps(
    cv::PyRotationWarper *obj, interop::Size srcSize,
    const interop::InputArrayProxy *k, const interop::InputArrayProxy *r,
    const interop::OutputArrayProxy *xmap, const interop::OutputArrayProxy *ymap,
    interop::Rect *returnValue)
{
    return cvTry([&] {
        *returnValue = c(obj->buildMaps(cpp(srcSize), InProxy(*k), InProxy(*r), OutProxy(*xmap), OutProxy(*ymap)));
    });
}

CVAPI(ExceptionStatus) stitching_PyRotationWarper_warp(
    cv::PyRotationWarper *obj,
    const interop::InputArrayProxy *src, const interop::InputArrayProxy *k, const interop::InputArrayProxy *r,
    int interpMode, int borderMode,
    const interop::OutputArrayProxy *dst,
    interop::Point *returnValue)
{
    return cvTry([&] {
        *returnValue = c(obj->warp(InProxy(*src), InProxy(*k), InProxy(*r), interpMode, borderMode, OutProxy(*dst)));
    });
}

CVAPI(ExceptionStatus) stitching_PyRotationWarper_warpBackward(
    cv::PyRotationWarper *obj,
    const interop::InputArrayProxy *src, const interop::InputArrayProxy *k, const interop::InputArrayProxy *r,
    int interpMode, int borderMode, interop::Size dstSize,
    const interop::OutputArrayProxy *dst)
{
    return cvTry([&] {
        obj->warpBackward(InProxy(*src), InProxy(*k), InProxy(*r), interpMode, borderMode, cpp(dstSize), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) stitching_PyRotationWarper_warpRoi(
    cv::PyRotationWarper *obj, interop::Size srcSize,
    const interop::InputArrayProxy *k, const interop::InputArrayProxy *r,
    interop::Rect *returnValue)
{
    return cvTry([&] {
        *returnValue = c(obj->warpRoi(cpp(srcSize), InProxy(*k), InProxy(*r)));
    });
}

CVAPI(ExceptionStatus) stitching_PyRotationWarper_getScale(cv::PyRotationWarper *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getScale();
    });
}
CVAPI(ExceptionStatus) stitching_PyRotationWarper_setScale(cv::PyRotationWarper *obj, float val)
{
    return cvTry([&] {
        obj->setScale(val);
    });
}


// WarperCreator concrete factories: constructor + destructor only.
// (WarperCreator::create() is intentionally not exposed - cv::PyRotationWarper already covers
// standalone warping, and these types exist only to be handed to Stitcher::setWarper().)

#define OCS_WARPER_CREATOR_CTOR_DTOR(NAME)                                                    \
    CVAPI(ExceptionStatus) stitching_##NAME##_new(cv::NAME **returnValue)                     \
    {                                                                                         \
        return cvTry([&] {                                                                    \
            *returnValue = new cv::NAME();                                                     \
        });                                                                                    \
    }                                                                                          \
    CVAPI(ExceptionStatus) stitching_##NAME##_delete(cv::NAME *obj)                           \
    {                                                                                         \
        return cvTry([&] {                                                                    \
            delete obj;                                                                        \
        });                                                                                    \
    }

OCS_WARPER_CREATOR_CTOR_DTOR(PlaneWarper)
OCS_WARPER_CREATOR_CTOR_DTOR(AffineWarper)
OCS_WARPER_CREATOR_CTOR_DTOR(CylindricalWarper)
OCS_WARPER_CREATOR_CTOR_DTOR(SphericalWarper)
OCS_WARPER_CREATOR_CTOR_DTOR(FisheyeWarper)
OCS_WARPER_CREATOR_CTOR_DTOR(StereographicWarper)
OCS_WARPER_CREATOR_CTOR_DTOR(MercatorWarper)
OCS_WARPER_CREATOR_CTOR_DTOR(TransverseMercatorWarper)

#undef OCS_WARPER_CREATOR_CTOR_DTOR

#define OCS_WARPER_CREATOR_AB_CTOR_DTOR(NAME)                                                 \
    CVAPI(ExceptionStatus) stitching_##NAME##_new(float a, float b, cv::NAME **returnValue)   \
    {                                                                                         \
        return cvTry([&] {                                                                    \
            *returnValue = new cv::NAME(a, b);                                                 \
        });                                                                                    \
    }                                                                                          \
    CVAPI(ExceptionStatus) stitching_##NAME##_delete(cv::NAME *obj)                           \
    {                                                                                         \
        return cvTry([&] {                                                                    \
            delete obj;                                                                        \
        });                                                                                    \
    }

OCS_WARPER_CREATOR_AB_CTOR_DTOR(CompressedRectilinearWarper)
OCS_WARPER_CREATOR_AB_CTOR_DTOR(CompressedRectilinearPortraitWarper)
OCS_WARPER_CREATOR_AB_CTOR_DTOR(PaniniWarper)
OCS_WARPER_CREATOR_AB_CTOR_DTOR(PaniniPortraitWarper)

#undef OCS_WARPER_CREATOR_AB_CTOR_DTOR

#endif // NO_STITCHING
