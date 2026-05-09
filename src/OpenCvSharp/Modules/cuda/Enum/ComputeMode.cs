#if ENABLED_CUDA
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Cuda;

public enum ComputeMode
{
    /// <summary>
    /// multiple threads can use cudaSetDevice() with this device 
    /// </summary>
    Default = 0,            
    /// <summary>
    /// only one thread in one process will be able to use cudaSetDevice() with this device 
    /// </summary>
    Exclusive = 1,          
    /// <summary>
    /// no threads can use cudaSetDevice() with this device 
    /// </summary>
    Prohibited = 2,         
    /// <summary>
    /// many threads in one process will be able to use cudaSetDevice() with this device 
    /// </summary>
    ExclusiveProcess = 3    
}
#endif
