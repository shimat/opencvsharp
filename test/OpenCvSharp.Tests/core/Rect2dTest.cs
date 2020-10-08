using Xunit;
using Xunit.Abstractions;

namespace OpenCvSharp.Tests.Core
{
    public class Rect2dTest
    {
        private readonly ITestOutputHelper testOutputHelper;

        public Rect2dTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void TopLeft()
        {
            var rect = new Rect2d(10, 10, 100, 100);

            Assert.Equal(10, rect.Top);
            Assert.Equal(10, rect.Left);
            Assert.Equal(new Point2d(10, 10), rect.TopLeft);
        }

        [Fact]
        public void BottomRight()
        {
            var rect = new Rect2d(10, 10, 100, 100);

            Assert.Equal(110, rect.Bottom);
            Assert.Equal(110, rect.Right);
            Assert.Equal(new Point2d(110, 110), rect.BottomRight);
        }

        [Fact]
        public void Contains()
        {
            var rect = new Rect2d(new Point2d(0, 0), new Size2d(3,3));

            // OpenCV typically assumes that the top and left boundary of the rectangle are inclusive,
            // while the right and bottom boundaries are not. https://docs.opencv.org/2.4/modules/core/doc/basic_structures.html?highlight=rect

            Assert.False(rect.Contains(0, -1));
            Assert.False(rect.Contains(-1, 0));
            Assert.False(rect.Contains(-1, -1));

            Assert.True(rect.Contains(0, 0));
            Assert.True(rect.Contains(0, 1));
            Assert.True(rect.Contains(1, 0));
            Assert.True(rect.Contains(1, 1));

            Assert.True(rect.Contains(2, 0));
            Assert.True(rect.Contains(2, 1));
            Assert.True(rect.Contains(2, 2));
            Assert.True(rect.Contains(0, 2));
            Assert.True(rect.Contains(1, 2));
            Assert.True(rect.Contains(2, 2));

            Assert.False(rect.Contains(0, 3));
            Assert.False(rect.Contains(1, 3));
            Assert.False(rect.Contains(2, 3));
            Assert.False(rect.Contains(3, 3));
            Assert.False(rect.Contains(3, 0));
            Assert.False(rect.Contains(3, 1));
            Assert.False(rect.Contains(3, 2));
            Assert.False(rect.Contains(3, 3));
        }

        // https://github.com/shimat/opencvsharp/issues/74
        // https://github.com/shimat/opencvsharp/issues/75
        [Fact]
        public void ContainsTopLeft()
        {
            var rect = new Rect2d(10, 10, 100, 100);

            Assert.True(rect.Contains(rect.TopLeft));
            Assert.True(rect.Contains(rect.Left, rect.Top));
        }

        [Fact]
        public void DoNotContainsBottomRight()
        {
            var rect = new Rect2d(10, 10, 100, 100);

            Assert.False(rect.Contains(rect.BottomRight));
            Assert.False(rect.Contains(rect.Right, rect.Bottom));
        }

        [Fact]
        public void ContainsRect()
        {
            var rect = new Rect2d(10, 10, 100, 100);

            Assert.True(rect.Contains(rect));
        }

        [Fact]
        public void IntersectsWith()
        {
            var rect1 = new Rect2d(0, 0, 100, 100);
            var rect2 = new Rect2d(0, 0, 100, 100);
            Assert.True(rect1.IntersectsWith(rect2));

            rect2 = new Rect2d(50, 0, 100, 100);
            Assert.True(rect1.IntersectsWith(rect2));

            rect2 = new Rect2d(100, 0, 100, 100);
            Assert.False(rect1.IntersectsWith(rect2));
        }

        [Fact]
        public void Intersect()
        {
            var rect1 = new Rect2d(0, 0, 100, 100);
            var rect2 = new Rect2d(0, 0, 100, 100);

            var intersect = rect1.Intersect(rect2);
            Assert.Equal(new Rect2d(0, 0, 100, 100), intersect);

            rect2 = new Rect2d(50, 0, 100, 100);
            intersect = rect1.Intersect(rect2);
            Assert.Equal(new Rect2d(50, 0, 50, 100), intersect);

            rect2 = new Rect2d(100, 0, 100, 100);
            intersect = rect1.Intersect(rect2);
            Assert.Equal(new Rect2d(100, 0, 0, 100), intersect);
        }

        [Fact]
        public void FromLTRB()
        {
            var rect = Rect2d.FromLTRB(1, 2, 3, 4);

            Assert.Equal(new Rect2d(1, 2, 3, 3), rect);
        }
    }
}
