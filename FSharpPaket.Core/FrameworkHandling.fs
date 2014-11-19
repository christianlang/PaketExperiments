﻿module FrameworkHandling

[<RequireQualifiedAccess>]
type NetVersion = 
    | V1
    | V1_1
    | V2
    | V3
    | V3_5
    | V4_Client
    | V4
    | V4_5
    | V4_5_1
    | V4_5_2
    | V4_5_3
    override this.ToString() = 
        match this with
        | V1 -> "v1.0"
        | V1_1 -> "v1.1"
        | V2 -> "v2.0"
        | V3 -> "v3.0"
        | V3_5 -> "v3.5"
        | V4_Client -> "v4.0"
        | V4 -> "v4.0"
        | V4_5 -> "v4.5"
        | V4_5_1 -> "v4.5.1"
        | V4_5_2 -> "v4.5.2"
        | V4_5_3 -> "v4.5.3"

type Platform =
    | Net of NetVersion
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

// shorthand notations
let Net40 = Net NetVersion.V4
let Net45 = Net NetVersion.V4_5
let Net451 = Net NetVersion.V4_5_1

type TargetProfile =
    | SinglePlatform of Platform
    | PortableProfile of string * Platform list

    static member KnownTargetProfiles =
        [SinglePlatform(Net NetVersion.V1)
         SinglePlatform(Net NetVersion.V1_1)
         SinglePlatform(Net NetVersion.V2)
         SinglePlatform(Net NetVersion.V3)
         SinglePlatform(Net NetVersion.V3_5)
         SinglePlatform(Net NetVersion.V4_Client)
         SinglePlatform(Net NetVersion.V4)
         SinglePlatform(Net NetVersion.V4_5)
         SinglePlatform(Net NetVersion.V4_5_1)
         SinglePlatform(Net NetVersion.V4_5_2)
         SinglePlatform(Net NetVersion.V4_5_3)
         SinglePlatform(MonoAndroid)
         SinglePlatform(MonoTouch)
         SinglePlatform(Silverlight3)
         SinglePlatform(Silverlight4)
         SinglePlatform(Silverlight5)
         SinglePlatform(Windows8)
         SinglePlatform(Windows81)
         SinglePlatform(WindowsPhoneSilverlight7)
         SinglePlatform(WindowsPhoneSilverlight71)
         SinglePlatform(WindowsPhoneSilverlight8)
         SinglePlatform(WindowsPhoneSilverlight81)
         SinglePlatform(WindowsPhone81)
         PortableProfile("Profile2", [ Net NetVersion.V4; Silverlight4; Windows8; WindowsPhoneSilverlight7 ])
         PortableProfile("Profile3", [ Net NetVersion.V4; Silverlight4 ])
         PortableProfile("Profile4", [ Net NetVersion.V4_5; Silverlight4; Windows8; WindowsPhoneSilverlight7 ])
         PortableProfile("Profile5", [ Net NetVersion.V4; Windows8; MonoAndroid; MonoTouch ])
         PortableProfile("Profile5", [ Net NetVersion.V4; Windows8 ])
         PortableProfile("Profile6", [ Net NetVersion.V4; Windows8 ])
         PortableProfile("Profile7" , [ Net NetVersion.V4_5; Windows8 ])
         PortableProfile("Profile14", [ Net NetVersion.V4; Silverlight5 ])
         PortableProfile("Profile18", [ Net NetVersion.V4; Silverlight4 ])
         PortableProfile("Profile19", [ Net NetVersion.V4; Silverlight5 ])
         PortableProfile("Profile23", [ Net NetVersion.V4_5; Silverlight4 ])
         PortableProfile("Profile24", [ Net NetVersion.V4_5; Silverlight5 ])
         PortableProfile("Profile31", [ Windows81; WindowsPhoneSilverlight81 ])
         PortableProfile("Profile32", [ Windows81; WindowsPhone81 ])
         PortableProfile("Profile36", [ Net NetVersion.V4; Silverlight4; Windows8; WindowsPhoneSilverlight8 ])
         PortableProfile("Profile37", [ Net NetVersion.V4; Silverlight5; Windows8 ])
         PortableProfile("Profile41", [ Net NetVersion.V4; Silverlight4; Windows8 ])
         PortableProfile("Profile42", [ Net NetVersion.V4; Silverlight5; Windows8 ])
         PortableProfile("Profile44", [ Net NetVersion.V4_5_1; Windows81 ])
         PortableProfile("Profile46", [ Net NetVersion.V4_5; Silverlight4; Windows8 ])
         PortableProfile("Profile47", [ Net NetVersion.V4_5; Silverlight5; Windows8 ])
         PortableProfile("Profile49", [ Net NetVersion.V4_5; WindowsPhoneSilverlight8 ])
         PortableProfile("Profile78", [ Net NetVersion.V4_5; Windows8; WindowsPhoneSilverlight8 ])
         PortableProfile("Profile84", [ WindowsPhone81; WindowsPhoneSilverlight81 ])
         PortableProfile("Profile88", [ Net NetVersion.V4; Silverlight4; Windows8; WindowsPhoneSilverlight71 ])
         PortableProfile("Profile92", [ Net NetVersion.V4; Windows8; WindowsPhone81 ])
         PortableProfile("Profile95", [ Net NetVersion.V4; Silverlight4; Windows8; WindowsPhoneSilverlight7 ])
         PortableProfile("Profile96", [ Net NetVersion.V4; Silverlight4; Windows8; WindowsPhoneSilverlight71 ])
         PortableProfile("Profile102", [ Net NetVersion.V4; Windows8; WindowsPhone81 ])
         PortableProfile("Profile104", [ Net NetVersion.V4_5; Silverlight4; Windows8; WindowsPhoneSilverlight71 ])
         PortableProfile("Profile111", [ Net NetVersion.V4_5; Windows8; WindowsPhone81 ])
         PortableProfile("Profile136", [ Net NetVersion.V4; Silverlight5; WindowsPhoneSilverlight8; Windows8; WindowsPhone81 ])
         PortableProfile("Profile143", [ Net NetVersion.V4; Silverlight4; Windows8; WindowsPhoneSilverlight8 ])
         PortableProfile("Profile147", [ Net NetVersion.V4; Silverlight5; Windows8; WindowsPhoneSilverlight8 ])
         PortableProfile("Profile151", [ Net NetVersion.V4_5_1; Windows81; WindowsPhone81 ])
         PortableProfile("Profile154", [ Net NetVersion.V4_5; Silverlight4; Windows8; WindowsPhoneSilverlight8 ])
         PortableProfile("Profile157", [ Windows81; WindowsPhone81; WindowsPhoneSilverlight81 ])
         PortableProfile("Profile158", [ Net NetVersion.V4_5; Silverlight5; Windows8; WindowsPhoneSilverlight8 ])
         PortableProfile("Profile225", [ Net  NetVersion.V4; Silverlight5; Windows8; WindowsPhone81 ])                  
         PortableProfile("Profile240", [ Net NetVersion.V4; Silverlight5; Windows8; WindowsPhone81 ])
         PortableProfile("Profile255", [ Net NetVersion.V4_5; Silverlight5; Windows8; WindowsPhone81 ])
         PortableProfile("Profile259", [ Net NetVersion.V4_5; Windows8; WindowsPhoneSilverlight8; WindowsPhone81 ])
         PortableProfile("Profile328", [ Net NetVersion.V4; Silverlight5; WindowsPhoneSilverlight8; Windows8; WindowsPhone81 ])
         PortableProfile("Profile336", [ Net NetVersion.V4; Silverlight5; Windows8; WindowsPhone81; WindowsPhoneSilverlight8 ])
         PortableProfile("Profile344", [ Net NetVersion.V4_5; Silverlight5; Windows8; WindowsPhone81; WindowsPhoneSilverlight8 ])]

    static member findPortableProfile name =
        TargetProfile.KnownTargetProfiles
        |> List.pick (fun target -> match target with
                                    | PortableProfile(n, _) as p -> if n = name then Some(p) else None
                                    | _ -> None)

