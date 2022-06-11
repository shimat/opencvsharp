using Xunit;
using OpenCvSharp.AvaloniaExtensions;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace OpenCvSharp.AvaloniaExtensionsTest
{
    public class WriteableBitmapConverterTests
    {
        [Fact]
        public void TestConversion()
        {
            new WriteableBitmap(new Avalonia.PixelSize(20, 20), new Avalonia.Vector(96,96));

            using Mat abbeyRoad = new("_data/image/abbey_road.jpg");

            WriteableBitmap wbmp = abbeyRoad.ToWriteableBitmap(AlphaFormat.Unpremul);

            wbmp.Save("_data/image/abbey_road_wbmp.jpg");
        }
    }
}