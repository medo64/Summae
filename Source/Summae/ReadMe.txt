Shortcut keys
~~~~~~~~~~~~~

F5                  Start calculations
Ctrl+N              Clear list
Ctrl+O              Add files to list



Command line options (Summae.exe)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

[filename]

filename
Specifies name of file or files that will be added to list.



Command line options (SummaeExecutor.exe)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

[/crc16] [/crc32] [/md5] [/sha1] [/sha256] [/sha384] [/sha512] filename

/crc16
Calculations are done using IEEE 802.3 defined CRC-16 algorithm.

/crc32
Calculations are done using IEEE 802.3 defined CRC-32 algorithm.

/md5
Calculations are done using MD-5 hashing algorithm.

/ripemd160
Calculations are done using RIPE MD-160 hashing algorithm.

/sha1
Calculations are done using SHA-1 hashing algorithm.

/sha256
Calculations are done using SHA-256 hashing algorithm.

/sha384
Calculations are done using SHA-384 hashing algorithm.

/sha512
Calculations are done using SHA-512 hashing algorithm.

/filename
Specifies name of file or files on which calculations are to be done.


If hashing method is not specified, SHA-1 is used. If multiple methods are
specified, all calculations are serialized in one thread and disk access is
done only one time regardless of selected number of algorithms.
If more than one file is specified, calculations for additional files will
be done in new instance.


Exit codes:
0: Execution completed successfuly.
1: File name not specified.
2: File access exception.



Command line options (Sum.exe)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

All command-line parameters are same as for SummaeExecutor.exe.
Only difference in behaviour comes when multiple files are passed as parameter.
While SummaeExecutor.exe will create new instance for each file, Sum.exe will
do calculations one after another in same instance.



Command line options (SummaeSettings.exe)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

This executable is used by Summae.exe for setting options that need
administrative priviledges. Command-line parameters are undefined and they
can (and probably will) change from version to version.



Version 1.10             [2012-09-24]
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

- command-line can make sum of directories
- command-line supports basic patterns (? and *)
- no registry writes will be performed if application is not installed


Version 1.01             [2010-01-17]
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

- fixed text box width on Windows XP
- last choice of methods is now remembered in main program
- fixed issues when window would get outside of screen border


Version 1.00             [2009-12-16]
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

- First public release.



Licence [MIT]
~~~~~~~~~~~~~

Copyright (c) 2009 Josip Medved <jmedved@jmedved.com>

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
