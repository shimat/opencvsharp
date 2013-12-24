/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CVBLOBWRAPPER_H_
#define _CVBLOBWRAPPER_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#pragma warning(disable: 4715)
#endif

#include "cvblob.h"

#pragma region Methods
CVAPI(unsigned int) cvb_cvLabel(IplImage *img, IplImage *imgOut, cvb::CvBlobs *blobs)
{
	return cvb::cvLabel(img, imgOut, *blobs);
}
CVAPI(void) cvb_cvFilterLabels(IplImage *imgIn, IplImage *imgOut, cvb::CvBlobs *blobs)
{
	cvb::cvFilterLabels(imgIn, imgOut, *blobs);
}


CVAPI(void) cvb_cvReleaseBlob(cvb::CvBlob *blob)
{
	cvb::cvReleaseBlob(blob);
}
CVAPI(void) cvb_cvReleaseBlobs(cvb::CvBlobs *blobs)
{
	cvb::cvReleaseBlobs(*blobs);
}
CVAPI(cvb::CvLabel) cvb_cvGreaterBlob(cvb::CvBlobs *blobs)
{
	return cvb::cvGreaterBlob(*blobs);
}
CVAPI(void) cvb_cvFilterByArea(cvb::CvBlobs *blobs, unsigned int minArea, unsigned int maxArea)
{
	cvb::cvFilterByArea(*blobs, minArea, maxArea);
}
CVAPI(CvPoint2D64f) cvb_cvCentroid(cvb::CvBlob *blob)
{
	return cvb::cvCentroid(blob);
}
/*CVAPI(void) cvb_cvCentralMoments(cvb::CvBlob *blob, const IplImage *img)
{
	cvb::cvCentralMoments(blob, img);
}*/
CVAPI(double) cvb_cvAngle(cvb::CvBlob *blob)
{
	return cvb::cvAngle(blob);
}
CVAPI(void) cvb_cvRenderBlobs(const IplImage *imgLabel, cvb::CvBlobs *blobs, IplImage *imgSource, IplImage *imgDest, unsigned short mode, double alpha)
{
	cvb::cvRenderBlobs(imgLabel, *blobs, imgSource, imgDest, mode, alpha);
}  
CVAPI(void) cvb_cvSetImageROItoBlob(IplImage *img, const cvb::CvBlob *blob)
{
    cvb::cvSetImageROItoBlob(img, blob);
}
/*
CVAPI(cvb::CvContourChainCode*) cvb_cvGetContour_(const cvb::CvBlob *blob, const IplImage *img)
{
	return cvb::cvGetContour(blob, img);
}
//*/
CVAPI(void) cvb_cvRenderContourChainCode(const cvb::CvContourChainCode *contour, const IplImage *img, CvScalar color)
{
	cvb::cvRenderContourChainCode(contour, img, color);
}
CVAPI(cvb::CvContourPolygon*) cvb_cvConvertChainCodesToPolygon(cvb::CvContourChainCode const *cc)
{
	return cvb::cvConvertChainCodesToPolygon(cc);
}
CVAPI(void) cvb_cvRenderContourPolygon(const cvb::CvContourPolygon *contour, IplImage *img, CvScalar color)
{
	cvb::cvRenderContourPolygon(contour, img, color);
}
CVAPI(void) cvb_cvUpdateTracks(const cvb::CvBlobs* b, cvb::CvTracks* t, double thDistance, unsigned int thInactive)
{
	cvb::cvUpdateTracks(*b, *t, thDistance, thInactive);
}
CVAPI(void) cvb_cvRenderTracks(cvb::CvTracks *tracks, IplImage *imgSource, IplImage *imgDest, unsigned short mode, CvFont *font)
{
	cvb::cvRenderTracks(*tracks, imgSource, imgDest, mode, font);
}
CVAPI(cvb::CvLabel) cvb_cvGetLabel(const IplImage *img, unsigned int x, unsigned int y)
{
	return cvb::cvGetLabel(img, x, y);
}
CVAPI(double) cvb_cvContourPolygonArea(const cvb::CvContourPolygon *p)
{
	return cvb::cvContourPolygonArea(p);
}
CVAPI(double) cvb_cvContourPolygonPerimeter(const cvb::CvContourPolygon *p)	
{
	return cvb::cvContourPolygonPerimeter(p);
}
CVAPI(cvb::CvContourPolygon*) cvb_cvSimplifyPolygon(const cvb::CvContourPolygon *p, double delta)
{
	return cvb::cvSimplifyPolygon(p, delta);
}
CVAPI(cvb::CvContourPolygon*) cvb_cvPolygonContourConvexHull(const cvb::CvContourPolygon *p)
{
	return cvb::cvPolygonContourConvexHull(p);
}
CVAPI(void) cvb_cvWriteContourPolygonCSV(const cvb::CvContourPolygon* p, const char* filename)
{
	std::string filenameStr = filename;
	cvb::cvWriteContourPolygonCSV(*p, filenameStr);
}
CVAPI(void) cvb_cvWriteContourPolygonSVG(const cvb::CvContourPolygon* p, const char* filename, CvScalar stroke, CvScalar fill)
{
	std::string filenameStr = filename;
	cvb::cvWriteContourPolygonSVG(*p, filenameStr, stroke, fill);
}
CVAPI(void) cvb_cvRenderBlob(const IplImage *imgLabel, cvb::CvBlob *blob, IplImage *imgSource, IplImage *imgDest, unsigned short mode, CvScalar color, double alpha)
{
	cvb::cvRenderBlob(imgLabel, blob, imgSource, imgDest, mode, color, alpha);
}
CVAPI(CvScalar) cvb_cvBlobMeanColor(cvb::CvBlob *blob, IplImage *imgLabel, IplImage *img)
{
	return cvBlobMeanColor(blob, imgLabel, img);
}

