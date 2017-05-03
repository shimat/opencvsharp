using System;
using NUnit.Framework;

namespace OpenCvSharp.Tests.Aruco
{
    // ReSharper disable once InconsistentNaming

    [TestFixture]
    public class ArucoTest : TestBase
    {

        [Test]
        public void CreateDetectorParameters()
        {
            var param = DetectorParameters.Create();
            param.Dispose();
        }

        [Test]
        public void DetectorParametersProperties()
        {
            var param = OpenCvSharp.DetectorParameters.Create();

            const bool boolValue = true;
            const int intValue = 100;
            const double doubleValue = 10d;

            param.DoCornerRefinement = boolValue;

            param.AdaptiveThreshConstant = doubleValue;
            param.CornerRefinementMinAccuracy = doubleValue;
            param.ErrorCorrectionRate = doubleValue;
            param.MaxErroneousBitsInBorderRate = doubleValue;
            param.MaxMarkerPerimeterRate = doubleValue;
            param.MinCornerDistanceRate = doubleValue;
            param.MinMarkerDistanceRate = doubleValue;
            param.MinMarkerPerimeterRate = doubleValue;
            param.MinOtsuStdDev = doubleValue;
            param.PerspectiveRemoveIgnoredMarginPerCell = doubleValue;
            param.PolygonalApproxAccuracyRate = doubleValue;

            param.AdaptiveThreshWinSizeMax = intValue;
            param.AdaptiveThreshWinSizeStep = intValue;
            param.CornerRefinementMaxIterations = intValue;
            param.CornerRefinementWinSize = intValue;
            param.MarkerBorderBits = intValue;
            param.MinDistanceToBorder = intValue;
            param.PerspectiveRemovePixelPerCell = intValue;
            param.AdaptiveThreshWinSizeMin = intValue;

            Assert.AreEqual(boolValue, param.DoCornerRefinement);

            Assert.AreEqual(doubleValue, param.AdaptiveThreshConstant);
            Assert.AreEqual(doubleValue, param.CornerRefinementMinAccuracy);
            Assert.AreEqual(doubleValue, param.ErrorCorrectionRate);
            Assert.AreEqual(doubleValue, param.MaxErroneousBitsInBorderRate);
            Assert.AreEqual(doubleValue, param.MaxMarkerPerimeterRate);
            Assert.AreEqual(doubleValue, param.MinCornerDistanceRate);
            Assert.AreEqual(doubleValue, param.MinMarkerDistanceRate);
            Assert.AreEqual(doubleValue, param.MinMarkerPerimeterRate);
            Assert.AreEqual(doubleValue, param.MinOtsuStdDev);
            Assert.AreEqual(doubleValue, param.PerspectiveRemoveIgnoredMarginPerCell);
            Assert.AreEqual(doubleValue, param.PolygonalApproxAccuracyRate);

            Assert.AreEqual(intValue, param.AdaptiveThreshWinSizeMax);
            Assert.AreEqual(intValue, param.AdaptiveThreshWinSizeStep);
            Assert.AreEqual(intValue, param.CornerRefinementMaxIterations);
            Assert.AreEqual(intValue, param.CornerRefinementWinSize);
            Assert.AreEqual(intValue, param.MarkerBorderBits);
            Assert.AreEqual(intValue, param.MinDistanceToBorder);
            Assert.AreEqual(intValue, param.PerspectiveRemovePixelPerCell);
            Assert.AreEqual(intValue, param.AdaptiveThreshWinSizeMin);

            param.Dispose();
        }

        [Test]
        public void GetPredefinedDictionary()
        {
            foreach (PredefinedDictionaryName val in Enum.GetValues(typeof(PredefinedDictionaryName)))
            {
                var dict = OpenCvSharp.Aruco.GetPredefinedDictionary(val);
                dict.Dispose();
            }
        }

        [Test]
        public void DetectMarkers()
        {
            using (var image = Image("markers_6x6_250.png", ImreadModes.GrayScale))
            using (var dict = OpenCvSharp.Aruco.GetPredefinedDictionary(PredefinedDictionaryName.Dict6X6_250))
            using (var param = DetectorParameters.Create())
            {
                Point2f[][] corners;
                int[] ids;
                Point2f[][] rejectedImgPoints;
                OpenCvSharp.Aruco.DetectMarkers(image, dict, out corners, out ids, param, out rejectedImgPoints);
            }
        }

        [Test]
        public void DictionaryProperties()
        {
            var dict = OpenCvSharp.Aruco.GetPredefinedDictionary(PredefinedDictionaryName.Dict6X6_250);
            Assert.AreEqual(250, dict.BytesList.Rows);
            Assert.AreEqual(5, dict.BytesList.Cols); // (6*6 + 7)/8
            Assert.AreEqual(6, dict.MarkerSize);
            Assert.AreEqual(5, dict.MaxCorrectionBits);

            dict.MarkerSize = 4;
            dict.MaxCorrectionBits = 50;
            Assert.AreEqual(4, dict.MarkerSize);
            Assert.AreEqual(50, dict.MaxCorrectionBits);
        }

        [Test]
        public void DrawMarker()
        {
            const int markerSidePixels = 128;
            const int columns = 4;
            const int rows = 5;
            const int margin = 20;

            // If you want to save markers image, you must change the following values.
            const bool output = false;
            const string path = "C:\\markers_6x6_250.png";

            int width = columns * markerSidePixels + margin * (columns + 1);
            int height = rows * markerSidePixels + margin * (rows + 1);

            var id = 0;
            Rect roi = new Rect(0, 0, markerSidePixels, markerSidePixels);
            using (var outputImage = new Mat(new Size(width, height), MatType.CV_8UC1, Scalar.White))
            {
                for (var y = 0; y < rows; y++)
                {
                    roi.Top = y * markerSidePixels + margin * (y + 1);

                    for (var x = 0; x < columns; x++)
                    {
                        roi.Left = x * markerSidePixels + margin * (x + 1);

                        using (var roiMat = new Mat(outputImage, roi))
                        using (var markerImage = new Mat())
                        using (var dict = OpenCvSharp.Aruco.GetPredefinedDictionary(PredefinedDictionaryName.Dict6X6_250))
                        {
                            OpenCvSharp.Aruco.DrawMarker(dict, id++, markerSidePixels, markerImage, 1);
                            markerImage.CopyTo(roiMat);
                        }
                    }
                }

                if (output)
                    OpenCvSharp.Cv2.ImWrite(path, outputImage);
            }
        }

        [Test]
        public void DrawDetectedMarker()
        {
            // If you want to save markers image, you must change the following values.
            const bool output = false;
            const string path = "C:\\detected_markers_6x6_250.png";

            using (var image = Image("markers_6x6_250.png", ImreadModes.GrayScale))
            using (var outputImage = image.CvtColor(ColorConversionCodes.GRAY2RGB))
            using (var dict = OpenCvSharp.Aruco.GetPredefinedDictionary(PredefinedDictionaryName.Dict6X6_250))
            using (var param = DetectorParameters.Create())
            {
                Point2f[][] corners;
                int[] ids;
                Point2f[][] rejectedImgPoints;
                OpenCvSharp.Aruco.DetectMarkers(image, dict, out corners, out ids, param, out rejectedImgPoints);

                OpenCvSharp.Aruco.DrawDetectedMarkers(outputImage, corners, ids, new Scalar(255, 0, 0));
                OpenCvSharp.Aruco.DrawDetectedMarkers(outputImage, rejectedImgPoints, null, new Scalar(0, 0, 255));

                if (output)
                    OpenCvSharp.Cv2.ImWrite(path, outputImage);
            }
        }
    }
}
