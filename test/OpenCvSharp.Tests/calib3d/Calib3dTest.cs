using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable UnusedVariable
// ReSharper disable RedundantArgumentDefaultValue
// ReSharper disable JoinDeclarationAndInitializer

namespace OpenCvSharp.Tests.Calib3D
{
    public class Calib3DTest : TestBase
    {
        private readonly ITestOutputHelper output;

        public Calib3DTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Rodrigues()
        {
            const double angle = 45;
            double cos = Math.Cos(angle * Math.PI / 180);
            double sin = Math.Sin(angle * Math.PI / 180);
            var matrix = new double[3, 3]
            {
                {cos, -sin, 0},
                {sin, cos, 0},
                {0, 0, 1}
            };

            Cv2.Rodrigues(matrix, out var vector, out var jacobian);

            Assert.NotNull(vector);
            Assert.Equal(3, vector.Length);
            Assert.Equal(0, vector[0], 3);
            Assert.Equal(0, vector[1], 3);
            Assert.Equal(0.785, vector[2], 3);
            Assert.NotNull(jacobian);
            Assert.Equal(9, jacobian.GetLength(0));
            Assert.Equal(3, jacobian.GetLength(1));

            Cv2.Rodrigues(vector, out var matrix2, out var jacobian2);

            Assert.NotNull(matrix2);
            Assert.NotNull(jacobian2);
            Assert.Equal(3, matrix2.GetLength(0));
            Assert.Equal(3, matrix2.GetLength(1));
            for (var i = 0; i < matrix2.GetLength(0); i++)
                for(var j = 0; j < matrix2.GetLength(1); j++)
                    Assert.Equal(matrix[i, j], matrix2[i, j], 3);
        }

        [Fact]
        public void CheckChessboard()
        {
            var patternSize = new Size(10, 7);

            using (var image1 = Image("calibration/00.jpg", ImreadModes.Grayscale))
            using (var image2 = Image("lenna.png", ImreadModes.Grayscale))
            {
                Assert.True(Cv2.CheckChessboard(image1, patternSize));
                Assert.False(Cv2.CheckChessboard(image2, patternSize));
            }
        }

        [Fact]
        public void FindChessboardCorners()
        {
            var patternSize = new Size(10, 7);

            using (var image = Image("calibration/00.jpg"))
            using (var corners = new Mat())
            {
                bool found = Cv2.FindChessboardCorners(image, patternSize, corners);
                
                if (Debugger.IsAttached)
                {
                    Cv2.DrawChessboardCorners(image, patternSize, corners, found);
                    Window.ShowImages(image);
                }

                Assert.True(found);
                Assert.Equal(70, corners.Total());
                Assert.Equal(MatType.CV_32FC2, corners.Type());
            }
        }

        [Fact]
        public void FindChessboardCornersSB()
        {
            var patternSize = new Size(10, 7);

            using (var image = Image("calibration/00.jpg"))
            using (var corners = new Mat())
            {
                bool found = Cv2.FindChessboardCornersSB(image, patternSize, corners);

                if (Debugger.IsAttached)
                {
                    Cv2.DrawChessboardCorners(image, patternSize, corners, found);
                    Window.ShowImages(image);
                }

                // TODO fail on appveyor
                //Assert.True(found);
                if (found)
                {
                    Assert.Equal(70, corners.Total());
                    Assert.Equal(MatType.CV_32FC2, corners.Type());
                }
                else
                {
                    output.WriteLine(@"!!! [FindChessboardCornersSB] chessboard not found");
                }
            }
        }

        [Fact]
        public void CalibrateCameraByArray()
        {
            var patternSize = new Size(10, 7);

            using (var image = Image("calibration/00.jpg"))
            using (var corners = new Mat<Point2f>())
            {
                Cv2.FindChessboardCorners(image, patternSize, corners);

                var objectPoints = Create3DChessboardCorners(patternSize, 1.0f);
                var imagePoints = corners.ToArray();
                var cameraMatrix = new double[,] {{1, 0, 0}, {0, 1, 0}, {0, 0, 1}};
                var distCoeffs = new double[5];

                var rms = Cv2.CalibrateCamera(new []{objectPoints}, new[]{imagePoints}, image.Size(), cameraMatrix,
                    distCoeffs, out var rotationVectors, out var translationVectors, 
                    CalibrationFlags.UseIntrinsicGuess | CalibrationFlags.FixK5);

                Assert.Equal(6.16, rms, 2);
                Assert.Contains(distCoeffs, d => Math.Abs(d) > 1e-20);
            }
        }

