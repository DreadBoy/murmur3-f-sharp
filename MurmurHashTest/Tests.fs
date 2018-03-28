namespace MurmurHashTest

open Microsoft.VisualStudio.TestTools.UnitTesting
open Murmur3

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.TestMethodPassing () =
        Assert.IsTrue(true);

    [<TestMethod>]
    member this.EmptyString () =
        Assert.Equals(murmur3 "" 5u, 3423425485u) 

    // testiraj edge case v podatkih
        // prazen string, 
        // string dolžine toèno 4, 
        // string vseh možnih dolžin po mod 4
        // seed 0
        // seed preko uint32

    // testiraj dolžino stringa (lahko pride do stack overflowa?)
