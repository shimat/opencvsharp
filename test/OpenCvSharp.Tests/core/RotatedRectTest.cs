using System;
using System.Globalization;
using Xunit;

namespace OpenCvSharp.Tests.Core;

public class RotatedRectTest
{
    [Fact]
    public void FromThreeVertexPoints()
    {
        for (int angle = -44; angle <= +44; angle++)
        {
            var rt1 = new RotatedRect(
                center: new(50f, 50f),
                size: new(100f, 100f),
                angle: angle);
            var p = rt1.Points();
            var rt2 = new RotatedRect(p[0], p[1], p[2]);
            var tolerance = 0.0001;

            Assert.True(
                Math.Abs(rt2.Angle - rt1.Angle) < tolerance
                && Math.Abs(rt2.Center.X - rt1.Center.X) < tolerance
                && Math.Abs(rt2.Center.Y - rt1.Center.Y) < tolerance
                && Math.Abs(rt2.Size.Width - rt1.Size.Width) < tolerance
                && Math.Abs(rt2.Size.Height - rt1.Size.Height) < tolerance,
                string.Format(
                    CultureInfo.InvariantCulture,
                    $"angle={angle}\n"
                    + "1 rtAngle={0} rtCenterX={1} rtCenterY={2} rtWidth={3} rtHeight={4}\n"
                    + "2 rtAngle={5} rtCenterX={6} rtCenterY={7} rtWidth={8} rtHeight={9}\n",
                    rt1.Angle, rt1.Center.X, rt1.Center.Y, rt1.Size.Width, rt1.Size.Height,
                    rt2.Angle, rt2.Center.X, rt2.Center.Y, rt2.Size.Width, rt2.Size.Height));
        }
    }
}
