type File = System.IO.File
let filePath = """C:\MyTemp\findme.txt"""
let text = File.ReadAllText(filePath)

printfn "size: %i content: %A" text.Length text

let todo = List.chunkBySize 3 (text.ToCharArray() |> List.ofArray)

let (?>) f x =
    match f with
    | true -> Some(x)
    | _ -> None
    
let transposeRow columns (body:string) col =
    body.ToCharArray()
    |> Seq.mapi (fun i x -> i,x)
    |> Seq.choose (fun (i,x) -> i % columns = col ?> x)
    |> Array.ofSeq |> (fun arr -> System.String(arr))

let rowTransposition columns text =
    let getColumn = transposeRow columns text
    [0..(columns - 1)]
    |> List.map getColumn
    |> List.reduce (+)
    

"Myaaillba d tearh lt m" = rowTransposition 3 text
