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
#include <opencv/highgui.h>
#include "cvblob.h"

namespace cvb
{

  CvLabel cvLargestBlob(const CvBlobs &blobs)
  {
    CvLabel label=0;
    unsigned int maxArea=0;

    for (CvBlobs::const_iterator it=blobs.begin();it!=blobs.end();++it)
    {
      CvBlob *blob=(*it).second;

      if (blob->area > maxArea)
      {
		label=blob->label;
		maxArea=blob->area;
      }
    }

    return label;
  }

  void cvFilterByArea(CvBlobs &blobs, unsigned int minArea, unsigned int maxArea)
  {
    CvBlobs::iterator it=blobs.begin();
    while(it!=blobs.end())
    {
      CvBlob *blob=(*it).second;
      if ((blob->area<minArea)||(blob->area>maxArea))
      {
	cvReleaseBlob(blob);

	CvBlobs::iterator tmp=it;
	++it;
	blobs.erase(tmp);
      }
      else
	++it;
    }
  }

  void cvFilterByLabel(CvBlobs &blobs, CvLabel label)
  {
    CvBlobs::iterator it=blobs.begin();
    while(it!=blobs.end())
    {
      CvBlob *blob=(*it).second;
      if (blob->label!=label)
      {
	delete blob;
	CvBlobs::iterator tmp=it;
	++it;
	blobs.erase(tmp);
      }
      else
	++it;
    }
  }

  /*void cvCentralMoments(CvBlob *blob, const IplImage *img)
  {
    CV_FUNCNAME("cvCentralMoments");
    __CV_BEGIN__;
    if (!blob->centralMoments)
    {
      CV_ASSERT(img&&(img->depth==IPL_DEPTH_LABEL)&&(img->nChannels==1));

      //cvCentroid(blob); // Here?

      blob->u11=blob->u20=blob->u02=0.;

      // Only in the bounding box
      int stepIn = img->widthStep / (img->depth / 8);
      int img_width = img->width;
      int img_height = img->height;
      int img_offset = 0;
      if(0 != img->roi)
      {
	img_width = img->roi->width;
	img_height = img->roi->height;
	img_offset = img->roi->xOffset + (img->roi->yOffset * stepIn);
      }

      CvLabel *imgData=(CvLabel *)img->imageData + (blob->miny * stepIn) + img_offset;
      for (unsigned int r=blob->miny;
	  r<blob->maxy;
	  r++,imgData+=stepIn)
	for (unsigned int c=blob->minx;c<blob->maxx;c++)
	  if (imgData[c]==blob->label)
	  {
	    double tx=(c-blob->centroid.x);
	    double ty=(r-blob->centroid.y);
	    blob->u11+=tx*ty;
	    blob->u20+=tx*tx;
	    blob->u02+=ty*ty;
	  }

      blob->centralMoments = true;
    }
    __CV_END__;
  }*/

