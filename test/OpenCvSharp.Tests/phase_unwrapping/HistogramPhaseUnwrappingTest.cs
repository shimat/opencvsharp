using Xunit;

namespace OpenCvSharp.Tests.PhaseUnwrap;

public class HistogramPhaseUnwrappingTest : TestBase
{
    private static Mat CreateWrappedPhaseMap(int width, int height)
    {
        var mat = new Mat(height, width, MatType.CV_32FC1);
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                // A linear phase ramp, wrapped into [-pi, pi).
                var trueValue = (x + y) * 0.3f;
                var wrapped = (float)(Math.IEEERemainder(trueValue, 2 * Math.PI));
                mat.Set(y, x, wrapped);
            }
        }
        return mat;
    }

    [Fact]
    public void CreateWithDefaultParams()
    {
        using var unwrapper = HistogramPhaseUnwrapping.Create();
        Assert.NotNull(unwrapper);
    }

    [Fact]
    public void UnwrapPhaseMap()
    {
        const int width = 32;
        const int height = 32;

        var parameters = HistogramPhaseUnwrapping.Params.Default;
        parameters.Width = width;
        parameters.Height = height;

        using var unwrapper = HistogramPhaseUnwrapping.Create(parameters);
        using var wrappedPhaseMap = CreateWrappedPhaseMap(width, height);
        using var unwrappedPhaseMap = new Mat();

        unwrapper.UnwrapPhaseMap(wrappedPhaseMap, unwrappedPhaseMap);

        Assert.False(unwrappedPhaseMap.Empty());
        Assert.Equal(height, unwrappedPhaseMap.Rows);
        Assert.Equal(width, unwrappedPhaseMap.Cols);
        Assert.Equal(MatType.CV_32FC1, unwrappedPhaseMap.Type());

        using var reliabilityMap = new Mat();
        unwrapper.GetInverseReliabilityMap(reliabilityMap);
        Assert.False(reliabilityMap.Empty());
    }
}
