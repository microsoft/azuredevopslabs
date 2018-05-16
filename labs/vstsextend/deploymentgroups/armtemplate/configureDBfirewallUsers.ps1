param
(
    [Parameter(Mandatory=$false)]
    [string] $sqluser 
)

$sqlInstanceName = 'MSSQLSERVER'

if ([String]::IsNullOrEmpty($sqluser) -eq $true)
    { 
        $sqluser = "contoso"
    }

#STEP1: Enable TCP protocol
Write-Output "Enabling TCP protocol"
Import-Module "sqlps"
$smo = 'Microsoft.SqlServer.Management.Smo.'
$wmi = new-object ($smo + 'Wmi.ManagedComputer').

# List the object properties, including the instance names.
$Wmi

# Enable the TCP protocol on the default instance.
$uri = "ManagedComputer[@Name='" + (get-item env:\computername).Value + "']/ServerInstance[@Name='$sqlInstanceName']/ServerProtocol[@Name='Tcp']"
$Tcp = $wmi.GetSmoObject($uri)
$Tcp.IsEnabled = $true
$Tcp.Alter()
$Tcp


#STEP2: Start SQL Server Browser service
Write-output "Enabling SQL browser service"
Set-Service sqlbrowser -StartupType Automatic
net start sqlbrowser


#STEP3: ADD firewall rules for SQL service
Write-Output "Enabling firewall rules"
netsh advfirewall firewall add rule name = SQLPort dir = in protocol = tcp action = allow localport = 1433 remoteip = any profile = domain  
netsh advfirewall firewall add rule name = SQLPortPrivate dir = in protocol = tcp action = allow localport = 1433 remoteip = any profile = private  
netsh advfirewall firewall add rule name = SQLPortPublic dir = in protocol = tcp action = allow localport = 1433 remoteip = any profile = public  

#STEP4: Restart SQL service
Write-Output "Restarting SQL service"
net stop $sqlInstanceName /yes
net start $sqlInstanceName /yes


#STEP5: Add user to SQL roles
Write-Output "Adding user to SQL roles"+$sqluser
$sqluser = "contoso"
$username = "$env:ComputerName\$sqluser"
$password = 'Microsoft!123'
$securePassword = ConvertTo-SecureString $password -AsPlainText -Force
$credential = New-Object System.Management.Automation.PSCredential $username, $securePassword

$sqltoolPath="C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\110\Tools\binn"
pushd $sqltoolPath

$arguments = "-S localhost -Q `"sp_addsrvrolemember '$env:ComputerName\$sqluser', 'sysadmin' `""
Start-Process sqlcmd.exe -Credential $credential -ArgumentList $arguments

$arguments = "-S localhost -Q `"sp_addsrvrolemember '$env:ComputerName\$sqluser', 'dbcreator' `""
Start-Process sqlcmd.exe -Credential $credential -ArgumentList $arguments

$arguments = "-S localhost -Q `"sp_addsrvrolemember 'NT AUTHORITY\SYSTEM', 'sysadmin' `""
Start-Process sqlcmd.exe -Credential $credential -ArgumentList $arguments

$arguments = "-S localhost -Q `"sp_addsrvrolemember 'NT AUTHORITY\SYSTEM', 'dbcreator' `""
Start-Process sqlcmd.exe -Credential $credential -ArgumentList $arguments

popd

Write-Output "Successfully added users to SQL roles"
# Enable SQl auth and SQL User
Invoke-WebRequest https://raw.githubusercontent.com/bayernmunich/sqlscript/master/sqlauthwithuser.ps1 -OutFile "D:\sqlauthwithuser.ps1"
Invoke-Expression "D:\sqlauthwithuser.ps1"
