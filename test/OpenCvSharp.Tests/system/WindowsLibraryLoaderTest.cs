using OpenCvSharp.Internal;
using Xunit;

namespace OpenCvSharp.Tests;

public class WindowsLibraryLoaderTest
{
    [Fact]
    public void IsDotNetCore()
    {
        Assert.True(WindowsLibraryLoader.IsDotNetCore());
    }
}
