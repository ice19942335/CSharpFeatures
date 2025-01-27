# ?? and ??= operators - the null-coalescing operators

> More info can be found here
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator

The null-coalescing operator `??` returns the value of its left-hand operand if it isn't `null;` otherwise, it evaluates the right-hand operand and returns its result.<br>
The `??` operator doesn't evaluate its right-hand operand if the left-hand operand evaluates to non-null.<br>
The null-coalescing assignment operator `??=` assigns the value of its right-hand operand to its left-hand operand only if the left-hand operand evaluates to `null`.<br> 
The `??=` operator doesn't evaluate its right-hand operand if the left-hand operand evaluates to non-null.

```
List<int>? numbers = null;
int? a = null;

Console.WriteLine((numbers is null)); // expected: true
// if numbers is null, initialize it. Then, add 5 to numbers
(numbers ??= new List<int>()).Add(5);
Console.WriteLine(string.Join(" ", numbers));  // output: 5
Console.WriteLine((numbers is null)); // expected: false        


Console.WriteLine((a is null)); // expected: true
Console.WriteLine((a ?? 3)); // expected: 3 since a is still null 
// if a is null then assign 0 to a and add a to the list
numbers.Add(a ??= 0);
Console.WriteLine((a is null)); // expected: false        
Console.WriteLine(string.Join(" ", numbers));  // output: 5 0
Console.WriteLine(a);  // output: 0
```

### The null-coalescing operators are right-associative. That is, expressions of the form
```aiignore
a ?? b ?? c
d ??= e ??= f
```
are evaluated as
```aiignore
a ?? (b ?? c)
d ??= (e ??= f)
```