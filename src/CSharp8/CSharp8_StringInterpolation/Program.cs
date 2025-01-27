namespace CSharp8_StringInterpolation;

class Program
{
    static void Main(string[] args)
    {
        var name = "John";
        var date = DateTime.Now;
        
        // Composite formatting:
        Console.WriteLine("Hello, {0}! Today is {1}, it's {2:HH:mm} now.", name, date.DayOfWeek, date);
        
        // String interpolation:
        Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");
        
        // The following example uses optional formatting components described in the preceding table:
        Console.WriteLine($"|{"Align Left", -20}|{"Align Right", 20}|");
    }
}