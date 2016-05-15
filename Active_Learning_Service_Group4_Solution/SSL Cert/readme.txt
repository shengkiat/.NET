On Visual Studio 2015 you have to install the Windows 10 SDK to have the file "makecert.exe" installed. 

Run Developer Command Prompt in Admin Mode

makecert.exe -sr LocalMachine -ss MY -n "CN=pt4.activelearning.com" -r -sky exchange -pe