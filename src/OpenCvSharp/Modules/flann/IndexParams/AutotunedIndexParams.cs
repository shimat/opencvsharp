using OpenCvSharp.Internal;

namespace OpenCvSharp.Flann;

/// <summary>
/// hierarchical k-means tree.
/// </summary>
public class AutotunedIndexParams : IndexParams
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="targetPrecision">Is a number between 0 and 1 specifying the percentage of the approximate nearest-neighbor searches that return the exact nearest-neighbor. 
    /// Using a higher value for this parameter gives more accurate results, but the search takes longer. The optimum value usually depends on the application.</param>
    /// <param name="buildWeight">Specifies the importance of the index build time raported to the nearest-neighbor search time. 
    /// In some applications it’s acceptable for the index build step to take a long time if the subsequent searches in the index can be performed very fast. 
    /// In other applications it’s required that the index be build as fast as possible even if that leads to slightly longer search times.</param>
    /// <param name="memoryWeight">Is used to specify the tradeoff between time (index build time and search time) and memory used by the index. 
    /// A value less than 1 gives more importance to the time spent and a value greater than 1 gives more importance to the memory usage.</param>
    /// <param name="sampleFraction">Is a number between 0 and 1 indicating what fraction of the dataset to use in the automatic parameter configuration algorithm. 
    /// Running the algorithm on the full dataset gives the most accurate results, but for very large datasets can take longer than desired. 
    /// In such case using just a fraction of the data helps speeding up this algorithm while still giving good approximations of the optimum parameters.</param>
    public AutotunedIndexParams(float targetPrecision = 0.9f, float buildWeight = 0.01f, float memoryWeight = 0, float sampleFraction = 0.1f)
        : base(null)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_Ptr_AutotunedIndexParams_new(targetPrecision, buildWeight, memoryWeight, sampleFraction, out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(AutotunedIndexParams)}");

        PtrObj = new Ptr(p);
        ptr = PtrObj.Get();
    }

    /// <summary>
    /// 
    /// </summary>
    protected AutotunedIndexParams(OpenCvSharp.Ptr ptrObj)
        : base(ptrObj)
    {
    }

    internal new class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.flann_Ptr_AutotunedIndexParams_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.flann_Ptr_AutotunedIndexParams_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
