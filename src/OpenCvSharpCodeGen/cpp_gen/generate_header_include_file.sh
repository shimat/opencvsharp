#!/bin/bash
# crash when sth fails
set -e
# generates all the files to be included by the generated cp code
searchDir=$1
targetDir=$searchDir
targetName=$2
headerFileName=$targetName".h"
srcFileName=$targetName".cpp"

# check if folders does exists:
if [ ! -d $searchDir ] 
then
    echo $searchDir" does not exists" 
    exit 1 
fi
echo $targetName
cd $searchDir
includeString=""
echo "Find every header file in "$searchDir
for entry in *
do
  fileName=$(basename -- "$entry")
  extension="${entry##*.}"
  if [ "$extension" = "h" ] && [  "$fileName" != "$headerFileName" ];
  then
    includeString=$includeString"#include \"$fileName\"\n"
  fi
done
# Add fileName last
includeString=$includeString"#include \"$headerFileName\""

#echo -e $includeString
if [ -f $srcFileName ] 
then
  echo "Already a file in "$srcFileName  
  rm $srcFileName
fi
touch $srcFileName
echo "Write header file"
echo -e $includeString >> $srcFileName
