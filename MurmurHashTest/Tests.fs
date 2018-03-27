namespace MurmurHashTest

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.TestMethodPassing () =
        Assert.IsTrue(true);

    // testiraj edge case v podatkih
        // prazen string, 
        // string dolžine toèno 4, 
        // string vseh možnih dolžin po mod 4
        // seed 0
        // seed preko uint32

    // testiraj dolžino stringa (lahko pride do stack overflowa?)
