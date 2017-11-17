using System;
using Xunit;

namespace OpenCvSharp.Tests.Core
{
    public class SparseMatTest : TestBase
    {
        [Fact]
        public void CreateAndDispose()
        {
            using (var sm = new SparseMat(new[] { 10, 20 }, MatType.CV_64FC1))
            {
                GC.KeepAlive(sm);
            }
        }

        [Fact]
        public void Dims()
        {
            using (var sm = new SparseMat(new[] { 10, 20 }, MatType.CV_16SC1))
            {
                Assert.Equal(2, sm.Dims());
            }
        }

        [Fact]
        public void Channels()
        {
            using (var sm = new SparseMat(new[] { 10, 20 }, MatType.CV_32FC4))
            {
                Assert.Equal(4, sm.Channels());
            }
            using (var sm = new SparseMat(new[] { 10, 20 }, MatType.CV_16SC2))
            {
                Assert.Equal(2, sm.Channels());
            }
        }

        [Fact]
        public void ConvertToMat()
        {
            using (var sm = new SparseMat(new[] { 10, 20 }, MatType.CV_8UC1))
            using (var m = new Mat())
            {
                sm.ConvertTo(m, MatType.CV_8UC1);
                Assert.Equal(10, m.Rows);
                Assert.Equal(20, m.Cols);
            }
        }
    }
}

