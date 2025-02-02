using System.Text.Json.Serialization;

namespace CSharp9_Records_PositionalSyntaxForPropertyDefinition;

/// <summary>
/// Simple record with positional syntax
/// </summary>
record Person1(string FirstName, string LastName);

/// <summary>
/// Record with positional syntax + attributes
/// </summary>
record Person2(
    [property: JsonPropertyName("firstName")]
    string FirstName,
    [property: JsonPropertyName("lastName")]
    string LastName);

/// <summary>
/// Record with positional syntax + property behaviour override
/// </summary>
record Person3(string FirstName, string LastName, string Id)
{
    internal string Id { get; init; } = Id;
}

/// <summary>
/// Record with positional syntax combined with standard property initialization syntax
/// </summary>
record Person4(string FirstName, string LastName)
{
    public string[] PhoneNumbers { get; init; } = [];
}

class Program
{
    static void Main(string[] args)
    {
        var person1 = new Person1("John", "Gates");
        var person2 = new Person2("John", "Gates");
        var person3 = new Person3("John", "Gates", "LV123456789");
        var person4 = new Person4("John", "Gates") { PhoneNumbers = ["+44 123456789", "+44 987654321"] };
    }
}