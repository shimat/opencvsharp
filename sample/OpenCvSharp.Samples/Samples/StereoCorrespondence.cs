using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp.CPlusPlus;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// ステレオマッチング
    /// </summary>
    class StereoCorrespondence
    {
        public StereoCorrespondence()
        {
            // cvFindStereoCorrespondenceBM + cvFindStereoCorrespondenceGC
            // ブロックマッチング, グラフカットの両アルゴリズムによるステレオマッチング

            // 入力画像の読み込み
            using (IplImage imgLeft = new IplImage(Const.ImageTsukubaLeft, LoadMode.GrayScale))
            using (IplImage imgRight = new IplImage(Const.ImageTsukubaRight, LoadMode.GrayScale))
            {
                // 視差画像, 出力画像の領域を確保
                using (IplImage dispBM = new IplImage(imgLeft.Size, BitDepth.S16, 1))
                using (IplImage dispLeft = new IplImage(imgLeft.Size, BitDepth.S16, 1))
                using (IplImage dispRight = new IplImage(imgLeft.Size, BitDepth.S16, 1))
                using (IplImage dstBM = new IplImage(imgLeft.Size, BitDepth.U8, 1))
                using (IplImage dstGC = new IplImage(imgLeft.Size, BitDepth.U8, 1))
                using (IplImage dstAux = new IplImage(imgLeft.Size, BitDepth.U8, 1))
                using (Mat dstSGBM = new Mat())
                {
                    // 距離計測とスケーリング  
                    int sad = 3;
                    using (CvStereoBMState stateBM = new CvStereoBMState(StereoBMPreset.Basic, 16))
                    using (CvStereoGCState stateGC = new CvStereoGCState(16, 2))
                    using (StereoSGBM sgbm = new StereoSGBM()
                        {
                            MinDisparity = 0,
                            NumberOfDisparities = 32,
                            PreFilterCap = 63,
                            SADWindowSize = sad,
                            P1 = 8 * imgLeft.NChannels * sad * sad,
                            P2 = 32 * imgLeft.NChannels * sad * sad,
                            UniquenessRatio = 10,
                            SpeckleWindowSize = 100,
                            SpeckleRange = 32,
                            Disp12MaxDiff = 1,
                            FullDP = false,
                        })
                    {
                        Cv.FindStereoCorrespondenceBM(imgLeft, imgRight, dispBM, stateBM);                      // stateBM.FindStereoCorrespondence(imgLeft, imgRight, dispBM);
                        Cv.FindStereoCorrespondenceGC(imgLeft, imgRight, dispLeft, dispRight, stateGC, false);  // stateGC.FindStereoCorrespondence(imgLeft, imgRight, dispLeft, dispRight, false);
                        Cv.FindStereoCorrespondence(imgLeft, imgRight, DisparityMode.Birchfield, dstAux, 50, 25, 5, 12, 15, 25);
                        sgbm.FindCorrespondence(new Mat(imgLeft), new Mat(imgRight), dstSGBM);

                        Cv.ConvertScale(dispBM, dstBM, 1);
                        Cv.ConvertScale(dispLeft, dstGC, -16);
                        Cv.ConvertScale(dstAux, dstAux, 16);
                        dstSGBM.ConvertTo(dstSGBM, dstSGBM.Type, 32, 0);                     

                        using (new CvWindow("Stereo Correspondence (BM)", dstBM))
                        using (new CvWindow("Stereo Correspondence (GC)", dstGC))
                        using (new CvWindow("Stereo Correspondence (cvaux)", dstAux))
                        using (new CvWindow("Stereo Correspondence (SGBM)", dstSGBM.ToIplImage()))
                        {
                            Cv.WaitKey();
                        }
                    }
                }
            }
        }
    }
}
