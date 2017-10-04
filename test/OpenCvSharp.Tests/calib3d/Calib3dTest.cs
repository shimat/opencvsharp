using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;

namespace OpenCvSharp.Tests.Calib3D
{
    public class Calib3DTest : TestBase
    {
        /// <summary>
        /// https://stackoverflow.com/questions/25244603/opencvs-projectpoints-function
        /// </summary>
        [Fact]
        public void ProjectPointsTest()
        {
            // Read 3D points
            var objectPointsArray = Generate3DPoints().ToArray();
            var objectPoints = new Mat(objectPointsArray.Length, 1, MatType.CV_64FC3, objectPointsArray);

            Mat intrisicMat = new Mat(3, 3, MatType.CV_64FC1); // Intrisic matrix
            intrisicMat.Set<double>(0, 0, 1.6415318549788924e+003);
            intrisicMat.Set<double>(1, 0,0);
            intrisicMat.Set<double>(2, 0,0);
            intrisicMat.Set<double>(0, 1,0);
            intrisicMat.Set<double>(1, 1,1.7067753507885654e+003);
            intrisicMat.Set<double>(2, 1,0);
            intrisicMat.Set<double>(0, 2,5.3262822453148601e+002);
            intrisicMat.Set<double>(1, 2,3.8095355839052968e+002);
            intrisicMat.Set<double>(2, 2,1);

            Mat rVec = new Mat(3, 1, MatType.CV_64FC1); // Rotation vector
            rVec.Set<double>(0, -3.9277902400761393e-002);
            rVec.Set<double>(1, 3.7803824407602084e-002);
            rVec.Set<double>(2, 2.6445674487856268e-002);

            Mat tVec = new Mat(3, 1, MatType.CV_64FC1); // Translation vector
            tVec.Set<double>(0, 2.1158489381208221e+000);
            tVec.Set<double>(1, -7.6847683212704716e+000);
            tVec.Set<double>(2, 2.6169795190294256e+001);

            Mat distCoeffs = new Mat(4, 1, MatType.CV_64FC1);   // Distortion vector
            /*distCoeffs.Set<double>(0, -7.9134632415085826e-001);
            distCoeffs.Set<double>(1, 1.5623584435644169e+000);
            distCoeffs.Set<double>(2, -3.3916502741726508e-002);
            distCoeffs.Set<double>(3, -1.3921577146136694e-002);
            distCoeffs.Set<double>(4, 1.1430734623697941e+002);*/
            distCoeffs.Set<double>(0, 0);
            distCoeffs.Set<double>(1, 0);
            distCoeffs.Set<double>(2, 0);
            distCoeffs.Set<double>(3, 0);

            // without jacobian
            Mat projectedPoints = new Mat();
            Cv2.ProjectPoints(objectPoints, rVec, tVec, intrisicMat, distCoeffs, projectedPoints);

            // with jacobian
            Mat jacobian = new Mat();
            Cv2.ProjectPoints(objectPoints, rVec, tVec, intrisicMat, distCoeffs, projectedPoints, jacobian);

            objectPoints.Dispose();
            intrisicMat.Dispose();
            rVec.Dispose();
            tVec.Dispose();
            distCoeffs.Dispose();
            projectedPoints.Dispose();
            jacobian.Dispose();
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

