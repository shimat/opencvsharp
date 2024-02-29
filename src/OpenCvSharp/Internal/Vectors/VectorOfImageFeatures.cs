using OpenCvSharp.Detail;

namespace OpenCvSharp.Internal.Vectors;

/// <summary> 
/// </summary>
public class VectorOfImageFeatures : DisposableCvObject, IStdVector<ImageFeatures>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfImageFeatures()
    {
        ptr = NativeMethods.vector_ImageFeatures_new1();
    }
        
    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.vector_ImageFeatures_delete(ptr);
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// vector.size()
    /// </summary>
    public int Size
    {
        get
        {
            var res = NativeMethods.vector_ImageFeatures_getSize(ptr);
            GC.KeepAlive(this);
            return (int)res;
        }
    }
        
    /// <summary>
    /// Converts std::vector to managed array
    /// </summary>
    /// <returns></returns>
    public ImageFeatures[] ToArray()
    {
        var size = Size;
        if (size == 0)
            return Array.Empty<ImageFeatures>();
            
        VectorOfKeyPoint[]? keypointsVecs = null;
        Mat[]? descriptors = null;
        try
        {
            var nativeResult = new WImageFeatures[size];
            keypointsVecs = new VectorOfKeyPoint[size];
            descriptors = new Mat[size];
            for (int i = 0; i < size; i++)
            {
                keypointsVecs[i] = new VectorOfKeyPoint();
                descriptors[i] = new Mat();
                nativeResult[i].Keypoints = keypointsVecs[i].CvPtr;
                nativeResult[i].Descriptors = descriptors[i].CvPtr;
            }

            NativeMethods.vector_ImageFeatures_getElements(ptr, nativeResult);

            var result = new ImageFeatures[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = new ImageFeatures(
                    imgIdx: nativeResult[i].ImgIdx,
                    imgSize: nativeResult[i].ImgSize,
                    keypoints: keypointsVecs[i].ToArray(),
                    descriptors: descriptors[i]);
            }

            // ElemPtr is IntPtr to memory held by this object, so make sure we are not disposed until finished with copy.
            GC.KeepAlive(this);
            return result;
        }
        catch
        {
            if (descriptors is not null)
            {
                foreach (var mat in descriptors)
                {
                    mat.Dispose();
                }
            }

            throw;
        }
        finally
        {
#pragma warning disable CA1508 // (???) Avoid dead conditional code
            if (keypointsVecs is not null)
            {
                foreach (var vec in keypointsVecs)
                {
                    vec.Dispose();
                }
            }
#pragma warning restore CA1508
        }
    }

    private int[] KeypointsSizes(int size)
    {
        var ret = new nuint[size];
        NativeMethods.vector_ImageFeatures_getKeypointsSize(ptr, ret);
        GC.KeepAlive(this);
        return ret.Select(v => (int)v).ToArray();
    }
}
