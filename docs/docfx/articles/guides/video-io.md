# Video I/O

`VideoCapture` reads frames from video files, cameras, image sequences, and streams supported by the selected OpenCV backend. `VideoWriter` encodes a sequence of matrices into a video file.

The full and headless Linux runtime packages include `videoio`. The slim runtime packages do not. Windows ARM64 runtime packages do not include FFmpeg-based video I/O.

## Read a video file

```csharp
using var capture = new VideoCapture("input.mp4");
if (!capture.IsOpened())
{
    throw new IOException("Could not open input.mp4.");
}

using var frame = new Mat();
while (capture.Read(frame))
{
    if (frame.Empty())
    {
        break;
    }

    Console.WriteLine($"Frame {capture.PosFrames}: {frame.Width} x {frame.Height}");
    // Process frame here. Do not retain it after the next Read call unless you clone it.
}
```

The same `Mat` is reused for every frame. Call `frame.Clone()` when a frame must outlive the next `Read`.

Properties such as `Fps`, `FrameCount`, and `PosFrames` depend on the backend and input. A backend may report zero or an approximate value when the information is unavailable.

## Open a camera

```csharp
using var capture = new VideoCapture(0);
if (!capture.IsOpened())
{
    throw new IOException("Could not open camera 0.");
}

capture.FrameWidth = 1280;
capture.FrameHeight = 720;

using var frame = new Mat();
while (capture.Read(frame) && !frame.Empty())
{
    // Process or display the frame.
}
```

Device index `0` selects the first camera. Camera properties are requests to the backend and device; read the property again when the exact negotiated value matters.

An application can request a backend explicitly, for example `VideoCaptureAPIs.DSHOW` on Windows or `VideoCaptureAPIs.V4L2` on Linux, but the default automatic selection is more portable.

## Write a video

The following example copies frames to an MJPEG AVI file:

```csharp
using var capture = new VideoCapture("input.mp4");
if (!capture.IsOpened())
{
    throw new IOException("Could not open input.mp4.");
}

using var frame = new Mat();
if (!capture.Read(frame) || frame.Empty())
{
    throw new IOException("Could not read the first frame.");
}

double fps = capture.Fps > 0 ? capture.Fps : 30;
var frameSize = new Size(frame.Width, frame.Height);
int fourcc = VideoWriter.FourCC('M', 'J', 'P', 'G');

using var writer = new VideoWriter("output.avi", fourcc, fps, frameSize);
if (!writer.IsOpened())
{
    throw new IOException("Could not open output.avi.");
}

writer.Write(frame);
while (capture.Read(frame) && !frame.Empty())
{
    writer.Write(frame);
}
```

Every frame passed to a writer must have the configured size and a compatible channel layout. Resize or convert frames before calling `Write` when necessary. Set `isColor: false` in the `VideoWriter` constructor when writing single-channel frames.

Codec availability depends on the operating system, OpenCV build, backend, and output container. `VideoWriter.FourCC` creates the four-character codec identifier, but it does not install an encoder.

## Displaying frames

`Cv2.ImShow` and `Cv2.WaitKey` require `highgui` and a graphical environment. They are unavailable in the Linux headless and slim runtime packages. Services should process, encode, or stream frames without creating native windows.

## Official OpenCV references

- [OpenCV Video I/O](https://docs.opencv.org/5.0/main_modules/videoio.html)
- [OpenCV application utilities](https://docs.opencv.org/5.0/tutorials/application_utils/application_utils.html)

## Related API

- [VideoCapture](xref:OpenCvSharp.VideoCapture)
- [VideoWriter](xref:OpenCvSharp.VideoWriter)
- [VideoCaptureAPIs](xref:OpenCvSharp.VideoCaptureAPIs)
