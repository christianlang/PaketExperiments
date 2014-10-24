module FrameworkHandlingTests

open NUnit.Framework
open FsUnit

module ``Given a path`` =

    [<Test>]
    let ``it should split it into the right platforms``() =
        FrameworkHandling3.extractPlatforms "net40+win8" |> should equal [ FrameworkHandling3.Net40; FrameworkHandling3.Windows8 ]

    [<Test>]
    let ``it should ignore 'portable-'``() =
        FrameworkHandling3.extractPlatforms "portable-net40+win8" |> should equal [ FrameworkHandling3.Net40; FrameworkHandling3.Windows8 ]

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
        FrameworkHandling3.findBestMatch paths FrameworkHandling3.Net40 |> should equal (Some "net40")

    [<Test>]
    let ``it should find the best match for Silverlight 5``() =
        FrameworkHandling3.findBestMatch paths FrameworkHandling3.Silverlight5 |> should equal (Some "sl5")

    [<Test>]
    let ``it should find no match for Silverlight 4``() =
        FrameworkHandling3.findBestMatch paths FrameworkHandling3.Silverlight5 |> should equal None
