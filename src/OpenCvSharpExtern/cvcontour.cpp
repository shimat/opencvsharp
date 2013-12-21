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

#include <climits>

#define _USE_MATH_DEFINES
#include <cmath>

#include <deque>
#include <iostream>
#include <fstream>
#include <sstream>
using namespace std;

#include <opencv/cv.h>
#include "cvblob.h"

#ifdef M_PI
const double pi = M_PI;
#else
const double pi = std::atan(1.)*4.;
#endif // M_PI

namespace cvb
{

  void cvRenderContourChainCode(CvContourChainCode const *contour, IplImage const *img, CvScalar const &color)
  {
    CV_FUNCNAME("cvRenderContourChainCode");
    __CV_BEGIN__;
    {
      CV_ASSERT(img&&(img->depth==IPL_DEPTH_8U)&&(img->nChannels==3));

      int stepDst = img->widthStep/(img->depth/8);
      int img_width = img->width;
      int img_height = img->height;
      int img_offset = 0;

      if(img->roi)
      {
	img_width = img->roi->width;
	img_height = img->roi->height;
	img_offset = (img->nChannels * img->roi->xOffset) + (img->roi->yOffset * stepDst);
      }

      unsigned char *imgData = (unsigned char *)img->imageData + img_offset;

      unsigned int x = contour->startingPoint.x;
      unsigned int y = contour->startingPoint.y;

      for (CvChainCodes::const_iterator it=contour->chainCode.begin(); it!=contour->chainCode.end(); ++it)
      {
	imgData[img->nChannels*x+img->widthStep*y+0] = (unsigned char)(color.val[0]); // Blue
	imgData[img->nChannels*x+img->widthStep*y+1] = (unsigned char)(color.val[1]); // Green
	imgData[img->nChannels*x+img->widthStep*y+2] = (unsigned char)(color.val[2]); // Red

	x += cvChainCodeMoves[*it][0];
	y += cvChainCodeMoves[*it][1];
      }
    }
    __CV_END__;
  }

  CvContourPolygon *cvConvertChainCodesToPolygon(CvContourChainCode const *cc)
  {
    CV_FUNCNAME("cvConvertChainCodesToPolygon");
    __CV_BEGIN__;
    {
      CV_ASSERT(cc!=NULL);

      CvContourPolygon *contour = new CvContourPolygon;

      unsigned int x = cc->startingPoint.x;
      unsigned int y = cc->startingPoint.y;
      contour->push_back(cvPoint(x, y));

      if (cc->chainCode.size())
      {
        CvChainCodes::const_iterator it=cc->chainCode.begin();
        CvChainCode lastCode = *it;

        x += cvChainCodeMoves[*it][0];
        y += cvChainCodeMoves[*it][1];

        ++it;

        for (; it!=cc->chainCode.end(); ++it)
        {
          if (lastCode!=*it)
          {
            contour->push_back(cvPoint(x, y));
            lastCode=*it;
          }

          x += cvChainCodeMoves[*it][0];
          y += cvChainCodeMoves[*it][1];
        }
      }

      return contour;
    }
    __CV_END__;
  }

  void cvRenderContourPolygon(CvContourPolygon const *contour, IplImage *img, CvScalar const &color)
  {
    CV_FUNCNAME("cvRenderContourPolygon");
    __CV_BEGIN__;
    {
      CV_ASSERT(img&&(img->depth==IPL_DEPTH_8U)&&(img->nChannels==3));

      CvContourPolygon::const_iterator it=contour->begin();

      if (it!=contour->end())
      {
	unsigned int fx, x, fy, y;
	fx = x = it->x;
	fy = y = it->y;

	for (; it!=contour->end(); ++it)
	{
	  cvLine(img, cvPoint(x, y), cvPoint(it->x, it->y), color, 1);
	  x = it->x;
	  y = it->y;
	}

	cvLine(img, cvPoint(x, y), cvPoint(fx, fy), color, 1);
      }
    }
    __CV_END__;
  }

