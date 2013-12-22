using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Blob
{
    internal static class BlobRenderer
    {
        public static unsafe void PerformOne(int[,] labels, CvBlob blob, IplImage imgSrc, IplImage imgDst,
            RenderBlobsMode mode, CvScalar color, double alpha)
        {
            if (labels == null)
                throw new ArgumentNullException("labels");
            if (blob == null)
                throw new ArgumentNullException("blob");
            if (imgSrc == null)
                throw new ArgumentNullException("imgSrc");
            if (imgDst == null)
                throw new ArgumentNullException("imgDst");
            if (imgDst.Depth != BitDepth.U8 || imgDst.NChannels != 3)
                throw new ArgumentException("'img' must be a 3-channel U8 image.");

            if ((mode & RenderBlobsMode.Color) == RenderBlobsMode.Color)
            {
                int stepSrc = imgSrc.WidthStep;
                int stepDst = imgDst.WidthStep;
                int widthSrc = imgSrc.Width;
                int heightSrc = imgSrc.Height;
                int offsetSrc = 0;
                int widthDst = imgDst.Width;
                int heightDst = imgDst.Height;
                int offsetDst = 0;
                if (imgSrc.ROIPointer != IntPtr.Zero)
                {
                    IplROI roi = imgSrc.ROIValue;
                    widthSrc = roi.width;
                    heightSrc = roi.height;
                    offsetSrc = (imgSrc.NChannels*roi.xOffset) + (roi.yOffset*stepSrc);
                }
                if (imgDst.ROIPointer != IntPtr.Zero)
                {
                    IplROI roi = imgDst.ROIValue;
                    widthDst = roi.width;
                    heightDst = roi.height;
                    offsetDst = (imgDst.NChannels*roi.xOffset) + (roi.yOffset*stepSrc);
                }

                byte* pSrc = (byte*) imgSrc.ImageData + offsetSrc + (blob.MinY*stepSrc);
                byte* pDst = (byte*) imgDst.ImageData + offsetDst + (blob.MinY*stepDst);

                for (int r = blob.MinY; r < blob.MaxY; r++)
                {
                    for (int c = blob.MinX; c < blob.MaxX; c++)
                    {
                        if (labels[r, c] == blob.Label)
                        {
                            pDst[c*3 + 0] = (byte) ((1.0 - alpha)*pSrc[c + 0] + alpha*color.Val0);
                            pDst[c*3 + 1] = (byte) ((1.0 - alpha)*pSrc[c + 1] + alpha*color.Val1);
                            pDst[c*3 + 2] = (byte) ((1.0 - alpha)*pSrc[c + 2] + alpha*color.Val2);
                        }
                    }
                    pSrc += stepSrc;
                    pDst += stepDst;
                }
            }

            if (mode != RenderBlobsMode.None)
            {
                if ((mode & RenderBlobsMode.BoundingBox) == RenderBlobsMode.BoundingBox)
                {
                    Cv.Rectangle(
                        imgDst,
                        new CvPoint(blob.MinX, blob.MinY),
                        new CvPoint(blob.MaxX - 1, blob.MaxY - 1),
                        new CvColor(255, 0, 0));
                }
                if ((mode & RenderBlobsMode.Angle) == RenderBlobsMode.Angle)
                {
                    double angle = CvBlobLib.Angle(blob);
                    double lengthLine = Math.Max(blob.MaxX - blob.MinX, blob.MaxY - blob.MinY)/2.0;
                    double x1 = blob.Centroid.X - lengthLine*Math.Cos(angle);
                    double y1 = blob.Centroid.Y - lengthLine*Math.Sin(angle);
                    double x2 = blob.Centroid.X + lengthLine*Math.Cos(angle);
                    double y2 = blob.Centroid.Y + lengthLine*Math.Sin(angle);
                    Cv.Line(imgDst, new CvPoint((int) x1, (int) y1), Cv.Point((int) x2, (int) y2),
                        new CvColor(0, 255, 0));
                }
                if ((mode & RenderBlobsMode.Centroid) == RenderBlobsMode.Centroid)
                {
                    Cv.Line(imgDst,
                        new CvPoint((int) blob.Centroid.X - 3, (int) blob.Centroid.Y),
                        new CvPoint((int) blob.Centroid.X + 3, (int) blob.Centroid.Y),
                        new CvColor(0, 0, 255));
                    Cv.Line(imgDst,
                        new CvPoint((int) blob.Centroid.X, (int) blob.Centroid.Y - 3),
                        new CvPoint((int) blob.Centroid.X, (int) blob.Centroid.Y + 3),
                        new CvColor(0, 0, 255));
                }
            }

        }

        public static void PerformMany(int[,] labels, CvBlobs blobs, IplImage imgSrc, IplImage imgDst,
            RenderBlobsMode mode, double alpha)
        {
            if (labels == null)
                throw new ArgumentNullException("labels");
            if (blobs == null)
                throw new ArgumentNullException("blobs");
            if (imgSrc == null)
                throw new ArgumentNullException("imgSrc");
            if (imgDst == null)
                throw new ArgumentNullException("imgDst");
            if (imgDst.Depth != BitDepth.U8 || imgDst.NChannels != 3)
                throw new ArgumentException("'img' must be a 3-channel U8 image.");

            CV_ASSERT(imgLabel && (imgLabel->depth == IPL_DEPTH_LABEL) && (imgLabel->nChannels == 1));
            CV_ASSERT(imgDest && (imgDest->depth == IPL_DEPTH_8U) && (imgDest->nChannels == 3));

            Palete pal;
            if (mode & CV_BLOB_RENDER_COLOR)
            {

                unsigned
                int colorCount = 0;
                for (CvBlobs::const_iterator it = blobs.begin(); it != blobs.end(); ++it)
                {
                    CvLabel label = (*it).second->label;

                    double r, g, b;

                    _HSV2RGB_((double) ((colorCount*77)%360), .5, 1., r, g, b);
                    colorCount++;

                    pal[label] = CV_RGB(r, g, b);
                }
            }

            for (CvBlobs::iterator it = blobs.begin(); it != blobs.end(); ++it)
                cvRenderBlob(imgLabel, (*it).second, imgSource, imgDest, mode, pal[(*it).second->label], alpha);

        }

    }
}
