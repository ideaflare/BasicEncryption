module KeyMap

let initialKeyMap =
    charList """\n\t `-=~!@#$%^&*()_+[]{}|\;':",./<>?"""
    @ ['0' .. '9']
    @ ['a' .. 'z']
    @ ['A' .. 'Z']

let buildKeyMap (input : char list) =
    let rnd = System.Random()
    initialKeyMap @ input
    |> List.distinct
    |> List.sortBy ( fun _ -> rnd.Next())

let toNumberList password keymap =
    let keymapIndex letter = keymap |> List.findIndex ((=) letter)
    password
    |> List.map keymapIndex