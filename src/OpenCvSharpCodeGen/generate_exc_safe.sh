#!/bin/bash
# crash when sth fails
set -e

natMethodsPath="../OpenCvSharp/PInvoke/NativeMethods/"
hiddenNatMethodsPath="../OpenCvSharp/PInvoke/.NativeMethods/"
genFileNameNM="NativeMethods_generated.cs"
genFileNameNME="NativeMethodsExc_generated.cs"

externPath="../../OpenCvSharpExtern/"
genFileNameBase="exc_safe_generated"
genFileNameHeader=$genFileNameBase".h"
genFileNameSrc=$genFileNameBase".cpp"

if [ -d $hiddenNatMethodsPath ] 
then
    echo $hiddenNatMethodsPath" does already exists exists" 
    exit 1 
fi

echo "generate C# code"
cd csharp_gen
# TODO: Might not work everywhere
dotnet run
cd ..
echo "hide NativeMethods folder"
mv $natMethodsPath $hiddenNatMethodsPath
echo "move generated files to new folder "$natMethodsPath
mkdir $natMethodsPath
mv $genFileNameNM $natMethodsPath$genFileNameNM
mv $genFileNameNME $natMethodsPath$genFileNameNME
echo "generate C++ Code"$natMethodsPath
cd cpp_gen
# script moves the gen. file into OpenCvSharpExtern 
python3 generate_header_file.py

bash generate_header_include_file.sh $externPath $genFileNameBase
echo "finished"

