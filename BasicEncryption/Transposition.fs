module Transposition

let transpose columns items =    
    if columns < 2 then items else
    [0 .. columns - 1]
    |> List.collect (fun colStart -> [colStart .. columns .. List.length items - 1])
    |> List.map (fun i -> items.[i])