#ifndef _CPP_LEGACY_H_
#define _CPP_LEGACY_H_

#include "include_opencv.h"

CVAPI(size_t) legacy_CvCamShiftTracker_sizeof()
{
	return sizeof(CvCamShiftTracker);
}
CVAPI(CvCamShiftTracker*) legacy_CvCamShiftTracker_new()
{
	return new CvCamShiftTracker();
}
CVAPI(void) legacy_CvCamShiftTracker_delete(CvCamShiftTracker *obj)
{
	delete obj; 
}

/**** Characteristics of the object that are calculated by track_object method *****/
CVAPI(float) legacy_CvCamShiftTracker_get_orientation(CvCamShiftTracker *obj)
{ 
	return obj->get_orientation(); 
}
CVAPI(float) legacy_CvCamShiftTracker_get_length(CvCamShiftTracker *obj)
{
	return obj->get_length();
}
CVAPI(float) legacy_CvCamShiftTracker_get_width(CvCamShiftTracker *obj)
{ 
	return obj->get_width(); 
}
CVAPI(CvPoint2D32f) legacy_CvCamShiftTracker_get_center(CvCamShiftTracker *obj)
{ 
	return obj->get_center(); 
}
CVAPI(CvRect) legacy_CvCamShiftTracker_get_window(CvCamShiftTracker *obj)
{ 
	return obj->get_window(); 
}

CVAPI(int) legacy_CvCamShiftTracker_get_threshold(CvCamShiftTracker *obj)
{ 
	return obj->get_threshold(); 
}
CVAPI(int) legacy_CvCamShiftTracker_get_hist_dims(CvCamShiftTracker *obj, int *dims)
{ 
	return obj->get_hist_dims(dims); 
}
CVAPI(int) legacy_CvCamShiftTracker_get_min_ch_val(CvCamShiftTracker *obj, int channel)
{
	return obj->get_min_ch_val(channel);
}
CVAPI(int) legacy_CvCamShiftTracker_get_max_ch_val(CvCamShiftTracker *obj, int channel)
{ 
	return obj->get_max_ch_val(channel);
}

CVAPI(int) legacy_CvCamShiftTracker_set_window(CvCamShiftTracker *obj, CvRect window)
{ 
	return obj->set_window(window); 
}
CVAPI(int) legacy_CvCamShiftTracker_set_threshold(CvCamShiftTracker *obj, int threshold)
{ 
	return obj->set_threshold(threshold); 
}
CVAPI(int) legacy_CvCamShiftTracker_set_hist_bin_range(CvCamShiftTracker *obj, int dim, int min_val, int max_val)
{
	return obj->set_hist_bin_range(dim, min_val, max_val);
}
CVAPI(int) legacy_CvCamShiftTracker_set_hist_dims(CvCamShiftTracker *obj, int c_dims, int* dims)
{
	return obj->set_hist_dims(c_dims, dims);
}
CVAPI(int) legacy_CvCamShiftTracker_set_min_ch_val(CvCamShiftTracker *obj, int channel, int val)
{
	return obj->set_min_ch_val(channel, val);
}
CVAPI(int) legacy_CvCamShiftTracker_set_max_ch_val(CvCamShiftTracker *obj, int channel, int val)
{
	return obj->set_max_ch_val(channel, val);
}

/************************ The processing methods *********************************/
CVAPI(bool) legacy_CvCamShiftTracker_track_object(CvCamShiftTracker *obj, IplImage *cur_frame)
{
	return obj->track_object(cur_frame);
}
CVAPI(bool) legacy_CvCamShiftTracker_update_histogram(CvCamShiftTracker *obj, IplImage *cur_frame)
{
	return obj->update_histogram(cur_frame);
}
CVAPI(void) legacy_CvCamShiftTracker_reset_histogram(CvCamShiftTracker *obj)
{
	return obj->reset_histogram();
}

/************************ Retrieving internal data *******************************/
CVAPI(IplImage*) legacy_CvCamShiftTracker_get_back_project(CvCamShiftTracker *obj)
{ 
	return obj->get_back_project(); 
}

CVAPI(float) legacy_CvCamShiftTracker_query(CvCamShiftTracker *obj, int *bin)
{ 
	return obj->query(bin);
}

#endif