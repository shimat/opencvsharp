## File encoding

All source files in this repository use **UTF-8 with BOM** (`EF BB BF`).

When creating or editing files, always save them as UTF-8 with BOM. This applies to `.cs`, `.csproj`, `.yml`, `.md`, `.json`, and all other text files.

Do **not** save files as UTF-8 without BOM, ANSI, or Shift-JIS — doing so will corrupt Japanese content and break Visual Studio / MSBuild tooling.

### Verification

```powershell
# Check whether a file has UTF-8 BOM
$b = [System.IO.File]::ReadAllBytes("path\to\file")
$b[0] -eq 0xEF -and $b[1] -eq 0xBB -and $b[2] -eq 0xBF   # should be True

# Convert a file to UTF-8 with BOM
$enc = New-Object System.Text.UTF8Encoding $true
$content = [System.IO.File]::ReadAllText("path\to\file", [System.Text.Encoding]::UTF8)
[System.IO.File]::WriteAllText("path\to\file", $content, $enc)
```
