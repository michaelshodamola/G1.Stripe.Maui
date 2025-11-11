$ErrorActionPreference = "Stop"

$repoRoot = Split-Path -Parent $MyInvocation.MyCommand.Path
$propsPath = Join-Path $repoRoot "Directory.Build.props"

if (-not (Test-Path $propsPath)) {
    throw "Cannot find Directory.Build.props at $propsPath"
}

[xml]$props = Get-Content -Path $propsPath
$iosVersion = $props.Project.PropertyGroup `
    | ForEach-Object { $_._IosSdkVersion } `
    | Where-Object { -not [string]::IsNullOrWhiteSpace($_) } `
    | Select-Object -First 1

if ([string]::IsNullOrWhiteSpace($iosVersion)) {
    throw "Unable to read _IosSdkVersion from Directory.Build.props"
}

$downloadUrl = "https://github.com/stripe/stripe-ios/releases/download/$iosVersion/Stripe.xcframework.zip"
$tempZip = Join-Path ([System.IO.Path]::GetTempPath()) ("Stripe.xcframework." + [System.Guid]::NewGuid() + ".zip")
$destination = Join-Path $repoRoot "src\G1.Stripe.iOS.Bindings\stripe"

try {
    Write-Host "Downloading Stripe iOS SDK version $iosVersion..."
    Invoke-WebRequest -Uri $downloadUrl -OutFile $tempZip

    if (Test-Path $destination) {
        Write-Host "Clearing existing contents at $destination"
        Remove-Item -Recurse -Force -Path $destination
    }

    New-Item -ItemType Directory -Path $destination | Out-Null

    Write-Host "Extracting SDK to $destination"
    Expand-Archive -Path $tempZip -DestinationPath $destination -Force

    Write-Host "Stripe iOS SDK version $iosVersion downloaded and extracted successfully."
}
finally {
    if (Test-Path $tempZip) {
        Remove-Item -Path $tempZip -Force
    }
}
