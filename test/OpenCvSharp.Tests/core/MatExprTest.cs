using Xunit;

namespace OpenCvSharp.Tests.Core
{
    public class MatExprTest
    {
        [Fact]
        public void Size()
        {
            using var matExpr = Mat.Eye(3, 5, MatType.CV_8UC1);
            var size = matExpr.Size();
            Assert.Equal(3, size.Height);
            Assert.Equal(5, size.Width);
        }

        [Fact]
        public void Type()
        {
            using var matExpr = Mat.Ones(3, 5, MatType.CV_32FC4);
            Assert.Equal(MatType.CV_32FC4, matExpr.Type());
        }

        [Fact]
        public void GetSubMat()
        {
            using var matExpr = Mat.Eye(10, 10, MatType.CV_8UC1);
            
            var rect = new Rect(2, 2, 5, 5);
            using var sub = matExpr.SubMat(rect);
            Assert.Equal(rect.Width, sub.Size().Width);
            Assert.Equal(rect.Height, sub.Size().Height);

            using var subMat = sub.ToMat();
            Assert.Equal(rect.Width, subMat.Rows);
            Assert.Equal(rect.Height, subMat.Cols);

            for (int r = 0; r < subMat.Rows; r++)
            {
                for (int c = 0; c < subMat.Cols; c++)
                {
                    Assert.Equal(r == c ? 1 : 0, subMat.Get<byte>(r, c));
                }
            }
        }
    }
}
