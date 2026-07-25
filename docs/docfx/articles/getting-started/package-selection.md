# Choose a Version and Package

OpenCvSharp uses separate managed and native packages. Every application needs the managed OpenCvSharp package and a native runtime package for its target operating system and architecture. The Windows convenience packages include both.

## Choose OpenCvSharp5 or OpenCvSharp4

| Package family | OpenCV version | .NET support | Recommended use |
|---|---|---|---|
| `OpenCvSharp5.*` | OpenCV 5.x | .NET 8 or later | New applications |
| `OpenCvSharp4.*` | OpenCV 4.13 | .NET Framework 4.6.1 or later, .NET Standard 2.0/2.1, and .NET 8 or later | Existing applications and applications that require older .NET targets |

The examples in this documentation use OpenCvSharp5. Replace `OpenCvSharp5` with the corresponding `OpenCvSharp4` package only when your application must use the OpenCvSharp4 family.

## Choose a runtime package

| Target | Packages |
|---|---|
| Windows x64 | `OpenCvSharp5.Windows` |
| Windows ARM64 | `OpenCvSharp5` and `OpenCvSharp5.runtime.win-arm64` |
| Linux x64 with GUI support | `OpenCvSharp5` and `OpenCvSharp5.official.runtime.linux-x64` |
| Linux x64 without GUI support | `OpenCvSharp5` and `OpenCvSharp5.official.runtime.linux-x64.headless` |
| Linux x64 with a reduced module set | `OpenCvSharp5` and `OpenCvSharp5.official.runtime.linux-x64.slim` |
| Linux ARM64 | `OpenCvSharp5` and `OpenCvSharp5.runtime.linux-arm64` |
| macOS Intel | `OpenCvSharp5` and `OpenCvSharp5.runtime.osx.x64` |
| macOS Apple Silicon | `OpenCvSharp5` and `OpenCvSharp5.runtime.osx.arm64` |
| WebAssembly | `OpenCvSharp5` and `OpenCvSharp5.runtime.wasm` |

Use only one native runtime package for a given deployment target. The runtime package must match the operating system and process architecture.

## Full, headless, and slim Linux packages

The full Linux x64 package contains the complete module set, including `highgui`, and therefore uses GTK3 for APIs such as `Cv2.ImShow` and `Cv2.WaitKey`.

The headless package contains the same module set as the full package except for `highgui`. It is the usual choice for services and containers that need features such as `videoio`, DNN, ML, or contrib modules but do not display native windows.

The slim package has no GUI dependency and reduces the native module set. It omits contrib, DNN, `videoio`, and `highgui`, among other modules. Choose it only when the reduced feature set is sufficient.

## Windows convenience packages

`OpenCvSharp5.Windows` combines the managed library, Windows x64 native runtime, GDI+ extensions, and WPF extensions where applicable. `OpenCvSharp5.Windows.Slim` provides the corresponding reduced native module set.

For Windows ARM64, reference `OpenCvSharp5` and `OpenCvSharp5.runtime.win-arm64` separately. FFmpeg-based video I/O is not included in the Windows ARM64 runtime package.

## Next step

Continue to [Installation](installation.md).
