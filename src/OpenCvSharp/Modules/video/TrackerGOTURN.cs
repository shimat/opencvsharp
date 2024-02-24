using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <inheritdoc />
/// <summary>
/// GOTURN (@cite GOTURN) is kind of trackers based on Convolutional Neural Networks (CNN). 
/// </summary>
/// <remarks>
/// * While taking all advantages of CNN trackers, GOTURN is much faster due to offline training without online fine-tuning nature.
/// * GOTURN tracker addresses the problem of single target tracking: given a bounding box label of an object in the first frame of the video,
/// 
/// * we track that object through the rest of the video.NOTE: Current method of GOTURN does not handle occlusions; however, it is fairly
/// * robust to viewpoint changes, lighting changes, and deformations.
/// 
/// * Inputs of GOTURN are two RGB patches representing Target and Search patches resized to 227x227.
/// * Outputs of GOTURN are predicted bounding box coordinates, relative to Search patch coordinate system, in format X1, Y1, X2, Y2.
/// * Original paper is here: [http://davheld.github.io/GOTURN/GOTURN.pdf]
/// * As long as original authors implementation: [https://github.com/davheld/GOTURN#train-the-tracker]
/// * Implementation of training algorithm is placed in separately here due to 3d-party dependencies:
/// *  [https://github.com/Auron-X/GOTURN_Training_Toolkit]
/// * GOTURN architecture goturn.prototxt and trained model goturn.caffemodel are accessible on opencv_extra GitHub repository.
/// </remarks>
// ReSharper disable once InconsistentNaming
public class TrackerGOTURN : Tracker
{
    /// <summary>
    /// 
    /// </summary>
    protected TrackerGOTURN(IntPtr p)
        : base(new Ptr(p))
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <returns></returns>
    public static TrackerGOTURN Create()
    {
        NativeMethods.HandleException(
            NativeMethods.video_TrackerGOTURN_create1(out var p));
        return new TrackerGOTURN(p);
    }

    // TODO
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="parameters">GOTURN parameters</param>
    /// <returns></returns>
    public static TrackerGOTURN Create(Params parameters)
    {
        unsafe
        {
            NativeMethods.HandleException(
                NativeMethods.video_TrackerGOTURN_create2(&parameters, out var p));
            return new TrackerGOTURN(p);
        }
    }
        
    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.video_Ptr_TrackerGOTURN_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.video_Ptr_TrackerGOTURN_delete(ptr));
            base.DisposeUnmanaged();
        }
    }

#pragma warning disable CA1034
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Params
    {
    }
}
