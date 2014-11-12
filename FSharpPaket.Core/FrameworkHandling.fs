module FrameworkHandling

type Platform =
    | Net10
    | Net11
    | Net20
    | Net30
    | Net35
    | Net40Client
    | Net40
    | Net45
    | Net451
    | Net452
    | Net453
    | MonoAndroid
    | MonoTouch
    | Silverlight3
    | Silverlight4
    | Silverlight5
    | Windows8
    | Windows81
    | WindowsPhoneSilverlight7
    | WindowsPhoneSilverlight71
    | WindowsPhoneSilverlight8
    | WindowsPhoneSilverlight81
    | WindowsPhone81

//type PortableProfile = Platform[]

type TargetProfile =
    | Platform of Platform
    | PortableProfile of string * Platform list

    static member KnownProfiles =
        [PortableProfile("Profile2", [ Net40; Silverlight4; Windows8; WindowsPhoneSilverlight7 ])
         PortableProfile("Profile3", [ Net40; Silverlight4 ])
         PortableProfile("Profile4", [ Net45; Silverlight4; Windows8; WindowsPhoneSilverlight7 ])
         PortableProfile("Profile5", [ Net40; Windows8; MonoAndroid; MonoTouch ])]


let extractPlatform = function
    | "net10" | "net1" | "1.0" -> Some Net10
    | "net11" | "1.1" -> Some Net11
    | "net20" | "net2" | "net20-full" | "2.0" -> Some Net20
    | "net35" | "net35-full" -> Some Net35
    | "net40" | "net4" | "net40-full" | "net403" -> Some Net40
    | "net45" | "net451" -> Some Net45
    | "monotouch" -> Some MonoTouch
    | "monoandroid" -> Some MonoAndroid
    | "sl3" | "sl30" -> Some Silverlight3
    | "sl4" | "sl40" -> Some Silverlight4
    | "sl5" | "sl50" -> Some Silverlight5
    | "win8" | "windows8" | "netcore45" | "winrt45" -> Some Windows8
    | "win81" | "windows81" | "netcore46" | "winrt46" -> Some Windows81
    | "wp7" | "windowsphone7" -> Some WindowsPhoneSilverlight7
    | "wp71" | "windowsphone71" -> Some WindowsPhoneSilverlight71
    | "wp8" | "windowsphone8" -> Some WindowsPhoneSilverlight8
    | "wpa81" -> Some WindowsPhone81
    | _ -> None

let split (path:string) =
    path.Split('+', '-') |> Array.filter (fun x -> x <> "portable") |> Array.toList

let extractPlatforms path =
    split path
    |> List.choose extractPlatform

// For a given platform return a list of compatible platforms that is also supports.
let supportedPlatforms (platform:Platform) =
    match platform with
    | Net10 -> [ ]
    | Net11 -> [ Net10 ]
    | Net20 -> [ Net11 ]
    | Net30 -> [ Net20 ]
    | Net35 -> [ Net20 ]
    | Net40Client -> [ ]
    | Net40 -> [ Net35; Net40Client ]
    | Net45 -> [ Net40 ]
    | Net451 -> [ Net45 ]
    | Net452 -> [ Net451 ]
    | Net453 -> [ Net452 ]
    | MonoAndroid -> [ Net453 ]
    | MonoTouch -> [ Net453 ]
    | Silverlight3 -> [ ]
    | Silverlight4 -> [ Silverlight3 ]
    | Silverlight5 -> [ Silverlight4 ]
    | Windows8 -> [ ]
    | Windows81 -> [ Windows8 ]
    | WindowsPhoneSilverlight7 -> [ ]
    | WindowsPhoneSilverlight71 -> [ WindowsPhoneSilverlight7 ]
    | WindowsPhoneSilverlight8 -> [ WindowsPhoneSilverlight71 ]
    | WindowsPhoneSilverlight81 -> [ WindowsPhoneSilverlight8 ]
    | WindowsPhone81 -> [ ]

let rec getPlatformPenalty (targetPlatform:Platform) (packagePlatform:Platform) =
    if packagePlatform = targetPlatform then
        0
    else
        let penalties = supportedPlatforms targetPlatform
                        |> List.map (getPlatformPenalty packagePlatform)
        List.min (999::penalties) + 1

let getPathPenalty (path:string) (platform:Platform) =
    extractPlatforms path
    |> List.map (getPlatformPenalty platform)
    |> List.min

// Checks wether a list of target platforms is supported by this path and with which penalty. 
let getPenalty (requiredPlatforms:Platform list) (path:string) =
    requiredPlatforms
    |> List.map (getPathPenalty path)
    |> List.sum

//let findBestMatch (paths:string list) (targetPlatform:Platform) =
//    paths
//    |> List.map getPenalty targetPlatform