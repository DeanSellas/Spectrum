@echo off
title Build Spectrum
echo Spectrum Builder V1.0
echo Created by Dean Sellas
echo Provided Under The MIT License  & echo.&

:top

set /P userInput= Dev[0] Or Public[1] Build (Input 0 or 1): 


if %userInput% == 0 (
	echo testing
	CALL :moveFilesDev
)
if %userInput% == 1 (
	echo testing
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
	copy ..\Spectrum\bin\Release\*.exe Public\Files
	Public\Spectrum.nsi
	cls
	echo Prosses Is Done Spectrum is Built!
EXIT /B 0

:moveFilesDev
	echo Moving Files...
	copy ..\Spectrum\bin\Debug\*.exe DevBuild\Files
	DevBuild\Spectrum.nsi
	cls
	echo Prosses Is Done Spectrum is Built!
EXIT /B 0