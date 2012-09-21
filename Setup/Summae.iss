#define AppName        GetStringFileInfo('..\Binaries\Summae.exe', 'ProductName')
#define AppVersion     GetStringFileInfo('..\Binaries\Summae.exe', 'ProductVersion')
#define AppFileVersion GetStringFileInfo('..\Binaries\Summae.exe', 'FileVersion')
#define AppCompany     GetStringFileInfo('..\Binaries\Summae.exe', 'CompanyName')
#define AppCopyright   GetStringFileInfo('..\Binaries\Summae.exe', 'LegalCopyright')

[Setup]
AppName={#AppName}
AppVersion={#AppVersion}
AppVerName={#AppName} {#AppVersion}
AppPublisher={#AppCompany}
AppPublisherURL=http://www.jmedved.com/summae/
AppCopyright={#AppCopyright}
VersionInfoProductVersion={#AppVersion}
VersionInfoProductTextVersion={#AppVersion}
VersionInfoVersion={#AppFileVersion}
DefaultDirName={pf}\{#AppCompany}\{#AppName}
OutputBaseFilename=summae000
OutputDir=..\Releases
SourceDir=..\Binaries
AppId=JosipMedved_Summae
AppMutex=Global\JosipMedved_Summae
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
Source: "Summae.exe";         DestDir: "{app}"; Flags: ignoreversion;
Source: "SummaeExecutor.exe"; DestDir: "{app}"; Flags: ignoreversion;
Source: "sum.exe";            DestDir: "{app}"; Flags: ignoreversion;
Source: "SummaeSettings.exe"; DestDir: "{app}"; Flags: ignoreversion;
Source: "ReadMe.txt";         DestDir: "{app}"; Attribs: readonly; Flags: overwritereadonly uninsremovereadonly;

[Icons]
Name: "{userstartmenu}\Summae"; Filename: "{app}\Summae.exe"

[Registry]
Root: HKCU; Subkey: "Software\Josip Medved\Summae"; ValueType: none;  ValueName: "Installed"; Flags: deletevalue uninsdeletevalue
Root: HKLM; Subkey: "Software\Josip Medved\Summae"; ValueType: dword; ValueName: "Installed"; ValueData: "1"; Flags: uninsdeletekey
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
