using System;
using System.Diagnostics;
using OpenCvSharp.Aruco;
using Xunit;

namespace OpenCvSharp.Tests.Aruco
{
    // ReSharper disable once InconsistentNaming

    public class ArucoTest : TestBase
    {

        [Fact]
        public void CreateDetectorParameters()
        {
            var param = DetectorParameters.Create();
            param.Dispose();
        }

        [Fact]
        public void DetectorParametersProperties()
        {
            var param = DetectorParameters.Create();

            const int intValue = 100;
            const double doubleValue = 10d;

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

            Assert.Equal(doubleValue, param.AdaptiveThreshConstant);
            Assert.Equal(doubleValue, param.CornerRefinementMinAccuracy);
            Assert.Equal(doubleValue, param.ErrorCorrectionRate);
            Assert.Equal(doubleValue, param.MaxErroneousBitsInBorderRate);
            Assert.Equal(doubleValue, param.MaxMarkerPerimeterRate);
            Assert.Equal(doubleValue, param.MinCornerDistanceRate);
            Assert.Equal(doubleValue, param.MinMarkerDistanceRate);
            Assert.Equal(doubleValue, param.MinMarkerPerimeterRate);
            Assert.Equal(doubleValue, param.MinOtsuStdDev);
            Assert.Equal(doubleValue, param.PerspectiveRemoveIgnoredMarginPerCell);
            Assert.Equal(doubleValue, param.PolygonalApproxAccuracyRate);

            Assert.Equal(intValue, param.AdaptiveThreshWinSizeMax);
            Assert.Equal(intValue, param.AdaptiveThreshWinSizeStep);
            Assert.Equal(intValue, param.CornerRefinementMaxIterations);
            Assert.Equal(intValue, param.CornerRefinementWinSize);
            Assert.Equal(intValue, param.MarkerBorderBits);
            Assert.Equal(intValue, param.MinDistanceToBorder);
            Assert.Equal(intValue, param.PerspectiveRemovePixelPerCell);
            Assert.Equal(intValue, param.AdaptiveThreshWinSizeMin);

            param.Dispose();
        }

        [Fact]
        public void GetPredefinedDictionary()
        {
            foreach (PredefinedDictionaryName val in Enum.GetValues(typeof(PredefinedDictionaryName)))
            {
                var dict = CvAruco.GetPredefinedDictionary(val);
                dict.Dispose();
            }
        }

        [Fact]
        public void DetectMarkers()
        {
            using (var image = Image("markers_6x6_250.png", ImreadModes.GrayScale))
            using (var dict = CvAruco.GetPredefinedDictionary(PredefinedDictionaryName.Dict6X6_250))
            using (var param = DetectorParameters.Create())
            {
                Point2f[][] corners;
                int[] ids;
                Point2f[][] rejectedImgPoints;
                CvAruco.DetectMarkers(image, dict, out corners, out ids, param, out rejectedImgPoints);
            }
        }

        [Fact]
        public void DictionaryProperties()
        {
            var dict = CvAruco.GetPredefinedDictionary(PredefinedDictionaryName.Dict6X6_250);
            Assert.Equal(250, dict.BytesList.Rows);
            Assert.Equal(5, dict.BytesList.Cols); // (6*6 + 7)/8
            Assert.Equal(6, dict.MarkerSize);
            Assert.Equal(5, dict.MaxCorrectionBits);

            dict.MarkerSize = 4;
            dict.MaxCorrectionBits = 50;
            Assert.Equal(4, dict.MarkerSize);
            Assert.Equal(50, dict.MaxCorrectionBits);
        }

        [Fact]
        public void DrawMarker()
        {
            const int markerSidePixels = 128;
            const int columns = 4;
            const int rows = 5;
            const int margin = 20;

            // If you want to save markers image, you must change the following values.
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
                        using (var dict = CvAruco.GetPredefinedDictionary(PredefinedDictionaryName.Dict6X6_250))
                        {
                            CvAruco.DrawMarker(dict, id++, markerSidePixels, markerImage, 1);
                            markerImage.CopyTo(roiMat);
                        }
                    }
                }

                if (Debugger.IsAttached)
                {
                    Cv2.ImWrite(path, outputImage);
                    Process.Start(path);
                }
            }
        }

        [Fact]
        public void DrawDetectedMarker()
        {
            // If you want to save markers image, you must change the following values.
            const string path = "C:\\detected_markers_6x6_250.png";

            using (var image = Image("markers_6x6_250.png", ImreadModes.GrayScale))
            using (var outputImage = image.CvtColor(ColorConversionCodes.GRAY2RGB))
            using (var dict = CvAruco.GetPredefinedDictionary(PredefinedDictionaryName.Dict6X6_250))
            using (var param = DetectorParameters.Create())
            {
                Point2f[][] corners;
                int[] ids;
                Point2f[][] rejectedImgPoints;
                CvAruco.DetectMarkers(image, dict, out corners, out ids, param, out rejectedImgPoints);

                CvAruco.DrawDetectedMarkers(outputImage, corners, ids, new Scalar(255, 0, 0));
                CvAruco.DrawDetectedMarkers(outputImage, rejectedImgPoints, null, new Scalar(0, 0, 255));

                if (Debugger.IsAttached)
                {
                    Cv2.ImWrite(path, outputImage);
                    Process.Start(path);
                }
            }
        }
    }
}
