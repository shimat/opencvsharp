using System.Diagnostics.CodeAnalysis;

#pragma warning disable CA1051

namespace OpenCvSharp.LineDescriptor;

/// <summary>
/// A class to represent a line
///
/// As aformentioned, it is been necessary to design a class that fully stores the information needed to 
/// characterize completely a line and plot it on image it was extracted from, when required.
///
/// *KeyLine* class has been created for such goal; it is mainly inspired to Feature2d's KeyPoint class,
/// since KeyLine shares some of* KeyPoint*'s fields, even if a part of them assumes a different
/// meaning, when speaking about lines.In particular:
///
/// -   the* class_id* field is used to gather lines extracted from different octaves which refer to
/// same line inside original image (such lines and the one they represent in original image share
/// the same* class_id* value)
/// -   the* angle* field represents line's slope with respect to (positive) X axis
/// -   the* pt* field represents line's midpoint
/// -   the* response* field is computed as the ratio between the line's length and maximum between
/// image's width and height
/// -   the* size* field is the area of the smallest rectangle containing line
///
/// Apart from fields inspired to KeyPoint class, KeyLines stores information about extremes of line in
/// original image and in octave it was extracted from, about line's length and number of pixels it
/// covers.
/// </summary>
[SuppressMessage("Microsoft.Design", "CA1815: Override equals and operator equals on value types")]
public readonly struct KeyLine
{
    /// <summary>
    /// orientation of the line
    /// </summary>
    public readonly float Angle;

    /// <summary>
    /// object ID, that can be used to cluster keylines by the line they represent
    /// </summary>
    public readonly int ClassId;
        
    /// <summary>
    /// octave (pyramid layer), from which the keyline has been extracted
    /// </summary>
    public readonly int Octave;
        
    /// <summary>
    /// coordinates of the middlepoint
    /// </summary>
    public readonly Point2f Pt;

    /// <summary>
    /// the response, by which the strongest keylines have been selected.
    /// It's represented by the ratio between line's length and maximum between
    /// image's width and height
    /// </summary>
    public readonly float Response;
        
    /// <summary>
    /// minimum area containing line
    /// </summary>
    public readonly float Size;

    /// <summary>
    /// lines' extremes in original image
    /// </summary>
    public readonly float StartPointX;
    /// <summary>
    /// lines' extremes in original image
    /// </summary>
    public readonly float StartPointY;
    /// <summary>
    /// lines' extremes in original image
    /// </summary>
    public readonly float EndPointX;
    /// <summary>
    /// lines' extremes in original image
    /// </summary>
    public readonly float EndPointY;

    /// <summary>
    /// line's extremes in image it was extracted from
    /// </summary>
    public readonly float SPointInOctaveX;
    /// <summary>
    /// line's extremes in image it was extracted from
    /// </summary>
    public readonly float SPointInOctaveY;
    /// <summary>
    /// line's extremes in image it was extracted from
    /// </summary>
    public readonly float EPointInOctaveX;
    /// <summary>
    /// line's extremes in image it was extracted from
    /// </summary>
    public readonly float EPointInOctaveY;

    /// <summary>
    /// the length of line
    /// </summary>
    public readonly float LineLength;

    /// <summary>
    /// number of pixels covered by the line
    /// </summary>
    public readonly int NumOfPixels;
        
    /// <summary>
    /// Returns the start point of the line in the original image
    /// </summary>
    public Point2f StartPoint => new (StartPointX, StartPointY);
        
    /// <summary>
    /// Returns the end point of the line in the original image
    /// </summary>
    public Point2f EndPoint => new (EndPointX, EndPointY);

    /// <summary>
    /// Returns the start point of the line in the octave it was extracted from
    /// </summary>
    public Point2f StartPointInOctave => new (SPointInOctaveX, SPointInOctaveY);
        
    /// <summary>
    /// Returns the end point of the line in the octave it was extracted from
    /// </summary>
    public Point2f EndPointInOctave => new (EPointInOctaveX, EPointInOctaveY);

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="angle"></param>
    /// <param name="classId"></param>
    /// <param name="octave"></param>
    /// <param name="pt"></param>
    /// <param name="response"></param>
    /// <param name="size"></param>
    /// <param name="startPointX"></param>
    /// <param name="startPointY"></param>
    /// <param name="endPointX"></param>
    /// <param name="endPointY"></param>
    /// <param name="sPointInOctaveX"></param>
    /// <param name="sPointInOctaveY"></param>
    /// <param name="ePointInOctaveX"></param>
    /// <param name="ePointInOctaveY"></param>
    /// <param name="lineLength"></param>
    /// <param name="numOfPixels"></param>
    public KeyLine(
        float angle = default, 
        int classId = default, 
        int octave = default, 
        Point2f pt = default,
        float response = default, 
        float size = default, 
        float startPointX = default, 
        float startPointY = default,
        float endPointX = default, 
        float endPointY = default, 
        float sPointInOctaveX = default,
        float sPointInOctaveY = default, 
        float ePointInOctaveX = default,
        float ePointInOctaveY = default,
        float lineLength = default, 
        int numOfPixels = default)
    {
        Angle = angle;
        ClassId = classId;
        Octave = octave;
        Pt = pt;
        Response = response;
        Size = size;
        StartPointX = startPointX;
        StartPointY = startPointY;
        EndPointX = endPointX;
        EndPointY = endPointY;
        SPointInOctaveX = sPointInOctaveX;
        SPointInOctaveY = sPointInOctaveY;
        EPointInOctaveX = ePointInOctaveX;
        EPointInOctaveY = ePointInOctaveY;
        LineLength = lineLength;
        NumOfPixels = numOfPixels;
    }
}
