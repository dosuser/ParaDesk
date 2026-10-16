#Requires -Version 5.1
[CmdletBinding()]
param()

$ErrorActionPreference = 'Stop'
if ($env:GITHUB_ACTIONS -ne 'true' -or $env:GITHUB_EVENT_NAME -ne 'push' -or $env:GITHUB_REF -ne 'refs/heads/main') {
    throw 'Release publishing requires a push to main in GitHub Actions.'
}
$releaseRoot = Split-Path -Parent $PSScriptRoot
[xml]$project = Get-Content -LiteralPath (Join-Path $releaseRoot 'src/ParaDesk.App/ParaDesk.App.csproj') -Raw
$version = [string]($project.Project.PropertyGroup.Version | Where-Object { $_ } | Select-Object -First 1)
if ($version -notmatch '^\d+\.\d+\.\d+$') { throw "Invalid release version: $version" }
$tag = "v$version"
$notes = Join-Path $releaseRoot 'RELEASE_NOTES.md'
if ((Get-Content -LiteralPath $notes -TotalCount 1).Trim() -ne "# $version") { throw 'Release notes version mismatch.' }
$existingJson = & gh release view $tag --repo $env:GITHUB_REPOSITORY --json isDraft,targetCommitish 2>$null
$exists = $LASTEXITCODE -eq 0
if ($exists) {
    $existing = $existingJson | ConvertFrom-Json
    if (-not $existing.isDraft) { Write-Host "$tag already published; skipping."; exit 0 }
    if ($existing.targetCommitish -ne $env:GITHUB_SHA) { throw 'Existing draft targets another commit.' }
}

# Pin both the installer version and its official GitHub asset digest.
$compilerInstaller = Join-Path $env:RUNNER_TEMP 'innosetup-6.7.3.exe'
Invoke-WebRequest 'https://github.com/jrsoftware/issrc/releases/download/is-6_7_3/innosetup-6.7.3.exe' -OutFile $compilerInstaller
if ((Get-FileHash -LiteralPath $compilerInstaller -Algorithm SHA256).Hash -ne '9C73C3BAE7ED48D44112A0F48E66742C00090BDB5BEF71D9D3C056C66E97B732') {
    throw 'Inno Setup checksum mismatch.'
}
$compilerDir = Join-Path $env:RUNNER_TEMP 'ParaDesk-InnoSetup'
$install = Start-Process -FilePath $compilerInstaller -ArgumentList @('/VERYSILENT','/SUPPRESSMSGBOXES','/NORESTART','/SP-',"/DIR=`"$compilerDir`"") -WindowStyle Hidden -Wait -PassThru
if ($install.ExitCode -ne 0) { throw "Inno Setup installation failed: $($install.ExitCode)" }
& (Join-Path $releaseRoot 'publish.ps1') -Version $version -IsccPath (Join-Path $compilerDir 'ISCC.exe') -SelfTest
if ($LASTEXITCODE -ne 0) { throw 'Packaging failed.' }

$dist = Join-Path $releaseRoot 'dist'
$assetNames = @("ParaDesk-$version.zip", "ParaDesk-$version.sha256", "ParaDesk-$version-arm64.zip", "ParaDesk-$version-arm64.sha256", "ParaDesk-$version-Setup.exe", "ParaDesk-$version-Setup.sha256")
$assets = @($assetNames | ForEach-Object { Join-Path $dist $_ })
foreach ($file in $assets) {
    if (-not (Test-Path -LiteralPath $file -PathType Leaf) -or (Get-Item -LiteralPath $file).Length -eq 0) { throw "Missing asset: $file" }
}
foreach ($name in @("ParaDesk-$version", "ParaDesk-$version-arm64", "ParaDesk-$version-Setup")) {
    $hashLine = (Get-Content -LiteralPath (Join-Path $dist "$name.sha256") -Raw).Trim()
    $parts = $hashLine -split '\s+', 2
    $expectedName = if ($name.EndsWith('-Setup')) { "$name.exe" } else { "$name.zip" }
    if ($parts.Count -ne 2 -or $parts[1] -ne $expectedName -or
        (Get-FileHash -LiteralPath (Join-Path $dist $expectedName) -Algorithm SHA256).Hash -ne $parts[0]) { throw "Invalid checksum: $name" }
}

if (-not $exists) {
    & gh release create $tag --repo $env:GITHUB_REPOSITORY --target $env:GITHUB_SHA --title "ParaDesk $version" --notes-file $notes --draft
    if ($LASTEXITCODE -ne 0) { throw 'Creating release draft failed.' }
}
& gh release upload $tag @assets --repo $env:GITHUB_REPOSITORY --clobber
if ($LASTEXITCODE -ne 0) { throw 'Uploading release assets failed; draft retained.' }
$uploadedJson = & gh release view $tag --repo $env:GITHUB_REPOSITORY --json assets
if ($LASTEXITCODE -ne 0) { throw 'Verifying uploaded assets failed.' }
$uploaded = $uploadedJson | ConvertFrom-Json
foreach ($name in $assetNames) {
    $local = Get-Item -LiteralPath (Join-Path $dist $name)
    $remote = @($uploaded.assets | Where-Object { $_.name -eq $name })
    if ($remote.Count -ne 1 -or $remote[0].size -ne $local.Length) { throw "Uploaded asset mismatch: $name" }
}
& gh release edit $tag --repo $env:GITHUB_REPOSITORY --draft=false --latest
if ($LASTEXITCODE -ne 0) { throw 'Publishing release failed; draft retained.' }
