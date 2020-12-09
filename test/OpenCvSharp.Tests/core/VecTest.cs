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

        [Fact]
        public void ConversionVec2b()
        {
            var v = new Vec2b(1, 2);

            Assert.Equal(new Vec2s(1, 2), v.ToVec2s());
            Assert.Equal(new Vec2w(1, 2), v.ToVec2w());
            Assert.Equal(new Vec2i(1, 2), v.ToVec2i());
            Assert.Equal(new Vec2f(1, 2), v.ToVec2f());
            Assert.Equal(new Vec2d(1, 2), v.ToVec2d());
        }

        [Fact]
        public void ConversionVec3b()
        {
            var v = new Vec3b(1, 2, 3);

            Assert.Equal(new Vec3s(1, 2, 3), v.ToVec3s());
            Assert.Equal(new Vec3w(1, 2, 3), v.ToVec3w());
            Assert.Equal(new Vec3i(1, 2, 3), v.ToVec3i());
            Assert.Equal(new Vec3f(1, 2, 3), v.ToVec3f());
            Assert.Equal(new Vec3d(1, 2, 3), v.ToVec3d());
        }

        [Fact]
        public void ConversionVec4b()
        {
            var v = new Vec4b(1, 2, 3, 4);

            Assert.Equal(new Vec4s(1, 2, 3, 4), v.ToVec4s());
            Assert.Equal(new Vec4w(1, 2, 3, 4), v.ToVec4w());
            Assert.Equal(new Vec4i(1, 2, 3, 4), v.ToVec4i());
            Assert.Equal(new Vec4f(1, 2, 3, 4), v.ToVec4f());
            Assert.Equal(new Vec4d(1, 2, 3, 4), v.ToVec4d());
        }

        [Fact]
        public void ConversionVec6b()
        {
            var v = new Vec6b(1, 2, 3, 4, 5, 6);

            Assert.Equal(new Vec6s(1, 2, 3, 4, 5, 6), v.ToVec6s());
            Assert.Equal(new Vec6w(1, 2, 3, 4, 5, 6), v.ToVec6w());
            Assert.Equal(new Vec6i(1, 2, 3, 4, 5, 6), v.ToVec6i());
            Assert.Equal(new Vec6f(1, 2, 3, 4, 5, 6), v.ToVec6f());
            Assert.Equal(new Vec6d(1, 2, 3, 4, 5, 6), v.ToVec6d());
        }
    }
}
