using System;
using OpenCvSharp.Dnn;
using OpenCvSharp.Tests.dnn;
using Xunit;
using Xunit.Abstractions;

namespace OpenCvSharp.Tests.Dnn
{
    public class NetTest : TestBase, IClassFixture<DnnDataFixture>
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly CaffeData caffeData;

        public NetTest(ITestOutputHelper testOutputHelper, DnnDataFixture fixture)
        {
            if (fixture == null) 
                throw new ArgumentNullException(nameof(fixture));
            this.testOutputHelper = testOutputHelper;
            caffeData = fixture.Caffe.Value;
        }

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

        [ExplicitFact]
        public void Dump()
        {
            var net = caffeData.Net;
            var dump = net.Dump();
            Assert.NotEmpty(dump);
        }
    }
}
