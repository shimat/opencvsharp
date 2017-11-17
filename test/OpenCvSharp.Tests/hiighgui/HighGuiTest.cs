using System;
using Xunit;

namespace OpenCvSharp.Tests.HighGui
{
    public class HighGuiTest : TestBase
    {
        [Fact]
        public void WaitKey()
        {
            int val = Cv2.WaitKey(1);
            Assert.Equal(-1, val);
        }

        [Fact]
        public void WaitKeyEx()
        {
            int val = Cv2.WaitKeyEx(1);
            Assert.Equal(-1, val);
        }
    }
}