#pragma endregion

#pragma region CvBlob
CVAPI(int) CvBlob_sizeof()
{
	return sizeof(cvb::CvBlob);
}
CVAPI(cvb::CvBlob*) CvBlob_construct()
{
	return new cvb::CvBlob();
}
CVAPI(void) CvBlob_destruct(cvb::CvBlob* blob)
{
	delete blob;
}
CVAPI(cvb::CvLabel*) CvBlob_label(cvb::CvBlob* obj)
{
	return &(obj->label);
}

CVAPI(unsigned int*) CvBlob_area(cvb::CvBlob* obj)
{
	return &(obj->area);
}
CVAPI(unsigned int*) CvBlob_m00(cvb::CvBlob* obj)
{
	return &(obj->m00);
}

CVAPI(unsigned int*) CvBlob_minx(cvb::CvBlob* obj)
{
	return &(obj->minx);
}
CVAPI(unsigned int*) CvBlob_maxx(cvb::CvBlob* obj)
{
	return &(obj->maxx);
}
CVAPI(unsigned int*) CvBlob_miny(cvb::CvBlob* obj)
{
	return &(obj->miny);
}
CVAPI(unsigned int*) CvBlob_maxy(cvb::CvBlob* obj)
{
	return &(obj->maxy);
}

CVAPI(CvPoint2D64f*) CvBlob_centroid(cvb::CvBlob* obj)
{
	return &(obj->centroid);
}

CVAPI(double*) CvBlob_m10(cvb::CvBlob* obj)
{
	return &(obj->m10);
}
CVAPI(double*) CvBlob_m01(cvb::CvBlob* obj)
{
	return &(obj->m01);
}
CVAPI(double*) CvBlob_m11(cvb::CvBlob* obj)
{
	return &(obj->m11);
}
CVAPI(double*) CvBlob_m20(cvb::CvBlob* obj)
{
	return &(obj->m20);
}
CVAPI(double*) CvBlob_m02(cvb::CvBlob* obj)
{
	return &(obj->m02);
}


/*CVAPI(bool*) CvBlob_centralMoments(cvb::CvBlob* obj)
{
	return &(obj->centralMoments);
}*/
CVAPI(double*) CvBlob_u11(cvb::CvBlob* obj)
{
	return &(obj->u11);
}
CVAPI(double*) CvBlob_u20(cvb::CvBlob* obj)
{
	return &(obj->u20);
}
CVAPI(double*) CvBlob_u02(cvb::CvBlob* obj)
{
	return &(obj->u02);
}

CVAPI(cvb::CvContourChainCode*) CvBlob_contour(cvb::CvBlob* obj)
{
	return &(obj->contour);
}
CVAPI(cvb::CvContoursChainCode*) CvBlob_internalContours(cvb::CvBlob* obj)
{
	return &(obj->internalContours);
}
#pragma endregion

#pragma region CvContourChainCode
CVAPI(int) CvContourChainCode_sizeof()
{
	return sizeof(cvb::CvContourChainCode);
}
CVAPI(CvPoint) CvContourChainCode_startingPoint_get(cvb::CvContourChainCode* obj)
{
	return obj->startingPoint;
}
CVAPI(void) CvContourChainCode_startingPoint_set(cvb::CvContourChainCode* obj, CvPoint value)
{
	obj->startingPoint = value;
}
CVAPI(cvb::CvChainCodes*) CvContourChainCode_chainCode_get(cvb::CvContourChainCode* obj)
{
	return &(obj->chainCode);
}
#pragma endregion

