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

#include <opencv/cv.h>
#include "cvblob.h"

namespace cvb
{

  //////////////////////////////////////////////////////////////////////////////////////////////////////////////
  // http://www.topcoder.com/tc?module=Static&d1=tutorials&d2=geometry1

  double cvDotProductPoints(CvPoint const &a, CvPoint const &b, CvPoint const &c)
  {
    double abx = b.x-a.x;
    double aby = b.y-a.y;
    double bcx = c.x-b.x;
    double bcy = c.y-b.y;

    return abx*bcx + aby*bcy;
  }

  double cvCrossProductPoints(CvPoint const &a, CvPoint const &b, CvPoint const &c)
  {
    double abx = b.x-a.x;
    double aby = b.y-a.y;
    double acx = c.x-a.x;
    double acy = c.y-a.y;

    return abx*acy - aby*acx;
  }

  double cvDistancePointPoint(CvPoint const &a, CvPoint const &b)
  {
    double abx = a.x-b.x;
    double aby = a.y-b.y;

    return sqrt(abx*abx + aby*aby);
  }

  double cvDistanceLinePoint(CvPoint const &a, CvPoint const &b, CvPoint const &c, bool isSegment)
  {
    if (isSegment)
    {
      double dot1 = cvDotProductPoints(a, b, c);
      if (dot1>0) return cvDistancePointPoint(b, c);

      double dot2 = cvDotProductPoints(b, a, c);
      if(dot2>0) return cvDistancePointPoint(a, c);
    }

    return fabs(cvCrossProductPoints(a,b,c)/cvDistancePointPoint(a,b));
  }
  //////////////////////////////////////////////////////////////////////////////////////////////////////////////

}
