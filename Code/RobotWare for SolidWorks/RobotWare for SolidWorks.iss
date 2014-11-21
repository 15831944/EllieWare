; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "RobotWare for SolidWorks"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "EllieWare"
#define MyAppURL "http://www.EllieWare.com/"
#define MyCopyrightYear "2014"
#define MyDescription "Automation without the pain of code"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{A01DC147-7A09-4F32-AAA8-4979CC5D6768}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DisableDirPage=yes
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
OutputDir=.
OutputBaseFilename=setup
SetupIconFile=robot.ico
Compression=lzma
SolidCompression=yes
UninstallDisplayName={#MyAppName}
AppCopyright={#MyAppPublisher} {#MyCopyrightYear}
LicenseFile=EULA.rtf
LanguageDetectionMethod=none
UninstallDisplayIcon={app}\robot.ico
VersionInfoVersion={#MyAppVersion}
VersionInfoCompany={#MyAppPublisher}
VersionInfoDescription={#MyDescription}
VersionInfoCopyright={#MyAppPublisher} {#MyCopyrightYear}
VersionInfoProductName={#MyAppName}
VersionInfoProductVersion={#MyAppVersion}
ArchitecturesAllowed=x64
ArchitecturesInstallIn64BitMode=x64
AllowUNCPath=False
ShowLanguageDialog=no
CloseApplications=False
RestartApplications=False
CloseApplicationsFilter=SldWorks.exe

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Dirs]
Name: {userdocs}\{#MyAppName}; Flags: uninsneveruninstall;

[Files]
; location is relative to "RobotWare for SolidWorks.iss"
Source: "..\RobotWare.SolidWorks\bin\Release\AutoUpdaterDotNET.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\RobotWare.SolidWorks\bin\Release\CrashReporterDotNET.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\RobotWare.SolidWorks\bin\Release\EllieWare.Common.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\RobotWare.SolidWorks\bin\Release\EllieWare.Interfaces.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\RobotWare.SolidWorks\bin\Release\EllieWare.Licensing.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\RobotWare.SolidWorks\bin\Release\EllieWare.Manager.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\RobotWare.SolidWorks\bin\Release\EllieWare.Support.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\RobotWare.SolidWorks\bin\Release\RobotWare.SolidWorks.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\RobotWare for SpaceClaim\robot.ico"; DestDir: "{app}"

[Run]
Filename: "{dotnet40}\RegAsm.exe"; Parameters: "/codebase RobotWare.SolidWorks.dll"; WorkingDir: "{app}"; Flags: runminimized 64bit; Description: "Register addin with SolidWorks"; StatusMsg: "Registering addin with SolidWorks..."

[UninstallRun]
Filename: "{dotnet40}\RegAsm.exe"; Parameters: "/unregister RobotWare.SolidWorks.dll"; WorkingDir: "{app}"; Flags: runminimized 64bit 