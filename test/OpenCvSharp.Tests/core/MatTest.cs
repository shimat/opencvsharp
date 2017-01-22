using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace OpenCvSharp.Tests.Core
{
    [TestFixture]
    public class MatTest : TestBase
    {
        [Test]
        public void MatOfDoubleFromArray()
        {
            var array = new double[] {7, 8, 9};
            var m = MatOfDouble.FromArray(array);

            for (int i = 0; i < array.Length; i++)
            {
                Assert.That(m.Get<double>(i), Is.EqualTo(array[i]).Within(1e-6));
            }
        }

        [Test]
        public void MatOfFloatFromArray()
        {
            var array = new float[] { 7, 8, 9 };
            var m = MatOfFloat.FromArray(array);

            for (int i = 0; i < array.Length; i++)
            {
                Assert.That(m.Get<float>(i), Is.EqualTo(array[i]).Within(1e-6));
            }
        }

        [Test]
        public void MatOfIntFromArray()
        {
            var array = new int[] { 7, 8, 9 };
            var m = MatOfInt.FromArray(array);

            for (int i = 0; i < array.Length; i++)
            {
                Assert.That(m.Get<int>(i), Is.EqualTo(array[i]));
            }
        }

        [Test]
        public void MatOfUShortFromArray()
        {
            var array = new ushort[] { 7, 8, 9 };
            var m = MatOfUShort.FromArray(array);

            for (int i = 0; i < array.Length; i++)
            {
                Assert.That(m.Get<ushort>(i), Is.EqualTo(array[i]));
            }
        }

        [Test]
        public void MatOfShortFromArray()
        {
            var array = new short[] { 7, 8, 9 };
            var m = MatOfShort.FromArray(array);

            for (int i = 0; i < array.Length; i++)
            {
                Assert.That(m.Get<short>(i), Is.EqualTo(array[i]));
            }
        }

        [Test]
        public void MatOfByteFromArray()
        {
            var array = new byte[] { 7, 8, 9 };
            var m = MatOfByte.FromArray(array);

            for (int i = 0; i < array.Length; i++)
            {
                Assert.That(m.Get<byte>(i), Is.EqualTo(array[i]));
            }
        }
    }
}

