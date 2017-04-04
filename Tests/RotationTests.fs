namespace Tests

open Microsoft.VisualStudio.TestTools.UnitTesting
open Rotation
open Domain

[<TestClass>]
type RotationTests() =

    [<TestMethod>]
    member me.LeftRotation() =
        let plain =    "xxooo" |> charList
        let expected = "oooxx" |> charList

        let rotated = apply -2 plain
        
        Assert.AreEqual(expected, rotated)
