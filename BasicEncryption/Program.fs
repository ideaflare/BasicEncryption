// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open FileIO

let usage customMessage =
    printfn "%s" customMessage
    printfn "---------------------------------------------"
    printfn "To encrypt: BasicEncryption.exe -e fileName"
    printfn "To decrypt: BasicEncryption.exe -d fileName"
    printfn "---------------------------------------------"
    printfn "Add > to the end if you want to output to a file, for example:"
    printfn "BasicEncryption.exe -d test.txt > temp.txt"

let encrypt text =    
    let rec jumble n text =
        let transposed = TextOperations.transpose 3 text
        match n with
        | 0 -> transposed
        | n -> jumble (n - 1) transposed
    let cypher = jumble 7 text
    printf "%s" cypher

let decrypt text =
    let rec jumble i n text =
        let transposed = TextOperations.undoTranspose 3 text
        if i = n then
          transposed
        else jumble (i + 1) n transposed
    let cypher = jumble 0 7 text
    printf "%s" cypher

let transform operation filePath =
    match tryReadAllText filePath with
    | Ok(text) -> operation text
    | Error msg -> printfn "Error reading text: %s" msg

[<EntryPoint>]
let main argv =
    let input = argv |> List.ofArray
    match input with
    | ["-e";fileName] -> transform encrypt fileName
    | ["-d";fileName] -> transform decrypt fileName
    | [] -> usage "No arguments supplied."
    | _ ->  usage "Unkown or missing operation/file"        
    0 // exit code
          