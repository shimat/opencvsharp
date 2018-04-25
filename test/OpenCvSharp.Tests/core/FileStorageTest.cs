using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using OpenCvSharp.ML;
using Xunit;

namespace OpenCvSharp.Tests.Core
{
    public class FileStorageTest : TestBase
    {
        [Fact]
        public void Issue403()
        {
            const string fileName = "fs.yml";

            // write
            using (var fs = new FileStorage(fileName, FileStorage.Mode.Write))
            {
                fs.Add("sequence").Add("[")
                    .Add("image1.jpg")
                    .Add("myfi.png")
                    .Add("../data/baboon.jpg")
                    .Add("]");

                fs.Add("map").Add("{")
                    .Add("int").Add(12345)
                    .Add("double").Add(3.14159)
                    .Add("string").Add("foo")
                    .Add("}");

                fs.Add("map_sequence").Add("[")
                    .Add("{:")
                    .Add("float").Add(1.2345f)
                    .Add("rect").Add(new Rect(4,3,2,1))
                    .Add("}")/*.Add("{:")
                    .Add("size").Add(new Size(10, 20))
                    .Add("point").Add(new Point(300, 400))
                    .Add("}")*/
                    .Add("]");

                using (Mat r = Mat.Eye(3, 3, MatType.CV_64FC1))
                using (Mat t = Mat.Ones(3, 1, MatType.CV_64FC1))
                {
                    fs.Write("R", r);
                    fs.Write("T", t);
                }
            }

            Assert.True(File.Exists(fileName));

            // read
            using (var fs = new FileStorage(fileName, FileStorage.Mode.Read))
            {
                Assert.True(fs.IsOpened());

                FileNode n = fs["images"];
                
                //Assert.Equal(FileNode.Types.SEQ, n.Type);
                /*
                Console.WriteLine("reading images");
                FileNodeIterator it = n.begin(), it_end = n.end();
                for (; it != it_end; ++it)
                {
                    cout << (string)*it << "\n";
                }*/

                Mat r = fs["R"].ReadMat();
                Mat t = fs["T"].ReadMat();
                Console.WriteLine("R = {0}", r.ToString());
                Console.WriteLine("T = {0}", t.ToString());
            }
        }

        struct MyData
        {
            public int A { get; set; }
            public byte B { get; set; }
            public double C { get; set; }

            public override string ToString()
            {
                return $"A={A}, B={B}, C={C}";
            }
        }
    }
}

