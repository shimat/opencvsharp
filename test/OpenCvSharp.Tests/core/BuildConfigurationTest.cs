using System.Text.RegularExpressions;
using Xunit;

namespace OpenCvSharp.Tests.Core;

/// <summary>
/// Asserts that the native OpenCV binary was built with the expected feature set.
/// Failures here mean a dependency was silently dropped during the cmake configure step
/// (e.g. a vcpkg package not found → OpenCV falls back to "NO").
///
/// These tests are written for the *full* build profile.  They will fail for slim builds
/// or custom builds that intentionally omit certain features.
/// </summary>
public class BuildConfigurationTest : TestBase
{
    private static readonly string BuildInfo = Cv2.GetBuildInformation();

    private readonly ITestOutputHelper output;

    public BuildConfigurationTest(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void PrintBuildInformation()
    {
        output.WriteLine(BuildInfo);
    }

    // -------------------------------------------------------------------------
    // Helper
    // -------------------------------------------------------------------------

    /// <summary>
    /// Returns the raw value string for a named feature entry (the part after "Feature: "),
    /// or null if the feature is not listed.
    /// Handles both "YES (...)" and path-based values like "/usr/lib/libjpeg.a (ver 9e)".
    /// </summary>
    private static string? GetFeatureValue(string feature)
    {
        var m = Regex.Match(BuildInfo,
            $@"^\s+{Regex.Escape(feature)}:\s+(.+)$",
            RegexOptions.Multiline);
        return m.Success ? m.Groups[1].Value.Trim() : null;
    }

    /// <summary>
    /// Returns true when the feature is present in the build info and its value is not "NO".
    /// A path value (e.g. "/usr/lib/libjpeg.a") counts as enabled.
    /// </summary>
    private static bool IsEnabled(string feature)
    {
        var value = GetFeatureValue(feature);
        if (value is null) return false;
        return !value.StartsWith("NO", StringComparison.OrdinalIgnoreCase);
    }

    private void AssertEnabled(string feature)
    {
        var value = GetFeatureValue(feature);
        Assert.True(
            value is not null && !value.StartsWith("NO", StringComparison.OrdinalIgnoreCase),
            $"Expected '{feature}' to be enabled in the OpenCV build, but got: '{value ?? "(not listed)"}'\n" +
            $"Run the PrintBuildInformation test to see the full build info.");
    }

    // -------------------------------------------------------------------------
    // Full-build feature assertions
    // -------------------------------------------------------------------------

    [Fact]
    public void FFMPEG_IsEnabled() => AssertEnabled("FFMPEG");

    [Fact]
    public void JPEG_IsEnabled() => AssertEnabled("JPEG");

    [Fact]
    public void PNG_IsEnabled() => AssertEnabled("PNG");

    [Fact]
    public void TIFF_IsEnabled() => AssertEnabled("TIFF");

    [Fact]
    public void WEBP_IsEnabled() => AssertEnabled("WEBP");
}

/* Example output from cmake configuration of OpenCV 4.13.0 on Linux ARM64 (2026-03-14):
-- General configuration for OpenCV 4.13.0 =====================================
--   Version control:               fe38fc6
-- 
--   Extra modules:
--     Location (extra):            /home/runner/work/opencvsharp/opencvsharp/opencv_contrib/modules
--     Version control (extra):     d99ad2a
-- 
--   Platform:
--     Timestamp:                   2026-03-14T09:37:26Z
--     Host:                        Linux 6.14.0-1017-azure aarch64
--     CMake:                       3.31.6
--     CMake generator:             Ninja
--     CMake build tool:            /usr/local/bin/ninja
--     Configuration:               Release
--     Algorithm Hint:              ALGO_HINT_ACCURATE
-- 
--   CPU/HW features:
--     Baseline:                    NEON FP16
--       requested:                 DETECT
--     Dispatched code generation:  NEON_DOTPROD NEON_FP16 NEON_BF16
--       requested:                 NEON_FP16 NEON_BF16 NEON_DOTPROD
--       NEON_DOTPROD (2 files):    + NEON_DOTPROD
--       NEON_FP16 (2 files):       + NEON_FP16
--       NEON_BF16 (0 files):       + NEON_BF16
-- 
--   C/C++:
--     Built as dynamic libs?:      NO
--     C++ standard:                11
--     C++ Compiler:                /usr/bin/c++  (ver 13.3.0)
--     C++ flags (Release):         -fsigned-char -W -Wall -Wreturn-type -Wnon-virtual-dtor -Waddress -Wsequence-point -Wformat -Wformat-security -Wmissing-declarations -Wundef -Winit-self -Wpointer-arith -Wshadow -Wsign-promo -Wuninitialized -Wsuggest-override -Wno-delete-non-virtual-dtor -Wno-comment -Wimplicit-fallthrough=3 -Wno-strict-overflow -fdiagnostics-show-option -pthread -fomit-frame-pointer -ffunction-sections -fdata-sections  -fvisibility=hidden -fvisibility-inlines-hidden -O3 -DNDEBUG  -DNDEBUG
--     C++ flags (Debug):           -fsigned-char -W -Wall -Wreturn-type -Wnon-virtual-dtor -Waddress -Wsequence-point -Wformat -Wformat-security -Wmissing-declarations -Wundef -Winit-self -Wpointer-arith -Wshadow -Wsign-promo -Wuninitialized -Wsuggest-override -Wno-delete-non-virtual-dtor -Wno-comment -Wimplicit-fallthrough=3 -Wno-strict-overflow -fdiagnostics-show-option -pthread -fomit-frame-pointer -ffunction-sections -fdata-sections  -fvisibility=hidden -fvisibility-inlines-hidden -g  -O0 -DDEBUG -D_DEBUG
--     C Compiler:                  /usr/bin/cc
--     C flags (Release):           -fsigned-char -W -Wall -Wreturn-type -Waddress -Wsequence-point -Wformat -Wformat-security -Wmissing-declarations -Wmissing-prototypes -Wstrict-prototypes -Wundef -Winit-self -Wpointer-arith -Wshadow -Wuninitialized -Wno-comment -Wimplicit-fallthrough=3 -Wno-strict-overflow -fdiagnostics-show-option -pthread -fomit-frame-pointer -ffunction-sections -fdata-sections  -fvisibility=hidden -O3 -DNDEBUG  -DNDEBUG
--     C flags (Debug):             -fsigned-char -W -Wall -Wreturn-type -Waddress -Wsequence-point -Wformat -Wformat-security -Wmissing-declarations -Wmissing-prototypes -Wstrict-prototypes -Wundef -Winit-self -Wpointer-arith -Wshadow -Wuninitialized -Wno-comment -Wimplicit-fallthrough=3 -Wno-strict-overflow -fdiagnostics-show-option -pthread -fomit-frame-pointer -ffunction-sections -fdata-sections  -fvisibility=hidden -g  -O0 -DDEBUG -D_DEBUG
--     Linker flags (Release):      -Wl,--gc-sections -Wl,--as-needed -Wl,--no-undefined  
--     Linker flags (Debug):        -Wl,--gc-sections -Wl,--as-needed -Wl,--no-undefined  
--     ccache:                      NO
--     Precompiled headers:         NO
--     Extra dependencies:          /usr/lib/aarch64-linux-gnu/libjpeg.so /usr/lib/aarch64-linux-gnu/libwebp.so /usr/lib/aarch64-linux-gnu/libwebpmux.so /usr/lib/aarch64-linux-gnu/libwebpdemux.so /usr/lib/aarch64-linux-gnu/libpng.so /usr/lib/aarch64-linux-gnu/libtiff.so /usr/lib/aarch64-linux-gnu/libz.so /usr/lib/aarch64-linux-gnu/libfreetype.so /usr/lib/aarch64-linux-gnu/libharfbuzz.so Iconv::Iconv dl m pthread rt
--     3rdparty dependencies:       ittnotify libprotobuf libopenjp2 IlmImf tegra_hal kleidicv_hal kleidicv kleidicv_thread
-- 
--   OpenCV modules:
--     To be built:                 aruco bgsegm calib3d core dnn dnn_superres face features2d flann freetype hfs highgui img_hash imgcodecs imgproc line_descriptor ml objdetect optflow phase_unwrapping photo plot quality rgbd saliency shape signal stitching superres text tracking video videoio wechat_qrcode xfeatures2d ximgproc xobjdetect xphoto
--     Disabled:                    bioinspired ccalib datasets dnn_objdetect dpm fuzzy intensity_transform java_bindings_generator js_bindings_generator mcc objc_bindings_generator python_bindings_generator python_tests rapid reg stereo structured_light surface_matching videostab world
--     Disabled by dependency:      -
--     Unavailable:                 alphamat cannops cudaarithm cudabgsegm cudacodec cudafeatures2d cudafilters cudaimgproc cudalegacy cudaobjdetect cudaoptflow cudastereo cudawarping cudev cvv fastcv gapi hdf java julia matlab ovis python2 python3 sfm ts viz
--     Applications:                -
--     Documentation:               NO
--     Non-free algorithms:         YES
-- 
--   GUI:                           GTK3
--     GTK+:                        YES (ver 3.24.41)
--     VTK support:                 NO
-- 
--   Media I/O: 
--     ZLib:                        /usr/lib/aarch64-linux-gnu/libz.so (ver 1.3)
--     JPEG:                        /usr/lib/aarch64-linux-gnu/libjpeg.so (ver 80)
--     WEBP:                        /usr/lib/aarch64-linux-gnu/libwebp.so (ver decoder: 0x0209, encoder: 0x020f, demux: 0x0107)
--     AVIF:                        NO
--     PNG:                         /usr/lib/aarch64-linux-gnu/libpng.so (ver 1.6.43)
--     TIFF:                        /usr/lib/aarch64-linux-gnu/libtiff.so (ver 42 / 4.5.1)
--     JPEG 2000:                   build (ver 2.5.3)
--     OpenEXR:                     build (ver 2.3.0)
--     GIF:                         YES
--     HDR:                         YES
--     SUNRASTER:                   YES
--     PXM:                         YES
--     PFM:                         YES
-- 
--   Video I/O:
--     FFMPEG:                      YES
--       avcodec:                   YES (60.31.102)
--       avformat:                  YES (60.16.100)
--       avutil:                    YES (58.29.100)
--       swscale:                   YES (7.5.100)
--       avdevice:                  NO
--     v4l/v4l2:                    YES (linux/videodev2.h)
--     Orbbec:                      YES
-- 
--   Parallel framework:            pthreads
-- 
--   Trace:                         YES (with Intel ITT(3.25.4))
-- 
--   Other third-party libraries:
--     Lapack:                      NO
--     Eigen:                       NO
--     Custom HAL:                  YES (carotene (ver 0.0.1) KleidiCV (ver 0.7.0))
--     Protobuf:                    build (3.19.1)
--     Flatbuffers:                 builtin/3rdparty (25.9.23)
-- 
--   OpenCL:                        YES (no extra features)
--     Include path:                /home/runner/work/opencvsharp/opencvsharp/opencv/3rdparty/include/opencl/1.2
--     Link libraries:              Dynamic load
-- 
--   Python (for build):            /usr/bin/python3
-- 
--   Install to:                    /home/runner/work/opencvsharp/opencvsharp/opencv_artifacts
-- -----------------------------------------------------------------
*/