using System.Text.Json.Nodes;
using Xunit;

namespace OpenCvSharp.Tests.Core;

public class FileStorageTest : TestBase
{
    private readonly ITestOutputHelper testOutputHelper;

    public FileStorageTest(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

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
            vec2b = new Vec2b(255, 128),
            rect = new Rect(1, 2, 3, 4),
            size = new Size(10, 20),
            point = new Point(300, 400)
        };

        // write
        using (var fs = new FileStorage(fileName, FileStorage.Modes.Write))
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
                .Add("vec2b").Add(mapSequence.vec2b)
                .Add("rect").Add(mapSequence.rect)
                .Add("}").Add("{")
                .Add("size").Add(mapSequence.size)
                .Add("point").Add(mapSequence.point)
                .Add("}")
                .Add("]");

            using (Mat r = Mat.Eye(3, 3, MatType.CV_64FC1))
            using (Mat t = Mat.Ones(3, 1, MatType.CV_64FC1))
            using (Mat lenna = LoadImage("lenna.png"))
            {
                fs.Write("R", r);
                fs.Write("T", t);
                fs.Write("lenna", lenna);
            }
        }

        Assert.True(File.Exists(fileName));

        // read
        using (var fs = new FileStorage(fileName, FileStorage.Modes.Read))
        {
            Assert.True(fs.IsOpened());
            Assert.Equal(FileStorage.Modes.FormatYaml, fs.GetFormat());

            // sequence
            using (var node = fs["sequence"])
            {
                Assert.NotNull(node);
#pragma warning disable CS8602

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
            using (var node = fs["empty_sequence"])
            {
                Assert.NotNull(node);
                Assert.Equal(FileNode.Types.Seq, node.Type);

                var children = node.ToArray();
                Assert.Empty(children);
            }

            // map
            using (var node = fs["map"])
            {
                Assert.NotNull(node);
                Assert.Equal(FileNode.Types.Map, node.Type);

                Assert.Equal(map.@int, node["int"].ReadInt());
                Assert.Equal(map.@double, node["double"].ReadDouble());
                Assert.Equal(map.@string, node["string"].ReadString());
                Assert.True(node.RawSize > 0);
            }
                
            // map_sequence
            using (var node = fs["map_sequence"])
            {
                Assert.NotNull(node);
                Assert.Equal(FileNode.Types.Seq, node.Type);

                using (var elem0 = node.ElementAt(0))
                using (var elem1 = node.ElementAt(1))
                {
                    Assert.Equal(mapSequence.vec2b, elem0["vec2b"].ReadVec2b());
                    Assert.Equal(mapSequence.rect, elem0["rect"].ReadRect());
                    Assert.Equal(mapSequence.size, elem1["size"].ReadSize());
                    Assert.Equal(mapSequence.point, elem1["point"].ReadPoint());
                }
            }

            // mat
            using (var rr = fs["R"])
            using (var tt = fs["T"])
            {
                Assert.NotNull(rr);
                Assert.NotNull(tt);
                using var r = rr.ReadMat();
                using var t = tt.ReadMat();
                testOutputHelper.WriteLine("R = {0}", r);
                testOutputHelper.WriteLine("T = {0}", t);

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

            using (var storedLenna = fs["lenna"]?.ReadMat())
            using (var lenna = LoadImage("lenna.png"))
            {
                Assert.NotNull(storedLenna);
#pragma warning disable CS8604
                ImageEquals(storedLenna, lenna);
#pragma warning restore CS8604 
            }

#pragma warning restore CS8602
        }
    }

    /// <summary>
    /// https://github.com/shimat/opencvsharp/issues/403
    /// https://docs.opencv.org/2.4/modules/core/doc/xml_yaml_persistence.html
    /// </summary>
    [Fact]
    public void ReadAndWriteInMemory()
    {
        var sequence = new[] { "image1.jpg", "myfi.png", "../data/baboon.jpg" };
        var map = new { @int = 12345, @double = 3.14159, @string = "foo" };
        var mapSequence = new
        {
            vec2b = new Vec2b(255, 128),
            rect = new Rect(1, 2, 3, 4),
            size = new Size(10, 20),
            point = new Point(300, 400)
        };

        // write
        string yaml;
        using (var fs = new FileStorage("yml", FileStorage.Modes.Write | FileStorage.Modes.Memory))
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
                .Add("vec2b").Add(mapSequence.vec2b)
                .Add("rect").Add(mapSequence.rect)
                .Add("}").Add("{")
                .Add("size").Add(mapSequence.size)
                .Add("point").Add(mapSequence.point)
                .Add("}")
                .Add("]");

            using (Mat r = Mat.Eye(3, 3, MatType.CV_64FC1))
            using (Mat t = Mat.Ones(3, 1, MatType.CV_64FC1))
            using (Mat lenna = LoadImage("lenna.png"))
            {
                fs.Write("R", r);
                fs.Write("T", t);
                fs.Write("lenna", lenna);
            }

            yaml = fs.ReleaseAndGetString();
        }

        // check truncation because of StringBuilder capacity
        Assert.EndsWith("]", yaml.TrimEnd(), StringComparison.Ordinal);

#pragma warning disable CS8602
#pragma warning disable CS8604
        // read
        using (var fs = new FileStorage(yaml, FileStorage.Modes.Read | FileStorage.Modes.Memory))
        {
            Assert.True(fs.IsOpened());

            // sequence
            using (FileNode? node = fs["sequence"])
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
            using (FileNode? node = fs["empty_sequence"])
            {
                Assert.NotNull(node);
                Assert.Equal(FileNode.Types.Seq, node.Type);

                var children = node.ToArray();
                Assert.Empty(children);
            }

            // map
            using (FileNode? node = fs["map"])
            {
                Assert.NotNull(node);
                Assert.Equal(FileNode.Types.Map, node.Type);

                Assert.Equal(map.@int, node["int"]?.ReadInt());
                Assert.Equal(map.@double, node["double"]?.ReadDouble());
                Assert.Equal(map.@string, node["string"]?.ReadString());
            }

            // map_sequence
            using (FileNode? node = fs["map_sequence"])
            {
                Assert.NotNull(node);
                Assert.Equal(FileNode.Types.Seq, node.Type);

                using (var elem0 = node.ElementAt(0))
                using (var elem1 = node.ElementAt(1))
                {
                    Assert.Equal(mapSequence.vec2b, elem0["vec2b"]?.ReadVec2b());
                    Assert.Equal(mapSequence.rect, elem0["rect"]?.ReadRect());
                    Assert.Equal(mapSequence.size, elem1["size"]?.ReadSize());
                    Assert.Equal(mapSequence.point, elem1["point"]?.ReadPoint());
                }
            }

            // mat
            using (var r = fs["R"]?.ReadMat())
            using (var t = fs["T"]?.ReadMat())
            {
                Assert.NotNull(r);
                Assert.NotNull(t);

                testOutputHelper.WriteLine("R = {0}", r);
                testOutputHelper.WriteLine("T = {0}", t);

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

            using (var storedLenna = fs["lenna"]?.ReadMat())
            using (var lenna = LoadImage("lenna.png"))
            {
                Assert.NotNull(storedLenna);
                ImageEquals(storedLenna, lenna);
            }
        }
#pragma warning restore CS8602
#pragma warning restore CS8604
    }

    [Fact]
    public void WriteBoolInt64AndStringArray()
    {
        const string fileName = "fs_bool_int64_strings.yml";
        string[] labels = ["cat", "dog", "bird"];

        using (var fs = new FileStorage(fileName, FileStorage.Modes.Write))
        {
            fs.Write("flagTrue", true);
            fs.Write("flagFalse", false);
            fs.Write("bigNumber", 9_000_000_000_000L);
            fs.Write("labels", labels);
        }

        using (var fs = new FileStorage(fileName, FileStorage.Modes.Read))
        {
            Assert.True(fs["flagTrue"]!.ReadInt() != 0);
            Assert.True(fs["flagFalse"]!.ReadInt() == 0);
            Assert.Equal(9_000_000_000_000L, fs["bigNumber"]!.ToInt64());
            Assert.Equal(9_000_000_000_000L, fs["bigNumber"]!.ReadInt64());

            using var labelsNode = fs["labels"];
            Assert.NotNull(labelsNode);
            Assert.Equal(FileNode.Types.Seq, labelsNode.Type);
            Assert.Equal(labels, labelsNode.Select(n => n.ReadString()));
        }
    }

    [Fact]
    public void KeysReturnsMappingKeys()
    {
        const string fileName = "fs_keys.yml";

        using (var fs = new FileStorage(fileName, FileStorage.Modes.Write))
        {
            fs.Write("alpha", 1);
            fs.Write("beta", 2);
            fs.Write("gamma", 3);
        }

        using (var fs = new FileStorage(fileName, FileStorage.Modes.Read))
        {
            using var root = fs.Root();
            Assert.NotNull(root);
            Assert.Equal(["alpha", "beta", "gamma"], root.Keys);
        }
    }

    [Fact]
    public void MissingKeyIndexerReturnsNull()
    {
        const string fileName = "fs_missing_key.yml";

        using (var fs = new FileStorage(fileName, FileStorage.Modes.Write))
        {
            fs.Write("present", 1);
        }

        using (var fs = new FileStorage(fileName, FileStorage.Modes.Read))
        {
            Assert.NotNull(fs["present"]);
            Assert.Null(fs["definitely_not_present"]);

            using var root = fs.Root();
            Assert.NotNull(root);
            Assert.Null(root["definitely_not_present"]);
        }
    }

    [Fact]
    public void WriteRawAndReadRawRoundTrip()
    {
        const string fileName = "fs_raw.yml";
        byte[] source = [1, 2, 3, 4, 5, 6, 7, 8];

        using (var fs = new FileStorage(fileName, FileStorage.Modes.Write))
        {
            fs.StartWriteStruct("raw", FileNode.Types.Seq | FileNode.Types.Flow);
            fs.WriteRaw("u", source.AsSpan());
            fs.EndWriteStruct();
        }

        using (var fs = new FileStorage(fileName, FileStorage.Modes.Read))
        {
            using var node = fs["raw"];
            Assert.NotNull(node);
            var buffer = new byte[source.Length];
            node.ReadRaw("u", buffer);
            Assert.Equal(source, buffer);
        }
    }

    [Fact]
    public void WriteStructScopeMatchesManualStartEnd()
    {
        const string fileName = "fs_write_struct_scope.yml";

        using (var fs = new FileStorage(fileName, FileStorage.Modes.Write))
        {
            using (fs.WriteStruct("camera", FileNode.Types.Map))
            {
                fs.Write("fx", 800.0);
                fs.Write("fy", 800.0);
            }
        }

        using (var fs = new FileStorage(fileName, FileStorage.Modes.Read))
        {
            using var camera = fs["camera"];
            Assert.NotNull(camera);
            Assert.Equal(FileNode.Types.Map, camera.Type);
            Assert.Equal(800.0, camera["fx"]!.ReadDouble());
            Assert.Equal(800.0, camera["fy"]!.ReadDouble());
        }
    }

    [Fact]
    public void WriteStructScopeDisposeIsIdempotent()
    {
        const string fileName = "fs_write_struct_scope_double_dispose.yml";

        using (var fs = new FileStorage(fileName, FileStorage.Modes.Write))
        {
            fs.Write("before", 1);

            // A double Dispose() (e.g. an explicit call inside a using block) must not end the
            // structure twice - otherwise it would unbalance FileStorage's write-struct nesting
            // and corrupt whatever comes after it, such as "after" below.
            var scope = fs.WriteStruct("camera", FileNode.Types.Map);
            fs.Write("fx", 800.0);
            scope.Dispose();
            scope.Dispose();

            fs.Write("after", 2);
        }

        using (var fs = new FileStorage(fileName, FileStorage.Modes.Read))
        {
            Assert.Equal(1, fs["before"]!.ReadInt());
            Assert.Equal(2, fs["after"]!.ReadInt());

            using var camera = fs["camera"];
            Assert.NotNull(camera);
            Assert.Equal(800.0, camera["fx"]!.ReadDouble());
        }
    }

    [Fact]
    public void ToJsonNodeConvertsScalarsSequencesAndMappings()
    {
        const string fileName = "fs_to_json_node.yml";

        using (var fs = new FileStorage(fileName, FileStorage.Modes.Write))
        {
            fs.Write("name", "widget");
            fs.Write("count", 3);
            fs.Write("ratio", 1.5);
            using (fs.WriteStruct("tags", FileNode.Types.Seq))
            {
                fs.Add("red").Add("green").Add("blue");
            }
            using (fs.WriteStruct("nested", FileNode.Types.Map))
            {
                fs.Write("enabled", true);
            }
        }

        using (var fs = new FileStorage(fileName, FileStorage.Modes.Read))
        {
            using var root = fs.Root();
            Assert.NotNull(root);
            var json = root.ToJsonNode();
            Assert.NotNull(json);

            Assert.Equal("widget", json!["name"]!.GetValue<string>());
            Assert.Equal(3L, json["count"]!.GetValue<long>());
            Assert.Equal(1.5, json["ratio"]!.GetValue<double>());

            var tags = Assert.IsType<JsonArray>(json["tags"]);
            Assert.Equal(["red", "green", "blue"], tags.Select(n => n!.GetValue<string>()));

            var nested = Assert.IsType<JsonObject>(json["nested"]);
            Assert.Equal(1L, nested["enabled"]!.GetValue<long>()); // bool round-trips as int (0/1) in FileStorage

            // The resulting tree is a plain JsonNode graph, usable with System.Text.Json as normal.
            var roundTripped = json.ToJsonString();
            Assert.Contains("widget", roundTripped, StringComparison.Ordinal);
        }
    }
}
