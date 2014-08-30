/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// AVI capture
    /// </summary>
    class CaptureAVI
    {
        public CaptureAVI()
        {
            using (CvCapture cap = CvCapture.FromFile(FilePath.Movie.Hara)) 
            using (CvWindow w = new CvWindow("SampleCapture"))
            {
                int interval = (int)(1000 / cap.Fps);
                while (true)
                {
                    IplImage image = cap.QueryFrame();
                    if (image == null)
                    {
                        break;
                    }
                    w.Image = image;
                    if (Cv.WaitKey(interval) > 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
