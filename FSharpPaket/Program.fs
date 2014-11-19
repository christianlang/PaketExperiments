
[<EntryPoint>]
let main argv = 
    printfn "%A" argv
//    let net40 = FrameworkHandling.GetSupportedTargetFrameworks "net40"
//    let portable = FrameworkHandling.GetSupportedTargetFrameworks "portable-net40+sl5+win8+wp8+wpa81"

    let paths = [ "net4+win8+wpa81" ]

    let profile = FrameworkHandling.TargetProfile.findProfile "Profile92"
    let m = FrameworkHandling.findBestMatch paths profile
    0 // return an integer exit code
