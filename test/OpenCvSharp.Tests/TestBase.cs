using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace OpenCvSharp.Tests
{
    public abstract class TestBase 
    {
        protected TestBase()
        {
            Directory.SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);
        }

        protected Mat Image(string fileName, ImreadModes modes = ImreadModes.Color)
        {
            return new Mat(Path.Combine("_data", "image", fileName), modes);
        }
    }
}
