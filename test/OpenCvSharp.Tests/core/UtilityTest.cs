using System;
using Xunit;
using Xunit.Abstractions;

namespace OpenCvSharp.Tests.Core
{
    public class UtilityTest : TestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        public UtilityTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void GetAndSetNumThreads()
        {
            // GCD framework on Apple platforms causes different behaviour of SetNumThreads 
            // https://docs.opencv.org/3.4/db/de0/group__core__utils.html#gae78625c3c2aa9e0b83ed31b73c6549c0
            if(!System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX))
            {
                int threads = Cv2.GetNumThreads();
            
                Cv2.SetNumThreads(threads + 1);
                Assert.Equal(threads + 1, Cv2.GetNumThreads());

                Cv2.SetNumThreads(threads);
                Assert.Equal(threads, Cv2.GetNumThreads());
            }
        }
        
        [Fact]
        public void GetThreadNum()
        {
            testOutputHelper.WriteLine("GetThreadNum: {0}", Cv2.GetThreadNum());
        }

        [Fact]
        public void GetBuildInformation()
        {
            Assert.NotEmpty(Cv2.GetBuildInformation());
            testOutputHelper.WriteLine("GetBuildInformation: {0}", Cv2.GetBuildInformation());
            Console.WriteLine("GetBuildInformation: {0}", Cv2.GetBuildInformation());
        }

        [Fact]
        public void GetVersionString()
        {
            Assert.NotEmpty(Cv2.GetVersionString());
            testOutputHelper.WriteLine("GetVersionString: {0}", Cv2.GetVersionString());
        }

        [Fact]
        public void GetVersionMajor()
        {
            testOutputHelper.WriteLine("GetVersionMajor: {0}", Cv2.GetVersionMajor());
        }

        [Fact]
        public void GetVersionMinor()
        {
            testOutputHelper.WriteLine("GetVersionMinor: {0}", Cv2.GetVersionMinor());
        }

        [Fact]
        public void GetVersionRevision()
        {
            testOutputHelper.WriteLine("GetVersionRevision: {0}", Cv2.GetVersionRevision());
        }

        [Fact]
        public void GetTickCount()
        {
            testOutputHelper.WriteLine("GetTickCount: {0}", Cv2.GetTickCount());
        }

        [Fact]
        public void GetTickFrequency()
        {
            testOutputHelper.WriteLine("GetTickFrequency: {0}", Cv2.GetTickFrequency());
        }

        [Fact]
        public void GetCpuTickCount()
        {
            testOutputHelper.WriteLine("GetCpuTickCount: {0}", Cv2.GetCpuTickCount());
        }

        [Fact]
        public void CheckHardwareSupport()
        {
            var features = (CpuFeatures[])Enum.GetValues(typeof(CpuFeatures));

            foreach (var feature in features)
            {
                testOutputHelper.WriteLine("CPU Feature '{0}': {1}", feature, Cv2.CheckHardwareSupport(feature));
            }
        }

        [Fact]
        public void GetHardwareFeatureName()
        {
            testOutputHelper.WriteLine(Cv2.GetHardwareFeatureName(0));
        }

        [Fact]
        public void GetCpuFeaturesLine()
        {
            Assert.NotEmpty(Cv2.GetCpuFeaturesLine());
            testOutputHelper.WriteLine("GetCpuFeaturesLine: {0}", Cv2.GetCpuFeaturesLine());
        }

        [Fact]
        // ReSharper disable once IdentifierTypo
        public void GetNumberOfCpus()
        {
            Assert.True(1 <= Cv2.GetNumberOfCpus());
        }

        [Theory]
        [InlineData(FormatType.Default)]
        [InlineData(FormatType.MATLAB)]
        [InlineData(FormatType.CSV)]
        [InlineData(FormatType.Python)]
        [InlineData(FormatType.NumPy)]
        [InlineData(FormatType.C)]
        public void Format(FormatType format)
        {
            using var mat = new Mat(3, 3, MatType.CV_8UC1, new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9});
            var result = Cv2.Format(mat, format);
            Assert.NotEmpty(result);
            testOutputHelper.WriteLine("Format: {0}", format);
            testOutputHelper.WriteLine(result);
        }

        [Theory]
        [InlineData(FormatType.Default)]
        [InlineData(FormatType.MATLAB)]
        [InlineData(FormatType.CSV)]
        [InlineData(FormatType.Python)]
        [InlineData(FormatType.NumPy)]
        [InlineData(FormatType.C)]
        public void Dump(FormatType format)
        {
            using var mat = new Mat(3, 3, MatType.CV_8UC1, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            var result = mat.Dump(format);
            Assert.NotEmpty(result);
            Assert.Equal(Cv2.Format(mat, format), result);
            testOutputHelper.WriteLine("Dump: {0}", format);
            testOutputHelper.WriteLine(result);
        }
    }
}