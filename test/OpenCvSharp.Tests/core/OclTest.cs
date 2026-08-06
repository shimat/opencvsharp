using Xunit;

namespace OpenCvSharp.Tests.Core;

public class OclTest : TestBase
{
    [Fact]
    public void RuntimeStatusCanBeQueriedAndRestored()
    {
        var initiallyEnabled = Cv2.Ocl.UseOpenCL();
        Assert.False(initiallyEnabled && !Cv2.Ocl.HaveOpenCL());

        try
        {
            Cv2.Ocl.SetUseOpenCL(false);
            Assert.False(Cv2.Ocl.UseOpenCL());
        }
        finally
        {
            Cv2.Ocl.SetUseOpenCL(initiallyEnabled);
        }

        Assert.Equal(initiallyEnabled, Cv2.Ocl.UseOpenCL());
    }

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

    [Fact]
    public void GetPlatformsInfoReturnsSnapshots()
    {
        var platforms = Cv2.Ocl.GetPlatformsInfo();

        if (!Cv2.Ocl.HaveOpenCL())
        {
            Assert.Empty(platforms);
            return;
        }

        Assert.NotEmpty(platforms);
        Assert.All(platforms, platform =>
        {
            Assert.NotNull(platform.Name);
            Assert.NotNull(platform.Vendor);
            Assert.NotNull(platform.Version);
            Assert.True(platform.VersionMajor >= 0);
            Assert.True(platform.VersionMinor >= 0);
            Assert.All(platform.Devices, device =>
            {
                Assert.NotNull(device.Name);
                Assert.NotNull(device.VendorName);
                Assert.NotNull(device.OpenCLVersion);
                Assert.NotNull(device.OpenCLCVersion);
                Assert.NotNull(device.DriverVersion);
                Assert.True(device.AddressBits >= 0);
                Assert.True(device.MaxClockFrequency >= 0);
                Assert.True(device.MaxComputeUnits >= 0);
            });
        });
    }
}
