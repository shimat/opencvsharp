using Xunit;

namespace OpenCvSharp.Tests.Core
{
    public class MatExprTest
    {
        [Fact]
        public void GetSubMat()
        {
            using var matExpr = Mat.Eye(10, 10, MatType.CV_8UC1);
            
            var rect = new Rect(2, 2, 5, 5);
            using var sub = matExpr.SubMat(rect);
            Assert.Equal(rect.Width, sub.Size.Width);
            Assert.Equal(rect.Height, sub.Size.Height);

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
