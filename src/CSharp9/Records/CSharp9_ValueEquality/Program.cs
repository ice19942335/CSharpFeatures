namespace CSharp9_ValueEquality;

record Person(string FirstName, string LastName, string[] PhoneNumbers);

class Program
{
    static void Main(string[] args)
    {
        string[] phoneNumbers = ["123", "456"];
        
        Person person1 = new Person("John", "Doe", phoneNumbers);
        Person person2 = new Person("John", "Doe", phoneNumbers);
        Console.WriteLine(person1 == person2); // output: True

        person1.PhoneNumbers[0] = "555-555-1234"; // Changing the value of array but not the link to this array itself
        Console.WriteLine(person1 == person2); // output: true
        
        Console.WriteLine(ReferenceEquals(person1, person2)); // output: False
    }
}