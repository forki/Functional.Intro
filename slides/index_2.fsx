(**
- title : F# Intro
- description : F# Intro
- author : Max Grebeniuk
- theme : night
- transition : zoom

***

### F#unctional journey
![FSharp Logo](https://pbs.twimg.com/profile_images/518069764510330880/yRNL7yTW.png)

---

### Objectives
- Understand the basic core principles behind FP
- Understand the F# syntax
- Understand the F# structures
- Get motivation to practice and master F#

---

### Inspired by
- [*@c4fsharp*](https://twitter.com/c4fsharp) [**"F# Community"**](https://github.com/fsprojectsgit)
- [*@ChrisMarinos*](https://twitter.com/chrismarinos) [**"F# Koans"**](https://github.com/ChrisMarinos/FSharpKoans)
- [*@JorgeFioranelli*](https://twitter.com/jorgefioranelli) [**"F# Workshop"**](https://github.com/jorgef/fsharpworkshop)

---

### F# Community
- [*fsharp.org*](http://fsharp.org/)
- [*fsharpforfunandprofit.com*](http://fsharpforfunandprofit.com/)
- [*tryfsharp.com*](http://www.tryfsharp.org/)

***

### Dive in
F# is a mature, open source, cross-platform, functional-first programming language.
![Community Logo](http://www.cornify.com/cornified/image_1257619523542.jpg)

---

### Imperative vs Functional

---

### Functional Core Concepts

***
### Conventions
<div class="fragment">
#### C#

    [lang=cs]
    var number = 1;

</div><div class="fragment">
#### F#
*)
let number = 1
(**
</div>

---
### Declarative Style

<div class="fragment">
#### Imperative
    [lang=cs]
    var potentialGirlfriends = new List<Girl>();
    foreach (var girl in girls) {
      if (girl.IsGorgeous && girl.IsAdult)
        potentialGirlfriends.Add(girl);
    }
</div><div class="fragment">
#### Declarative
    [lang=cs]
    var potentialGirlfriends = girls.Where(g => g.IsGorgeous &&
                                                g.IsAdult);
</div>

---
### Immutability

#### C#

    [lang=cs]
    public partial class Girl
    {
        public Girl(int age, int intelligenceScore, int beautyScore)
        {
          this.age = age;
          this.intelligenceScore = intelligenceScore;
          this.beautyScore = beautyScore;
        }

        private readonly int age;
        private readonly int beautyScore;
        private readonly int intelligenceScore;
        public int Age {
          get { return this.age; } }
        public int BeautyScore {
          get { return this.beautyScore; } }
        public int IntelligenceScore {
          get { return this.intelligenceScore; } }
    }

---
### Immutability

#### C# (continuation)

    [lang=cs]
    public partial class Girl
    {
      public bool IsAdult {
        get {
          return this.age > 18;
        }
      }

      public bool IsGorgeous {
        get {
          return this.intelligenceScore > 90 && this.beautyScore > 90;
        }
      }
    }

---
### Immutability
#### F#
*)
type Girl = { Age : int;
              IntelligenceScore : int;
              BeautyScore : int } with

              member this.IsAdult =
                  this.Age > 18

              member this.IsGorgeous =
                  this.IntelligenceScore > 90 &&
                  this.BeautyScore > 90

let girl = { Age = 19; IntelligenceScore = 93; BeautyScore = 95 }
(**
<div class="fragment">
##### Result
*)
(*** include-value: girl ***)
(**
</div>

***
### Functions
#### C#

    [lang=cs]
    int Sum(int num1, int num2)
    {
      var result = num1 + num2;
      return result;
    }


<div class="fragment">

    [lang=cs]
    int Sum(int num1, int num2)
    {
      return num1 + num2;
    }

</div><div class="fragment">

    [lang=cs]
    Func<int, int, int> Sum = (num1, num2) => num1 + num2;

</div>

---
### Functions
#### F#
*)
let sum num1 num2 =
  let result = num1 + num2
  result
(**
<div class="fragment">
*)
let sum' num1 num2 =
  num1 + num2
(**
</div><div class="fragment">
*)
let inline sum'' num1 num2 = num1 + num2
(**
</div>

***
### Pure Functions and Side Effects

#### Pure function

    [lang=cs]
    int Sum(int a, int b)
    {
      return a + b;
    }

<div class="fragment">
#### Function with side effect

    [lang=cs]
    private int accumulator = 0;

    int Sum(int a, int b)
    {
      accumulator++;
      return a + b;
    }

</div>

***
### Expressions
#### C# (expressions & statements)
    [lang=cs]
    // Expression
    a == b //returns a bool

    // Statement
    var a = 1; // does not return anything

<div class="fragment">

    [lang=cs]
    int result;
    if (a == b) { // expression
      result = 1; // statement
    } else {
      result = 2; // statement
    }

</div><div class="fragment">

    [lang=cs]
    var result = (a == b) ? 1 : 2;

</div>

---
### Expressions
#### F# (only expressions)
*)
let a = 1 (* returns int=1 *)
(**
*)
let add a b = (* returns int -> int -> int *)
  a + b
(**
*)
let add' a b c = (* returns int -> int -> int -> int *)
  let x = add a b
  add x c
(**
<div class="fragment">
...pipeline operator to the resque...
*)
let add'' a b c = a |> add b |> add c (* partial application *)
(**
</div><div class="fragment">
..."+" is a function...
*)
let add''' a b c = a |> (+) b |> (+) c (* partial add *)
(**
</div>

***
### Tuples
#### C#

    [lang=cs]
    Tuple<int, int> Divide(int divident, int divisor)
    {
      var quotient = divident / divisor;
      var remainder = divident % divisor;
      // composition
      return new Tuple<int, int>(quotient, remainder);
    }

<div class="fragment">

    [lang=cs]
    var result = Divide(10, 3);
    // decomposition
    var quotient = result.Item1;
    var remainder = result.Item2;

</div>

---
### Tuples
#### F#
*)
let divide divident divisor =
  let quotient = divident / divisor
  let remainder = divident % divisor
  (quotient, remainder) (* composition *)
(**
<div class="fragment">
*)
open System

let quotient, remainder = divide 10 3 (* decomposition *)
let success, value = Int32.TryParse("42")

(**
</div>

***
### Records
#### C#

    [lang=cs]
    public class DivisionResult
    {
      public int Quotient { get; set; }
      public int Remainder { get; set; }
    }

<div class="fragment">

    [lang=cs]
    public class DivisionResult {
      private readonly int quotient;
      private readonly int remainder;
      public DivisionResult(int quotient, int remainder) {
        this.quotient = quotient;
        this.remainder = remainder;
      }
      public int Quotient { get { return this.quotient; } }
      public int Remainder { get { return this.remainder; } }
      // TODO: Override GetHashCode, Equals, implement IEquatable
    }

</div>

---
### Records
#### F#
*)
type DivisionResult = { Quotient : int
                        Remainder : int }
(**
<div class="fragment">
*)
let result = { Quotient = 3; Remainder = 1 }
(**
</div><div class="fragment">
*)
let newResult = { Quotient = result.Quotient; Remainder = 0 }
(**
</div><div class="fragment">
*)
let newResult' = { result with Remainder = 0 }
(**
</div><div class="fragment">
*)
let recordsEqual =
  newResult = newResult' (* reference types with structural equality *)
(**
</div>
<div class="fragment">
##### Result
*)
(*** include-value: recordsEqual ***)
(**
</div>

---
### Immutable & Structural Equality
#### C#

    [lang=cs]
    var message1 = "John Snow is dead";
    var message2 = "John Snow is dead";

...John Snow will be dead anyways...

    [lang=cs]
    var result = message1 == message2; // true

...Guess what happened with Stannis Baratheon...

    [lang=cs]
    var message3 = message1.Replace("John Snow", "Stannis Baratheon")

***

### High Order Functions
#### C#

    [lang=cs]
    public int Sum(int a, int b) {
      return a + b;
    }

<div class="fragment">

    [lang=cs]
    public int Execute(int a, int b, Func<int, int, int> operation) {
      return operation(a, b);
    }

</div><div class="fragment">

    [lang=cs]
    var result = Execute(1, 2, (a, b) => a + b);

</div><div class="fragment">

    [lang=cs]
    var result = Execute(1, 2, (a, b) => a * b);

</div><div class="fragment">

    [lang=cs]
    var result = Execute(1, 2, Sum);

</div>

---
### High Order Functions
#### C#

    [lang=cs]
    var girlNames = girls.Where(g => g.IsGorgeous &&
                                     g.IsAdult)
                         .Select( g => g.Name);

<div class="fragment">

    [lang=cs]
    public Func<int, int, int> GetOpStrategy(Type operationType)
    {
      return (operationType == Type.Sum)
        ? (a, b) => a + b;
        : (a, b) => a - b;
    };

    var operation = GetOpStrategy(operationType);

</div>

---
### High Order Functions
#### F#

    [lang=fs]
    let summ a b = a + b
    let execute a b op = op a b

<div class="fragment">

    [lang=fs]
    let getOpStrategy type =
      if type = OperationType.Sum then fun a b -> a + b
      else fun a b -> a - b

</div><div class="fragment">

    [lang=fs]
    let getOpStrategy type =
      match type with
      | OperationType.Sum -> (+)
      | _ -> (-)

</div>

***
### Execution Pipeline
#### C# => *Extension Methods*

    [lang=cs]
    public List<int> Filter<int>(List<int> list, Func<int, bool> condition)

    var filteredNumbers = Filter(numbers, n => n > 1);

<div class="fragment">

    [lang=cs]
    public static List<int> Filter<int>(this List<int> list, Func<int, bool> condition)

    var filteredNumbers = numbers.Filter(n => n > 1);

</div><div class="fragment">

    [lang=cs]
    var filteredNumbers = numbers.Filter(n => n > 1)
                                 .Filter(n => n < 5);

</div>

---
### Execution Pipeline
#### F# => *Pipelining Operator*

    [lang=fs]
    let filter condition list = ...

    let filteredNumbers = filter (fun n -> n > 1) numbers

<div class="fragment">

    [lang=fs]
    let (|>) x y = y x

</div><div class="fragment">

    [lang=fs]
    let filteredNumbers numbers |> filter (fun n -> n > 1)

</div><div class="fragment">

    [lang=fs]
    let filteredNumbers numbers
                        |> filter (fun n -> n > 1)
                        |> filter (fun n -> n < 5)

</div>

***
### Partial application
*)
let summ a b = a + b

let result' = summ 1 2

let ``add 1 to number`` = summ 1

let result'' = ``add 1 to number`` 2

let result''' = ``add 1 to number`` 3
(**

***
### Composition
*)
let addOne a = a + 1

let addTwo a = a + 2

let addThree a = addOne >> addTwo

let num = addThree 1
(**
<div class="fragment">
##### Result
*)
(*** include-value: num ***)
(**
</div>

***
### Demo

    >*Demo time!*

*)
