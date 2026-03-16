open System



let len (length: int) (strings: string list) =
    strings |> List.fold (fun acc s -> 
        if s.Length = length 
        then acc + 1 
        else acc) 0

let rec amountline() =
    printf "Enter amount line: "
    let input = Console.ReadLine()
    match Int32.TryParse(input) with
    | (true, n) when n > 0 -> n
    | _ ->
        printfn "Error number is no avelibale"
        amountline()

let rec lenline (list: string list) =
    printf "\nEnter len to find: "
    let input = Console.ReadLine()
    match Int32.TryParse(input) with
    | (true, length) when length >= 0 ->
        let result = len length list
        printfn "\n Original list:"
        List.iteri (fun i s -> printfn "  %d- \"%s\"" (i + 1) s) list
        printfn "\n amount line lenght %d: %d" length result
        lenline list 
    | _ ->
        printfn "Error: enter good number"
        lenline list 


let askK() =
    printf "enter k: "
    Console.ReadLine()

let readline(index: int) =
    printf "Enter line %d: " (index)
    Console.ReadLine()

let addline(count: int) =
    [ for i in 1 .. count -> readline i ]

let add (k: string) (s: string) =
    k + s

let uni k strings =
    List.map (add k) strings

let print before after =
    printfn "\nBefore list:"
    List.iteri (fun i s -> printfn "  %d- \"%s\"" (i + 1) s) before
    printfn "\nAfter list:"
    List.iteri (fun i s -> printfn "  %d- \"%s\"" (i + 1) s) after



let quest1() =
    let count = amountline()
    let k = askK()
    printfn "\nEnter %d line:" count
    let list = addline count
    let list2 = uni k list
    print list list2
    0


let quest2() =
    let count = amountline()
    printfn "\nEnter %d line:" count
    let list = addline count
    lenline list
    0


[<EntryPoint>]
let main argv =
    printf "Enter quest: "
    let quest = int(Console.ReadLine())
    match quest with
    | 1 -> quest1()  
    | 2 -> quest2()  
    0 