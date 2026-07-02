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

### Sub-namespace free functions: `CvXxx` → `Cv2.Xxx`

The standalone free-function facade classes (`CvDnn`, `CvAruco`, …) have been
replaced by **nested static classes under `Cv2`**, so the managed API mirrors the
C++ sub-namespaces and the Python `cv2` submodules (`cv2.dnn.*`, `cv2.aruco.*`, …):

| Before (OpenCvSharp4) | After (OpenCvSharp5) | C++ namespace |
|---|---|---|
| `CvDnn.ReadNetFromOnnx` | `Cv2.Dnn.ReadNetFromOnnx` | `cv::dnn` |
| `CvAruco.DetectMarkers` | `Cv2.Aruco.DetectMarkers` | `cv::aruco` |
| `CvXImgProc.NiblackThreshold` | `Cv2.XImgProc.NiblackThreshold` | `cv::ximgproc` |
| `CvXPhoto.Inpaint` | `Cv2.XPhoto.Inpaint` | `cv::xphoto` |
| `CvOptFlow.CalcOpticalFlowSF` | `Cv2.OptFlow.CalcOpticalFlowSF` | `cv::optflow` |
| `CvText.DetectTextSWT` | `Cv2.Text.DetectTextSWT` | `cv::text` |
| `CvDetail.ComputeImageFeatures` | `Cv2.Detail.ComputeImageFeatures` | `cv::detail` |
| `CvShape.CreateThinPlateSplineShapeTransformer` | `Cv2.CreateThinPlateSplineShapeTransformer` | `cv::` (no sub-namespace) |

The wrapper **types** (`Net`, `ArucoDetector`, the `ximgproc` filter classes, …)
are unchanged and still live in their `OpenCvSharp.<Sub>` namespaces, so a typical
call site only changes the static facade prefix:

```csharp
using OpenCvSharp.Dnn;                       // Net / Model types (unchanged)
var net = Cv2.Dnn.ReadNetFromOnnx("m.onnx"); // was: CvDnn.ReadNetFromOnnx(...)
```

`CvShape` had no matching `cv::shape` sub-namespace (its members are `Create…`
factories for types living directly in `cv::`), so it folds straight into `Cv2`.
`CvExtensions` (the OpenCvSharp-specific `Mat` extension methods) is **not** part
of this change and keeps its name and `OpenCvSharp.Extensions` namespace.

## 3. Removed APIs

These wrap OpenCV functions that were removed in OpenCV 5 (no replacement), so
the managed methods are gone too:

| Removed | Notes / replacement |
|---|---|
| `OpenCvSharp.Extensions.Binarizer` (Niblack/Sauvola/Bernsen/Nick/…) | Use `Cv2.XImgProc.NiblackThreshold` (Niblack / Sauvola / Wolf / Nick) |
| `CvDnn.ReadNetFromDarknet`, `CvDnn.ReadNetFromCaffe`, `CvDnn.ReadNetFromTorch`, `CvDnn.ReadTorchBlob`, `CvDnn.ShrinkCaffeModel` (and the `Net.*` equivalents) | Darknet/Caffe/Torch parsers removed — export to ONNX and use `Cv2.Dnn.ReadNetFromONNX` |
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

## 3b. Additional findings from real-world migration testing (raw notes, needs editing pass)

The following was found by taking the `opencvsharp_samples` repo and actually
migrating every sample project from OpenCvSharp4 to a locally-built
OpenCvSharp5 beta package. Not yet cross-checked against other modules or
polished into the rest of this document — treat as a raw findings dump for a
future editing pass.

### `Cv2.Dnn.ReadNet(model, config)` is NOT a working fallback for Caffe/Darknet

