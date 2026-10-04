# Android Runtime Support (Preview)

`OpenCvSharp5.runtime.android` supplies the native `OpenCvSharpExtern` library for Android arm64-v8a and x86_64. It works with the regular `OpenCvSharp5` managed package in a `net10.0-android` application. The minimum Android API level is 24.

The native package is CPU-only and builds OpenCV 5 from the repository's pinned `opencv` submodule with NDK `27.3.13750724`. Its supported module profile is `core`, `imgproc`, and `imgcodecs`. The managed assembly contains declarations for other platforms too; calling an API whose native export is absent from this profile fails at runtime. `Subdiv2D`, `IntelligentScissorsMB`, and `GoodFeaturesToTrack` are excluded because OpenCV 5 provides them through the `geometry`, `photo`, and `features` modules. Do not use this package for `VideoCapture`, `VideoWriter`, `highgui` windows, DNN, contrib modules, MAUI UI integration, or hardware acceleration. Camera applications should acquire frames with Android platform APIs and then pass the image data to OpenCvSharp.

Add the managed and runtime packages to an Android application:

```bash
dotnet add package OpenCvSharp5
dotnet add package OpenCvSharp5.runtime.android
```

The [Android GitHub Actions workflow](https://github.com/shimat/opencvsharp/blob/main/.github/workflows/android.yml) runs on every pull request and push to `main`. It cross-compiles both native ABIs, checks their ELF architecture, exports, and dependencies, packs a local NuGet package, restores it into a `net10.0-android` application, and exercises managed `Mat`, `GaussianBlur`, PNG encode, and PNG decode calls in an emulator. The arm64 job must execute those calls in an arm64 process before the package is considered supported. No maintainer-owned device or local Android installation is needed for the CI gate.
