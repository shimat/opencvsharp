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

/// \file cvblob.h
/// \brief OpenCV Blob header file.

#ifdef SWIG
%module cvblob
%{
#include "cvblob.h"
%}
#endif

#ifndef CVBLOB_H
#define CVBLOB_H

#include <iostream>
#include <map>
#include <list>
#include <vector>
#include <limits>

#include <opencv/cv.h>

#ifndef __CV_BEGIN__
#define __CV_BEGIN__ __BEGIN__
#endif
#ifndef __CV_END__
#define __CV_END__ __END__
#endif

#ifdef __cplusplus
extern "C" {
#endif

  namespace cvb
  {

  ////////////////////////////////////////////////////////////////////////////////////////////////////////////
  // Contours

  // Chain code:
  //        7 0 1
  //        6   2
  //        5 4 3
#define CV_CHAINCODE_UP		0 ///< Up.
#define CV_CHAINCODE_UP_RIGHT	1 ///< Up and right.
#define CV_CHAINCODE_RIGHT	2 ///< Right.
#define CV_CHAINCODE_DOWN_RIGHT	3 ///< Down and right.
#define CV_CHAINCODE_DOWN	4 ///< Down.
#define CV_CHAINCODE_DOWN_LEFT	5 ///< Down and left.
#define CV_CHAINCODE_LEFT	6 ///< Left.
#define CV_CHAINCODE_UP_LEFT	7 ///< Up and left.

  /// \brief Move vectors of chain codes.
  /// \see CV_CHAINCODE_UP
  /// \see CV_CHAINCODE_UP_LEFT
  /// \see CV_CHAINCODE_LEFT
  /// \see CV_CHAINCODE_DOWN_LEFT
  /// \see CV_CHAINCODE_DOWN
  /// \see CV_CHAINCODE_DOWN_RIGHT
  /// \see CV_CHAINCODE_RIGHT
  /// \see CV_CHAINCODE_UP_RIGHT
  const char cvChainCodeMoves[8][2] = { { 0, -1},
                                        { 1, -1},
					{ 1,  0},
					{ 1,  1},
					{ 0,  1},
					{-1,  1},
					{-1,  0},
					{-1, -1}
                                      };

  /// \brief Direction.
  /// \see CV_CHAINCODE_UP
  /// \see CV_CHAINCODE_UP_LEFT
  /// \see CV_CHAINCODE_LEFT
  /// \see CV_CHAINCODE_DOWN_LEFT
  /// \see CV_CHAINCODE_DOWN
  /// \see CV_CHAINCODE_DOWN_RIGHT
  /// \see CV_CHAINCODE_RIGHT
  /// \see CV_CHAINCODE_UP_RIGHT
  typedef unsigned char CvChainCode;

  /// \brief Chain code.
  /// \see CvChainCode
  typedef std::list<CvChainCode> CvChainCodes;

  /// \brief Chain code contour.
  /// \see CvChainCodes
  struct CvContourChainCode
  {
    CvPoint startingPoint; ///&lt; Point where contour begin.
    CvChainCodes chainCode; ///&lt; Polygon description based on chain codes.
  };

  typedef std::list<CvContourChainCode *> CvContoursChainCode; ///&lt; List of contours (chain codes type).

  /// \brief Polygon based contour.
  typedef std::vector<CvPoint> CvContourPolygon;

  /// \fn void cvRenderContourChainCode(CvContourChainCode const *contour, IplImage const *img, CvScalar const &color=CV_RGB(255, 255, 255))
  /// \brief Draw a contour.
  /// \param contour Chain code contour.
  /// \param img Image to draw on.
  /// \param color Color to draw (default, white).
  /// \see CvContourChainCode
  void cvRenderContourChainCode(CvContourChainCode const *contour, IplImage const *img, CvScalar const &color=CV_RGB(255, 255, 255));
  
  /// \fn CvContourPolygon *cvConvertChainCodesToPolygon(CvContourChainCode const *cc)
  /// \brief Convert a chain code contour to a polygon.
  /// \param cc Chain code contour.
  /// \return A polygon.
  /// \see CvContourChainCode
  /// \see CvContourPolygon
  CvContourPolygon *cvConvertChainCodesToPolygon(CvContourChainCode const *cc);

  /// \fn void cvRenderContourPolygon(CvContourPolygon const *contour, IplImage *img, CvScalar const &color=CV_RGB(255, 255, 255))
  /// \brief Draw a polygon.
  /// \param contour Polygon contour.
  /// \param img Image to draw on.
  /// \param color Color to draw (default, white).
  /// \see CvContourPolygon
  void cvRenderContourPolygon(CvContourPolygon const *contour, IplImage *img, CvScalar const &color=CV_RGB(255, 255, 255));

  /// \fn double cvContourPolygonArea(CvContourPolygon const *p)
  /// \brief Calculates area of a polygonal contour.
  /// \param p Contour (polygon type).
  /// \return Area of the contour.
  double cvContourPolygonArea(CvContourPolygon const *p);

  /// \fn double cvContourChainCodePerimeter(CvContourChainCode const *c)
  /// \brief Calculates perimeter of a chain code contour.
  /// \param c Contour (chain code type).
  /// \return Perimeter of the contour.
  double cvContourChainCodePerimeter(CvContourChainCode const *c);

  /// \fn double cvContourPolygonPerimeter(CvContourPolygon const *p)
  /// \brief Calculates perimeter of a polygonal contour.
  /// \param p Contour (polygon type).
  /// \return Perimeter of the contour.
  double cvContourPolygonPerimeter(CvContourPolygon const *p);

  /// \fn double cvContourPolygonCircularity(const CvContourPolygon *p)
  /// \brief Calculates the circularity of a polygon (compactness measure).
  /// \param p Contour (polygon type).
  /// \return Circularity: a non-negative value, where 0 correspond with a circumference.
  double cvContourPolygonCircularity(const CvContourPolygon *p);

  /// \fn CvContourPolygon *cvSimplifyPolygon(CvContourPolygon const *p, double const delta=1.)
  /// \brief Simplify a polygon reducing the number of vertex according the distance "delta".
  /// Uses a version of the Ramer-Douglas-Peucker algorithm (http://en.wikipedia.org/wiki/Ramer-Douglas-Peucker_algorithm).
  /// \param p Contour (polygon type).
  /// \param delta Minimun distance.
  /// \return A simplify version of the original polygon.
  CvContourPolygon *cvSimplifyPolygon(CvContourPolygon const *p, double const delta=1.);

  /// \fn CvContourPolygon *cvPolygonContourConvexHull(CvContourPolygon const *p)
  /// \brief Calculates convex hull of a contour.
  /// Uses the Melkman Algorithm. Code based on the version in http://w3.impa.br/~rdcastan/Cgeometry/.
  /// \param p Contour (polygon type).
  /// \return Convex hull.
  CvContourPolygon *cvPolygonContourConvexHull(CvContourPolygon const *p);

  /// \fn void cvWriteContourPolygonCSV(const CvContourPolygon& p, const std::string& filename)
  /// \brief Write a contour to a CSV (Comma-separated values) file.
  /// \param p Polygon contour.
  /// \param filename File name.
  void cvWriteContourPolygonCSV(const CvContourPolygon& p, const std::string& filename);

  /// \fn void cvWriteContourPolygonSVG(const CvContourPolygon& p, const std::string& filename, const CvScalar& stroke=cvScalar(0,0,0), const CvScalar& fill=cvScalar(255,255,255))
  /// \brief Write a contour to a SVG file (http://en.wikipedia.org/wiki/Scalable_Vector_Graphics).
  /// \param p Polygon contour.
  /// \param filename File name.
  /// \param stroke Stroke color (black by default).
  /// \param fill Fill color (white by default).
  void cvWriteContourPolygonSVG(const CvContourPolygon& p, const std::string& filename, const CvScalar& stroke=cvScalar(0,0,0), const CvScalar& fill=cvScalar(255,255,255));

  ////////////////////////////////////////////////////////////////////////////////////////////////////////////
  // Blobs

  /// \brief Type of label.
  /// \see IPL_DEPTH_LABEL
  typedef unsigned int CvLabel;
  //typedef unsigned char CvLabel;

  /// \def IPL_DEPTH_LABEL
  /// \brief Size of a label in bits.
  /// \see CvLabel
#define IPL_DEPTH_LABEL (sizeof(cvb::CvLabel)*8)

  /// \def CV_BLOB_MAX_LABEL
  /// \brief Max label number.
  /// \see CvLabel.
#define CV_BLOB_MAX_LABEL std::numeric_limits<CvLabel>::max()
  
  /// \brief Type of identification numbers.
  typedef unsigned int CvID;

  /// \brief Struct that contain information about one blob.
  struct CvBlob
  {
    CvLabel label; ///< Label assigned to the blob.
    
    union
    {
      unsigned int area; ///< Area (moment 00).
      unsigned int m00; ///< Moment 00 (area).
    };
    
    unsigned int minx; ///< X min.
    unsigned int maxx; ///< X max.
    unsigned int miny; ///< Y min.
    unsigned int maxy; ///< y max.
    
    CvPoint2D64f centroid; ///< Centroid.
    
    double m10; ///< Moment 10.
    double m01; ///< Moment 01.
    double m11; ///< Moment 11.
    double m20; ///< Moment 20.
    double m02; ///< Moment 02.
    
    double u11; ///< Central moment 11.
    double u20; ///< Central moment 20.
    double u02; ///< Central moment 02.

    double n11; ///< Normalized central moment 11.
    double n20; ///< Normalized central moment 20.
    double n02; ///< Normalized central moment 02.

    double p1; ///< Hu moment 1.
    double p2; ///< Hu moment 2.

    CvContourChainCode contour;           ///< Contour.
    CvContoursChainCode internalContours; ///< Internal contours.
  };
  
  /// \var typedef std::map<CvLabel,CvBlob *> CvBlobs
  /// \brief List of blobs.
  /// A map is used to access each blob from its label number.
  /// \see CvLabel
  /// \see CvBlob
  typedef std::map<CvLabel,CvBlob *> CvBlobs;

  /// \var typedef std::pair<CvLabel,CvBlob *> CvLabelBlob
  /// \brief Pair (label, blob).
  /// \see CvLabel
  /// \see CvBlob
  typedef std::pair<CvLabel,CvBlob *> CvLabelBlob;
  
  /// \fn unsigned int cvLabel (IplImage const *img, IplImage *imgOut, CvBlobs &blobs);
  /// \brief Label the connected parts of a binary image.
  /// Algorithm based on paper "A linear-time component-labeling algorithm using contour tracing technique" of Fu Chang, Chun-Jen Chen and Chi-Jen Lu.
  /// \param img Input binary image (depth=IPL_DEPTH_8U and num. channels=1).
  /// \param imgOut Output image (depth=IPL_DEPTH_LABEL and num. channels=1).
  /// \param blobs List of blobs.
  /// \return Number of pixels that has been labeled.
  unsigned int cvLabel (IplImage const *img, IplImage *imgOut, CvBlobs &blobs);

  //IplImage *cvFilterLabel(IplImage *imgIn, CvLabel label);

  /// \fn void cvFilterLabels(IplImage *imgIn, IplImage *imgOut, const CvBlobs &blobs)
  /// \brief Draw a binary image with the blobs that have been given.
  /// \param imgIn Input image (depth=IPL_DEPTH_LABEL and num. channels=1).
  /// \param imgOut Output binary image (depth=IPL_DEPTH_8U and num. channels=1).
  /// \param blobs List of blobs to be drawn.
  /// \see cvLabel
  void cvFilterLabels(IplImage *imgIn, IplImage *imgOut, const CvBlobs &blobs);

  /// \fn CvLabel cvGetLabel(IplImage const *img, unsigned int x, unsigned int y)
  /// \brief Get the label value from a labeled image.
  /// \param img Label image.
  /// \param x X coordenate.
  /// \param y Y coordenate.
  /// \return Label value.
  /// \see CvLabel
  CvLabel cvGetLabel(IplImage const *img, unsigned int x, unsigned int y);

  /// \fn inline void cvReleaseBlob(CvBlob *blob)
  /// \brief Clear a blob structure.
  /// \param blob Blob.
  /// \see CvBlob
  inline void cvReleaseBlob(CvBlob *blob)
  {
    if (blob)
    {
      for (CvContoursChainCode::iterator jt=blob->internalContours.begin(); jt!=blob->internalContours.end(); ++jt)
      {
	CvContourChainCode *contour = *jt;
	if (contour)
	  delete contour;
      }
      blob->internalContours.clear();

      delete blob;
    }
  }

  /// \fn inline void cvReleaseBlobs(CvBlobs &blobs)
  /// \brief Clear blobs structure.
  /// \param blobs List of blobs.
  /// \see CvBlobs
  inline void cvReleaseBlobs(CvBlobs &blobs)
  {
    for (CvBlobs::iterator it=blobs.begin(); it!=blobs.end(); ++it)
    {
      cvReleaseBlob((*it).second);
    }
    blobs.clear();
  }

  /// \fn CvLabel cvLargestBlob(const CvBlobs &blobs)
  /// \brief Find largest blob (biggest area).
  /// \param blobs List of blobs.
  /// \return Label of the largest blob or 0 if there are no blobs.
  /// \see cvLabel
  CvLabel cvLargestBlob(const CvBlobs &blobs);

  inline CvLabel cvGreaterBlob(const CvBlobs &blobs)
  {
    return cvLargestBlob(blobs);
  }

  /// \fn void cvFilterByArea(CvBlobs &blobs, unsigned int minArea, unsigned int maxArea)
  /// \brief Filter blobs by area.
  /// Those blobs whose areas are not in range will be erased from the input list of blobs.
  /// \param blobs List of blobs.
  /// \param minArea Minimun area.
  /// \param maxArea Maximun area.
  void cvFilterByArea(CvBlobs &blobs, unsigned int minArea, unsigned int maxArea);

  /// \fn void cvFilterByLabel(CvBlobs &blobs, CvLabel label)
  /// \brief Filter blobs by label.
  /// Delete all blobs except those with label l.
  /// \param blobs List of blobs.
  /// \param label Label to leave.
  void cvFilterByLabel(CvBlobs &blobs, CvLabel label);

  /// \fn inline CvPoint2D64f cvCentroid(CvBlob *blob)
  /// \brief Calculates centroid.
  /// Centroid will be returned and stored in the blob structure.
  /// \param blob Blob whose centroid will be calculated.
  /// \return Centroid.
  /// \see CvBlob
  inline CvPoint2D64f cvCentroid(CvBlob *blob)
  {
    return blob->centroid=cvPoint2D64f(blob->m10/blob->area, blob->m01/blob->area);
  }

  /// \fn double cvAngle(CvBlob *blob)
  /// \brief Calculates angle orientation of a blob.
  /// \param blob Blob.
  /// \return Angle orientation in radians.
  /// \see CvBlob
  double cvAngle(CvBlob *blob);

  /// \fn cvSaveImageBlob(const char *filename, IplImage *img, CvBlob const *blob)
  /// \brief Save the image of a blob to a file.
  /// The function uses an image (that can be the original pre-processed image or a processed one, or even the result of cvRenderBlobs, for example) and a blob structure.
  /// Then the function saves a copy of the part of the image where the blob is.
  /// \param filename Name of the file.
  /// \param img Image.
  /// \param blob Blob.
  /// \see CvBlob
  /// \see cvRenderBlob
  void cvSaveImageBlob(const char *filename, IplImage *img, CvBlob const *blob);
  
#define CV_BLOB_RENDER_COLOR            0x0001 ///< Render each blog with a different color. \see cvRenderBlobs
#define CV_BLOB_RENDER_CENTROID         0x0002 ///< Render centroid. \see cvRenderBlobs
#define CV_BLOB_RENDER_BOUNDING_BOX     0x0004 ///< Render bounding box. \see cvRenderBlobs
#define CV_BLOB_RENDER_ANGLE            0x0008 ///< Render angle. \see cvRenderBlobs
#define CV_BLOB_RENDER_TO_LOG           0x0010 ///< Print blob data to log out. \see cvRenderBlobs
#define CV_BLOB_RENDER_TO_STD           0x0020 ///< Print blob data to std out. \see cvRenderBlobs

  /// \fn void cvRenderBlob(const IplImage *imgLabel, CvBlob *blob, IplImage *imgSource, IplImage *imgDest, unsigned short mode=0x000f, CvScalar const &color=CV_RGB(255, 255, 255), double alpha=1.)
  /// \brief Draws or prints information about a blob.
  /// \param imgLabel Label image (depth=IPL_DEPTH_LABEL and num. channels=1).
  /// \param blob Blob.
  /// \param imgSource Input image (depth=IPL_DEPTH_8U and num. channels=3).
  /// \param imgDest Output image (depth=IPL_DEPTH_8U and num. channels=3).
  /// \param mode Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.
  /// \param color Color to render (if CV_BLOB_RENDER_COLOR is used).
  /// \param alpha If mode CV_BLOB_RENDER_COLOR is used. 1.0 indicates opaque and 0.0 translucent (1.0 by default).
  /// \see CV_BLOB_RENDER_COLOR
  /// \see CV_BLOB_RENDER_CENTROID
  /// \see CV_BLOB_RENDER_BOUNDING_BOX
  /// \see CV_BLOB_RENDER_ANGLE
  /// \see CV_BLOB_RENDER_TO_LOG
  /// \see CV_BLOB_RENDER_TO_STD
  void cvRenderBlob(const IplImage *imgLabel, CvBlob *blob, IplImage *imgSource, IplImage *imgDest, unsigned short mode=0x000f, CvScalar const &color=CV_RGB(255, 255, 255), double alpha=1.);

  /// \fn void cvRenderBlobs(const IplImage *imgLabel, CvBlobs &blobs, IplImage *imgSource, IplImage *imgDest, unsigned short mode=0x000f, double alpha=1.)
  /// \brief Draws or prints information about blobs.
  /// \param imgLabel Label image (depth=IPL_DEPTH_LABEL and num. channels=1).
  /// \param blobs List of blobs.
  /// \param imgSource Input image (depth=IPL_DEPTH_8U and num. channels=3).
  /// \param imgDest Output image (depth=IPL_DEPTH_8U and num. channels=3).
  /// \param mode Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.
  /// \param alpha If mode CV_BLOB_RENDER_COLOR is used. 1.0 indicates opaque and 0.0 translucent (1.0 by default).
  /// \see CV_BLOB_RENDER_COLOR
  /// \see CV_BLOB_RENDER_CENTROID
  /// \see CV_BLOB_RENDER_BOUNDING_BOX
  /// \see CV_BLOB_RENDER_ANGLE
  /// \see CV_BLOB_RENDER_TO_LOG
  /// \see CV_BLOB_RENDER_TO_STD
  void cvRenderBlobs(const IplImage *imgLabel, CvBlobs &blobs, IplImage *imgSource, IplImage *imgDest, unsigned short mode=0x000f, double alpha=1.);

  /// \fn void cvSetImageROItoBlob(IplImage *img, CvBlob const *blob)
  /// \brief Set the ROI of an image to the bounding box of a blob.
  /// \param img Image.
  /// \param blob Blob.
  /// \see CvBlob
  inline void cvSetImageROItoBlob(IplImage *img, CvBlob const *blob)
  {
    cvSetImageROI(img, cvRect(blob->minx, blob->miny, blob->maxx-blob->minx, blob->maxy-blob->miny));
  };

  ////////////////////////////////////////////////////////////////////////////////////////////////////////////
  // Color

  /// \fn CvScalar cvBlobMeanColor(CvBlob const *blob, IplImage const *imgLabel, IplImage const *img)
  /// \brief Calculates mean color of a blob in an image.
  /// \param blob Blob.
  /// \param imgLabel Image of labels.
  /// \param img Original image.
  /// \return Average color.
  CvScalar cvBlobMeanColor(CvBlob const *blob, IplImage const *imgLabel, IplImage const *img);
  
  ////////////////////////////////////////////////////////////////////////////////////////////////////////////
  // Aux
  
  /// \fn double cvDotProductPoints(CvPoint const &a, CvPoint const &b, CvPoint const &c)
  /// \brief Dot product of the vectors ab and bc.
  /// \param a First point.
  /// \param b Middle point.
  /// \param c Last point.
  /// \return Dot product of ab and bc.
  double cvDotProductPoints(CvPoint const &a, CvPoint const &b, CvPoint const &c);
  
  /// \fn double cvCrossProductPoints(CvPoint const &a, CvPoint const &b, CvPoint const &c)
  /// \brief Cross product of the vectors ab and bc.
  /// \param a Point.
  /// \param b Point.
  /// \param c Point.
  /// \return Cross product of ab and bc.
  double cvCrossProductPoints(CvPoint const &a, CvPoint const &b, CvPoint const &c);

  /// \fn double cvDistancePointPoint(CvPoint const &a, CvPoint const &b)
  /// \brief Distance between two points.
  /// \param a Point.
  /// \param b Point.
  /// \return Distance.
  double cvDistancePointPoint(CvPoint const &a, CvPoint const &b);

  /// \fn double cvDistanceLinePoint(CvPoint const &a, CvPoint const &b, CvPoint const &c, bool isSegment=true)
  /// \brief Distance between line ab and point c.
  /// \param a First point of the segment.
  /// \param b Second point of the segment.
  /// \param c Point.
  /// \param isSegment If false then the distance will be calculated from the line defined by the points a and b, to the point c.
  /// \return Distance between ab and c.
  double cvDistanceLinePoint(CvPoint const &a, CvPoint const &b, CvPoint const &c, bool isSegment=true);
  
  ////////////////////////////////////////////////////////////////////////////////////////////////////////////
  // Tracking

  /// \brief Struct that contain information about one track.
  /// \see CvID
  /// \see CvLabel
  struct CvTrack
  {
    CvID id; ///< Track identification number.

    CvLabel label; ///< Label assigned to the blob related to this track.

    unsigned int minx; ///< X min.
    unsigned int maxx; ///< X max.
    unsigned int miny; ///< Y min.
    unsigned int maxy; ///< y max.
    
    CvPoint2D64f centroid; ///< Centroid.

    unsigned int lifetime; ///< Indicates how much frames the object has been in scene.
    unsigned int active; ///< Indicates number of frames that has been active from last inactive period.
    unsigned int inactive; ///< Indicates number of frames that has been missing.
  };

  /// \var typedef std::map<CvID, CvTrack *> CvTracks
  /// \brief List of tracks.
  /// \see CvID
  /// \see CvTrack
  typedef std::map<CvID, CvTrack *> CvTracks;

  /// \var typedef std::pair<CvID, CvTrack *> CvIDTrack
  /// \brief Pair (identification number, track).
  /// \see CvID
  /// \see CvTrack
  typedef std::pair<CvID, CvTrack *> CvIDTrack;

  /// \fn inline void cvReleaseTracks(CvTracks &tracks)
  /// \brief Clear tracks structure.
  /// \param tracks List of tracks.
  /// \see CvTracks
  inline void cvReleaseTracks(CvTracks &tracks)
  {
    for (CvTracks::iterator it=tracks.begin(); it!=tracks.end(); it++)
    {
      CvTrack *track = (*it).second;
      if (track) delete track;
    }

    tracks.clear();
  }

  /// \fn cvUpdateTracks(CvBlobs const &b, CvTracks &t, const double thDistance, const unsigned int thInactive, const unsigned int thActive=0)
  /// \brief Updates list of tracks based on current blobs.
  /// Tracking based on:
  /// A. Senior, A. Hampapur, Y-L Tian, L. Brown, S. Pankanti, R. Bolle. Appearance Models for
  /// Occlusion Handling. Second International workshop on Performance Evaluation of Tracking and
  /// Surveillance Systems & CVPR'01. December, 2001.
  /// (http://www.research.ibm.com/peoplevision/PETS2001.pdf)
  /// \param b List of blobs.
  /// \param t List of tracks.
  /// \param thDistance Max distance to determine when a track and a blob match.
  /// \param thInactive Max number of frames a track can be inactive.
  /// \param thActive If a track becomes inactive but it has been active less than thActive frames, the track will be deleted.
  /// \see CvBlobs
  /// \see Tracks
  void cvUpdateTracks(CvBlobs const &b, CvTracks &t, const double thDistance, const unsigned int thInactive, const unsigned int thActive=0);

#define CV_TRACK_RENDER_ID            0x0001 ///< Print the ID of each track in the image. \see cvRenderTracks
#define CV_TRACK_RENDER_BOUNDING_BOX  0x0002 ///< Draw bounding box of each track in the image. \see cvRenderTracks
#define CV_TRACK_RENDER_TO_LOG        0x0010 ///< Print track info to log out. \see cvRenderTracks
#define CV_TRACK_RENDER_TO_STD        0x0020 ///< Print track info to log out. \see cvRenderTracks

  /// \fn void cvRenderTracks(CvTracks const tracks, IplImage *imgSource, IplImage *imgDest, unsigned short mode=0x00ff, CvFont *font=NULL)
  /// \brief Prints tracks information.
  /// \param tracks List of tracks.
  /// \param imgSource Input image (depth=IPL_DEPTH_8U and num. channels=3).
  /// \param imgDest Output image (depth=IPL_DEPTH_8U and num. channels=3).
  /// \param mode Render mode. By default is CV_TRACK_RENDER_ID|CV_TRACK_RENDER_BOUNDING_BOX.
  /// \param font OpenCV font for print on the image.
  /// \see CV_TRACK_RENDER_ID
  /// \see CV_TRACK_RENDER_BOUNDING_BOX
  /// \see CV_TRACK_RENDER_TO_LOG
  /// \see CV_TRACK_RENDER_TO_STD
  void cvRenderTracks(CvTracks const tracks, IplImage *imgSource, IplImage *imgDest, unsigned short mode=0x000f, CvFont *font=NULL);
  }
#ifdef __cplusplus
}
#endif

/// \fn std::ostream& operator<< (std::ostream& output, const cvb::CvBlob& b)
/// \brief Overload operator "<<" for printing blob structure.
/// \return Stream.
std::ostream& operator<< (std::ostream& output, const cvb::CvBlob& b);

/// \fn std::ostream& operator<< (std::ostream& output, const cvb::CvContourPolygon& p)
/// \brief Overload operator "<<" for printing polygons in CSV format.
/// \return Stream.
std::ostream& operator<< (std::ostream& output, const cvb::CvContourPolygon& p);

/// \fn std::ostream& operator<< (std::ostream& output, const cvb::CvTrack& t)
/// \brief Overload operator "<<" for printing track structure.
/// \return Stream.
std::ostream& operator<< (std::ostream& output, const cvb::CvTrack& t);
#endif
