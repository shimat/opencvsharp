#!/bin/bash
# crash when sth fails
set -e

natMethodsPath="../OpenCvSharp/PInvoke/NativeMethods/"
hiddenNatMethodsPath="../OpenCvSharp/PInvoke/.NativeMethods/"

genFileNameNM="NativeMethods_generated.cs"
genFileNameNME="NativeMethodsExc_generated.cs"

externPath="../OpenCvSharpExtern/"
genFileNameBase="exc_safe_generated"
genFileNameHeader=$genFileNameBase".h"
genFileNameSrc=$genFileNameBase".cpp"

echo "remove generated C# code"
# check if folders does exists:
if [ ! -d $natMethodsPath ] 
then
    echo $natMethodsPath" does not exists" 
    exit 1 
fi
if [ ! -d $hiddenNatMethodsPath ] 
then
    echo $hiddenNatMethodsPath" does not exists" 
    exit 1 
fi

rm $natMethodsPath$genFileNameNM
rm $natMethodsPath$genFileNameNME
rm -r $natMethodsPath

echo "move Native Methods back "
mv $hiddenNatMethodsPath $natMethodsPath

echo "remove generated C++ code"
rm $externPath$genFileNameHeader
rm $externPath$genFileNameSrc
echo "finished"

