using OpenCvSharp.Internal.Vectors;
using Xunit;

namespace OpenCvSharp.Tests;

// ReSharper disable InconsistentNaming
public class VectorTest : TestBase
{
    [Fact]
    public void VectorOfMat()
    {
        var mats = new Mat[]
        {
            Mat.Eye(2, 2, MatType.CV_8UC1),
            Mat.Ones(2, 2, MatType.CV_64FC1),
        };

        using (var vec = new VectorOfMat(mats))
        {
            Assert.Equal(2, vec.Size);
            var dst = vec.ToArray();
            Assert.Equal(2, dst.Length);

            var eye = dst[0];
            var one = dst[1];

            Assert.Equal(1, eye.Get<byte>(0, 0));
            Assert.Equal(0, eye.Get<byte>(0, 1));
            Assert.Equal(0, eye.Get<byte>(1, 0));
            Assert.Equal(1, eye.Get<byte>(1, 1));

            Assert.Equal(1, one.Get<double>(0, 0), 6);
            Assert.Equal(1, one.Get<double>(0, 1), 6);
            Assert.Equal(1, one.Get<double>(1, 0), 6);
            Assert.Equal(1, one.Get<double>(1, 1), 6);

            foreach (var d in dst)
            {
                d.Dispose();
            }
        }

        foreach (var mat in mats)
        {
            mat.Dispose();
        }
    }
}
