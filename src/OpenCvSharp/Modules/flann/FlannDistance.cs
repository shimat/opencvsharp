namespace OpenCvSharp.Flann
{
#pragma warning disable 1591
#pragma warning disable CA1069
    // ReSharper disable InconsistentNaming
    
    public enum FlannDistance
    {
        Euclidean = 1,
        L2 = 1,
        Manhattan = 2,
        L1 = 2,
        // ReSharper disable once IdentifierTypo
        Minkowski = 3,
        Max = 4,
        HistIntersect = 5,
        // ReSharper disable once IdentifierTypo
        Hellinger = 6,
        ChiSquare = 7,
        CS = 7,
        // ReSharper disable once IdentifierTypo
        KullbackLeibler =  8,
        KL = 8,
        Hamming = 9,
    }
}
