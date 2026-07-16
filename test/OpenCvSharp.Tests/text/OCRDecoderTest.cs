using OpenCvSharp.Text;
using Xunit;

namespace OpenCvSharp.Tests.Text;

// ReSharper disable InconsistentNaming
public class OCRDecoderTest : TestBase
{
    [Fact]
    public void CreateOCRHMMTransitionsTable()
    {
        var lexicon = new[] { "cat", "car", "cart", "dog", "dot" };

        using var table = Cv2.Text.CreateOCRHMMTransitionsTable("abcdgort", lexicon);

        Assert.False(table.Empty());
        Assert.Equal(8, table.Rows);
        Assert.Equal(8, table.Cols);
    }

    [Fact]
    public void OCRHMMDecoderCreate_MissingFile_Throws()
    {
        using var transitionTable = Mat.Eye(2, 2, MatType.CV_64FC1).ToMat();
        using var emissionTable = Mat.Eye(2, 2, MatType.CV_64FC1).ToMat();

        Assert.ThrowsAny<Exception>(() =>
            OCRHMMDecoder.Create("_data/text/no_such_hmm_classifier.xml", "ab", transitionTable, emissionTable));
    }

    [Fact]
    public void OCRHMMDecoderLoadClassifier_MissingFile_Throws()
    {
        Assert.ThrowsAny<Exception>(() =>
            OCRHMMDecoderClassifierCallback.LoadClassifier("_data/text/no_such_hmm_classifier.xml", ClassifierType.Knn));
    }

    [Fact]
    public void OCRBeamSearchDecoderCreate_MissingFile_Throws()
    {
        using var transitionTable = Mat.Eye(2, 2, MatType.CV_64FC1).ToMat();
        using var emissionTable = Mat.Eye(2, 2, MatType.CV_64FC1).ToMat();

        Assert.ThrowsAny<Exception>(() =>
            OCRBeamSearchDecoder.Create("_data/text/no_such_beamsearch_classifier.xml", "ab", transitionTable, emissionTable));
    }

    [Fact]
    public void OCRBeamSearchDecoderLoadClassifier_MissingFile_Throws()
    {
        Assert.ThrowsAny<Exception>(() =>
            OCRBeamSearchDecoderClassifierCallback.LoadClassifierCNN("_data/text/no_such_beamsearch_classifier.xml"));
    }

    [Fact]
    public void OCRHolisticWordRecognizerCreate_MissingFile_Throws()
    {
        Assert.ThrowsAny<Exception>(() =>
            OCRHolisticWordRecognizer.Create(
                "_data/text/no_such_arch.prototxt", "_data/text/no_such_weights.caffemodel", "_data/text/no_such_words.txt"));
    }
}
