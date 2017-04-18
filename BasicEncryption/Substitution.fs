module Substitution
    
let substituteList keyMap (replaceMap : char list) items =
    let substitute c =
        keyMap
        |> List.findIndex (fun k -> k = c)
        |> (fun i -> replaceMap.[i])
    List.map substitute items

let initialKeyMap =
    charList """\n\t `-=~!@#$%^&*()_+[]{}|\;':",./<>?"""
    @ ['0' .. '9']
    @ ['a' .. 'z']
    @ ['A' .. 'Z']

let buildKeyMap (input : char list) =
    let rnd = System.Random()
    initialKeyMap @ input
    |> List.distinct
    |> List.sortBy ( fun _ -> rnd.Next())
   

