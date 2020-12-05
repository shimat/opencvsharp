using OpenCvSharp.Util;
using Xunit;

namespace OpenCvSharp.Tests
{
    public class SaturateCastTest
    {
        [Theory]
        [InlineData(10, 10)]
        [InlineData(-1, 0)]
        [InlineData(256, 255)]
        public void ToByteFromInt(int from, byte to)
        {
            Assert.Equal(to, SaturateCast.ToByte(from));
        }

        [Theory]
        [InlineData(1.2345, 1)]
        [InlineData(-10000.98765, 0)]
        [InlineData(10000.12345, 255)]
        public void ToByteFromDouble(double from, byte to)
        {
            Assert.Equal(to, SaturateCast.ToByte(from));
        }
    }
}
