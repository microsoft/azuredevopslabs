###################################################################################################
#
# PowerShell configurations
#

# NOTE: Because the $ErrorActionPreference is "Stop", this script will stop on first failure.
#       This is necessary to ensure we capture errors inside the try-catch-finally block.
$ErrorActionPreference = "Stop"

# Make download speed more faster
$ProgressPreference = "SilentlyContinue"

# Change to TLS1.2 https://somoit.net/powershell/could-not-create-ssltls-secure-channel
[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
###################################################################################################


# chrome
$Path = $env:TEMP; $Installer = "chrome_installer.exe"; Invoke-WebRequest "http://dl.google.com/chrome/install/375.126/chrome_installer.exe" -OutFile $Path\$Installer; Start-Process -FilePath $Path\$Installer -Args "/silent /install" -Verb RunAs -Wait; Remove-Item $Path\$Installer


# firefox

# Silent Install Firefox 
# Download URL: https://www.mozilla.org/en-US/firefox/all/

# Path for the workdir
$workdir = "c:\installer\"

# Check if work directory exists if not create it

If (Test-Path -Path $workdir -PathType Container)
{ Write-Host "$workdir already exists" -ForegroundColor Red}
ELSE
{ New-Item -Path $workdir  -ItemType directory }

# Download the installer

$source = "https://download.mozilla.org/?product=firefox-latest&os=win64&lang=en-US"
$destination = "$workdir\firefox.exe"

# Check if Invoke-Webrequest exists otherwise execute WebClient

if (Get-Command 'Invoke-Webrequest')
{
     Invoke-WebRequest $source -OutFile $destination
}
else
{
    $WebClient = New-Object System.Net.WebClient
    $webclient.DownloadFile($source, $destination)
}

# Start the installation

Start-Process -FilePath "$workdir\firefox.exe" -ArgumentList "/S"

# Wait XX Seconds for the installation to finish

Start-Sleep -s 35

# Remove the installer

rm -Force $workdir\firefox*

#copy geckodriver
Invoke-WebRequest https://github.com/Microsoft/almvm/blob/master/labs/vstsextend/selenium/armtemplate/geckodriver.exe?raw=true -OutFile "C:\Program Files\Mozilla Firefox\geckodriver.exe"

#Downlaod and extract VSTS windows agent
mkdir C:\VSTSwinAgent ;
Invoke-WebRequest https://vstsagentpackage.azureedge.net/agent/2.142.1/vsts-agent-win-x64-2.142.1.zip -OutFile C:\VSTSwinAgent\agent.zip
#Start-Sleep -s 30
Expand-Archive C:\VSTSwinAgent\agent.zip -DestinationPath C:\VSTSwinAgent

#Set Execution Policy
Set-ExecutionPolicy Unrestricted -Force

#IIS installation
Install-WindowsFeature -Name Web-Server -IncludeAllSubFeature 
