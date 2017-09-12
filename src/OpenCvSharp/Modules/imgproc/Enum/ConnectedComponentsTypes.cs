namespace OpenCvSharp
{
    /// <summary>
    /// components algorithm output formats
    /// </summary>
    public enum ConnectedComponentsTypes
    {
        /// <summary>
        /// The leftmost (x) coordinate which is the inclusive start of the bounding
        /// box in the horizontal direction.
        /// </summary>
        Left = 0,  
        
        /// <summary>
        /// The topmost (y) coordinate which is the inclusive start of the bounding
        /// box in the vertical direction.
        /// </summary>
        Top = 1,  
        
        /// <summary>
        /// The horizontal size of the bounding box
        /// </summary>
        Width = 2,  

        /// <summary>
        /// The vertical size of the bounding box
        /// </summary>
        Height = 3, 

        /// <summary>
        /// The total area (in pixels) of the connected component
        /// </summary>
        Area = 4, 
    }
}
