param
(
    # Directory used to base all relative paths
    [Parameter(Mandatory=$false)]
    [string] $BaseDirectory = "..\",
    #
    [Parameter(Mandatory=$false)]
    [string] $OutputDirectory = ".\src\WinRTUtil\bin\release\",
    #
    [Parameter(Mandatory=$false)]
    [X509Certificate] $SigningCertificate = (Get-ChildItem Cert:\CurrentUser\My\E7413D745138A6DC584530AECE27CEFDDA9D9CD6 -CodeSigningCert),
    #
    [Parameter(Mandatory=$false)]
    [string] $TimestampServer = 'http://timestamp.digicert.com'
)

## Sign PowerShell Files
Set-AuthenticodeSignature (Join-Path (Join-Path $BaseDirectory $OutputDirectory) "\*\*.dll") -Certificate $SigningCertificate -HashAlgorithm SHA256 -IncludeChain NotRoot -TimestampServer $TimestampServer
