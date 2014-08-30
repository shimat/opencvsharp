using System;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// 
    /// </summary>
    class FileStorage
    {        
        public FileStorage()
        {
            const string fileNameImage = "images.xml";
            const string fileNameSeq = "sequence.yml";

            // writing test
            SampleFileStorageWriteImage(fileNameImage);
            SampleFileStorageReadImage(fileNameImage);

            // reading test
            SampleFileStorageWriteSeq(fileNameSeq);
            SampleFileStorageReadSeq(fileNameSeq);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        private static void SampleFileStorageWriteImage(string fileName)
        {
            // cvWrite, cvWriteComment

            using (IplImage colorImg = new IplImage(FilePath.Image.Lenna, LoadMode.Color))
            using (IplImage grayImg = new IplImage(colorImg.Size, BitDepth.U8, 1))
            {
                colorImg.CvtColor(grayImg, ColorConversion.BgrToGray);
                CvRect roi = new CvRect(0, 0, colorImg.Width / 2, colorImg.Height / 2);
                grayImg.SetROI(roi);
                colorImg.SetROI(roi);
                grayImg.Threshold(grayImg, 90, 255, ThresholdType.Binary);

                using (CvFileStorage fs = new CvFileStorage(fileName, null, FileStorageMode.Write))
                {
                    fs.WriteComment("This is a comment line.", false);
                    fs.Write("color_img", colorImg);
                    fs.StartNextStream();
                    fs.Write("gray_img", grayImg);
                }
            }
        }
        /// <summary>
        ///     
        /// </summary>
        /// <param name="fileName"></param>
        private static void SampleFileStorageReadImage(string fileName)
        {
            IplImage colorImg, grayImg;

            using (CvFileStorage fs = new CvFileStorage(fileName, null, FileStorageMode.Read))
            {
                CvFileNode node;
                node = fs.GetFileNodeByName(null, "color_img");
                colorImg = fs.Read<IplImage>(node);
                node = fs.GetFileNodeByName(null, "gray_img");
                grayImg = fs.Read<IplImage>(node);
            }

            CvRect roiColor = colorImg.GetROI();
            CvRect roiGray = grayImg.GetROI();
            colorImg.ResetROI();
            grayImg.ResetROI();
            colorImg.Rectangle(
                new CvPoint(roiColor.X, roiColor.Y),
                new CvPoint(roiColor.X + roiColor.Width, roiColor.Y + roiColor.Height),
                CvColor.Red
            );
            grayImg.Rectangle(
                new CvPoint(roiGray.X, roiGray.Y),
                new CvPoint(roiGray.X + roiGray.Width, roiGray.Y + roiGray.Height),
                CvColor.Black
            );

            using (new CvWindow("Color Image", WindowMode.AutoSize, colorImg)) 
            using (new CvWindow("Grayscale Image", WindowMode.AutoSize, grayImg))
            {
                Cv.WaitKey(0);
            }
            colorImg.Dispose();
            grayImg.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName">書きこむXML or YAMLファイル</param>
        private static void SampleFileStorageWriteSeq(string fileName)
        {
            // cvStartWriteStruct, cvEndWriteStruct

            const int size = 20;
            CvRNG rng = new CvRNG((ulong)DateTime.Now.Ticks);
            CvPoint[] pt = new CvPoint[size];

            for (int i = 0; i < pt.Length; i++)
            {
                pt[i].X = (int)rng.RandInt(100);
                pt[i].Y = (int)rng.RandInt(100);
            }

            using (CvFileStorage fs = new CvFileStorage(fileName, null, FileStorageMode.Write))
            {
                fs.StartWriteStruct("points", NodeType.Seq);
                for (int i = 0; i < pt.Length; i++)
                {
                    fs.StartWriteStruct(null, NodeType.Map | NodeType.Flow);
                    fs.WriteInt("x", pt[i].X);
                    fs.WriteInt("y", pt[i].Y);
                    fs.EndWriteStruct();
                }
                fs.EndWriteStruct();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        private static void SampleFileStorageReadSeq(string fileName)
        {
            // cvGetHashedKey, cvGetFileNode

            using (CvFileStorage fs = new CvFileStorage("sequence.yml", null, FileStorageMode.Read))
            {
                CvStringHashNode xKey = fs.GetHashedKey("x", true);
                CvStringHashNode yKey = fs.GetHashedKey("y", true);
                CvFileNode points = fs.GetFileNodeByName(null, "points");

                if ((points.Tag & NodeType.Seq) != 0)
                {
                    CvSeq seq = points.DataSeq;
                    int total = seq.Total;
                    CvSeqReader reader = new CvSeqReader();
                    seq.StartRead(reader, false);
                    for (int i = 0; i < total; i++)
                    {
                        CvFileNode pt = CvFileNode.FromPtr(reader.Ptr);
                        int x = fs.ReadIntByName(pt, "x", 0);
                        int y = fs.ReadIntByName(pt, "y", 0);

                        Cv.NEXT_SEQ_ELEM(seq.ElemSize, reader);
                        Console.WriteLine("{0}: ({1}, {2})", i, x, y);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
