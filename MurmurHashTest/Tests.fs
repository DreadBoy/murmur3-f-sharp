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
        // string dol�ine to�no 4, 
        // string vseh mo�nih dol�in po mod 4
        // seed 0
        // seed preko uint32

    // testiraj dol�ino stringa (lahko pride do stack overflowa?)
