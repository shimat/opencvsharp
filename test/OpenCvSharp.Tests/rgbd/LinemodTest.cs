using OpenCvSharp.Rgbd;
using Xunit;

namespace OpenCvSharp.Tests.Rgbd;

public class LinemodTest
{
    [Fact]
    public void ModalitiesExposeParametersAndNames()
    {
        using var color = new ColorGradient(12f, 48, 60f);
        Assert.Equal("ColorGradient", color.Name);
        Assert.Equal(12f, color.WeakThreshold);
        Assert.Equal((nuint)48, color.NumFeatures);
        Assert.Equal(60f, color.StrongThreshold);

        using var depth = new DepthNormal(1500, 40, 32, 3);
        Assert.Equal("DepthNormal", depth.Name);
        Assert.Equal(1500, depth.DistanceThreshold);
        Assert.Equal(40, depth.DifferenceThreshold);
        Assert.Equal((nuint)32, depth.NumFeatures);
        Assert.Equal(3, depth.ExtractThreshold);
    }

    [Fact]
    public void ColorGradientCreatesQuantizedPyramid()
    {
        using var image = CreateTestImage();
        using var modality = new ColorGradient();
        using var pyramid = modality.Process(image);
        using var quantized = pyramid.Quantize();

        Assert.Equal(image.Size(), quantized.Size());
        Assert.Equal(MatType.CV_8UC1, quantized.Type());
    }

    [Fact]
    public void ModalityCanRoundTripThroughFileStorage()
    {
        string yaml;
        using (var modality = new ColorGradient(12f, 48, 60f))
        using (var storage = new FileStorage("yml", FileStorage.Modes.Write | FileStorage.Modes.Memory))
        {
            storage.StartWriteStruct("modality", FileNode.Types.Map);
            modality.Write(storage);
            storage.EndWriteStruct();
            yaml = storage.ReleaseAndGetString();
        }

        using var input = new FileStorage(yaml, FileStorage.Modes.Read | FileStorage.Modes.Memory);
        using var node = input["modality"]!;
        using var restored = LinemodModality.Create(node);
        Assert.Equal("ColorGradient", restored.Name);
    }

    [Fact]
    public void DefaultLineCanAddAndMatchTemplate()
    {
        using var image = CreateTestImage();
        using var mask = new Mat(image.Size(), MatType.CV_8UC1, Scalar.Black);
        Cv2.Rectangle(mask, new Rect(12, 12, 104, 104), Scalar.White, -1);
        using var modality = new ColorGradient(1f, 4, 2f);
        using (var pyramid = modality.Process(image, mask))
            Assert.True(pyramid.ExtractTemplate(out _));
        using var detector = new LinemodDetector([modality], [4]);

        var templateId = detector.AddTemplate([image], "shape", mask, out var bounds);

        Assert.True(templateId >= 0);
        Assert.Equal(1, detector.NumClasses);
        Assert.Equal(1, detector.GetNumTemplates("shape"));
        Assert.Contains("shape", detector.GetClassIds());
        Assert.True(bounds.Width > 0);
        Assert.True(bounds.Height > 0);

        var templates = detector.GetTemplates("shape", templateId);
        Assert.Single(templates);
        Assert.Equal(4, templates[0].Features.Length);
        var detectorModalities = detector.GetModalities();
        try
        {
            Assert.Single(detectorModalities);
            Assert.Equal("ColorGradient", detectorModalities[0].Name);
        }
        finally
        {
            foreach (var detectorModality in detectorModalities)
                detectorModality.Dispose();
        }

        using var syntheticDetector = new LinemodDetector([modality], [4]);
        Assert.Equal(0, syntheticDetector.AddSyntheticTemplate(templates, "synthetic"));
        Assert.Equal(1, syntheticDetector.GetNumTemplates("synthetic"));

        string serializedClass;
        using (var storage = new FileStorage("yml", FileStorage.Modes.Write | FileStorage.Modes.Memory))
        {
            detector.WriteClass("shape", storage);
            serializedClass = storage.ReleaseAndGetString();
        }
        using (var input = new FileStorage(serializedClass, FileStorage.Modes.Read | FileStorage.Modes.Memory))
        using (var root = input.Root()!)
        using (var restoredDetector = new LinemodDetector([modality], [4]))
        {
            Assert.Equal("shape", restoredDetector.ReadClass(root));
            Assert.Equal(1, restoredDetector.GetNumTemplates("shape"));
        }

        var matches = detector.Match([image], 80f, out var quantizedImages);
        try
        {
            Assert.Contains(matches, m => m.ClassId == "shape" && m.TemplateId == templateId);
            Assert.NotEmpty(quantizedImages);
        }
        finally
        {
            foreach (var quantized in quantizedImages)
                quantized.Dispose();
        }
    }

    private static Mat CreateTestImage()
    {
        var image = new Mat(128, 128, MatType.CV_8UC3, Scalar.Black);
        for (var x = 0; x < image.Cols; x += 16)
            Cv2.Rectangle(image, new Rect(x, 0, 8, image.Rows), Scalar.White, -1);
        Cv2.Rectangle(image, new Rect(20, 20, 80, 80), Scalar.White, 4);
        Cv2.Line(image, new Point(24, 24), new Point(94, 94), Scalar.Red, 5);
        Cv2.Circle(image, new Point(64, 64), 20, Scalar.Green, 4);
        return image;
    }
}
