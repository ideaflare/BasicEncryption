#load "Domain.fs"
#load "Transposition.fs"
#load "Rotation.fs"
#load "Substitution.fs"
#load "TextOperations.fs"
open Domain
open TextOperations
open Substitution
open Rotation

// Todo
// 1. Call tests with test framework / tasks
// 2. Property based tests all the things \(",)/

// general test setup
let testPlainText = "Mary had a little lamb?"
let testCharList = testPlainText |> charList

// substitution -------------------------------

let sub = substituteList keymap replaceMap;;
let fix = substituteList replaceMap keymap;
let encoded = sub testCharList
let decrypted = fix (charList "sc\{)xcl)c)JA&&Jo)JcMf*")

decrypted |> stringFromCharList = testPlainText

// transposition --------------------------------

let filePath = """C:\MyTemp\findme.txt"""
let stringText = System.IO.File.ReadAllText(filePath)

printfn "size: %i content: %A" stringText.Length stringText

"Myaaillba d tearh lt m" = transpose 3 stringText

// rotation ----------------------------------

let emptyInput : int list = []

let wrapLeft = Rotation.apply
let wrapRight = Rotation.undo //unapply ?
wrapLeft 0 emptyInput = wrapLeft -3 emptyInput
wrapLeft System.Int32.MinValue emptyInput = wrapLeft System.Int32.MaxValue emptyInput
wrapRight 5 (wrapLeft 5 testCharList) = testCharList





