namespace OpenCvSharp
{
    /// <summary>
    /// Variants of Line Segment %Detector
    /// </summary>
    public enum LineSegmentDetectorModes : int
    {
        /// <summary>
        /// No refinement applied
        /// </summary>
        RefineNone = 0, 
        
        /// <summary>
        /// Standard refinement is applied. E.g. breaking arches into smaller straighter line approximations.
        /// </summary>
        RefineStd = 1, 
        
        /// <summary>
        /// Advanced refinement. Number of false alarms is calculated, lines are
        /// refined through increase of precision, decrement in size, etc.
        /// </summary>
        RefineAdv = 2,
    }
}
