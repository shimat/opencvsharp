$ErrorActionPreference = 'Stop'

$packages = Get-ChildItem -LiteralPath . -File |
    Where-Object { $_.Name -cmatch '-beta.*\.s?nupkg$' } |
    Sort-Object Extension, Name

foreach ($package in $packages) {
    if ($package.Name -cnotmatch '^OpenCvSharp5\..*[0-9]{8}-beta[0-9]*\.s?nupkg$') {
        Write-Output "ERROR: Unexpected -beta package file name: $($package.Name)"
        exit 1
    }

    $archive = [System.IO.Compression.ZipFile]::Open($package.FullName, 'Update')
    try {
        $nuspecs = @($archive.Entries | Where-Object { $_.FullName -clike '*.nuspec' })
        if ($nuspecs.Count -gt 1) {
            throw "Multiple .nuspec entries in $($package.Name)"
        }
        if ($nuspecs.Count -eq 1) {
            $entry = $nuspecs[0]
            $entryName = $entry.Name
            # Use a byte-preserving encoding because the replacements only touch ASCII.
            $encoding = [System.Text.Encoding]::Latin1
            $reader = [System.IO.StreamReader]::new($entry.Open(), $encoding, $false)
            try {
                $nuspec = $reader.ReadToEnd()
            } finally {
                $reader.Dispose()
            }

            # Strip the package's own beta suffix and, except for ubuntu packages, dependency suffixes.
            $nuspec = $nuspec -creplace '(?m)^([^\r\n]*?)-beta-?[0-9]*(</version>)', '$1$2'
            if ($package.Name -cnotlike '*ubuntu*') {
                $nuspec = $nuspec -creplace '(version="[0-9]{1,2}\.[0-9]{1,2}\.[0-9]{1,2}\.[0-9]{8})-beta-?[0-9]*', '$1'
            }

            $entry.Delete()
            $writer = [System.IO.StreamWriter]::new($archive.CreateEntry($entryName).Open(), $encoding)
            try {
                $writer.Write($nuspec)
            } finally {
                $writer.Dispose()
            }
        }
    } finally {
        $archive.Dispose()
    }

    $newName = [regex]::new('-beta-?[0-9]*').Replace($package.Name, '', 1)
    Move-Item -LiteralPath $package.FullName -Destination (Join-Path $package.DirectoryName $newName) -Force
}