  void cvRenderBlob(const IplImage *imgLabel, CvBlob *blob, IplImage *imgSource, IplImage *imgDest, unsigned short mode, CvScalar const &color, double alpha)
  {
    CV_FUNCNAME("cvRenderBlob");
    __CV_BEGIN__;

    CV_ASSERT(imgLabel&&(imgLabel->depth==IPL_DEPTH_LABEL)&&(imgLabel->nChannels==1));
    CV_ASSERT(imgDest&&(imgDest->depth==IPL_DEPTH_8U)&&(imgDest->nChannels==3));

    if (mode&CV_BLOB_RENDER_COLOR)
    {
      int stepLbl = imgLabel->widthStep/(imgLabel->depth/8);
      int stepSrc = imgSource->widthStep/(imgSource->depth/8);
      int stepDst = imgDest->widthStep/(imgDest->depth/8);
      int imgLabel_width = imgLabel->width;
      int imgLabel_height = imgLabel->height;
      int imgLabel_offset = 0;
      int imgSource_width = imgSource->width;
      int imgSource_height = imgSource->height;
      int imgSource_offset = 0;
      int imgDest_width = imgDest->width;
      int imgDest_height = imgDest->height;
      int imgDest_offset = 0;
      if(imgLabel->roi)
      {
	imgLabel_width = imgLabel->roi->width;
	imgLabel_height = imgLabel->roi->height;
	imgLabel_offset = (imgLabel->nChannels * imgLabel->roi->xOffset) + (imgLabel->roi->yOffset * stepLbl);
      }
      if(imgSource->roi)
      {
	imgSource_width = imgSource->roi->width;
	imgSource_height = imgSource->roi->height;
	imgSource_offset = (imgSource->nChannels * imgSource->roi->xOffset) + (imgSource->roi->yOffset * stepSrc);
      }
      if(imgDest->roi)
      {
	imgDest_width = imgDest->roi->width;
	imgDest_height = imgDest->roi->height;
	imgDest_offset = (imgDest->nChannels * imgDest->roi->xOffset) + (imgDest->roi->yOffset * stepDst);
      }

      CvLabel *labels = (CvLabel *)imgLabel->imageData + imgLabel_offset + (blob->miny * stepLbl);
      unsigned char *source = (unsigned char *)imgSource->imageData + imgSource_offset + (blob->miny * stepSrc);
      unsigned char *imgData = (unsigned char *)imgDest->imageData + imgDest_offset + (blob->miny * stepDst);

      for (unsigned int r=blob->miny; r<blob->maxy; r++, labels+=stepLbl, source+=stepSrc, imgData+=stepDst)
	for (unsigned int c=blob->minx; c<blob->maxx; c++)
	{
	  if (labels[c]==blob->label)
	  {
	    imgData[imgDest->nChannels*c+0] = (unsigned char)((1.-alpha)*source[imgSource->nChannels*c+0]+alpha*color.val[0]);
	    imgData[imgDest->nChannels*c+1] = (unsigned char)((1.-alpha)*source[imgSource->nChannels*c+1]+alpha*color.val[1]);
	    imgData[imgDest->nChannels*c+2] = (unsigned char)((1.-alpha)*source[imgSource->nChannels*c+2]+alpha*color.val[2]);
	  }
	}
    }

    if (mode)
    {
      if (mode&CV_BLOB_RENDER_TO_LOG)
      {
	std::clog << "Blob " << blob->label << std::endl;
	std::clog << " - Bounding box: (" << blob->minx << ", " << blob->miny << ") - (" << blob->maxx << ", " << blob->maxy << ")" << std::endl;
	std::clog << " - Bounding box area: " << (1 + blob->maxx - blob->minx) * (1 + blob->maxy - blob->miny) << std::endl;
	std::clog << " - Area: " << blob->area << std::endl;
	std::clog << " - Centroid: (" << blob->centroid.x << ", " << blob->centroid.y << ")" << std::endl;
	std::clog << std::endl;
      }

      if (mode&CV_BLOB_RENDER_TO_STD)
      {
	std::cout << "Blob " << blob->label << std::endl;
	std::cout << " - Bounding box: (" << blob->minx << ", " << blob->miny << ") - (" << blob->maxx << ", " << blob->maxy << ")" << std::endl;
	std::cout << " - Bounding box area: " << (1 + blob->maxx - blob->minx) * (1 + blob->maxy - blob->miny) << std::endl;
	std::cout << " - Area: " << blob->area << std::endl;
	std::cout << " - Centroid: (" << blob->centroid.x << ", " << blob->centroid.y << ")" << std::endl;
	std::cout << std::endl;
      }

      if (mode&CV_BLOB_RENDER_BOUNDING_BOX)
	cvRectangle(imgDest, cvPoint(blob->minx, blob->miny), cvPoint(blob->maxx-1, blob->maxy-1), CV_RGB(255., 0., 0.));

      if (mode&CV_BLOB_RENDER_ANGLE)
      {
	double angle = cvAngle(blob);

	double x1,y1,x2,y2;
	double lengthLine = MAX(blob->maxx-blob->minx, blob->maxy-blob->miny)/2.;

	x1=blob->centroid.x-lengthLine*cos(angle);
	y1=blob->centroid.y-lengthLine*sin(angle);
	x2=blob->centroid.x+lengthLine*cos(angle);
	y2=blob->centroid.y+lengthLine*sin(angle);
	cvLine(imgDest,cvPoint(int(x1),int(y1)),cvPoint(int(x2),int(y2)),CV_RGB(0.,255.,0.));
      }

      if (mode&CV_BLOB_RENDER_CENTROID)
      {
	cvLine(imgDest,cvPoint(int(blob->centroid.x)-3,int(blob->centroid.y)),cvPoint(int(blob->centroid.x)+3,int(blob->centroid.y)),CV_RGB(0.,0.,255.));
	cvLine(imgDest,cvPoint(int(blob->centroid.x),int(blob->centroid.y)-3),cvPoint(int(blob->centroid.x),int(blob->centroid.y)+3),CV_RGB(0.,0.,255.));
      }
    }

    __CV_END__;
  }

