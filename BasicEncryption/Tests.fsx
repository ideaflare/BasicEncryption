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

// Todo
// 1. Call tests with test framework / tasks
// 2. Property based tests all the things \(",)/

// general test setup
let testPlainText = "Mary had a little lamb?"
let testCharList = testPlainText |> charList

// substitution -------------------------------

let testKeymap = buildKeyMap testCharList

let testReplaceMap =
    testKeymap
    |> (Transposition.apply 3)
    |> (Rotation.apply 2)

let sub = substituteList testKeymap testReplaceMap;;
let fix = substituteList testReplaceMap testKeymap;
let encrypted = sub testCharList 
let decrypted = fix encrypted

encrypted <> decrypted
decrypted |> stringFromCharList = testPlainText


// transposition --------------------------------

let filePath = """C:\MyTemp\findme.txt"""
let stringText = System.IO.File.ReadAllText(filePath)

printfn "size: %i content: %A" stringText.Length stringText

"Myaaillba d tearh lt m" = transpose 3 stringText

let zeroAndNegativeTransposeAreSame =
    let zero = transpose 0 testPlainText
    let negative = transpose -5 testPlainText
    zero = negative

let nullAndEmptyYieldsSame =
    transpose 5 (null : string) = transpose 5 ""

let applyAndUndoGiveSameResult (plaintext : string) =
    let r = System.Random()
    let tSize = r.Next(0, plaintext.Length + 5)
    let cypher = transpose tSize plaintext
    let decrypted = undoTranspose tSize cypher
    plaintext = decrypted

applyAndUndoGiveSameResult "Some test string"

// rotation ----------------------------------

let emptyInput : int list = []

let wrapLeft = Rotation.apply
let wrapRight = Rotation.undo //unapply ?
wrapLeft 0 emptyInput = wrapLeft -3 emptyInput
wrapLeft System.Int32.MinValue emptyInput = wrapLeft System.Int32.MaxValue emptyInput
wrapLeft 0 [1..5] = [1..5]

wrapRight 5 (wrapLeft 5 testCharList) = testCharList

wrapLeft 1  (charList "xooo") = (charList "ooox")
wrapRight 1 (charList "xooo") = (charList "oxoo")
let ``Negative is same as wrap positive the other way``=
    wrapLeft -1 testCharList = wrapRight 1 testCharList