The "Removed APIs" table above says to use ONNX for Caffe/Darknet models, but
it's worth being explicit: the generic dispatcher `Cv2.Dnn.ReadNet(model,
config)` (`cv::dnn::readNet` in `opencv/modules/dnn/src/dnn_read.cpp`)
still *detects* `.caffemodel`/`.prototxt`/`.weights`/`.cfg` extensions, but on
match it unconditionally throws:

```
cv::Exception: Caffe importer has been removed. Please use ONNX-converted models or use an older OpenCV version.
```

(same for Darknet). So there is no code-level workaround at all for
Caffe/Darknet models in OpenCvSharp5 — model conversion to ONNX is mandatory,
not just recommended. (The `opencvsharp_samples` samples that loaded
`.caffemodel` files — `CaffeSample`, `FaceDetectionDNN`, `HandPose`, `Pose` —
were deleted outright rather than "fixed", since there is nothing to fix them
to without a different model file.)

### Minor: `ReadNetFromOnnx` casing is inconsistent between `Cv2.Dnn` and `Net`

`Cv2.Dnn.ReadNetFromOnnx` (lowercase `nnx`) forwards to `Net.ReadNetFromONNX`
(uppercase `ONNX`). Pick one casing convention; right now the facade and the
underlying type disagree with each other, and this migration doc's own
"Removed APIs" table used the `ONNX` casing (inherited from the `Net` side) —
worth double-checking every mention once one casing is chosen.

### `OutputArray.Create(List<T>)` (write-back into a `List<T>`) was removed

This is a genuine removed API, missing from the "Removed APIs" table above.
OpenCvSharp4 let you pass a `List<T>` as an output sink, e.g.:

```csharp
var output = new List<byte>();
Cv2.Threshold(InputArray.Create(input), OutputArray.Create(output), T, Max, ThresholdTypes.Binary);
```

`OutputArray.Create(List<T>)` no longer exists. Use a `Mat` as the output and
pull the array back out with `Mat.GetArray<T>(out T[])`:

```csharp
using var output = new Mat();
Cv2.Threshold(InputArray.Create(input), output, T, Max, ThresholdTypes.Binary);
output.GetArray(out byte[] outputArr);
```

This was removed as "dead scaffolding" (issue #1976 step 4), but real sample
code in `opencvsharp_samples` (`NormalArrayOperations`, `SolveEquation`) was
using it, so "dead" was inaccurate — flag this if the same reasoning gets
applied to other APIs going forward.

### `null` no longer works for optional `InputArray`/`OutputArray`/`InputOutputArray` parameters — use `default`

`InputArray` / `OutputArray` / `InputOutputArray` are now `readonly ref
struct`s (see the InputArray/OutputArray ref-struct redesign, issue #1976),
so they can't be `null`. Any call site that used to pass a literal `null` for
an optional mask/array parameter (e.g. `Feature2D.DetectAndCompute(image,
null, out keypoints, descriptors)`, `Cv2.CalcHist(..., null, ...)`,
`Cv2.Dilate(src, dst, null)`) now needs `default` instead:

```csharp
sift.DetectAndCompute(gray, default, out var keypoints, descriptors); // was: null
```

This is the same convention already used in `test/OpenCvSharp.Tests` (e.g.
`FlannBasedMatcherTest.cs`, `ORBTest.cs`), so it's at least consistent — but
it isn't mentioned anywhere in this migration doc yet, and the compiler error
you get (`CS0037: cannot convert null to 'InputArray' because it's a
non-nullable value type`) doesn't point at `default` as the fix.

### `Mat`'s fluent Cv2-wrapper instance methods were removed entirely (huge blast radius)

`Mat_CvMethods.cs` — the file of `Mat` instance methods that wrapped `Cv2`
static methods purely for chainable call syntax (`mat.Circle(...)`,
`mat.Line(...)`, `mat.Rectangle(...)`, `mat.PutText(...)`,
`mat.Polylines(...)`, `mat.CvtColor(...)`, `mat.Threshold(...)`,
`mat.Resize(...)`, `mat.SaveImage(...)`, `mat.HoughCircles(...)`,
`mat.MinEnclosingCircle(...)`, and many more — over 2300 lines) — was deleted
outright (commit `446c36b8`, "Remove Mat_CvMethods.cs fluent Cv2 wrappers
(Mat instance methods)"). Rationale from the commit message: the duplication
doubled the maintenance surface of every `Cv2` method, and intermediate
`Mat`s produced mid-chain couldn't be captured with `using`, leaking into
non-deterministic GC-driven native cleanup.

This is an intentional, deliberate, already-decided breaking change — not a
bug — but its real-world impact is large: migrating the ~20 files in
`opencvsharp_samples` that used this fluent style touched **every single
non-GUI sample that draws or converts a `Mat`**. The compile error gives zero
indication of what changed (`CS1061: 'Mat' does not contain a definition for
'Circle'`), so anyone hitting this needs to already know the fluent API was
removed. This deserves prominent, explicit coverage in the migration guide —
probably its own top-level section — since it's likely the single most common
break for existing OpenCvSharp4 code, more so than any of the renames above.

Migration pattern is mechanical: `mat.Xxx(args)` → `Cv2.Xxx(mat, args)`
(insert the `Mat` as the first argument). Two subtleties found in practice:

- Methods that used to *return a new Mat* (`var gray = src.CvtColor(code);`,
  `var t = src.Threshold(...)`) need an explicit destination `Mat` created
  first: `using var gray = new Mat(); Cv2.CvtColor(src, gray, code);`.
- `Mat.Resize(...)` collides with an unrelated, still-existing instance
  method: `Mat.Resize(int sz)` / `Mat.Resize(int sz, Scalar s)` (std::vector
  -style row-count resize, present since OpenCvSharp4). Callers who meant
  "image resize" and got a "wrong number of arguments" error rather than a
  "no such method" error should be pointed at `Cv2.Resize(src, dst, size,
  fx, fy, interpolation)` explicitly, since overload resolution won't say
  "did you mean Cv2.Resize" for them.

### `MatExpr` is no longer `IDisposable` — drop `using` on it

Consistent with the `MatExpr` lazy-tree rework: `Mat.Zeros(...)`, `Mat.Eye(...)`,
`mat.T()`, and Mat arithmetic operators (`+`, `*`, `-0.5`, ...) now return a
`MatExpr` that is a lightweight managed value, not a disposable native
handle. Code that did `using var x = Mat.Zeros(...);` or `using var t = a *
b;` now fails with `CS1674: 'MatExpr': type used in a using statement must be
implicitly convertible to 'System.IDisposable'`. Fix is to just drop the
`using`/`using var` (`var x = Mat.Zeros(...);`). If the declared type is
explicitly `Mat` rather than `var` (e.g. `using (Mat img = Mat.Zeros(...))`),
it still compiles and still needs disposal, because `MatExpr` has an
implicit conversion to `Mat` that materializes it.

### Namespace churn in `features`/`xfeatures2d` beyond what's listed above

Found while migrating `SiftSurfSample`, `BRISKSample`, `KAZESample*`:

- `SIFT` moved out of `OpenCvSharp.Features2D` and now lives directly in
  `OpenCvSharp` (the `OpenCvSharp.Features2D` namespace no longer exists at
  all).
- `BRISK`, `KAZE`, `AKAZE` moved the *other* direction: from `OpenCvSharp`
  into `OpenCvSharp.XFeatures2D`.
- `SURF` was already in `OpenCvSharp.XFeatures2D` in OpenCvSharp4, unchanged.

Worth a full sweep of every `features`/`xfeatures2d` type's namespace before
finalizing this doc, since the above was only what surfaced through the
samples actually exercised.

### Aruco: `DetectMarkers` is a structural change, not just a `CvAruco` → `Cv2.Aruco` rename

Beyond the `CvAruco.Xxx` → `Cv2.Aruco.Xxx` facade rename already documented
above, `DetectMarkers` itself moved from being a static one-shot call to an
instance method on `ArucoDetector` (constructed once from a `Dictionary` +
`DetectorParameters` + `RefineParameters`, then reused):

```csharp
// OpenCvSharp4
CvAruco.DetectMarkers(image, dictionary, out corners, out ids, detectorParameters, out rejected);

// OpenCvSharp5
using var dictionary = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_1000);
using var detector = new ArucoDetector(dictionary, detectorParameters, new RefineParameters());
detector.DetectMarkers(image, out corners, out ids, out rejected);
```

This mirrors the OpenCV 5 C++ API shape (`cv::aruco::ArucoDetector`), so it's
expected/upstream-driven, but it's a bigger call-site change than the simple
prefix swap the existing table above implies.

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
