using System;
using Xunit;

// ReSharper disable ReturnValueOfPureMethodIsNotUsed

namespace OpenCvSharp.Tests.Core
{
    public class MatTest : TestBase
    {
        [Fact]
        public void MatOfTDispose()
        {
            var sourceMat = new Mat(10, 20, MatType.CV_64FC1);
            var doubleMat = new Mat<double>(sourceMat);
            // ReSharper disable once RedundantAssignment
            sourceMat = null!;
            GC.Collect();
            doubleMat.Dispose(); // after it when GC will working program broken
        }

        [Fact]
        public void MatIndexerByte()
        {
            byte value = 123;
            using var img = new Mat(new Size(10, 10), MatType.CV_8UC1, Scalar.All(value));
            using var imgB = new Mat<byte>(img);
            var indexer = imgB.GetIndexer();
            var genericIndexer = img.GetGenericIndexer<byte>();
            var unsafeGenericIndexer = img.GetUnsafeGenericIndexer<byte>();

            Assert.Equal(value, indexer[0, 0]);
            Assert.Equal(value, genericIndexer[0, 0]);
            Assert.Equal(value, unsafeGenericIndexer[0, 0]);

            Assert.Equal(value, indexer[5, 7]);
            Assert.Equal(value, genericIndexer[5, 7]);
            Assert.Equal(value, unsafeGenericIndexer[5, 7]);

            indexer[3, 4] = 1;
            Assert.Equal(1, img.Get<byte>(3, 4));
            genericIndexer[3, 4] = 2;
            Assert.Equal(2, img.Get<byte>(3, 4));
            unsafeGenericIndexer[3, 4] = 3;
            Assert.Equal(3, img.Get<byte>(3, 4));
        }

        [Fact]
        public void MatIndexerVec3d()
        {
            var scalarValue = new Scalar(1, 2, 3);
            var expectedValue = new Vec3d(scalarValue[0], scalarValue[1], scalarValue[2]);

            using var img = new Mat(new Size(10, 10), MatType.CV_64FC3, scalarValue);
            using var imgB = new Mat<Vec3d>(img);
            var indexer = imgB.GetIndexer();
            var genericIndexer = img.GetGenericIndexer<Vec3d>();
            var unsafeGenericIndexer = img.GetUnsafeGenericIndexer<Vec3d>();

            Assert.Equal(expectedValue, indexer[0, 0]);
            Assert.Equal(expectedValue, genericIndexer[0, 0]);
            Assert.Equal(expectedValue, unsafeGenericIndexer[0, 0]);

            Assert.Equal(expectedValue, indexer[5, 7]);
            Assert.Equal(expectedValue, genericIndexer[5, 7]);
            Assert.Equal(expectedValue, unsafeGenericIndexer[5, 7]);

            indexer[3, 4] = new Vec3d(2, 3, 4);
            Assert.Equal(new Vec3d(2, 3, 4), img.Get<Vec3d>(3, 4));

            genericIndexer[3, 4] = new Vec3d(3, 4, 5);
            Assert.Equal(new Vec3d(3, 4, 5), img.Get<Vec3d>(3, 4));

            unsafeGenericIndexer[3, 4] = new Vec3d(4, 5, 6);
            Assert.Equal(new Vec3d(4, 5, 6), img.Get<Vec3d>(3, 4));
        }

