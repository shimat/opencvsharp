using System;
using System.IO;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using OpenCvSharp.Dnn;
using Xunit;
using Xunit.Abstractions;

namespace OpenCvSharp.Tests.Dnn
{
    /// <summary>
    /// https://github.com/opencv/opencv/blob/master/samples/dnn/text_detection.cpp
    /// </summary>
    /// <see cref="https://gist.github.com/ludwo/c091ed6261d26654c8b71949d89f8142"/>
    /// <see cref="https://github.com/shimat/opencvsharp/issues/702"/>
    public class EastTextDetectionTest : TestBase
    {
        // https://github.com/opencv/opencv_extra/blob/322b475403899abc2411c4fbf68318afa77d3191/testdata/dnn/download_models.py#L302
        const string ModelUrl = "https://www.dropbox.com/s/r2ingd0l3zt8hxs/frozen_east_text_detection.tar.gz?dl=1"; 
        const string LocalRawModelPath = "_data/model/frozen_east_text_detection.tar.gz";
        const string LocalModelPath = "_data/model/frozen_east_text_detection.pb";

        private static readonly object lockObj = new object();

        private readonly ITestOutputHelper testOutputHelper;

        /// <summary>
        /// Download model file
        /// </summary>
        /// <param name="testOutputHelper"></param>
        public EastTextDetectionTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper ?? throw new ArgumentNullException(nameof(testOutputHelper));
            
            testOutputHelper.WriteLine("Downloading EAST Model...");
            PrepareModel(new Uri(ModelUrl), LocalRawModelPath);
            testOutputHelper.WriteLine("Done");
            Assert.True(File.Exists(LocalRawModelPath), $"'{LocalRawModelPath}' not found");

            if (!File.Exists(LocalModelPath))
            {
                var modelDirectory = Path.GetDirectoryName(LocalRawModelPath)!;
                ExtractTarGz(LocalRawModelPath, modelDirectory);
            }

            var fileInfo = new FileInfo(LocalModelPath);
            Assert.True(fileInfo.Exists, $"'{LocalModelPath}' not found");
            Assert.True(fileInfo.Length > 90 * 1024 * 1024, $"Too small data ('{fileInfo.Length}' bytes)");
        }

        /// <summary>
        /// Download model file if it does not exist on local disk
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="fileName"></param>
        private static void PrepareModel(Uri uri, string fileName)
        {
            lock (lockObj)
            {
                if (!File.Exists(fileName))
                {
                    var contents = DownloadBytes(uri);
                    File.WriteAllBytes(fileName, contents);
                }
            }
        }

        /// <summary>
        /// Simple full extract from a TGZ
        /// https://github.com/icsharpcode/SharpZipLib/wiki/GZip-and-Tar-Samples
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="dstFolder"></param>
        private static void ExtractTarGz(string inputFile, string dstFolder)
        {
            using var inputStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
            using var gzipStream = new GZipInputStream(inputStream);
            using var tarArchive = TarArchive.CreateInputTarArchive(gzipStream);
            tarArchive.ExtractContents(dstFolder);
        }

        [Fact]
        public void Load()
        {
            Assert.True(File.Exists(LocalModelPath), $"'{LocalModelPath}' not found");

            using var net = CvDnn.ReadNet(LocalModelPath);
        }

        [Fact]
        public void NotSupportedUnicodeFileName()
        {
            Assert.True(File.Exists(LocalModelPath), $"'{LocalModelPath}' not found");

            var unicodeFileName = Path.Combine(Path.GetDirectoryName(LocalModelPath)!, "🤣🍀.pb");
            if (!File.Exists(unicodeFileName))
            {
                File.Copy(LocalModelPath, unicodeFileName, true);
            }

            // Check that ArgumentException(unicode unmappable char) does not occur.
            var ex = Assert.Throws<OpenCVException>(() =>
            {
                using var net = CvDnn.ReadNet(unicodeFileName);
            });
            Assert.StartsWith("FAILED: fs.is_open(). Can't open", ex.Message, StringComparison.InvariantCulture);
            Assert.Equal("cv::dnn::ReadProtoFromBinaryFile", ex.FuncName);
        }
    }
}
