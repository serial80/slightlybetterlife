// Implements Conway's Game Of Life slightly better than before
// https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life on a torus

open System

// returns the number of live neighbours the cell at (row,col) has has in world
let countNeighbours (world : bool list list) row col =
    let rows = world.Length
    let cols = world.[0].Length
    
    let mutable neighbours = 0
    
    if (world.[if row - 1 < 0 then rows - 1 else row - 1].[if col - 1 < 0 then cols - 1 else col - 1]) then neighbours <- neighbours+1
    if (world.[if row - 1 < 0 then rows - 1 else row - 1].[col]) then neighbours <- neighbours+1
    if (world.[if row - 1 < 0 then rows - 1 else row - 1].[if col + 1 = cols then 0 else col + 1]) then neighbours <- neighbours+1
    
    if (world.[row].[if col - 1 < 0 then cols - 1 else col - 1]) then neighbours <- neighbours+1
    if (world.[row].[if col + 1 = cols then 0 else col + 1]) then neighbours <- neighbours+1
    if (world.[if row + 1 = rows then 0 else row + 1].[if col - 1 < 0 then cols - 1 else col - 1]) then neighbours <- neighbours+1
    if (world.[if row + 1 = rows then 0 else row + 1].[col]) then neighbours <- neighbours+1
    if (world.[if row + 1 = rows then 0 else row + 1].[if col + 1 = cols then 0 else col + 1]) then neighbours <- neighbours+1
    
    printfn "%i,%i neighbours=%i" row col neighbours // to check if the above is working
    
    neighbours

// determines the state of a cell in the next phase given its current state and number of neighbours
let evolveCell alive neighbours =
    if (alive && neighbours < 2) then false
    else if (alive && neighbours = 2 || neighbours = 3) then true
    else if (alive && neighbours > 3) then false
    else if (not alive && neighbours = 3) then true 
    else false

// generates the next phase of a world
let evolve (world : bool list list) : bool array array = 
    let newWorld : bool array array = Array.zeroCreate world.Length
    for row in [0 .. world.Length-1] do
        newWorld.[row] <- Array.zeroCreate world.[row].Length
        for col in [0 .. world.[row].Length-1] do
            let neighbours = countNeighbours world row col
            newWorld.[row].[col] <- evolveCell world.[row].[col] neighbours
    newWorld 

let mapInputCharToBool chr =
    match chr with
        | '*' -> true
        | _ -> false

let mapStringToBoolList str =
    List.map mapInputCharToBool (Seq.toList str)

let mapAllInputToWorld (str : string) =
    List.map mapStringToBoolList ( Array.toList (str.Split Environment.NewLine) )

[<EntryPoint>]
let main argv =
    use reader = new System.IO.StreamReader("sample_input.txt")
    let inputText = reader.ReadToEnd()

    let world = mapAllInputToWorld inputText 

    let newWorld = evolve world

    for a in [0 .. newWorld.Length-1] do
        let mutable line = ""
        for b in [0 .. newWorld.[0].Length-1] do
            if newWorld.[a].[b] then line <- line + "*" else line <- line + "."
        printfn "%s" line
            
    42 // return an integer exit code

