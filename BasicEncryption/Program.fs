// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open FileIO

let usage customMessage =
    printfn "%s" customMessage
    printfn "---------------------------------------------"
    printfn "To encrypt: BasicEncryption.exe innerKey outerKey -e fileName"
    printfn "To decrypt: BasicEncryption.exe innerKey outerKey -d fileName"
    printfn "---------------------------------------------"
    printfn "innerKey: An 32 bit integer number"
    printfn "innerKey: An 32 bit integer number"
    printfn "fileName: Path of file to read"
    printfn "---------------------------------------------"    
    printfn "Add > to the end if you want to output to a file, for example:"
    printfn "BasicEncryption.exe -d test.txt > temp.txt"

let encrypt innerKey outerKey text =    
    let rec jumble n text =
        let transposed = TextOperations.transpose innerKey text
        match n with
        | 0 -> transposed
        | n -> jumble (n - 1) transposed
    let cypher = jumble outerKey text
    printf "%s" cypher

let decrypt innerKey outerKey text =
    let rec jumble i n text =
        let transposed = TextOperations.undoTranspose innerKey text
        if i = n then
          transposed
        else jumble (i + 1) n transposed
    let cypher = jumble 0 outerKey text
    printf "%s" cypher

let transform operation i o filePath =
    match tryReadAllText filePath with
    | Ok(text) -> 
        if i > text.Length || o > text.Length
        then printfn "Error: Keys cannot be longer than text length %i" text.Length
        else (operation i o) text
    | FileNotFound msg -> printfn "Couldn't find file: %s" msg
    | UnexpectedError e -> printfn "Unexpected error reading text: %s" (e.ToString())

let parseInt = System.Int32.TryParse >> (fun (success,value) -> if success then Some(value) else None)

let (|ProgramArgs|_|) (input : string list) =
    match input with
    [operation; inner; outer; file] ->
        match (operation, parseInt(inner), parseInt(outer), file) with
        | op, Some(i), Some(o), file ->
          let operation = match op with
                          | "-e" -> encrypt
                          | "-d" -> decrypt     
                          | _ -> (fun _ _ _ -> usage "Invalid operation. Specify -e or -d")
          Some(operation,i,o,file)
        | op, _, _, file -> Some((fun _ _ _-> usage "inner and outer key must both be 32bit numbers"),0,0, file)
    | _ -> None

[<EntryPoint>]
let main argv =
    let input = argv |> List.ofArray
    match input with
    | ProgramArgs(operation,i ,o ,file) -> transform operation i o file
    | [] -> usage "No arguments supplied."
    | _ ->  usage "Unkown or missing arguments."        
    0 // exit code
          