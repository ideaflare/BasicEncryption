#load "Domain.fs"
#load "Transposition.fs"
#load "Rotation.fs"
#load "Substitution.fs"
#load "TextOperations.fs"
#load "KeyMap.fs"
open Domain
open TextOperations
open Substitution
open Rotation
open KeyMap

// general test setup
let testPlainText = "Mary had a little lamb?"
let testCharList = testPlainText |> charList