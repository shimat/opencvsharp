# Your First Application

This example reads an image, converts it to grayscale, and saves the result. It does not open a native window, so it also works with the Linux headless runtime package.

## Prepare an input image

Place a JPEG or PNG image named `input.jpg` in the project directory. Configure it to be copied to the output directory by adding the following item to the project file:

```xml
<ItemGroup>
  <None Update="input.jpg" CopyToOutputDirectory="PreserveNewest" />
</ItemGroup>
```

## Add the code

Replace `Program.cs` with:

```csharp
using OpenCvSharp;

using var source = Cv2.ImRead("input.jpg", ImreadModes.Color);
if (source.Empty())
{
    throw new InvalidOperationException("Could not read input.jpg.");
}

using var grayscale = new Mat();
Cv2.CvtColor(source, grayscale, ColorConversionCodes.BGR2GRAY);

if (!Cv2.ImWrite("output.png", grayscale))
{
    throw new InvalidOperationException("Could not write output.png.");
}

Console.WriteLine($"Created output.png ({grayscale.Width} x {grayscale.Height}).");
```

## Run the application

```bash
dotnet run
```

The application creates `output.png` in its working directory.

## What the code does

- `Cv2.ImRead` decodes the input file into a `Mat`.
- `source.Empty()` detects a missing or unsupported input image.
- `Cv2.CvtColor` converts the image from OpenCV's default BGR channel order to grayscale.
- `Cv2.ImWrite` selects an encoder from the output file extension and writes the image.
- The `using` declarations release the native memory owned by both `Mat` instances.

OpenCvSharp objects that own native resources must be disposed. Read [Resource Management](../guides/resource-management.md) before building a long-running application.

## Next steps

- Browse the [OpenCvSharp API reference](xref:OpenCvSharp).
- Explore the [OpenCvSharp sample projects](https://github.com/shimat/opencvsharp_samples).
- Check [Native Library Loading](../troubleshooting/native-library-loading.md) if the application builds but fails at run time.
