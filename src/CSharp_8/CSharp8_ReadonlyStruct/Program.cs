// See https://aka.ms/new-console-template for more information

Rectangle rectangle = new Rectangle(10, 20);
Console.WriteLine("Height: " + rectangle.Height);
Console.WriteLine("width: " + rectangle.Width);
Console.WriteLine("Rectangle Area: " + rectangle.Area);
Console.WriteLine("Rectangle: " + rectangle);
Console.ReadKey();

// rectangle.Height = rectangle.Height / 2; //Compiling error

public readonly struct Rectangle
{
    public double Height { get; }
    public double Width { get; }
    public double Area => Height * Width;

    public Rectangle(double height, double width)
    {
        Height = height;
        Width = width;
    }

    public override string ToString()
    {
        return $"(Total area for height: {Height}, width: {Width} is {Area})";
    }
}