let extractPlatform = function
    | "net10" | "net1" | "1.0" -> Some (Net NetVersion.V1)
    | "net11" | "1.1" -> Some (Net NetVersion.V1_1)
    | "net20" | "net2" | "net20-full" | "2.0" -> Some (Net NetVersion.V2)
    | "net35" | "net35-full" -> Some (Net NetVersion.V3_5)
    | "net40" | "net4" | "net40-full" | "net403" -> Some (Net NetVersion.V4)
    | "net45" | "net451" -> Some (Net NetVersion.V4_5)
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
    | Net NetVersion.V1 -> [ ]
    | Net NetVersion.V1_1 -> [ Net NetVersion.V1 ]
    | Net NetVersion.V2 -> [ Net NetVersion.V1_1 ]
    | Net NetVersion.V3 -> [ Net NetVersion.V2 ]
    | Net NetVersion.V3_5 -> [ Net NetVersion.V3 ]
    | Net NetVersion.V4_Client -> [ ]
    | Net NetVersion.V4 -> [ Net NetVersion.V3_5; Net NetVersion.V4_Client ]
    | Net NetVersion.V4_5 -> [ Net NetVersion.V4 ]
    | Net NetVersion.V4_5_1 -> [ Net NetVersion.V4_5 ]
    | Net NetVersion.V4_5_2 -> [ Net NetVersion.V4_5_1 ]
    | Net NetVersion.V4_5_3 -> [ Net NetVersion.V4_5_2 ]
    | MonoAndroid -> [ Net NetVersion.V4_5_3 ]
    | MonoTouch -> [ Net NetVersion.V4_5_3 ]
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
    
