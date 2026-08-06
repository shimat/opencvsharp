using Xunit;

namespace OpenCvSharp.Tests.Core;

public class OclTest : TestBase
{
    [Fact]
    public void FinishAfterUMatOperation()
    {
        using var src = new UMat(32, 32, MatType.CV_8UC1, Scalar.All(1));
        using var dst = new UMat();

        Cv2.GaussianBlur(src, dst, new Size(5, 5), 0);
        Cv2.Ocl.Finish();

        using var result = dst.GetMat(AccessFlag.READ);
        Assert.Equal(1, result.At<byte>(0, 0));
    }
}
