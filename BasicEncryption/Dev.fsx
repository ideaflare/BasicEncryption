#load "Domain.fs"
#load "Transposition.fs"
#load "Rotation.fs"
#load "Substitution.fs"
#load "TextOperations.fs"
open Domain
open TextOperations
open Substitution

// substitution -------------------------------

let sub = substituteList keymap replaceMap;;
let fix = substituteList replaceMap keymap;
let testText = "Mary had a little lamb?"
let encoded = sub (charList testText)
let decrypted = fix (charList "sc\{)xcl)c)JA&&Jo)JcMf*")

decrypted |> stringFromCharList = testText

// transposition --------------------------------

let filePath = """C:\MyTemp\findme.txt"""
let stringText = System.IO.File.ReadAllText(filePath)

printfn "size: %i content: %A" stringText.Length stringText

"Myaaillba d tearh lt m" = transpose 3 stringText







