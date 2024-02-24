using OpenCvSharp.Internal;

// ReSharper disable once InconsistentNaming

namespace OpenCvSharp.XFeatures2D;

/// <summary>
/// FREAK implementation
/// </summary>
public class FREAK : Feature2D
{
    private Ptr? ptrObj;

    /// <summary>
    /// 
    /// </summary>
    protected FREAK(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="orientationNormalized">enable orientation normalization</param>
    /// <param name="scaleNormalized">enable scale normalization</param>
    /// <param name="patternScale">scaling of the description pattern</param>
    /// <param name="nOctaves">number of octaves covered by the detected keypoints</param>
    /// <param name="selectedPairs">(optional) user defined selected pairs</param>
    public static FREAK Create(
        bool orientationNormalized = true,
        bool scaleNormalized = true,
        float patternScale = 22.0f,
        int nOctaves = 4,
        IEnumerable<int>? selectedPairs = null)
    {
        var selectedPairsArray = selectedPairs?.ToArray();

        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_FREAK_create(
                orientationNormalized ? 1 : 0,
                scaleNormalized ? 1 : 0, patternScale, nOctaves,
                selectedPairsArray, selectedPairsArray?.Length ?? 0, out var ret));
        return new FREAK(ret);
    }

    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        ptrObj?.Dispose();
        ptrObj = null;
        base.DisposeManaged();
    }
        
    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_Ptr_FREAK_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_Ptr_FREAK_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
