using System;
using System.Collections.Generic;
using OpenCvSharp.Detail;
using Xunit;

#pragma warning disable 162

namespace OpenCvSharp.Tests.ObjDetect
{
    public class HOGDescriptorTest : TestBase
    {
        [Fact]
        public void PropertyCellSize()
        {
            using (var obj = new HOGDescriptor())
            {
                Size value = new Size(123, 789);
                obj.CellSize = value;
                Assert.Equal(value, obj.CellSize);
            }
        }

        [Fact]
        public void PropertyWinSize()
        {
            using (var obj = new HOGDescriptor())
            {
                Size value = new Size(123, 789);
                obj.WinSize = value;
                Assert.Equal(value, obj.WinSize);
            }
        }
    }
}

