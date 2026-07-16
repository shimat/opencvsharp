using OpenCvSharp.Plot;
using Xunit;

namespace OpenCvSharp.Tests.Plot;

public class Plot2dTest : TestBase
{
    [Fact]
    public void CreateFromSingleArray()
    {
        using var data = new Mat(1, 10, MatType.CV_64FC1);
        for (var i = 0; i < 10; i++)
            data.Set(0, i, (double)i * i);

        using var plot = Plot2d.Create(data);
        Assert.NotNull(plot);

        using var result = new Mat();
        plot.Render(result);
        Assert.False(result.Empty());
    }

    [Fact]
    public void CreateFromXYArrays()
    {
        using var dataX = new Mat(1, 10, MatType.CV_64FC1);
        using var dataY = new Mat(1, 10, MatType.CV_64FC1);
        for (var i = 0; i < 10; i++)
        {
            dataX.Set(0, i, (double)i);
            dataY.Set(0, i, (double)i * 2);
        }

        using var plot = Plot2d.Create(dataX, dataY);
        Assert.NotNull(plot);

        // Plot2d::setPlotSize clamps to a minimum of 400x300 internally.
        plot.SetPlotSize(640, 480);
        plot.SetShowGrid(false);
        plot.SetPlotLineColor(new Scalar(0, 0, 255));

        using var result = new Mat();
        plot.Render(result);
        Assert.False(result.Empty());
        Assert.Equal(480, result.Rows);
        Assert.Equal(640, result.Cols);
    }
}
