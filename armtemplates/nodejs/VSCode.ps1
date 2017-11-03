#Set Execution Policy
Set-ExecutionPolicy Unrestricted -Force

#Create Folder
cd \
mkdir Downloads

#Download Visual Studio Code
Invoke-WebRequest -Uri "https://go.microsoft.com/fwlink/?Linkid=852157" -OutFile "C:\Downloads\vscode.exe"

#Download NodeJs
Invoke-WebRequest -Uri "https://nodejs.org/dist/v6.11.4/node-v6.11.4-x64.msi" -OutFile "C:\Downloads\node.msi"

#Silent Installation of Visual Studio Code
C:\Downloads\vscode.exe /VERYSILENT /MERGETASKS=!runcode

#Silent Installation of NodeJS
C:\Downloads\node.msi /passive