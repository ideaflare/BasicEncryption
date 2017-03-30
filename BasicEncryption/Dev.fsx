#load "Domain.fs"
#load "Transposition.fs"
open Domain
open Transposition

type File = System.IO.File
let filePath = """C:\MyTemp\findme.txt"""
let stringText = File.ReadAllText(filePath)

printfn "size: %i content: %A" stringText.Length stringText


"Myaaillba d tearh lt m" = transpose 3 stringText


(* Now to reverse the transposition without the padding, first stab: *)


//let todo2 = (listText text) |> List.groupBy

let cypher = stringToCharList "Myaaillba d tea?rh lt m"

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
     if (col = rowLength && row >= spills) then
        (-1,-1)
     else (col,row)))
     
[0 .. rowLength]
|> List.collect (fun col ->     
     [0 .. (rows - 1)]
     |> List.map (fun row ->
     if (col = rowLength && row >= spills)
     then None
     else Some(allRows.[row].[col]) ))
|> List.choose id
|> List.map (fun c -> string c)
|> List.reduce (+)







