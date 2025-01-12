public static class Program
{
    public static void Main(string[] args)
    {
        using var mug = new Mug(10, 1);
        Console.WriteLine(mug.ToString());

        using var mug2 = new Mug(10, 2);
        Console.WriteLine(mug2.ToString());
    }
}

public ref struct Mug : IDisposable
{
    private int capacity;
    private int index;
    private StreamReader reader;

    public Mug(int capacity, int nameIndex)
    {
        this.capacity = capacity;
        this.index = nameIndex;
    }

    public int GetCapacity()
    {
        if (System.Runtime.CompilerServices.Unsafe.IsNullRef(ref capacity))
        {
            throw new InvalidOperationException($"The {nameof(capacity)} field is not initialized.");
        }

        return capacity;
    }

    public string GetName()
    {
        try
        {
            reader = new StreamReader(Path.Combine(Environment.CurrentDirectory, "MugNames.txt"));

            var i = 0;
            while (reader.ReadLine() is { } line)
            {
                i++;
                if (i == index)
                {
                    return line;
                }
            }

            throw new InvalidOperationException($"The index '{index}' not found.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override string ToString()
    {
        return $"Mug name '{GetName()}, Capacity: {GetCapacity()}";
    }

    public void Dispose()
    {
        if (reader is not null)
        {
            reader.Dispose();
            Console.WriteLine($"Mug {index} - Disposed");
        }
    }
}