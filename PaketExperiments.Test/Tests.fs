namespace Tests

open NUnit.Framework
open FsUnit
open FrameworkHandling

module ``Given a target platform`` =
    
    [<Test>]
    let ``it should return no penalty for the same platform``() =
        getPlatformPenalty (Net NetVersion.V4_5) (Net NetVersion.V4_5)
        |> should equal 0

    [<Test>]
    let ``it should return the right penalty for a compatible platform``() =
        getPlatformPenalty (Net NetVersion.V4_5) (Net NetVersion.V4)
        |> should equal 1

    [<Test>]
    let ``it should return > 1000 for an incompatible platform``() =
        getPlatformPenalty (Net NetVersion.V4_5) (Silverlight "v5.0")
        |> should greaterThan 1000

module ``Given a path`` =

    [<Test>]
    let ``it should split it into the right platforms``() =
        extractPlatforms "net40+win8" |> should equal [ Net NetVersion.V4; Windows "v8.0" ]

    [<Test>]
    let ``it should ignore 'portable-'``() =
        extractPlatforms "portable-net40+win8" |> should equal [ Net NetVersion.V4; Windows "v8.0" ]
        
    [<Test>]
    let ``it should return no penalty for a matching .NET framework``() =
        getPenalty [ Net NetVersion.V4_5 ] "net45"
        |> should equal 0
    
    [<Test>]
    let ``it should return no penalty for a matching portable profile``() =
        getPenalty [ Net NetVersion.V4; Silverlight "v4.0" ] "net40+sl4"
        |> should equal 0
    
    [<Test>]
    let ``it should return 1 for a compatible portable profile``() =
        getPenalty [ Net NetVersion.V4; Silverlight "v5.0" ] "net40+sl4"
        |> should equal 1


module ``Given a list of paths`` =

    let paths = [ "net40"
                  "net45"
                  "portable-monotouch+monoandroid"
                  "portable-net40+sl5+win8+wp8+wpa81"
                  "portable-net45+winrt45+wp8+wpa81"
                  "portable-win81+wpa81"
                  "portable-windows8+net45+wp8"
                  "sl5"
                  "win8"
                  "wp8" ]

    [<Test>]
    let ``it should find the best match for .NET 4.0``() =
        findBestMatch paths (SinglePlatform (Net NetVersion.V4)) |> should equal (Some "net40")

    [<Test>]
    let ``it should find the best match for Silverlight 5``() =
        findBestMatch paths (SinglePlatform (Silverlight "v5.0")) |> should equal (Some "sl5")

    [<Test>]
    let ``it should find no match for Silverlight 4``() =
        findBestMatch paths (SinglePlatform (Silverlight "v4.0")) |> should equal None
    
    module ``when I get the supported target profiles`` =

        let supportedTargetProfiles = getSupportedTargetProfiles paths

        [<Test>]
        let ``it should contain profile 32``() =
            supportedTargetProfiles.["portable-win81+wpa81"]
            |> should contain (TargetProfile.findPortableProfile "Profile32")
        
        [<Test>]
        let ``it should not contain profile 41``() =
            let flattend = seq { for item in supportedTargetProfiles do yield! item.Value }
            flattend
            |> should not' (contain (TargetProfile.findPortableProfile "Profile41"))