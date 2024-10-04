@echo off
set SERVICE_HOME=D:\Hosting\VideoSync\
set SERVICE_EXE=VNN_VIDEOSVC.exe
set INSTALL_UTIL_HOME=C:\WINDOWS\microsoft.net\Framework\v2.0.50727\

set PATH=%PATH%;%INSTALL_UTIL_HOME%

cd %SERVICE_HOME%

echo Uninstalling Service...
installutil /name=VNN_VIDEOSVC %SERVICE_EXE%

echo Done.