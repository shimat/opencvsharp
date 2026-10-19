# OpenCV Module Coverage

This table describes the OpenCvSharp5 bindings on `main` and the native modules included in its packaged runtime profiles. Published NuGet versions may predate changes on `main`. It does not describe OpenCvSharp4. OpenCvSharp exposes selected APIs from each listed module; a check mark does **not** mean that every OpenCV function, class, overload, or backend in that module has a .NET binding. Search the [API reference](../../api/index.md) for a particular API before depending on it.

| Mark | Meaning |
|---|---|
| ✓ | OpenCvSharp has bindings for at least part of the module, and the profile builds the corresponding native exports. |
| — | The profile does not provide OpenCvSharp bindings for that module. A managed declaration may still be present, but calling it with this runtime can fail because the native export is absent. |

**Full** covers the Windows, macOS, and Linux full runtime builds. **Headless** is the official Linux headless build, which differs from full by disabling `highgui`. **Slim** covers the Windows and official Linux slim builds. **Android** is the preview `OpenCvSharp5.runtime.android` package. Platform backends and third-party dependencies can still differ within a profile; for example, Windows ARM64 does not include the FFmpeg video I/O plugin. This matrix describes module availability, not every backend or codec.

## OpenCV modules and API groups

OpenCV 5 split the former `calib3d` module into `geometry`, `calib`, `stereo`, and `ptcloud`, and renamed `features2d` to `features`. Its `aruco` and `barcode` APIs are part of `objdetect`; they are shown separately because OpenCvSharp exposes separate binding groups for them.

| Module or API group | Full | Headless | Slim | Android | Notes |
|---|:---:|:---:|:---:|:---:|---|
| `core` | ✓ | ✓ | ✓ | ✓ | Core types and operations; individual APIs may depend on other modules. |
| `imgproc` | ✓ | ✓ | ✓ | ✓ | Some image processing APIs moved to other OpenCV 5 modules. |
| `imgcodecs` | ✓ | ✓ | ✓ | ✓ | Codec availability depends on the build. |
| `geometry` | ✓ | ✓ | ✓ | — | Includes geometry APIs formerly in `calib3d`. |
| `calib` | ✓ | ✓ | ✓ | — | Camera calibration. |
| `stereo` | ✓ | ✓ | ✓ | — | Stereo matching. |
| `ptcloud` | ✓ | ✓ | ✓ | — | Point cloud and odometry APIs. |
| `features` | ✓ | ✓ | ✓ | — | Formerly `features2d`. |
| `flann` | ✓ | ✓ | ✓ | — | Approximate nearest-neighbor search. |
| `objdetect` | ✓ | ✓ | ✓ | — | Includes selected APIs backed by contrib `xobjdetect`. |
| `aruco` (`objdetect` APIs) | ✓ | ✓ | ✓ | — | Marker and ChArUco APIs use the existing `objdetect` module. |
| `barcode` (`objdetect` APIs) | ✓ | ✓ | ✓ | — | Barcode detection is part of `objdetect` in OpenCV 5. |
| `photo` | ✓ | ✓ | ✓ | — | Computational photography. |
| `ml` | ✓ | ✓ | ✓ | — | Machine learning. |
| `video` | ✓ | ✓ | ✓ | — | Video analysis; distinct from `videoio`. |
| `dnn` | ✓ | ✓ | — | — | Deep neural networks. |
| `stitching` | ✓ | ✓ | — | — | Panorama stitching. |
| `videoio` | ✓ | ✓ | — | — | Capture and writing; available backends vary by platform. |
| `highgui` | ✓ | — | — | — | Native windows and UI controls. |

## opencv_contrib modules

The table lists contrib modules with OpenCvSharp bindings. `xobjdetect` supplies some `objdetect` bindings above, including cascade and HOG APIs, rather than a separate managed API group. Some contrib modules remain in slim even though that native binding build sets `NO_CONTRIB=ON`. This is why the OpenCV build list alone cannot determine whether a particular OpenCvSharp binding is available.

| Module | Full | Headless | Slim | Android | Notes |
|---|:---:|:---:|:---:|:---:|---|
| `bgsegm` | ✓ | ✓ | ✓ | — | Background segmentation. |
| `img_hash` | ✓ | ✓ | ✓ | — | Perceptual image hashes. |
| `xobjdetect` | ✓ | ✓ | ✓ | — | Selected APIs appear under OpenCvSharp's `objdetect` bindings. |
| `ximgproc` | ✓ | ✓ | ✓ | — | Extended image processing. |
| `xphoto` | ✓ | ✓ | ✓ | — | Extended photography. |
| `bioinspired` | ✓ | ✓ | — | — | |
| `ccalib` | ✓ | ✓ | — | — | |
| `dnn_objdetect` | ✓ | ✓ | — | — | |
| `dnn_superres` | ✓ | ✓ | — | — | |
| `dpm` | ✓ | ✓ | — | — | |
| `face` | ✓ | ✓ | — | — | |
| `fuzzy` | ✓ | ✓ | — | — | |
| `hfs` | ✓ | ✓ | — | — | |
| `intensity_transform` | ✓ | ✓ | — | — | |
| `line_descriptor` | ✓ | ✓ | — | — | Named `line_descriptors` in the managed source tree. |
| `optflow` | ✓ | ✓ | — | — | |
| `phase_unwrapping` | ✓ | ✓ | — | — | |
| `plot` | ✓ | ✓ | — | — | |
| `quality` | ✓ | ✓ | — | — | |
| `rapid` | ✓ | ✓ | — | — | |
| `reg` | ✓ | ✓ | — | — | |
| `rgbd` | ✓ | ✓ | — | — | |
| `saliency` | ✓ | ✓ | — | — | |
| `shape` | ✓ | ✓ | — | — | |
| `signal` | ✓ | ✓ | — | — | |
| `structured_light` | ✓ | ✓ | — | — | |
| `superres` | ✓ | ✓ | — | — | |
| `surface_matching` | ✓ | ✓ | — | — | |
| `text` | ✓ | ✓ | — | — | Some OCR APIs require Tesseract. |
| `tracking` | ✓ | ✓ | — | — | |
| `videostab` | ✓ | ✓ | — | — | Video stabilization from in-memory frames. |
| `wechat_qrcode` | ✓ | ✓ | — | — | |
| `xfeatures2d` | ✓ | ✓ | ✓ | — | Slim exposes BRISK, KAZE, AKAZE, and AGAST; the other bindings remain full/headless only. |
| `xstereo` | ✓ | ✓ | — | — | |

