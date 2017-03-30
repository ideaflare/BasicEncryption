module Transposition

let transpose size (body : string) =
    [0..(size - 1)]
    |> List.map (fun colStart   -> [colStart .. size .. (body.Length - 1)])
    |> List.map (fun colIndexes -> colIndexes |> List.map (fun i -> body.[i]))
    |> List.map charListToString
    |> List.reduce (+)