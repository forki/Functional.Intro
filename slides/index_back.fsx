(**
- title : Functional.Intro
- description : Brief history of functional programming
- author : Max Grebeniuk
- theme : night
- transition : default

***

### Why functional programming matters?

' Functional programming dates back to the 1940s. 
' back then it was rather different (minimalist)

<div class="fragment">

- Minimalist: who needs booleans?

</div>

<div class="fragment">

- A boolean just _makes a choise_!

</div>

<div class="fragment">

```fsharp
 let fun_true () = 1
 let fun_false () = 0
```

</div>

---

## Let's define a boolean 

<div class="fragment">

- A boolean just _makes a choise_!

</div>
**)

let fun_true x y = x
let fun_false x y = y

(**
<div class="fragment">

- What about defining **if..then..else** ?

</div>

<div class="fragment">
**)
let ifte pred opt_x opt_y = 
    pred opt_x opt_y  
(**
</div>

***

### Who needs integers?

' integers are usually used to count iterations
> Let's define integer

<div class="fragment">
' f is a loop body
**)

let twice f x = f (f x)

(**
</div>
<div class="fragment">
**)

let once f x = f x

(**
</div>
<div class="fragment">
**)

let zeroes f x = x

(**
</div>

<div class="fragment">

' all info is in these functions
> Let's recover a _normal_ integer
**)

let two = twice ((+) 1) 0

(**
</div>
<div class="fragment">
- lets print out the result
**)
(*** include-output:two ***)
(**
</div>
*)