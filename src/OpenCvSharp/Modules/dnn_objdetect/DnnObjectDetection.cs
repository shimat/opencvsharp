namespace OpenCvSharp.DnnObjdetect;

/// <summary>A bounding box selected from SqueezeDet predictions.</summary>
public readonly record struct DnnObjectDetection(
    int XMin, int YMin, int XMax, int YMax,
    int ClassIndex, string Label, double Probability);
