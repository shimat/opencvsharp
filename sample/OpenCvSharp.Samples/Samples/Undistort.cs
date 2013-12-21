using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 歪み補正
    /// </summary>
    /// <remarks>http://opencv.jp/sample/camera_calibration.html#undistortion</remarks>
    class Undistort
    {
        public Undistort()
        {
            // cvUndistort2
            // キャリブレーションデータを利用して，歪みを補正する

            // (1)補正対象となる画像の読み込み
            using (IplImage srcImg = new IplImage(Const.ImageDistortion, LoadMode.Color))
            using (IplImage dstImg = srcImg.Clone())
            {

                // (2)パラメータファイルの読み込み
                CvMat intrinsic, distortion;
                using (CvFileStorage fs = new CvFileStorage(Const.XmlCamera, null, FileStorageMode.Read))
                {
                    CvFileNode param = fs.GetFileNodeByName(null, "intrinsic");
                    intrinsic = fs.Read<CvMat>(param);
                    param = fs.GetFileNodeByName(null, "distortion");
                    distortion = fs.Read<CvMat>(param);
                }

                // (3)歪み補正
                Cv.Undistort2(srcImg, dstImg, intrinsic, distortion);

                // (4)画像を表示，キーが押されたときに終了
                using (CvWindow w1 = new CvWindow("Distortion", WindowMode.AutoSize, srcImg))
                using (CvWindow w2 = new CvWindow("Undistortion", WindowMode.AutoSize, dstImg))
                {
                    CvWindow.WaitKey(0);
                }

                intrinsic.Dispose();
                distortion.Dispose();
            }
        }
    }
}
