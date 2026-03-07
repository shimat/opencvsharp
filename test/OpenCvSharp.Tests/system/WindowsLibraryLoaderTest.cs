using OpenCvSharp.Internal;
using Xunit;

namespace OpenCvSharp.Tests;

public class WindowsLibraryLoaderTest
{
    [Fact]
    public void IsDotNetCore()
    {
#if NET
        Assert.True(WindowsLibraryLoader.IsDotNetCore());
#else
        Assert.False(WindowsLibraryLoader.IsDotNetCore());
#endif
    }
}
