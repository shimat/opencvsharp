""" This module uses the c++ header files of opencvsharp to generate a new header which servers as supplementary 
    layer between the current c++ headers and the pinvoke boundary. 
    Every function to the current c++ header files are wrapped in a try-catch-block
    The return value of the generated functions indicates the occurence of an exception
"""
import sys
import re
import os


from typing import Tuple, List

PADDING = 4
EXC_SAFE_FUNC_SUFFIX = "_excsafe"
GEN_FILE_NAME = "exc_safe_generated.h"

def main():
  externDir = "../../OpenCvSharpExtern/"
  targetDir = externDir
  generatedFileHeader = """\
#ifndef _CPP_GENERATED_NATIVE_FUNC_H_
#define _CPP_GENERATED_NATIVE_FUNC_H_

// THIS CLASS IS GENERATED

#include "include_opencv.h"
"""
  generatedFileFooter = """#endif"""
  filepaths = getFilesPaths(externDir)
  generatedFileFunctionsTemplate = "{}\n"*len(filepaths)
  fileStrings = []
  for filePath in filepaths:
    with open(filePath, 'r') as file:
      fileString = str(file.read())
      fileStrings.append(getNewFileString(fileString))
  generatedFileString = "{}{}{}".format(generatedFileHeader, generatedFileFunctionsTemplate.format(*fileStrings), generatedFileFooter)
  with open(os.path.join(targetDir, GEN_FILE_NAME), 'w') as file:
    file.write(generatedFileString) 
 

""" Iterate over every  file recursively, return list of files """
def getFilesPaths(rootDir: str) -> List[str]:
  filepaths = [] 
  for subdir, dirs, files in os.walk(rootDir):
    for file in files:
      if file.endswith(".h") and not file == GEN_FILE_NAME:
        filepaths.append(os.path.join(subdir, file))
  return filepaths


""" Given the content of a file, return the new functions as string"""
def getNewFileString(fileString: str) -> str:
  newFunctions = getNewFunctions(fileString)
  newFileString = "{}\n" * len(newFunctions)
  return newFileString.format(*newFunctions)


def getNewFunctions(fileString: str) -> List[str]:
  functions = getFunctions(fileString)
  return list(map(getNewFunctionString, functions))


""" Given a string yielded from a header file, extracts all the function substrings.
    Assuming nested functions/blocks possible
    Assumes the line begins with the characters 'CVAPI'
"""
def getFunctions(fileString: str) -> List[str]:
  def findComments(fileString: str) -> List[str]:
    comments = []
    index = 2
    while index < len(fileString):
      index += 1
      if fileString[(index-2):index] == "/*":
        begCom = index-2
        while index < len(fileString):
          if fileString[(index-2):index] == "*/":
            comments.append( fileString[begCom:index])
            break
          index += 1
    return comments 

  def removeComments(fileString, comments):
    for comment in comments:
      fileString = fileString.replace(comment, "")
    return fileString

  comments = findComments(fileString)
  fileString = removeComments(fileString, comments)

  # find all function that begin with "CVAPI"
  pattern = re.compile(r'^CVAPI.*?{.*?}', re.MULTILINE|re.DOTALL)
  # get every index of the occurences of CVAPI
  funBeg = list(re.finditer(pattern, fileString))
  # TODO: this could better be done by using recursive regex
  functionStrings = []
  for item in funBeg:
    beg, end = item.start(), item.end()
    currentString = fileString[beg:end]
    # Count occ of {
    cOpenBrac = currentString.count("{")
    cCloseBrac = currentString.count("}")
    while cOpenBrac > cCloseBrac:
      end += 1
      if fileString[end-1] == "}":
        cCloseBrac += 1
      elif fileString[end-1] == "{":
        cOpenBrac += 1
    functionString = fileString[beg:end]
    if not "CVAPI_EXC" in functionString: 
      functionStrings.append(functionString)
  return functionStrings


