@echo off
setlocal enableextensions
set PATH=%CD%\tools\ruby\bin;%PATH%;
tools\ruby\bin\rake %*
endlocal
