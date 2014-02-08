/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_NONFREE_H_
#define _CPP_NONFREE_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/nonfree/nonfree.hpp>

CVAPI(int) nonfree_initModule_nonfree()
{
	return cv::initModule_nonfree();
}

#endif