        [Fact]
        public void CalibrateCameraByMat()
        {
            var patternSize = new Size(10, 7);

            using (var image = Image("calibration/00.jpg"))
            using (var corners = new Mat<Point2f>())
            {
                Cv2.FindChessboardCorners(image, patternSize, corners);

                var objectPointsArray = Create3DChessboardCorners(patternSize, 1.0f).ToArray();
                var imagePointsArray = corners.ToArray();

                using (var objectPoints = Mat<Point3f>.FromArray(objectPointsArray))
                using (var imagePoints = Mat<Point2f>.FromArray(imagePointsArray))
                using (var cameraMatrix = new Mat<double>(Mat.Eye(3, 3, MatType.CV_64FC1)))
                using (var distCoeffs = new Mat<double>())
                {
                    var rms = Cv2.CalibrateCamera(new[] { objectPoints }, new[] { imagePoints }, image.Size(), cameraMatrix,
                        distCoeffs, out var rotationVectors, out var translationVectors,
                        CalibrationFlags.UseIntrinsicGuess | CalibrationFlags.FixK5);

                    var distCoeffValues = distCoeffs.ToArray();
                    Assert.Equal(6.16, rms, 2);
                    Assert.Contains(distCoeffValues, d => Math.Abs(d) > 1e-20);
                }
            }
        }
        
        [Fact]
        public void FishEyeCalibrate()
        {
            var patternSize = new Size(10, 7);

            using (var image = Image("calibration/00.jpg"))
            using (var corners = new Mat<Point2f>())
            {
                Cv2.FindChessboardCorners(image, patternSize, corners);

                var objectPointsArray = Create3DChessboardCorners(patternSize, 1.0f).ToArray();
                var imagePointsArray = corners.ToArray();

                using (var objectPoints = Mat<Point3f>.FromArray(objectPointsArray))
                using (var imagePoints = Mat<Point2f>.FromArray(imagePointsArray))
                using (var cameraMatrix = new Mat<double>(Mat.Eye(3, 3, MatType.CV_64FC1)))
                using (var distCoeffs = new Mat<double>())
                {
                    var rms = Cv2.FishEye.Calibrate(new[] { objectPoints }, new[] { imagePoints }, image.Size(), cameraMatrix,
                        distCoeffs, out var rotationVectors, out var translationVectors);

                    var distCoeffValues = distCoeffs.ToArray();
                    Assert.Equal(55.15, rms, 2);
                    Assert.Contains(distCoeffValues, d => Math.Abs(d) > 1e-20);
                    Assert.NotEmpty(rotationVectors);
                    Assert.NotEmpty(translationVectors);
                }
            }
        }

        /// <summary>
        /// https://stackoverflow.com/questions/25244603/opencvs-projectpoints-function
        /// </summary>
        [Fact]
        [SuppressMessage("ReSharper", "RedundantTypeArgumentsOfMethod")]
        public void ProjectPoints()
        {
            var objectPointsArray = Generate3DPoints().ToArray();
            using var objectPoints = new Mat(objectPointsArray.Length, 1, MatType.CV_64FC3, objectPointsArray);

            using var intrinsicMat = new Mat(3, 3, MatType.CV_64FC1);
            intrinsicMat.Set<double>(0, 0, 1.6415318549788924e+003);
            intrinsicMat.Set<double>(1, 0, 0);
            intrinsicMat.Set<double>(2, 0, 0);
            intrinsicMat.Set<double>(0, 1, 0);
            intrinsicMat.Set<double>(1, 1, 1.7067753507885654e+003);
            intrinsicMat.Set<double>(2, 1, 0);
            intrinsicMat.Set<double>(0, 2, 5.3262822453148601e+002);
            intrinsicMat.Set<double>(1, 2, 3.8095355839052968e+002);
            intrinsicMat.Set<double>(2, 2, 1);

            using var rVec = new Mat(3, 1, MatType.CV_64FC1);
            rVec.Set<double>(0, -3.9277902400761393e-002);
            rVec.Set<double>(1, 3.7803824407602084e-002);
            rVec.Set<double>(2, 2.6445674487856268e-002);

            using var tVec = new Mat(3, 1, MatType.CV_64FC1);
            tVec.Set<double>(0, 2.1158489381208221e+000);
            tVec.Set<double>(1, -7.6847683212704716e+000);
            tVec.Set<double>(2, 2.6169795190294256e+001);

            using var distCoeffs = new Mat(4, 1, MatType.CV_64FC1);  
            distCoeffs.Set<double>(0, 0);
            distCoeffs.Set<double>(1, 0);
            distCoeffs.Set<double>(2, 0);
            distCoeffs.Set<double>(3, 0);

            // without jacobian
            using var imagePoints = new Mat();
            Cv2.ProjectPoints(objectPoints, rVec, tVec, intrinsicMat, distCoeffs, imagePoints);

            // with jacobian
            using var jacobian = new Mat();
            Cv2.ProjectPoints(objectPoints, rVec, tVec, intrinsicMat, distCoeffs, imagePoints, jacobian);
        }

