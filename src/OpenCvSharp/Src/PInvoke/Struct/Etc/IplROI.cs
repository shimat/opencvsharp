#pragma warning disable 1591
// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
    public struct IplROI
    {
        public int coi; /* 0 - no COI (all channels are selected), 1 - 0th channel is selected ...*/
        public int xOffset;
        public int yOffset;
        public int width;
        public int height;
    }
}