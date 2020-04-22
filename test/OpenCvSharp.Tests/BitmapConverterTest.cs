using System.Drawing;
using System.Drawing.Imaging;
using OpenCvSharp.Extensions;
using Xunit;

// ReSharper disable InvokeAsExtensionMethod

namespace OpenCvSharp.Tests
{
    public class BitmapConverterTest
    {
        [Fact]
        // ReSharper disable once InconsistentNaming
        public void ToMat8bppIndexed()
        {
            using var bitmap = new Bitmap("_data/image/8bpp_indexed.png");
            Assert.Equal(PixelFormat.Format8bppIndexed, bitmap.PixelFormat);

            using var mat = BitmapConverter.ToMat(bitmap);
            Assert.NotNull(mat);
            Assert.False(mat.IsDisposed);
            Assert.False(mat.Empty());
            Assert.Equal(bitmap.Width, mat.Width);
            Assert.Equal(bitmap.Height, mat.Height);
            Assert.Equal(MatType.CV_8UC1, mat.Type());

            int width = bitmap.Width, height = bitmap.Height;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var bitmapPixel = bitmap.GetPixel(x, y);
                    var matPixel = mat.Get<byte>(y, x);
                    Assert.Equal(bitmapPixel.R, matPixel);
                }
            }
        }

        [Fact]
        // ReSharper disable once InconsistentNaming
        public void ToMat24bppRgb()
        {
            using var bitmap = new Bitmap("_data/image/lenna.png");
            Assert.Equal(PixelFormat.Format24bppRgb, bitmap.PixelFormat);

            using var mat = BitmapConverter.ToMat(bitmap);
            Assert.NotNull(mat);
            Assert.False(mat.IsDisposed);
            Assert.False(mat.Empty());
            Assert.Equal(bitmap.Width, mat.Width);
            Assert.Equal(bitmap.Height, mat.Height);
            Assert.Equal(MatType.CV_8UC3, mat.Type());

            int width = bitmap.Width, height = bitmap.Height;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var bitmapPixel = bitmap.GetPixel(x, y);
                    var matPixel = mat.Get<Vec3b>(y, x);
                    Assert.Equal(bitmapPixel.R, matPixel.Item2);
                    Assert.Equal(bitmapPixel.G, matPixel.Item1);
                    Assert.Equal(bitmapPixel.B, matPixel.Item0);
                }
            }
        }
        
        [Fact]
        // ReSharper disable once InconsistentNaming
        public void ToMat32bppArgb()
        {
            using var bitmapOrg = new Bitmap("_data/image/issue/821.jpg");
            Assert.Equal(PixelFormat.Format24bppRgb, bitmapOrg.PixelFormat);

            // 24bpp -> 32bppArgb
            using var bitmap = new Bitmap(bitmapOrg.Width, bitmapOrg.Height, PixelFormat.Format32bppArgb);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawImage(bitmapOrg, new System.Drawing.Point(0, 0));
            }
            Assert.Equal(PixelFormat.Format32bppArgb, bitmap.PixelFormat);

            using var mat = BitmapConverter.ToMat(bitmap);
            Assert.NotNull(mat);
            Assert.False(mat.IsDisposed);
            Assert.False(mat.Empty());
            Assert.Equal(bitmap.Width, mat.Width);
            Assert.Equal(bitmap.Height, mat.Height);
            Assert.Equal(MatType.CV_8UC4, mat.Type());

            int width = bitmap.Width, height = bitmap.Height;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var bitmapPixel = bitmap.GetPixel(x, y);
                    var matPixel = mat.Get<Vec4b>(y, x);
                    Assert.Equal(bitmapPixel.A, matPixel.Item3);
                    Assert.Equal(bitmapPixel.R, matPixel.Item2);
                    Assert.Equal(bitmapPixel.G, matPixel.Item1);
                    Assert.Equal(bitmapPixel.B, matPixel.Item0);
                }
            }
        }
        
        [Fact]
        // ReSharper disable once InconsistentNaming
        public void ToMat32bppRgb()
        {
            using var bitmapOrg = new Bitmap("_data/image/issue/821.jpg");
            Assert.Equal(PixelFormat.Format24bppRgb, bitmapOrg.PixelFormat);

            // 24bpp -> 32bppRgb
            using var bitmap = new Bitmap(bitmapOrg.Width, bitmapOrg.Height, PixelFormat.Format32bppRgb);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawImage(bitmapOrg, new System.Drawing.Point(0, 0));
            }
            Assert.Equal(PixelFormat.Format32bppRgb, bitmap.PixelFormat);

            using var mat = BitmapConverter.ToMat(bitmap);
            Assert.NotNull(mat);
            Assert.False(mat.IsDisposed);
            Assert.False(mat.Empty());
            Assert.Equal(bitmap.Width, mat.Width);
            Assert.Equal(bitmap.Height, mat.Height);
            Assert.Equal(MatType.CV_8UC3, mat.Type());

            int width = bitmap.Width, height = bitmap.Height;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var bitmapPixel = bitmap.GetPixel(x, y);
                    var matPixel = mat.Get<Vec3b>(y, x);
                    Assert.Equal(bitmapPixel.R, matPixel.Item2);
                    Assert.Equal(bitmapPixel.G, matPixel.Item1);
                    Assert.Equal(bitmapPixel.B, matPixel.Item0);
                }
            }
        }

        [Fact]
        // ReSharper disable once InconsistentNaming
        public void ToBitmap8bppIndexed()
        {
            using var mat = new Mat("_data/image/8bpp_indexed.png", ImreadModes.Grayscale);
            Assert.Equal(MatType.CV_8UC1, mat.Type());

            using var bitmap = BitmapConverter.ToBitmap(mat);
            Assert.NotNull(bitmap);
            Assert.Equal(mat.Width, bitmap.Width);
            Assert.Equal(mat.Height, bitmap.Height);
            Assert.Equal(PixelFormat.Format8bppIndexed, bitmap.PixelFormat);

            var matIndexer = mat.GetUnsafeGenericIndexer<byte>();
            int width = bitmap.Width, height = bitmap.Height;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var matPixel = matIndexer[y, x];
                    var bitmapPixel = bitmap.GetPixel(x, y);
                    Assert.Equal(matPixel, bitmapPixel.R);
                }
            }
        }

        [Fact]
        // ReSharper disable once InconsistentNaming
        public void ToBitmap24bppRgb()
        {
            using var mat = new Mat("_data/image/lenna.png", ImreadModes.Color);
            Assert.False(mat.Empty());
            Assert.Equal(MatType.CV_8UC3, mat.Type());

            using var bitmap = BitmapConverter.ToBitmap(mat);
            Assert.NotNull(bitmap);
            Assert.Equal(mat.Width, bitmap.Width);
            Assert.Equal(mat.Height, bitmap.Height);
            Assert.Equal(PixelFormat.Format24bppRgb, bitmap.PixelFormat);

            int width = bitmap.Width, height = bitmap.Height;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var matPixel = mat.Get<Vec3b>(y, x);
                    var bitmapPixel = bitmap.GetPixel(x, y);
                    Assert.Equal(matPixel.Item2, bitmapPixel.R);
                    Assert.Equal(matPixel.Item1, bitmapPixel.G);
                    Assert.Equal(matPixel.Item0, bitmapPixel.B);
                }
            }
        }
    }
}