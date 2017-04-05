namespace Tests

// Old school MsTest zZzz :|

open Microsoft.VisualStudio.TestTools.UnitTesting
open TextOperations
open Rotation
open Domain

[<TestClass>]
type TranspositionTests() =

    // property based tests would have been great

    [<TestMethod>]
    member me.TranspositionHandlesStrangeInput() =
        let nullInput : string = null
        let emptyInput = ""
        let actualInput = "FsUnit.. FsCheck.. Unquote.. "

        let nullTranspose = transpose 5 nullInput
        let emptyTransPose = transpose 7 emptyInput

        let zeroTranspose = transpose 0 actualInput
        let negativeTranspose = transpose -32 actualInput

        Assert.AreEqual(System.String.Empty, nullTranspose)
        Assert.AreEqual(zeroTranspose, negativeTranspose)

    [<TestMethod>]
    member me.UndoTransposition() =
        let plaintext = "Some test string"
        let cypher = transpose 3 plaintext
        let decrypted = undoTranspose 3 cypher
        Assert.AreEqual(plaintext, decrypted)

    [<TestMethod>]
    member me.LeftRotation() =
        let plain =    "xxooo" |> charList
        let expected = "oooxx" |> charList

        let rotated = apply -2 plain
        
        Assert.AreEqual(expected, rotated)