// See https://aka.ms/new-console-template for more information


IDefaultInterfaceMethod anyClass = new AnyClass();
anyClass.DefaultMethod();
Console.ReadKey();

public interface IDefaultInterfaceMethod
{
    public const int Number = 100;
    
    public void DefaultMethod()
    {
        Console.WriteLine($"I am default method in the interface! My number is: {Number}");
    }
}

public class AnyClass : IDefaultInterfaceMethod
{
}