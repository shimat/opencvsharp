using System.Runtime.InteropServices;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Tiff;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using Xunit;
using Color = SixLabors.ImageSharp.Color;
using Image = SixLabors.ImageSharp.Image;

#pragma warning disable CA1031

namespace OpenCvSharp.Tests.ImgCodecs;

public class ImgCodecsTest : TestBase
{
    private readonly ITestOutputHelper testOutputHelper;

    // Platform check for conditional test execution
    public static bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    public ImgCodecsTest(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }
    
    [Theory]
    [InlineData("building.jpg")]
    [InlineData("lenna.png")]
    [InlineData("building_mask.bmp")]
    public void ImReadSuccess(string fileName)
    {
        using (var image = LoadImage(fileName, ImreadModes.Grayscale))
        {
            Assert.False(image.Empty());
        }
        // ReSharper disable once RedundantArgumentDefaultValue
        using (var image = LoadImage(fileName, ImreadModes.Color))
        {
            Assert.False(image.Empty());
        }
        using (var image = LoadImage(fileName, ImreadModes.AnyColor | ImreadModes.AnyDepth))
        {
            Assert.False(image.Empty());
        }
    }

    [Fact]
    public void ImReadFailure()
    {
        using var image = Cv2.ImRead("not_exist.png", ImreadModes.Grayscale);
        Assert.NotNull(image);
        Assert.True(image.Empty());
    }
        
    [Fact(Skip = "supported?")]
    public void ImReadDoesNotSupportGif()
    {
        using var image = Cv2.ImRead("_data/image/empty.gif", ImreadModes.Grayscale);
        Assert.NotNull(image);
        Assert.True(image.Empty());
    }

    [Fact]
    public void ImReadJapaneseFileName()
    {
        // https://github.com/opencv/opencv/issues/4242
        // TODO: Fails on AppVeyor (probably this test succeeds only on Japanese Windows)

        testOutputHelper.WriteLine($"CurrentCulture: {Thread.CurrentThread.CurrentCulture.Name}");
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
            Thread.CurrentThread.CurrentCulture.Name != "ja-JP")
        {
            testOutputHelper.WriteLine($"Skip {nameof(ImReadJapaneseFileName)}");
            return;
        }

        const string fileName = "_data/image/imread_にほんご日本語.png";

        // Create test data
        {
            using var image = new Image<Bgr24>(10, 10);
            image.Mutate(x =>
            {
                x.Fill(Color.Red);
            });
            image.SaveAsPng(fileName);
        }

        Assert.True(File.Exists(fileName), $"File '{fileName}' not found");

