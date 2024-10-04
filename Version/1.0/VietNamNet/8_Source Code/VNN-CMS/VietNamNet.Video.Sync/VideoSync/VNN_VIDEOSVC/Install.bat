@echo off
set SERVICE_HOME=<service executable directory>
set SERVICE_EXE=<service executable name>
set INSTALL_UTIL_HOME=C:\Windows\Microsoft.NET\Framework\v2.0.50727

set PATH=%PATH%;%INSTALL_UTIL_HOME%

cd %SERVICE_HOME%

echo Uninstalling Service...
installutil /u /name=<service name> %SERVICE_EXE%

echo Done.