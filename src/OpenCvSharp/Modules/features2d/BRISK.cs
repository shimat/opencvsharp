using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable once InconsistentNaming
/// <summary>
/// BRISK implementation
/// </summary>
// ReSharper disable once InconsistentNaming
public class BRISK : Feature2D
{
    private Ptr? ptrObj;

    /// <summary>
    /// </summary>
    protected BRISK()
    {
    }

    /// <summary>
    /// Construct from native cv::Ptr&lt;T&gt;*
    /// </summary>
    /// <param name="p"></param>
    protected BRISK(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// The BRISK constructor
    /// </summary>
    /// <param name="thresh">AGAST detection threshold score.</param>
    /// <param name="octaves">detection octaves. Use 0 to do single scale.</param>
    /// <param name="patternScale">apply this scale to the pattern used for sampling the neighbourhood of a keypoint.</param>
    public static BRISK Create(int thresh = 30, int octaves = 3, float patternScale = 1.0f)
    {
        NativeMethods.HandleException(
            NativeMethods.features2d_BRISK_create1(thresh, octaves, patternScale, out var ptr));
        return new BRISK(ptr);
    }

    /// <summary>
    /// The BRISK constructor for a custom pattern
    /// </summary>
    /// <param name="radiusList">defines the radii (in pixels) where the samples around a keypoint are taken (for keypoint scale 1).</param>
    /// <param name="numberList">defines the number of sampling points on the sampling circle. Must be the same size as radiusList..</param>
    /// <param name="dMax">threshold for the short pairings used for descriptor formation (in pixels for keypoint scale 1).</param>
    /// <param name="dMin">threshold for the long pairings used for orientation determination (in pixels for keypoint scale 1).</param>
    /// <param name="indexChange">index remapping of the bits.</param>
    /// <returns></returns>
    public static BRISK Create(
        IEnumerable<float> radiusList,
        IEnumerable<int> numberList,
        float dMax = 5.85f,
        float dMin = 8.2f,
        IEnumerable<int>? indexChange = null)
    {
        if (radiusList is null)
            throw new ArgumentNullException(nameof(radiusList));
        if (numberList is null)
            throw new ArgumentNullException(nameof(numberList));

        var radiusListArray = radiusList.ToArray();
        var numberListArray = numberList.ToArray();
        var indexChangeArray = indexChange?.ToArray();

        NativeMethods.HandleException(
            NativeMethods.features2d_BRISK_create2(
                radiusListArray, radiusListArray.Length,
                numberListArray, numberListArray.Length,
                dMax, dMin,
                indexChangeArray, indexChangeArray?.Length ?? 0, 
                out var ptr));

        return new BRISK(ptr);
    }

    /// <summary>
    /// The BRISK constructor for a custom pattern, detection threshold and octaves
    /// </summary>
    /// <param name="thresh">AGAST detection threshold score.</param>
    /// <param name="octaves">detection octaves. Use 0 to do single scale.</param>
    /// <param name="radiusList">defines the radii (in pixels) where the samples around a keypoint are taken (for keypoint scale 1).</param>
    /// <param name="numberList">defines the number of sampling points on the sampling circle. Must be the same size as radiusList..</param>
    /// <param name="dMax">threshold for the short pairings used for descriptor formation (in pixels for keypoint scale 1).</param>
    /// <param name="dMin">threshold for the long pairings used for orientation determination (in pixels for keypoint scale 1).</param>
    /// <param name="indexChange">index remapping of the bits.</param>
    /// <returns></returns>
    public static BRISK Create(
        int thresh, 
        int octaves, 
        IEnumerable<float> radiusList,
        IEnumerable<int> numberList,
        float dMax = 5.85f,
        float dMin = 8.2f,
        IEnumerable<int>? indexChange = null)
    {
        if (radiusList is null)
            throw new ArgumentNullException(nameof(radiusList));
        if (numberList is null)
            throw new ArgumentNullException(nameof(numberList));

        var radiusListArray = radiusList.ToArray();
        var numberListArray = numberList.ToArray();
        var indexChangeArray = indexChange?.ToArray();

        NativeMethods.HandleException(
            NativeMethods.features2d_BRISK_create3(
                thresh, octaves,
                radiusListArray, radiusListArray.Length,
                numberListArray, numberListArray.Length,
                dMax, dMin,
                indexChangeArray, indexChangeArray?.Length ?? 0, 
                out var ptr));

        return new BRISK(ptr);
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
                NativeMethods.features2d_Ptr_BRISK_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.features2d_Ptr_BRISK_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
