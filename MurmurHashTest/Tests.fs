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
        // string dol�ine to�no 4, 
        // string vseh mo�nih dol�in po mod 4
        // seed 0
        // seed preko uint32

    // testiraj dol�ino stringa (lahko pride do stack overflowa?)
