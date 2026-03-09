open System



let len (length: int) (strings: string list) =
    strings |> List.fold (fun acc s -> 
        if s.Length = length 
        then acc + 1 
        else acc) 0

let rec colstrok() =
    printf "Enter col strok: "
    let input = Console.ReadLine()
    match Int32.TryParse(input) with
    | (true, n) when n > 0 -> n
    | _ ->
        printfn "Error number is no avelibale"
        colstrok()

let rec lenstrok (spisok: string list) =
    printf "\nEnter len to find: "
    let input = Console.ReadLine()
    match Int32.TryParse(input) with
    | (true, length) when length >= 0 ->
        let result = len length spisok
        printfn "\n Original spisok:"
        List.iteri (fun i s -> printfn "  %d- \"%s\"" (i + 1) s) spisok
        printfn "\n col strok dliny %d: %d" length result
        lenstrok spisok 
    | _ ->
        printfn "Error: enter norm chislo"
        lenstrok spisok 


let askK() =
    printf "enter k: "
    Console.ReadLine()

let readstroka(index: int) =
    printf "Enter strok %d: " (index)
    Console.ReadLine()

let addstroka(count: int) =
    [ for i in 1 .. count -> readstroka i ]

let add (k: string) (s: string) =
    k + s

let uni k strings =
    List.map (add k) strings

let print before after =
    printfn "\nBefore spisok:"
    List.iteri (fun i s -> printfn "  %d- \"%s\"" (i + 1) s) before
    printfn "\nAfter spisok:"
    List.iteri (fun i s -> printfn "  %d- \"%s\"" (i + 1) s) after



let quest1() =
    let count = colstrok()
    let k = askK()
    printfn "\nEnter %d strok:" count
    let spisok = addstroka count
    let spisok2 = uni k spisok
    print spisok spisok2
    0


let quest2() =
    let count = colstrok()
    printfn "\nEnter %d strok:" count
    let spisok = addstroka count
    lenstrok spisok
    0


[<EntryPoint>]
let main argv =
    printf "Enter zadanie: "
    let quest = int(Console.ReadLine())
    match quest with
    | 1 -> quest1()  
    | 2 -> quest2()  
    0 