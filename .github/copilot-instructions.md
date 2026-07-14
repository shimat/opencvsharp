# Copilot Instructions

## File encoding

All text files in this repository use **UTF-8 without a BOM**. This applies to `.cs`, `.csproj`, `.yml`, `.md`, `.json`, `.cpp`, `.h`, and every other text file — there are no exceptions.

- `.editorconfig` declares `charset = utf-8` (no BOM) for all files, so editors and `dotnet format` enforce this automatically.
- The `Write` / `create_file` tool already produces UTF-8 without a BOM, so just create and edit files normally — no encoding fix-up step is needed.
- Do **not** add a BOM, and do not save as ANSI, Shift-JIS, or UTF-16. The repository is English-only (ASCII), and the C++ build sets the UTF-8 source charset, so MSVC reads the sources correctly without a BOM.
- **All repository content is English**, regardless of what language a request or discussion happens in: code, comments, identifiers, commit messages, PR/issue titles and descriptions, and every file under `docs/`. This holds even when the person or agent driving the change is working with the maintainer in a different language.

## NuGet README sync

When editing the root `README.md`, also update the NuGet-specific README files accordingly.

| File | Target packages |
|---|---|
| `packaging/nuget/README.managed.md` | `OpenCvSharp5`, `OpenCvSharp5.Windows`, `OpenCvSharp5.Windows.Slim`, `OpenCvSharp5.GdipExtensions`, `OpenCvSharp5.WpfExtensions`, `OpenCvSharp5.AvaloniaExtensions` |
| `packaging/nuget/README.runtime.md` | `OpenCvSharp5.runtime.*`, `OpenCvSharp5.official.runtime.*` (all native runtime packages) |

> The `main`-branch packages are the `OpenCvSharp5.*` family (OpenCV 5.x). An identically-structured `OpenCvSharp4.*` family (OpenCV 4.13.0, frozen on the `4.x` branch) is also published for .NET Framework / pre-.NET 8 consumers — see the branch note under "Versioning and release process".

The NuGet READMEs are a subset of the top-level README and consist of the following sections:

- Overview and supported platforms
- Installation instructions (Quick Start)
- Requirements
- Slim profile module coverage table (`README.managed.md` only)
- Code usage examples (`README.managed.md` only)
- Links (GitHub, Samples, API Docs, Issue Tracker)

Do **not** include CI badges, Docker instructions, build instructions, or donation links in the NuGet READMEs.

## Markdown authoring

Do not hard-wrap Markdown prose at a fixed character width in the middle of a sentence. Write each paragraph, and each list item, as a single unbroken line in the source, and let the renderer/editor soft-wrap it for display. Only start a new line for a genuinely new block: the next list item, a new paragraph, a heading, a code fence, etc. This applies to every Markdown file in the repo (READMEs, `docs/*.md`, this file) as well as PR/issue/commit-message bodies that render as Markdown — manually wrapping mid-sentence makes diffs noisy (a small wording edit reflows the whole paragraph) and reads as pointlessly rigid formatting. When editing an existing hard-wrapped file, prefer reflowing the touched paragraphs to single lines rather than preserving the old wrap width.

## Agent mode — terminal commands

In agent mode, do **not** use display commands that require user input (e.g., `more`, `less` without options). Use non-interactive alternatives instead:
- PowerShell: `Select-Object -First N`, `Out-String`, `Write-Output`
- Git: pass `-P` or `--no-pager`, or pipe to `Out-String`; e.g. `git --no-pager diff`
- Use `cat` for displaying file contents.

## Adding a new OpenCV class wrapper

> **Scope**: This checklist covers `cv::SomeClass : cv::Algorithm` subclasses. OpenCV also has classes that do **not** inherit from `Algorithm` — those may follow different ownership and lifetime patterns (see existing non-Algorithm wrappers such as `BackgroundSubtractor` or classes in `core/` for reference).

Follow this checklist when wrapping a new `cv::SomeClass : cv::Algorithm` class:

### Files to create

| File | Location |
|---|---|
| `<module>_SomeClass.h` | `src/OpenCvSharpExtern/` |
| `SomeClass.cs` | `src/OpenCvSharp/Modules/<module>/` |
| `NativeMethods_<module>_SomeClass.cs` | `src/OpenCvSharp/Internal/PInvoke/NativeMethods/<module>/` |
| `SomeClassTest.cs` | `test/OpenCvSharp.Tests/<module>/` |
| `Enum/SomeEnum.cs` (if needed) | same module folder |
| `VectorOfVecXy.cs` (only if the element type is non-blittable/nested — blittable types use `StdVector<T>` directly, no new file needed) | `src/OpenCvSharp/Internal/Vectors/` |

