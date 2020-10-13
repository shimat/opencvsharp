using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenCvSharp.Dnn;

namespace OpenCvSharp.Tests.dnn
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
        private static readonly object lockObj = new object();

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
            PrepareModel(new Uri(caffeModelUrl), caffeModel);
            Console.WriteLine("Done");

            var net = CvDnn.ReadNetFromCaffe(protoTxt, caffeModel);
            return new CaffeData(net, classNames);
        }

        /// <summary>
        /// Download model file
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="fileName"></param>
        private static void PrepareModel(Uri uri, string fileName)
        {
            lock (lockObj)
            {
                if (File.Exists(fileName)) 
                    return;

                int beforePercent = 0;
                var contents = DownloadBytes(uri, progress =>
                {
                    if (progress.ProgressPercentage == beforePercent)
                        return;
                    beforePercent = progress.ProgressPercentage;
                    Console.WriteLine("[{0}] Download Progress: {1}/{2} ({3}%)",
                        fileName,
                        progress.BytesReceived,
                        progress.TotalBytesToReceive,
                        progress.ProgressPercentage);
                });
                File.WriteAllBytes(fileName, contents);
            }
        }

        private static byte[] DownloadBytes(
            Uri uri, 
            Action<(long BytesReceived, long TotalBytesToReceive, int ProgressPercentage)>? downloadProgressChangedEvent = null)
        {
            using var client = new MyWebClient();
            if (downloadProgressChangedEvent == null)
            {
                return client.DownloadData(uri);
            }

            var task = client.DownloadDataTaskAsync(
                uri,
                new Progress<(long BytesReceived, long TotalBytesToReceive, int ProgressPercentage)>(downloadProgressChangedEvent));
            return task.Result;
            //var response = (httpClient.GetAsync(uri).Result).EnsureSuccessStatusCode();
            //return response.Content.ReadAsByteArrayAsync().Result;
        }
    }
}
