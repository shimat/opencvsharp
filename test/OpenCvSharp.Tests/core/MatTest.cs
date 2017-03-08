using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace OpenCvSharp.Tests.Core
{
    [TestFixture]
    public class MatTest : TestBase
    {
        [Test]
        public void SetTo()
        {
            using (Mat graySrc = Image("lenna.png", ImreadModes.GrayScale))
            using (Mat resultImage = graySrc.Clone())
            using (Mat mask = graySrc.InRange(100, 200))
            {
                Assert.DoesNotThrow(() => { resultImage.SetTo(0, mask); });
                //Window.ShowImages(resultImage);
                Assert.DoesNotThrow(() => { resultImage.SetTo(0, null); });
                //Window.ShowImages(resultImage);
            }
        }

        [Test]
        public void CopyTo()
        {
            using (Mat src = Image("lenna.png", ImreadModes.GrayScale))
            using (Mat dst = new Mat())
            using (Mat mask = src.GreaterThan(128))
            {
                Assert.DoesNotThrow(() => { src.CopyTo(dst, mask); });
                //Window.ShowImages(dst);
                Assert.DoesNotThrow(() => { src.CopyTo(dst, null); });
                //Window.ShowImages(dst);
            }
        }

        [Test]
        public void MatOfDoubleFromArray()
        {
            var array = new double[] {7, 8, 9};
            var m = MatOfDouble.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.Length; i++)
            {
                Assert.That(m.Get<double>(i), Is.EqualTo(array[i]).Within(1e-6));
                Assert.That(indexer[i], Is.EqualTo(array[i]).Within(1e-6));
            }
        }

        [Test]
        public void MatOfDoubleFromRectangularArray()
        {
            var array = new double[,] {{1, 2}, {3, 4}};
            var m = MatOfDouble.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Assert.That(m.Get<double>(i, j), Is.EqualTo(array[i, j]).Within(1e-6));
                    Assert.That(indexer[i, j], Is.EqualTo(array[i, j]).Within(1e-6));
                }
            }
        }

        [Test]
        public void MatOfFloatFromArray()
        {
            var array = new float[] { 7, 8, 9 };
            var m = MatOfFloat.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.Length; i++)
            {
                Assert.That(m.Get<float>(i), Is.EqualTo(array[i]).Within(1e-6));
                Assert.That(indexer[i], Is.EqualTo(array[i]).Within(1e-6));
            }
        }

        [Test]
        public void MatOfFloatFromRectangularArray()
        {
            var array = new float[,] { { 1, 2 }, { 3, 4 } };
            var m = MatOfFloat.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Assert.That(m.Get<float>(i, j), Is.EqualTo(array[i, j]).Within(1e-6));
                    Assert.That(indexer[i, j], Is.EqualTo(array[i, j]).Within(1e-6));
                }
            }
        }

        [Test]
        public void MatOfIntFromArray()
        {
            var array = new int[] { 7, 8, 9 };
            var m = MatOfInt.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.Length; i++)
            {
                Assert.That(m.Get<int>(i), Is.EqualTo(array[i]));
                Assert.That(indexer[i], Is.EqualTo(array[i]));
            }
        }

        [Test]
        public void MatOfIntFromRectangularArray()
        {
            var array = new int[,] { { 1, 2 }, { 3, 4 } };
            var m = MatOfInt.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Assert.That(m.Get<int>(i, j), Is.EqualTo(array[i, j]));
                    Assert.That(indexer[i, j], Is.EqualTo(array[i, j]));
                }
            }
        }

        [Test]
        public void MatOfUShortFromArray()
        {
            var array = new ushort[] { 7, 8, 9 };
            var m = MatOfUShort.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.Length; i++)
            {
                Assert.That(m.Get<ushort>(i), Is.EqualTo(array[i]));
                Assert.That(indexer[i], Is.EqualTo(array[i]));
            }
        }

        [Test]
        public void MatOfUShortFromRectangularArray()
        {
            var array = new ushort[,] { { 1, 2 }, { 3, 4 } };
            var m = MatOfUShort.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Assert.That(m.Get<ushort>(i, j), Is.EqualTo(array[i, j]));
                    Assert.That(indexer[i, j], Is.EqualTo(array[i, j]));
                }
            }
        }

        [Test]
        public void MatOfShortFromArray()
        {
            var array = new short[] { 7, 8, 9 };
            var m = MatOfShort.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.Length; i++)
            {
                Assert.That(m.Get<short>(i), Is.EqualTo(array[i]));
                Assert.That(indexer[i], Is.EqualTo(array[i]));
            }
        }

        [Test]
        public void MatOfShortFromRectangularArray()
        {
            var array = new short[,] { { 1, 2 }, { 3, 4 } };
            var m = MatOfShort.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Assert.That(m.Get<short>(i, j), Is.EqualTo(array[i, j]));
                    Assert.That(indexer[i, j], Is.EqualTo(array[i, j]));
                }
            }
        }

        [Test]
        public void MatOfByteFromArray()
        {
            var array = new byte[] { 7, 8, 9 };
            var m = MatOfByte.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.Length; i++)
            {
                Assert.That(m.Get<byte>(i), Is.EqualTo(array[i]));
                Assert.That(indexer[i], Is.EqualTo(array[i]));
            }
        }

        [Test]
        public void MatOfByteFromRectangularArray()
        {
            var array = new byte[,] { { 1, 2 }, { 3, 4 } };
            var m = MatOfByte.FromArray(array);

            var indexer = m.GetIndexer();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Assert.That(m.Get<byte>(i, j), Is.EqualTo(array[i, j]));
                    Assert.That(indexer[i, j], Is.EqualTo(array[i, j]));
                }
            }
        }
    }
}

