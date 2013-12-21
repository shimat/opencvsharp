using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// samples/c/squares.c
    /// </summary>
    class Squares
    {
        const int Thresh = 50;
        const string WindowName = "Square Detection Demo";
        readonly string[] _names = { Const.ImageSquare1, Const.ImageSquare2, Const.ImageSquare3, Const.ImageSquare4, Const.ImageSquare5, Const.ImageSquare6, };

        public Squares()
        {
            // create memory storage that will contain all the dynamic data
            CvMemStorage storage = new CvMemStorage(0);

            for (int i = 0; i < _names.Length; i++)
            {
                // load i-th image
                using (IplImage img = new IplImage(_names[i], LoadMode.Color))
                {
                    // create window and a trackbar (slider) with parent "image" and set callback
                    // (the slider regulates upper threshold, passed to Canny edge detector) 
                    Cv.NamedWindow(WindowName, WindowMode.AutoSize);

                    // find and draw the squares
                    DrawSquares(img, FindSquares4(img, storage));                    
                }

                // clear memory storage - reset free space position
                storage.Clear(); 

                // wait for key.
                // Also the function cvWaitKey takes care of event processing
                int c = Cv.WaitKey(0);
                if ((char)c == 27)
                    break;
            }

            Cv.DestroyWindow(WindowName);
        }

        /// <summary>
        /// helper function:
        /// finds a cosine of Angle between vectors
        /// from pt0->pt1 and from pt0->pt2 
        /// </summary>
        /// <param name="pt1"></param>
        /// <param name="pt2"></param>
        /// <param name="pt0"></param>
        /// <returns></returns>
        static double Angle(CvPoint pt1, CvPoint pt2, CvPoint pt0)
        {
            double dx1 = pt1.X - pt0.X;
            double dy1 = pt1.Y - pt0.Y;
            double dx2 = pt2.X - pt0.X;
            double dy2 = pt2.Y - pt0.Y;
            return (dx1 * dx2 + dy1 * dy2) / Math.Sqrt((dx1 * dx1 + dy1 * dy1) * (dx2 * dx2 + dy2 * dy2) + 1e-10);
        }

        /// <summary>
        /// returns sequence of squares detected on the image.
        /// the sequence is stored in the specified memory storage
        /// </summary>
        /// <param name="img"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        static CvPoint[] FindSquares4(IplImage img, CvMemStorage storage)
        {
            const int N = 11;

            CvSize sz = new CvSize(img.Width & -2, img.Height & -2);
            IplImage timg = img.Clone(); // make a copy of input image
            IplImage gray = new IplImage(sz, BitDepth.U8, 1);
            IplImage pyr = new IplImage(sz.Width / 2, sz.Height / 2, BitDepth.U8, 3);
            // create empty sequence that will contain points -
            // 4 points per square (the square's vertices)
            CvSeq<CvPoint> squares = new CvSeq<CvPoint>(SeqType.Zero, CvSeq.SizeOf, storage);

            // select the maximum ROI in the image
            // with the width and height divisible by 2
            timg.ROI = new CvRect(0, 0, sz.Width, sz.Height);

            // down-Scale and upscale the image to filter out the noise
            Cv.PyrDown(timg, pyr, CvFilter.Gaussian5x5);
            Cv.PyrUp(pyr, timg, CvFilter.Gaussian5x5);
            IplImage tgray = new IplImage(sz, BitDepth.U8, 1);

            // find squares in every color plane of the image
            for (int c = 0; c < 3; c++)
            {
                // extract the c-th color plane
                timg.COI = c + 1;
                Cv.Copy(timg, tgray, null);

                // try several threshold levels
                for (int l = 0; l < N; l++)
                {
                    // hack: use Canny instead of zero threshold level.
                    // Canny helps to catch squares with gradient shading   
                    if (l == 0)
                    {
                        // apply Canny. Take the upper threshold from slider
                        // and set the lower to 0 (which forces edges merging) 
                        Cv.Canny(tgray, gray, 0, Thresh, ApertureSize.Size5);
                        // dilate canny output to remove potential
                        // holes between edge segments 
                        Cv.Dilate(gray, gray, null, 1);
                    }
                    else
                    {
                        // apply threshold if l!=0:
                        //     tgray(x,y) = gray(x,y) < (l+1)*255/N ? 255 : 0
                        Cv.Threshold(tgray, gray, (l + 1) * 255.0 / N, 255, ThresholdType.Binary);
                    }

                    // find contours and store them all as a list
                    CvSeq<CvPoint> contours;
                    Cv.FindContours(gray, storage, out contours, CvContour.SizeOf, ContourRetrieval.List, ContourChain.ApproxSimple, new CvPoint(0, 0));

                    // test each contour
                    while (contours != null)
                    {
                        // approximate contour with accuracy proportional
                        // to the contour perimeter
                        CvSeq<CvPoint> result = Cv.ApproxPoly(contours, CvContour.SizeOf, storage, ApproxPolyMethod.DP, contours.ContourPerimeter() * 0.02, false);
                        // square contours should have 4 vertices after approximation
                        // relatively large area (to filter out noisy contours)
                        // and be convex.
                        // Note: absolute value of an area is used because
                        // area may be positive or negative - in accordance with the
                        // contour orientation
                        if (result.Total == 4 && Math.Abs(result.ContourArea(CvSlice.WholeSeq)) > 1000 && result.CheckContourConvexity())
                        {
                            double s = 0;

                            for (int i = 0; i < 5; i++)
                            {
                                // find minimum Angle between joint
                                // edges (maximum of cosine)
                                if (i >= 2)
                                {
                                    double t = Math.Abs(Angle(result[i].Value, result[i - 2].Value, result[i - 1].Value));
                                    s = s > t ? s : t;
                                }
                            }

                            // if cosines of all angles are small
                            // (all angles are ~90 degree) then write quandrange
                            // vertices to resultant sequence 
                            if (s < 0.3)
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    //Console.WriteLine(result[i]);
                                    squares.Push(result[i].Value);
                                }
                            }
                        }

                        // take the next contour
                        contours = contours.HNext;
                    }
                }
            }

            // release all the temporary images
            gray.Dispose();
            pyr.Dispose();
            tgray.Dispose();
            timg.Dispose();

            return squares.ToArray();
        }


        /// <summary>
        /// the function draws all the squares in the image
        /// </summary>
        /// <param name="img"></param>
        /// <param name="squares"></param>
        static void DrawSquares(IplImage img, CvPoint[] squares)
        {
            using (IplImage cpy = img.Clone())
            {
                // read 4 sequence elements at a time (all vertices of a square)
                for (int i = 0; i < squares.Length; i += 4)
                {
                    CvPoint[] pt = new CvPoint[4];

                    // read 4 vertices
                    pt[0] = squares[i + 0];
                    pt[1] = squares[i + 1];
                    pt[2] = squares[i + 2];
                    pt[3] = squares[i + 3];

                    // draw the square as a closed polyline 
                    Cv.PolyLine(cpy, new CvPoint[][] { pt }, true, CvColor.Green, 3, LineType.AntiAlias, 0);
                }

                // show the resultant image
                Cv.ShowImage(WindowName, cpy);
            }
        }
    }
}
