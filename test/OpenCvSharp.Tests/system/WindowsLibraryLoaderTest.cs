using OpenCvSharp.Internal;
using Xunit;

namespace OpenCvSharp.Tests;

public class WindowsLibraryLoaderTest
{
    [Fact]
    public void IsDotNetCore()
    {
#if NET48
        Assert.False(WindowsLibraryLoader.IsDotNetCore());
#elif NETCOREAPP3_1_OR_GREATER
            Assert.True(WindowsLibraryLoader.IsDotNetCore());
#else
            throw new OpenCvSharpException("Unexpected environment.");
#endif
    }
}
