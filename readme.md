# Warning

* Don't roll your own encryption, use something known like TrueCrypt or 7z built in AES encryption
* This is intended just for play

# Usage
`BasicEncryption.exe [encrypt/decrypt] [key1] [key2] [filePath]`

Choose 2 numbers smaller than the number of characters in a file you want to encrypt.
For example, file has length of 593 characters, choose 23 and 17 arbitrarily.
 * To encrypt:
   `BasicEncryption.exe -e 23 17 fileName`
 * To decrypt:
   `BasicEncryption.exe -d 23 17 fileName`

Add `>` to the end if you want to output to a file, for example:
  `BasicEncryption.exe -d test.txt > temp.txt`

## Goal of this project:

To practice F#, by encrypting a body of text using some basics of encryption:

* Transposition : Exchange places of letters
* Substitution  : Replace letters with other letters
