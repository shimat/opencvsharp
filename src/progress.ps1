$files = [System.IO.Directory]::GetFiles([System.IO.Path]::Combine($PSScriptRoot, "OpenCvSharpExtern"), "*.h")

$allTotalCount = 0
$allSupportedCount = 0
$defaultColor = [System.Console]::ForegroundColor

foreach ($f in $files){
    $lines = [System.IO.File]::ReadAllLines($f)

    $totalCount = 0
    $supportedCount = 0
    
    foreach ($line in $lines){
        if ($line.StartsWith("CVAPI")){
            $totalCount += 1
            if ($line.StartsWith("CVAPI(ExceptionStatus)"))
            {
                $supportedCount += 1
            }
        }
    }

    $allTotalCount += $totalCount
    $allSupportedCount += $supportedCount

    if ($totalCount -gt 0){
        if ($supportedCount -eq $totalCount){
            [System.Console]::ForegroundColor = [System.ConsoleColor]::Green
        }elseif ($supportedCount -eq 0){
            [System.Console]::ForegroundColor = [System.ConsoleColor]::Red
        }else{
            [System.Console]::ForegroundColor = $defaultColor
        }
        [System.Console]::Write("{0}: ", $f)
        [System.Console]::WriteLine("{0}/{1} {2:P2}", $supportedCount, $totalCount, [double]$supportedCount/$totalCount)
    }
}

[System.Console]::ForegroundColor = $defaultColor

if ($allTotalCount -gt 0){
    [System.Console]::WriteLine("")
    [System.Console]::WriteLine("Summary: {0}/{1} {2:P2}", $allSupportedCount, $allTotalCount, [double]$allSupportedCount/$allTotalCount)
    [System.Console]::WriteLine("")
}