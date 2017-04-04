module Substitution
    
let substituteList keyMap (replaceMap : char list) items =
    let substitute c =
        keyMap
        |> List.findIndex (fun k -> k = c)
        |> (fun i -> replaceMap.[i])
    items
    |> List.map substitute

let keymap =
    charList """\n\t `-=~!@#$%^&*()_+[]{}|\;':",./<>?"""
    @ ['0' .. '9']
    @ ['a' .. 'z']
    @ ['A' .. 'Z']

let replaceMap =
    keymap
    |> (Transposition.apply 3)
    |> (Rotation.apply 2)
   

