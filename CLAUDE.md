# OpenCvSharp — Claude Code Instructions

This file provides context for AI-assisted development on this repository.

## Repository overview

OpenCvSharp is a .NET wrapper for OpenCV. The solution has three layers:

- **`src/OpenCvSharp/`** — managed C# wrapper (P/Invoke, types, extension methods)
- **`src/OpenCvSharpExtern/`** — thin C++ bridge that the C# side calls via P/Invoke
- **`nuget/`** — NuGet packaging projects (runtime packages that bundle the native DLLs)

Target frameworks for the managed library: `netstandard2.0`, `netstandard2.1`, `net8.0`. Always verify that any change is consistent across all three.

## Key conventions

### Versioning

See `docs/release-process.md` for the full release process.

**Short version:** `AssemblyVersion` and `FileVersion` are hardcoded to `4.0.0.0` in `src/Directory.Build.props` and must **not** be changed for routine OpenCV patch/minor upgrades. The NuGet package version is passed via `-p:Version=...` at pack time in CI; no source file needs editing for a version bump. `InformationalVersion` is set automatically by the SDK and tracks the full NuGet version string including the commit SHA.

Only bump the major component of `AssemblyVersion` (e.g. `4.0.0.0` → `5.0.0.0`) when there is a breaking API change or an OpenCV major-version upgrade. This is a breaking change for .NET Framework consumers.

### Native DLL loading (Windows)

`WindowsLibraryLoader` in `src/OpenCvSharp/Internal/PInvoke/WindowsLibraryLoader.cs` handles native DLL loading on Windows for .NET Framework targets. Key points:

- Uses `AppContext.BaseDirectory` (not `Assembly.Location`) to avoid IL3000 warnings in AoT/single-file apps.
- For .NET Framework (net4x), looks for DLLs under `dll/x64/` relative to the base directory. The NuGet `.props` file copies DLLs there at build time.
- For .NET 5+, returns early — the .NET runtime handles native loading via the `runtimes/` folder layout.

### NuGet runtime packages

`nuget/OpenCvSharp4.runtime.win.props` and its slim variant copy native DLLs to `dll/x64/` for net4x consumers. A companion `.targets` file suppresses the redundant copy that NuGet's PackageReference pipeline would otherwise make to the output root.

## Issue backlog

`docs/issue-backlog.md` tracks actionable issues identified from closed/stale GitHub issues. Update the checkboxes as items are resolved.
