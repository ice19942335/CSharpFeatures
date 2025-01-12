// See https://aka.ms/new-console-template for more information

var day = new Day{ Name = "SUNDAY"};
Console.WriteLine($"Passing {day} into switch expression with False.");
Console.WriteLine(GetExpressionResult(day, false));

Console.WriteLine($"Passing {day} into switch expression with True.");
Console.WriteLine(GetExpressionResult(day, true));

string GetExpressionResult(Day value, bool test)
{
    // Property + switch expression example
    return value switch
    {
        { Name: "SUNDAY" } when test => "Weekend when True",
        { Name: "SUNDAY" } when test == false => "Weekend when False",
        { Name: "MONDAY" } => "Start of the weekday",
        { Name: "FRIDAY" } => "End of the weekday",
        _ => "Invalid day"
    };
}

record Day
{
    public required string Name { get; set; }
}