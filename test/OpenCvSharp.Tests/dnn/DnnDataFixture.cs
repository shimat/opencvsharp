using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenCvSharp.Dnn;
using Xunit;

namespace OpenCvSharp.Tests.Dnn
{
    public class CaffeData
    {
        public Net Net { get; }
        public IReadOnlyList<string> ClassNames { get; }

        public CaffeData(Net net, IReadOnlyList<string> classNames)
        {
            Net = net;
            ClassNames = classNames;
        }
    }
    
    public sealed class DnnDataFixture : IDisposable
    {
        public Lazy<CaffeData> Caffe { get; }

        public DnnDataFixture()
        {
            Caffe = new Lazy<CaffeData>(LoadCaffeModel);
        }

        public void Dispose()
        {
            if (Caffe.IsValueCreated)
            {
                Caffe.Value.Net.Dispose();
            }
        }

        private static CaffeData LoadCaffeModel()
        {
            const string protoTxt = @"_data/text/bvlc_googlenet.prototxt";
            const string caffeModelUrl = "https://drive.google.com/uc?id=1RUsoiLiXrKBQu9ibwsMqR3n_UkhnZLRR"; //"http://dl.caffe.berkeleyvision.org/bvlc_googlenet.caffemodel";
            const string caffeModel = "_data/model/bvlc_googlenet.caffemodel";
            const string synsetWords = @"_data/text/synset_words.txt";
            var classNames = File.ReadAllLines(synsetWords)
                .Select(line => line.Split(' ').Last())
                .ToArray();

            Console.WriteLine("Downloading Caffe Model...");
            ModelDownloader.DownloadAndSave(new Uri(caffeModelUrl), caffeModel);
            Console.WriteLine("Done");

            var net = CvDnn.ReadNetFromCaffe(protoTxt, caffeModel);
            Assert.NotNull(net);
            return new CaffeData(net!, classNames);
        }
    }
}
