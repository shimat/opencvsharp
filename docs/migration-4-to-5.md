# Migrating from OpenCvSharp4 to OpenCvSharp5

OpenCvSharp5 wraps **OpenCV 5.x** and is published as a new package family (`OpenCvSharp5.*`) alongside the existing **OpenCvSharp4** family (`OpenCvSharp4.*`, OpenCV 4.13.0). OpenCvSharp4 continues as a maintenance line, so you are not forced to migrate — but if you want OpenCV 5 features you will move to OpenCvSharp5 and the changes below apply.

> **Status:** living document. The "OpenCV 5 API changes" section is filled in as modules are ported. See the OpenCV 5 tracking issue for current progress.

## Why so many changes?

The single biggest decision behind OpenCvSharp5 is dropping every target framework except **`net8.0`** (see [§1](#1-target-frameworks)). OpenCvSharp4 has to support .NET Framework 4.6.1, .NET Standard 2.0/2.1, and modern .NET all at once, which rules out a lot of runtime and language surface added since C# 8 — `ref struct`s with relaxed rules, source-generated P/Invoke (`[LibraryImport]`), `SafeHandle`-first ownership, and so on. Once OpenCvSharp5 could assume .NET 8+, most of the rest of the redesign followed from that one decision:

- **`InputArray`/`OutputArray`/`InputOutputArray` became `ref struct`s** (§2). In OpenCvSharp4, every implicit conversion (e.g. `Cv2.Foo(mat, dst)`) allocated a disposable native wrapper object; because the conversion is *implicit*, there is nowhere natural to put a `using`, so these objects routinely leaked until the finalizer eventually ran. The `ref struct` version carries only a handle and a kind tag, lives on the stack, and has nothing to dispose in the first place.
- **`Mat` arithmetic (`MatExpr`) became a lazy, purely-managed expression tree** (§2). Chained operators like `255 - mat * 0.8` used to allocate a native `cv::MatExpr` at *every* operator call; OpenCvSharp4 even shipped a dedicated `ResourcesTracker` helper class so users could track and dispose those anonymous intermediates by hand. OpenCvSharp5 builds the whole expression in managed memory and only touches native code once, when the expression is finally materialized into a `Mat` — `ResourcesTracker` is gone because there is nothing left for it to track.
- **P/Invoke moved from `[DllImport]` to source-generated `[LibraryImport]`**, and most wrapper types now own their native handle through a `SafeHandle` instead of manual `GC.KeepAlive` calls scattered through the codebase. This is invisible from the C# call-site surface almost everywhere, but it is why a few previously `IDisposable`/`CvObject`-based helper types (e.g. `FacemarkAAM.Params`, §6) turned into plain POCOs — they no longer own a native handle that needs managing.
- **The managed API follows the OpenCV 5 / Python `cv2` module layout more closely.** Free-function facades like `CvDnn`/`CvAruco` became nested `Cv2.Dnn`/`Cv2.Aruco` classes (§4), and C# namespaces track the upstream module reorganization (`features2d` → `features`, `calib3d` split into `calib`/`stereo`/`geometry`/`ptcloud`, etc., §7).

None of this is change for its own sake — every item above is either a direct consequence of raising the minimum target framework, or a mechanical follow-through of an upstream OpenCV 5 change. But together they add up to a real one-time migration cost, bigger than a typical OpenCvSharp point release. The sections below are ordered roughly by how many call sites they are likely to touch, starting with the highest-impact ones.

## 1. Target frameworks

The OpenCvSharp5 managed libraries target **.NET 8+ only**. Support for .NET Standard 2.0 / 2.1 and .NET Framework (net48) has been dropped.

- `OpenCvSharp5`, `OpenCvSharp5.GdipExtensions`: `net8.0`
- `OpenCvSharp5.WpfExtensions`: `net8.0-windows` (net48 dropped)

If you need **.NET Framework, Unity, or another pre-.NET 8 runtime**, stay on the `OpenCvSharp4` family, which keeps the netstandard2.0 / net48 targets.

## 2. Resource-safety redesign: `InputArray`/`OutputArray` and `Mat` expressions

### `InputArray` / `OutputArray` / `InputOutputArray` are now `ref struct`s

In OpenCvSharp4, `InputArray`/`OutputArray`/`InputOutputArray` were ordinary classes wrapping a native `cv::_InputArray`/`_OutputArray`/`_InputOutputArray` handle (`public class InputArray : CvObject`, heap-allocated, `IDisposable` via the `CvObject` base). Every implicit conversion from `Mat`/`Scalar`/`double`/a fixed-length `Vec`/... allocated one of these on the heap and built a matching native object underneath it.

In OpenCvSharp5 they are `readonly ref struct`s (issue #1976): a stack-only proxy carrying just a native handle and a kind tag (plus an inline payload for scalar/vector operands), built with **zero heap allocation** and requiring **no disposal at all** — see [`InputArray.cs`](../src/OpenCvSharp/Modules/core/InputArray.cs).

This is transparent at the overwhelming majority of call sites — `Cv2.Foo(mat, dst)` compiles completely unchanged — but a few patterns do break:

- **`null` no longer works for an optional array parameter — use `default`.** A `ref struct` can't be `null`, so any call site that passed a literal `null` for an optional mask/array argument now needs `default`:
  ```csharp
  // OpenCvSharp4
  sift.DetectAndCompute(gray, null, out var keypoints, descriptors);
  // OpenCvSharp5
  sift.DetectAndCompute(gray, default, out var keypoints, descriptors);
  ```
  The compiler error you'll get (`CS0037: cannot convert null to 'InputArray' because it's a non-nullable value type`) doesn't point at `default` as the fix, so it's worth knowing this in advance.
- **They can no longer be stored in a field, captured by a closure, or used across an `await`/`yield` boundary** (standard `ref struct` constraints). Build one at the call site instead of holding onto it; if you need the same array across several calls, keep the underlying `Mat`/`UMat` around and let the implicit conversion run again each time.
- **`OutputArray.Create(List<T>)` was removed.** OpenCvSharp4 let a `List<T>` act as a write-back output sink:
  ```csharp
  // OpenCvSharp4
  var output = new List<byte>();
  Cv2.Threshold(InputArray.Create(input), OutputArray.Create(output), t, max, ThresholdTypes.Binary);
  ```
  Use a `Mat` output and read the array back with `Mat.GetArray<T>(out T[])`:
  ```csharp
  // OpenCvSharp5
  using var output = new Mat();
  Cv2.Threshold(InputArray.Create(input), output, t, max, ThresholdTypes.Binary);
  output.GetArray(out byte[] outputArr);
  ```

### `Mat` arithmetic (`MatExpr`) is now a lazy, leak-free tree — no more `ResourcesTracker`

OpenCvSharp4's `Mat` arithmetic operators (`+`, `-`, `*`, `/`, `T()`, `Inv()`, ...) eagerly built a disposable `MatExpr` wrapping a native `cv::MatExpr` at *every* operator call. A chained expression like `255 - mat * 0.8` therefore produced multiple untracked native intermediates that a single `using` couldn't reach, so OpenCvSharp4 shipped a dedicated `ResourcesTracker` helper purely to track and dispose them:

```csharp
// OpenCvSharp4
using var t = new ResourcesTracker();
Mat dst = t.T(255 - t.T(src * 0.8));
```

In OpenCvSharp5, `Mat` arithmetic operators return a purely managed, lazily-evaluated `MatExpr` that holds **no** native resource — the expression tree is assembled entirely in managed memory, and the native `cv::MatExpr` chain is built (and immediately torn down) only once, when the expression is materialized into a `Mat`:

```csharp
// OpenCvSharp5
Mat dst = 255 - src * 0.8;
```

`ResourcesTracker` has been removed entirely — there is nothing left for it to track. Two follow-on effects:

- **`MatExpr` is no longer `IDisposable`.** Code that did `using var x = Mat.Zeros(...);` or `using var t = a * b;` now fails to compile (`CS1674: 'MatExpr': type used in a using statement must be implicitly convertible to 'System.IDisposable'`) — just drop the `using`. If your code declares the variable as `Mat` rather than `var` (e.g. `using (Mat img = Mat.Zeros(...))`), it still compiles and still needs disposal, because `MatExpr` has an implicit conversion to `Mat` that materializes it there.
- **Fixed-size ops like `Cross()` are unaffected** — they still return a concrete `Mat` directly, since OpenCV's `cross()` always produces one fixed-size result with no fusable expression node.

## 3. `Mat`'s fluent Cv2-wrapper instance methods were removed

`Mat` used to have a large family of instance methods (`mat.Circle(...)`, `mat.Line(...)`, `mat.Rectangle(...)`, `mat.PutText(...)`, `mat.CvtColor(...)`, `mat.Threshold(...)`, `mat.Resize(...)`, `mat.SaveImage(...)`, `mat.HoughCircles(...)`, `mat.MinEnclosingCircle(...)`, and many more — over 2,300 lines in `Mat_CvMethods.cs`) that existed purely so `Cv2` static methods could be called with chainable, fluent syntax. These have been **removed entirely**: the duplication doubled the maintenance surface of every `Cv2` method, and intermediate `Mat`s produced mid-chain couldn't be captured with `using`, leaking into non-deterministic GC-driven native cleanup — the same problem the `MatExpr` rework above solves for arithmetic operators.

This is likely the single most common break when porting existing OpenCvSharp4 code — more so than any of the renames in this guide — and the compile error gives no hint about what happened (`CS1061: 'Mat' does not contain a definition for 'Circle'`). The fix is mechanical: `mat.Xxx(args)` → `Cv2.Xxx(mat, args)` (insert the `Mat` as the first argument). Two subtleties:

- Methods that used to *return a new `Mat`* (`var gray = src.CvtColor(code);`, `var t = src.Threshold(...)`) need an explicit destination `Mat` created first:
  ```csharp
  // OpenCvSharp5
  using var gray = new Mat();
  Cv2.CvtColor(src, gray, code);
  ```
- `Mat.Resize(...)` collides with an unrelated, still-existing instance method — `Mat.Resize(int sz)` / `Mat.Resize(int sz, Scalar s)`, a `std::vector`-style row-count resize present since OpenCvSharp4. If you meant "resize this image" and get a "wrong number of arguments" error rather than "no such method", you want `Cv2.Resize(src, dst, size, fx, fy, interpolation)` — overload resolution won't suggest it for you.

## 4. Package and namespace renames

### GDI+ extensions: `Extensions` → `GdipExtensions`

The old `OpenCvSharp.Extensions` package mixed dependency-free helpers with GDI+ (System.Drawing) interop. It has been split:

| Before (OpenCvSharp4) | After (OpenCvSharp5) |
|---|---|
| package `OpenCvSharp4.Extensions` | package `OpenCvSharp5.GdipExtensions` |
| `using OpenCvSharp.Extensions;` (for `BitmapConverter`) | `using OpenCvSharp.GdipExtensions;` |

`BitmapConverter` (System.Drawing.Bitmap ⇄ Mat) now lives in `OpenCvSharp5.GdipExtensions`, namespace `OpenCvSharp.GdipExtensions`.

### `CvExtensions` moved into core

`CvExtensions` (the `Mat.HoughLinesProbabilisticEx` extension) moved into the core **`OpenCvSharp`** package. Its namespace is unchanged (`OpenCvSharp.Extensions`), so existing `using OpenCvSharp.Extensions;` keeps working — but you no longer need a separate extensions package for it.

### Sub-namespace free functions: `CvXxx` → `Cv2.Xxx`

The standalone free-function facade classes (`CvDnn`, `CvAruco`, …) have been replaced by **nested static classes under `Cv2`**, so the managed API mirrors the C++ sub-namespaces and the Python `cv2` submodules (`cv2.dnn.*`, `cv2.aruco.*`, …):

| Before (OpenCvSharp4) | After (OpenCvSharp5) | C++ namespace |
|---|---|---|
| `CvDnn.ReadNetFromOnnx` | `Cv2.Dnn.ReadNetFromONNX` | `cv::dnn` |
| `CvAruco.DetectMarkers` | `Cv2.Aruco.DetectMarkers` | `cv::aruco` |
| `CvXImgProc.NiblackThreshold` | `Cv2.XImgProc.NiblackThreshold` | `cv::ximgproc` |
| `CvXPhoto.Inpaint` | `Cv2.XPhoto.Inpaint` | `cv::xphoto` |
| `CvOptFlow.CalcOpticalFlowSF` | `Cv2.OptFlow.CalcOpticalFlowSF` | `cv::optflow` |
| `CvText.DetectTextSWT` | `Cv2.Text.DetectTextSWT` | `cv::text` |
| `CvDetail.ComputeImageFeatures` | `Cv2.Detail.ComputeImageFeatures` | `cv::detail` |
| `CvShape.CreateThinPlateSplineShapeTransformer` | `Cv2.CreateThinPlateSplineShapeTransformer` | `cv::` (no sub-namespace) |

The wrapper **types** (`Net`, `ArucoDetector`, the `ximgproc` filter classes, …) are unchanged and still live in their `OpenCvSharp.<Sub>` namespaces, so a typical call site only changes the static facade prefix:

```csharp
using OpenCvSharp.Dnn;                       // Net / Model types (unchanged)
var net = Cv2.Dnn.ReadNetFromONNX("m.onnx"); // was: CvDnn.ReadNetFromOnnx(...)
```

`CvShape` had no matching `cv::shape` sub-namespace (its members are `Create…` factories for types living directly in `cv::`), so it folds straight into `Cv2`. `CvExtensions` (the OpenCvSharp-specific `Mat` extension methods) is **not** part of this change and keeps its name and `OpenCvSharp.Extensions` namespace.

> **Aruco is more than a rename.** Beyond the `CvAruco.Xxx` → `Cv2.Aruco.Xxx` facade swap, `DetectMarkers` itself moved from a static one-shot call to an instance method on `ArucoDetector`, constructed once from a `Dictionary` + `DetectorParameters` + `RefineParameters` and then reused — mirroring the OpenCV 5 C++ API shape (`cv::aruco::ArucoDetector`):
> ```csharp
> // OpenCvSharp4
> CvAruco.DetectMarkers(image, dictionary, out corners, out ids, detectorParameters, out rejected);
>
> // OpenCvSharp5
> using var dictionary = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_1000);
> using var detector = new ArucoDetector(dictionary, detectorParameters, new RefineParameters());
> detector.DetectMarkers(image, out corners, out ids, out rejected);
> ```
> The `Aruco` *types* themselves (`ArucoDetector`, `Dictionary`, `DetectorParameters`) did not move — they are still in `OpenCvSharp.Aruco`, same as OpenCvSharp4.

### Feature detector and Bag-of-Words namespace churn

Following the OpenCV 5 `features2d`/`xfeatures2d` reshuffle, several detector and Bag-of-Words classes changed namespace:

| Class | Before (OpenCvSharp4) | After (OpenCvSharp5) |
|---|---|---|
| `SIFT` | `OpenCvSharp.Features2D` | `OpenCvSharp` (the `Features2D` namespace no longer exists) |
| `BRISK` | `OpenCvSharp` | `OpenCvSharp.XFeatures2D` |
| `KAZE` | `OpenCvSharp` | `OpenCvSharp.XFeatures2D` |
| `AKAZE` | `OpenCvSharp` | `OpenCvSharp.XFeatures2D` |
| `BOWTrainer` / `BOWKMeansTrainer` / `BOWImgDescriptorExtractor` | `OpenCvSharp` | `OpenCvSharp.XFeatures2D` |
| `SURF` | `OpenCvSharp.XFeatures2D` | unchanged |
| `ORB`, `FastFeatureDetector` | `OpenCvSharp` | unchanged |

## 5. Removed APIs

These wrap OpenCV functions that were removed in OpenCV 5 (no replacement), so the managed methods are gone too:

| Removed | Notes / replacement |
|---|---|
| `OpenCvSharp.Extensions.Binarizer` (Niblack/Sauvola/Bernsen/Nick/…) | Use `Cv2.XImgProc.NiblackThreshold` (Niblack / Sauvola / Wolf / Nick) |
| `CvDnn.ReadNetFromDarknet`, `CvDnn.ReadNetFromCaffe`, `CvDnn.ReadNetFromTorch`, `CvDnn.ReadTorchBlob`, `CvDnn.ShrinkCaffeModel` (and the `Net.*` equivalents) | Darknet/Caffe/Torch parsers removed — export to ONNX and use `Cv2.Dnn.ReadNetFromONNX` |
| `Net.SetHalideScheduler` | Halide backend removed |
| `Cv2.ConvertFp16` | Use `Mat.ConvertTo` to/from `MatType.CV_16F` |
| `Cv2.LogPolar`, `Cv2.LinearPolar` | Use `Cv2.WarpPolar` (`WarpPolarMode.Linear` / `Log`) |
| `Window.GetHandle()`, `Cv2.GetWindowHandle` | Legacy C API removed; no replacement |
| `Window.DisplayOverlay`, `Window.DisplayStatusBar` | Legacy GTK status-bar API removed; no replacement |
| `TrackerGOTURN` | Removed from OpenCV 5 |
| The entire `OpenCvSharp.Cuda` namespace (`GpuMat`, `Stream`, `DeviceInfo`, …) | Was already non-functional dead code in OpenCvSharp4 (guarded by a build symbol that was never actually defined) and has now been deleted outright. OpenCvSharp has never supported CUDA — see the main README. |
| `OutputArray.Create(List<T>)` | See §2 — use a `Mat` output and `Mat.GetArray<T>(out T[])` instead |

> **Caffe/Darknet has no runtime fallback, not just a removed convenience method.** The generic dispatcher `Cv2.Dnn.ReadNet(model, config)` still *detects* `.caffemodel`/`.prototxt`/`.weights`/`.cfg` extensions, but on a match it unconditionally throws `cv::Exception: Caffe importer has been removed. Please use ONNX-converted models or use an older OpenCV version.` (same for Darknet). Converting the model to ONNX is mandatory, not just recommended, for any code that used to load `.caffemodel`/Darknet models.

## 6. Changed signatures

Caffe model support was dropped; these constructors now take ONNX model paths:

| Before (OpenCvSharp4) | After (OpenCvSharp5) |
|---|---|
| `new BarcodeDetector(superResolutionPrototxtPath, superResolutionCaffeModelPath)` | `new BarcodeDetector(superResolutionModelPath = "")` |
| `new WeChatQRCode(detectorPrototxt, detectorCaffe, srPrototxt, srCaffe)` | `new WeChatQRCode(detectorModelPath = "", superResolutionModelPath = "")` |

**`FacemarkAAM.Params` / `FacemarkLBF.Params` are no longer `IDisposable`.** They used to be native-handle-backed `CvObject` subclasses; they are now plain managed classes with the same property names and types (`ModelFilename`, `M`, `N`, `NIter`, `Verbose`, `SaveModel`, `MaxM`, `MaxN`, `TextureMaxM`, `Scales`, ...). Remove any `using`/`.Dispose()` call on them — everything else about constructing and using them is unchanged:

```csharp
// OpenCvSharp4
using var p = new FacemarkAAM.Params { M = 20, N = 10 };
// OpenCvSharp5
var p = new FacemarkAAM.Params { M = 20, N = 10 };
```

## 7. OpenCV 5 API changes surfaced through the wrapper

OpenCV 5 reorganizes modules and changes some APIs. The managed surface follows the C++ structure where reasonable, while the `Cv2` facade is kept source-compatible where possible. This section is updated as modules are ported.

- **Module reorganization** (C++ build side): `calib3d` split into `calib`/`stereo`/`geometry`/`ptcloud`; `features2d` renamed to `features`. Despite this, most C# call sites are unaffected — `Cv2.CalibrateCamera`, `Cv2.FindChessboardCorners`, `Cv2.Rodrigues`, `StereoBM`/`StereoSGBM` all keep their existing flat `Cv2`/`OpenCvSharp` locations; only the internal source file layout moved. `ml`, `gapi`, and the Haar `CascadeClassifier` / `HOGDescriptor` native modules moved into `opencv_contrib` on the **C++ build** side only — the C# `CascadeClassifier`/`HOGDescriptor` types stay in the same `OpenCvSharp` namespace and the same NuGet package, so nothing changes for callers.
- **New `MatType` depth types**: `CV_16BF` (bfloat16), `CV_32U`, `CV_64U`, `CV_64S`, `CV_Bool`.
- **DNN**: a new inference engine is now the default (`EngineType.Auto` tries the new engine and falls back to the classic 4.x-style engine; pass `EngineType.Classic` explicitly to force the old behavior). The Darknet and Caffe model readers were removed — convert models to ONNX and use `Cv2.Dnn.ReadNetFromONNX`.
- **Behavioral differences**: `Resize` with `INTER_NEAREST` now matches Pillow; `WarpAffine` / `WarpPerspective` / `Remap` interpolation produces slightly different numeric output; the legacy `HersheyFonts` text rendering changed and a new `FontFace` text API is available.

_(Detailed managed signature changes will be added here per module as the port lands.)_
