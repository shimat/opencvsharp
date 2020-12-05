using Xunit;

namespace OpenCvSharp.Tests.core
{
    public class VecTest
    {
        [Fact]
        public void Vec2b()
        {
            Assert.Equal(
                new Vec2b(4, 6),
                new Vec2b(1, 2) + new Vec2b(3, 4));
            Assert.Equal(
                new Vec2b(255, 255), 
                new Vec2b(100, 200) + new Vec2b(200, 200));

            Assert.Equal(
                new Vec2b(9, 8),
                new Vec2b(10, 10) - new Vec2b(1, 2));
            Assert.Equal(
                new Vec2b(0, 0), 
                new Vec2b(10, 20) - new Vec2b(100, 200));

            Assert.Equal(
                new Vec2b(2, 4), 
                new Vec2b(1, 2) * 2);
            Assert.Equal(
                new Vec2b(5, 10),
                new Vec2b(2, 4) * 2.5);
            Assert.Equal(
                new Vec2b(255, 255), 
                new Vec2b(1, 2) * 10000);
            Assert.Equal(
                new Vec2b(0, 0), 
                new Vec2b(1, 2) * -10000);
        }

        [Fact]
        public void Vec3b()
        {
            Assert.Equal(
                new Vec3b(6, 9, 12), 
                new Vec3b(1, 2, 3) + new Vec3b(2, 3, 4) + new Vec3b(3, 4, 5));
            Assert.Equal(
                new Vec3b(200, 255, 255),
                new Vec3b(100, 150, 200) + new Vec3b(100, 150, 200));

            Assert.Equal(
                new Vec3b(9, 8, 7),
                new Vec3b(10, 10, 10) - new Vec3b(1, 2, 3));
            Assert.Equal(
                new Vec3b(0, 0, 0),
                new Vec3b(1, 2, 3) - new Vec3b(10, 20, 30));

            Assert.Equal(
                new Vec3b(2, 4, 6), 
                new Vec3b(1, 2, 3) * 2);
            Assert.Equal(
                new Vec3b(5, 10, 15), 
                new Vec3b(2, 4, 6) * 2.5);
            Assert.Equal(
                new Vec3b(255, 255, 255), 
                new Vec3b(1, 2, 3) * 10000);
            Assert.Equal(
                new Vec3b(0, 0, 0),
                new Vec3b(1, 2, 3) * -10000);

            Assert.Equal(
                new Vec3b(2, 1, 0),
                new Vec3b(3, 2, 1) / 2);
        }
    }
}