        /// <summary>
        /// https://stackoverflow.com/questions/25244603/opencvs-projectpoints-function
        /// </summary>
        [Fact]
        [SuppressMessage("ReSharper", "RedundantTypeArgumentsOfMethod")]
        public void FishEyeProjectPoints()
        {
            var objectPointsArray = Generate3DPoints().ToArray();
            using var objectPoints = new Mat(objectPointsArray.Length, 1, MatType.CV_64FC3, objectPointsArray);

            using var intrisicMat = new Mat(3, 3, MatType.CV_64FC1);
            intrisicMat.Set<double>(0, 0, 1.6415318549788924e+003);
            intrisicMat.Set<double>(1, 0, 0);
            intrisicMat.Set<double>(2, 0, 0);
            intrisicMat.Set<double>(0, 1, 0);
            intrisicMat.Set<double>(1, 1, 1.7067753507885654e+003);
            intrisicMat.Set<double>(2, 1, 0);
            intrisicMat.Set<double>(0, 2, 5.3262822453148601e+002);
            intrisicMat.Set<double>(1, 2, 3.8095355839052968e+002);
            intrisicMat.Set<double>(2, 2, 1);

            using var rVec = new Mat(3, 1, MatType.CV_64FC1);
            rVec.Set<double>(0, -3.9277902400761393e-002);
            rVec.Set<double>(1, 3.7803824407602084e-002);
            rVec.Set<double>(2, 2.6445674487856268e-002);

            using var tVec = new Mat(3, 1, MatType.CV_64FC1);
            tVec.Set<double>(0, 2.1158489381208221e+000);
            tVec.Set<double>(1, -7.6847683212704716e+000);
            tVec.Set<double>(2, 2.6169795190294256e+001);

            using var distCoeffs = new Mat(4, 1, MatType.CV_64FC1);
            distCoeffs.Set<double>(0, 0);
            distCoeffs.Set<double>(1, 0);
            distCoeffs.Set<double>(2, 0);
            distCoeffs.Set<double>(3, 0);

            // without jacobian
            using var imagePoints = new Mat();
            Cv2.FishEye.ProjectPoints(objectPoints, imagePoints, rVec, tVec, intrisicMat, distCoeffs, 0);

            // with jacobian
            using var jacobian = new Mat();
            Cv2.FishEye.ProjectPoints(objectPoints, imagePoints, rVec, tVec, intrisicMat, distCoeffs, 0, jacobian);
        }

        [Fact]
        public void SolvePnPTestByArray()
        {
            var rvec = new double[] { 0, 0, 0 };
            var tvec = new double[] { 0, 0, 0 };
            var cameraMatrix = new double[,]
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            };
            var dist = new double[] { 0, 0, 0, 0, 0 };

            var objPts = new []
            {
                new Point3f(0,0,1),
                new Point3f(1,0,1),
                new Point3f(0,1,1),
                new Point3f(1,1,1),
                new Point3f(1,0,2),
                new Point3f(0,1,2)
            };

            Cv2.ProjectPoints(objPts, rvec, tvec, cameraMatrix, dist, out var imgPts, out var jacobian);

            Cv2.SolvePnP(objPts, imgPts, cameraMatrix, dist, ref rvec, ref tvec);
        }
        
        [Fact]
        public void SolvePnPTestByMat()
        {
            var rvec = new double[] { 0, 0, 0 };
            var tvec = new double[] { 0, 0, 0 };
            var cameraMatrix = new double[,]
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            };
            var dist = new double[] { 0, 0, 0, 0, 0 };

            var objPts = new []
            {
                new Point3f(0,0,1),
                new Point3f(1,0,1),
                new Point3f(0,1,1),
                new Point3f(1,1,1),
                new Point3f(1,0,2),
                new Point3f(0,1,2)
            };

            Cv2.ProjectPoints(objPts, rvec, tvec, cameraMatrix, dist, out var imgPts, out var jacobian);

