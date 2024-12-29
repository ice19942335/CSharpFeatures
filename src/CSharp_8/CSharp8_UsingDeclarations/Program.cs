// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/using

using System.Runtime.CompilerServices;

var cancellationToken = CancellationToken.None;
var path = Path.Combine(Environment.CurrentDirectory, "Text.txt");

await foreach (var number in GetNumbers(path, cancellationToken))
{
    Console.WriteLine($"{DateTime.Now:hh:mm:ss.fff}: {number}");
}

return;

static async IAsyncEnumerable<int> GetNumbers(string filePath, [EnumeratorCancellation] CancellationToken cancellationToken)
{
    using StreamReader reader = File.OpenText(filePath);

    while (await reader.ReadLineAsync(cancellationToken) is { } line)
    {
        if (int.TryParse(line, out int number))
        {
            await Task.Delay(1000, cancellationToken);
            yield return number;
        }
    }

    // When declared in a using declaration, a local variable is disposed at the end of the scope in which it's declared.
    // In the preceding example, disposal happens at the end of a method.
}

static async Task<int> GetNumber(string[] filePaths, CancellationToken cancellationToken)
{
    using StreamReader reader = File.OpenText(filePaths[0]);
    using StreamReader reader1 = File.OpenText(filePaths[1]);

    var line = await reader.ReadLineAsync(cancellationToken);
    if (line is not null && int.TryParse(line, out int number))
    {
        return number;
    }

    return 0;
    
    // When you declare several instances in one using statement, they are disposed in reverse order of declaration.
}