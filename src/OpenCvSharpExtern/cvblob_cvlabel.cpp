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

#include <stdexcept>
#include <iostream>
using namespace std;

#include <opencv/cv.h>
#include "cvblob.h"

namespace cvb
{
	const char movesE[4][3][4] = { { { -1, -1, 3, CV_CHAINCODE_UP_LEFT }, { 0, -1, 0, CV_CHAINCODE_UP }, { 1, -1, 0, CV_CHAINCODE_UP_RIGHT } },
	{ { 1, -1, 0, CV_CHAINCODE_UP_RIGHT }, { 1, 0, 1, CV_CHAINCODE_RIGHT }, { 1, 1, 1, CV_CHAINCODE_DOWN_RIGHT } },
	{ { 1, 1, 1, CV_CHAINCODE_DOWN_RIGHT }, { 0, 1, 2, CV_CHAINCODE_DOWN }, { -1, 1, 2, CV_CHAINCODE_DOWN_LEFT } },
	{ { -1, 1, 2, CV_CHAINCODE_DOWN_LEFT }, { -1, 0, 3, CV_CHAINCODE_LEFT }, { -1, -1, 3, CV_CHAINCODE_UP_LEFT } }
	};

	const char movesI[4][3][4] = { { { 1, -1, 3, CV_CHAINCODE_UP_RIGHT }, { 0, -1, 0, CV_CHAINCODE_UP }, { -1, -1, 0, CV_CHAINCODE_UP_LEFT } },
	{ { -1, -1, 0, CV_CHAINCODE_UP_LEFT }, { -1, 0, 1, CV_CHAINCODE_LEFT }, { -1, 1, 1, CV_CHAINCODE_DOWN_LEFT } },
	{ { -1, 1, 1, CV_CHAINCODE_DOWN_LEFT }, { 0, 1, 2, CV_CHAINCODE_DOWN }, { 1, 1, 2, CV_CHAINCODE_DOWN_RIGHT } },
	{ { 1, 1, 2, CV_CHAINCODE_DOWN_RIGHT }, { 1, 0, 3, CV_CHAINCODE_RIGHT }, { 1, -1, 3, CV_CHAINCODE_UP_RIGHT } }
	};


