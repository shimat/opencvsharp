# Issue Backlog

> Last updated: 2026-05-30  
> Scope: issues closed as stale that appear actionable, plus open issues under investigation.

Check off items as they are resolved.

---

## ✅ Quick wins (small, self-contained fixes)

### [x] #1766 — IL3000 warning with PublishTrimmed / PublishAoT

- **State**: closed (stale)
- **URL**: https://github.com/shimat/opencvsharp/issues/1766
- **Root cause**: `WindowsLibraryLoader.cs` uses `Assembly.Location`, which always returns an empty string in single-file / AoT apps, triggering the IL3000 trimming warning.
- **Fix**: Replace `Assembly.Location` with `AppContext.BaseDirectory` (one-line change).
- **Effort**: Low

---

### [x] #1704 — Assembly version reported as `0.0.0.0`

- **State**: closed (stale)
- **URL**: https://github.com/shimat/opencvsharp/issues/1704
- **Root cause**: `AssemblyVersion` and `FileVersion` were not aligned with the NuGet package version. The csproj now has them hardcoded to `4.13.0.0`, so the `0.0.0.0` symptom may already be resolved. The remaining issue is that these values must be updated manually on each release.
- **Note**: Because OpenCvSharp is a strong-named assembly (`SignAssembly=true`), bumping `AssemblyVersion` on every release would be a breaking change for .NET Framework consumers (binding redirects required). The recommended approach is to keep `AssemblyVersion` pinned to the major version (e.g. `4.0.0.0`) and only align `FileVersion` / `InformationalVersion` with the NuGet package version automatically via CI.
- **Fix**: Keep `AssemblyVersion` at `4.0.0.0` (major-pinned); `FileVersion` is intentionally pinned to `4.0.0.0` in `Directory.Build.props` (due to Windows PE/FILEVERSION 65535-per-component limits and the project comment in `Directory.Build.props`); `InformationalVersion` remains automated from `$(Version)` by the SDK. The recommended approach is to pin `AssemblyVersion` to the major version (e.g., `4.0.0.0`) and automate only `InformationalVersion` in CI.
- **Effort**: Low–Medium

---

## 🔧 Medium effort

### [x] #1765 — Native DLLs copied twice when targeting .NET Framework 4.8

- **State**: closed (stale)
- **URL**: https://github.com/shimat/opencvsharp/issues/1765
- **Root cause**: NuGet restore already copies the `runtimes/` DLLs to the output directory, but the package's custom `.targets` file copies them again into `dll/x64`, resulting in duplicates.
- **Fix**: Add a condition to the custom copy task in the `.targets` file so it is skipped when NuGet has already handled the copy (i.e., on net48 targets).
- **Effort**: Medium

---

### [x] #1753 — `NativeMethods` static constructor fires too early

- **State**: closed (stale)
- **URL**: https://github.com/shimat/opencvsharp/issues/1753
- **Root cause**: `NativeMethods` calls `TryPInvoke` in its static constructor, which runs before user code has a chance to register a custom `NativeLibrary.SetDllImportResolver`. Custom native loaders therefore cannot intercept the first P/Invoke.
- **Fix**: Removed the automatic `TryPInvoke()` call from `NativeMethods`' static constructor. `TryPInvoke()` remains public for explicit opt-in validation but is no longer called automatically. Users can now register `NativeLibrary.SetDllImportResolver` (via `typeof(NativeMethods).Assembly`) before any OpenCvSharp API call, then optionally call `NativeMethods.TryPInvoke()` for pre-flight validation.
- **Effort**: Medium

---

### [ ] #1731 — WASM runtime fails to publish under .NET 9 with trimming/linking enabled

- **State**: closed (stale)
- **URL**: https://github.com/shimat/opencvsharp/issues/1731
- **Root cause**: `OpenCvSharp4.runtime.wasm` ships `OpenCvSharpExtern.a` compiled with Emscripten 3.1.32 (.NET 8 era). .NET 9 uses Emscripten 3.1.56, whose C++ stdlib ABI differs, causing `undefined symbol` linker errors.
- **Fix**: Rebuild `OpenCvSharpExtern.a` with Emscripten 3.1.56 and publish a `net9.0`-targeting package. Add a .NET 9 + Emscripten 3.1.56 build step to `.github/workflows/wasm.yml`.
- **Effort**: Medium

---

## 🏗️ Large effort

### [ ] #1743 — No NuGet runtime package for Windows ARM64

- **State**: closed (stale)
- **URL**: https://github.com/shimat/opencvsharp/issues/1743
- **Note**: A community fork (`xavave/opencvsharp.win.arm64`) has already done this work and can serve as a reference.
- **Fix**: Build `OpenCvSharpExtern.dll` for ARM64 Windows, package it under `runtimes/win-arm64/native/`, and add an ARM64 Windows CI build.
- **Effort**: Large

---

### [ ] #1737 — Camera calibration with `CharucoBoard` not supported

- **State**: closed (stale)
- **URL**: https://github.com/shimat/opencvsharp/issues/1737
- **Note**: A community fork (`xavave`) has implemented this and can serve as a reference.
- **Fix**: Add wrappers for `CharucoBoard` and the `Cv2.Aruco.CalibrateCamera` overloads in the aruco module.
- **Effort**: Large

---

## ⏸️ On hold (need more information)

### #1774 — Suspected memory leak in `CvtColor BGR2RGBA`

- **State**: closed (stale)
- **URL**: https://github.com/shimat/opencvsharp/issues/1774
- **Note**: Cannot confirm this is a wrapper bug without a verified minimal repro showing native heap growth (e.g. via a native heap profiler). Revisit if a clean repro is provided.

### #1748 — `libssl.lib` linked in `OpenCvSharpExtern.vcxproj`

- **State**: closed (stale)
- **URL**: https://github.com/shimat/opencvsharp/issues/1748
- **Note**: Unclear whether this is a stale leftover or a genuine dependency. Needs inspection of the `.vcxproj` linker settings.

### #1745 — Intermittent `AccessViolationException` in `CLAHE.Apply`

- **State**: closed (stale)
- **URL**: https://github.com/shimat/opencvsharp/issues/1745
- **Note**: Occurs roughly once every few days. Hard to attribute to the wrapper layer without a repro. Likely a race condition or memory corruption in native OpenCV. Revisit if a repro is found.

---

## 📋 Open issues under investigation

### #1863 — Crash in `BarcodeDetector` (0xc0000409)

- **State**: open
- **URL**: https://github.com/shimat/opencvsharp/issues/1863
- **Note**: Cannot reproduce with our own tests. Waiting for a stack trace and full environment details from the reporter.

### #1789 — `ConcatLayer` throws "Inconsistent shape"

- **State**: open
- **URL**: https://github.com/shimat/opencvsharp/issues/1789
- **Note**: Reportedly fixed in OpenCV 4.10, but the reporter sees it on 4.11. Likely an ONNX export configuration issue. Cannot investigate without the model file.
