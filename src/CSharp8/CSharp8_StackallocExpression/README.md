# stackalloc expression
> More info can be found here:<br>
> https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/stackalloc<br>
> https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#239-stack-allocation<br>
> https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#12822-stack-allocation<br>
> https://stackoverflow.com/questions/785226/practical-use-of-stackalloc-keyword<br>
> https://stackoverflow.com/questions/78113377/what-is-the-most-efficient-way-to-create-a-temporary-collection-differences-bet

## The results of benchmark
`2.1057 / 0.0775 ≈ 27.171`&ensp;- NewArray against collection expression<br>
`0.3492 / 0.0775 ≈ 4.505`&emsp;- stackalloc against collection expression<br>
Seems that the collection expression feature is the fastest, and it does not allocate any memory in `heap`.<br>
Collection expression also it has very nice and beautiful easy to use API.
In my opinion we should use collection expression in every possible case.<br>
![img_3.png](img_3.png)