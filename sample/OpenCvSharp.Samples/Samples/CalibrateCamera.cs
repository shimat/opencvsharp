using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// カメラキャリブレーション
    /// </summary>
    /// <remarks>
    /// http://opencv.jp/sample/camera_calibration.html#calibration
    /// </remarks>
    class CalibrateCamera
    {
        public CalibrateCamera()
        {
            const int ImageNum = 3;           // 画像数
            const int PatRow = 7;              // パターンの行数 
            const int PatCol = 10;             // パターンの列数 
            const int PatSize = PatRow * PatCol;
            const int AllPoints = ImageNum * PatSize;
            const float ChessSize = 24.0f;     // パターン1マスの1辺サイズ[mm]            

            // (1)キャリブレーション画像の読み込み
            IplImage[] srcImg = new IplImage[ImageNum];
            for (int i = 0; i < ImageNum; i++)
            {
                srcImg[i] = new IplImage(string.Format(Const.ImageCalibration, i), LoadMode.Color);
            }

            // (2)3次元空間座標の設定
            CvPoint3D32f[,,] objects = new CvPoint3D32f[ImageNum, PatRow, PatCol];
            for (int i = 0; i < ImageNum; i++)
            {
                for (int j = 0; j < PatRow; j++)
                {
                    for (int k = 0; k < PatCol; k++)
                    {
                        objects[i, j, k] = new CvPoint3D32f
                        {
                            X = j * ChessSize,
                            Y = k * ChessSize,
                            Z = 0.0f
                        };
                    }
                }
            }
            CvMat objectPoints = new CvMat(AllPoints, 3, MatrixType.F32C1, objects);

            // (3)チェスボード（キャリブレーションパターン）のコーナー検出
            CvSize patternSize = new CvSize(PatCol, PatRow);

            int foundNum = 0;
            List<CvPoint2D32f> allCorners = new List<CvPoint2D32f>(AllPoints);
            int[] pointCountsValue = new int[ImageNum];
            using (CvWindow window = new CvWindow("Calibration", WindowMode.AutoSize))
            {
                for (int i = 0; i < ImageNum; i++)
                {
                    CvPoint2D32f[] corners;
                    bool found = Cv.FindChessboardCorners(srcImg[i], patternSize, out corners);
                    Debug.Print("{0:D2}...", i);
                    if (found)
                    {
                        Debug.Print("ok");
                        foundNum++;
                    }
                    else
                    {
                        Debug.Print("fail");
                    }
                    // (4)コーナー位置をサブピクセル精度に修正，描画                    
                    using (IplImage srcGray = new IplImage(srcImg[i].Size, BitDepth.U8, 1))
                    {
                        Cv.CvtColor(srcImg[i], srcGray, ColorConversion.BgrToGray);
                        Cv.FindCornerSubPix(srcGray, corners, corners.Length, new CvSize(3, 3), new CvSize(-1, -1), new CvTermCriteria(20, 0.03));
                        Cv.DrawChessboardCorners(srcImg[i], patternSize, corners, found);
                        pointCountsValue[i] = corners.Length;

                        window.ShowImage(srcImg[i]);
                        Cv.WaitKey(0);
                    }
                    allCorners.AddRange(corners);
                }
                if (foundNum != ImageNum)
                {
                    Debug.Assert(false);
                }
            }
 
            CvMat imagePoints = new CvMat(AllPoints, 1, MatrixType.F32C2, allCorners.ToArray());
            CvMat pointCounts = new CvMat(ImageNum, 1, MatrixType.S32C1, pointCountsValue);

            // (5)内部パラメータ，歪み係数の推定
            CvMat intrinsic = new CvMat(3, 3, MatrixType.F64C1);
            CvMat distortion = new CvMat(1, 4, MatrixType.F64C1);
            CvMat rotation = new CvMat(ImageNum, 3, MatrixType.F64C1);
            CvMat translation = new CvMat(ImageNum, 3, MatrixType.F64C1);

            Cv.CalibrateCamera2(objectPoints, imagePoints, pointCounts, srcImg[0].Size, intrinsic, distortion, rotation, translation, CalibrationFlag.Default);

            // (6)外部パラメータの推定 (1枚目の画像に対して)
            CvMat subImagePoints, subObjectPoints;
            Cv.GetRows(imagePoints, out subImagePoints, 0, PatSize);
            Cv.GetRows(objectPoints, out subObjectPoints, 0, PatSize);
            CvMat rotation_ = new CvMat(1, 3, MatrixType.F32C1);
            CvMat translation_ = new CvMat(1, 3, MatrixType.F32C1);

            Cv.FindExtrinsicCameraParams2(subObjectPoints, subImagePoints, intrinsic, distortion, rotation_, translation_, false);
            //Cv.FindExtrinsicCameraParams2_(subObjectPoints, subImagePoints, intrinsic, distortion, rotation_, translation_, false);

            // (7)XMLファイルへの書き出し
            using (CvFileStorage fs = new CvFileStorage("camera.xml", null, FileStorageMode.Write))
            {
                fs.Write("intrinsic", intrinsic);
                fs.Write("rotation", rotation_);
                fs.Write("translation", translation_);
                fs.Write("distortion", distortion);
            }

            foreach (IplImage img in srcImg)
            {
                img.Dispose();
            }

            // 書き込んだファイルを表示
            Console.WriteLine(File.ReadAllText("camera.xml"));
            Console.Read();
        }
    }
}
