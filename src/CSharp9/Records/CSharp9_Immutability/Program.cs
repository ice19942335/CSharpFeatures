namespace CSharp9_Immutability;

record Person(string Name, string LastName, string[] PhoneNumbers);

class Program
{
    static void Main(string[] args)
    {
        var person = new Person("John", "Doe", new[] {"123-456-1111", "123-456-2222"});
        Console.WriteLine(person.PhoneNumbers[0]);

        //person.PhoneNumbers = []; //Invalid assignment as PhoneNumbers is property with { get; init; } accessing.
        
        // Changing not the object state but the state of array that object is referencing to.
        person.PhoneNumbers[0] = "123-456-3333";
        Console.WriteLine(person.PhoneNumbers[0]);
    }
}