using System.Runtime.InteropServices;
using System.Text;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using OpenCvSharp.Dnn;
using Xunit;

namespace OpenCvSharp.Tests.Dnn;

// Tests for the high-level dnn text Model API.
//
// The end-to-end EAST test downloads the EAST model (same as EastTextDetectionTest),
// so it is marked Explicit and does not run in the normal CI pass. The lifecycle
// tests construct each text model from an empty Net and exercise the setters/getters,
// verifying the native constructors, destructors and accessors are wired up.
public class TextModelTest : TestBase
{
    public static bool IsWindowsOrLinux =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

    // https://github.com/opencv/opencv_extra/blob/master/testdata/dnn/download_models.py
    private const string EastModelUrl = "https://www.dropbox.com/s/r2ingd0l3zt8hxs/frozen_east_text_detection.tar.gz?dl=1";
    private const string EastRawModelPath = "_data/model/frozen_east_text_detection.tar.gz";
    private const string EastModelPath = "_data/model/frozen_east_text_detection.pb";
    private static readonly object lockObj = new();

    [ExplicitTheory]
    [InlineData("_data/image/abbey_road.jpg")]
    public void TextDetectionModelEastDetectsText(string imageFileName)
    {
        PrepareEastModel();

        using var img = new Mat(imageFileName);

        using var model = new TextDetectionModelEAST(EastModelPath);
        model.SetConfidenceThreshold(0.5f);
        model.SetNMSThreshold(0.4f);
        // EAST expects the input size to be a multiple of 32.
        model.SetInputParams(1.0, new Size(320, 320), new Scalar(123.68, 116.78, 103.94), true);

        model.DetectTextRectangles(img, out var detections, out var confidences);

        Assert.NotEmpty(detections);
        Assert.Equal(detections.Length, confidences.Length);
        Assert.All(confidences, c => Assert.True(c >= 0.5f, $"confidence {c} below threshold"));
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void TextRecognitionModelLifecycle()
    {
        using var net = new Net();
        using var model = new TextRecognitionModel(net);

        model.SetDecodeType("CTC-greedy");
        Assert.Equal("CTC-greedy", model.GetDecodeType());

        var vocabulary = new[] { "a", "b", "c" };
        model.SetVocabulary(vocabulary);
        Assert.Equal(vocabulary, model.GetVocabulary());

        model.SetDecodeOptsCTCPrefixBeamSearch(10);
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void TextDetectionModelEastLifecycle()
    {
        using var net = new Net();
        using var model = new TextDetectionModelEAST(net);

        model.SetConfidenceThreshold(0.5f);
        Assert.Equal(0.5f, model.GetConfidenceThreshold());
        model.SetNMSThreshold(0.4f);
        Assert.Equal(0.4f, model.GetNMSThreshold());
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void TextDetectionModelDbLifecycle()
    {
        using var net = new Net();
        using var model = new TextDetectionModelDB(net);

        model.SetBinaryThreshold(0.3f);
        Assert.Equal(0.3f, model.GetBinaryThreshold());
        model.SetPolygonThreshold(0.5f);
        Assert.Equal(0.5f, model.GetPolygonThreshold());
        model.SetUnclipRatio(2.0);
        Assert.Equal(2.0, model.GetUnclipRatio());
        model.SetMaxCandidates(200);
        Assert.Equal(200, model.GetMaxCandidates());
    }

    private static void PrepareEastModel()
    {
        lock (lockObj)
        {
            if (!File.Exists(EastRawModelPath))
            {
                var contents = FileDownloader.DownloadData(new Uri(EastModelUrl));
                File.WriteAllBytes(EastRawModelPath, contents);
            }

            if (!File.Exists(EastModelPath))
            {
                using var inputStream = new FileStream(EastRawModelPath, FileMode.Open, FileAccess.Read);
                using var gzipStream = new GZipInputStream(inputStream);
                using var tarArchive = TarArchive.CreateInputTarArchive(gzipStream, Encoding.UTF8);
                tarArchive.ExtractContents(Path.GetDirectoryName(EastRawModelPath)!);
            }

            Assert.True(File.Exists(EastModelPath), $"'{EastModelPath}' not found");
        }
    }
}
