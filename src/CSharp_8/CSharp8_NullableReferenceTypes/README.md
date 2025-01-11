# Nullable reference types (C# reference)
> https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-reference-types

# Setting the nullable context
There are two ways to control the nullable context. At the project level, you can add the <Nullable>enable</Nullable> project setting.
In a single C# source file, you can add the #nullable enable pragma to enable the nullable context. See the article on setting a nullable strategy.
Before .NET 6, new projects use the default, <Nullable>disable</Nullable>.
Beginning with .NET 6, new projects include the <Nullable>enable</Nullable> element in the project file.