def getNewFunctionString(functionString: str) -> str:
  signature, _, _ = splitFunctionString(functionString)
  returnType, funcName , parameterList = splitSignature(signature)

  def getParameterString(parameterList):
    # Add return value to parameterlist if necessary
    parameterString = ""
    if len(parameterList) > 1:
      parameterString = parameterList[0]
      for entry in parameterList[1:]:
        parameterString += ", {}".format(entry) 
    elif len(parameterList) == 1:
      parameterString = "{}".format(parameterList[0])
    return parameterString.strip()

  def getParameterName(parameterString):
    end = len(parameterString)
    while parameterString[end-1] == " " :
      end=end-1
    beg = end-1
    while( not  (parameterString[beg:beg+1] == " " or parameterString[beg:beg+1] == "*" or  parameterString[beg:beg+1] == "&" )  ):
      beg -= 1
    return parameterString[(beg+1):end]

  parameterString = getParameterString(list(map(getParameterName, parameterList)))
  retString = ""
  if not returnType == "void":
    retString = "ret = "
    parameterList.insert(0, " {} &ret".format(returnType))
  newParameterString = getParameterString(parameterList)

  # body hast a try catch block and  calls the appropriate function
  body = """try
    \t{{
    \t    {0}{1}({2});
    \t    return false;
    \t}}
    \tcatch(std::exception e)
    \t{{
    \t    return true;
    \t}}
    """.format(retString, funcName, parameterString)
  newFuncName = funcName + EXC_SAFE_FUNC_SUFFIX
  newFunctionString = "CVAPI(bool) {} ({}) {{\n {} }}".format(newFuncName, newParameterString, body)
  return newFunctionString


def splitSignature(signature: str) -> Tuple[str, str, List[str]]:
  def getReturnType(signature: str) -> str:
    typeStringMatch =  re.match(r'(CVAPI\()(.*?)(\))', signature)
    typeString = typeStringMatch.group(2)
    return typeString
  def getName(signature: str) -> str:
    nameStringMatch =  re.match(r'(CVAPI\()(.*?)(\))(.*?)\(', signature)
    return  nameStringMatch.group(4)
  def getParameterList(signature: str) -> List[str]:
    end = len(signature)-1
    while not signature[end] == ")":
      end -= 1;
    beg = end
    cOpenBrac = 0
    cCloseBrac = 1
    while not cOpenBrac == cCloseBrac:
      beg -= 1
      if signature[beg] == ")":
        cCloseBrac += 1
      elif signature[beg] == "(":
        cOpenBrac += 1
    parameterString = signature[beg+1:end].strip()
    if parameterString == "":
      return []
    else:
      return parameterString.split(",")
  return getReturnType(signature), getName(signature), getParameterList(signature)


""" Takes a function String and splits it into a prefix, its content and a suffix (})
"""
def splitFunctionString(funcString: str)->Tuple[str,str,str]:
  # first occurrence of "{"    
  prefixEndIndex = funcString.index("{")+1
  #iterate to the first occurence of a new char which is not space, tab or newline and newline has not been reached yet
  while funcString[prefixEndIndex] in " \t\n" and not funcString[prefixEndIndex-1] == "\n" :
    prefixEndIndex += 1
  # outermost "}" 
  suffixBeginIndex = funcString.rindex("}")
  #iterate backwards to the first occurence of a new char which is not space, tab or newline and newline has not been reached yet
  while funcString[suffixBeginIndex-1] in " \t\n" and not funcString[suffixBeginIndex] == "\n" :
    suffixBeginIndex -= 1

  prefix = funcString[:prefixEndIndex]
  innerBlock = funcString[prefixEndIndex:suffixBeginIndex]
  suffix = funcString[suffixBeginIndex:]
  return (prefix,innerBlock,suffix)


#def getNewHeaderFileString(fileString: str) -> str:
#  functions = getFunctions(fileString)
#  return "\n".join(list(map(getNewFunctionDecl, functions)))


#def getNewFunctionDecl(functionString):
#  signature, _, _ = splitFunctionString(functionString)
#  lastBrac = len(signature)-1
#  while not functionString[lastBrac] == ")":
#    lastBrac -= 1
#  signature = signature[:lastBrac+1]
#  signature += ";"
#  return signature

if __name__ == "__main__":
  main()
