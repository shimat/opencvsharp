using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Core;
using NUnit.Framework;
using OpenCvSharp.Blob;

namespace OpenCvSharp.NUnitTest
{
    [TestFixture]
    public class BlobTest
    {
        [Test]
        public void CheckPlatform()
        {
            Assert.Inconclusive("My platform is {0}", IntPtr.Size == 8 ? "x64" : "x86");
        }
        
        [Test]
        public void SimpleTest()
        {
        }
    }
}

