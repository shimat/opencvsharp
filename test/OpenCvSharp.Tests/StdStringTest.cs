using System;
using NUnit.Framework;

namespace OpenCvSharp.Tests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class StdStringTest : TestBase
    {
        [Test]
        public void SimpleNew()
        {
            using (var s = new StdString())
            {
            }
        }

        [Test]
        public void ToStringTest()
        {
            const string value = "foo";
            using (var s = new StdString(value))
            {
                Assert.AreEqual(value, s.ToString());
            }
        }
    }
}
