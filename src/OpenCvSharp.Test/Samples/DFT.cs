using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 離散フーリエ変換
    /// </summary>
    /// <remarks>
    /// http://opencv.jp/sample/discrete_transforms.html#dft
    /// </remarks>
    class DFT
    {
        public DFT()
        {
            using (IplImage srcImg = Cv.LoadImage(Const.ImageGoryokaku, LoadMode.GrayScale))
            using (IplImage srcImgGauss = srcImg.Clone())
            {
                RunDFT(srcImg);
                Cv.Smooth(srcImg, srcImgGauss, SmoothType.Gaussian, 11);
                RunDFT(srcImgGauss);
                Cv.Smooth(srcImg, srcImgGauss, SmoothType.Gaussian, 31);
                RunDFT(srcImgGauss);
                Cv.Smooth(srcImg, srcImgGauss, SmoothType.Gaussian, 101);
                RunDFT(srcImgGauss);
            }
        }

        private void RunDFT(IplImage srcImg)
        {
            // cvDFT
            // 離散フーリエ変換を用いて，振幅画像を生成する．

            //using (IplImage srcImg = Cv.LoadImage(Const.ImageGoryokaku, LoadMode.GrayScale))
            using (IplImage realInput = Cv.CreateImage(srcImg.Size, BitDepth.F64, 1))
            using (IplImage imaginaryInput = Cv.CreateImage(srcImg.Size, BitDepth.F64, 1))
            using (IplImage complexInput = Cv.CreateImage(srcImg.Size, BitDepth.F64, 2))
            {
                // (1)入力画像を実数配列にコピーし，虚数配列とマージして複素数平面を構成
                Cv.Scale(srcImg, realInput, 1.0, 0.0);
                Cv.Zero(imaginaryInput);
                Cv.Merge(realInput, imaginaryInput, null, null, complexInput);
                // (2)DFT用の最適サイズを計算し，そのサイズで行列を確保する
                int dftM = Cv.GetOptimalDFTSize(srcImg.Height - 1);
                int dftN = Cv.GetOptimalDFTSize(srcImg.Width - 1);
                using (CvMat dft_A = Cv.CreateMat(dftM, dftN, MatrixType.F64C2))
                using (IplImage imageRe = new IplImage(new CvSize(dftN, dftM), BitDepth.F64, 1))
                using (IplImage imageIm = new IplImage(new CvSize(dftN, dftM), BitDepth.F64, 1))
                {
                    // (3)複素数平面をdft_Aにコピーし，残りの行列右側部分を0で埋める
                    CvMat tmp;
                    Cv.GetSubRect(dft_A, out tmp, new CvRect(0, 0, srcImg.Width, srcImg.Height));
                    Cv.Copy(complexInput, tmp, null);
                    if (dft_A.Cols > srcImg.Width)
                    {
                        Cv.GetSubRect(dft_A, out tmp, new CvRect(srcImg.Width, 0, dft_A.Cols - srcImg.Width, srcImg.Height));
                        Cv.Zero(tmp);
                    }
                    // (4)離散フーリエ変換を行い，その結果を実数部分と虚数部分に分解
                    Cv.DFT(dft_A, dft_A, DFTFlag.Forward, complexInput.Height);
                    Cv.Split(dft_A, imageRe, imageIm, null, null);
                    // (5)スペクトルの振幅を計算 Mag = sqrt(Re^2 + Im^2)
                    Cv.Pow(imageRe, imageRe, 2.0);
                    Cv.Pow(imageIm, imageIm, 2.0);
                    Cv.Add(imageRe, imageIm, imageRe, null);
                    Cv.Pow(imageRe, imageRe, 0.5);
                    // (6)振幅の対数をとる log(1 + Mag)  
                    Cv.AddS(imageRe, CvScalar.ScalarAll(1.0), imageRe, null);
                    Cv.Log(imageRe, imageRe);
                    // (7)原点（直流成分）が画像の中心にくるように，画像の象限を入れ替える
                    ShiftDFT(imageRe, imageRe);
                    // (8)振幅画像のピクセル値が0.0-1.0に分布するようにスケーリング
                    double m, M;
                    Cv.MinMaxLoc(imageRe, out m, out M);
                    Cv.Scale(imageRe, imageRe, 1.0 / (M - m), 1.0 * (-m) / (M - m));
                    using (new CvWindow("Image", WindowMode.AutoSize, srcImg)) 
                    using (new CvWindow("Magnitude", WindowMode.AutoSize, imageRe))
                    {
                        Cv.WaitKey(0);
                    }
                }
            }
        }

        /// <summary>
        /// 原点（直流成分）が画像の中心にくるように，画像の象限を入れ替える関数.
        /// srcArr, dstArr は同じサイズ，タイプの配列.
        /// </summary>
        /// <param name="srcArr"></param>
        /// <param name="dstArr"></param>
        private static void ShiftDFT(CvArr srcArr, CvArr dstArr)
        {
            CvSize size = Cv.GetSize(srcArr);
            CvSize dstSize = Cv.GetSize(dstArr);
            if (dstSize.Width != size.Width || dstSize.Height != size.Height)
            {
                throw new ApplicationException("Source and Destination arrays must have equal sizes");
            }
            // (9)インプレースモード用のテンポラリバッファ
            CvMat tmp = null;
            if (srcArr == dstArr)
            {
                tmp = Cv.CreateMat(size.Height / 2, size.Width / 2, Cv.GetElemType(srcArr));
            }
            int cx = size.Width / 2;   /* 画像中心 */
            int cy = size.Height / 2;
            
            // (10)1〜4象限を表す配列と，そのコピー先
            CvMat q1stub, q2stub;
            CvMat q3stub, q4stub;
            CvMat d1stub, d2stub;
            CvMat d3stub, d4stub;
            CvMat q1 = Cv.GetSubRect(srcArr, out q1stub, new CvRect(0, 0, cx, cy));
            CvMat q2 = Cv.GetSubRect(srcArr, out q2stub, new CvRect(cx, 0, cx, cy));
            CvMat q3 = Cv.GetSubRect(srcArr, out q3stub, new CvRect(cx, cy, cx, cy));
            CvMat q4 = Cv.GetSubRect(srcArr, out q4stub, new CvRect(0, cy, cx, cy));
            CvMat d1 = Cv.GetSubRect(srcArr, out d1stub, new CvRect(0, 0, cx, cy));
            CvMat d2 = Cv.GetSubRect(srcArr, out d2stub, new CvRect(cx, 0, cx, cy));
            CvMat d3 = Cv.GetSubRect(srcArr, out d3stub, new CvRect(cx, cy, cx, cy));
            CvMat d4 = Cv.GetSubRect(srcArr, out d4stub, new CvRect(0, cy, cx, cy));
            // (11)実際の象限の入れ替え
            if (srcArr != dstArr)
            {
                if (!Cv.ARE_TYPES_EQ(q1, d1))
                {
                    throw new ApplicationException("Source and Destination arrays must have the same format");
                }
                Cv.Copy(q3, d1, null);
                Cv.Copy(q4, d2, null);
                Cv.Copy(q1, d3, null);
                Cv.Copy(q2, d4, null);
            }
            else
            {      /* インプレースモード */
                Cv.Copy(q3, tmp, null);
                Cv.Copy(q1, q3, null);
                Cv.Copy(tmp, q1, null);
                Cv.Copy(q4, tmp, null);
                Cv.Copy(q2, q4, null);
                Cv.Copy(tmp, q2, null);
            }
            if (tmp != null)
            {
                tmp.Dispose();
            }
        }
    }
}
