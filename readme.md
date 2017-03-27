# Goal of this project:

To encrypt a body of text using the following recipe:

* Swap          : Exchange places of letters
* Transposition : Jumble around letters
* Substitution  : Replace letters with other letters

## The ingredients are:

* A keymap: ```abc..ABC..123..!@#$%^```
* A substitution keymap: initially copy of the original keymap
* A password: Password1
* A number G = 2

## for each letter in  the password, do:
### transpose & wrap around body
1. row transposition body with size = keymap.indexOf(letter)
2. 	swap 10 first letters of body with last 10 letters, since a transposition doesn't move the 1st character around much
### transpose & wrap around substitution keymap
3. G := (G + keymap.indexOf(letter)) % keymap size
4. row transposition substitution keymap by G places
5. swap (G/2) first letters of keymap with the last
### apply substitution
6. apply substitution to the first half of the body using the substitution keymap

*And do the reverse to decrypt the body*

#### Coming soon:
A reward for cracking a file encrypted with this algorithm:
* File containing 0.1 Bitcoin _(around $100 early 2017)_

The reward is yours to keep, but please do comment/wiki how you did it :)