let getCondition (target:TargetProfile) = function
    | SinglePlatform(platform) -> match platform with
                                  | Net(version) -> System.String.Format("$(TargetFrameworkIdentifier) == '.NETFramework' And $(TargetFrameworkVersion) == '{0}'", version)

    | PortableProfile(name, _) -> System.String.Format("$(TargetFrameworkProfile) == '{0}'", name)

let rec getPlatformPenalty (targetPlatform:Platform) (packagePlatform:Platform) =
    if packagePlatform = targetPlatform then
        0
    else
        let penalties = supportedPlatforms targetPlatform
                        |> List.map (getPlatformPenalty packagePlatform)
        List.min (1000::penalties) + 1

let getPathPenalty (path:string) (platform:Platform) =
    extractPlatforms path
    |> List.map (getPlatformPenalty platform)
    |> List.min

// Checks wether a list of target platforms is supported by this path and with which penalty. 
let getPenalty (requiredPlatforms:Platform list) (path:string) =
    requiredPlatforms
    |> List.map (getPathPenalty path)
    |> List.sum

let findBestMatch (paths:string list) (targetProfile:TargetProfile) =
    let requiredPlatforms = match targetProfile with
                            | PortableProfile(_, platforms) -> platforms
                            | SinglePlatform(platform) -> [platform]

    let pathPenalties = paths
                        |> List.map (fun path -> (path, getPenalty requiredPlatforms path))

    let minPenalty = pathPenalties
                     |> List.map (fun (path, penalty) -> penalty)
                     |> List.min

    pathPenalties
    |> List.filter (fun (path, penalty) -> penalty = minPenalty && minPenalty < 1000)
    |> List.map (fun (path, penalty) -> path)
    |> List.sortBy (fun path -> (extractPlatforms path).Length)
    |> List.tryFind (fun _ -> true)

// For a given list of paths and target profiles return tuples of paths with their supported target profiles.
// Every target profile will only be listed for own path - the one that best supports it. 
let getSupportedTargetProfiles (paths:string list) =
    TargetProfile.KnownTargetProfiles
    |> List.map (fun target -> ((findBestMatch paths target), target))
    |> List.collect (fun (path, target) -> match path with
                                           | Some(p) -> [(p, target)]
                                           | _ -> [])
    |> Seq.groupBy (fun (path, target) -> path)
    |> Seq.map (fun (path, group) -> (path, Seq.map (fun (_, target) -> target) group))