            using (var objPtsMat = new Mat(objPts.Length, 1, MatType.CV_32FC3, objPts))
            using (var imgPtsMat = new Mat(imgPts.Length, 1, MatType.CV_32FC2, imgPts))
            using (var cameraMatrixMat = Mat.Eye(3, 3, MatType.CV_64FC1))
            using (var distMat = Mat.Zeros(5, 0, MatType.CV_64FC1))
            using (var rvecMat = new Mat())
            using (var tvecMat = new Mat())
            {
                Cv2.SolvePnP(objPtsMat, imgPtsMat, cameraMatrixMat, distMat, rvecMat, tvecMat);
            }
        }

        [Fact]
        public void FindFundamentalMat()
        {
            var imgPt1 = new[]
            {
                new Point2d(1017.0883, 848.23529),
                new Point2d(1637, 848.23529),
                new Point2d(1637, 1648.7059),
                new Point2d(1017.0883, 1648.7059),
                new Point2d(2282.2144, 772),
                new Point2d(3034.9644, 772),
                new Point2d(3034.9644, 1744),
                new Point2d(2282.2144, 1744),
            };
            var imgPt2 = new[]
            {
                new Point2d(414.88824, 848.23529),
                new Point2d(1034.8, 848.23529),
                new Point2d(1034.8, 1648.7059),
                new Point2d(414.88824, 1648.7059),
                new Point2d(1550.9714, 772),
                new Point2d(2303.7214, 772),
                new Point2d(2303.7214, 1744),
                new Point2d(1550.9714, 1744),
            };

            using Mat f = Cv2.FindFundamentalMat(imgPt1, imgPt2, FundamentalMatMethod.Point8);
            Assert.True(f.Empty()); // TODO 
        }
        
        // https://github.com/shimat/opencvsharp/issues/1069
        [Fact]
        public void RecoverPose()
        {
            var essentialData = new double[,]
            {
                {1.503247056657373e-16, -7.074103796034695e-16, -7.781514175638166e-16},
                {6.720398606232961e-16, -6.189840821530359e-17, -0.7071067811865476},
                {7.781514175638166e-16, 0.7071067811865475, -2.033804841359975e-16}
            };
            using var essential = Mat.FromArray(essentialData);

            var p1Data = new[]
            {
                new Point2d(1017.0883, 848.23529),
                new Point2d(1637, 848.23529),
                new Point2d(1637, 1648.7059),
                new Point2d(1017.0883, 1648.7059),
                new Point2d(2282.2144, 772),
                new Point2d(3034.9644, 772),
                new Point2d(3034.9644, 1744),
                new Point2d(2282.2144, 1744)
            };
            var p2Data = new[]
            {
                new Point2d(414.88824, 848.23529),
                new Point2d(1034.8, 848.23529),
                new Point2d(1034.8, 1648.7059),
                new Point2d(414.88824, 1648.7059),
                new Point2d(1550.9714, 772),
                new Point2d(2303.7214, 772),
                new Point2d(2303.7214, 1744),
                new Point2d(1550.9714, 1744)
            };
            using var p1 = Mat.FromArray(p1Data);
            using var p2 = Mat.FromArray(p2Data);

            var kData = new double[,]
            {
                {3011, 0, 1637},
                {0, 3024, 1204},
                {0, 0, 1}
            };
            using var k = Mat.FromArray(kData);

            using var r = new Mat();
            using var t = new Mat();
            Cv2.RecoverPose(essential, p1, p2, k, r, t);

            Assert.False(r.Empty());
            Assert.False(t.Empty());
        }

        private static IEnumerable<Point3f> Create3DChessboardCorners(Size boardSize, float squareSize)
        {
            for (int y = 0; y < boardSize.Height; y++)
            {
                for (int x = 0; x < boardSize.Width; x++)
                {
                    yield return new Point3f(x * squareSize, y * squareSize, 0);
                }
            }
        }

        private static IEnumerable<Point3d> Generate3DPoints()
        {
            double x, y, z;

            x = .5; y = .5; z = -.5;
            yield return new Point3d(x, y, z);

            x = .5; y = .5; z = .5;
            yield return new Point3d(x, y, z);

            x = -.5; y = .5; z = .5;
            yield return new Point3d(x, y, z);

            x = -.5; y = .5; z = -.5;
            yield return new Point3d(x, y, z);

            x = .5; y = -.5; z = -.5;
            yield return new Point3d(x, y, z);

            x = -.5; y = -.5; z = -.5;
            yield return new Point3d(x, y, z);

            x = -.5; y = -.5; z = .5;
            yield return new Point3d(x, y, z);
        }
    }
}

