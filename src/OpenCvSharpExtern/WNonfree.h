/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _WNONFREE_H_
#define _WNONFREE_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/nonfree/nonfree.hpp>

CVAPI(int) cv_initModule_nonfree()
{
	return cv::initModule_nonfree();
}

#endif