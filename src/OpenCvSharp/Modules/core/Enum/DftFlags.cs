namespace OpenCvSharp;

/// <summary>
/// Transformation flags for cvDFT
/// </summary>
[Flags]
public enum DftFlags
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// Do inverse 1D or 2D transform. The result is not scaled. 
    /// (Forward and Inverse are mutually exclusive, of course.)
    /// </summary>
    Inverse = 1,

    /// <summary>
    /// Scale the result: divide it by the number of array elements. Usually, it is combined with Inverse.
    /// </summary>
    Scale = 2,

    /// <summary>
    /// Do forward or inverse transform of every individual row of the input matrix. 
    /// This flag allows user to transform multiple vectors simultaneously and can be used to decrease the overhead
    /// (which is sometimes several times larger than the processing itself), to do 3D and higher-dimensional transforms etc.
    /// </summary>
    Rows = 4,

    /// <summary>
    /// performs a forward transformation of 1D or 2D real array; the result, 
    /// though being a complex array, has complex-conjugate symmetry (*CCS*, 
    /// see the function description below for details), and such an array can 
    /// be packed into a real array of the same size as input, which is the fastest 
    /// option and which is what the function does by default; however, you may 
    /// wish to get a full complex array (for simpler spectrum analysis, and so on) - 
    /// pass the flag to enable the function to produce a full-size complex output array.
    /// </summary>
    ComplexOutput = 16,

    /// <summary>
    /// performs an inverse transformation of a 1D or 2D complex array; 
    /// the result is normally a complex array of the same size, however, 
    /// if the input array has conjugate-complex symmetry (for example, 
    /// it is a result of forward transformation with DFT_COMPLEX_OUTPUT flag), 
    /// the output is a real array; while the function itself does not 
    /// check whether the input is symmetrical or not, you can pass the flag 
    /// and then the function will assume the symmetry and produce the real 
    /// output array (note that when the input is packed into a real array 
    /// and inverse transformation is executed, the function treats the input 
    /// as a packed complex-conjugate symmetrical array, and the output 
    /// will also be a real array).
    /// </summary>
    RealOutput = 32,
}