	unsigned int cvLabel(IplImage const *img, IplImage *imgOut, CvBlobs &blobs)
	{
		CV_FUNCNAME("cvLabel");
		__CV_BEGIN__;
		{
			CV_ASSERT(img && (img->depth == IPL_DEPTH_8U) && (img->nChannels == 1));
			CV_ASSERT(imgOut && (imgOut->depth == IPL_DEPTH_LABEL) && (imgOut->nChannels == 1));

			unsigned int numPixels = 0;

			cvSetZero(imgOut);

			CvLabel label = 0;
			cvReleaseBlobs(blobs);

			unsigned int stepIn = img->widthStep / (img->depth / 8);
			unsigned int stepOut = imgOut->widthStep / (imgOut->depth / 8);
			unsigned int imgIn_width = img->width;
			unsigned int imgIn_height = img->height;
			unsigned int imgIn_offset = 0;
			unsigned int imgOut_width = imgOut->width;
			unsigned int imgOut_height = imgOut->height;
			unsigned int imgOut_offset = 0;
			if (img->roi)
			{
				imgIn_width = img->roi->width;
				imgIn_height = img->roi->height;
				imgIn_offset = img->roi->xOffset + (img->roi->yOffset * stepIn);
			}
			if (imgOut->roi)
			{
				imgOut_width = imgOut->roi->width;
				imgOut_height = imgOut->roi->height;
				imgOut_offset = imgOut->roi->xOffset + (imgOut->roi->yOffset * stepOut);
			}

			unsigned char *imgDataIn = (unsigned char *)img->imageData + imgIn_offset;
			CvLabel *imgDataOut = (CvLabel *)imgOut->imageData + imgOut_offset;

#define imageIn(X, Y) imgDataIn[(X) + (Y)*stepIn]
#define imageOut(X, Y) imgDataOut[(X) + (Y)*stepOut]

			CvLabel lastLabel = 0;
			CvBlob *lastBlob = NULL;

			for (unsigned int y = 0; y < imgIn_height; y++)
			{
				for (unsigned int x = 0; x < imgIn_width; x++)
				{
					if (imageIn(x, y))
					{
						bool labeled = imageOut(x, y);

						if ((!imageOut(x, y)) && ((y == 0) || (!imageIn(x, y - 1))))
						{
							labeled = true;

							// Label contour.
							label++;
							CV_ASSERT(label != CV_BLOB_MAX_LABEL);

							imageOut(x, y) = label;
							numPixels++;

							// XXX This is not necessary at all. I only do this for consistency.
							if (y > 0)
								imageOut(x, y - 1) = CV_BLOB_MAX_LABEL;

							CvBlob *blob = new CvBlob;
							blob->label = label;
							blob->area = 1;
							blob->minx = x; blob->maxx = x;
							blob->miny = y; blob->maxy = y;
							blob->m10 = x; blob->m01 = y;
							blob->m11 = x*y;
							blob->m20 = x*x; blob->m02 = y*y;
							blob->internalContours.clear();
							blobs.insert(CvLabelBlob(label, blob));

							lastLabel = label;
							lastBlob = blob;

							blob->contour.startingPoint = cvPoint(x, y);

							unsigned char direction = 1;
							unsigned int xx = x;
							unsigned int yy = y;


							bool contourEnd = false;

							do
							{
								for (unsigned int numAttempts = 0; numAttempts < 3; numAttempts++)
								{
									bool found = false;

									for (unsigned char i = 0; i < 3; i++)
									{
										int nx = xx + movesE[direction][i][0];
										int ny = yy + movesE[direction][i][1];
										if ((nx < imgIn_width) && (nx >= 0) && (ny < imgIn_height) && (ny >= 0))
										{
											if (imageIn(nx, ny))
											{
												found = true;

												blob->contour.chainCode.push_back(movesE[direction][i][3]);

												xx = nx;
												yy = ny;

												direction = movesE[direction][i][2];
												break;
											}
											else
											{
												imageOut(nx, ny) = CV_BLOB_MAX_LABEL;
											}
										}
									}

									if (!found)
										direction = (direction + 1) % 4;
									else
									{
										if (imageOut(xx, yy) != label)
										{
											imageOut(xx, yy) = label;
											numPixels++;

											if (xx<blob->minx) blob->minx = xx;
											else if (xx>blob->maxx) blob->maxx = xx;
											if (yy<blob->miny) blob->miny = yy;
											else if (yy>blob->maxy) blob->maxy = yy;

											blob->area++;
											blob->m10 += xx; blob->m01 += yy;
											blob->m11 += xx*yy;
											blob->m20 += xx*xx; blob->m02 += yy*yy;
										}

										break;
									}

									if (contourEnd = ((xx == x) && (yy == y) && (direction == 1)))
										break;
								}
							} while (!contourEnd);

						}

						if ((y + 1 < imgIn_height) && (!imageIn(x, y + 1)) && (!imageOut(x, y + 1)))
						{
							labeled = true;

							// Label internal contour
							CvLabel l;
							CvBlob *blob = NULL;

							if (!imageOut(x, y))
							{
								/*if (!imageOut(x-1, y))
								{
								cerr << "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" << endl;
								continue;
								}*/

								l = imageOut(x - 1, y);

								imageOut(x, y) = l;
								numPixels++;

								if (l == lastLabel)
									blob = lastBlob;
								else
								{
									blob = blobs.find(l)->second;
									lastLabel = l;
									lastBlob = blob;
								}
								blob->area++;
								blob->m10 += x; blob->m01 += y;
								blob->m11 += x*y;
								blob->m20 += x*x; blob->m02 += y*y;
							}
							else
							{
								l = imageOut(x, y);

								if (l == lastLabel)
									blob = lastBlob;
								else
								{
									blob = blobs.find(l)->second;
									lastLabel = l;
									lastBlob = blob;
								}
							}

							// XXX This is not necessary (I believe). I only do this for consistency.
							imageOut(x, y + 1) = CV_BLOB_MAX_LABEL;

							CvContourChainCode *contour = new CvContourChainCode;
							contour->startingPoint = cvPoint(x, y);

							unsigned char direction = 3;
							unsigned int xx = x;
							unsigned int yy = y;

							do
							{
								for (unsigned int numAttempts = 0; numAttempts < 3; numAttempts++)
								{
									bool found = false;

									for (unsigned char i = 0; i < 3; i++)
									{
										int nx = xx + movesI[direction][i][0];
										int ny = yy + movesI[direction][i][1];
										if (imageIn(nx, ny))
										{
											found = true;

											contour->chainCode.push_back(movesI[direction][i][3]);

											xx = nx;
											yy = ny;

											direction = movesI[direction][i][2];
											break;
										}
										else
										{
											imageOut(nx, ny) = CV_BLOB_MAX_LABEL;
										}
									}

									if (!found)
										direction = (direction + 1) % 4;
									else
									{
										if (!imageOut(xx, yy))
										{
											imageOut(xx, yy) = l;
											numPixels++;

											blob->area++;
											blob->m10 += xx; blob->m01 += yy;
											blob->m11 += xx*yy;
											blob->m20 += xx*xx; blob->m02 += yy*yy;
										}

										break;
									}
								}
							} while (!(xx == x && yy == y));

							blob->internalContours.push_back(contour);
						}

						//else if (!imageOut(x, y))
						if (!labeled)
						{
							// Internal pixel
							CvLabel l = imageOut(x - 1, y);

							imageOut(x, y) = l;
							numPixels++;

							CvBlob *blob = NULL;
							if (l == lastLabel)
								blob = lastBlob;
							else
							{
								blob = blobs.find(l)->second;
								lastLabel = l;
								lastBlob = blob;
							}
							blob->area++;
							blob->m10 += x; blob->m01 += y;
							blob->m11 += x*y;
							blob->m20 += x*x; blob->m02 += y*y;
						}
					}
				}
			}

			for (CvBlobs::iterator it = blobs.begin(); it != blobs.end(); ++it)
			{
				cvCentroid((*it).second);

				(*it).second->u11 = (*it).second->m11 - ((*it).second->m10*(*it).second->m01) / (*it).second->m00;
				(*it).second->u20 = (*it).second->m20 - ((*it).second->m10*(*it).second->m10) / (*it).second->m00;
				(*it).second->u02 = (*it).second->m02 - ((*it).second->m01*(*it).second->m01) / (*it).second->m00;

				double m00_2 = (*it).second->m00 * (*it).second->m00;

				(*it).second->n11 = (*it).second->u11 / m00_2;
				(*it).second->n20 = (*it).second->u20 / m00_2;
				(*it).second->n02 = (*it).second->u02 / m00_2;

				(*it).second->p1 = (*it).second->n20 + (*it).second->n02;

				double nn = (*it).second->n20 - (*it).second->n02;
				(*it).second->p2 = nn*nn + 4.*((*it).second->n11*(*it).second->n11);
			}

			return numPixels;

		}
		__CV_END__;
	}

