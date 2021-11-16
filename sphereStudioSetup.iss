; Sphere Studio Setup Script for Inno Setup
; Builds a Windows installer distribution of Sphere Studio.
; Copyright (c) 2021 Spherical

#define AppName "Sphere Studio"
#define AppPublisher "Fat Cerberus"
#define AppVersion "2.0.0"

[Setup]
OutputBaseFilename=sphereStudioSetup-{#AppVersion}-msw
OutputDir=.
AppId={{F40892B0-C96E-48B7-B1E9-8C2BFB6C167D}
AppCopyright=© 2021 Fat Cerberus
AppName={#AppName}
AppPublisher={#AppPublisher}
AppPublisherURL=http://www.spheredev.org/
AppSupportURL=http://forums.spheredev.org/
AppUpdatesURL=http://forums.spheredev.org/index.php/topic,24.0.html
AppVerName={#AppName} {#AppVersion}
AppVersion={#AppVersion}
ArchitecturesInstallIn64BitMode=x64 ia64
ChangesAssociations=yes
Compression=lzma2
DefaultDirName={autopf}\{#AppName}
DisableProgramGroupPage=yes
LicenseFile=LICENSE.txt
SetupIconFile=SphereStudioIDE\Sphere Studio.ico
SolidCompression=yes
UninstallDisplayIcon={app}\SphereStudioIDE.exe,0
VersionInfoDescription={#AppName} {#AppVersion} Setup for Windows

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
Source: "SphereStudioIDE\bin\Release\SphereStudioIDE.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "SphereStudioIDE\bin\Release\SphereStudio.Base.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "SphereStudioIDE\bin\Release\*.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "SphereStudioIDE\bin\Release\*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "SphereStudioIDE\bin\Release\*.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "SphereStudioIDE\bin\Release\Dictionary\*"; DestDir: "{app}\Dictionary"; Flags: ignoreversion
Source: "SphereStudioIDE\bin\Release\Plugins\*.dll"; DestDir: "{app}\Plugins"; Flags: ignoreversion

[Registry]
Root: HKCR; Subkey: ".ssproj"; ValueType: string; ValueName: ""; ValueData: "SphereStudio.SSPROJ"; Flags: uninsdeletevalue
Root: HKCR; Subkey: "SphereStudio.SSPROJ"; ValueType: string; ValueName: ""; ValueData: "Sphere Studio Project"; Flags: uninsdeletekey
Root: HKCR; Subkey: "SphereStudio.SSPROJ\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\SphereStudioIDE.exe,0"
Root: HKCR; Subkey: "SphereStudio.SSPROJ\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\SphereStudioIDE.exe"" ""%1"""

[Icons]
Name: "{commonprograms}\{#AppName}"; Filename: "{app}\SphereStudioIDE.exe"

[Run]
Filename: "{app}\SphereStudioIDE.exe"; Description: "{cm:LaunchProgram,{#StringChange(AppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
