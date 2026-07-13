#pragma once
#ifndef NO_CONTRIB
#include "include_opencv.h"

// Keep the exported functions compact while using the repository's cvTry exception boundary.
#define BEGIN_WRAP return cvTry([&] {
#define END_WRAP });

using cv::linemod::ColorGradient;
using cv::linemod::DepthNormal;
using cv::linemod::Detector;
using cv::linemod::Feature;
using cv::linemod::Match;
using cv::linemod::Modality;
using cv::linemod::QuantizedPyramid;
using cv::linemod::Template;

CVAPI(ExceptionStatus) rgbd_linemod_ColorGradient_create(
    float weakThreshold, size_t numFeatures, float strongThreshold,
    cv::Ptr<Modality> **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Ptr<Modality>(ColorGradient::create(weakThreshold, numFeatures, strongThreshold));
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_linemod_DepthNormal_create(
    int distanceThreshold, int differenceThreshold, size_t numFeatures, int extractThreshold,
    cv::Ptr<Modality> **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Ptr<Modality>(DepthNormal::create(
        distanceThreshold, differenceThreshold, numFeatures, extractThreshold));
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_linemod_Modality_create(
    const char *modalityType, cv::Ptr<Modality> **returnValue)
{
    BEGIN_WRAP *returnValue = new cv::Ptr<Modality>(Modality::create(modalityType)); END_WRAP
}

CVAPI(ExceptionStatus) rgbd_linemod_Modality_createFromFileNode(
    cv::FileNode *node, cv::Ptr<Modality> **returnValue)
{ BEGIN_WRAP *returnValue = new cv::Ptr<Modality>(Modality::create(*node)); END_WRAP }

CVAPI(ExceptionStatus) rgbd_linemod_Ptr_Modality_delete(cv::Ptr<Modality> *obj)
{ BEGIN_WRAP delete obj; END_WRAP }

CVAPI(ExceptionStatus) rgbd_linemod_Ptr_Modality_get(
    cv::Ptr<Modality> *obj, Modality **returnValue)
{ BEGIN_WRAP *returnValue = obj->get(); END_WRAP }

CVAPI(ExceptionStatus) rgbd_linemod_Modality_name(Modality *obj, std::string *returnValue)
{ BEGIN_WRAP *returnValue = obj->name(); END_WRAP }

CVAPI(ExceptionStatus) rgbd_linemod_Modality_process(
    Modality *obj, cv::Mat *src, cv::Mat *mask, cv::Ptr<QuantizedPyramid> **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Ptr<QuantizedPyramid>(obj->process(*src, mask == nullptr ? cv::Mat() : *mask));
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_linemod_Modality_read(Modality *obj, cv::FileNode *node)
{ BEGIN_WRAP obj->read(*node); END_WRAP }

CVAPI(ExceptionStatus) rgbd_linemod_Modality_write(Modality *obj, cv::FileStorage *fs)
{ BEGIN_WRAP obj->write(*fs); END_WRAP }

CVAPI(ExceptionStatus) rgbd_linemod_ColorGradient_get(
    Modality *obj, float *weakThreshold, size_t *numFeatures, float *strongThreshold)
{
    BEGIN_WRAP
    const auto p = dynamic_cast<ColorGradient *>(obj);
    if (p == nullptr) CV_Error(cv::Error::StsBadArg, "Modality is not ColorGradient");
    *weakThreshold = p->weak_threshold; *numFeatures = p->num_features; *strongThreshold = p->strong_threshold;
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_linemod_DepthNormal_get(
    Modality *obj, int *distanceThreshold, int *differenceThreshold, size_t *numFeatures, int *extractThreshold)
{
    BEGIN_WRAP
    const auto p = dynamic_cast<DepthNormal *>(obj);
    if (p == nullptr) CV_Error(cv::Error::StsBadArg, "Modality is not DepthNormal");
    *distanceThreshold = p->distance_threshold; *differenceThreshold = p->difference_threshold;
    *numFeatures = p->num_features; *extractThreshold = p->extract_threshold;
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_linemod_Ptr_QuantizedPyramid_delete(cv::Ptr<QuantizedPyramid> *obj)
{ BEGIN_WRAP delete obj; END_WRAP }

CVAPI(ExceptionStatus) rgbd_linemod_Ptr_QuantizedPyramid_get(
    cv::Ptr<QuantizedPyramid> *obj, QuantizedPyramid **returnValue)
{ BEGIN_WRAP *returnValue = obj->get(); END_WRAP }

CVAPI(ExceptionStatus) rgbd_linemod_QuantizedPyramid_quantize(QuantizedPyramid *obj, cv::Mat *dst)
{ BEGIN_WRAP obj->quantize(*dst); END_WRAP }

CVAPI(ExceptionStatus) rgbd_linemod_QuantizedPyramid_pyrDown(QuantizedPyramid *obj)
{ BEGIN_WRAP obj->pyrDown(); END_WRAP }

CVAPI(ExceptionStatus) rgbd_linemod_QuantizedPyramid_extractTemplate(
    QuantizedPyramid *obj, int *width, int *height, int *pyramidLevel,
    std::vector<cv::Vec4i> *features, int *returnValue)
{
    BEGIN_WRAP
    Template t;
    *returnValue = obj->extractTemplate(t) ? 1 : 0;
    *width = t.width; *height = t.height; *pyramidLevel = t.pyramid_level;
    features->clear();
    for (const auto &f : t.features) features->emplace_back(f.x, f.y, f.label, 0);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_linemod_Detector_new(
    cv::Ptr<Modality> **modalities, int modalitiesLength, int *tPyramid, int tPyramidLength,
    Detector **returnValue)
{
    BEGIN_WRAP
    std::vector<cv::Ptr<Modality>> mods;
    mods.reserve(modalitiesLength);
    for (int i = 0; i < modalitiesLength; i++) mods.push_back(*modalities[i]);
    *returnValue = new Detector(mods, std::vector<int>(tPyramid, tPyramid + tPyramidLength));
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_linemod_Detector_newEmpty(Detector **returnValue)
{ BEGIN_WRAP *returnValue = new Detector(); END_WRAP }

CVAPI(ExceptionStatus) rgbd_linemod_getDefaultLINE(Detector **returnValue)
{ BEGIN_WRAP *returnValue = new Detector(*cv::linemod::getDefaultLINE()); END_WRAP }

CVAPI(ExceptionStatus) rgbd_linemod_getDefaultLINEMOD(Detector **returnValue)
{ BEGIN_WRAP *returnValue = new Detector(*cv::linemod::getDefaultLINEMOD()); END_WRAP }

CVAPI(ExceptionStatus) rgbd_linemod_Detector_delete(Detector *obj)
{ BEGIN_WRAP delete obj; END_WRAP }

CVAPI(ExceptionStatus) rgbd_linemod_Detector_addTemplate(
    Detector *obj, std::vector<cv::Mat> *sources, const char *classId,
    cv::Mat *objectMask, interop::Rect *boundingBox, int *returnValue)
{
    BEGIN_WRAP
    cv::Rect rect;
    *returnValue = obj->addTemplate(*sources, classId, *objectMask, boundingBox == nullptr ? nullptr : &rect);
    if (boundingBox != nullptr) *boundingBox = c(rect);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_linemod_Detector_addSyntheticTemplate(
    Detector *obj, std::vector<cv::Vec4i> *headers, std::vector<cv::Vec4i> *features,
    const char *classId, int *returnValue)
{
    BEGIN_WRAP
    std::vector<Template> templates;
    size_t featureOffset = 0;
    for (const auto &h : *headers)
    {
        Template t;
        t.width = h[0]; t.height = h[1]; t.pyramid_level = h[2];
        const auto count = static_cast<size_t>(h[3]);
        if (featureOffset + count > features->size())
            CV_Error(cv::Error::StsBadArg, "Invalid flattened LINEMOD feature data");
        for (size_t i = 0; i < count; i++)
        {
            const auto &f = (*features)[featureOffset++];
            t.features.emplace_back(f[0], f[1], f[2]);
        }
        templates.push_back(std::move(t));
    }
    if (featureOffset != features->size())
        CV_Error(cv::Error::StsBadArg, "Invalid flattened LINEMOD feature data");
    *returnValue = obj->addSyntheticTemplate(templates, classId);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_linemod_Detector_match(
    Detector *obj, std::vector<cv::Mat> *sources, float threshold,
    std::vector<cv::Vec4f> *values, std::vector<cv::String> *classIds,
    std::vector<cv::String> *filterClassIds, std::vector<cv::Mat> *quantizedImages,
    std::vector<cv::Mat> *masks)
{
    BEGIN_WRAP
    std::vector<Match> matches;
    obj->match(*sources, threshold, matches,
        filterClassIds == nullptr ? std::vector<cv::String>() : *filterClassIds,
        quantizedImages == nullptr ? cv::noArray() : cv::OutputArrayOfArrays(*quantizedImages),
        masks == nullptr ? std::vector<cv::Mat>() : *masks);
    values->clear(); classIds->clear();
    for (const auto &m : matches)
    {
        values->emplace_back(static_cast<float>(m.x), static_cast<float>(m.y), m.similarity,
            static_cast<float>(m.template_id));
        classIds->push_back(m.class_id);
    }
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_linemod_Detector_getT(Detector *obj, int level, int *returnValue)
{ BEGIN_WRAP *returnValue = obj->getT(level); END_WRAP }
CVAPI(ExceptionStatus) rgbd_linemod_Detector_pyramidLevels(Detector *obj, int *returnValue)
{ BEGIN_WRAP *returnValue = obj->pyramidLevels(); END_WRAP }
CVAPI(ExceptionStatus) rgbd_linemod_Detector_numTemplates(Detector *obj, int *returnValue)
{ BEGIN_WRAP *returnValue = obj->numTemplates(); END_WRAP }
CVAPI(ExceptionStatus) rgbd_linemod_Detector_numTemplatesByClass(Detector *obj, const char *classId, int *returnValue)
{ BEGIN_WRAP *returnValue = obj->numTemplates(classId); END_WRAP }
CVAPI(ExceptionStatus) rgbd_linemod_Detector_numClasses(Detector *obj, int *returnValue)
{ BEGIN_WRAP *returnValue = obj->numClasses(); END_WRAP }
CVAPI(ExceptionStatus) rgbd_linemod_Detector_classIds(Detector *obj, std::vector<cv::String> *returnValue)
{ BEGIN_WRAP *returnValue = obj->classIds(); END_WRAP }

CVAPI(ExceptionStatus) rgbd_linemod_Detector_getTemplates(
    Detector *obj, const char *classId, int templateId,
    std::vector<cv::Vec4i> *headers, std::vector<cv::Vec4i> *features)
{
    BEGIN_WRAP
    headers->clear(); features->clear();
    for (const auto &t : obj->getTemplates(classId, templateId))
    {
        headers->emplace_back(t.width, t.height, t.pyramid_level, static_cast<int>(t.features.size()));
        for (const auto &f : t.features) features->emplace_back(f.x, f.y, f.label, 0);
    }
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_linemod_Detector_getModalitiesSize(Detector *obj, int *returnValue)
{ BEGIN_WRAP *returnValue = static_cast<int>(obj->getModalities().size()); END_WRAP }

CVAPI(ExceptionStatus) rgbd_linemod_Detector_getModality(
    Detector *obj, int index, cv::Ptr<Modality> **returnValue)
{
    BEGIN_WRAP *returnValue = new cv::Ptr<Modality>(obj->getModalities().at(index)); END_WRAP
}

CVAPI(ExceptionStatus) rgbd_linemod_Detector_read(Detector *obj, cv::FileNode *node)
{ BEGIN_WRAP obj->read(*node); END_WRAP }
CVAPI(ExceptionStatus) rgbd_linemod_Detector_write(Detector *obj, cv::FileStorage *fs)
{ BEGIN_WRAP obj->write(*fs); END_WRAP }
CVAPI(ExceptionStatus) rgbd_linemod_Detector_readClass(
    Detector *obj, cv::FileNode *node, const char *classIdOverride, std::string *returnValue)
{ BEGIN_WRAP *returnValue = obj->readClass(*node, classIdOverride); END_WRAP }
CVAPI(ExceptionStatus) rgbd_linemod_Detector_writeClass(
    Detector *obj, const char *classId, cv::FileStorage *fs)
{ BEGIN_WRAP obj->writeClass(classId, *fs); END_WRAP }
CVAPI(ExceptionStatus) rgbd_linemod_Detector_readClasses(
    Detector *obj, std::vector<cv::String> *classIds, const char *format)
{ BEGIN_WRAP obj->readClasses(*classIds, format); END_WRAP }
CVAPI(ExceptionStatus) rgbd_linemod_Detector_writeClasses(Detector *obj, const char *format)
{ BEGIN_WRAP obj->writeClasses(format); END_WRAP }
#undef BEGIN_WRAP
#undef END_WRAP
#endif
