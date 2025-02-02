namespace CSharp9_NondestructiveMutation;

record Person(string FirstName, string LastName)
{
    public string[] PhoneNumbers { get; init; }
}

class Program
{
    static void Main(string[] args)
    {
        Person person1 = new("John", "Doe") { PhoneNumbers = new string[1] };
        Console.WriteLine(person1); // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }
        
        Person person2 = person1 with { FirstName = "Nancy" };
        Console.WriteLine(person2); // output: Person { FirstName = John, LastName = Davolio, PhoneNumbers = System.String[] }
        Console.WriteLine(person1 == person2); // output: False;
        
        person2 = person1 with { PhoneNumbers = new string[1] };
        Console.WriteLine(person2); // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }
        Console.WriteLine(person1 == person2); // output: False
        
        person2 = person1 with { };
        Console.WriteLine(person1 == person2); // output: True
    }
}