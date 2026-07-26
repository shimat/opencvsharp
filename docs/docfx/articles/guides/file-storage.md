# File Storage

OpenCV `FileStorage` reads and writes matrices, scalars, sequences, and mappings in YAML, XML, or JSON. It is useful for calibration data and OpenCV-compatible model parameters. For ordinary application configuration, a .NET serializer may provide a more natural object model.

## Write values and a matrix

The file extension selects the format:

```csharp
using Mat transform = Mat.Eye(3, 3, MatType.CV_64FC1);

using var storage = new FileStorage("settings.yml", FileStorage.Modes.Write);
if (!storage.IsOpened())
{
    throw new IOException("Could not open settings.yml for writing.");
}

storage.Write("threshold", 128);
storage.Write("name", "example");
storage.Write("transform", transform);
```

Use `.xml`, `.yml` or `.yaml`, and `.json` for the corresponding formats. Append `.gz` to write or read a compressed XML or YAML file.

## Read values and a matrix

`FileStorage` indexers return `FileNode` objects that own native resources. Dispose each node after reading it:

```csharp
using var storage = new FileStorage("settings.yml", FileStorage.Modes.Read);
if (!storage.IsOpened())
{
    throw new IOException("Could not open settings.yml.");
}

using var thresholdNode = storage["threshold"]
    ?? throw new InvalidDataException("Missing threshold.");
using var nameNode = storage["name"]
    ?? throw new InvalidDataException("Missing name.");
using var transformNode = storage["transform"]
    ?? throw new InvalidDataException("Missing transform.");

int threshold = thresholdNode.ReadInt();
string name = nameNode.ReadString();
using Mat transform = transformNode.ReadMat();
```

The returned `Mat` owns its native data and must also be disposed.

## Work with an in-memory document

Combine `Modes.Memory` with the write or read mode:

```csharp
string yaml;
using (var writer = new FileStorage("yml", FileStorage.Modes.Write | FileStorage.Modes.Memory))
{
    writer.Write("answer", 42);
    yaml = writer.ReleaseAndGetString();
}

using var reader = new FileStorage(yaml, FileStorage.Modes.Read | FileStorage.Modes.Memory);
using var answerNode = reader["answer"]
    ?? throw new InvalidDataException("Missing answer.");
int answer = answerNode.ReadInt();
```

When writing in memory, the first constructor argument identifies the output format rather than a file path.

## Use FileStorage with System.Text.Json

OpenCvSharp adds two .NET-specific bridges that are not part of the native OpenCV API:

- `FileNode.ToJsonNode()` converts a node and its descendants to a managed `JsonNode` tree.
- `FileStorage.Write(string, JsonNode?)` writes a managed JSON tree through OpenCV's XML, YAML, or JSON storage engine.

This lets `System.Text.Json` serialize and deserialize ordinary .NET models while `FileStorage` retains compatibility with OpenCV documents. The following example round-trips a record through an OpenCV YAML file:

```csharp
using OpenCvSharp;
using System.Text.Json;
using System.Text.Json.Nodes;

var original = new CameraSettings(
    Name: "front",
    Width: 1920,
    Height: 1080,
    DistortionCoefficients: [0.12, -0.34, 0.001, 0.002]);

JsonNode settingsJson = JsonSerializer.SerializeToNode(original)
    ?? throw new JsonException("Could not serialize camera settings.");

using (var writer = new FileStorage("camera.yml", FileStorage.Modes.Write))
{
    if (!writer.IsOpened())
    {
        throw new IOException("Could not open camera.yml for writing.");
    }

    writer.Write("camera", settingsJson);
}

CameraSettings restored;
using (var reader = new FileStorage("camera.yml", FileStorage.Modes.Read))
{
    if (!reader.IsOpened())
    {
        throw new IOException("Could not open camera.yml.");
    }

    using var cameraNode = reader["camera"]
        ?? throw new InvalidDataException("Missing camera settings.");
    JsonNode cameraJson = cameraNode.ToJsonNode()
        ?? throw new InvalidDataException("Camera settings are empty.");

    restored = cameraJson.Deserialize<CameraSettings>()
        ?? throw new JsonException("Could not deserialize camera settings.");
}

public sealed record CameraSettings(
    string Name,
    int Width,
    int Height,
    double[] DistortionCoefficients);
```

The returned `JsonNode` tree is fully managed and remains usable after its `FileNode` and `FileStorage` have been disposed. Conversion is structural: an OpenCV `Mat` becomes an object containing its `rows`, `cols`, `dt`, and `data` representation rather than a managed `Mat`. Use `FileNode.ReadMat()` when the destination should remain a `Mat`.

OpenCV `FileStorage` has no explicit null scalar, so `FileStorage.Write` rejects JSON null values. Boolean values also round-trip through native `FileStorage` as the integers `0` and `1`; account for that when deserializing a model with Boolean properties.

## Nested data

`FileStorage.Add` writes sequences and mappings using OpenCV's streaming syntax. `FileStorage.GetPath` reads a nested path while disposing intermediate `FileNode` instances. Prefer `GetPath` over a long indexer chain when reading nested data.

## Official OpenCV references

- [File input and output using XML, YAML, and JSON](https://docs.opencv.org/5.0/tutorials/core/file_input_output_with_xml_yml/file_input_output_with_xml_yml.html)

## Related API

- [FileStorage](xref:OpenCvSharp.FileStorage)
- [FileNode](xref:OpenCvSharp.FileNode)
