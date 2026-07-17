using OpenCvSharp.OptFlow;
using Xunit;

namespace OpenCvSharp.Tests.OptFlow;

// ReSharper disable once InconsistentNaming
public class GPCTreeTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        var tree = GPCTree.Create();
        tree.Dispose();
    }

    [Fact]
    public void GetDescriptorTypeDefault()
    {
        using var tree = GPCTree.Create();

        // An untrained tree still reports the default descriptor type (DCT) from its
        // default-constructed GPCTrainingParams member.
        Assert.Equal(GPCDescType.DCT, tree.GetDescriptorType());
    }
}
