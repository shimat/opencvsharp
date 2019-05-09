using System;
using System.Collections.Generic;
using Xunit;

namespace OpenCvSharp.Tests.Core
{
    public class MatTest : TestBase
    {
        [Fact]
        public void MatOfTDispose()
        {
            //Mat img = Image("lenna.png", ImreadModes.GrayScale);
            //Mat copy = new Mat(img);

            var sourceMat = new Mat(10, 20, MatType.CV_64FC1);
            var doubleMat = new MatOfDouble(sourceMat);
            sourceMat = null;
            doubleMat.Dispose(); // after it when GC will working program broken
        }

        [Fact]
        public void MatIndexer()
        {
            const byte value = 123;
            var img = new Mat(new Size(10, 10), MatType.CV_8UC1, Scalar.All(value));
            var imgB = new MatOfByte(img);
            var indexer = imgB.GetIndexer();
            var generiCIndexer = img.GetGenericIndexer<byte>();

            Assert.Equal(value, indexer[0, 0]);
            Assert.Equal(value, generiCIndexer[0, 0]);

            img.Dispose();
            imgB.Dispose();
        }

        [Fact]
        public void SetTo()
        {
            using (Mat graySrc = Image("lenna.png", ImreadModes.Grayscale))
            using (Mat resultImage = graySrc.Clone())
            using (Mat mask = graySrc.InRange(100, 200))
            {
                var ret = resultImage.SetTo(0, mask);
                ShowImagesWhenDebugMode(resultImage);
                Assert.True(ReferenceEquals(resultImage, ret));

                ret = resultImage.SetTo(0, null); 
                ShowImagesWhenDebugMode(resultImage);
                Assert.True(ReferenceEquals(resultImage, ret));
            }
        }

        [Fact]
        public void CopyTo()
        {
            using (Mat src = Image("lenna.png", ImreadModes.Grayscale))
            using (Mat dst = new Mat())
            using (Mat mask = src.GreaterThan(128))
            {
                src.CopyTo(dst, mask);
                ShowImagesWhenDebugMode(dst);
                src.CopyTo(dst, null);
                ShowImagesWhenDebugMode(dst);
            }
        }

        [Fact]
        public void Diag()
        {
            var data = new byte[] {1, 10, 100};
            using (var mat = new Mat(3, 1, MatType.CV_8UC1, data))
            using (var diag = Mat.Diag(mat))
            {
                Assert.Equal(3, diag.Rows);
                Assert.Equal(3, diag.Cols);
                Assert.Equal(MatType.CV_8UC1, diag.Type());

                Assert.Equal(1, diag.Get<byte>(0, 0));
                Assert.Equal(0, diag.Get<byte>(0, 1));
                Assert.Equal(0, diag.Get<byte>(0, 2));
                Assert.Equal(0, diag.Get<byte>(1, 0));
                Assert.Equal(10, diag.Get<byte>(1, 1));
                Assert.Equal(0, diag.Get<byte>(1, 2));
                Assert.Equal(0, diag.Get<byte>(2, 0));
                Assert.Equal(0, diag.Get<byte>(2, 1));
                Assert.Equal(100, diag.Get<byte>(2, 2));
            }
        }


        [Fact]
        public void MatOfDoubleFromArray()
        {
            var array = new double[] {7, 8, 9};
            var m = MatOfDouble.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(array[i], m.Get<double>(i), 6);
                Assert.Equal(array[i], indexer[i], 6);
            }
        }

