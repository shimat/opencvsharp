// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace OpenCvSharp;

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
    GRANA = 1,
        
    /// <summary>
    /// Spaghetti @cite Bolelli2019 algorithm for 8-way connectivity, SAUF algorithm for 4-way connectivity.
    /// </summary>
    BOLELLI = 2,

    /// <summary>
    /// Same as CCL_WU. It is preferable to use the flag with the name of the algorithm (CCL_SAUF) rather than the one with the name of the first author (CCL_WU).
    /// </summary>
    SAUF = 3,

    /// <summary>
    /// Same as CCL_GRANA. It is preferable to use the flag with the name of the algorithm (CCL_BBDT) rather than the one with the name of the first author (CCL_GRANA).
    /// </summary>
    BBDT = 4,

    /// <summary>
    /// Same as CCL_BOLELLI. It is preferable to use the flag with the name of the algorithm (CCL_SPAGHETTI) rather than the one with the name of the first author (CCL_BOLELLI).
    /// </summary>
    SPAGHETTI = 5,
}
