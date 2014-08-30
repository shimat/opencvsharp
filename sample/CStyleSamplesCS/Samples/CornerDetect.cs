using System;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// Corner detection
    /// </summary>
    /// <remarks>
    /// http://opencv.jp/sample/gradient_edge_corner.html#goodfeatures
    /// </remarks>
    class CornerDetect
    {
        public CornerDetect()
        {
            int cornerCount = 150;

            using (IplImage dstImg1 = new IplImage(FilePath.Image.Lenna, LoadMode.AnyColor | LoadMode.AnyDepth))
            using (IplImage dstImg2 = dstImg1.Clone())
            using (IplImage srcImgGray = new IplImage(FilePath.Image.Lenna, LoadMode.GrayScale))
            using (IplImage eigImg = new IplImage(srcImgGray.GetSize(), BitDepth.F32, 1))
            using (IplImage tempImg = new IplImage(srcImgGray.GetSize(), BitDepth.F32, 1))
            {
                CvPoint2D32f[] corners;
                Cv.GoodFeaturesToTrack(srcImgGray, eigImg, tempImg, out corners, ref cornerCount, 0.1, 15);
                Cv.FindCornerSubPix(srcImgGray, corners, cornerCount, new CvSize(3, 3), new CvSize(-1, -1), new CvTermCriteria(20, 0.03));

                for (int i = 0; i < cornerCount; i++)
                    Cv.Circle(dstImg1, corners[i], 3, new CvColor(255, 0, 0), 2);

                cornerCount = 150;
                Cv.GoodFeaturesToTrack(srcImgGray, eigImg, tempImg, out corners, ref cornerCount, 0.1, 15, null, 3, true, 0.01);
                Cv.FindCornerSubPix(srcImgGray, corners, cornerCount, new CvSize(3, 3), new CvSize(-1, -1), new CvTermCriteria(20, 0.03));

                for (int i = 0; i < cornerCount; i++)
                    Cv.Circle(dstImg2, corners[i], 3, new CvColor(0, 0, 255), 2);

                using (new CvWindow("EigenVal", WindowMode.AutoSize, dstImg1)) 
                using (new CvWindow("Harris", WindowMode.AutoSize, dstImg2))
                {
                    Cv.WaitKey(0);
                }
            }
        }
    }
}
