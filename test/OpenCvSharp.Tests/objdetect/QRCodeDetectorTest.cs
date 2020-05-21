using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

#pragma warning disable 162

// ReSharper disable UnusedVariable
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Tests.ObjDetect
{
    public class QRCodeDetectorTest : TestBase
    {
        [Fact]
        public void ExplicitlyDetectAndDecode()
        {
            using var obj = new QRCodeDetector();
            const int x = 100;
            const int y = 200;

            using var withQr = ImageWithQrCode(x, y, out var w, out var h);
            using var pointsMat = new Mat();
            ShowImagesWhenDebugMode(withQr);

            bool detected = obj.Detect(withQr, out var points);
            Assert.True(detected);
            Assert.Equal(4, points.Length);
            Assert.Equal(102, points[0].X, 6);
            Assert.Equal(201, points[0].Y, 6);
            Assert.Equal(199, points[1].X, 6);
            Assert.Equal(201, points[1].Y, 6);
            Assert.Equal(199, points[2].X, 6);
            Assert.Equal(299, points[2].Y, 6);
            Assert.Equal(102, points[3].X, 6);
            Assert.Equal(299, points[3].Y, 6);

            using var straightQrCode = new Mat();
            obj.Decode(withQr, points);
            var decodedString = obj.Decode(withQr, points, straightQrCode);
            Assert.False(straightQrCode.Empty());
            Assert.Equal("https://github.com/opencv/opencv", decodedString);
        }

        [Fact]
        public void DetectAndDecode()
        {
            using var obj = new QRCodeDetector();
            const int x = 100;
            const int y = 200;

            using var withQr = ImageWithQrCode(x, y, out var w, out var h);
            ShowImagesWhenDebugMode(withQr);

            using var straightQrCode = new Mat();
            var decodedString = obj.DetectAndDecode(withQr, out var points, straightQrCode);
            Assert.Equal(4, points.Length);
            Assert.Equal(102, points[0].X, 6);
            Assert.Equal(201, points[0].Y, 6);
            Assert.Equal(199, points[1].X, 6);
            Assert.Equal(201, points[1].Y, 6);
            Assert.Equal(199, points[2].X, 6);
            Assert.Equal(299, points[2].Y, 6);
            Assert.Equal(102, points[3].X, 6);
            Assert.Equal(299, points[3].Y, 6);

            Assert.False(straightQrCode.Empty());
            Assert.Equal("https://github.com/opencv/opencv", decodedString);
        }

        [Fact]
        public void DecodeSinglebyteString()
        {
            using var obj = new QRCodeDetector();
            using var withQr = Image("qr_singlebyte_letters.png");

            var decodedString = obj.DetectAndDecode(withQr, out var points);

            Assert.Equal(4, points.Length);
            Assert.Equal("0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!\"#$%&'()*+,-./:;<=>?@[]^_`{|}", decodedString);
        }

        [Fact]
        public void DecodeMultibyteString()
        {
            using var obj = new QRCodeDetector();
            using var withQr = Image("qr_multibyte_letters.png");

            var decodedString = obj.DetectAndDecode(withQr, out var points);

            Assert.Equal(4, points.Length);
            Assert.Equal("Helloこんにちは你好안녕하세요", decodedString);
        }

        [Fact]
        public void ExplicitlyDetectMulti()
        {
            using var obj = new QRCodeDetector();

            using var withQr = Image("qr_multi.png");
            using var pointsMat = new Mat();
            ShowImagesWhenDebugMode(withQr);

            bool detected = obj.DetectMulti(withQr, out var points);
            Assert.True(detected);
            Assert.Equal(8, points.Length);

            var expectedPoints = new[]
            {
                new Point2f(39, 39),
                new Point2f(260, 39),
                new Point2f(260, 260),
                new Point2f(39, 260),

                new Point2f(334, 334),
                new Point2f(565, 334),
                new Point2f(565, 565),
                new Point2f(334, 565),
            };
            AreEquivalent(expectedPoints, points);
        }

        [Fact]
        public void ExplicitlyDecodeMulti()
        {
            var expectedDecodedStrings = new[]
            {
                "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!\"#$%&'()*+,-./:;<=>?@[]^_`{|}",
                "Helloこんにちは你好안녕하세요"
            };

            using var obj = new QRCodeDetector();

            using var withQr = Image("qr_multi.png");
            using var pointsMat = new Mat();
            ShowImagesWhenDebugMode(withQr);

            bool detected = obj.DetectMulti(withQr, out var points);
            Assert.True(detected);
            Assert.Equal(8, points.Length);

            bool decoded = obj.DecodeMulti(withQr, points, out var decodedStrings, out var straightQrCode);
            Assert.True(decoded);
            Assert.Equal(2, decodedStrings.Length);
            AreEquivalent(expectedDecodedStrings, decodedStrings);

            foreach (var mat in straightQrCode)
            {
                ShowImagesWhenDebugMode(mat);
            }

            bool decodedWithoutStraightQrCode = obj.DecodeMulti(withQr, points, out decodedStrings);
            Assert.True(decodedWithoutStraightQrCode);
            Assert.Equal(2, decodedStrings.Length);
            AreEquivalent(expectedDecodedStrings, decodedStrings);
        }

        [Fact]
        public void EmptyDetectMulti()
        {
            var lenna = Image("lenna.png");

            using var obj = new QRCodeDetector();

            bool detected = obj.DetectMulti(lenna, out var points);
            Assert.False(detected);
            Assert.Empty(points);
        }

        private static Mat ImageWithQrCode(int x, int y, out int qrWidth, out int qrHeight)
        {
            var lenna = Image("lenna.png");
            using var qr = Image("qr.png");
            Assert.False(qr.Empty(), "Mat qr is empty.");
            qrWidth = qr.Width;
            qrHeight = qr.Height;

            var roi = new Rect(x, y, qr.Width, qr.Height);
            using var part = lenna[roi];
            qr.CopyTo(part);

            return lenna;
        }

        // ReSharper disable ParameterOnlyUsedForPreconditionCheck.Local

        private static void AreEquivalent(IEnumerable<Point2f> expectedPoints, IEnumerable<Point2f> actualPoints)
        {
            var orderedExpectedPoints = expectedPoints.OrderBy(p => p.X * 1000 + p.Y).ToArray();
            var orderedActualPoints = actualPoints.OrderBy(p => p.X * 1000 + p.Y).ToArray();

            Assert.Equal(orderedExpectedPoints.Length, orderedActualPoints.Length);

            foreach (var (p1, p2) in orderedExpectedPoints.Zip(orderedActualPoints, Tuple.Create))
            {
                Assert.Equal(p1.X, p2.X, 6);
                Assert.Equal(p1.Y, p2.Y, 6);
            }
        }

        private static void AreEquivalent<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            Assert.Equal(expected.OrderBy(_ => _), actual.OrderBy(_ => _));
        }
    }
}

