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
