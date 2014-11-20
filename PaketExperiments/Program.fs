open FrameworkHandling

let print result =
    for (key, value) in Map.toList result do
        printfn "\npath: %A" key
        for target in value do
            printfn "   %A" target

let printConditions result =
    for (key, value) in Map.toList result do
        printfn "\nCondition for path: %A" key
        value |> List.ofSeq |> getPathCondition |> printfn "%A"

[<EntryPoint>]
let main argv =
    // given a list of paths and a target, find the path that supports this target best
    let profile = TargetProfile.findPortableProfile "Profile92"
    findBestMatch [ "net4+win8+wpa81"; "net4" ] profile
    |> printfn "%A matches best for the given profile"
    
    // get all targets supported by a given path
    getSupportedTargetProfiles [ "net4+win8+wpa81" ] |> print
    printf "\n\n"

    // note how adding more paths also affects the previous path "net4+win8+wpa81"
    // because now there are paths that better match some targets (like .NET 4.5)
    getSupportedTargetProfiles [ "net4+win8+wpa81"; "net45"; "net45+win81+wpa81" ] |> print

    // now we can determine conditions to use in the Choose/When in project files
    getSupportedTargetProfiles [ "net4+win8+wpa81"; "net45"; "net45+win81+wpa81" ] |> printConditions

    0 // return an integer exit code