namespace OpenCvSharp.Dpm;

/// <summary>A detection returned by a deformable part model.</summary>
public readonly record struct DpmObjectDetection(Rect Rect, float Score, int ClassId);
