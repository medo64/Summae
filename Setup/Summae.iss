[Setup]
AppName=Summae
AppVerName=Summae 0.00
DefaultDirName={pf}\Josip Medved\Summae
OutputBaseFilename=summae000
OutputDir=..\Releases
SourceDir=..\Binaries
AppId=JosipMedved_Summae
AppMutex=Global\JosipMedved_Summae
AppPublisher=Josip Medved
AppPublisherURL=http://www.jmedved.com/summae/
UninstallDisplayIcon={app}\Summae.exe
AlwaysShowComponentsList=no
ArchitecturesInstallIn64BitMode=x64
DisableProgramGroupPage=yes
MergeDuplicateFiles=yes
MinVersion=0,5.01
PrivilegesRequired=admin
ShowLanguageDialog=no
SolidCompression=yes
ChangesAssociations=yes

[Files]
Source: "Summae.exe";         DestDir: "{app}";
Source: "SummaeExecutor.exe"; DestDir: "{app}";
Source: "sum.exe";            DestDir: "{app}";
Source: "SummaeSettings.exe"; DestDir: "{app}";
Source: "ReadMe.txt";         DestDir: "{app}"; Attribs: readonly; Flags: overwritereadonly uninsremovereadonly;

[Icons]
Name: "{userstartmenu}\Summae"; Filename: "{app}\Summae.exe"

[Registry]
Root: HKCU; Subkey: "Software\Josip Medved\Summae"; ValueType: dword; ValueName: "Installed"; ValueData: "1"; Flags: uninsdeletekey
Root: HKCU; Subkey: "Software\Josip Medved"; Flags: uninsdeletekeyifempty
Root: HKCR; Subkey: "*\shell\Summae"; ValueType: none; Flags: dontcreatekey uninsdeletekey;
Root: HKCR; Subkey: "*\shell\Summae (SHA-1)"; ValueType: none; Flags: uninsdeletekey;
Root: HKCR; Subkey: "*\shell\Summae (SHA-1)"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player";
Root: HKCR; Subkey: "*\shell\Summae (SHA-1)\command"; ValueType: string; ValueName: ""; ValueData: """{app}\SummaeExecutor.exe"" /sha1 ""%1""";
Root: HKCR; Subkey: "*\shell\Summae (CRC-16)"; ValueType: none; Flags: dontcreatekey uninsdeletekey;
Root: HKCR; Subkey: "*\shell\Summae (CRC-32)"; ValueType: none; Flags: dontcreatekey uninsdeletekey;
Root: HKCR; Subkey: "*\shell\Summae (MD-5)"; ValueType: none; Flags: dontcreatekey uninsdeletekey;
Root: HKCR; Subkey: "*\shell\Summae (RIPE MD-160)"; ValueType: none; Flags: dontcreatekey uninsdeletekey;
Root: HKCR; Subkey: "*\shell\Summae (SHA-256)"; ValueType: none; Flags: dontcreatekey uninsdeletekey;
Root: HKCR; Subkey: "*\shell\Summae (SHA-384)"; ValueType: none; Flags: dontcreatekey uninsdeletekey;
Root: HKCR; Subkey: "*\shell\Summae (SHA-512)"; ValueType: none; Flags: dontcreatekey uninsdeletekey;

[Run]
Filename: "{app}\ReadMe.txt"; Description: "View ReadMe.txt"; Flags: postinstall runasoriginaluser shellexec nowait skipifsilent unchecked
Filename: "{app}\Summae.exe"; Description: "Launch application now"; Flags: postinstall nowait skipifsilent runasoriginaluser unchecked
