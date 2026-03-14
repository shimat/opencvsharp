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
    public void Tesseract_IsEnabled() => AssertEnabled("Tesseract");

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
