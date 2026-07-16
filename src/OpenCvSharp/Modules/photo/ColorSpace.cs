namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// Color space used by the color correction model (ccm), covering common RGB working spaces (each
/// with a corresponding linear variant, suffixed RGBL) plus CIE XYZ and CIE Lab under several
/// illuminant/observer-angle combinations.
/// </summary>
public enum ColorSpace
{
    /// <summary>https://en.wikipedia.org/wiki/SRGB , RGB color space</summary>
    SRGB,
    /// <summary>https://en.wikipedia.org/wiki/SRGB , linear RGB color space</summary>
    SRGBL,
    /// <summary>https://en.wikipedia.org/wiki/Adobe_RGB_color_space , RGB color space</summary>
    AdobeRGB,
    /// <summary>https://en.wikipedia.org/wiki/Adobe_RGB_color_space , linear RGB color space</summary>
    AdobeRGBL,
    /// <summary>https://en.wikipedia.org/wiki/Wide-gamut_RGB_color_space , RGB color space</summary>
    WideGamutRGB,
    /// <summary>https://en.wikipedia.org/wiki/Wide-gamut_RGB_color_space , linear RGB color space</summary>
    WideGamutRGBL,
    /// <summary>https://en.wikipedia.org/wiki/ProPhoto_RGB_color_space , RGB color space</summary>
    ProPhotoRGB,
    /// <summary>https://en.wikipedia.org/wiki/ProPhoto_RGB_color_space , linear RGB color space</summary>
    ProPhotoRGBL,
    /// <summary>https://en.wikipedia.org/wiki/DCI-P3 , RGB color space</summary>
    DciP3RGB,
    /// <summary>https://en.wikipedia.org/wiki/DCI-P3 , linear RGB color space</summary>
    DciP3RGBL,
    /// <summary>http://www.brucelindbloom.com/index.html?WorkingSpaceInfo.html , RGB color space</summary>
    AppleRGB,
    /// <summary>http://www.brucelindbloom.com/index.html?WorkingSpaceInfo.html , linear RGB color space</summary>
    AppleRGBL,
    /// <summary>https://en.wikipedia.org/wiki/Rec._709 , RGB color space</summary>
    Rec709RGB,
    /// <summary>https://en.wikipedia.org/wiki/Rec._709 , linear RGB color space</summary>
    Rec709RGBL,
    /// <summary>https://en.wikipedia.org/wiki/Rec._2020 , RGB color space</summary>
    Rec2020RGB,
    /// <summary>https://en.wikipedia.org/wiki/Rec._2020 , linear RGB color space</summary>
    Rec2020RGBL,
    /// <summary>https://en.wikipedia.org/wiki/CIE_1931_color_space , XYZ color space, D65 illuminant, 2 degree</summary>
    XYZ_D65_2,
    /// <summary>https://en.wikipedia.org/wiki/CIE_1931_color_space , XYZ color space, D50 illuminant, 2 degree</summary>
    XYZ_D50_2,
    /// <summary>https://en.wikipedia.org/wiki/CIE_1931_color_space , XYZ color space, D65 illuminant, 10 degree</summary>
    XYZ_D65_10,
    /// <summary>https://en.wikipedia.org/wiki/CIE_1931_color_space , XYZ color space, D50 illuminant, 10 degree</summary>
    XYZ_D50_10,
    /// <summary>https://en.wikipedia.org/wiki/CIE_1931_color_space , XYZ color space, A illuminant, 2 degree</summary>
    XYZ_A_2,
    /// <summary>https://en.wikipedia.org/wiki/CIE_1931_color_space , XYZ color space, A illuminant, 10 degree</summary>
    XYZ_A_10,
    /// <summary>https://en.wikipedia.org/wiki/CIE_1931_color_space , XYZ color space, D55 illuminant, 2 degree</summary>
    XYZ_D55_2,
    /// <summary>https://en.wikipedia.org/wiki/CIE_1931_color_space , XYZ color space, D55 illuminant, 10 degree</summary>
    XYZ_D55_10,
    /// <summary>https://en.wikipedia.org/wiki/CIE_1931_color_space , XYZ color space, D75 illuminant, 2 degree</summary>
    XYZ_D75_2,
    /// <summary>https://en.wikipedia.org/wiki/CIE_1931_color_space , XYZ color space, D75 illuminant, 10 degree</summary>
    XYZ_D75_10,
    /// <summary>https://en.wikipedia.org/wiki/CIE_1931_color_space , XYZ color space, E illuminant, 2 degree</summary>
    XYZ_E_2,
    /// <summary>https://en.wikipedia.org/wiki/CIE_1931_color_space , XYZ color space, E illuminant, 10 degree</summary>
    XYZ_E_10,
    /// <summary>https://en.wikipedia.org/wiki/CIELAB_color_space , Lab color space, D65 illuminant, 2 degree</summary>
    Lab_D65_2,
    /// <summary>https://en.wikipedia.org/wiki/CIELAB_color_space , Lab color space, D50 illuminant, 2 degree</summary>
    Lab_D50_2,
    /// <summary>https://en.wikipedia.org/wiki/CIELAB_color_space , Lab color space, D65 illuminant, 10 degree</summary>
    Lab_D65_10,
    /// <summary>https://en.wikipedia.org/wiki/CIELAB_color_space , Lab color space, D50 illuminant, 10 degree</summary>
    Lab_D50_10,
    /// <summary>https://en.wikipedia.org/wiki/CIELAB_color_space , Lab color space, A illuminant, 2 degree</summary>
    Lab_A_2,
    /// <summary>https://en.wikipedia.org/wiki/CIELAB_color_space , Lab color space, A illuminant, 10 degree</summary>
    Lab_A_10,
    /// <summary>https://en.wikipedia.org/wiki/CIELAB_color_space , Lab color space, D55 illuminant, 2 degree</summary>
    Lab_D55_2,
    /// <summary>https://en.wikipedia.org/wiki/CIELAB_color_space , Lab color space, D55 illuminant, 10 degree</summary>
    Lab_D55_10,
    /// <summary>https://en.wikipedia.org/wiki/CIELAB_color_space , Lab color space, D75 illuminant, 2 degree</summary>
    Lab_D75_2,
    /// <summary>https://en.wikipedia.org/wiki/CIELAB_color_space , Lab color space, D75 illuminant, 10 degree</summary>
    Lab_D75_10,
    /// <summary>https://en.wikipedia.org/wiki/CIELAB_color_space , Lab color space, E illuminant, 2 degree</summary>
    Lab_E_2,
    /// <summary>https://en.wikipedia.org/wiki/CIELAB_color_space , Lab color space, E illuminant, 10 degree</summary>
    Lab_E_10,
}
