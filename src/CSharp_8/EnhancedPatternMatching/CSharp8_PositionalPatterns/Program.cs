// See https://aka.ms/new-console-template for more information

var rectangle = new Rectangle { Length = 20, Height = 40 };
var (length, height) = rectangle;
Console.WriteLine($"The rectangle Length: {length} and Height: {height}");

if (rectangle is (20, _) rect)
{
    Console.WriteLine("The rectangle has a length of 20");
}

class Rectangle
{
    public double Height { get; set; }
    public double Length { get; set; }

    public void Deconstruct(out double length, out double height)
    {
        height = Height;
        length = Length;
    }
}