using System;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// 歪み補正
    /// </summary>
    /// <remarks>http://opencv.jp/sample/camera_calibration.html#undistortion</remarks>
    class Undistort
    {
        public Undistort()
        {
            using (IplImage srcImg = new IplImage(FilePath.Image.Distortion, LoadMode.Color))
            using (IplImage dstImg = srcImg.Clone())
            {
                CvMat intrinsic, distortion;
                using (CvFileStorage fs = new CvFileStorage(FilePath.Text.Camera, null, FileStorageMode.Read))
                {
                    CvFileNode param = fs.GetFileNodeByName(null, "intrinsic");
                    intrinsic = fs.Read<CvMat>(param);
                    param = fs.GetFileNodeByName(null, "distortion");
                    distortion = fs.Read<CvMat>(param);
                }
                
                Cv.Undistort2(srcImg, dstImg, intrinsic, distortion);

                using (new CvWindow("Distortion", WindowMode.AutoSize, srcImg))
                using (new CvWindow("Undistortion", WindowMode.AutoSize, dstImg))
                {
                    CvWindow.WaitKey(0);
                }

                intrinsic.Dispose();
                distortion.Dispose();
            }
        }
    }
}
