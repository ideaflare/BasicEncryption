module Transposition

let private transposeChars size (body : char list) =
    [0..(size - 1)]
    |> List.map (fun colStart   -> [colStart .. size .. (body.Length - 1)])
    |> List.map (fun colIndexes -> colIndexes |> List.map (fun i -> body.[i]))
    |> List.collect id

let transpose size (body : string) =
    charList body
    |> transposeChars size
    |> stringFromCharList