#load "Domain.fs"
#load "Transposition.fs"
#load "Rotation.fs"
#load "Substitution.fs"
#load "TextOperations.fs"
#load "KeyMap.fs"
open Domain
open TextOperations
open Substitution
open KeyMap

// general test setup
let testPlainText = "Alice sent a message to Bob. Still need to add R, prime, substitution and noise."
let plainText = testPlainText |> charList
let passwordText = "even 1 letter password seems fine so far"
let password = passwordText |> charList

let operations reverse =
    if reverse then
        Rotation.undo, Transposition.undo
    else
        Transposition.apply, Rotation.apply

let jumble reverse secretNumbers text =
    let mixNumbers = if reverse then List.rev secretNumbers else secretNumbers
    let fA, fB = operations reverse
    let rec mix result scrambleList =
        match scrambleList with
        | [] -> result
        | x :: xs ->
            let nextMix = result |> fA x |> fB x
            mix nextMix xs
    mix text mixNumbers

let encrypt password plainText =
    let keyMap = buildKeyMap plainText
    let numberLookup = secretNumbers password keyMap
    let mix = jumble true numberLookup plainText
    keyMap @ mix

let decrypt password mixText =
    let keyMap, tail = KeyMap.splitPrependedKeyMap mixText
    let numberLookup = secretNumbers password keyMap
    jumble false numberLookup tail

let encrypted = encrypt password plainText
let decrypted = decrypt password encrypted

// tests
decrypted = plainText
let _, encryptedBody = KeyMap.splitPrependedKeyMap encrypted
encryptedBody.Length = plainText.Length
encryptedBody <> plainText

encryptedBody |> stringFromCharList
decrypted     |> stringFromCharList

