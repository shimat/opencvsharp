using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp.Dnn;
using Xunit;

namespace OpenCvSharp.Tests.Dnn
{
    public class NetTest : TestBase
    {
        [Fact]
        public void Empty()
        {
            using (var net = new Net())
            {
                Assert.True(net.Empty());
            }
        }

        [Fact]
        public void GetLayerNames()
        {
            using (var net = new Net())
            {
                Assert.Empty(net.GetLayerNames());
            }
        }
    }
}
