using Xunit;

namespace OpenCvSharp.Tests.Core
{
    public class UMatTest
    {
        [Fact]
        public void NewAndDispose()
        {
            using var umat = new UMat();
        }

        [Fact]
        public void Empty()
        {
            using var umat1 = new UMat();
            Assert.True(umat1.Empty());

            using var umat2 = new UMat(1, 2, MatType.CV_32FC1);
            Assert.False(umat2.Empty());
        }

        [Fact]
        public void Size()
        {
            using var umat = new UMat(new Size(1,2), MatType.CV_8UC1);
            Assert.Equal(new Size(1, 2), umat.Size());
            Assert.Equal(2, umat.Rows);
            Assert.Equal(1, umat.Cols);
        }

        [Fact]
        public void Type()
        {
            using var umat = new UMat(1, 2, MatType.CV_8UC1);
            Assert.Equal(MatType.CV_8UC1, umat.Type());
            Assert.Equal(1, umat.Channels());
            Assert.Equal(MatType.CV_8U, umat.Depth());
        }

        [Fact]
        public void GetMat()
        {
            using var umat = new UMat(1, 1, MatType.CV_8UC3, new Scalar(1, 2, 3));
            using var mat = umat.GetMat(AccessFlag.READ);

            Assert.Equal(umat.Size(), mat.Size());
            Assert.Equal(umat.Type(), mat.Type());
            Assert.Equal(new Vec3b(1, 2, 3), mat.Get<Vec3b>(0, 0));
        }

        [Fact]
        public void CastToInputArray()
        {
            using var src = new UMat(1, 1, MatType.CV_8UC1, new Scalar(64));
            using var dst = new UMat();

            Cv2.BitwiseNot(src, dst);

            AssertEquals(dst, new byte[,] {{255 - 64}});
        }

        [Fact]
        public void Diag()
        {
            using var main = new UMat(3, 1, MatType.CV_8UC1, new Scalar(3));
            using var diag = UMat.Diag(main);
            
            AssertEquals(diag, new byte[,]
            {
                { 3, 0, 0 },
                { 0, 3, 0 },
                { 0, 0, 3 }
            });
        }
        
        [Fact]
        public void Clone()
        {
            var values = new byte[,] { { 1, 2 }, { 3, 4 } };
            using var srcMat = Mat.FromArray(values);

            using var srcUMat = new UMat();
            srcMat.CopyTo(srcUMat);

            var dstUMat = srcUMat.Clone();

            AssertEquals(dstUMat, values);
        }

        private static void AssertEquals(UMat umat, byte[,] expectedValues)
        {
            int rows = expectedValues.GetLength(0);
            int cols = expectedValues.GetLength(1);
            Assert.False(umat.Empty());
            Assert.Equal(rows, umat.Rows);
            Assert.Equal(cols, umat.Cols);
            Assert.Equal(MatType.CV_8UC1, umat.Type());

            using var mat = umat.GetMat(AccessFlag.READ);
            Assert.True(mat.GetRectangularArray(out byte[,] matValues));
            Assert.Equal(expectedValues, matValues);
        }
    }
}
