// See https://aka.ms/new-console-template for more information

Rectangle rectangle = new Rectangle { Length = 5, Height = 10 };
IsSpecificRectanglee(rectangle);

void IsSpecificRectanglee(Rectangle rect)
{
    if (rect is Rectangle { Length: 5 or 10, Height: 10 or 20 } specificRectangle)
    {
        Console.WriteLine($"Rectangle Length: {specificRectangle.Length} and Height: {specificRectangle.Height}");
    }
}

class Rectangle
{
    public double Length { get; set; }
    public double Height { get; set; }
}