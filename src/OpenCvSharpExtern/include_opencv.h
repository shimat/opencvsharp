#ifndef _INCLUDE_OPENCV_H_
#define _INCLUDE_OPENCV_H_

#ifdef _MSC_VER
#pragma warning(push)
#pragma warning(disable: 4251)
#pragma warning(disable: 4996)
#endif
#include <opencv2/opencv.hpp>
#include <opencv2/legacy/legacy.hpp>
#include <opencv2/nonfree/nonfree.hpp>
#include <opencv2/superres/superres.hpp>
#include <opencv2/superres/optical_flow.hpp>

#include <vector>
#include <algorithm>
#include <sstream>
#include <iterator>
#include <fstream>
#include <iostream>
#include <cstdio>
#include <cstring>
#include <cstdlib>
#ifdef _MSC_VER
#pragma warning(pop)
#endif

// Additional types
#include "my_types.h"

// Additional functions
#include "my_functions.h"

#endif
