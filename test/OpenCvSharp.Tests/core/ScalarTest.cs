using System.Runtime.InteropServices;
using Xunit;

namespace OpenCvSharp.Tests.Core;

public class ScalarTest
{
    [Fact]
    public void SizeOf()
    {
        Assert.Equal(sizeof(double)*4, Marshal.SizeOf<Scalar>());
    }
}
