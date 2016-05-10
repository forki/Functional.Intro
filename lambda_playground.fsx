// 1. All we have is a lambda, single input, single output
// 2. Build natural numbers
// 3. Peano's Axioms (italian gerk josepy piano)

(*
    # number properties
    4 for every number x, x = x (reflexive)
    5 for all numbers x and y, if x = y, then y = x (symmetric)
    6 for all numbers x, y and z, if x = y and y = z, then x = z (transitive)
    7 for all a nd bm if b is a natural number and a = b, then a is also a netural number (closed under equality)
    # successor function properties
    8 for every number n, S(n) is a number (closed under successor)
    9 for all numbers m and n, m = n if and only if S(n) = S(n) (S is an injection)
    10 for every number n, S(n) = 0 is false (0 is the starting point)
*)

//identity x -> x
//assert true -> output "T"
//assert false -> output "F"
    
    
    
    
let Identity = fun x -> x()

let Invert = fun f x y  -> f y x
 
let True = fun x y -> x

let False = fun x y -> y

let If = fun pred x y -> (pred x y) |> Identity
    
let Assert = fun boolean -> If boolean (fun () -> printfn "T") (fun () -> printfn "F")

let Refute = fun boolean -> If (Invert boolean) (fun () -> printfn "T") (fun () -> printfn "F")


let zero = fun () -> True

//sucessor
let Succ = fun x -> fun () -> False


let IsZero = fun x -> x |> Identity

let NumbersEqual = fun x y -> 
    If (IsZero x) 
        (fun () -> IsZero y) 
        (fun () -> Invert (IsZero y))





IsZero zero |> Assert
NumbersEqual zero zero |> Assert
NumbersEqual (Succ zero) (Succ zero) |> Assert

Succ zero |> IsZero |> Refute
NumbersEqual zero (Succ zero) |> Refute
NumbersEqual (Succ zero) zero |> Refute


NumbersEqual (Succ (Succ zero)) (Succ zero) |> Assert
