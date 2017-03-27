basic ideas of encryption:

Transposition : To jumble around letters
Substitution  : To replace letters with other letters

Goal of this project:

To encrypt a body of text using the following recipe:

A keymap: 12324567890-=~!@#$%^&*()_+qwertyuiop[]asdfghjkl;'zcvxbnm,./QWERTYUIPOASDFGHJKL;ZCVNM,
A substitution keymap: initially copy of the original keymap
A password: Password1
A number G = 2

for each letter in  the password, do:
	-- transpose & wrap around body
	row transposition body with size = keymap.indexOf(letter)
	swap 10 first letters of body with last 10 letters, since a transposition doesn't move the 1st character around much
	-- transpose & wrap around substitution keymap
	G := (G + keymap.indexOf(letter)) % keymap size
	row transposition substitution keymap by G places
	swap (G/2) first letters of keymap with the last
	-- apply substitution
	Apply substitution to the first half of the body using the substitution keymap

And do the reverse to decrypt the body