open System
open System.Text
open Murmur3

[<EntryPoint>]
let main argv =
    printfn "Enter ASCII string to encode"
    let key = Console.ReadLine()
    printfn "Enter uint32 seed (default 5)"
    let seed = Console.ReadLine() |> fun line -> if line.Length = 0 then 5u else line |> uint32
    let result = murmur3 key seed
    printfn "Enter 'correct' value"
    let trueValue = Console.ReadLine() |> uint32
    printfn "You got %u which is %s" result (if trueValue = result then "correct" else "incorrect")
    printfn "\nPress any key to exit..."
    Console.ReadKey() |> ignore
    0
