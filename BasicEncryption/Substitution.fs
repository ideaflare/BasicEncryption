module Substitution
    
let substituteList keyMap (replaceMap : char list) items =
    let substitute c =
        keyMap
        |> List.findIndex (fun k -> k = c)
        |> (fun i -> replaceMap.[i])
    List.map substitute items