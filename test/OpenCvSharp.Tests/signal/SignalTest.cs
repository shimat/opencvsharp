using Xunit;

namespace OpenCvSharp.Tests.Signal;

public class SignalTest : TestBase
{
    [Fact]
    public void ResampleSignal()
    {
        const int inFreq = 48000;
        const int outFreq = 16000;
        const int length = 4800;

        using var inputSignal = new Mat(1, length, MatType.CV_32FC1);
        for (var i = 0; i < length; i++)
            inputSignal.Set(0, i, (float)Math.Sin(i * 0.1));

        using var outSignal = new Mat();
        Cv2.Signal.ResampleSignal(inputSignal, outSignal, inFreq, outFreq);

        Assert.False(outSignal.Empty());
        var expectedLength = length * outFreq / inFreq;
        Assert.InRange(outSignal.Cols, expectedLength - 1, expectedLength + 1);
    }
}
