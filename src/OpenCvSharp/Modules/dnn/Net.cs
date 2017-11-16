using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.Dnn
{
    /// <inheritdoc />
    /// <summary>
    /// This class allows to create and manipulate comprehensive artificial neural networks.
    /// </summary>
    /// <remarks>
    /// Neural network is presented as directed acyclic graph(DAG), where vertices are Layer instances,
    /// and edges specify relationships between layers inputs and outputs.
    /// 
    /// Each network layer has unique integer id and unique string name inside its network.
    /// LayerId can store either layer name or layer id.
    /// This class supports reference counting of its instances, i.e.copies point to the same instance.
    /// </remarks>
    public class Net : DisposableCvObject
    {
        /// <summary>
        /// 
        /// </summary>
        protected Net(IntPtr ptr)
        {
            this.ptr = ptr;
        }
        
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.dnn_Net_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// Reads a network model stored in Darknet (https://pjreddie.com/darknet/) model files.
        /// </summary>
        /// <param name="cfgFile">path to the .cfg file with text description of the network architecture.</param>
        /// <param name="darknetModel">path to the .weights file with learned network.</param>
        /// <returns>Network object that ready to do forward, throw an exception in failure cases.</returns>
        /// <remarks>This is shortcut consisting from DarknetImporter and Net::populateNet calls.</remarks>
        public static Net ReadNetFromDarknet(string cfgFile, string darknetModel = null)
        {
            if (cfgFile == null)
                throw new ArgumentNullException(nameof(cfgFile));

            IntPtr ptr = NativeMethods.dnn_readNetFromDarknet(cfgFile, darknetModel);
            return new Net(ptr);
        }

        /// <summary>
        /// Reads a network model stored in Caffe model files.
        /// </summary>
        /// <param name="prototxt"></param>
        /// <param name="caffeModel"></param>
        /// <returns></returns>
        /// <remarks>This is shortcut consisting from createCaffeImporter and Net::populateNet calls.</remarks>
        public static Net ReadNetFromCaffe(string prototxt, string caffeModel = null)
        {
            if (prototxt == null)
                throw new ArgumentNullException(nameof(prototxt));

            IntPtr ptr = NativeMethods.dnn_readNetFromCaffe(prototxt, caffeModel);
            return new Net(ptr);
        }

        /// <summary>
        /// Reads a network model stored in Tensorflow model file.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        /// <remarks>This is shortcut consisting from createTensorflowImporter and Net::populateNet calls.</remarks>
        public static Net ReadNetFromTensorflow(string model, string config = null)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            IntPtr ptr = NativeMethods.dnn_readNetFromTensorflow(model, config);
            return new Net(ptr);
        }

        /// <summary>
        /// Reads a network model stored in Torch model file.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isBinary"></param>
        /// <returns></returns>
        /// <remarks>This is shortcut consisting from createTorchImporter and Net::populateNet calls.</remarks>
        public static Net ReadNetFromTorch(string model, bool isBinary = true)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            IntPtr ptr = NativeMethods.dnn_readNetFromTorch(model, isBinary ? 1 : 0);
            return new Net(ptr);
        }
        
        /// <summary>
        /// Runs forward pass to compute output of layer with name @p outputName.
        /// By default runs forward pass for the whole network.
        /// </summary>
        /// <param name="outputName">name for layer which output is needed to get</param>
        /// <returns>blob for first output of specified layer.</returns>
        public Mat Forward(string outputName = null)
        {
            IntPtr ret = NativeMethods.dnn_Net_forward(ptr, outputName);
            GC.KeepAlive(this);
            return new Mat(ret);
        }

        /// <summary>
        /// Sets the new value for the layer output blob
        /// </summary>
        /// <param name="blob">new blob.</param>
        /// <param name="name">descriptor of the updating layer output blob.</param>
        /// <remarks>
        /// connect(String, String) to know format of the descriptor.
        /// If updating blob is not empty then @p blob must have the same shape, 
        /// because network reshaping is not implemented yet.
        /// </remarks>
        public void SetInput(Mat blob, string name = "")
        {
            if (blob == null)
                throw new ArgumentNullException(nameof(blob));

            NativeMethods.dnn_Net_setInput(ptr, blob.CvPtr, name);
            GC.KeepAlive(this);
        }
    }
}