        [Fact]
        public void MatOfDoubleFromRectangularArray()
        {
            var array = new double[,] {{1, 2}, {3, 4}};
            var m = MatOfDouble.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Assert.Equal(array[i, j], m.Get<double>(i, j), 6);
                    Assert.Equal(array[i, j], indexer[i, j], 6);
                }
            }
        }

        [Fact]
        public void MatOfFloatFromArray()
        {
            var array = new float[] { 7, 8, 9 };
            var m = MatOfFloat.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(array[i], m.Get<float>(i), 6);
                Assert.Equal(array[i], indexer[i], 6);
            }
        }

        [Fact]
        public void MatOfFloatFromRectangularArray()
        {
            var array = new float[,] { { 1, 2 }, { 3, 4 } };
            var m = MatOfFloat.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Assert.Equal(array[i, j], m.Get<float>(i, j), 6);
                    Assert.Equal(array[i, j], indexer[i, j], 6);
                }
            }
        }

        [Fact]
        public void MatOfIntFromArray()
        {
            var array = new int[] { 7, 8, 9 };
            var m = MatOfInt.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(array[i], m.Get<int>(i));
                Assert.Equal(array[i], indexer[i]);
            }
        }

        [Fact]
        public void MatOfIntFromRectangularArray()
        {
            var array = new int[,] { { 1, 2 }, { 3, 4 } };
            var m = MatOfInt.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Assert.Equal(array[i, j], m.Get<int>(i, j));
                    Assert.Equal(array[i, j], indexer[i, j]);
                }
            }
        }

        [Fact]
        public void MatOfUShortFromArray()
        {
            var array = new ushort[] { 7, 8, 9 };
            var m = MatOfUShort.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(array[i], m.Get<ushort>(i));
                Assert.Equal(array[i], indexer[i]);
            }
        }

        [Fact]
        public void MatOfUShortFromRectangularArray()
        {
            var array = new ushort[,] { { 1, 2 }, { 3, 4 } };
            var m = MatOfUShort.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Assert.Equal(array[i, j], m.Get<ushort>(i, j));
                    Assert.Equal(array[i, j], indexer[i, j]);
                }
            }
        }

        [Fact]
        public void MatOfShortFromArray()
        {
            var array = new short[] { 7, 8, 9 };
            var m = MatOfShort.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(array[i], m.Get<short>(i));
                Assert.Equal(array[i], indexer[i]);
            }
        }

        [Fact]
        public void MatOfShortFromRectangularArray()
        {
            var array = new short[,] { { 1, 2 }, { 3, 4 } };
            var m = MatOfShort.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Assert.Equal(array[i, j], m.Get<short>(i, j));
                    Assert.Equal(array[i, j], indexer[i, j]);
                }
            }
        }

        [Fact]
        public void MatOfByteFromArray()
        {
            var array = new byte[] { 7, 8, 9 };
            var m = MatOfByte.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(array[i], m.Get<byte>(i));
                Assert.Equal(array[i], indexer[i]);
            }
        }

        [Fact]
        public void MatOfByteFromRectangularArray()
        {
            var array = new byte[,] { { 1, 2 }, { 3, 4 } };
            var m = MatOfByte.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Assert.Equal(array[i, j], m.Get<byte>(i, j));
                    Assert.Equal(array[i, j], indexer[i, j]);
                }
            }
        }

        [Fact]
        public void GetSetArrayByte()
        {
            var data = new byte[]
            {
                0, 
                128,
                255,
                1
            };

            var mat = new Mat(2, 2, MatType.CV_8UC1);
            mat.SetArray(0, 0, data);

            var data2 = new byte[mat.Total()];
            mat.GetArray(0, 0, data2);

            Assert.Equal(data, data2);
        }

        [Fact]
        public void GetSetArrayVec3b()
        {
            var data = new Vec3b[]
            {
                Scalar.Red.ToVec3b(),
                Scalar.Blue.ToVec3b(),
                Scalar.Green.ToVec3b(),
                Scalar.Yellow.ToVec3b(),
            };

            var mat = new Mat(2, 2, MatType.CV_8UC3);
            mat.SetArray(0, 0, data);

            var data2 = new Vec3b[mat.Total()];
            mat.GetArray(0, 0, data2);

            Assert.Equal(data, data2);
        }

        [Fact]
        public void GetSetArrayDMatch()
        {
            var data = new DMatch[]
            {
                new DMatch(1, 2, 3),
                new DMatch(2, 4, 6),
                new DMatch(3, 6, 9),
                new DMatch(4, 7, 12),
            };

            var mat = new Mat(2, 2, MatType.CV_32FC4);
            mat.SetArray(0, 0, data);

            var data2 = new DMatch[mat.Total()];
            mat.GetArray(0, 0, data2);

            Assert.Equal(data, data2);
        }

        [Fact(Skip = "heavy")]
        public void Issue349()
        {
            var array = new float[8, 8];
            var handle = System.Runtime.InteropServices.GCHandle.Alloc(array, System.Runtime.InteropServices.GCHandleType.Pinned);
            var ptr = handle.AddrOfPinnedObject();
            Mat mat1 = new Mat(8, 8, MatType.CV_32FC1, ptr);
            for(long i = 0; i < 1000000; i++)
            {
                Mat mat2 = mat1.Idct(); 
            }

            handle.Free();
        }
    }
}

