using OpenCvSharp.Dnn;
using Xunit;

namespace OpenCvSharp.Tests.Dnn;

// High-level dnn Model API smoke tests.
// These verify the native P/Invoke wiring (constructors, base setters, destructors)
// without requiring a downloaded model file.
public class ModelTest : TestBase
{
    [Fact]
    public void ModelFromNetAndSetParams()
    {
        using var net = new Net();
        using var model = new Model(net);

        model.SetInputSize(new Size(224, 224));
        model.SetInputSize(224, 224);
        model.SetInputMean(new Scalar(104, 117, 123));
        model.SetInputScale(new Scalar(1.0 / 255));
        model.SetInputCrop(false);
        model.SetInputSwapRB(true);
        model.SetInputParams(1.0 / 255, new Size(224, 224), new Scalar(0, 0, 0), true, false);
    }

    [Fact]
    public void ClassificationModelLifecycle()
    {
        using var net = new Net();
        using var model = new ClassificationModel(net);

        model.SetEnableSoftmaxPostProcessing(true);
        Assert.True(model.GetEnableSoftmaxPostProcessing());
        model.SetEnableSoftmaxPostProcessing(false);
        Assert.False(model.GetEnableSoftmaxPostProcessing());

        model.SetInputParams(1.0, new Size(224, 224));
    }

    [Fact]
    public void DetectionModelLifecycle()
    {
        using var net = new Net();
        using var model = new DetectionModel(net);

        model.SetNmsAcrossClasses(true);
        Assert.True(model.GetNmsAcrossClasses());
        model.SetNmsAcrossClasses(false);
        Assert.False(model.GetNmsAcrossClasses());

        model.SetInputParams(1.0 / 255, new Size(416, 416), new Scalar(), true);
    }

    [Fact]
    public void SegmentationModelLifecycle()
    {
        using var net = new Net();
        using var model = new SegmentationModel(net);
        model.SetInputParams(1.0, new Size(513, 513));
    }

    [Fact]
    public void KeypointsModelLifecycle()
    {
        using var net = new Net();
        using var model = new KeypointsModel(net);
        model.SetInputParams(1.0 / 255, new Size(368, 368));
    }
}
