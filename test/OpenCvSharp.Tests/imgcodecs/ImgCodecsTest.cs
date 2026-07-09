using System.Runtime.InteropServices;
using BitMiracle.LibTiff.Classic;
using SkiaSharp;
using Xunit;

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
            using var bitmap = new SKBitmap(10, 10);
            bitmap.Erase(SKColors.Red);
            using var image = SKImage.FromBitmap(bitmap);
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            using var fs = File.Create(fileName);
            data.SaveTo(fs);
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

        var (width, height) = IdentifyImage(fileName);
        Assert.Equal(10, height);
        Assert.Equal(20, width);
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

        var (width, height) = IdentifyImage(fileName);
        Assert.Equal(10, height);
        Assert.Equal(20, width);
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
        var (width, height) = IdentifyImage(asciiFileName);

        Assert.Equal(10, height);
        Assert.Equal(20, width);
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

        // Can an independent decoder read the imageData?
        var (width, height) = IdentifyImageBytes(imageData, ext);
        Assert.Equal(mat.Rows, height);
        Assert.Equal(mat.Cols, width);
    }

    [Theory]
    [InlineData("Png")]
    [InlineData("Jpeg")]
    [InlineData("Tiff")]
    [InlineData("Bmp")]
    public void ImDecode(string imageFormatName)
    {
        // Tiff/Bmp: SkiaSharp cannot encode these formats, so we use pre-generated fixture
        // files (produced once from mandrill.png by an independent encoder) instead.
        var imageData = imageFormatName switch
        {
            "Png" => EncodeWithSkia("_data/image/mandrill.png", SKEncodedImageFormat.Png),
            "Jpeg" => EncodeWithSkia("_data/image/mandrill.png", SKEncodedImageFormat.Jpeg),
            "Tiff" => File.ReadAllBytes("_data/image/mandrill.tif"),
            "Bmp" => File.ReadAllBytes("_data/image/mandrill.bmp"),
            _ => throw new ArgumentOutOfRangeException(nameof(imageFormatName), imageFormatName, null)
        };
        Assert.NotNull(imageData);

        using var codec = SKCodec.Create("_data/image/mandrill.png");
        var referenceWidth = codec.Info.Width;
        var referenceHeight = codec.Info.Height;

        using var mat = Cv2.ImDecode(imageData, ImreadModes.Color);
        Assert.NotNull(mat);
        Assert.False(mat.Empty());
        Assert.Equal(referenceWidth, mat.Cols);
        Assert.Equal(referenceHeight, mat.Rows);

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

    [Fact]
    public void ImCountMultiPageTiff()
    {
        string[] files = ["multipage_p1.tif", "multipage_p2.tif"];
        const string tiffPath = "imcount_multi.tiff";
        try
        {
            using var pages = new VectorOfMatForTest(files.Select(f => LoadImage(f)));
            Assert.True(Cv2.ImWrite(tiffPath, pages.Mats));

            Assert.Equal(2L, Cv2.ImCount(tiffPath));
        }
        finally
        {
            if (File.Exists(tiffPath)) File.Delete(tiffPath);
        }
    }

    [Fact]
    public void ImCountSinglePage()
    {
        Assert.Equal(1L, Cv2.ImCount("_data/image/lenna.png"));
    }

    [Fact]
    public void ImReadMultiRange()
    {
        string[] files = ["multipage_p1.tif", "multipage_p2.tif"];
        const string tiffPath = "imreadmulti_range.tiff";
        try
        {
            using var pages = new VectorOfMatForTest(files.Select(f => LoadImage(f)));
            Assert.True(Cv2.ImWrite(tiffPath, pages.Mats));

            Assert.True(Cv2.ImReadMulti(tiffPath, out var readPages, 1, 1));
            try
            {
                Assert.Single(readPages);
                ImageEquals(pages.Mats[1], readPages[0]);
            }
            finally
            {
                foreach (var p in readPages) p.Dispose();
            }
        }
        finally
        {
            if (File.Exists(tiffPath)) File.Delete(tiffPath);
        }
    }

    [Fact]
    public void ImEncodeMultiAndImDecodeMulti()
    {
        string[] files = ["multipage_p1.tif", "multipage_p2.tif"];
        using var pages = new VectorOfMatForTest(files.Select(f => LoadImage(f)));

        Assert.True(Cv2.ImEncodeMulti(".tiff", pages.Mats, out var buf));
        Assert.NotEmpty(buf);

        using var bufMat = new Mat(1, buf.Length, MatType.CV_8UC1);
        bufMat.SetArray(buf);
        Assert.True(Cv2.ImDecodeMulti(bufMat, ImreadModes.AnyColor, out var decoded));
        try
        {
            Assert.Equal(pages.Mats.Length, decoded.Length);
            for (var i = 0; i < decoded.Length; i++)
                ImageEquals(pages.Mats[i], decoded[i]);
        }
        finally
        {
            foreach (var m in decoded) m.Dispose();
        }
    }

    [Fact]
    public void ImDecodeMultiRange()
    {
        string[] files = ["multipage_p1.tif", "multipage_p2.tif"];
        using var pages = new VectorOfMatForTest(files.Select(f => LoadImage(f)));

        Assert.True(Cv2.ImEncodeMulti(".tiff", pages.Mats, out var buf));

        using var bufMat = new Mat(1, buf.Length, MatType.CV_8UC1);
        bufMat.SetArray(buf);
        Assert.True(Cv2.ImDecodeMulti(bufMat, ImreadModes.AnyColor, out var decoded, new Range(1, 2)));
        try
        {
            Assert.Single(decoded);
            ImageEquals(pages.Mats[1], decoded[0]);
        }
        finally
        {
            foreach (var m in decoded) m.Dispose();
        }
    }

    [Fact]
    public void ImWriteReadWithMetadataRoundTrip()
    {
        const string fileName = "test_imwrite_metadata.jpg";
        try
        {
            using var mat = new Mat(10, 20, MatType.CV_8UC3, Scalar.Blue);
            var exifBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            using var exifMat = new Mat(1, exifBytes.Length, MatType.CV_8UC1);
            exifMat.SetArray(exifBytes);

            Assert.True(Cv2.ImWriteWithMetadata(
                fileName, mat, [ImageMetadataType.Exif], [exifMat]));
            Assert.True(File.Exists(fileName));

            using var read = Cv2.ImReadWithMetadata(
                fileName, out var metadataTypes, out var metadata, ImreadModes.Unchanged);
            try
            {
                Assert.False(read.Empty());
                Assert.Contains(ImageMetadataType.Exif, metadataTypes);
            }
            finally
            {
                foreach (var m in metadata) m.Dispose();
            }
        }
        finally
        {
            if (File.Exists(fileName)) File.Delete(fileName);
        }
    }

    [Fact]
    public void AnimationWriteReadRoundTrip()
    {
        const string fileName = "test_animation.gif";
        try
        {
            using var frame1 = new Mat(10, 20, MatType.CV_8UC3, Scalar.Red);
            using var frame2 = new Mat(10, 20, MatType.CV_8UC3, Scalar.Blue);

            using var written = new Animation(loopCount: 3)
            {
                Frames = [frame1, frame2],
                Durations = [100, 200]
            };
            Assert.Equal(3, written.LoopCount);
            Assert.Equal([100, 200], written.Durations);
            Assert.Equal(2, written.Frames.Length);

            Assert.True(Cv2.ImWriteAnimation(fileName, written));
            Assert.True(File.Exists(fileName));

            using var read = new Animation();
            Assert.True(Cv2.ImReadAnimation(fileName, read));
            try
            {
                Assert.Equal(2, read.Frames.Length);
                Assert.Equal(10, read.Frames[0].Rows);
                Assert.Equal(20, read.Frames[0].Cols);
            }
            finally
            {
                foreach (var f in read.Frames) f.Dispose();
            }
        }
        finally
        {
            if (File.Exists(fileName)) File.Delete(fileName);
        }
    }

    [Fact]
    public void AnimationEncodeDecodeRoundTrip()
    {
        using var frame1 = new Mat(8, 8, MatType.CV_8UC3, Scalar.Red);
        using var frame2 = new Mat(8, 8, MatType.CV_8UC3, Scalar.Green);

        using var written = new Animation
        {
            Frames = [frame1, frame2],
            Durations = [50, 50]
        };

        Assert.True(Cv2.ImEncodeAnimation(".gif", written, out var buf));
        Assert.NotEmpty(buf);

        using var bufMat = new Mat(1, buf.Length, MatType.CV_8UC1);
        bufMat.SetArray(buf);

        using var read = new Animation();
        Assert.True(Cv2.ImDecodeAnimation(bufMat, read));
        try
        {
            Assert.Equal(2, read.Frames.Length);
        }
        finally
        {
            foreach (var f in read.Frames) f.Dispose();
        }
    }

    [Fact]
    public void ImageCollectionReadsPagesLazily()
    {
        string[] files = ["multipage_p1.tif", "multipage_p2.tif"];
        const string tiffPath = "imagecollection_multi.tiff";
        try
        {
            using var pages = new VectorOfMatForTest(files.Select(f => LoadImage(f)));
            Assert.True(Cv2.ImWrite(tiffPath, pages.Mats));

            using var collection = new ImageCollection(tiffPath);
            Assert.Equal(2L, collection.Size);

            using (var page0 = collection[0])
            {
                Assert.False(page0.Empty());
                ImageEquals(pages.Mats[0], page0);
            }
            using (var page1 = collection.At(1))
            {
                Assert.False(page1.Empty());
                ImageEquals(pages.Mats[1], page1);
            }

            collection.ReleaseCache(0);

            var count = 0;
            foreach (var page in collection)
            {
                using (page)
                {
                    Assert.False(page.Empty());
                }
                count++;
            }
            Assert.Equal(2, count);
        }
        finally
        {
            if (File.Exists(tiffPath)) File.Delete(tiffPath);
        }
    }

    // Small helper to keep a VectorOfMat's backing Mat[] alive alongside the test Mats.
    private sealed class VectorOfMatForTest : IDisposable
    {
        public Mat[] Mats { get; }

        public VectorOfMatForTest(IEnumerable<Mat> mats) => Mats = mats.ToArray();

        public void Dispose()
        {
            foreach (var m in Mats) m.Dispose();
        }
    }

    private static void CreateDummyImageFile(string path)
    {
        _ = Path.GetFullPath(path);

        var tempFileName = Path.GetTempFileName();
        {
            using var bitmap = new SKBitmap(10, 10);
            bitmap.Erase(SKColors.Red);
            using var image = SKImage.FromBitmap(bitmap);
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            using (var fs = File.Create(tempFileName))
            {
                data.SaveTo(fs);
            }
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

    private static byte[] EncodeWithSkia(string path, SKEncodedImageFormat format)
    {
        using var bitmap = SKBitmap.Decode(path) ?? throw new InvalidOperationException($"Cannot decode '{path}'");
        using var image = SKImage.FromBitmap(bitmap);
        using var data = image.Encode(format, 100);
        return data.ToArray();
    }

    // Reads only Width/Height metadata via an independent decoder (SkiaSharp for
    // png/jpg/bmp, LibTiff.NET for tiff, since SkiaSharp does not support tiff).
    private static bool IsTiffExtension(string ext) =>
        ext.Equals(".tif", StringComparison.OrdinalIgnoreCase) || ext.Equals(".tiff", StringComparison.OrdinalIgnoreCase);

    private static (int Width, int Height) IdentifyImage(string path)
    {
        if (IsTiffExtension(Path.GetExtension(path)))
        {
            using var tiff = Tiff.Open(path, "r") ?? throw new InvalidOperationException($"Cannot open '{path}'");
            return (tiff.GetField(TiffTag.IMAGEWIDTH)[0].ToInt(), tiff.GetField(TiffTag.IMAGELENGTH)[0].ToInt());
        }

        using var codec = SKCodec.Create(path);
        return (codec.Info.Width, codec.Info.Height);
    }

    private static (int Width, int Height) IdentifyImageBytes(byte[] data, string ext)
    {
        if (IsTiffExtension(ext))
        {
            using var ms = new MemoryStream(data);
            using var tiff = Tiff.ClientOpen("in-memory", "r", ms, new ReadOnlyTiffStream())
                ?? throw new InvalidOperationException("Cannot open TIFF byte data");
            return (tiff.GetField(TiffTag.IMAGEWIDTH)[0].ToInt(), tiff.GetField(TiffTag.IMAGELENGTH)[0].ToInt());
        }

        using var memoryStream = new SKMemoryStream(data);
        using var codec = SKCodec.Create(memoryStream);
        return (codec.Info.Width, codec.Info.Height);
    }

    // Read-only adapter so LibTiff.NET can read TIFF data straight from a MemoryStream.
    private sealed class ReadOnlyTiffStream : TiffStream
    {
        public override int Read(object clientData, byte[] buffer, int offset, int count)
            => ((Stream)clientData).Read(buffer, offset, count);

        public override long Seek(object clientData, long offset, SeekOrigin origin)
            => ((Stream)clientData).Seek(offset, origin);

        public override void Close(object clientData)
        {
            // The caller owns the underlying stream's lifetime.
        }

        public override long Size(object clientData) => ((Stream)clientData).Length;
    }
}
