### Summae ###

This a is small tool capable of calculating CRC-16, CRC-32, MD-5, RIPE-160, SHA-1 and other variants.


#### Shortcut Keys ####

  * `F5`                      Start calculations
  * `Ctrl+N`                  Clear list
  * `Ctrl+O`                  Add files to list



#### Command Line Options ####

#### Summae.exe

    Summae.exe [filename]

* `filename`: Specifies name of file or files that will be added to list.


#### SummaeExecutor.exe

    SummaeExecutor.exe [/crc16] [/crc32] [/md5] [/sha1] [/sha256] [/sha384] [/sha512] filename

* `/crc16`:     Calculations are done using IEEE 802.3 defined CRC-16 algorithm.
* `/crc32`:     Calculations are done using IEEE 802.3 defined CRC-32 algorithm.
* `/md5`:       Calculations are done using MD-5 hashing algorithm.
* `/ripemd160`: Calculations are done using RIPE MD-160 hashing algorithm.
* `/sha1`:      Calculations are done using SHA-1 hashing algorithm.
* `/sha256`:    Calculations are done using SHA-256 hashing algorithm.
* `/sha384`:    Calculations are done using SHA-384 hashing algorithm.
* `/sha512`:    Calculations are done using SHA-512 hashing algorithm.
* `/filename`:  Specifies name of file or files on which calculations are to be done.

If hashing method is not specified, SHA-1 is used. If multiple methods are
specified, all calculations are serialized in one thread and disk access is
done only one time regardless of selected number of algorithms.

If more than one file is specified, calculations for additional files will be
done in a new instance.


##### Exit codes

* `0`: Execution completed successfuly.
* `1`: File name not specified.
* `2`: File access exception.



#### Sum.exe

All command-line parameters are same as for SummaeExecutor.exe. Only difference
in behaviour comes when multiple files are passed as parameter. While
SummaeExecutor.exe will create new instance for each file, Sum.exe will do
calculations one after another in same instance.



#### SummaeSettings.exe

This executable is used by Summae.exe for setting options that need
administrative priviledges. Command-line parameters are undefined and they can
(and probably will) change from version to version.
