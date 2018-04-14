;NSIS Modern User Interface
;Welcome/Finish Page Example Script
;Written by Joost Verburg




; Uninstall Before Upgrade
  Function .onInit

 ReadRegStr $R0 HKLM Software\Microsoft\Windows\CurrentVersion\Uninstall\Spectrum" \
  "UninstallString"
  StrCmp $R0 "" done
  
MessageBox MB_OKCANCEL|MB_ICONEXCLAMATION \
  "Spectrum is already installed. $\n$\nClick `OK` to remove the \
  previous version or `Cancel` to cancel this upgrade." \
  IDOK uninst
  Abort
 
;Run the uninstaller
uninst:
    ClearErrors
    Exec "$INSTDIR\SpectrumUninstall.exe"
  done:
 
FunctionEnd



;--------------------------------
;Include Modern UI

  !include "MUI2.nsh"
  !include "nsDialogs.nsh"
  


;--------------------------------
;General

  ;Name and file
  Name "Spectrum"
  OutFile "spectrumv0.2setup.exe"
  
  !define MUI_PRODUCT "Spectrum"
  !define MUI_FILE "Spectrum"
  CRCCheck On

  ;Default installation folder
  InstallDir "$LOCALAPPDATA\Spectrum"

  ;Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\Spectrum" ""

  ;Request application privileges for Windows
  RequestExecutionLevel admin

;--------------------------------
;Interface Settings

  !define MUI_ABORTWARNING

;--------------------------------
;Pages
  !insertmacro MUI_PAGE_WELCOME
  !insertmacro MUI_PAGE_LICENSE "Files/LICENSE"
  ;!insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES
  !insertmacro MUI_PAGE_FINISH

  !insertmacro MUI_UNPAGE_WELCOME
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  !insertmacro MUI_UNPAGE_FINISH

;--------------------------------
;Languages

  !insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Installer Sections

Section "Dummy Section" SecDummy

  SetOutPath "$INSTDIR"

  ;ADD YOUR OWN FILES HERE...
  File /r "Files\*"
  
  ;Store installation folder
  WriteRegStr HKCU "Software\${MUI_FILE}" "" $INSTDIR
  
  
  ;create desktop shortcut
   CreateShortCut "$DESKTOP\${MUI_PRODUCT}.lnk" "$INSTDIR\${MUI_FILE}.exe" ""
 
  ;create start-menu items
   CreateDirectory "$SMPROGRAMS\${MUI_PRODUCT}"
   CreateShortCut "$SMPROGRAMS\${MUI_PRODUCT}\Uninstall.lnk" "$INSTDIR\SpectrumUninstall.exe" "" "$INSTDIR\SpectrumUninstall.exe" 0
   CreateShortCut "$SMPROGRAMS\${MUI_PRODUCT}\${MUI_PRODUCT}.lnk" "$INSTDIR\${MUI_FILE}.exe" "" "$INSTDIR\${MUI_FILE}.exe" 0
 
;write uninstall information to the registry
  WriteRegStr HKLM Software\Microsoft\Windows\CurrentVersion\Uninstall\Spectrum" \
    "DisplayName" "Spectrum"
  WriteRegStr HKLM Software\Microsoft\Windows\CurrentVersion\Uninstall\Spectrum" \
    "UninstallString" "$INSTDIR\SpectrumUninstall.exe"
  WriteRegStr HKLM Software\Microsoft\Windows\CurrentVersion\Uninstall\Spectrum" \
    "Publisher" "Dean Sellas"
  WriteRegStr HKLM Software\Microsoft\Windows\CurrentVersion\Uninstall\Spectrum" \
    "DisplayIcon" "$INSTDIR\Spectrum.exe"
    
  

  ;Create uninstaller
  WriteUninstaller "$INSTDIR\SpectrumUninstall.exe"

SectionEnd

;--------------------------------
;Descriptions

  ;Language strings
  LangString DESC_SecDummy ${LANG_ENGLISH} "A test section."

  ;Assign language strings to sections
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT ${Section1} $(DESC_Section1)
    !insertmacro MUI_DESCRIPTION_TEXT ${Section2} $(DESC_Section2)
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

;--------------------------------
;Uninstaller Section

Section "Uninstall"

  ;ADD YOUR OWN FILES HERE...

  ;Delete "$INSTDIR\*\*"

  RMDir /r "$INSTDIR"

  ;Delete Start Menu Shortcuts
  Delete "$DESKTOP\${MUI_PRODUCT}.lnk"
  Delete "$SMPROGRAMS\${MUI_PRODUCT}\*.*"
  RmDir  "$SMPROGRAMS\${MUI_PRODUCT}"
 
;Delete Uninstaller And Unistall Registry Entries
  DeleteRegKey HKLM "Software\Spectrum"
  DeleteRegKey HKLM Software\Microsoft\Windows\CurrentVersion\Uninstall\Spectrum"  

SectionEnd
