# Migrating from OpenCvSharp4 to OpenCvSharp5

OpenCvSharp5 wraps **OpenCV 5.x** and is published as a new package family
(`OpenCvSharp5.*`) alongside the existing **OpenCvSharp4** family
(`OpenCvSharp4.*`, OpenCV 4.13.0). OpenCvSharp4 continues as a maintenance line,
so you are not forced to migrate — but if you want OpenCV 5 features you will
move to OpenCvSharp5 and the changes below apply.

> **Status:** living document. The "OpenCV 5 API changes" section is filled in
> as modules are ported. See the OpenCV 5 tracking issue for current progress.

## 1. Target frameworks

The OpenCvSharp5 managed libraries target **.NET 8+ only**. Support for
.NET Standard 2.0 / 2.1 and .NET Framework (net48) has been dropped.

- `OpenCvSharp5`, `OpenCvSharp5.GdipExtensions`: `net8.0`
- `OpenCvSharp5.WpfExtensions`: `net8.0-windows` (net48 dropped)

If you need **.NET Framework, Unity, or another pre-.NET 8 runtime**, stay on the
`OpenCvSharp4` family, which keeps the netstandard2.0 / net48 targets.

## 2. Package and namespace renames

### GDI+ extensions: `Extensions` → `GdipExtensions`

The old `OpenCvSharp.Extensions` package mixed dependency-free helpers with
GDI+ (System.Drawing) interop. It has been split:

| Before (OpenCvSharp4) | After (OpenCvSharp5) |
|---|---|
| package `OpenCvSharp4.Extensions` | package `OpenCvSharp5.GdipExtensions` |
| `using OpenCvSharp.Extensions;` (for `BitmapConverter`) | `using OpenCvSharp.GdipExtensions;` |

`BitmapConverter` (System.Drawing.Bitmap ⇄ Mat) now lives in
`OpenCvSharp5.GdipExtensions`, namespace `OpenCvSharp.GdipExtensions`.

### `CvExtensions` moved into core

`CvExtensions` (the `Mat.HoughLinesProbabilisticEx` extension) moved into the
core **`OpenCvSharp`** package. Its namespace is unchanged
(`OpenCvSharp.Extensions`), so existing `using OpenCvSharp.Extensions;` keeps
working — but you no longer need a separate extensions package for it.

## 3. Removed APIs

These wrap OpenCV functions that were removed in OpenCV 5 (no replacement), so
the managed methods are gone too:

| Removed | Notes / replacement |
|---|---|
| `OpenCvSharp.Extensions.Binarizer` (Niblack/Sauvola/Bernsen/Nick/…) | Use `CvXImgProc.NiblackThreshold` (Niblack / Sauvola / Wolf / Nick) |
| `CvDnn.ReadNetFromDarknet`, `CvDnn.ReadNetFromCaffe`, `CvDnn.ReadNetFromTorch`, `CvDnn.ReadTorchBlob`, `CvDnn.ShrinkCaffeModel` (and the `Net.*` equivalents) | Darknet/Caffe/Torch parsers removed — export to ONNX and use `CvDnn.ReadNetFromONNX` |
| `Net.SetHalideScheduler` | Halide backend removed |
| `Cv2.ConvertFp16` | Use `Mat.ConvertTo` to/from `MatType.CV_16F` |
| `Cv2.LogPolar`, `Cv2.LinearPolar` | Use `Cv2.WarpPolar` (`WarpPolarMode.Linear` / `Log`) |
| `Window.GetHandle()`, `Cv2.GetWindowHandle` | Legacy C API removed; no replacement |
| `TrackerGOTURN` | Removed from OpenCV 5 |

## 3a. Changed signatures

Caffe model support was dropped; these constructors now take ONNX model paths:

| Before (OpenCvSharp4) | After (OpenCvSharp5) |
|---|---|
| `new BarcodeDetector(superResolutionPrototxtPath, superResolutionCaffeModelPath)` | `new BarcodeDetector(superResolutionModelPath = "")` |
| `new WeChatQRCode(detectorPrototxt, detectorCaffe, srPrototxt, srCaffe)` | `new WeChatQRCode(detectorModelPath = "", superResolutionModelPath = "")` |

## 4. OpenCV 5 API changes surfaced through the wrapper

OpenCV 5 reorganizes modules and changes some APIs. The managed surface follows
the C++ structure where reasonable, while the `Cv2` facade is kept
source-compatible where possible. This section is updated as modules are ported.

- **Module reorganization** (C++ side): `calib3d` split into
  `calib` / `stereo` / `geometry` / `ptcloud`; `features2d` renamed to
  `features`; `ml`, `gapi`, and the Haar `CascadeClassifier` / `HOGDescriptor`
  moved to `opencv_contrib`.
- **New `MatType` depth types**: `CV_16BF` (bfloat16), `CV_32U`, `CV_64U`,
  `CV_64S`, `CV_Bool`.
- **DNN**: a new default inference engine; the Darknet and Caffe model readers
  were removed — convert models to ONNX and use `Net.ReadNetFromONNX`.
- **Behavioral differences**: `Resize` with `INTER_NEAREST` now matches Pillow;
  `WarpAffine` / `WarpPerspective` / `Remap` interpolation produces slightly
  different numeric output; the legacy `HersheyFonts` text rendering changed and
  a new `FontFace` text API is available.

_(Detailed managed signature changes will be added here per module as the port
lands.)_
