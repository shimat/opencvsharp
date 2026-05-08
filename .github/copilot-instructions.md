# Copilot Instructions

## File encoding

All source files in this repository use **UTF-8 with BOM** (`EF BB BF`).

When creating or editing files, always save them as UTF-8 with BOM. This applies to `.cs`, `.csproj`, `.yml`, `.md`, `.json`, and all other text files.

**Exception — Linux tooling files: use UTF-8 without BOM.**
The following file types are processed by Linux tools (Docker, bash, VS Code Dev Containers) that do not tolerate a BOM and must be saved **without** BOM:
- `Dockerfile` and any file named `*.Dockerfile`
- Shell scripts (`.sh`)
- `devcontainer.json` and all files under `.devcontainer/`

Do **not** save files as UTF-8 without BOM, ANSI, or Shift-JIS — doing so will corrupt Japanese content and break Visual Studio / MSBuild tooling (for the files above that require BOM).

### Editing workflow requirement

Maintain correct encoding **during each edit/create step** — do not correct it in a follow-up step.

Do not rely on a final "bulk conversion/check" step at the end of the task.

**Important:** The `create_file` tool does **not** interpret `\uFEFF` in the content string as BOM bytes — it writes the literal six characters `\uFEFF`. Never place `\uFEFF` (or any Unicode escape for U+FEFF) directly in the `content` parameter. Instead, create the file first (BOM-free), then immediately apply the PowerShell conversion command below for files that require BOM.

### Verification

Do not run the verification/conversion commands on every edit by default.
Prevent encoding issues through edit/create operations that preserve UTF-8 BOM.
Run the commands below only when preservation cannot be guaranteed or when troubleshooting is required.
# Check whether a file has UTF-8 BOM
$b = [System.IO.File]::ReadAllBytes("path\to\file")
$b[0] -eq 0xEF -and $b[1] -eq 0xBB -and $b[2] -eq 0xBF   # should be True

# Convert a file to UTF-8 with BOM
$enc = New-Object System.Text.UTF8Encoding $true
$content = [System.IO.File]::ReadAllText("path\to\file", [System.Text.Encoding]::UTF8)
[System.IO.File]::WriteAllText("path\to\file", $content, $enc)
## NuGet README sync

When editing the root `README.md`, also update the NuGet-specific README files accordingly.

| File | Target packages |
|---|---|
| `nuget/README.managed.md` | `OpenCvSharp4`, `OpenCvSharp4.Windows`, `OpenCvSharp4.Windows.Slim`, `OpenCvSharp4.Extensions`, `OpenCvSharp4.WpfExtensions` |
| `nuget/README.runtime.md` | `OpenCvSharp4.runtime.*`, `OpenCvSharp4.official.runtime.*` (all native runtime packages) |

The NuGet READMEs are a subset of the top-level README and consist of the following sections:

- Overview and supported platforms
- Installation instructions (Quick Start)
- Requirements
- Slim profile module coverage table (`README.managed.md` only)
- Code usage examples (`README.managed.md` only)
- Links (GitHub, Samples, API Docs, Issue Tracker)

Do **not** include CI badges, Docker instructions, build instructions, or donation links in the NuGet READMEs.

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
| `VectorOfVecXy.cs` (if needed) | `src/OpenCvSharp/Internal/Vectors/` |

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
        if (src is null) throw new ArgumentNullException(nameof(src));
        src.ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.<module>_SomeClass_someMethod(RawPtr, src.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(src);
    }

    // OutputArray methods: call dst.Fix() after the P/Invoke call
    // std::vector return methods: use VectorOfXxx, wrap in using, call .ToArray()
}
```

### Params struct pattern (P/Invoke-compatible)

When the C++ class has a `Params` struct with `bool` fields, define a flat C struct with `int` for booleans and convert in `getParams`/`setParams`:

```cpp
// C++ side
struct CvSomeClassParams { int SomeBool; /* other fields */ };

CVAPI(ExceptionStatus) <module>_SomeClass_getParams(obj, CvSomeClassParams* out) {
    BEGIN_WRAP out->SomeBool = obj->params.SomeBool ? 1 : 0; END_WRAP }
CVAPI(ExceptionStatus) <module>_SomeClass_setParams(obj, CvSomeClassParams* p) {
    BEGIN_WRAP cv::<module>::SomeClass::Params q; q.SomeBool = p->SomeBool != 0; obj->setParams(q); END_WRAP }
```

```csharp
// C# side — [MarshalAs(UnmanagedType.Bool)] makes bool marshal as 4-byte BOOL matching int in C
[StructLayout(LayoutKind.Sequential)]
public struct SomeClassParams {
    [MarshalAs(UnmanagedType.Bool)] public bool SomeBool;
    // other fields...
}
// P/Invoke: out SomeClassParams / ref SomeClassParams
```

### Namespace access note

From `namespace OpenCvSharp.Internal`, types in `namespace OpenCvSharp` are directly visible (outer scope rule). Types in a sub-namespace such as `namespace OpenCvSharp.XImgProc` are NOT — add an explicit `using` directive in the NativeMethods file when referencing structs defined there.

### std::vector return values

- `std::vector<std::vector<Point>>` → `VectorOfVectorPoint` (already exists)
- `std::vector<int>` → `VectorOfInt32` (already exists)
- `std::vector<Vec4f>` → `VectorOfVec4f` (already exists)
- `std::vector<Vec6d>` → `VectorOfVec6d` (added in EdgeDrawing PR)
- New vector types: add `#pragma region` in `std_vector.h`, `#region` in `NativeMethods_stdvector.cs`, and create `VectorOfXxx.cs`

### EdgeDrawing as reference implementation

See `src/OpenCvSharpExtern/ximgproc_EdgeDrawing.h`, `src/OpenCvSharp/Modules/ximgproc/EdgeDrawing.cs` for a complete example covering: factory, OutputArray methods, std::vector methods, nested Params struct with bool fields, and VectorOfVec6d.