	void cvFilterLabels(IplImage *imgIn, IplImage *imgOut, const CvBlobs &blobs)
	{
		CV_FUNCNAME("cvFilterLabels");
		__CV_BEGIN__;
		{
			CV_ASSERT(imgIn && (imgIn->depth == IPL_DEPTH_LABEL) && (imgIn->nChannels == 1));
			CV_ASSERT(imgOut && (imgOut->depth == IPL_DEPTH_8U) && (imgOut->nChannels == 1));

			int stepIn = imgIn->widthStep / (imgIn->depth / 8);
			int stepOut = imgOut->widthStep / (imgOut->depth / 8);
			int imgIn_width = imgIn->width;
			int imgIn_height = imgIn->height;
			int imgIn_offset = 0;
			int imgOut_width = imgOut->width;
			int imgOut_height = imgOut->height;
			int imgOut_offset = 0;
			if (imgIn->roi)
			{
				imgIn_width = imgIn->roi->width;
				imgIn_height = imgIn->roi->height;
				imgIn_offset = imgIn->roi->xOffset + (imgIn->roi->yOffset * stepIn);
			}
			if (imgOut->roi)
			{
				imgOut_width = imgOut->roi->width;
				imgOut_height = imgOut->roi->height;
				imgOut_offset = imgOut->roi->xOffset + (imgOut->roi->yOffset * stepOut);
			}

			char *imgDataOut = imgOut->imageData + imgOut_offset;
			CvLabel *imgDataIn = (CvLabel *)imgIn->imageData + imgIn_offset;

			for (unsigned int r = 0; r < (unsigned int)imgIn_height; r++,
				imgDataIn += stepIn, imgDataOut += stepOut)
			{
				for (unsigned int c = 0; c < (unsigned int)imgIn_width; c++)
				{
					if (imgDataIn[c])
					{
						if (blobs.find(imgDataIn[c]) == blobs.end()) imgDataOut[c] = 0x00;
						else imgDataOut[c] = (char)0xff;
					}
					else
						imgDataOut[c] = 0x00;
				}
			}
		}
		__CV_END__;
	}


	CvLabel cvGetLabel(IplImage const *img, unsigned int x, unsigned int y)
	{
		CV_FUNCNAME("cvGetLabel");
		__CV_BEGIN__;
		{
			CV_ASSERT(img && (img->depth == IPL_DEPTH_LABEL) && (img->nChannels == 1));

			int step = img->widthStep / (img->depth / 8);
			int img_width = 0;
			int img_height = 0;
			int img_offset = 0;
			if (img->roi)
			{
				img_width = img->roi->width;
				img_height = img->roi->height;
				img_offset = img->roi->xOffset + (img->roi->yOffset * step);
			}
			else
			{
				img_width = img->width;
				img_height = img->height;
			}

			CV_ASSERT((x >= 0) && (x < img_width) && (y >= 0) && (y < img_height));

			return ((CvLabel *)(img->imageData + img_offset))[x + y*step];
		}
		__CV_END__;
		return -1;
	}

}
