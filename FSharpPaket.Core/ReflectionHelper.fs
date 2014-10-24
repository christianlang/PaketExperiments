module ReflectionHelper

open System
open System.IO
open System.Reflection
open System.Runtime.Versioning

let findDlls =
    let dir = new DirectoryInfo("C:\Workspace\6Wunderkinder\wunderlist-windows\packages")
    dir.GetFiles("*.dll", SearchOption.AllDirectories)

let extractTargetFramework path =
    try
        let assembly = Assembly.ReflectionOnlyLoadFrom(path)
//        if assembly.IsDefined(typedefof<TargetFrameworkAttribute>) then
//            let attribute = assembly.GetCustomAttribute(typedefof<TargetFrameworkAttribute>) :?> TargetFrameworkAttribute
//            attribute.FrameworkName
//        else
//            ""
        let attribute = assembly.GetCustomAttributesData() |> 
                        Seq.tryFind (fun d -> d.AttributeType.Equals(typedefof<TargetFrameworkAttribute>))
        match attribute with
            | Some(d) -> d.ConstructorArguments.[0].Value :?> String
            | _ -> ""
    with
    | :? BadImageFormatException -> ""

let test = 
    let result = findDlls |> Array.map (fun info -> info.FullName) |> Array.map extractTargetFramework
    printfn "%A\n" (String.Join(",", result))
    0 // return an integer exit code


