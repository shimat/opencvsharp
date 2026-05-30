# Release Process

This document describes the steps required to publish a new version of OpenCvSharp.

---

## Version numbering

NuGet package versions follow the pattern `{opencv_version}.{YYYYMMDD}`, e.g. `4.13.0.20260530`. The `-beta` suffix is stripped by `OpenCvSharp.NupkgBetaRemover` at publish time.

The version is passed at pack time via `-p:Version=...` in CI. **No source file needs to be edited to change the version number.**

### Assembly versioning policy

Managed assembly attributes are set as follows (see `src/Directory.Build.props`):

| Attribute | Value | Rationale |
|---|---|---|
| `AssemblyVersion` | `4.0.0.0` (major-pinned, hardcoded) | Changing this on every release is a breaking change for .NET Framework consumers of the strong-named assembly — they would need binding redirects in `app.config`. Only bump the major component when there is a breaking API change. |
| `FileVersion` | `4.0.0.0` (hardcoded) | The date-based 4th component (e.g. `20260530`) exceeds the 65535 per-component limit of the Windows FILEVERSION PE resource. |
| `InformationalVersion` | Set automatically by the .NET SDK to `$(Version)` | This is the human-readable version visible in Windows file properties ("Product version") and most tooling. It tracks the NuGet version correctly with no manual action needed. |

### When to bump `AssemblyVersion`

- **Patch / minor OpenCV update** (e.g. 4.13.0 → 4.13.1, or 4.13 → 4.14): **do nothing**. The assembly version stays at `4.0.0.0`.
- **OpenCV major version bump** (e.g. 4.x → 5.x): update `AssemblyVersion` and `FileVersion` in `src/Directory.Build.props` to `5.0.0.0`. Be aware this is a breaking change for .NET Framework consumers.
- **Breaking API change in the C# wrapper** (rare): same as above — bump the major component.

---

## CI workflow

Releases are produced by running the following workflows in order:

1. **`windows.yml`** — builds `OpenCvSharpExtern.dll` (full and slim), runs tests, packs NuGet packages with a `-beta` version suffix.
2. **`linux-arm64.yml`** — builds the Linux ARM64 native library.
3. **`manylinux.yml`** — builds the Linux x64 native library.
4. **`wasm.yml`** — builds the WASM native library.
5. **`publish_nuget.yml`** — collects all artifacts, strips the `-beta` suffix via `OpenCvSharp.NupkgBetaRemover`, validates the package set, and pushes to NuGet.org.

The `OPENCV_VERSION` environment variable in `windows.yml` controls the OpenCV version embedded in the package version string. Update it there when upgrading OpenCV.

---

## Upgrading OpenCV

1. Update the `opencv` and `opencv_contrib` submodules to the new tag.
2. Update `OPENCV_VERSION` in `.github/workflows/windows.yml`.
3. Update the ffmpeg DLL filename references in `nuget/OpenCvSharp4.runtime.win.props` and `nuget/OpenCvSharp4.runtime.win.csproj` if the ffmpeg DLL name changed (e.g. `opencv_videoio_ffmpeg4130_64.dll` → `opencv_videoio_ffmpeg4140_64.dll`).
4. Run the full CI pipeline and verify all tests pass.
5. `AssemblyVersion` does **not** need to be changed for a minor/patch OpenCV upgrade.
