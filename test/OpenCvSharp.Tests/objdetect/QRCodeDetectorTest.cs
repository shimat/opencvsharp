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
            int x = 100;
            int y = 200;

            using var withQr = ImageWithQrCode(x, y, out int w, out int h);
            using var pointsMat = new Mat();
            ShowImagesWhenDebugMode(withQr);

            bool detected = obj.Detect(withQr, out var points);
            Assert.True(detected);
            Assert.Equal(4, points.Length);
            Assert.Equal(102, points[0].X);
            Assert.Equal(201, points[0].Y);
            Assert.Equal(199, points[1].X);
            Assert.Equal(201, points[1].Y);
            Assert.Equal(199, points[2].X);
            Assert.Equal(299, points[2].Y);
            Assert.Equal(102, points[3].X);
            Assert.Equal(299, points[3].Y);

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
            int x = 100;
            int y = 200;

            using var withQr = ImageWithQrCode(x, y, out int w, out int h);
            ShowImagesWhenDebugMode(withQr);

            using var straightQrCode = new Mat();
            var decodedString = obj.DetectAndDecode(withQr, out var points, straightQrCode);
            Assert.Equal(4, points.Length);
            Assert.Equal(102, points[0].X);
            Assert.Equal(201, points[0].Y);
            Assert.Equal(199, points[1].X);
            Assert.Equal(201, points[1].Y);
            Assert.Equal(199, points[2].X);
            Assert.Equal(299, points[2].Y);
            Assert.Equal(102, points[3].X);
            Assert.Equal(299, points[3].Y);

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
        public void ExplicitlyDetectMultiAndDecodeMulti()
        {
            using var obj = new QRCodeDetector();
            int x = 100;
            int y = 200;

            using var withQr = Image("qr_multi.png");
            using var pointsMat = new Mat();
            ShowImagesWhenDebugMode(withQr);

            bool detected = obj.DetectMulti(withQr, out var points);
            Assert.True(detected);
            Assert.Equal(8, points.Length);
            Assert.Equal(39, points[0].X);
            Assert.Equal(39, points[0].Y);
            Assert.Equal(260, points[1].X);
            Assert.Equal(39, points[1].Y);
            Assert.Equal(260, points[2].X);
            Assert.Equal(260, points[2].Y);
            Assert.Equal(39, points[3].X);
            Assert.Equal(260, points[3].Y);

            Assert.Equal(334, points[4].X);
            Assert.Equal(334, points[4].Y);
            Assert.Equal(565, points[5].X);
            Assert.Equal(334, points[5].Y);
            Assert.Equal(565, points[6].X);
            Assert.Equal(565, points[6].Y);
            Assert.Equal(334, points[7].X);
            Assert.Equal(565, points[7].Y);

            bool decoded = obj.DecodeMulti(withQr, points, out var decodedStrings, out var straightQrCode);

            Assert.True(decoded);
            Assert.Equal(2, decodedStrings.Length);
            Assert.Equal("0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!\"#$%&'()*+,-./:;<=>?@[]^_`{|}", decodedStrings[0]);
            Assert.Equal("Helloこんにちは你好안녕하세요", decodedStrings[1]);

            foreach (var mat in straightQrCode)
            {
                ShowImagesWhenDebugMode(mat);
            }

            bool decodedWithoutStraightQrCode = obj.DecodeMulti(withQr, points, out decodedStrings);
            Assert.True(decodedWithoutStraightQrCode);
            Assert.Equal(2, decodedStrings.Length);
            Assert.Equal("0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!\"#$%&'()*+,-./:;<=>?@[]^_`{|}", decodedStrings[0]);
            Assert.Equal("Helloこんにちは你好안녕하세요", decodedStrings[1]);
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
    }
}

