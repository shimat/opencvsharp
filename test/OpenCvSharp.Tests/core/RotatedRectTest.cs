using System.Globalization;
using Xunit;

namespace OpenCvSharp.Tests.Core;

public class RotatedRectTest
{
    [Fact]
    public void FromThreeVertexPoints()
    {
        for (int angle = -360; angle <= +360; angle++)
        {
            var rt1 = new RotatedRect(
                center: new(50.5f, 50.5f),
                size: new(100.5f, 100.5f),
                angle: angle);
            var p = rt1.Points();
            var rt2 = new RotatedRect(p[0], p[1], p[2]);

            var rt2Native = RotatedRect.FromThreeVertexPoints(p[0], p[1], p[2]);

            // same as native result
            Assert.Equal(rt2.Angle, rt2Native.Angle, 1e-4);
            Assert.Equal(rt2.Center.X, rt2Native.Center.X, 1e-4);
            Assert.Equal(rt2.Center.Y, rt2Native.Center.Y, 1e-4);
            Assert.Equal(rt2.Size.Width, rt2Native.Size.Width, 1e-4);
            Assert.Equal(rt2.Size.Height, rt2Native.Size.Height, 1e-4);

            const double tolerance = 0.0001;
            var angleDiff = Math.Abs(rt2.Angle - rt1.Angle) % 90;
            Assert.True(
                (angleDiff < tolerance || angleDiff > 90 - tolerance)
                && Math.Abs(rt2.Center.X - rt1.Center.X) < tolerance
                && Math.Abs(rt2.Center.Y - rt1.Center.Y) < tolerance
                && Math.Abs(rt2.Size.Width - rt1.Size.Width) < tolerance
                && Math.Abs(rt2.Size.Height - rt1.Size.Height) < tolerance,
                string.Format(
                    CultureInfo.InvariantCulture,
                    $"angle={angle}\n"
                    + $"angleDiff = {angleDiff}"
                    + "1 rtAngle={0} rtCenterX={1} rtCenterY={2} rtWidth={3} rtHeight={4}\n"
                    + "2 rtAngle={5} rtCenterX={6} rtCenterY={7} rtWidth={8} rtHeight={9}\n",
                    rt1.Angle, rt1.Center.X, rt1.Center.Y, rt1.Size.Width, rt1.Size.Height,
                    rt2.Angle, rt2.Center.X, rt2.Center.Y, rt2.Size.Width, rt2.Size.Height));
        }
    }
}
