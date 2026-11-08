$ErrorActionPreference = 'Stop'
# A missing tag or release is expected on the first run. Check native exit codes explicitly.
$PSNativeCommandUseErrorActionPreference = $false

$releaseVersion = $env:RELEASE_VERSION
$sourceCommit = $env:GITHUB_SHA

# --target only applies to a new tag. Check an existing tag before using it.
$tagCommit = git rev-parse --verify --quiet "refs/tags/${releaseVersion}^{commit}"
if ($LASTEXITCODE -eq 0) {
    if ($tagCommit -cne $sourceCommit) {
        Write-Output "Tag $releaseVersion points to $tagCommit, expected $sourceCommit"
        exit 1
    }
    $isDraft = gh release view $releaseVersion --json isDraft --jq .isDraft
    if ($LASTEXITCODE -eq 0) {
        if ($isDraft -ceq 'false') {
            Write-Output "GitHub Release $releaseVersion already exists"
            exit 0
        }
        Write-Output "A draft already exists for $releaseVersion. Review and publish it on GitHub."
        exit 1
    }
}

# Stay on this commit's history and use the highest older stable 5.x tag.
$tags = git tag --merged $sourceCommit --sort=-version:refname --list '5.*'
if ($LASTEXITCODE -ne 0) {
    exit $LASTEXITCODE
}
$previousTag = $tags | Where-Object {
    $_ -cmatch '^5\.[0-9]+\.[0-9]+\.[0-9]{8}$' -and [version]$_ -lt [version]$releaseVersion
} | Select-Object -First 1
if (-not $previousTag) {
    Write-Output "No previous stable 5.x tag found in the history of $sourceCommit"
    exit 1
}

gh release create $releaseVersion --target $sourceCommit --generate-notes --notes-start-tag $previousTag
exit $LASTEXITCODE
