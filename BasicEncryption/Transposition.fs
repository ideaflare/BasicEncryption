module Transposition

let apply columns items =    
    if columns < 2 then items else
    [0 .. columns - 1]
    |> List.collect (fun colStart -> [colStart .. columns .. List.length items - 1])
    |> List.map (fun i -> items.[i])
    
let undo columns (items : 'a list) =    
    if columns < 2 then items else
    [0 .. columns - 1]
    |> List.collect (fun colStart -> [colStart .. columns .. List.length items - 1])
    |> List.mapi (fun i x -> (i,x))
    |> List.sortBy (fun (position, order) -> order)
    |> List.map (fun (i, _) -> items.[i])