namespace MurmurHashTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open Murmur3
open System

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.EmptyString () =
        Assert.IsTrue(murmur3 "" 5u = 3423425485u);

    [<TestMethod>]
    member this.StringLength4 () =
        Assert.IsTrue(murmur3 "sgcg" 5u = 920588061u);

    [<TestMethod>]
    member this.StringLength5 () = // mod 5 = 1
        Assert.IsTrue(murmur3 "sgcgs" 5u = 2023615742u);

    [<TestMethod>]
    member this.StringLength6 () = // mod 4 = 2
        Assert.IsTrue(murmur3 "sgcgsg" 5u = 644375083u);

    [<TestMethod>]
    member this.StringLength7 () = // mod 4 = 2
        Assert.IsTrue(murmur3 "sgcgsga" 5u = 2375236397u);

    [<TestMethod>]
    member this.Key0 () =
        Assert.IsTrue(murmur3 "sgcg" 0u = 221061426u);
        
    [<TestMethod>]
    member this.SpecialCharacters () =
        Assert.ThrowsException<ArgumentException>(fun () -> murmur3 "èèšæðž!_" 5u |> ignore);

    // testiraj edge case v podatkih
        // prazen string, 
        // string dolžine toèno 4, 
        // string vseh možnih dolžin po mod 4
        // seed 0
        // posebni znaki

    // testiraj dolžino stringa (lahko pride do stack overflowa?)
