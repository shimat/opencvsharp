using Xunit;

namespace OpenCvSharp.Tests.Features;

public class DescriptorMatcherTest : TestBase
{
    [Theory]
    [InlineData(DescriptorMatcher.MatcherType.FlannBased)]
    [InlineData(DescriptorMatcher.MatcherType.BruteForce)]
    [InlineData(DescriptorMatcher.MatcherType.BruteForceL1)]
    [InlineData(DescriptorMatcher.MatcherType.BruteForceHamming)]
    [InlineData(DescriptorMatcher.MatcherType.BruteForceHammingLut)]
    [InlineData(DescriptorMatcher.MatcherType.BruteForceSL2)]
    public void CreateFromMatcherType(DescriptorMatcher.MatcherType matcherType)
    {
        using var matcher = DescriptorMatcher.Create(matcherType);

        Assert.NotNull(matcher);
        // A freshly created matcher has no train descriptors yet.
        Assert.True(matcher.Empty());
    }
}