        using var mat = Cv2.ImRead(fileName);
        Assert.NotNull(mat);
        Assert.False(mat.Empty());
    }

    // Unicode (incl. non-ANSI) paths now work on every platform: the native side reads via a wide
    // path on Windows. (Formerly unsupported on Windows; opencv #4242.)
    [Fact]
    public void ImReadUnicodeFileName()
    {
        const string fileName = "_data/image/imread♥♡😀😄.png";

        CreateDummyImageFile(fileName);

        using var image = Cv2.ImRead(fileName);
        Assert.NotNull(image);
        Assert.False(image.Empty());
    }

    // --- Edge cases for the Windows non-ANSI (wide-path) route: gating, mmap decode and its fallbacks ---

    [Fact]
    public void ImReadWriteUnicodeRoundTripPixels()
    {
        // The wide-path encode/write and mmap decode must produce byte-identical pixels (PNG is lossless).
        const string fileName = "_data/image/roundtrip♥😀.png";
        try
        {
            using var src = new Mat(10, 20, MatType.CV_8UC3, Scalar.Blue);
            src.Set(3, 5, new Vec3b(10, 20, 30));
            src.Set(9, 19, new Vec3b(200, 100, 50));

            Assert.True(Cv2.ImWrite(fileName, src));
            Assert.True(File.Exists(fileName), $"File '{fileName}' not found");

            using var dst = Cv2.ImRead(fileName, ImreadModes.Color);
            Assert.False(dst.Empty());
            Assert.Equal(src.Rows, dst.Rows);
            Assert.Equal(src.Cols, dst.Cols);
            Assert.Equal(src.At<Vec3b>(0, 0), dst.At<Vec3b>(0, 0));
            Assert.Equal(src.At<Vec3b>(3, 5), dst.At<Vec3b>(3, 5));
            Assert.Equal(src.At<Vec3b>(9, 19), dst.At<Vec3b>(9, 19));
        }
        finally
        {
            if (File.Exists(fileName)) File.Delete(fileName);
        }
    }

    [Fact]
    public void ImReadUnicodeEmptyFileReturnsEmpty()
    {
        // 0-byte file with a non-ANSI name: mapping is skipped and the fallback yields an empty Mat (no crash).
        const string fileName = "_data/image/empty♡😄.png";
        try
        {
            File.WriteAllBytes(fileName, Array.Empty<byte>());
            using var image = Cv2.ImRead(fileName);
            Assert.NotNull(image);
            Assert.True(image.Empty());
        }
        finally
        {
            if (File.Exists(fileName)) File.Delete(fileName);
        }
    }

    [Fact]
    public void ImReadUnicodeMissingFileReturnsEmpty()
    {
        using var image = Cv2.ImRead("_data/image/does_not_exist♥😀.png");
        Assert.NotNull(image);
        Assert.True(image.Empty());
    }

    [Fact]
    public void HaveImageReaderUnicodeNonImageIsFalse()
    {
        // Non-ANSI name with a .png extension but non-image content -> not decodable.
        const string fileName = "_data/image/notimage♥😀.png";
        try
        {
            File.WriteAllText(fileName, "this is not an image");
            Assert.False(Cv2.HaveImageReader(fileName));
            using var image = Cv2.ImRead(fileName);
            Assert.True(image.Empty());
        }
        finally
        {
            if (File.Exists(fileName)) File.Delete(fileName);
        }
    }

    [Theory]
    [InlineData(".jpg")]
    [InlineData(".png")]
    [InlineData(".bmp")]
    [InlineData(".tif")]
    public void ImWrite(string ext)
    {
        var fileName = $"test_imwrite{ext}";

        using (var mat = new Mat(10, 20, MatType.CV_8UC3, Scalar.Blue))
        {
            Cv2.ImWrite(fileName, mat);
        }

        var imageInfo = Image.Identify(fileName);
        Assert.Equal(10, imageInfo.Height);
        Assert.Equal(20, imageInfo.Width);
    }

    //[LinuxOnlyFact]
    [Fact]
    public void ImWriteJapaneseFileName()
    {
        // TODO: Fails on AppVeyor (probably this test succeeds only on Japanese Windows)
        testOutputHelper.WriteLine($"CurrentCulture: {Thread.CurrentThread.CurrentCulture.Name}");
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
            Thread.CurrentThread.CurrentCulture.Name != "ja-JP")
        {
            testOutputHelper.WriteLine($"Skip {nameof(ImWriteJapaneseFileName)}");
            return;
        }

        const string fileName = "_data/image/imwrite_にほんご日本語.png";

        using (var mat = new Mat(10, 20, MatType.CV_8UC3, Scalar.Blue))
        {
            Cv2.ImWrite(fileName, mat);
        }

        Assert.True(File.Exists(fileName), $"File '{fileName}' not found");

        var imageInfo = Image.Identify(fileName);
        Assert.Equal(10, imageInfo.Height);
        Assert.Equal(20, imageInfo.Width);
    }

    // Unicode (incl. non-ANSI) paths now work on every platform: the native side writes via a wide
    // path on Windows. (Formerly unsupported on Windows; opencv #4242.)
    [Fact]
    public void ImWriteUnicodeFileName()
    {
        const string fileName = "_data/image/imwrite♥♡😀😄.png";

        // Check whether the path is valid
        // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
        Path.GetFullPath(fileName);

        using (var mat = new Mat(10, 20, MatType.CV_8UC3, Scalar.Blue))
        {
            Cv2.ImWrite(fileName, mat);
        }

        var file = new FileInfo(fileName);
        Assert.True(file.Exists, $"File '{fileName}' not found");
        Assert.True(file.Length > 0, $"File size of '{fileName}' == 0");

        const string asciiFileName = "_data/image/imwrite_unicode_test.png";
#if NET5_0_OR_GREATER
        File.Move(fileName, asciiFileName, overwrite: true);
#else
        if (File.Exists(asciiFileName)) File.Delete(asciiFileName);
        File.Move(fileName, asciiFileName);
#endif
        var imageInfo = Image.Identify(asciiFileName);

        Assert.Equal(10, imageInfo.Height);
        Assert.Equal(20, imageInfo.Width);
    }

    [Theory]
    [InlineData("foo.png")]
    [InlineData("bar.jpg")]
    [InlineData("baz.bmp")]
    public void HaveImageReader(string fileName)
    {
        var path = Path.Combine("_data", "image", "haveImageReader_" + fileName);

        try
        {
            // Create a file for test
            using (var mat = new Mat(10, 20, MatType.CV_8UC3, Scalar.Blue))
            {
                Cv2.ImWrite(path, mat);
            }
            Assert.True(File.Exists(path), $"File '{path}' not found");

            Assert.True(Cv2.HaveImageReader(path));
        }
        finally
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {
                testOutputHelper.WriteLine(ex.ToString());
            }
        }
    }

    [Fact]
    public void HaveImageReaderJapanese()
    {
        testOutputHelper.WriteLine($"CurrentCulture: {Thread.CurrentThread.CurrentCulture.Name}");
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
            Thread.CurrentThread.CurrentCulture.Name != "ja-JP")
        {
            testOutputHelper.WriteLine($"Skip {nameof(ImWriteJapaneseFileName)}");
            return;
        }

        var path = Path.Combine("_data", "image", "haveImageReader_にほんご日本語.png");

        try
        {
            CreateDummyImageFile(path);
            Assert.True(Cv2.HaveImageReader(path));
        }
        finally
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {
                testOutputHelper.WriteLine(ex.ToString());
            }
        }
    }

    [Fact]
    public void HaveImageReaderUnicode()
    {
        var path = Path.Combine("_data", "image", "haveImageReader_♥♡😀😄.png");

        try
        {
            CreateDummyImageFile(path);

            // Unicode (incl. non-ANSI) paths now work on every platform (native probes via a wide
            // path on Windows; formerly unsupported there, opencv #4242).
            Assert.True(Cv2.HaveImageReader(path));
        }
        finally
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {
                testOutputHelper.WriteLine(ex.ToString());
            }
        }
    }

    [Theory]
    [InlineData("foo.png")]
    [InlineData("bar.jpg")]
    [InlineData("baz.bmp")]
    public void HaveImageWriter(string fileName) 
        => Assert.True(Cv2.HaveImageWriter(fileName));

    // TODO
    [Fact(Skip = "AccessViolationException")]
    public void HaveImageWriterJapanese()
    {
        // TODO: Fails on AppVeyor (probably this test succeeds only on Japanese Windows)
        testOutputHelper.WriteLine($"CurrentCulture: {Thread.CurrentThread.CurrentCulture.Name}");
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
            Thread.CurrentThread.CurrentCulture.Name != "ja-JP")
        {
            testOutputHelper.WriteLine($"Skip {nameof(ImWriteJapaneseFileName)}");
            return;
        }

        // This file does not have to exist
        const string fileName = "にほんご日本語.png";

        Assert.True(Cv2.HaveImageWriter(fileName));
    }

    // TODO
    [Fact(Skip = "Only runs on Windows", SkipUnless = nameof(IsWindows))]
    public void HaveImageWriterUnicode()
    {
        // This file does not have to exist
        const string fileName = "♥♡😀😄.png";

        // HaveImageWriter only inspects the file extension, which survives ANSI marshalling intact,
        // so it reports the writer as available even though the Unicode base name is mangled.
        Assert.True(Cv2.HaveImageWriter(fileName));
    }

    [Theory]
    [InlineData(".png")]
    [InlineData(".jpg")]
    [InlineData(".tif")]
    [InlineData(".bmp")]
    public void ImEncode(string ext)
    {
        using var mat = LoadImage("lenna.png", ImreadModes.Grayscale);
        Assert.False(mat.Empty());

        Cv2.ImEncode(ext, mat, out var imageData);
        Assert.NotNull(imageData);

        // Can ImageSharp decode the imageData?
        using var image = Image.Load(imageData);
        Assert.Equal(mat.Rows, image.Height);
        Assert.Equal(mat.Cols, image.Width);
    }

    [Theory]
    [InlineData("Png")]
    [InlineData("Jpeg")]
    [InlineData("Tiff")]
    [InlineData("Bmp")]
    public void ImDecode(string imageFormatName)
    {
        IImageEncoder encoder = imageFormatName switch
        {
            "Png" => new PngEncoder(),
            "Jpeg" => new JpegEncoder(),
            "Tiff" => new TiffEncoder(),
            "Bmp" => new BmpEncoder(),
            _ => throw new ArgumentOutOfRangeException(nameof(imageFormatName), imageFormatName, null)
        };

        using var image = Image.Load("_data/image/mandrill.png");
        using var stream = new MemoryStream();
        image.Save(stream, encoder);
        var imageData = stream.ToArray();
        Assert.NotNull(imageData);

        using var mat = Cv2.ImDecode(imageData, ImreadModes.Color);
        Assert.NotNull(mat);
        Assert.False(mat.Empty());
        Assert.Equal(image.Width, mat.Cols);
        Assert.Equal(image.Height, mat.Rows);

        ShowImagesWhenDebugMode(mat);
    }

    [Fact]
    public void ImDecodeSpan()
    {
        var imageBytes = File.ReadAllBytes("_data/image/mandrill.png");
        Assert.NotEmpty(imageBytes);

        // whole range
        {
            var span = imageBytes.AsSpan();
            using var mat = Cv2.ImDecode(span, ImreadModes.Color);
            Assert.NotNull(mat);
            Assert.False(mat.Empty());
            ShowImagesWhenDebugMode(mat);
        }

        // slice
        {
            var dummyBytes = Enumerable.Repeat((byte)123, 100).ToArray();
            var imageBytesWithDummy = dummyBytes.Concat(imageBytes).Concat(dummyBytes).ToArray();

#if NET48
            var span = imageBytesWithDummy.AsSpan(100, imageBytes.Length);
#else
            var span = imageBytesWithDummy.AsSpan()[100..^100];
#endif
            using var mat = Cv2.ImDecode(span, ImreadModes.Color);
            Assert.NotNull(mat);
            Assert.False(mat.Empty());
            ShowImagesWhenDebugMode(mat);
        }
    }

    [Fact]
    public void WriteMultiPagesTiff()
    {
        string[] files = [
            "multipage_p1.tif",
            "multipage_p2.tif",
        ];

        Mat[]? pages = null;
        Mat[]? readPages = null;
        try
        {
            pages = files.Select(f => LoadImage(f)).ToArray();

            Assert.True(Cv2.ImWrite("multi.tiff", pages), "imwrite failed");
            Assert.True(Cv2.ImReadMulti("multi.tiff", out readPages), "imreadmulti failed");
            Assert.NotEmpty(readPages);
            Assert.Equal(pages.Length, readPages.Length);

            for (var i = 0; i < pages.Length; i++)
            {
                ImageEquals(pages[i], readPages[i]);
            }

        }
        finally
        {
            if (pages is not null)
                foreach (var page in pages)
                    page.Dispose();
            if (readPages is not null)
                foreach (var page in readPages)
                    page.Dispose();
        }
    }

    private static void CreateDummyImageFile(string path)
    {
        _ = Path.GetFullPath(path);

        var tempFileName = Path.GetTempFileName();
        {
            
            using var image = new Image<Bgr24>(10, 10);
            image.Mutate(x =>
            {
                x.Fill(Color.Red);
            });
            image.SaveAsPng(tempFileName);
        }

#if NET48
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        File.Move(tempFileName, path);
#else
        File.Move(tempFileName, path, true);
#endif
        Assert.True(File.Exists(path), $"File '{path}' not found");
    }
}
