# Copilot Instructions for OpenCvSharp

## File Encoding

All `.cs` source files in this repository **must** be UTF-8 with BOM (Byte Order Mark: `EF BB BF`).

When writing or rewriting files via PowerShell scripts, **never** use bare `Set-Content`.
Always use one of the following:

```powershell
# Option 1: .NET API (works in both PowerShell 5 and 7+)
$utf8bom = New-Object System.Text.UTF8Encoding $true
[System.IO.File]::WriteAllText($path, $text, $utf8bom)

# Option 2: PowerShell 7+ only
Set-Content $path $text -Encoding UTF8BOM -NoNewline
```

## NuGet README sync

When editing the root `README.md`, also update the NuGet-specific README files accordingly.

| File | Target packages |
|---|---|
| `nuget/README.managed.md` | `OpenCvSharp4`, `OpenCvSharp4.Windows`, `OpenCvSharp4.Windows.Slim`, `OpenCvSharp4.Extensions`, `OpenCvSharp4.WpfExtensions` |
| `nuget/README.runtime.md` | `OpenCvSharp4.runtime.*`, `OpenCvSharp4.official.runtime.*` (all native runtime packages) |

The NuGet READMEs are a subset of the top-level README and consist of the following sections:

- Overview and supported platforms
- Installation instructions (Quick Start)
- Requirements
- Slim profile module coverage table (`README.managed.md` only)
- Code usage examples (`README.managed.md` only)
- Links (GitHub, Samples, API Docs, Issue Tracker)

Do **not** include CI badges, Docker instructions, build instructions, or donation links in the NuGet READMEs.
