using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// samples/c/polar_transform.c
    /// </summary>
    class PolarTransForm
    {
        public PolarTransForm()
        {
            using (IplImage imgSrc = Cv.LoadImage(Const.ImageFruits, LoadMode.Color))
            using (IplImage imgLog = Cv.CreateImage(Cv.Size(256, 256), BitDepth.U8, 3))
            using (IplImage imgLinear = Cv.CreateImage(Cv.Size(256, 256), BitDepth.U8, 3))
            using (IplImage imgRecovered1 = Cv.CreateImage(Cv.GetSize(imgSrc), BitDepth.U8, 3))
            using (IplImage imgRecovered2 = Cv.CreateImage(Cv.GetSize(imgSrc), BitDepth.U8, 3))
            {
                Cv.LogPolar(imgSrc, imgLog, Cv.Point2D32f(imgSrc.Width / 2f, imgSrc.Height / 2f), 40, Interpolation.Linear | Interpolation.FillOutliers);
                Cv.LogPolar(imgLog, imgRecovered1, Cv.Point2D32f(imgSrc.Width / 2f, imgSrc.Height / 2f), 40, Interpolation.Linear | Interpolation.FillOutliers | Interpolation.InverseMap);

                Cv.LinearPolar(imgSrc, imgLinear, Cv.Point2D32f(imgSrc.Width / 2f, imgSrc.Height  / 2f), imgLinear.Width, Interpolation.Linear | Interpolation.FillOutliers);
                Cv.LinearPolar(imgLinear, imgRecovered2, Cv.Point2D32f(imgSrc.Width / 2f, imgSrc.Height / 2f), imgLinear.Width, Interpolation.InverseMap | Interpolation.Linear | Interpolation.FillOutliers);

                Cv.NamedWindow("log-polar");
                Cv.ShowImage("log-polar", imgLog);
                Cv.NamedWindow("inverse log-polar");
                Cv.ShowImage("inverse log-polar", imgRecovered1);
                Cv.NamedWindow("linear-polar");
                Cv.ShowImage("linear-polar", imgLinear);
                Cv.NamedWindow("inverse linear-polar");
                Cv.ShowImage("inverse linear-polar", imgRecovered2);
                Cv.WaitKey();
                Cv.DestroyAllWindows();
            }

        }
    }
}