#pragma region CvContoursChainCode
CVAPI(void) CvContoursChainCode_PushBack(cvb::CvContoursChainCode* obj, cvb::CvContourChainCode* item)
{	
	obj->push_back(item);
}
CVAPI(void) CvContoursChainCode_Clear(cvb::CvContoursChainCode* obj)
{	
	obj->clear();
}
CVAPI(bool) CvContoursChainCode_Contains(cvb::CvContoursChainCode* obj, cvb::CvContourChainCode* item)
{	
	for (cvb::CvContoursChainCode::iterator it = obj->begin(); it != obj->end(); it++)
	{
		if(*it == item)
		{
			return true;
		}
	}
	return false;
}
CVAPI(void) CvContoursChainCode_CopyTo(cvb::CvContoursChainCode* obj, cvb::CvContourChainCode** array, int arrayIndex)
{
	int i = arrayIndex;
    for (cvb::CvContoursChainCode::iterator it = obj->begin(); it != obj->end(); it++)
	{
		array[i++] = *it;
	}
}
CVAPI(size_t) CvContoursChainCode_Count(cvb::CvContoursChainCode* obj)
{
    return obj->size();
}
CVAPI(bool) CvContoursChainCode_Remove(cvb::CvContoursChainCode* obj, cvb::CvContourChainCode* value)
{	
	for (cvb::CvContoursChainCode::iterator it = obj->begin(); it != obj->end(); it++)
	{
		if(*it == value)
		{
			obj->erase(it);
			return true;
		}
	}
	return false;
}
#pragma endregion

#pragma region CvChainCodes
CVAPI(void) CvChainCodes_PushBack(cvb::CvChainCodes* obj, cvb::CvChainCode item)
{	
	obj->push_back(item);
}
CVAPI(void) CvChainCodes_Clear(cvb::CvChainCodes* obj)
{	
	obj->clear();
}
CVAPI(bool) CvChainCodes_Contains(cvb::CvChainCodes* obj, cvb::CvChainCode item)
{	
	for (cvb::CvChainCodes::iterator it = obj->begin(); it != obj->end(); it++)
	{
		if(*it == item)
		{
			return true;
		}
	}
	return false;
}
CVAPI(void) CvChainCodes_CopyTo(cvb::CvChainCodes* obj, cvb::CvChainCode* array, int arrayIndex)
{
	int i = arrayIndex;
    for (cvb::CvChainCodes::iterator it = obj->begin(); it != obj->end(); it++)
	{
		array[i++] = *it;
	}
}
CVAPI(size_t) CvChainCodes_Count(cvb::CvChainCodes* obj)
{
    return obj->size();
}
CVAPI(bool) CvChainCodes_Remove(cvb::CvChainCodes* obj, cvb::CvChainCode value)
{	
	for (cvb::CvChainCodes::iterator it = obj->begin(); it != obj->end(); it++)
	{
		if(*it == value)
		{
			obj->erase(it);
			return true;
		}
	}
	return false;
}
#pragma endregion

#pragma region CvContourPolygon
CVAPI(void) CvContourPolygon_destruct(cvb::CvContourPolygon* obj)
{
	obj->clear();
	delete obj;
}
CVAPI(int) CvContourPolygon_IndexOf(cvb::CvContourPolygon* obj, CvPoint item)
{
	//return std::find(obj->begin(), obj->end(), item) - obj->begin();
	for (size_t i = 0; i < obj->size(); i++)
	{
		CvPoint elem = obj->at(i);
		if (elem.x == item.x && elem.y == item.y)
			return i;
	}
	return -1;
}
CVAPI(void) CvContourPolygon_Insert(cvb::CvContourPolygon* obj, int index, CvPoint item)
{
	obj->insert(obj->begin() + index, item);
}
CVAPI(void) CvContourPolygon_RemoveAt(cvb::CvContourPolygon* obj, int index)
{
	obj->erase(obj->begin() + index);
}
CVAPI(CvPoint) CvContourPolygon_This_get(cvb::CvContourPolygon* obj, int index)
{
	return obj->at(index);
}
CVAPI(void) CvContourPolygon_This_set(cvb::CvContourPolygon* obj, int index, CvPoint value)
{
	(*obj)[index] = value;
}
CVAPI(void) CvContourPolygon_Add(cvb::CvContourPolygon* obj, CvPoint item)
{	
	obj->push_back(item);
}
CVAPI(void) CvContourPolygon_Clear(cvb::CvContourPolygon* obj)
{	
	obj->clear();
}
CVAPI(bool) CvContourPolygon_Contains(cvb::CvContourPolygon* obj, CvPoint item)
{	
	for (cvb::CvContourPolygon::iterator it = obj->begin(); it != obj->end(); it++)
	{
		CvPoint current = *it;
		if(current.x == item.x && current.y == item.y)
		{
			return true;
		}
	}
	return false;
}
CVAPI(void) CvContourPolygon_CopyTo(cvb::CvContourPolygon* obj, CvPoint* array, int arrayIndex)
{
	int i = arrayIndex;
    for (cvb::CvContourPolygon::iterator it = obj->begin(); it != obj->end(); it++)
	{
		array[i++] = *it;
	}
}
CVAPI(size_t) CvContourPolygon_Count(cvb::CvContourPolygon* obj)
{
    return obj->size();
}
CVAPI(bool) CvContourPolygon_Remove(cvb::CvContourPolygon* obj, CvPoint value)
{	
	for (cvb::CvContourPolygon::iterator it = obj->begin(); it != obj->end(); it++)
	{
		CvPoint current = *it;
		if(current.x == value.x && current.y == value.y)
		{
			obj->erase(it);
			return true;
		}
	}
	return false;
}
#pragma endregion

