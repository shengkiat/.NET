On Visual Studio 2015 you have to install the Windows 10 SDK to have the file "makecert.exe" installed. 

Run Developer Command Prompt in Admin Mode

makecert.exe -sr LocalMachine -ss MY -n "CN=pt4.activelearning.com" -r -sky exchange -pe

Must give access rights to key

Start -> Run -> MMC
File -> Add/Remove Snapin
Add the Certificates Snap In
Select Computer Account, then hit next
Select Local Computer (the default), then click Finish
On the left panel from Console Root, navigate to Certificates (Local Computer) -> Personal -> Certificates
Your certificate will most likely be here.
Right click on your certificate -> All Tasks -> Manage Private Keys
Set your private key settings here.
Add Everyone