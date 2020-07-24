#if WINDOWS
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using OpenCvSharp.WpfExtensions;
using Xunit;

namespace OpenCvSharp.Tests
{
    public class WriteableBitmapConverterTest
    {
        [Fact]
        public void ToWriteableBitmap()
        {
            var expected = new byte[] {1, 2, 3, 4, 5, 6};
            using (var mat = new Mat(3, 2, MatType.CV_8UC1, expected))
            {
                var wb = mat.ToWriteableBitmap();

                byte[] actual = new byte[6]; 
                wb.CopyPixels(Int32Rect.Empty, actual, mat.Cols, 0);
                for (int i = 0; i < expected.Length; i++)
                {
                    Assert.True(expected[i] == actual[i], $"values[{i}] = {expected[i]}, pixels[{i}] = {actual[i]}");
                }
            }

            GC.KeepAlive(expected);
        }

        [Fact]
        public void ToWriteableBitmapSubmat()
        {
            var expected = new byte[] {1, 2, 3, 4, 5, 6};
            using (var mat = new Mat(3, 2, MatType.CV_8UC1, expected))
            using (var submat = mat[0, 2, 0, 2])
            {
                var wb = submat.ToWriteableBitmap();

                byte[] actual = new byte[4]; 
                wb.CopyPixels(Int32Rect.Empty, actual, submat.Cols, 0);
                for (int i = 0; i < actual.Length; i++)
                {
                    Assert.True(expected[i] == actual[i], $"values[{i}] = {expected[i]}, pixels[{i}] = {actual[i]}");
                }
            }

            GC.KeepAlive(expected);
        }

        [Fact]
        public void ToMatGray8()
        {
            const int width = 3;
            const int height = 4;

            var buffer = new byte[height, width]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9},
                {10, 11, 12},
            };

            var wb = new WriteableBitmap(width, height, 92, 92, PixelFormats.Gray8, null);
            wb.WritePixels(new Int32Rect(0, 0, width, height), buffer, width, 0);

            using var mat = wb.ToMat();
            Assert.Equal(MatType.CV_8UC1, mat.Type());
            Assert.Equal(width, mat.Cols);
            Assert.Equal(height, mat.Rows);

            var indexer = mat.GetUnsafeGenericIndexer<byte>();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Assert.True(buffer[y, x] == indexer[y, x], 
                        $"wb[{y},{x}] = {buffer[y, x]}, mat[{y},{x}] = {indexer[y, x]}");
                }
            }
        }

        [Fact]
        public void ToMatBgr24()
        {
            const int width = 3;
            const int height = 4;

            var buffer = new byte[height, width * 3]
            {
                {1,2,3, 4,5,6, 7,8,9},
                {10,11,12, 13,14,15, 16,17,18},
                {19,20,21, 22,23,24, 25,26,27},
                {28,29,30, 31,32,33, 34,35,36},
            };

            var wb = new WriteableBitmap(width, height, 92, 92, PixelFormats.Bgr24, null);
            wb.WritePixels(new Int32Rect(0, 0, width, height), buffer, width*3, 0);

            using var mat = wb.ToMat();
            Assert.Equal(MatType.CV_8UC3, mat.Type());
            Assert.Equal(width, mat.Cols);
            Assert.Equal(height, mat.Rows);

            var indexer = mat.GetUnsafeGenericIndexer<Vec3b>();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var expected = new Vec3b(buffer[y, x*3+0], buffer[y, x*3+1], buffer[y, x*3+2]);
                    var actual = indexer[y, x];

                    Assert.True(actual == expected,
                        $"wb[{y},{x}] = {expected}, mat[{y},{x}] = {actual}");
                }
            }
        }
    }
}
#endif