#pragma region CvBlobs
CVAPI(int) CvBlobs_sizeof()
{
	return sizeof(cvb::CvBlobs);
}
CVAPI(cvb::CvBlobs*) CvBlobs_construct()
{
	return new cvb::CvBlobs();
}
CVAPI(void) CvBlobs_destruct(cvb::CvBlobs* blobs)
{
	//delete blobs;
	blobs->clear();
	delete blobs;
}

CVAPI(void) CvBlobs_Add(cvb::CvBlobs* blobs, cvb::CvLabel key, cvb::CvBlob* value)
{
	blobs->insert( cvb::CvBlobs::value_type(key, value) );
}
CVAPI(bool) CvBlobs_ContainsKey(cvb::CvBlobs* blobs, cvb::CvLabel key)
{
	return blobs->count(key) > 0;
}
CVAPI(void) CvBlobs_Keys(cvb::CvBlobs* blobs, cvb::CvLabel* keys)
{
	int i = 0;
	for (cvb::CvBlobs::iterator it = blobs->begin(); it != blobs->end(); it++, i++)
	{
		keys[i] = it->first;
	}
}
CVAPI(bool) CvBlobs_RemoveAt(cvb::CvBlobs* blobs, cvb::CvLabel key)
{
	if(blobs->count(key) > 0)
	{
		blobs->erase(key);
		return true;
	}
	else
	{
		return false;
	}
}
CVAPI(bool) CvBlobs_TryGetValue(cvb::CvBlobs* blobs, cvb::CvLabel key, cvb::CvBlob** value)
{
    cvb::CvBlobs::iterator it = blobs->find(key);
	if(it != blobs->end())
	{
		*value = it->second;
		return true;
	}
	else
	{
		*value = NULL;
		return false;
	}
}
CVAPI(void) CvBlobs_Values(cvb::CvBlobs* blobs, cvb::CvBlob** values)
{
	int i = 0;
	for (cvb::CvBlobs::iterator it = blobs->begin(); it != blobs->end(); it++, i++)
	{
		values[i] = it->second;
	}
}
// obsolete
// instead: cvReleaseBlobs
CVAPI(void) CvBlobs_Clear(cvb::CvBlobs* blobs)
{
	blobs->clear();
}
CVAPI(bool) CvBlobs_Contains(cvb::CvBlobs* blobs, cvb::CvLabel key, cvb::CvBlob* value)
{
	cvb::CvBlobs::iterator it = blobs->find(key);
	if(it != blobs->end())
	{
		if(it->second == value)
		{
			return true;
		}
	}
	return false;
}
CVAPI(size_t) CvBlobs_Count(cvb::CvBlobs* blobs)
{
    return blobs->size();
}
CVAPI(bool) CvBlobs_Remove(cvb::CvBlobs* blobs, cvb::CvLabel key, cvb::CvBlob* value)
{	
	if(blobs->count(key) > 0)
	{
		cvb::CvBlob* b = (*blobs)[key];
		if(b == value)
		{
			return blobs->erase(key) > 0;
		}
	}
	return false;
}

CVAPI(cvb::CvBlob*) CvBlobs_get(cvb::CvBlobs* blobs, cvb::CvLabel key)
{
	return (*blobs)[key];
}
CVAPI(void) CvBlobs_set(cvb::CvBlobs* blobs, cvb::CvLabel key, cvb::CvBlob* value)
{
	(*blobs)[key] = value;
}

