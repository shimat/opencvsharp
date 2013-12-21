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
    /// 
    /// </summary>
    class CalibrateStereoCamera
    {
        const int ImageNum = 13;
        const int MaxScale = 2;
        static readonly CvSize BoardSize = new CvSize(9, 6);
        static readonly int AllPoints = ImageNum * BoardSize.Width * BoardSize.Height;
        const float SquareSize = 1.0f;

        public CalibrateStereoCamera()
        {
            // target filenames
            string[] pair = new string[] { "Data/Image/Calibration/left{0:D2}.jpg", "Data/Image/Calibration/right{0:D2}.jpg" };
            string[][] fileNames = new string[ImageNum][];
            for (int i = 0; i < ImageNum; i++)
            {
                fileNames[i] = new string[2] { string.Format(pair[0], i + 1), string.Format(pair[1], i + 1) };
            }

            // FindChessboardCorners
            CvPoint2D32f[] imagePointsLeft, imagePointsRight;
            int[] pointCountLeft, pointCountRight;
            int[] goodImagelist;
            FindChessboardCorners(fileNames, out imagePointsLeft, out imagePointsRight, out pointCountLeft, out pointCountRight, out goodImagelist);
            int nImages = goodImagelist.Length;

            // StereoCalibrate
            CvPoint3D32f[, ,] objects = new CvPoint3D32f[ImageNum, BoardSize.Height, BoardSize.Width];
            for (int i = 0; i < ImageNum; i++)
                for (int j = 0; j < BoardSize.Height; j++)
                    for (int k = 0; k < BoardSize.Width; k++)
                        objects[i, j, k] = new CvPoint3D32f(j * SquareSize, k * SquareSize, 0.0f);
            CvMat objectPoints = new CvMat(AllPoints, 3, MatrixType.F32C1, objects);

            CvMat imagePoints1 = new CvMat(AllPoints, 1, MatrixType.F32C2, imagePointsLeft);
            CvMat imagePoints2 = new CvMat(AllPoints, 1, MatrixType.F32C2, imagePointsRight);
            CvMat pointCount1 = new CvMat(nImages, 1, MatrixType.S32C1, pointCountLeft);
            CvMat pointCount2 = new CvMat(nImages, 1, MatrixType.S32C1, pointCountRight);

            CvMat cameraMatrix1 = CvMat.Identity(3, 3, MatrixType.F64C1);
            CvMat cameraMatrix2 = CvMat.Identity(3, 3, MatrixType.F64C1);
            CvMat distCoeffs1 = new CvMat(1, 4, MatrixType.F64C1);
            CvMat distCoeffs2 = new CvMat(1, 4, MatrixType.F64C1);
            CvMat R = new CvMat(3, 3, MatrixType.F64C1);
            CvMat T = new CvMat(3, 1, MatrixType.F64C1);
            
            Cv.StereoCalibrate(objectPoints, imagePoints1, imagePoints2, pointCount1,
                cameraMatrix1, distCoeffs1,
                cameraMatrix2, distCoeffs2,
                new CvSize(640, 480), R, T, null, null,
                new CvTermCriteria(100, 1e-5),
                CalibrationFlag.FixAspectRatio | CalibrationFlag.ZeroTangentDist | CalibrationFlag.SameFocalLength | 
                CalibrationFlag.RationalModel | CalibrationFlag.FixK3 | CalibrationFlag.FixK4 | CalibrationFlag.FixK5);

            // Rectify
            CvMat R1 = new CvMat(3, 3, MatrixType.F64C1);
            CvMat R2 = new CvMat(3, 3, MatrixType.F64C1);
            CvMat P1 = new CvMat(3, 4, MatrixType.F64C1);
            CvMat P2 = new CvMat(3, 4, MatrixType.F64C1);
            CvMat Q = new CvMat(4, 4, MatrixType.F64C1);

            Cv.StereoRectify(cameraMatrix1, cameraMatrix2, distCoeffs1, distCoeffs2,
              new CvSize(640, 480), R, T, R1, R2, P1, P2, Q,
              StereoRectificationFlag.ZeroDisparity, 1, new CvSize(640, 480)); 

            using (CvMemStorage mem = new CvMemStorage())
            using(CvFileStorage fs = new CvFileStorage("extrinsic.yml", mem, FileStorageMode.Write))
            {
                fs.Write("R", R);
                fs.Write("T", T);
                fs.Write("R1", R1);
                fs.Write("R2", R2);
                fs.Write("P1", P1);
                fs.Write("P1", P1);
                fs.Write("Q", Q);
            }
            Process.Start("notepad", "extrinsic.yml");

            Console.Read();
        }


        public void FindChessboardCorners(string[][] fileNames, out CvPoint2D32f[] imagePointsLeft, out CvPoint2D32f[] imagePointsRight, out int[] pointCountLeft, out int[] pointCountRight, out int[] goodImagelist)
        {
            List<CvPoint2D32f> imagePointsLeft_ = new List<CvPoint2D32f>();
            List<CvPoint2D32f> imagePointsRight_ = new List<CvPoint2D32f>();
            List<int> pointCountLeft_ = new List<int>();
            List<int> pointCountRight_ = new List<int>();
            List<int> goodImagelist_ = new List<int>();

            int i, j;
            for (i = 0; i < fileNames.Length; i++)
            {
                for (j = 0; j < 2; j++)
                {
                    IplImage img = new IplImage(fileNames[i][j], LoadMode.GrayScale);

                    bool found = false;
                    CvPoint2D32f[] corners = null;
                    int corner_count = 0;
                    for( int scale = 1; scale <= MaxScale; scale++ )
                    {
                        IplImage timg;
                        if( scale == 1 )
                            timg = img;
                        else{
                            timg = new IplImage(img.Width*scale, img.Height*scale, img.Depth, img.NChannels);
                            Cv.Resize(img, timg, Interpolation.Linear);
                        }
                        if (timg != img)
                            timg.Dispose();
                        
                        found = Cv.FindChessboardCorners(timg, BoardSize, out corners, out corner_count, ChessboardFlag.AdaptiveThresh | ChessboardFlag.NormalizeImage); 
                        if( found )
                        {
                            if( scale > 1 )
                            {
                                for (int l = 0; l < corners.Length; l++)
			                    {
			                        corners[i] *= 1.0/scale;
			                    }
                            }                            
                            break;
                        }
                    }
                    Console.Write(".");
                    if (found)
                        Cv.FindCornerSubPix(img, corners, corner_count, new CvSize(11, 11), new CvSize(-1, -1), new CvTermCriteria(30, 0.01));
                    if (j == 0)
                    {
                        imagePointsLeft_.AddRange(corners);
                        pointCountLeft_.Add(corner_count);
                    }
                    else
                    {
                        imagePointsRight_.AddRange(corners);
                        pointCountRight_.Add(corner_count);
                    }
                }
                if(j == 2)
                {
                    goodImagelist_.Add(i);
                }
            }

            imagePointsLeft = imagePointsLeft_.ToArray();
            imagePointsRight = imagePointsRight_.ToArray();
            pointCountLeft = pointCountLeft_.ToArray();
            pointCountRight = pointCountRight_.ToArray();
            goodImagelist = goodImagelist_.ToArray();
        }

    }
}
