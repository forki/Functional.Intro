// bools
let fun_true x y = x
let fun_false x y = y


let ifte pred opt_x opt_y = 
    pred opt_x opt_y

// programming like a math gerk

let two f x = f (f x)
let one f x = f x
let zero f x = x

let result = two ((+) 1) 0


// let's do some math

let add m n f x = m f (n f x)

let multiply m n f x = m (n f) x

let result = add one (multiply two two) ((+) 1) 0
