# Copyright (C) 2008-2011 by Schima
# schimatk@gmail.com
#
# OpenCvSharp is free software: you can redistribute it and/or modify
# it under the terms of the Lesser GNU General Public License as published by
# the Free Software Foundation, either version 3 of the License, or
# (at your option) any later version.
#
# OpenCvSharp is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# Lesser GNU General Public License for more details.
#
# You should have received a copy of the Lesser GNU General Public License
# along with OpenCvSharp.  If not, see <http://www.gnu.org/licenses/>.


===== Files =====
Essential file : OpenCvSharp.dll
                  
Optional files  : OpenCvSharp.MachineLearning.dll
                  OpenCvSharp.Blob.dll
                  OpenCvSharp.UserInterface.dll
                  OpenCvSharp.Extensions.dll
                  OpenCvSharp.CPlusPlus.dll

                  OpenCvSharpExtern.dll
             
Add references to these dll files.


===== OpenCvSharpExtern.dll =====
OpenCvSharpExtern.dll is not .NET binary but native binary. 
This is to invoke C++ functions and classes from managed code. 
When you use Blob, MachineLearning, and CPlusPlus namespaces, 
you need to put a OpenCvSharpExtern.dll into the executable directory (ex. bin/Debug).

The standard OpenCvSharpExtern.dll is compiled by VS2008. 
When you yourself compile OpenCV's DLLs by VS2010  use an alternative DLL 
which is in the "OpenCvSharpExtern.dll built by VC++2010" directory instead.

OpenCvSharpExtern.dllは.NETバイナリではなくネイティブのDLLです。
これはC++の関数やクラスをマネージコードから呼び出すためのものです。
Blob・MachineLearning・CPlusPlus の名前空間を利用する際は、
OpenCvSharpExtern.dllを実行ファイルがあるディレクトリ(例：bin/Debug)に置いてください。


===== Requirements =====
+ OpenCV 2.3.1
+ .NET Framework 2.0 (Windows) or Mono (other platforms)
     * .NET Framework 2.0
		- You may have to install "Visual C++ 2005/2008/2010 SP1 Redistributable Package".
     * Mono
		- When you use OpenCvSharp under Mono, change the mapping in OpenCvSharp.dll.config accordingly


===== Version =====
2.4


===== Description =====
This is a wrapper in order to use OpenCV on .NET Framework.

OpenCV (http://opencv.jp/opencv_org/docs/index.htm) を.NET Frameworkから利用するためのラッパーです。
OpenCVのバージョンは、OpenCvSharpと同じ番号のバージョンが必要です。


===== License =====
LGPL (http://www.gnu.org/licenses/lgpl.html)


===== Library =====
+ Qt 4.7.2 (LGPL)


===== XML Document Comments =====
Intellisenseで表示されるXMLドキュメントコメントは「OpenCV リファレンス マニュアル（日本語訳）」(http://opencv.jp/document/) 
から引用しています。OpenCvSharpの仕様に合わせ多少改変しています。