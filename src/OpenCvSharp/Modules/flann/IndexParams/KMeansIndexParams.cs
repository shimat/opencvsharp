using OpenCvSharp.Internal;

namespace OpenCvSharp.Flann;

/// <summary>
/// When passing an object of this type the index constructed will be a hierarchical k-means tree.
/// </summary>
public class KMeansIndexParams : IndexParams
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="branching">The branching factor to use for the hierarchical k-means tree</param>
    /// <param name="iterations">The maximum number of iterations to use in the k-means clustering stage when building the k-means tree. A value of -1 used here means that the k-means clustering should be iterated until convergence</param>
    /// <param name="centersInit">The algorithm to use for selecting the initial centers when performing a k-means clustering step. </param>
    /// <param name="cbIndex">This parameter (cluster boundary index) influences the way exploration is performed in the hierarchical kmeans tree. When cb_index is zero the next kmeans domain to be explored is choosen to be the one with the closest center. A value greater then zero also takes into account the size of the domain.</param>
    public KMeansIndexParams(int branching = 32, int iterations = 11, FlannCentersInit centersInit = FlannCentersInit.Random, float cbIndex = 0.2f)
        : base(null)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_Ptr_KMeansIndexParams_new(branching, iterations, centersInit, cbIndex, out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(KMeansIndexParams)}");

        PtrObj = new Ptr(p);
        ptr = PtrObj.Get();
    }

    /// <summary>
    /// 
    /// </summary>
    protected KMeansIndexParams(OpenCvSharp.Ptr ptrObj)
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
                NativeMethods.flann_Ptr_KMeansIndexParams_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.flann_Ptr_KMeansIndexParams_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
