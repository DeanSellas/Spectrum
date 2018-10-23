@echo off
title Build Spectrum
echo Spectrum Builder V1.0
echo Created by Dean Sellas
echo Provided Under The MIT License  & echo.&

:top

set /P userInput= Dev[0] Or Public[1] Build (Input 0 or 1): 


if %userInput% == 0 (
	echo Development Build
	CALL :moveFilesDev
)
if %userInput% == 1 (
	echo Public Build
	CALL :moveFilesPublic
)
if NOT %userInput% == 0 (
	if NOT %userInput% == 1 (
		echo cls
		echo Please Enter 0 or 1!
		GOTO:top
	)
)
pause
EXIT

REM MOVE FILES FUNCTION
:moveFilesPublic
	echo Moving Files...
	mkdir Public\Files\Settings

	copy ..\Spectrum\bin\Release\*.exe Public\Files
	copy ..\Spectrum\bin\Release\Settings\* Public\Files\Settings

	C:
	cd "Program Files (x86)\NSIS"
	makensis.exe "D:\Dean's Files\GoogleDrive\Documents\Projects\C#\Spectrum\Installer\Public\Spectrum.nsi"
	echo 
	echo Spectrum is Built!
EXIT /B 0

:moveFilesDev
	echo Moving Files...
	mkdir DevBuild\Files\Settings

	copy ..\Spectrum\bin\Debug\*.exe DevBuild\Files
	copy ..\Spectrum\bin\Debug\Settings\* DevBuild\Files\Settings
	
	C:
	cd "Program Files (x86)\NSIS"
	makensis.exe "D:\Dean's Files\GoogleDrive\Documents\Projects\C#\Spectrum\Installer\DevBuild\Spectrum.nsi"
	echo Spectrum is Built!
EXIT /B 0