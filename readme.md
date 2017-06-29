# Warning

* Don't roll your own encryption, use something known like TrueCrypt or 7z built in AES encryption
* This is intended just for play

# Usage
 * To encrypt:
   `BasicEncryption.exe -e fileName`
 * To decrypt:
   `BasicEncryption.exe -d fileName`

Add `>` to the end if you want to output to a file, for example:
  `BasicEncryption.exe -d test.txt > temp.txt`

## Goal of this project:

To practice F#, by encrypting a body of text using some basics of encryption:

* Transposition : Exchange places of letters
* Substitution  : Replace letters with other letters
