using Xunit;
using Xunit.Abstractions;

// ReSharper disable RedundantArgumentDefaultValue

namespace OpenCvSharp.Tests.Core;

public class SolveEquationTest : TestBase
{
    private readonly ITestOutputHelper testOutputHelper;

    public SolveEquationTest(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void ByMat()
    {
        // x + y = 10
        // 2x + 3y = 26
        // (x=4, y=6)

        double[,] av = {
            {1, 1},
            {2, 3}};
        double[] yv = [10, 26];

        using var a = Mat.FromPixelData(2, 2, MatType.CV_64FC1, av);
        using var y = Mat.FromPixelData(2, 1, MatType.CV_64FC1, yv);
        using var x = new Mat();

        Cv2.Solve(a, y, x, DecompTypes.LU);

        testOutputHelper.WriteLine("X1 = {0}, X2 = {1}", x.At<double>(0), x.At<double>(1));
        Assert.Equal(4, x.At<double>(0), 6);
        Assert.Equal(6, x.At<double>(1), 6);
    }

    [Fact]
    public void ByNormalArray()
    {
        // x + y = 10
        // 2x + 3y = 26
        // (x=4, y=6)

        double[,] a = {
            {1, 1},
            {2, 3}};
        double[] y = [10, 26];

        var x = new List<double>();

        using var ia = InputArray.Create(a);
        using var iy = InputArray.Create(y);
        using var ox = OutputArray.Create(x);
        Cv2.Solve(ia, iy, ox, DecompTypes.LU);

        testOutputHelper.WriteLine("X1 = {0}, X2 = {1}", x[0], x[1]);
        Assert.Equal(4, x[0], 6);
        Assert.Equal(6, x[1], 6);
    }
}
