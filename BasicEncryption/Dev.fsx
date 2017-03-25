type File = System.IO.File
let filePath = """C:\MyTemp\findme.txt"""
let text = File.ReadAllText(filePath)

let listText (txt:string) = txt.ToCharArray() |> List.ofArray

printfn "size: %i content: %A" text.Length text

let todo = List.chunkBySize 3 (listText text)
//let todo2 = (listText text) |> List.groupBy

let transposeRow columns (body:string) col =
    body.ToCharArray()
    |> Seq.mapi (fun i x -> if i % columns = col then Some(x) else None)
    |> Seq.choose id
    |> Array.ofSeq |> (fun arr -> System.String(arr))

let rowTransposition columns text =
    let getColumn = transposeRow columns text
    [0..(columns - 1)]
    |> List.map getColumn
    |> List.reduce (+)
    
let transposed = rowTransposition 3 text

"Myaaillba d tearh lt m" = transposed

(* Now to reverse the transposition without the padding, first stab: *)

let cypher = listText "Myaaillba d tea?rh lt m"

let rows = 3
let spills = cypher.Length % rows
let rowLength = cypher.Length / rows

let rec getSpills i acc text spillLength =
    let rec addSpills i acc text spillLength =
        match i with
        | 0 -> acc
        | n ->
            let nextSpill = text |> List.take spillLength
            let nextText = text |> List.skip spillLength
            addSpills (n - 1) (nextSpill :: acc) nextText spillLength
    addSpills i acc text spillLength
    |> List.rev

let spillRows = getSpills spills [] cypher (rowLength + 1)

let rest = cypher |> List.skip (spills * (rowLength + 1))

let normalRows = rest |> List.chunkBySize rowLength

let allRows = spillRows @ normalRows

[0 .. rowLength]
|> List.collect (fun col ->     
     [0 .. (rows - 1)]
     |> List.map (fun row ->
     if (col = rowLength && col >= spills) then
        (-1,-1)
     else (col,row)))
     
[0 .. rowLength]
|> List.collect (fun col ->     
     [0 .. (rows - 1)]
     |> List.map (fun row ->
     if (col = rowLength && col >= spills)
     then None
     else Some(allRows.[row].[col]) ))
|> List.choose id
|> List.map (fun c -> string c)
|> List.reduce (+)







