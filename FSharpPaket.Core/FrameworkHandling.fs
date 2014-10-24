module FrameworkHandling

type Platform =
    | MonoAndroid
    | MonoTouch
    | Net1
    | Net1_1
    | Net2
    | Net3
    | Net3_5
    | Net4_Client
    | Net4
    | Net4_5
    | Net4_5_1
    | Net4_5_2
    | Net4_5_3
    | Silverlight3
    | Silverlight4
    | Silverlight5
    | WindowsPhone7
    | WindowsPhone7_1
    | WindowsPhone8
    | WindowsPhoneSilverlight81
    | WindowsPhone81
    | Windows8
    | Windows81

let GetPlatform(name:string) =
    match name.ToLower() with
    | "net" -> Some(Platform.Net1) // not sure here
    | "1.0" -> Some(Platform.Net1)
    | "1.1" -> Some(Platform.Net1_1)
    | "2.0" -> Some(Platform.Net2)
    | "net11" -> Some(Platform.Net1_1)
    | "net20" -> Some(Platform.Net2)
    | "net20-full" -> Some(Platform.Net2)
    | "net35" -> Some(Platform.Net3_5)
    | "net35-full" -> Some(Platform.Net3_5)
    | "net4" -> Some(Platform.Net4)
    | "net40" -> Some(Platform.Net4)
    | "net40-full" -> Some(Platform.Net4)
    | "net40-client" -> Some(Platform.Net4_Client)
    | "net45" -> Some(Platform.Net4_5)
    | "net45-full" -> Some(Platform.Net4_5)
    | "net451" -> Some(Platform.Net4_5_1)
    | "35" -> Some(Platform.Net3_5)
    | "40" -> Some(Platform.Net4)
    | "45" -> Some(Platform.Net4_5)
    | "sl3" -> Some(Platform.Silverlight3)
    | "sl4" -> Some(Platform.Silverlight4)
    | "sl5" -> Some(Platform.Silverlight5)
    | "sl50" -> Some(Platform.Silverlight5)
    | "sl4-wp" -> Some(Platform.WindowsPhone7)
    | "sl4-wp71" -> Some(Platform.WindowsPhone7_1)
    | "sl4-windowsphone71" -> Some(Platform.WindowsPhone7_1)
    | "win8" -> Some(Platform.Windows8)
    | "wp8" -> Some(Platform.WindowsPhone8)
    | "wp81" -> Some(Platform.WindowsPhone8)
    | "wpa81" -> Some(Platform.WindowsPhone81)
    | "monoandroid" -> Some(Platform.MonoAndroid)
    | "monotouch" -> Some(Platform.MonoTouch)
    | _ -> None

type TargetPlatformMoniker = string

type Profile = TargetPlatformMoniker * Platform[]

//let Profile259 = ".NETPortable,Version=v4.5,Profile=Profile259" [Platform.Windows81, Platform.Net4_5] of Profile

type Profiles =
    | Profile2  of Profile

let GetSupportedTargetFrameworks(path:string) =
    path.Split('+')
    |> Array.map GetPlatform
    