### Files to modify

| File | Change |
|---|---|
| `<module>.cpp` | Add `#include "<module>_SomeClass.h"` |
| `std_vector.h` | Add `#pragma region cv::VecXy` block if new vector type needed |
| `NativeMethods_stdvector.cs` | Add corresponding P/Invoke region if new vector type needed |
| `Cv<Module>.cs` | Add `public static SomeClass CreateSomeClass()` factory method |

### C++ extern pattern (<module>_SomeClass.h)

```cpp
#pragma once
#ifndef NO_CONTRIB
#include "include_opencv.h"

CVAPI(ExceptionStatus) <module>_Ptr_SomeClass_delete(cv::Ptr<cv::<module>::SomeClass> *obj)
{ BEGIN_WRAP delete obj; END_WRAP }

CVAPI(ExceptionStatus) <module>_Ptr_SomeClass_get(
    cv::Ptr<cv::<module>::SomeClass> *ptr, cv::<module>::SomeClass **returnValue)
{ BEGIN_WRAP *returnValue = ptr->get(); END_WRAP }

CVAPI(ExceptionStatus) <module>_createSomeClass(
    cv::Ptr<cv::<module>::SomeClass> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::<module>::createSomeClass();
    *returnValue = new cv::Ptr<cv::<module>::SomeClass>(ptr);
    END_WRAP
}
// ... method bindings ...
#endif // NO_CONTRIB
```

### C# class pattern (SomeClass.cs)

```csharp
public class SomeClass : Algorithm
{
    private SomeClass(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(
            NativeMethods.<module>_Ptr_SomeClass_delete(p))) { }

    public static SomeClass Create()
    {
        NativeMethods.HandleException(NativeMethods.<module>_createSomeClass(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.<module>_Ptr_SomeClass_get(smartPtr, out var rawPtr));
        return new SomeClass(smartPtr, rawPtr);
    }

    public virtual void SomeMethod(InputArray src) {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(src);
        src.ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.<module>_SomeClass_someMethod(RawPtr, src.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(src);
    }

    // OutputArray methods: call dst.Fix() after the P/Invoke call
    // std::vector return methods: use StdVector<T> for blittable T (VectorOfXxx only for
    // non-blittable/nested element types), wrap in using, call .ToArray()
}
```

### Argument validation

Use the BCL `ArgumentNullException.ThrowIfNull(x)` / `ArgumentOutOfRangeException.ThrowIfNegative(x)` / `.ThrowIfGreaterThan(x, max)` / etc. helpers instead of a manual `if (x is null) throw ...` or `if (x < 0) throw ...`. `CvObject.ThrowIfDisposed()` itself is implemented as `ObjectDisposedException.ThrowIf(IsDisposed, this)`. A few patterns are deliberately **not** converted to `ThrowIfNull`:

- A ctor-chain initializer (`: this(...)`, `: base(...)`) or expression-bodied member (`=>`) that does `x ?? throw new ArgumentNullException(nameof(x))` — `ThrowIfNull` returns `void`, so it can't be used as part of an expression; keep the `?? throw` form there.
- `if (string.IsNullOrEmpty(x)) throw new ArgumentNullException(...)` (filenames, extensions, etc.) — this intentionally raises `ArgumentNullException` for *both* a null and an empty string. Don't "upgrade" it to `ArgumentException.ThrowIfNullOrEmpty`, which throws `ArgumentException` for the empty-string case — that's a behavior change, not a mechanical rewrite.
- A cast-based unsigned-comparison bounds check (`(uint)row >= (uint)Rows`) can still use `ThrowIfGreaterThanOrEqual((uint)row, (uint)Rows, nameof(row))`, but pass `nameof(row)` explicitly — `CallerArgumentExpression` would otherwise infer the parameter name as the literal cast expression text.

### Params struct pattern (P/Invoke-compatible)

When the C++ class has a `Params` struct with `bool` fields, define a flat C struct with `int` for booleans (not a marshaled `bool` — no `[MarshalAs(UnmanagedType.Bool)]`) and convert in `getParams`/`setParams`:

