"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" /t:Rebuild /p:Configuration=Release Tracki.sln
set folder="C:/Tracki"
if not exist %folder% mkdir %folder%
cp -R Tracki/bin/Release/* %folder%