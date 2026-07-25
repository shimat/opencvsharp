# File Storage

OpenCV `FileStorage` reads and writes matrices, scalars, sequences, and mappings in YAML, XML, or JSON. It is useful for calibration data and OpenCV-compatible model parameters. For ordinary application configuration, a .NET serializer may provide a more natural object model.

## Write values and a matrix

The file extension selects the format:

```csharp
using Mat transform = Mat.Eye(3, 3, MatType.CV_64FC1);

using var storage = new FileStorage("settings.yml", FileStorage.Modes.Write);
if (!storage.IsOpened())
{
    throw new InvalidOperationException("Could not open settings.yml for writing.");
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
    throw new InvalidOperationException("Could not open settings.yml.");
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

## Nested data

`FileStorage.Add` writes sequences and mappings using OpenCV's streaming syntax. `FileStorage.GetPath` reads a nested path while disposing intermediate `FileNode` instances. Prefer `GetPath` over a long indexer chain when reading nested data.

## Related API

- [FileStorage](xref:OpenCvSharp.FileStorage)
- [FileNode](xref:OpenCvSharp.FileNode)
