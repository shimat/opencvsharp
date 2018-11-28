using System;
using System.Collections.Generic;
using OpenCvSharp.Detail;
using Xunit;

#pragma warning disable 162

namespace OpenCvSharp.Tests.ObjDetect
{
    public class QRCodeDetectorTest : TestBase
    {
        [Fact]
        public void Detect()
        {
            using (var obj = new QRCodeDetector())
            {
                int x = 100;
                int y = 200;

                using (var withQr = ImageWithQrCode(x, y, out int w, out int h))
                using (var dst = new Mat())
                {     
                    ShowImagesWhenDebugMode(withQr);
                    bool detected = obj.Detect(withQr, dst);
                    Assert.True(detected);
                    Assert.Equal(4, dst.Rows);
                    Assert.Equal(1, dst.Cols);
                    Assert.Equal(MatType.CV_32FC2, dst.Type());

                    var p1 = dst.At<Point2f>(0);
                    var p2 = dst.At<Point2f>(1);
                    var p3 = dst.At<Point2f>(2);
                    var p4 = dst.At<Point2f>(3);
                    Assert.Equal(102, p1.X);
                    Assert.Equal(201, p1.Y);
                    Assert.Equal(199, p2.X);
                    Assert.Equal(201, p2.Y);
                    Assert.Equal(199, p3.X);
                    Assert.Equal(299, p3.Y);
                    Assert.Equal(102, p4.X);
                    Assert.Equal(299, p4.Y);

                    bool detected2 = obj.Detect(withQr, out var points);
                    Assert.True(detected);
                    Assert.Equal(4, points.Length);
                    Assert.Equal(points[0], p1);
                    Assert.Equal(points[1], p2);
                    Assert.Equal(points[2], p3);
                    Assert.Equal(points[3], p4);
                }
            }
        }

        private static Mat ImageWithQrCode(int x, int y, out int qrWidth, out int qrHeight)
        {
            var lenna = Image("lenna.png");
            using (var qr = Image("qr.png"))
            {
                qrWidth = qr.Width;
                qrHeight = qr.Height;

                var roi = new Rect(x, y, qr.Width, qr.Height);
                using (var part = lenna[roi])
                {
                    qr.CopyTo(part);
                }
            }
            return lenna;
        }
    }
}

