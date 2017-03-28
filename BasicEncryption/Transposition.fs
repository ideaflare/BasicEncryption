module Transposition

let private columnString columns body col =
    charList body
    |> Seq.mapi (fun i x -> if i % columns = col then Some(x) else None)
    |> Seq.choose id
    |> Array.ofSeq |> (fun arr -> System.String(arr))

let columnTransposition columns body =
    let getColumn = columnString columns body
    [0..(columns - 1)]
    |> List.map getColumn
    |> List.reduce (+)