  ///////////////////////////////////////////////////////////////////////////////////////////////////
  // Based on http://en.wikipedia.org/wiki/HSL_and_HSV

  /// \def _HSV2RGB_(H, S, V, R, G, B)
  /// \brief Color translation between HSV and RGB.
#define _HSV2RGB_(H, S, V, R, G, B) \
  { \
    double _h = H/60.; \
    int _hf = (int)floor(_h); \
    int _hi = ((int)_h)%6; \
    double _f = _h - _hf; \
    \
    double _p = V * (1. - S); \
    double _q = V * (1. - _f * S); \
    double _t = V * (1. - (1. - _f) * S); \
    \
    switch (_hi) \
    { \
      case 0: \
	      R = 255.*V; G = 255.*_t; B = 255.*_p; \
      break; \
      case 1: \
	      R = 255.*_q; G = 255.*V; B = 255.*_p; \
      break; \
      case 2: \
	      R = 255.*_p; G = 255.*V; B = 255.*_t; \
      break; \
      case 3: \
	      R = 255.*_p; G = 255.*_q; B = 255.*V; \
      break; \
      case 4: \
	      R = 255.*_t; G = 255.*_p; B = 255.*V; \
      break; \
      case 5: \
	      R = 255.*V; G = 255.*_p; B = 255.*_q; \
      break; \
    } \
  }
  ///////////////////////////////////////////////////////////////////////////////////////////////////

  typedef std::map<CvLabel, CvScalar> Palete;

  void cvRenderBlobs(const IplImage *imgLabel, CvBlobs &blobs, IplImage *imgSource, IplImage *imgDest, unsigned short mode, double alpha)
  {
    CV_FUNCNAME("cvRenderBlobs");
    __CV_BEGIN__;
    {

      CV_ASSERT(imgLabel&&(imgLabel->depth==IPL_DEPTH_LABEL)&&(imgLabel->nChannels==1));
      CV_ASSERT(imgDest&&(imgDest->depth==IPL_DEPTH_8U)&&(imgDest->nChannels==3));

      Palete pal;
      if (mode&CV_BLOB_RENDER_COLOR)
      {

	unsigned int colorCount = 0;
	for (CvBlobs::const_iterator it=blobs.begin(); it!=blobs.end(); ++it)
	{
	  CvLabel label = (*it).second->label;

	  double r, g, b;

	  _HSV2RGB_((double)((colorCount*77)%360), .5, 1., r, g, b);
	  colorCount++;

	  pal[label] = CV_RGB(r, g, b);
	}
      }

      for (CvBlobs::iterator it=blobs.begin(); it!=blobs.end(); ++it)
	cvRenderBlob(imgLabel, (*it).second, imgSource, imgDest, mode, pal[(*it).second->label], alpha);

    }
    __CV_END__;
  }

  // Returns radians
  double cvAngle(CvBlob *blob)
  {
    CV_FUNCNAME("cvAngle");
    __CV_BEGIN__;

    return .5*atan2(2.*blob->u11,(blob->u20-blob->u02));

    __CV_END__;
  }

  void cvSaveImageBlob(const char *filename, IplImage *img, CvBlob const *blob)
  {
    CvRect roi = cvGetImageROI(img);
    cvSetImageROItoBlob(img, blob);
    cvSaveImage(filename, img);
    cvSetImageROI(img, roi);
  }

}

ostream& operator<< (ostream& output, const cvb::CvBlob& b)
{
  output << b.label << ": " << b.area << ", (" << b.centroid.x << ", " << b.centroid.y << "), [(" << b.minx << ", " << b.miny << ") - (" << b.maxx << ", " << b.maxy << ")]";

  return output;
}
