### Summae ###

This a is small tool capable of calculating checksums using CRC-16, CRC-32,
MD-5, RIPE-160, SHA-1, SHA-256, SHA-384, and SHA-512 algorithm.


#### Shortcut Keys ####

  * `F5`                      Start calculations
  * `Ctrl+N`                  Clear list
  * `Ctrl+O`                  Add files to list



#### Command Line Options ####


##### Summae.exe

    Summae.exe [/crc16] [/crc32] [/md5] [/ripemd160] [/sha1] [/sha256] [/sha384] [/sha512] filename

* `/crc16`:     Calculations are done using IEEE 802.3 defined CRC-16 algorithm.
* `/crc32`:     Calculations are done using IEEE 802.3 defined CRC-32 algorithm.
* `/md5`:       Calculations are done using MD-5 hashing algorithm.
* `/ripemd160`: Calculations are done using RIPE MD-160 hashing algorithm.
* `/sha1`:      Calculations are done using SHA-1 hashing algorithm.
* `/sha256`:    Calculations are done using SHA-256 hashing algorithm.
* `/sha384`:    Calculations are done using SHA-384 hashing algorithm.
* `/sha512`:    Calculations are done using SHA-512 hashing algorithm.
* `filename`:   Specifies name of file or files on which calculations are to be done.

If multiple methods are specified, all calculations are done in parallel and
disk access is done only once regardless of number of algorithms selected.

If more than one file is specified, calculation will be done in parallel.


##### Sum.exe

All command-line parameters are same as for Summae.exe.

Calculations are done in a serialized fashion, i.e. one file after the other.

If hashing method is not specified, SHA-1 is used. If multiple methods are
specified, all calculations are done in parallel and disk access is done only
once regardless of number of algorithms selected.

###### Exit codes

* `0`: Execution completed successfuly.
* `1`: File name not specified.
* `2`: File access exception.
