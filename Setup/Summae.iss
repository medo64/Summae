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
AppPublisherURL=https://www.medo64.com/{#AppBase}/
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
BeveledLabel=www.medo64.com


[Files]
Source: "Summae.exe";         DestDir: "{app}"; Flags: ignoreversion;
Source: "Summae.pdb";         DestDir: "{app}"; Flags: ignoreversion;
Source: "SummaeExecutor.exe"; DestDir: "{app}"; Flags: ignoreversion;
Source: "SummaeExecutor.pdb"; DestDir: "{app}"; Flags: ignoreversion;
Source: "sum.exe";            DestDir: "{app}"; Flags: ignoreversion;
Source: "sum.pdb";            DestDir: "{app}"; Flags: ignoreversion;
Source: "SummaeSettings.exe"; DestDir: "{app}"; Flags: ignoreversion;
Source: "SummaeSettings.pdb"; DestDir: "{app}"; Flags: ignoreversion;
Source: "ReadMe.txt";         DestDir: "{app}"; Attribs: readonly; Flags: overwritereadonly uninsremovereadonly;
Source: "License.txt";        DestDir: "{app}"; Attribs: readonly; Flags: overwritereadonly uninsremovereadonly;


[Icons]
Name: "{userstartmenu}\Summae"; Filename: "{app}\Summae.exe"


[Registry]
Root: HKLM; Subkey: "Software\Josip Medved";        ValueType: none; Flags: uninsdeletekeyifempty;
Root: HKLM; Subkey: "Software\Josip Medved\Summae"; ValueType: none; Flags: uninsdeletekey

Root: HKCR; Subkey: "*\shell\Summae";                                                                              ValueType: none;   Flags: uninsdeletekey;
Root: HKCR; Subkey: "*\shell\Summae"; ValueName: "Icon";        ValueData: """{app}\Summae.exe""";                 ValueType: string; Flags: uninsdeletekey;
Root: HKCR; Subkey: "*\shell\Summae"; ValueName: "SubCommands"; ValueData: "Summae.Sha1;Summae.Sha256;Summae.Md5"; ValueType: string; Flags: uninsdeletekey;

Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Crc16";             ValueName: "MUIVerb";          ValueData: "CRC-16";                                         ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Crc16";             ValueName: "MultiSelectModel"; ValueData: "Player";                                         ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Crc16\command";     ValueName: "";                 ValueData: """{app}\SummaeExecutor.exe"" /crc16 ""%1""";     ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Crc32";             ValueName: "MUIVerb";          ValueData: "CRC-32";                                         ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Crc32";             ValueName: "MultiSelectModel"; ValueData: "Player";                                         ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Crc32\command";     ValueName: "";                 ValueData: """{app}\SummaeExecutor.exe"" /crc32 ""%1""";     ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Md5";               ValueName: "MUIVerb";          ValueData: "MD-5";                                           ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Md5";               ValueName: "MultiSelectModel"; ValueData: "Player";                                         ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Md5\command";       ValueName: "";                 ValueData: """{app}\SummaeExecutor.exe"" /md5 ""%1""";       ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.RipeMd160";         ValueName: "MUIVerb";          ValueData: "RIPE MD-160";                                    ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.RipeMd160";         ValueName: "MultiSelectModel"; ValueData: "Player";                                         ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.RipeMd160\command"; ValueName: "";                 ValueData: """{app}\SummaeExecutor.exe"" /ripemd160 ""%1"""; ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Sha1";              ValueName: "MUIVerb";          ValueData: "SHA-1";                                          ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Sha1";              ValueName: "MultiSelectModel"; ValueData: "Player";                                         ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Sha1\command";      ValueName: "";                 ValueData: """{app}\SummaeExecutor.exe"" /sha1 ""%1""";      ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Sha256";            ValueName: "MUIVerb";          ValueData: "SHA-256";                                        ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Sha256";            ValueName: "MultiSelectModel"; ValueData: "Player";                                         ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Sha256\command";    ValueName: "";                 ValueData: """{app}\SummaeExecutor.exe"" /sha256 ""%1""";    ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Sha384";            ValueName: "MUIVerb";          ValueData: "SHA-384";                                        ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Sha384";            ValueName: "MultiSelectModel"; ValueData: "Player";                                         ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Sha384\command";    ValueName: "";                 ValueData: """{app}\SummaeExecutor.exe"" /sha384 ""%1""";    ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Sha512";            ValueName: "MUIVerb";          ValueData: "SHA-512";                                        ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Sha512";            ValueName: "MultiSelectModel"; ValueData: "Player";                                         ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.Sha512\command";    ValueName: "";                 ValueData: """{app}\SummaeExecutor.exe"" /sha512 ""%1""";    ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.App";               ValueName: "Icon";             ValueData: """{app}\Summae.exe""";                           ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.App";               ValueName: "MUIVerb";          ValueData: "Summae";                                         ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.App";               ValueName: "MultiSelectModel"; ValueData: "Player";                                         ValueType: string; Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.App";               ValueName: "CommandFlags";     ValueData: "0x20";                                           ValueType: dword;  Flags: uninsdeletekey;
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Summae.App\command";       ValueName: "";                 ValueData: """{app}\Summae.exe"" ""%1""";                    ValueType: string; Flags: uninsdeletekey;

Root: HKCR; Subkey: "*\shell\Summae (CRC-16)";      ValueType: none; Flags: deletekey;
Root: HKCR; Subkey: "*\shell\Summae (CRC-32)";      ValueType: none; Flags: deletekey;
Root: HKCR; Subkey: "*\shell\Summae (MD-5)";        ValueType: none; Flags: deletekey;
Root: HKCR; Subkey: "*\shell\Summae (RIPE MD-160)"; ValueType: none; Flags: deletekey;
Root: HKCR; Subkey: "*\shell\Summae (SHA-1)";       ValueType: none; Flags: deletekey;
Root: HKCR; Subkey: "*\shell\Summae (SHA-256)";     ValueType: none; Flags: deletekey;
Root: HKCR; Subkey: "*\shell\Summae (SHA-384)";     ValueType: none; Flags: deletekey;
Root: HKCR; Subkey: "*\shell\Summae (SHA-512)";     ValueType: none; Flags: deletekey;


[Run]
Filename: "{app}\Summae.exe"; Description: "Launch application now"; Flags: postinstall nowait skipifsilent runasoriginaluser unchecked
Filename: "{app}\ReadMe.txt"; Description: "View ReadMe.txt";        Flags: postinstall nowait skipifsilent runasoriginaluser unchecked shellexec


[Code]

procedure InitializeWizard;
begin
  WizardForm.LicenseAcceptedRadio.Checked := True;
end;
