// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace OpenCvSharp;

/// <summary>
/// One of the implemented Robot-World/Hand-Eye calibration method
/// </summary>
public enum RobotWorldHandEyeCalibrationMethod
{
    /// <summary>
    /// Solving the robot-world/hand-eye calibration problem using the kronecker product @cite Shah2013SolvingTR
    /// </summary>
    SHAH = 0,

    /// <summary>
    /// Simultaneous robot-world and hand-eye calibration using dual-quaternions and kronecker product @cite Li2010SimultaneousRA
    /// </summary>
    LI = 1
}