  double cvContourPolygonArea(CvContourPolygon const *p)
  {
    CV_FUNCNAME("cvContourPolygonArea");
    __CV_BEGIN__;
    {
      CV_ASSERT(p!=NULL);

      if (p->size()<=2)
	return 1.;

      CvContourPolygon::const_iterator it=p->begin();
      CvPoint lastPoint = p->back();

      double a = 0.;

      for (; it!=p->end(); ++it)
      {
	a += lastPoint.x*it->y - lastPoint.y*it->x;
	lastPoint = *it;
      }

      return a*0.5;
    }
    __CV_END__;
  }

  double cvContourChainCodePerimeter(CvContourChainCode const *c)
  {
    CV_FUNCNAME("cvContourChainCodePerimeter");
    __CV_BEGIN__;
    {
      CV_ASSERT(c!=NULL);

      double perimeter = 0.;

      for(CvChainCodes::const_iterator it=c->chainCode.begin(); it!=c->chainCode.end(); ++it)
      {
	if ((*it)%2)
	  perimeter+=sqrt(1.+1.);
	else
	  perimeter+=1.;
      }

      return perimeter;
    }
    __CV_END__;
  }

  double cvContourPolygonPerimeter(CvContourPolygon const *p)
  {
    CV_FUNCNAME("cvContourPolygonPerimeter");
    __CV_BEGIN__;
    {
      CV_ASSERT(p!=NULL);

      double perimeter = cvDistancePointPoint((*p)[p->size()-1], (*p)[0]);

      for (unsigned int i=0; i<p->size()-1; i++)
	perimeter+=cvDistancePointPoint((*p)[i], (*p)[i+1]);

      return perimeter;
    }
    __CV_END__;
  }

  double cvContourPolygonCircularity(const CvContourPolygon *p)
  {
    CV_FUNCNAME("cvContourPolygonCircularity");
    __CV_BEGIN__;
    {
      CV_ASSERT(p!=NULL);

      double l = cvContourPolygonPerimeter(p);
      double c = (l*l/cvContourPolygonArea(p)) - 4.*pi;

      if (c>=0.)
        return c;
      else // This could happen if the blob it's only a pixel: the perimeter will be 0. Another solution would be to force "cvContourPolygonPerimeter" to be 1 or greater.
        return 0.;
    }
    __CV_END__;
  }

  void simplifyPolygonRecursive(CvContourPolygon const *p, int const i1, int const i2, bool *pnUseFlag, double const delta)
  {
    CV_FUNCNAME("cvSimplifyPolygonRecursive");
    __CV_BEGIN__;
    {
      int endIndex = (i2<0)?p->size():i2;

      if (abs(i1-endIndex)<=1)
	return;

      CvPoint firstPoint = (*p)[i1];
      CvPoint lastPoint = (i2<0)?p->front():(*p)[i2];

      double furtherDistance=0.;
      int furtherIndex=0;

      for (int i=i1+1; i<endIndex; i++)
      {
	double d = cvDistanceLinePoint(firstPoint, lastPoint, (*p)[i]);

	if ((d>=delta)&&(d>furtherDistance))
	{
	  furtherDistance=d;
	  furtherIndex=i;
	}
      }

      if (furtherIndex)
      {
	pnUseFlag[furtherIndex]=true;

	simplifyPolygonRecursive(p, i1, furtherIndex, pnUseFlag, delta);
	simplifyPolygonRecursive(p, furtherIndex, i2, pnUseFlag, delta);
      }
    }
    __CV_END__;
  }

  CvContourPolygon *cvSimplifyPolygon(CvContourPolygon const *p, double const delta)
  {
    CV_FUNCNAME("cvSimplifyPolygon");
    __CV_BEGIN__;
    {
      CV_ASSERT(p!=NULL);

      double furtherDistance=0.;
      unsigned int furtherIndex=0;

      CvContourPolygon::const_iterator it=p->begin();
      ++it;
      for (unsigned int i=1; it!=p->end(); ++it, i++)
      {
	double d = cvDistancePointPoint(*it, p->front());

	if (d>furtherDistance)
	{
	  furtherDistance = d;
	  furtherIndex = i;
	}
      }

      if (furtherDistance<delta)
      {
	CvContourPolygon *result = new CvContourPolygon;
	result->push_back(p->front());
	return result;
      }

      bool *pnUseFlag = new bool[p->size()];
      for (unsigned int i=1; i<p->size(); i++) pnUseFlag[i] = false;

      pnUseFlag[0] = pnUseFlag[furtherIndex] = true;

      simplifyPolygonRecursive(p, 0, furtherIndex, pnUseFlag, delta);
      simplifyPolygonRecursive(p, furtherIndex, -1, pnUseFlag, delta);

      CvContourPolygon *result = new CvContourPolygon;

      for (unsigned int i=0; i<p->size(); i++)
	if (pnUseFlag[i])
	  result->push_back((*p)[i]);

      delete[] pnUseFlag;

      return result;
    }
    __CV_END__;
  }

