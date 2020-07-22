namespace OpenCvSharp
{
    /// <summary>
    /// method One of the implemented Hand-Eye calibration method
    /// </summary>
    public enum HandEyeCalibrationMethod
    {
        /// <summary>
        /// A New Technique for Fully Autonomous and Efficient 3D Robotics Hand/Eye Calibration @cite Tsai89
        /// </summary>
        TSAI = 0, 

        /// <summary>
        /// Robot Sensor Calibration: Solving AX = XB on the Euclidean Group @cite Park94
        /// </summary>
        PARK = 1, 

        /// <summary>
        /// Hand-eye Calibration @cite Horaud95
        /// </summary>
        HORAUD = 2, 

        /// <summary>
        /// On-line Hand-Eye Calibration @cite Andreff99
        /// </summary>
        ANDREFF = 3, 

        /// <summary>
        /// Hand-Eye Calibration Using Dual Quaternions @cite Daniilidis98
        /// </summary>
        DANIILIDIS = 4 
    }
}