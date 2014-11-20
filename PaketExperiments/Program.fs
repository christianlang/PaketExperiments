open FrameworkHandling

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
//    let net40 = FrameworkHandling.GetSupportedTargetFrameworks "net40"
//    let portable = FrameworkHandling.GetSupportedTargetFrameworks "portable-net40+sl5+win8+wp8+wpa81"

    let paths = [ "net4+win8+wpa81"; "net4" ]

    let profile = TargetProfile.findPortableProfile "Profile92"
    let m = findBestMatch paths profile
    let result = getSupportedTargetProfiles paths
    let condition = result.["net4+win8+wpa81"] |> List.ofSeq |> getPathCondition
    0 // return an integer exit code
