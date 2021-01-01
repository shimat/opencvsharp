namespace OpenCvSharp
{
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
    public struct KeyLine
    {
        /// <summary>
        /// orientation of the line
        /// </summary>
        public float Angle;
        
        /// <summary>
        /// object ID, that can be used to cluster keylines by the line they represent
        /// </summary>
        public int ClassId;
        
        /// <summary>
        /// octave (pyramid layer), from which the keyline has been extracted
        /// </summary>
        public int Octave;
        
        /// <summary>
        /// coordinates of the middlepoint
        /// </summary>
        public Point2f Pt;

        /// <summary>
        /// the response, by which the strongest keylines have been selected.
        /// It's represented by the ratio between line's length and maximum between
        /// image's width and height
        /// </summary>
        public float Response;
        
        /// <summary>
        /// minimum area containing line
        /// </summary>
        public float Size;
        
        /// <summary>
        /// lines' extremes in original image
        /// </summary>
        public float StartPointX;
        /// <summary>
        /// lines' extremes in original image
        /// </summary>
        public float StartPointY;
        /// <summary>
        /// lines' extremes in original image
        /// </summary>
        public float EndPointX;
        /// <summary>
        /// lines' extremes in original image
        /// </summary>
        public float EndPointY;

        /// <summary>
        /// line's extremes in image it was extracted from
        /// </summary>
        public float SPointInOctaveX;
        /// <summary>
        /// line's extremes in image it was extracted from
        /// </summary>
        public float SPointInOctaveY;
        /// <summary>
        /// line's extremes in image it was extracted from
        /// </summary>
        public float EPointInOctaveX;
        /// <summary>
        /// line's extremes in image it was extracted from
        /// </summary>
        public float EPointInOctaveY;
        
        /// <summary>
        /// the length of line
        /// </summary>
        public float LineLength;
        
        /// <summary>
        /// number of pixels covered by the line
        /// </summary>
        public int NumOfPixels;
        
        /// <summary>
        /// Returns the start point of the line in the original image
        /// </summary>
        public Point2f GetStartPoint() => new (StartPointX, StartPointY);
        
        /// <summary>
        /// Returns the end point of the line in the original image
        /// </summary>
        public Point2f GetEndPoint() => new (EndPointX, EndPointY);

        /// <summary>
        /// Returns the start point of the line in the octave it was extracted from
        /// </summary>
        public Point2f GetStartPointInOctave() => new (SPointInOctaveX, SPointInOctaveY);
        
        /// <summary>
        /// Returns the end point of the line in the octave it was extracted from
        /// </summary>
        public Point2f GetEndPointInOctave() => new (EPointInOctaveX, EPointInOctaveY);
    }
}