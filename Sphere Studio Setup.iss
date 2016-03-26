; Sphere Studio Setup Script for Inno Setup 5.5+
; Builds a Windows installer distribution of Sphere Studio.
; Copyright (c) 2015 Spherical

#define AppName "Sphere Studio"
#define AppPublisher "Spherical"
#define AppVersion "1.2.2"

[Setup]
OutputBaseFilename=SphereStudioSetup-{#AppVersion}
SetupIconFile=Sphere Studio\Sphere Studio.ico
OutputDir=.
ArchitecturesInstallIn64BitMode=x64 ia64
Compression=lzma
LZMAUseSeparateProcess=yes
SolidCompression=yes

UninstallDisplayIcon={app}\Sphere Studio.exe,0
AppId={{F40892B0-C96E-48B7-B1E9-8C2BFB6C167D}
AppName={#AppName}
AppVerName={#AppName} {#AppVersion}
AppVersion={#AppVersion}
AppPublisher={#AppPublisher}
AppPublisherURL=http://www.spheredev.org/
AppSupportURL=http://forums.spheredev.org/
AppUpdatesURL=http://forums.spheredev.org/index.php/topic,24.0.html
AppCopyright=© 2015-2016 Spherical
LicenseFile=LICENSE.txt
DefaultDirName={pf}\{#AppName}
DisableProgramGroupPage=yes
ChangesAssociations=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktop"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"
Name: "desktop/user"; Description: "only for the current user ({username})"; GroupDescription: "{cm:AdditionalIcons}"; Flags: exclusive
Name: "desktop/all"; Description: "for all users of this PC"; GroupDescription: "{cm:AdditionalIcons}"; Flags: exclusive

[Files]
Source: "Sphere Studio\bin\Release\Sphere Studio.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "Sphere Studio\bin\Release\Sphere Studio.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "Sphere Studio\bin\Release\*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Sphere Studio\bin\Release\*.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "Sphere Studio\bin\Release\Dictionary\*"; DestDir: "{app}\Dictionary"; Flags: ignoreversion
Source: "Sphere Studio\bin\Release\Plugins\*.dll"; DestDir: "{app}\Plugins"; Flags: ignoreversion

[Registry]
Root: HKCR; Subkey: ".ssproj"; ValueType: string; ValueName: ""; ValueData: "SphereStudio.SSPROJ"; Flags: uninsdeletevalue
Root: HKCR; Subkey: "SphereStudio.SSPROJ"; ValueType: string; ValueName: ""; ValueData: "Sphere Studio Project"; Flags: uninsdeletekey
Root: HKCR; Subkey: "SphereStudio.SSPROJ\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\Sphere Studio.exe,0"
Root: HKCR; Subkey: "SphereStudio.SSPROJ\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\Sphere Studio.exe"" ""%1"""

[Icons]
Name: "{commonprograms}\{#AppName}"; Filename: "{app}\Sphere Studio.exe"
Name: "{userdesktop}\{#AppName}"; Filename: "{app}\Sphere Studio.exe"; Tasks: desktop/user
Name: "{commondesktop}\{#AppName}"; Filename: "{app}\Sphere Studio.exe"; Tasks: desktop/all

[Run]
Filename: "{app}\Sphere Studio.exe"; Description: "{cm:LaunchProgram,{#StringChange(AppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
