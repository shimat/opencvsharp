// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
    /// <summary>
    /// connected components algorithm
    /// </summary>
    public enum ConnectedComponentsAlgorithmsTypes
    {
        /// <summary>
        /// SAUF algorithm for 8-way connectivity, SAUF algorithm for 4-way connectivity
        /// </summary>
        WU = 0,

        /// <summary>
        /// BBDT algorithm for 8-way connectivity, SAUF algorithm for 4-way connectivity
        /// </summary>
        Default = -1,

        /// <summary>
        /// BBDT algorithm for 8-way connectivity, SAUF algorithm for 4-way connectivity
        /// </summary>
        GRANA = 1 
    }
}
