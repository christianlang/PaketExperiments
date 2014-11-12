namespace Tests

open NUnit.Framework
open FsUnit
open FrameworkHandling

module ``Given a target platform`` =
    
    [<Test>]
    let ``it should return no penalty for the same platform``() =
        getPlatformPenalty Net45 Net45
        |> should equal 0

    [<Test>]
    let ``it should return the right penalty for a compatible platform``() =
        getPlatformPenalty Net45 Net40
        |> should equal 1

    [<Test>]
    let ``it should return 1000 for an incompatible platform``() =
        getPlatformPenalty Net45 Silverlight5
        |> should equal 1000

module ``Given a path`` =

    [<Test>]
    let ``it should split it into the right platforms``() =
        extractPlatforms "net40+win8" |> should equal [ Net40; Windows8 ]

    [<Test>]
    let ``it should ignore 'portable-'``() =
        extractPlatforms "portable-net40+win8" |> should equal [ Net40; Windows8 ]
        
    [<Test>]
    let ``it should return no penalty for a matching .NET framework``() =
        getPenalty [ Net45 ] "net45"
        |> should equal 0
    
    [<Test>]
    let ``it should return no penalty for a matching portable profile``() =
        getPenalty [ Net40; Silverlight4 ] "net40+sl4"
        |> should equal 0
    
    [<Test>]
    let ``it should return 1 for a compatible portable profile``() =
        getPenalty [ Net40; Silverlight5 ] "net40+sl4"
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
        findBestMatch paths (SinglePlatform Net40) |> should equal (Some "net40")

    [<Test>]
    let ``it should find the best match for Silverlight 5``() =
        findBestMatch paths (SinglePlatform Silverlight5) |> should equal (Some "sl5")

    [<Test>]
    let ``it should find no match for Silverlight 4``() =
        findBestMatch paths (SinglePlatform Silverlight4) |> should equal None
