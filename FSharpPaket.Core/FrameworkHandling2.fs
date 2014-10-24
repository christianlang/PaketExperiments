module FrameworkHandling2

type Platform = {
    Aliases : string[];
    Supports : Platform[] }

type Profile = {
    Platforms : Platform[];
    Condition : string }

let Net10 = { Aliases = [| "net10"; "net1"; "1.0" |]; Supports = [||] }
let Net11 = { Aliases = [| "net11"; "1.1" |]; Supports = [| Net10 |] }
let Net20 = { Aliases = [| "net20"; "net2"; "net20-full"; "2.0" |]; Supports = [| Net11 |] }
let Net35 = { Aliases = [| "net35"; "net35-full" |]; Supports = [| Net20 |] }
let Net40Client = { Aliases = [| "net40-client" |]; Supports = [| |] }
let Net40 = { Aliases = [| "net40"; "net4"; "net40-full" |]; Supports = [| Net35; Net40Client |] }
let Net45 = { Aliases = [| "net45"; "net451" |]; Supports = [| Net40 |] }
let Net451 = { Aliases = [| "net451" |]; Supports = [| Net45 |] }
let Net452 = { Aliases = [| "net452" |]; Supports = [| Net451 |] }
let Net453 = { Aliases = [| "net453" |]; Supports = [| Net452 |] }

let MonoAndroid = { Aliases = [| "monoandroid" |]; Supports = [| Net452 |] }
let MonoTouch = { Aliases = [| "monotouch" |]; Supports = [| Net452 |]}

let Silverlight3 = { Aliases = [| "sl30"; "sl3" |]; Supports = [||] }
let Silverlight4 = { Aliases = [| "sl40"; "sl4" |]; Supports = [||] }
let Silverlight5 = { Aliases = [| "sl50"; "sl5" |]; Supports = [||] }

let platforms = [| Net10; Net11; Net20; Net35; Net40Client; Net40; Net45; Net451; Net452; Net453;
                   Silverlight3; Silverlight4; Silverlight5;
                   MonoAndroid; MonoTouch |]

let profiles = [|
    { Platforms = [| Net45; MonoAndroid; MonoTouch |]; Condition = "$(TargetFrameworkProfile) == 'Profile259'" }
    { Platforms = [| Net40; Silverlight3 |]; Condition = "$(TargetFrameworkProfile) == 'Profile3'" }
    |]

//let supportsPlatform(platform: platform:Platform) =
    
let supportsPlatform (platform:Platform) profile =
    Array.exists (fun p -> p = platform) profile.Platforms

let GetPlatform(path:string) =
    Array.tryFind (fun p -> Array.exists (fun a -> a.Equals(path)) p.Aliases) platforms

let GetSupportedProfiles(path:string) =
    match GetPlatform(path) with
    | Some(platform) -> Array.filter (supportsPlatform platform) profiles
    | _ -> [||]