  CvContourPolygon *cvPolygonContourConvexHull(CvContourPolygon const *p)
  {
    CV_FUNCNAME("cvPolygonContourConvexHull");
    __CV_BEGIN__;
    {
      CV_ASSERT(p!=NULL);
      
      if (p->size()<=3)
      {
	return new CvContourPolygon(p->begin(), p->end());
      }

      deque<CvPoint> dq;

      if (cvCrossProductPoints((*p)[0], (*p)[1], (*p)[2])>0)
      {
	dq.push_back((*p)[0]);
	dq.push_back((*p)[1]);
      }
      else
      {
	dq.push_back((*p)[1]);
	dq.push_back((*p)[0]);
      }

      dq.push_back((*p)[2]);
      dq.push_front((*p)[2]);

      for (unsigned int i=3; i<p->size(); i++)
      {
	int s = dq.size();

	if ((cvCrossProductPoints((*p)[i], dq.at(0), dq.at(1))>=0) && (cvCrossProductPoints(dq.at(s-2), dq.at(s-1), (*p)[i])>=0))
	  continue; // TODO Optimize.

	while (cvCrossProductPoints(dq.at(s-2), dq.at(s-1), (*p)[i])<0)
	{
	  dq.pop_back();
	  s = dq.size();
	}

	dq.push_back((*p)[i]);

	while (cvCrossProductPoints((*p)[i], dq.at(0), dq.at(1))<0)
	  dq.pop_front();

	dq.push_front((*p)[i]);
      }

      return new CvContourPolygon(dq.begin(), dq.end());
    }
    __CV_END__;
  }

  void cvWriteContourPolygonCSV(const CvContourPolygon& p, const string& filename)
  {
    ofstream f;
    f.open(filename.c_str());

    f << p << endl;

    f.close();
  }

  void cvWriteContourPolygonSVG(const CvContourPolygon& p, const string& filename, const CvScalar& stroke, const CvScalar& fill)
  {
    int minx=INT_MAX;
    int miny=INT_MAX;
    int maxx=INT_MIN;
    int maxy=INT_MIN;

    stringstream buffer("");

    for (CvContourPolygon::const_iterator it=p.begin(); it!=p.end(); ++it)
    {
      if (it->x>maxx)
	maxx = it->x;
      if (it->x<minx)
	minx = it->x;

      if (it->y>maxy)
	maxy = it->y;
      if (it->y<miny)
	miny = it->y;

      buffer << it->x << "," << it->y << " ";
    }

    ofstream f;
    f.open(filename.c_str());

    f << "<?xml version=\"1.0\" encoding=\"ISO-8859-1\" standalone=\"no\"?>" << endl;
    f << "<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 20010904//EN\" \"http://www.w3.org/TR/2001/REC-SVG-20010904/DTD/svg10.dtd\">" << endl;
    f << "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" xml:space=\"preserve\" width=\"" << maxx-minx << "px\" height=\"" << maxy-miny << "px\" viewBox=\"" << minx << " " << miny << " " << maxx << " " << maxy << "\" zoomAndPan=\"disable\" >" << endl;

    f << "<polygon fill=\"rgb(" << fill.val[0] << "," << fill.val[1] << "," << fill.val[2] << ")\" stroke=\"rgb(" << stroke.val[0] << "," << stroke.val[1] << "," << stroke.val[2] << ")\" stroke-width=\"1\" points=\"" << buffer.str() << "\"/>" << endl;

    f << "</svg>" << endl;

    f.close();
  }

}

ostream& operator<< (ostream& output, const cvb::CvContourPolygon& p)
{
  for (cvb::CvContourPolygon::const_iterator it=p.begin(); it!=p.end(); ++it)
    output << it->x << ", " << it->y << endl;

  return output;
}
