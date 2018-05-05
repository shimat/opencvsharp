using System;
using System.IO;
using System.Linq;
using Xunit;

namespace OpenCvSharp.Tests.Core
{
    public class FileStorageTest : TestBase
    {
        /// <summary>
        /// https://github.com/shimat/opencvsharp/issues/403
        /// https://docs.opencv.org/2.4/modules/core/doc/xml_yaml_persistence.html
        /// </summary>
        [Fact]
        public void ReadAndWrite()
        {
            const string fileName = "fs.yml";

            var sequence = new[] {"image1.jpg", "myfi.png", "../data/baboon.jpg"};
            var map = new {@int = 12345, @double = 3.14159, @string = "foo"};
            var mapSequence = new {
                vec3b = new Vec2b(255, 128/*, 0*/),
                rect = new Rect(1, 2, 3, 4),
                size = new Size(10, 20),
                point = new Point(300, 400)
            };

            // write
            using (var fs = new FileStorage(fileName, FileStorage.Mode.Write))
            {
                fs.Add("sequence").Add("[");
                foreach (var s in sequence)
                {
                    fs.Add(s);
                }
                fs.Add("]");

                fs.Add("empty_sequence").Add("[").Add("]");

                fs.Add("map").Add("{")
                    .Add("int").Add(map.@int)
                    .Add("double").Add(map.@double)
                    .Add("string").Add(map.@string)
                    .Add("}");

                fs.Add("map_sequence").Add("[")
                    .Add("{")
                    .Add("vec3b").Add(mapSequence.vec3b)
                    .Add("rect").Add(mapSequence.rect)
                    .Add("}").Add("{")
                    .Add("size").Add(mapSequence.size)
                    .Add("point").Add(mapSequence.point)
                    .Add("}")
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

                // sequence
                using (FileNode node = fs["sequence"])
                {
                    Assert.NotNull(node);
                    Assert.Equal(FileNode.Types.Seq, node.Type);

                    // C++ style sequence reading 
                    FileNodeIterator it = node.Begin(), end = node.End();
                    for (int i = 0;
                        !it.Equals(end);
                        it.MoveNext(), i++)
                    {
                        var s = it.Current.ReadString();
                        Assert.Equal(sequence[i], s);
                    }

                    // C# style
                    int j = 0;
                    foreach (var n in node)
                    {
                        var s = n.ReadString();
                        Assert.Equal(sequence[j++], s);
                    }
                }

                // empty_sequence
                using (FileNode node = fs["empty_sequence"])
                {
                    Assert.NotNull(node);
                    Assert.Equal(FileNode.Types.Seq, node.Type);

                    var children = node.ToArray();
                    Assert.Empty(children);
                }

                // map
                using (FileNode node = fs["map"])
                {
                    Assert.NotNull(node);
                    Assert.Equal(FileNode.Types.Map, node.Type);

                    Assert.Equal(map.@int, node["int"].ReadInt());
                    Assert.Equal(map.@double, node["double"].ReadDouble());
                    Assert.Equal(map.@string, node["string"].ReadString());
                }

                // map_sequence
                using (FileNode node = fs["map_sequence"])
                {
                    Assert.NotNull(node);
                    Assert.Equal(FileNode.Types.Seq, node.Type);

                    using (var elem0 = node.ElementAt(0))
                    using (var elem1 = node.ElementAt(1))
                    {
                        Assert.Equal(mapSequence.vec3b, elem0["vec3b"].ReadVec2b());
                        Assert.Equal(mapSequence.rect, elem0["rect"].ReadRect());
                        Assert.Equal(mapSequence.size, elem1["size"].ReadSize());
                        Assert.Equal(mapSequence.point, elem1["point"].ReadPoint());
                    }
                }

                // mat
                using (Mat r = fs["R"].ReadMat())
                using (Mat t = fs["T"].ReadMat())
                {
                    Console.WriteLine("R = {0}", r);
                    Console.WriteLine("T = {0}", t);

                    Assert.Equal(1.0, r.Get<double>(0, 0));
                    Assert.Equal(0.0, r.Get<double>(0, 1));
                    Assert.Equal(0.0, r.Get<double>(0, 2));
                    Assert.Equal(0.0, r.Get<double>(1, 0));
                    Assert.Equal(1.0, r.Get<double>(1, 1));
                    Assert.Equal(0.0, r.Get<double>(1, 2));
                    Assert.Equal(0.0, r.Get<double>(2, 0));
                    Assert.Equal(0.0, r.Get<double>(2, 1));
                    Assert.Equal(1.0, r.Get<double>(2, 2));

                    Assert.Equal(1.0, t.Get<double>(0));
                    Assert.Equal(1.0, t.Get<double>(1));
                    Assert.Equal(1.0, t.Get<double>(2));
                }
            }
        }
    }
}

