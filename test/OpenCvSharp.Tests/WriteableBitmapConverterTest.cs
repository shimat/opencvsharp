#if DOTNET_FRAMEWORK
using System;
using System.Windows;
using OpenCvSharp.Extensions;
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
                var wb = WriteableBitmapConverter.ToWriteableBitmap(mat);

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
                var wb = WriteableBitmapConverter.ToWriteableBitmap(submat);

                byte[] actual = new byte[4]; 
                wb.CopyPixels(Int32Rect.Empty, actual, submat.Cols, 0);
                for (int i = 0; i < actual.Length; i++)
                {
                    Assert.True(expected[i] == actual[i], $"values[{i}] = {expected[i]}, pixels[{i}] = {actual[i]}");
                }
            }

            GC.KeepAlive(expected);
        }
    }
}
#endif