The following upstream contrib modules have no OpenCvSharp5 bindings in these runtime profiles: `alphamat`, `cannops`, `cnn_3dobj`, `cvv`, `datasets`, `dnns_easily_fooled`, `fastcv`, `freetype`, `gapi`, `hdf`, `ovis`, `sfm`, and `viz`. The CUDA modules `cudev`, `cudaarithm`, `cudabgsegm`, `cudacodec`, `cudafeatures2d`, `cudafilters`, `cudaimgproc`, `cudalegacy`, `cudaobjdetect`, `cudaoptflow`, `cudastereo`, and `cudawarping` are also unsupported. Language-specific `julia` and `matlab` contrib modules, and the OpenCV `java`, `js`, `objc`, `python`, and `ts` binding generators, are outside the .NET binding scope. The upstream `world` target aggregates modules and has no separate API row here.

## Profile details and limits

- Full and headless Linux builds select the same non-GUI OpenCV modules. Headless turns GTK off and builds the native binding with `NO_HIGHGUI=ON`.
- Slim builds use the module list in [`cmake/opencv_build_options_slim.cmake`](https://github.com/shimat/opencvsharp/blob/main/cmake/opencv_build_options_slim.cmake) and disable `dnn`, `stitching`, `videoio`, `highgui`, and most contrib bindings. The slim `NO_CONTRIB` switch does not remove the lightweight contrib bindings marked above.
- Android builds only `core`, `imgproc`, and `imgcodecs` native bindings. `Subdiv2D`, `IntelligentScissorsMB`, and `GoodFeaturesToTrack` are unavailable there because OpenCV 5 places them in `geometry`, `photo`, and `features`, respectively. See [Android runtime support](android.md).
- WebAssembly has its own build and test configuration and is not represented by the four packaged profiles in this table. Check the [WebAssembly workflow](https://github.com/shimat/opencvsharp/blob/main/.github/workflows/wasm.yml) and test the specific API you need in a browser.

## Why these modules are in slim

The slim profile aims to keep common in-memory processing useful without requiring GUI, media capture, DNN, or their extra runtime dependencies. The decision is based on the OpenCV module dependency graph **and** the exports actually enabled in OpenCvSharp. A compiled OpenCV module alone does not make its managed API usable.

| Decision | Modules or APIs | Reason |
|---|---|---|
| Keep the base | `core`, `imgproc`, `imgcodecs`, `geometry`, `calib`, `stereo`, `ptcloud`, `features`, `flann`, `objdetect`, `photo`, `ml`, `video` | These cover the main image, feature, calibration, analysis, and point cloud workflows. `video` processes frames already in memory; capture and codecs belong to `videoio`. `ptcloud` uses modules already in this profile rather than a separate third-party runtime. |
| Keep selected contrib | `bgsegm`, `img_hash`, `ximgproc`, `xphoto`, `xobjdetect`, and selected `xfeatures2d` APIs | These provide commonly useful algorithms on top of the slim base without introducing DNN, GUI, or media I/O dependencies. Some larger `ximgproc` and `xfeatures2d` binding groups remain excluded. |
| Include relocated APIs | ArUco, barcode, cascade and HOG detection, BRISK, KAZE, AKAZE, AGAST | OpenCV 5 moved these APIs into `objdetect`, `xobjdetect`, or `xfeatures2d`. ArUco uses the already included `objdetect` module; the selected feature detectors use the already included `xfeatures2d` module. Their previous `NO_CONTRIB` guards would otherwise hide useful APIs despite those native dependencies being present. |
| Exclude heavy profile changes | `dnn`, `videoio`, `highgui`, `stitching`, and contrib bindings that require those modules or optional external integrations | These change the size or runtime dependency goals of slim. Full or headless is the appropriate profile when they are needed. |
| Leave specialized contrib in full/headless | Modules such as `ccalib`, `rapid`, `reg`, `rgbd`, `structured_light`, and `surface_matching` | Their narrower use cases do not yet justify expanding the default slim exports. Their dependencies and incremental package size should be measured before moving them into slim. |

The retained modules are not all equally small. In particular, `ptcloud`, `ml`, `ximgproc`, and `xfeatures2d` warrant size checks when the profile is next rebuilt. The choices above preserve their useful APIs while avoiding additional modules; they are not a numerical size guarantee.

This is a module-level guide to the source and build configuration, not a promise of complete API parity or a guarantee that an optional backend is installed. For package names, see [Choose a Version and Package](package-selection.md).
