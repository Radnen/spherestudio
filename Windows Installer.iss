; Sphere Studio Setup Script for Inno Setup 5.5+
; Builds a Windows installer distribution of Sphere Studio.
; Copyright (c) 2015 Spherical

#define AppName "Sphere Studio"
#define AppPublisher "Spherical"
#define AppVersion3 "1.2.2"
#define AppVersion4 "1.2.2.2016"

[Setup]
OutputBaseFilename=SphereStudio-{#AppVersion3}
SetupIconFile=Sphere Studio\SphereDev.ico
OutputDir=.
ArchitecturesInstallIn64BitMode=x64 ia64
Compression=lzma
LZMAUseSeparateProcess=yes
SolidCompression=yes

UninstallDisplayIcon={app}\SphereDev.ico,0
AppId={{F40892B0-C96E-48B7-B1E9-8C2BFB6C167D}
AppName={#AppName}
AppVerName={#AppName} {#AppVersion3}
AppVersion={#AppVersion4}
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

[Types]
Name: "full"; Description: "Full Installation"
Name: "minimal"; Description: "Minimal Installation"
Name: "custom"; Description: "Custom Installation"; Flags: iscustom

[Components]
Name: "spherestudio"; Description: "{#AppName} {#AppVersion3} IDE"; Types: full minimal custom; Flags: fixed
Name: "classic"; Description: "Sphere 1.x Engine Support"; Types: full minimal
Name: "plugins"; Description: "Additional Plugins"
Name: "plugins/soundtest"; Description: "Sound Test"; Types: full
Name: "plugins/tasklist"; Description: "Task List"; Types: full

[Tasks]
Name: "desktop"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "Sphere Studio\bin\Release\SphereStudioIDE.exe"; DestDir: "{app}"; Flags: ignoreversion; Components: spherestudio
Source: "Sphere Studio\SphereDev.ico"; DestDir: "{app}"; Flags: ignoreversion; Components: spherestudio
Source: "Sphere Studio\bin\Release\SphereStudioIDE.exe.config"; DestDir: "{app}"; Flags: ignoreversion; Components: spherestudio
Source: "Sphere Studio\bin\Release\*.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: spherestudio
Source: "Sphere Studio\bin\Release\SphereLexer.xml"; DestDir: "{app}"; Flags: ignoreversion; Components: spherestudio
Source: "Sphere Studio\bin\Release\Sphere.Plugins.xml"; DestDir: "{app}"; Flags: ignoreversion; Components: spherestudio
Source: "Sphere Studio\bin\Release\Docs\*"; DestDir: "{app}\Docs"; Flags: ignoreversion; Components: spherestudio
Source: "Sphere Studio\bin\Release\Plugins\*.dll"; DestDir: "{app}\Plugins"; Flags: ignoreversion; Components: classic

[Registry]
Root: HKCR; Subkey: ".ssproj"; ValueType: string; ValueName: ""; ValueData: "SphereStudio.SSPROJ"; Flags: uninsdeletevalue
Root: HKCR; Subkey: "SphereStudio.SSPROJ"; ValueType: string; ValueName: ""; ValueData: "Sphere Studio Project"; Flags: uninsdeletekey
Root: HKCR; Subkey: "SphereStudio.SSPROJ\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\SphereStudioIDE.exe,0"
Root: HKCR; Subkey: "SphereStudio.SSPROJ\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\SphereStudioIDE.exe"" ""%1"""

[Icons]
Name: "{commonprograms}\{#AppName} IDE"; Filename: "{app}\SphereStudioIDE.exe"
Name: "{commondesktop}\{#AppName} IDE"; Filename: "{app}\SphereStudioIDE.exe"; Tasks: desktop

[Run]
Filename: "{app}\SphereStudioIDE.exe"; Description: "{cm:LaunchProgram,{#StringChange(AppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
