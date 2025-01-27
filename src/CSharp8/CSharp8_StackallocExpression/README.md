# stackalloc expression
> More info can be found here:<br>
> https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/stackalloc<br>
> https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#239-stack-allocation<br>
> https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#12822-stack-allocation<br>
> https://stackoverflow.com/questions/785226/practical-use-of-stackalloc-keyword<br>
> https://stackoverflow.com/questions/78113377/what-is-the-most-efficient-way-to-create-a-temporary-collection-differences-bet

## The results of benchmark
Seems that the `Collection expression` feature is the fastest, and it does not allocate any memory in `heap` at all!.<br>
The `Collection expression` feature also has very nice and beautiful easy to use API.
In my opinion we should use collection expression in every possible case.<br> Be aware that stack is limited by available memory!

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22621.4317/22H2/2022Update/SunValley2)<br>
12th Gen Intel Core i7-1255U, 1 CPU, 12 logical and 10 physical cores<br>
.NET SDK 9.0.102<br>
[Host]     : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2<br>
DefaultJob : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2<br>

| Method               | Mean      | Error     | StdDev    | Median    | Gen0   | Allocated |
|--------------------- |----------:|----------:|----------:|----------:|-------:|----------:|
| NewArray             | 4.2979 ns | 0.4173 ns | 1.2108 ns | 4.0314 ns | 0.0051 |      32 B |
| Stackalloc           | 0.3051 ns | 0.0803 ns | 0.2290 ns | 0.2290 ns |      - |         - |
| CollectionExpression | 0.0068 ns | 0.0098 ns | 0.0087 ns | 0.0013 ns |      - |         - |

