#define AppName        GetStringFileInfo('..\Binaries\Summae.exe', 'ProductName')
#define AppVersion     GetStringFileInfo('..\Binaries\Summae.exe', 'ProductVersion')
#define AppFileVersion GetStringFileInfo('..\Binaries\Summae.exe', 'FileVersion')
#define AppCompany     GetStringFileInfo('..\Binaries\Summae.exe', 'CompanyName')
#define AppCopyright   GetStringFileInfo('..\Binaries\Summae.exe', 'LegalCopyright')
#define AppBase        LowerCase(StringChange(AppName, ' ', ''))
#define AppSetupFile   AppBase + StringChange(AppVersion, '.', '')


#define AppVersionEx   StringChange(AppVersion, '0.00', '')
#ifdef VersionHash
#  if "" != VersionHash
#    define AppVersionEx AppVersionEx + " (" + VersionHash + ")"
#  endif
#endif


[Setup]
AppName={#AppName}
AppVersion={#AppVersion}
AppVerName={#AppName} {#AppVersion}
AppPublisher={#AppCompany}
AppPublisherURL=https://medo64.com/{#AppBase}/
AppCopyright={#AppCopyright}
VersionInfoProductVersion={#AppVersion}
VersionInfoProductTextVersion={#AppVersionEx}
VersionInfoVersion={#AppFileVersion}
DefaultDirName={pf}\{#AppCompany}\{#AppName}
OutputBaseFilename={#AppSetupFile}
OutputDir=..\Releases
SourceDir=..\Binaries
AppId=JosipMedved_Summae
CloseApplications="yes"
RestartApplications="no"
AppMutex=Global\JosipMedved_Summae
UninstallDisplayIcon={app}\Summae.exe
AlwaysShowComponentsList=no
ArchitecturesInstallIn64BitMode=x64
DisableProgramGroupPage=yes
MergeDuplicateFiles=yes
MinVersion=6.1
PrivilegesRequired=admin
ShowLanguageDialog=no
SolidCompression=yes
ChangesAssociations=yes
DisableWelcomePage=yes
LicenseFile=..\Setup\License.rtf


[Messages]
SetupAppTitle=Setup {#AppName} {#AppVersionEx}
SetupWindowTitle=Setup {#AppName} {#AppVersionEx}
BeveledLabel=medo64.com


[Files]
Source: "Summae.exe";         DestDir: "{app}"; Flags: ignoreversion;
Source: "Summae.pdb";         DestDir: "{app}"; Flags: ignoreversion;
Source: "sum.exe";            DestDir: "{app}"; Flags: ignoreversion;
Source: "sum.pdb";            DestDir: "{app}"; Flags: ignoreversion;
Source: "ReadMe.txt";         DestDir: "{app}"; Attribs: readonly; Flags: overwritereadonly uninsremovereadonly;
Source: "License.txt";        DestDir: "{app}"; Attribs: readonly; Flags: overwritereadonly uninsremovereadonly;


[Icons]
Name: "{userstartmenu}\Summae"; Filename: "{app}\Summae.exe"


[Registry]
Root: HKLM; Subkey: "Software\Josip Medved\Summae"; ValueType: none; Flags: deletekey
Root: HKCU; Subkey: "Software\Josip Medved\Summae"; ValueType: none; Flags: deletekey


Root: HKCR; Subkey: "*\shell\Summae";               ValueType: none; Flags: deletekey;
Root: HKCR; Subkey: "*\shell\Summae (CRC-16)";      ValueType: none; Flags: deletekey;
Root: HKCR; Subkey: "*\shell\Summae (CRC-32)";      ValueType: none; Flags: deletekey;
Root: HKCR; Subkey: "*\shell\Summae (MD-5)";        ValueType: none; Flags: deletekey;
Root: HKCR; Subkey: "*\shell\Summae (RIPE MD-160)"; ValueType: none; Flags: deletekey;
Root: HKCR; Subkey: "*\shell\Summae (SHA-1)";       ValueType: none; Flags: deletekey;
Root: HKCR; Subkey: "*\shell\Summae (SHA-256)";     ValueType: none; Flags: deletekey;
Root: HKCR; Subkey: "*\shell\Summae (SHA-384)";     ValueType: none; Flags: deletekey;
Root: HKCR; Subkey: "*\shell\Summae (SHA-512)";     ValueType: none; Flags: deletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Crc16";     ValueType: none; Flags: deletekey
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Crc32";     ValueType: none; Flags: deletekey
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Md5";       ValueType: none; Flags: deletekey
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.RipeMd160"; ValueType: none; Flags: deletekey
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Sha1";      ValueType: none; Flags: deletekey
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Sha256";    ValueType: none; Flags: deletekey
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Sha384";    ValueType: none; Flags: deletekey
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Sha512";    ValueType: none; Flags: deletekey
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.App";       ValueType: none; Flags: deletekey

Root: HKCU; Subkey: "Software\Classes\*\shell\Summae";                                                              ValueType: none;   Flags: uninsdeletekey;
Root: HKCU; Subkey: "Software\Classes\*\shell\Summae"; ValueName: "Icon";        ValueData: """{app}\Summae.exe"""; ValueType: string; Flags: uninsdeletekey;
Root: HKCU; Subkey: "Software\Classes\*\shell\Summae"; ValueName: "MUIVerb";     ValueData: "Summae";               ValueType: string; Flags: uninsdeletekey;
Root: HKCU; Subkey: "Software\Classes\*\shell\Summae"; ValueName: "SubCommands"; ValueData: "";                     ValueType: string; Flags: uninsdeletekey;

Root: HKCU; Subkey: "Software\Classes\*\shell\Summae\Shell\Md5";            ValueName: "MUIVerb";          ValueData: "MD-5";                                ValueType: string; Flags: uninsdeletekey;
Root: HKCU; Subkey: "Software\Classes\*\shell\Summae\Shell\Md5";            ValueName: "MultiSelectModel"; ValueData: "Player";                              ValueType: string; Flags: uninsdeletekey;
Root: HKCU; Subkey: "Software\Classes\*\shell\Summae\Shell\Md5\command";    ValueName: "";                 ValueData: """{app}\Summae.exe"" /md5 ""%1""";    ValueType: string; Flags: uninsdeletekey;
Root: HKCU; Subkey: "Software\Classes\*\shell\Summae\Shell\Sha1";           ValueName: "MUIVerb";          ValueData: "SHA-1";                               ValueType: string; Flags: uninsdeletekey;
Root: HKCU; Subkey: "Software\Classes\*\shell\Summae\Shell\Sha1";           ValueName: "MultiSelectModel"; ValueData: "Player";                              ValueType: string; Flags: uninsdeletekey;
Root: HKCU; Subkey: "Software\Classes\*\shell\Summae\Shell\Sha1\command";   ValueName: "";                 ValueData: """{app}\Summae.exe"" /sha1 ""%1""";   ValueType: string; Flags: uninsdeletekey;
Root: HKCU; Subkey: "Software\Classes\*\shell\Summae\Shell\Sha256";         ValueName: "MUIVerb";          ValueData: "SHA-256";                             ValueType: string; Flags: uninsdeletekey;
Root: HKCU; Subkey: "Software\Classes\*\shell\Summae\Shell\Sha256";         ValueName: "MultiSelectModel"; ValueData: "Player";                              ValueType: string; Flags: uninsdeletekey;
Root: HKCU; Subkey: "Software\Classes\*\shell\Summae\Shell\Sha256\command"; ValueName: "";                 ValueData: """{app}\Summae.exe"" /sha256 ""%1"""; ValueType: string; Flags: uninsdeletekey;


[Run]
Filename: "{app}\Summae.exe"; Description: "Launch application now"; Flags: postinstall nowait skipifsilent runasoriginaluser unchecked
Filename: "{app}\ReadMe.txt"; Description: "View ReadMe.txt";        Flags: postinstall nowait skipifsilent runasoriginaluser unchecked shellexec


[Code]

procedure InitializeWizard;
begin
  WizardForm.LicenseAcceptedRadio.Checked := True;
end;