```cpp
// C++ side
struct CvSomeClassParams { int SomeBool; /* other fields */ };

CVAPI(ExceptionStatus) <module>_SomeClass_getParams(obj, CvSomeClassParams* out) {
    BEGIN_WRAP out->SomeBool = obj->params.SomeBool ? 1 : 0; END_WRAP }
CVAPI(ExceptionStatus) <module>_SomeClass_setParams(obj, CvSomeClassParams* p) {
    BEGIN_WRAP cv::<module>::SomeClass::Params q; q.SomeBool = p->SomeBool != 0; obj->setParams(q); END_WRAP }
```

```csharp
// C# side — the P/Invoke-facing struct keeps SomeBool as a plain int (blittable, matches the C struct 1:1)
[StructLayout(LayoutKind.Sequential)]
internal struct CvSomeClassParams {
    public int SomeBool;
    // other fields...
}
// The public-facing Params wrapper exposes a `bool SomeBool` property that converts
// manually (`value != 0` on get, `value ? 1 : 0` on set) — see EdgeDrawingParams /
// SimpleBlobDetector.Params for real examples.
// P/Invoke: out CvSomeClassParams / ref CvSomeClassParams
```

### One-shot config classes: getAll/setAll pattern

If a `Params`/`Settings`-style class has behavior (mutated after construction and read by a live algorithm), keep individual native getter/setter P/Invoke calls per field as above. But if it's a pure **one-shot config** — constructed, handed to a factory/algorithm, and never mutated afterward (verify this against the OpenCV source before applying) — prefer folding all the scalar fields into a single blittable POD struct with one `getAll`/`setAll` P/Invoke pair instead of one call per field: a native temporary is created only at construction/read/write time, and the C# side becomes a plain managed data class with no native handle at all. `EdgeDrawingParams`, `SimpleBlobDetector.Params`, and `FacemarkLBF`/`FacemarkAAM`'s `Params` are reference implementations of this pattern. `Mat`/`string`/vector-typed fields still need their own separate P/Invoke argument (they don't fit in a blittable struct).

### Namespace access note

From `namespace OpenCvSharp.Internal`, types in `namespace OpenCvSharp` are directly visible (outer scope rule). Types in a sub-namespace such as `namespace OpenCvSharp.XImgProc` are NOT — add an explicit `using` directive in the NativeMethods file when referencing structs defined there.

### POD value types crossing the extern boundary

General-purpose primitive value types passed across the P/Invoke boundary (`Point`/`Size`/`Rect`/`Scalar`/`Range`/`RotatedRect`/`KeyPoint`/`DMatch`/`Vec2b`..`Vec6d`, etc.) live under `namespace interop` with a clean name (no `MyCv*`/`CvVec*` prefix). Convert to/from the corresponding `cv::` type with the `OCS_INTEROP_BITCAST(InteropType, cv::Type)` macro (`std::bit_cast` plus a `static_assert` on size/layout match) rather than a hand-written field-by-field converter — the `static_assert` catches layout drift at compile time. Two exceptions:

- `cv::Scalar`/`cv::Vec*` (and `Moments`) are **not** trivially copyable (`cv::Matx`-derived, user-defined copy/move ops) and can't go through `bit_cast` — they keep an explicit converter. Geometry types (`Point_`/`Size_`/`Rect_`/`RotatedRect`/`KeyPoint`/`DMatch`/`Range`/`TermCriteria`) *are* trivially copyable and use `bit_cast`.
- Module-specific param/config structs (`aruco_DetectorParameters`, `ml_DTrees_*`, `*_Params`, `CvEdgeDrawingParams`, etc.) stay with their `module_` prefix and are **not** moved into `interop::` — the prefix is a meaningful namespace (which feature the struct belongs to), and folding it into the generic `interop::` bucket would obscure that.

### Common P/Invoke pitfalls

- **`cv::Ptr<T>*` vs. raw `T*` confusion.** `CvPtrObject.Handle` (used by most property getters/setters) returns a raw `T*`, not the smart pointer — a native binding declared as `cv::Ptr<T>* obj` with `(*obj)->getXxx()` silently misinterprets the raw pointer's vtable as a `cv::Ptr`'s internal layout and reliably crashes (access violation) the first time it's called, not at compile time. Match the parameter type to what the C# side actually passes (`Handle` → raw `T*` parameter with `obj->getXxx()`); this bit `BackgroundSubtractorGMG`/`MOG`'s property accessors and went unnoticed because no test exercised a round trip.
- **Don't change a marshaling attribute (`[MarshalAs(UnmanagedType.LPStr)]` vs. `LPUTF8Str`) without checking every native code path that consumes it.** Different OpenCV backends decode filename strings differently (e.g. `cap_msmf.cpp` uses `MultiByteToWideChar(CP_ACP, ...)`, i.e. it expects ANSI, not UTF-8) — switching the attribute to "fix" one call site can silently corrupt non-ASCII paths on a different backend. This kind of regression doesn't show up in a plain build/test run; it only surfaces when you actually exercise the affected path with non-ASCII input.
- **Write one real get/set (or call/verify) round trip before copying an existing property/method pattern to a new class.** Don't trust an existing, untested binding as a copy-source just because it compiles — verify it actually works first.

### Free-function facade naming: `Cv2` mirrors `cv::`

Free functions are exposed as static methods on `Cv2`, mirroring the C++ namespace structure:

- `Cv2` = `cv::` — e.g. `Cv2.CvtColor` ↔ `cv::cvtColor`.
- `Cv2.<Sub>` (a nested `public static partial class` under `Cv2`) = `cv::<sub>::` — e.g. `Cv2.Dnn.ReadNetFromONNX` ↔ `cv::dnn::readNetFromONNX`, matching the Python `cv2.dnn.*` submodules. In scope: `Dnn`, `Aruco`, `XImgProc`, `XPhoto`, `OptFlow`, `Text`, `Detail`, `Shape`, `VideoIORegistry`.

Place each submodule facade in its module folder as `Cv2.<Sub>.cs` (e.g. `Modules/dnn/Cv2.Dnn.cs`). The file uses `namespace OpenCvSharp;` and `using OpenCvSharp.<Sub>;` (the wrapper *types* stay in their `OpenCvSharp.<Sub>` namespaces). Where a sub-namespace type name collides with one in `OpenCvSharp` root (e.g. `InpaintTypes`), fully-qualify it in the signature (`OpenCvSharp.XPhoto.InpaintTypes`). Functions that live directly in `cv::` (no sub-namespace, e.g. the shape `Create…` factories) go on `Cv2` itself, not a nested class. The `CvExtensions` *extension methods* (`OpenCvSharp.Extensions`) are not part of this and keep their name.

### std::vector return values

- For a blittable/primitive element type (`int`, `byte`, `float`, `double`, `Point`, `Point2f`, `Vec4i`, `Vec4f`, `Vec6d`, ...), use the generic `StdVector<T>` directly — do **not** create a dedicated `VectorOfXxx` class. E.g. `new StdVector<Point2f>()`, `new StdVector<byte>()`, `new StdVector<Vec4i>()`.
- Only create a dedicated `VectorOfXxx.cs` for element types that aren't blittable or need custom marshaling: nested vectors (`std::vector<std::vector<Point>>` → `VectorOfVectorPoint`), `Mat` (`VectorOfMat`), `String` (`VectorOfString`), or other non-trivial types (`VectorOfKeyLine`, `VectorOfDTreesNode`, ...).
- New dedicated vector types: add `#pragma region` in `std_vector.h`, `#region` in `NativeMethods_stdvector.cs`, and create `VectorOfXxx.cs`.

### EdgeDrawing as reference implementation

See `src/OpenCvSharpExtern/ximgproc_EdgeDrawing.h`, `src/OpenCvSharp/Modules/ximgproc/EdgeDrawing.cs` for a complete example covering: factory, OutputArray methods, `StdVector<T>`-returning methods (`StdVector<Vec6d>` in `DetectEllipses()`, `StdVector<Vec4f>` in `DetectLines()`, `StdVector<int>` in `GetSegmentIndicesOfLines()`), a nested `VectorOfVectorPoint`-returning method, and a Params struct with `int`-backed bool fields (`EdgeDrawingParams`).

## Enum member naming

C++ enum members are `ALL_CAPS_WITH_UNDERSCORES` (e.g. `IMWRITE_JPEG_QUALITY`, `NORM_L2SQR`). When wrapping them as a C# enum, **default to PascalCase**, stripping the module/family prefix (`IMWRITE_JPEG_QUALITY` → `JpegQuality`). Keep the original casing (or a near-verbatim form) only when one of these narrow exceptions applies:

1. **The value itself is an unbreakable acronym/abbreviation, standing alone (nothing else glued onto it).** Test: read it aloud — do you spell out the letters (like an acronym) rather than pronounce it as a word? If so, PascalCasing it (`Exif`, `L2Sqr`) destroys the acronym for no benefit. Keep it verbatim (`EXIF`, `L2SQR`). Precedent: `NormTypes.INF`/`L1`/`L2SQR`, `ImageMetadataType.EXIF`/`XMP`/`ICCP`/`CICP`.
2. **The value has no natural word boundaries — it's an opaque code, not a phrase.** Test: does inserting word breaks add any information, or does it just capitalize letters arbitrarily? If the latter, keep it verbatim. Precedent: `ColorConversionCodes.BGR2GRAY` (whole body kept verbatim, only the `COLOR_` prefix stripped), `FASTType.TYPE_5_8`.
3. **The prefix identifies a specific vendor/backend and is semantically load-bearing.** Test: does stripping the prefix delete information a reader needs (which camera SDK/backend this property belongs to)? If so, keep the prefix verbatim; the suffix can still be PascalCased normally. Precedent: `VideoCaptureProperties`' `XI_`/`OPENNI_`/`PVAPI_`/`GIGA_`/`IOS_`-prefixed members.

When none of the three applies, PascalCase — don't keep a verbatim name "to be safe." The exceptions are narrow and should be justifiable by one of the tests above, not a default.

**Compounds win over exception 1.** The "standalone" qualifier in exception 1 matters: once an acronym is glued to another word/acronym to form one compound member name, PascalCase the whole compound rather than leaving the acronym in caps — an ALL-CAPS-then-lowercase transition mid-identifier (`TIFFResUnit`, `CCITTRle`) is harder to read than a clean compound (`TiffResUnit`, `CcittRle`). This is why the pre-existing `ImwriteFlags.TiffResUnit`/`JpegQuality`/`PngCompression`/`PamTupleType` PascalCase acronyms that would otherwise qualify for exception 1 in isolation — they're prefixes in a compound, not standalone values. Same reasoning covers `ImwriteTiffCompressionFlags.CcittRle`/`CcittFax3` and the standalone-but-left-PascalCase `Lzw`/`Jbig`/`Dcs`/`Rle` siblings in that same enum (and its `ImwriteEXRCompressionFlags`/`ImwriteHDRCompressionFlags` cousins) — treating every acronym-derived compression-scheme name as ordinary vocabulary, consistently within the enum, beats selectively all-capping only some of them.

**Enum type names are a separate question — mirror the C++ type identifier verbatim, don't run it through this heuristic.** OpenCV's own C++ type names are inconsistently cased across acronyms (`ImwriteJPEGSamplingFactorParams`, `ImwriteEXRTypeFlags`, `ImwritePNGFlags`, `ImwritePAMFlags`, `ImwriteWEBPLosslessMode`, `ImwriteHDRCompressionFlags`, `ImwriteBMPCompressionFlags`, `ImwriteGIFCompressionFlags` are capitalized, but `ImwriteTiffCompressionFlags`/`ImwriteTiffPredictorFlags`/`ImwriteTiffResolutionUnitFlags` use `Tiff`) — that inconsistency is inherited straight from `opencv2/imgcodecs.hpp`, not introduced on the C# side. Keep mirroring the C++ type name 1:1 regardless: it keeps the C# type grep-able against OpenCV's own headers/docs, which matters more than internal cosmetic consistency for a type name. This has always been this codebase's practice (`ImwriteEXRTypeFlags`/`ImwritePNGFlags`/`ImwritePAMFlags` pre-date this rule and already mirror C++ verbatim).

## Repository structure

OpenCvSharp is organized as:

- **`src/OpenCvSharp/`** — managed C# wrapper (P/Invoke, types, extension methods). Built against `net8.0` (`netstandard2.0`/`netstandard2.1`/`net4x` support was dropped); consumers on net8.0 or above (net9.0, net10.0, ...) can reference it.
- **`src/OpenCvSharpExtern/`** — thin C++ bridge called by the C# side via P/Invoke.
- **`src/OpenCvSharp.WpfExtensions/`, `src/OpenCvSharp.GdipExtensions/`, `src/OpenCvSharp.AvaloniaExtensions/`** — optional UI-toolkit interop packages (`Mat`/`BitmapSource`/`Bitmap`/`WriteableBitmap` conversions) consumers reference separately from the core package; each ships as its own `OpenCvSharp5.*Extensions` NuGet package.
- **`packaging/nuget/`** — NuGet packaging projects (runtime packages that bundle the native DLLs).

## Native ABI and breaking-change policy

`main` is on OpenCV 5.x, a deliberately breaking migration phase: neither the native `OpenCvSharpExtern` ABI nor the public managed API is a compatibility constraint on this branch. When a P/Invoke signature, a native struct layout, or a managed method signature is awkward only because it's mirroring an old/incidental shape, feel free to change **both** the native (`.cpp`/`.h`) and managed sides together to reach the most natural, most efficient design — don't contort the managed side just to avoid touching `OpenCvSharpExtern`. Rebuild and verify with `cmake --build src/build --config Release --target OpenCvSharpExtern` after any native-side change. That said, prefer the smallest change that gets a natural design: if a managed-only fix (e.g. exposing a multi-dimensional native array as a `Span` instead of adding a new native entry point) is just as natural, it's the lower-risk choice — don't change the native ABI merely because "5.x allows it."

Before proposing to delete legacy/unused-looking code (custom loaders, old P/Invoke wrappers, etc.), verify — don't just assume unused: (1) identify the concrete use case the code was solving, (2) judge whether that use case can still plausibly occur for some consumer, (3) if so, check whether the .NET BCL or a language feature already covers the same need in a more general way (e.g. a custom DLL-loading shim vs. `System.Runtime.InteropServices.NativeLibrary`). If (3) holds, the custom code is reinventing something the platform already provides and removing it is justified; if you skip this check, a deletion can break a real but niche use case (e.g. a plugin host) that the code was quietly serving.

Don't add lazy/deferred computation to a previously native-resource-free convenience type (e.g. a plain result class) if it means that type now has to hold a native handle and become `IDisposable`. Callers of a convenience API generally don't expect to have to think about disposal at all; a modest performance win from avoiding one copy is usually not worth breaking that expectation. If a genuine hot path needs the efficiency, first check whether an *eager* computation with a targeted zero-copy view for the specific expensive step (comparison, rendering, ...) gets most of the benefit without changing the type's disposal contract. If an `IDisposable`-introducing change really is the best option, present the trade-off (e.g. as two labeled alternatives) before implementing it rather than committing to it unilaterally.

## Versioning and release process

See `docs/release-process.md` for the full release workflow.

**Key rule: do not edit version numbers in source files for routine releases.** The NuGet package version is passed via `-p:Version=...` at pack time in CI. `AssemblyVersion` and `FileVersion` are hardcoded to `5.0.0.0` in `src/Directory.Build.props` and must not be changed for patch or minor OpenCV upgrades — only bump the major component on a breaking API change or OpenCV major-version upgrade. `InformationalVersion` is set automatically by the SDK to the full NuGet version string.

> **Branch note:** `main` targets OpenCV 5.x and publishes the `OpenCvSharp5` package family (there is no separate `5.x` branch — `main` is the OpenCV-5 development branch). The `4.x` branch is frozen on OpenCV 4.13.0 (`OpenCvSharp4` family, `AssemblyVersion 4.0.0.0`); cut 4.x patches from there.

## Native DLL loading

There is no custom native-library loader. Since `src/OpenCvSharp/` requires net8.0 or above, a consumer can never be a .NET Framework (net4x) project (net8.0+-only assemblies aren't referenceable from net4x), so the old `WindowsLibraryLoader`/`Win32Api` classes and their `dll/x64`-folder probing were unreachable and were removed. Native library resolution is handled entirely by the .NET runtime's default probing via the `runtimes/{rid}/native/` layout that the `OpenCvSharp5.runtime.*` NuGet packages provide. If an app needs to load the native DLL from a nonstandard location (e.g. a plugin host that doesn't process `deps.json`), it can call `System.Runtime.InteropServices.NativeLibrary.Load(path)` (or `NativeLibrary.SetDllImportResolver`) itself before the first OpenCvSharp call — no OpenCvSharp-side API is needed for this.

## Pull request conventions

This repo has no `PULL_REQUEST_TEMPLATE.md`, so there's no fixed checklist to fill in — but that doesn't mean invent your own heading structure (`### Description`, `### Changes`, etc.). Look at a few recently merged PRs' bodies first and match their shape: a short plain-prose summary (no invented headings), optionally followed by a `## Test plan` checklist when the change needs one. Keep it terse — a large, sectioned write-up reads as noticeably more "AI-generated" than the plain style this repo's own history uses.

## Issue backlog

`docs/issue-backlog.md` tracks actionable issues identified from closed/stale GitHub issues. Update the checkboxes as items are resolved.
