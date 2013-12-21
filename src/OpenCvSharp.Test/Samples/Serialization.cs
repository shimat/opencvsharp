using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using OpenCvSharp;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// Binary Serialization
    /// </summary>
    class Serialization
    {
        public Serialization()
        {
            const string FileName = "serialization.dat";

            IplImage imgWrite = new IplImage(Const.ImageFruits, LoadMode.Color);
            IplImage imgRead;

            using (FileStream fs = new FileStream(FileName, FileMode.Create))
            {                
                BinaryFormatter bf = new BinaryFormatter();                
                bf.Serialize(fs, imgWrite);                
            }

            FileInfo info = new FileInfo(FileName);
            Console.WriteLine("{0} filesize:{1}bytes", info.Name, info.Length);
            
            using (FileStream fs = new FileStream(FileName, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                imgRead = (IplImage)bf.Deserialize(fs);                
            }

            Console.WriteLine("Source:      width:{0} height:{1} depth:{2} channels:{3} imagesize:{4}",
                    imgWrite.Width, imgWrite.Height, imgWrite.Depth, imgWrite.NChannels, imgWrite.ImageSize);
            Console.WriteLine("Deserialize: width:{0} height:{1} depth:{2} channels:{3} imagesize:{4}",
                    imgRead.Width, imgRead.Height, imgRead.Depth, imgRead.NChannels, imgRead.ImageSize);            

            using (new CvWindow("Source Image", imgWrite))
            using (new CvWindow("Deserialized Image", imgRead))
            {
                Cv.WaitKey();
            }
        }
    }
}