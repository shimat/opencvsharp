using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Xunit;

namespace OpenCvSharp.Tests.Windows;

public class BitmapSourceConverterTest : OpenCvSharp.Tests.TestBase
{
    [Fact]
    public void BitmapSource8Bit()
    {
        var blueColor8 = new Scalar(200, 0, 0);
        var greenColor8 = new Scalar(0, 200, 0);
        var redColor8 = new Scalar(0, 0, 200);

        using (var mat = new Mat(1, 1, MatType.CV_8UC3, blueColor8))
        {
            var bs = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(mat); // PixelFormats.Bgr24
            AssertPixelValue<byte>(blueColor8, bs);
        }
        using (var mat = new Mat(1, 1, MatType.CV_8UC3, greenColor8))
        {
            var bs = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(mat);
            AssertPixelValue<byte>(greenColor8, bs);
        }
        using (var mat = new Mat(1, 1, MatType.CV_8UC3, redColor8))
        {
            var bs = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(mat);
            AssertPixelValue<byte>(redColor8, bs);
        }
    }

    [Fact]
    public void BitmapSource16Bit()
    {
        var blueColor16 = new Scalar(32767, 0, 0);
        var greenColor16 = new Scalar(0, 32767, 0);
        var redColor16 = new Scalar(0, 0, 32767);

        using (var mat = new Mat(1, 1, MatType.CV_16UC3, blueColor16))
        {
            var bs = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(mat); // PixelFormats.Rgb48
            AssertPixelValue<ushort>(redColor16, bs); // B is swapped for R
        }
        using (var mat = new Mat(1, 1, MatType.CV_16UC3, greenColor16))
        {
            var bs = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(mat);
            AssertPixelValue<ushort>(greenColor16, bs);
        }
        using (var mat = new Mat(1, 1, MatType.CV_16UC3, redColor16))
        {
            var bs = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(mat);
            AssertPixelValue<ushort>(blueColor16, bs); // R is swapped for B
        }
    }

    [Fact]
    public void BitmapSourceCanBeHostedInWpfWindow()
    {
        RunInStaThread(() =>
        {
            using var mat = new Mat(1, 1, MatType.CV_16UC3, new Scalar(32767, 0, 0));
            var source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(mat);
            var window = new System.Windows.Window
            {
                Content = new Image { Source = source },
                Width = 1,
                Height = 1,
                Left = -10000,
                Top = -10000,
                ShowActivated = false,
                ShowInTaskbar = false,
                WindowStyle = System.Windows.WindowStyle.None,
            };

            try
            {
                window.Show();
                Assert.True(window.IsVisible);
            }
            finally
            {
                if (window.IsVisible)
                    window.Close();
            }

            Assert.False(window.IsVisible);
        });
    }

    private static void AssertPixelValue<T>(Scalar expectedValue, BitmapSource bs)
        where T : unmanaged
    {
        if (bs.PixelWidth != 1 || bs.PixelHeight != 1)
            throw new ArgumentException("1x1 image only");

        var pixels = new T[3];
        int stride = 4 * Marshal.SizeOf<T>();
        bs.CopyPixels(Int32Rect.Empty, pixels, stride, 0);

        Console.WriteLine("Expected: ({0},{1},{2})", expectedValue.Val0, expectedValue.Val1, expectedValue.Val2);
        Console.WriteLine("Actual: ({0},{1},{2})", pixels[0], pixels[1], pixels[2]);
        Assert.Equal(expectedValue.Val0, Convert.ToDouble(pixels[0], CultureInfo.InvariantCulture), 9);
        Assert.Equal(expectedValue.Val1, Convert.ToDouble(pixels[1], CultureInfo.InvariantCulture), 9);
        Assert.Equal(expectedValue.Val2, Convert.ToDouble(pixels[2], CultureInfo.InvariantCulture), 9);
    }

    private static void RunInStaThread(Action action)
    {
        ExceptionDispatchInfo? failure = null;
        var thread = new Thread(() =>
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                failure = ExceptionDispatchInfo.Capture(ex);
            }
        })
        {
            IsBackground = true,
        };

        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();

        Assert.True(
            thread.Join(TimeSpan.FromSeconds(10)),
            "The STA test thread did not finish within the timeout.");
        failure?.Throw();
    }
}
