open System
open System.Text

let murmur3 (key:string) seed = 
    let c1 = 0xcc9e2d51u
    let c2 = 0x1b873593u
    let r1 = 15
    let r2 = 13
    let m = 5u
    let n = 0xe6546b64u

    let bytes = Encoding.ASCII.GetBytes key
    let hash = seed

    let rec hashAndBits (key:byte[]) (hash: uint32) (i:int) = 
        if i >= key.Length then hash
        elif i <= key.Length-4 then
            let mutable k = BitConverter.ToUInt32(key, i)
            k <- k * c1
            k <- (k <<< r1) ||| (k >>> 32-r1)
            k <- k * c2;
            let hash = hash ^^^ k
            let hash = (hash <<< r2) ||| (hash >>> 32-r2);
            let hash = hash * m + n
            hashAndBits key hash (i + 4)
        else
            let bytes = key |> Seq.skip i |> Seq.take (key.Length - i) |> fun s -> Seq.append s [0uy; 0uy; 0uy] |> Seq.toArray
            let bytes = if not BitConverter.IsLittleEndian then bytes |> Array.rev else bytes
            let mutable k = BitConverter.ToUInt32(bytes, 0)
            k <- k * c1
            k <- (k <<< r1) ||| (k >>> 32-r1)
            k <- k * c2;
            let hash = hash ^^^ k
            hashAndBits key hash (key.Length)

    let hash = hashAndBits bytes hash 0
    let hash = hash ^^^ (uint32)bytes.Length

    let hash = hash ^^^ (hash >>> 16)
    let hash = hash * 0x85ebca6bu
    let hash = hash ^^^ (hash >>> 13)
    let hash = hash * 0xc2b2ae35u
    let hash = hash ^^^ (hash >>> 16)

    hash



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
