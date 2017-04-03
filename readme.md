# Goal of this project:

To encrypt a body of text using the basics of encryption:

* Transposition : Exchange places of letters
* Substitution  : Replace letters with other letters

## The ingredients are:

* A keymap that contains all the letters on the keyboard ```abc..ABC..123..!@#$%^```
* A substitution keymap. Initially copy of the original keymap, used to substitute letters with their corresponding index in the keymap
* A password: Password1
* A number G = 2

## The algorithm is:
1. (Optional/Eventually) to add any letters not in the keymap to the keymap, to shuffle the keymap, and to save it pre-pended to the encrypted message. Alternative could be to ignore any non-keymap letters and leave them unencrypted.
2. To encrypt via the following:

## For each letter in  the password, do:
### transpose & wrap around body

2.1 row transposition body with size = keymap.indexOf(letter)
2.2 	swap 10 first letters of body with last 10 letters, since a transposition doesn't move the 1st character around much

### transpose & wrap around substitution keymap

2.3 G := (G + keymap.indexOf(letter)) % keymap size
2.4. row transposition substitution keymap by G places
2.5 swap (G/2) first letters of keymap with the last
### apply substitution

2.6 apply substitution to the first half of the body using the substitution keymap

*And do the reverse to decrypt the body*

#### Coming soon:
A reward for cracking a file encrypted with this algorithm:
* File containing 0.1 Bitcoin _(around $100 early 2017)_

The reward is yours to keep, but please do comment/wiki how you did it :)