        [Fact]
        public void Diag()
        {
            var data = new byte[] {1, 10, 100};
            using var mat = new Mat(3, 1, MatType.CV_8UC1, data);
            using var diag = Mat.Diag(mat);
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
        
        [Fact]
        public void CopyTo()
        {
            using var src = Image("lenna.png", ImreadModes.Grayscale);
            using var dst = new Mat();
            using var mask = src.GreaterThan(128);
            src.CopyTo(dst, mask);
            ShowImagesWhenDebugMode(dst);
            src.CopyTo(dst, null);
            ShowImagesWhenDebugMode(dst);
        }

        [Fact]
        public void SetTo()
        {
            using var graySrc = Image("lenna.png", ImreadModes.Grayscale);
            using var resultImage = graySrc.Clone();
            using var mask = graySrc.InRange(100, 200);
            var ret = resultImage.SetTo(0, mask);
            ShowImagesWhenDebugMode(resultImage);
            Assert.True(ReferenceEquals(resultImage, ret));

            ret = resultImage.SetTo(0, null);
            ShowImagesWhenDebugMode(resultImage);
            Assert.True(ReferenceEquals(resultImage, ret));
        }

        [Fact]
        public void T()
        {
            var data = new byte[] {1, 10, 100};
            using var mat = new Mat(3, 1, MatType.CV_8UC1, data);
            using var tExpr = mat.T();
            using var t = tExpr.ToMat();

            Assert.Equal(1, t.Rows);
            Assert.Equal(3, t.Cols);
            Assert.Equal(MatType.CV_8UC1, t.Type());

            Assert.Equal(1, t.Get<byte>(0, 0));
            Assert.Equal(10, t.Get<byte>(0, 1));
            Assert.Equal(100, t.Get<byte>(0, 2));
        }
        
        [Fact]
        public void Inv()
        {
            var data = new double[] {1, 2, 3, 4};
            using var mat = new Mat(2, 2, MatType.CV_64FC1, data);
            using var invExpr = mat.Inv();
            using var inv = invExpr.ToMat();

            Assert.Equal(2, inv.Rows);
            Assert.Equal(2, inv.Cols);
            Assert.Equal(MatType.CV_64FC1, inv.Type());

            Assert.Equal(-2.0, inv.Get<double>(0, 0), 3);
            Assert.Equal(+1.0, inv.Get<double>(0, 1), 3);
            Assert.Equal(+1.5, inv.Get<double>(1, 0), 3);
            Assert.Equal(-0.5, inv.Get<double>(1, 1), 3);
        }
        
        [Fact]
        public void Dot()
        {
            var data1 = new double[] {1, 2};
            var data2 = new double[] {3, 4};
            using var mat1 = new Mat(2, 1, MatType.CV_64FC1, data1);
            using var mat2 = new Mat(2, 1, MatType.CV_64FC1, data2);
            var dot = mat1.Dot(mat2);

            Assert.Equal(data1[0] * data2[0] + data1[1] * data2[1], dot);
        }

        [Fact]
        public void Reserve()
        {
            using var mat = new Mat(1, 1, MatType.CV_8UC1);
            mat.Reserve(10);
            mat.ReserveBuffer(100);
        }
        
        [Fact]
        public void Resize()
        {
            using var mat = new Mat(1, 1, MatType.CV_8UC1);
            mat.Resize(10);
            Assert.Equal(10, mat.Rows);
        }

        [Fact]
        public void Add()
        {
            using var m = new Mat<double>();
            m.Add(1.2);
            m.Add(3.4);
            m.Add(5.6);

            Assert.Equal(1.2, m.Get<double>(0), 6);
            Assert.Equal(3.4, m.Get<double>(1), 6);
            Assert.Equal(5.6, m.Get<double>(2), 6);
        }

        [Fact]
        public void MatOfDoubleFromArray()
        {
            var array = new double[] {7, 8, 9};
            using var m = Mat<double>.FromArray(array);

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
            using var m = Mat<double>.FromArray(array);

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
            var array = new float[] {7, 8, 9};
            using var m = Mat<float>.FromArray(array);

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
            var array = new float[,] {{1, 2}, {3, 4}};
            using var m = Mat<float>.FromArray(array);

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
            var array = new[] {7, 8, 9};
            var m = Mat<int>.FromArray(array);

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
            var array = new[,] {{1, 2}, {3, 4}};
            using var m = Mat<int>.FromArray(array);

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
            var array = new ushort[] {7, 8, 9};
            using var m = Mat<ushort>.FromArray(array);

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
            var array = new ushort[,] {{1, 2}, {3, 4}};
            using var m = Mat<ushort>.FromArray(array);

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
            var array = new short[] {7, 8, 9};
            using var m = Mat<short>.FromArray(array);

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
            var array = new short[,] {{1, 2}, {3, 4}};
            using var m = Mat<short>.FromArray(array);

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
            var array = new byte[] {7, 8, 9};
            var m = Mat<byte>.FromArray(array);

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
            var array = new byte[,] {{1, 2}, {3, 4}};
            using var m = Mat<byte>.FromArray(array);

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
        public void GetArrayByte()
        {
            var data = new byte[] {0, 128, 255, 1};

            using var mat = new Mat(2, 2, MatType.CV_8UC1, data);
            bool success = mat.GetArray(out byte[] data2);

            Assert.True(success);
            Assert.Equal(data, data2);
        }

        [Fact]
        public void GetArrayFailure()
        {
            var data = new byte[] {0, 128, 255, 1};

            using var mat = new Mat(2, 2, MatType.CV_64FC4, data);
            Assert.Throws<OpenCvSharpException>( ()=>
            {
                mat.GetArray(out byte[] _);
            });
        }

        [Fact]
        public void GetRectangularArrayByte()
        {
            var data = new byte[,]
            {
                {0, 128},
                {255, 1}
            };

            using var mat = new Mat(2, 2, MatType.CV_8UC1, data);
            bool success = mat.GetRectangularArray(out byte[,] data2);

            Assert.True(success);
            Assert.Equal(data, data2);
        }
        
        [Fact]
        public void GetArrayInt16()
        {
            var data = new short[] {3, short.MaxValue, short.MinValue, 10000};

            using var mat = new Mat(2, 2, MatType.CV_16SC1, data);
            bool success = mat.GetArray(out short[] data2);

            Assert.True(success);
            Assert.Equal(data, data2);
        }

        [Fact]
        public void GetArrayInt32()
        {
            // ReSharper disable once RedundantExplicitArrayCreation
            var data = new int[] {3, int.MaxValue, int.MinValue, 65536};

            using var mat = new Mat(2, 2, MatType.CV_32SC1, data);
            bool success = mat.GetArray(out int[] data2);

            Assert.True(success);
            Assert.Equal(data, data2);
        }

        [Fact]
        public void GetArraySingle()
        {
            // ReSharper disable once RedundantExplicitArrayCreation
            var data = new float[] {3.14f, float.MaxValue, float.MinValue, 12345.6789f};

            using var mat = new Mat(2, 2, MatType.CV_32FC1, data);
            bool success = mat.GetArray(out float[] data2);

            Assert.True(success);
            Assert.Equal(data, data2);
        }
        
        [Fact]
        public void GetArrayDouble()
        {
            // ReSharper disable once RedundantExplicitArrayCreation
            var data = new double[] {3.14, double.MaxValue, double.MinValue, double.Epsilon};

            using var mat = new Mat(2, 2, MatType.CV_64FC1, data);
            bool success = mat.GetArray(out double[] data2);

            Assert.True(success);
            Assert.Equal(data, data2);
        }
        
        [Fact]
        public void GetArrayPoint()
        {
            var data = new []
            {
                new Point(1, 2), 
                new Point(3, 4), 
                new Point(5, 6), 
                new Point(7, 8), 
            };

            using var mat = new Mat(2, 2, MatType.CV_32SC2, data);
            bool success = mat.GetArray(out Point[] data2);

            Assert.True(success);
            Assert.Equal(data, data2);
        }

        [Fact]
        public void GetArrayRect()
        {
            var data = new []
            {
                new Rect(1, 2, 3, 4), 
                new Rect(5, 6, 7, 8), 
                new Rect(9, 10, 11, 12), 
                new Rect(13, 14, 15, 16), 
            };

            using var mat = new Mat(2, 2, MatType.CV_32SC4, data);
            bool success = mat.GetArray(out Rect[] data2);

            Assert.True(success);
            Assert.Equal(data, data2);
        }

        [Fact]
        public void GetArrayVec3b()
        {
            var data = new []
            {
                new Vec3b(1, 2, 3), 
                new Vec3b(4, 5, 6), 
                new Vec3b(7, 8, 9), 
                new Vec3b(10, 11, 12), 
            };

            using var mat = new Mat(2, 2, MatType.CV_8UC3, data);
            bool success = mat.GetArray(out Vec3b[] data2);

            Assert.True(success);
            Assert.Equal(data, data2);
        }
                /*
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

            using var mat = new Mat(2, 2, MatType.CV_8UC1);
            mat.SetArray(0, 0, data);

            var data2 = new byte[mat.Total()];
            mat.GetArray(0, 0, data2);

            Assert.Equal(data, data2);
        }

        [Fact]
        public void GetSetArrayVec3b()
        {
            var data = new[]
            {
                Scalar.Red.ToVec3b(),
                Scalar.Blue.ToVec3b(),
                Scalar.Green.ToVec3b(),
                Scalar.Yellow.ToVec3b(),
            };

            using var mat = new Mat(2, 2, MatType.CV_8UC3);
            mat.SetArray(0, 0, data);

            var data2 = new Vec3b[mat.Total()];
            mat.GetArray(0, 0, data2);

            Assert.Equal(data, data2);
        }

        [Fact]
        public void GetSetArrayDMatch()
        {
            var data = new[]
            {
                new DMatch(1, 2, 3),
                new DMatch(2, 4, 6),
                new DMatch(3, 6, 9),
                new DMatch(4, 7, 12),
            };

            using var mat = new Mat(2, 2, MatType.CV_32FC4);
            mat.SetArray(0, 0, data);

            var data2 = new DMatch[mat.Total()];
            mat.GetArray(0, 0, data2);

            Assert.Equal(data, data2);
        }
        */
        [Fact]
        public void GetSubMat()
        {
            const byte expectedValue = 128;

            using var mat = new Mat(10, 10, MatType.CV_8UC1, Scalar.All(0));

            var rect = new Rect(2, 2, 5, 5);
            mat.Rectangle(rect, new Scalar(expectedValue), -1);

            using var subMat = mat.SubMat(rect);
            Assert.Equal(rect.Width, subMat.Rows);
            Assert.Equal(rect.Height, subMat.Cols);

            for (int r = 0; r < subMat.Rows; r++)
            {
                for (int c = 0; c < subMat.Cols; c++)
                {
                    Assert.Equal(expectedValue, subMat.Get<byte>(r, c));
                }
            }
        }

        [Fact]
        public void GetSubMatByIndexer()
        {
            const byte expectedValue = 128;

            using var mat = new Mat(10, 10, MatType.CV_8UC1, Scalar.All(0));

            var rect = new Rect(2, 2, 5, 5);
            mat.Rectangle(rect, new Scalar(expectedValue), -1);

            using var subMat = mat[rect];
            Assert.Equal(rect.Width, subMat.Rows);
            Assert.Equal(rect.Height, subMat.Cols);

            for (int r = 0; r < subMat.Rows; r++)
            {
                for (int c = 0; c < subMat.Cols; c++)
                {
                    Assert.Equal(expectedValue, subMat.Get<byte>(r, c));
                }
            }
        }

        [Fact]
        public void SetSubMat()
        {
            const byte expectedValue = 128;

            using var mat = new Mat(10, 10, MatType.CV_8UC1, Scalar.All(0));

            var rect = new Rect(2, 2, 5, 5);
            mat[rect].SetTo(expectedValue);

            for (int r = rect.Left; r < rect.Right; r++)
            {
                for (int c = rect.Top; c < rect.Bottom; c++)
                {
                    Assert.Equal(expectedValue, mat.Get<byte>(r, c));
                }
            }
        }

        [Fact(Skip = "heavy")]
        public void Issue349()
        {
            var array = new float[8, 8];
            var handle =
                System.Runtime.InteropServices.GCHandle.Alloc(array,
                    System.Runtime.InteropServices.GCHandleType.Pinned);
            var ptr = handle.AddrOfPinnedObject();
            using var mat1 = new Mat(8, 8, MatType.CV_32FC1, ptr);
            for (long i = 0; i < 1000000; i++)
            {
                using var mat2 = mat1.Idct();
                GC.KeepAlive(mat2);
            }

            handle.Free();
        }
    }
}
