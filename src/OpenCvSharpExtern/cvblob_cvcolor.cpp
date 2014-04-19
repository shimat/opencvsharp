// Copyright (C) 2007 by Cristóbal Carnero Liñán
// grendel.ccl@gmail.com
//
// This file is part of cvBlob.
//
// cvBlob is free software: you can redistribute it and/or modify
// it under the terms of the Lesser GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// cvBlob is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// Lesser GNU General Public License for more details.
//
// You should have received a copy of the Lesser GNU General Public License
// along with cvBlob.  If not, see <http://www.gnu.org/licenses/>.
//

#include <cmath>
#include <iostream>
using namespace std;

#include <opencv/cv.h>
#include "cvblob.h"

namespace cvb
{

	CvScalar cvBlobMeanColor(CvBlob const *blob, IplImage const *imgLabel, IplImage const *img)
	{
		CV_FUNCNAME("cvBlobMeanColor");
		__CV_BEGIN__;
		{
			CV_ASSERT(imgLabel && (imgLabel->depth == IPL_DEPTH_LABEL) && (imgLabel->nChannels == 1));
			CV_ASSERT(img && (img->depth == IPL_DEPTH_8U) && (img->nChannels == 3));

			int stepLbl = imgLabel->widthStep / (imgLabel->depth / 8);
			int stepImg = img->widthStep / (img->depth / 8);
			int imgLabel_width = imgLabel->width;
			int imgLabel_height = imgLabel->height;
			int imgLabel_offset = 0;
			int img_width = img->width;
			int img_height = img->height;
			int img_offset = 0;
			if (imgLabel->roi)
			{
				imgLabel_width = imgLabel->roi->width;
				imgLabel_height = imgLabel->roi->height;
				imgLabel_offset = (imgLabel->nChannels * imgLabel->roi->xOffset) + (imgLabel->roi->yOffset * stepLbl);
			}
			if (img->roi)
			{
				img_width = img->roi->width;
				img_height = img->roi->height;
				img_offset = (img->nChannels * img->roi->xOffset) + (img->roi->yOffset * stepImg);
			}

			CvLabel *labels = (CvLabel *)imgLabel->imageData + imgLabel_offset;
			unsigned char *imgData = (unsigned char *)img->imageData + img_offset;

			double mb = 0;
			double mg = 0;
			double mr = 0;
			double pixels = (double)blob->area;

			for (unsigned int r = 0; r < (unsigned int)imgLabel_height; r++, labels += stepLbl, imgData += stepImg)
			for (unsigned int c = 0; c < (unsigned int)imgLabel_width; c++)
			{
				if (labels[c] == blob->label)
				{
					mb += ((double)imgData[img->nChannels*c + 0]) / pixels; // B
					mg += ((double)imgData[img->nChannels*c + 1]) / pixels; // G
					mr += ((double)imgData[img->nChannels*c + 2]) / pixels; // R
				}
			}

			/*double mb = 0;
			double mg = 0;
			double mr = 0;
			double pixels = (double)blob->area;
			for (unsigned int y=0; y<imgLabel->height; y++)
			for (unsigned int x=0; x<imgLabel->width; x++)
			{
			if (cvGetLabel(imgLabel, x, y)==blob->label)
			{
			CvScalar color = cvGet2D(img, y, x);
			mb += color.val[0]/pixels;
			mg += color.val[1]/pixels;
			mr += color.val[2]/pixels;
			}
			}*/ 

			return cvScalar(mr, mg, mb);
		}
		__CV_END__;
		return cvScalarAll(0);
	}

}
