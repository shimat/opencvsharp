using OpenCvSharp.ImgHash;
using Xunit;

namespace OpenCvSharp.Tests.ImgHash;

public class ImgHashFunctionsTest : TestBase
{
    [Theory]
    [InlineData("average")]
    [InlineData("blockMean")]
    [InlineData("colorMoment")]
    [InlineData("marrHildreth")]
    [InlineData("pHash")]
    [InlineData("radialVariance")]
    public void MatchesAlgorithmCompute(string algorithmName)
    {
        using var image = LoadImage("lenna.png");
        using var expected = new Mat();
        using var actual = new Mat();
        using var algorithm = CreateAlgorithm(algorithmName);

        algorithm.Compute(image, expected);
        ComputeOneShot(algorithmName, image, actual);

        using var mismatch = new Mat();
        Cv2.Compare(expected, actual, mismatch, CmpTypes.NE);
        Assert.Equal(0, Cv2.CountNonZero(mismatch.Reshape(1)));
    }

    private static ImgHashBase CreateAlgorithm(string name) => name switch
    {
        "average" => AverageHash.Create(),
        "blockMean" => BlockMeanHash.Create(),
        "colorMoment" => ColorMomentHash.Create(),
        "marrHildreth" => MarrHildrethHash.Create(),
        "pHash" => PHash.Create(),
        "radialVariance" => RadialVarianceHash.Create(),
        _ => throw new ArgumentOutOfRangeException(nameof(name)),
    };

    private static void ComputeOneShot(string name, Mat image, Mat output)
    {
        switch (name)
        {
            case "average": Cv2.ImgHash.AverageHash(image, output); break;
            case "blockMean": Cv2.ImgHash.BlockMeanHash(image, output); break;
            case "colorMoment": Cv2.ImgHash.ColorMomentHash(image, output); break;
            case "marrHildreth": Cv2.ImgHash.MarrHildrethHash(image, output); break;
            case "pHash": Cv2.ImgHash.PHash(image, output); break;
            case "radialVariance": Cv2.ImgHash.RadialVarianceHash(image, output); break;
            default: throw new ArgumentOutOfRangeException(nameof(name));
        }
    }
}