CVAPI(void) CvBlobs_GetKeysAndValues(cvb::CvBlobs* blobs, cvb::CvLabel* keys, cvb::CvBlob** values)
{
	int i = 0;
	for (cvb::CvBlobs::const_iterator it = blobs->begin(); it != blobs->end(); it++, i++)
	{
		keys[i] = it->first;
		values[i] = it->second;
	}
}
#pragma endregion

#pragma region CvTrack
CVAPI(int) CvTrack_sizeof()
{
	return sizeof(cvb::CvTrack);
}
CVAPI(cvb::CvTrack*) CvTrack_construct()
{
	return new cvb::CvTrack;
}
CVAPI(void) CvTrack_destruct(cvb::CvTrack *track)
{
	delete track;
}
#pragma endregion

#pragma region CvTracks
CVAPI(int) CvTracks_sizeof()
{
	return sizeof(cvb::CvTracks);
}
CVAPI(cvb::CvTracks*) CvTracks_construct()
{
	return new cvb::CvTracks();
}
CVAPI(void) CvTracks_destruct(cvb::CvTracks* obj)
{
	delete obj;
}



CVAPI(void) CvTracks_cvReleaseTracks(cvb::CvTracks *tracks)
{
	cvReleaseTracks(*tracks);
}

CVAPI(void) CvTracks_Add(cvb::CvTracks* obj, cvb::CvID key, cvb::CvTrack* value)
{
	obj->insert( cvb::CvTracks::value_type(key, value) );
}
CVAPI(bool) CvTracks_ContainsKey(cvb::CvTracks* obj, cvb::CvID key)
{
	return obj->count(key) > 0;
}
CVAPI(void) CvTracks_Keys(cvb::CvTracks* obj, cvb::CvID* keys)
{
	int i = 0;
	for (cvb::CvTracks::iterator it = obj->begin(); it != obj->end(); it++, i++)
	{
		keys[i] = it->first;
	}
}
CVAPI(bool) CvTracks_RemoveAt(cvb::CvTracks* obj, cvb::CvID key)
{
	if(obj->count(key) > 0)
	{
		obj->erase(key);
		return true;
	}
	else
	{
		return false;
	}
}
CVAPI(bool) CvTracks_TryGetValue(cvb::CvTracks* obj, cvb::CvID key, cvb::CvTrack** value)
{
    cvb::CvTracks::iterator it = obj->find(key);
	if(it != obj->end())
	{
		*value = it->second;
		return true;
	}
	else
	{
		*value = NULL;
		return false;
	}
}
CVAPI(void) CvTracks_Values(cvb::CvTracks* obj, cvb::CvTrack** values)
{
	int i = 0;
	for (cvb::CvTracks::iterator it = obj->begin(); it != obj->end(); it++, i++)
	{
		values[i] = it->second;
	}
}
// obsolete
// instead: cvReleaseTracks
CVAPI(void) CvTracks_Clear(cvb::CvTracks* obj)
{
	obj->clear();
}
CVAPI(bool) CvTracks_Contains(cvb::CvTracks* obj, cvb::CvID key, cvb::CvTrack* value)
{
	cvb::CvTracks::iterator it = obj->find(key);
	if(it != obj->end())
	{
		if(it->second == value)
		{
			return true;
		}
	}
	return false;
}
CVAPI(size_t) CvTracks_Count(cvb::CvTracks* obj)
{
    return obj->size();
}
CVAPI(bool) CvTracks_Remove(cvb::CvTracks* obj, cvb::CvID key, cvb::CvTrack* value)
{	
	if(obj->count(key) > 0)
	{
		cvb::CvTrack* v = (*obj)[key];
		if(v == value)
		{
			return obj->erase(key) > 0;
		}
	}
	return false;
}

CVAPI(cvb::CvTrack*) CvTracks_get(cvb::CvTracks* obj, cvb::CvID key)
{
	return (*obj)[key];
}
CVAPI(void) CvTracks_set(cvb::CvTracks* obj, cvb::CvID key, cvb::CvTrack* value)
{
	(*obj)[key] = value;
}

CVAPI(void) CvTracks_GetKeysAndValues(cvb::CvTracks* obj, cvb::CvID* keys, cvb::CvTrack** values)
{
	int i = 0;
	for (cvb::CvTracks::iterator it = obj->begin(); it != obj->end(); it++, i++)
	{
		keys[i] = it->first;
		values[i] = it->second;
	}
}
#pragma endregion

#endif