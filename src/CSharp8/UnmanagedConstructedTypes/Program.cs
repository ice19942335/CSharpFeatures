namespace UnmanagedConstructedTypes;

class MyCustomDict<TKey, TValue>
    where TKey : struct
    where TValue : unmanaged
{
    private Dictionary<TKey, TValue> _dict = new();

    public TValue this[TKey index]
    {
        get => _dict[index];
        set => _dict[index] = value;
    }

    public void Add(TKey key, TValue value)
    {
        _dict.Add(key, value);
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, _dict.Select(x => $"Key: {x.Key}, Value: {x.Value}"));
    }
}

struct Key
{
    public string Name { get; init; }

    public override string ToString() => Name;
}

struct ValidUnmanagedValue // Satisfies unmanaged constraint https://stackoverflow.com/questions/55016755/difference-between-unmanaged-and-struct-constraints-in-c-sharp-generics
{
    public int Id { get; init; }
    public int Permission { get; init; }

    public override string ToString() => $"Id: {Id} - Permission: {Permission}";
}

struct InvalidUnmanagedValue // Does not satisfy unmanaged constraint https://stackoverflow.com/questions/55016755/difference-between-unmanaged-and-struct-constraints-in-c-sharp-generics
{
    public string Name { get; set; }
    public int[] Permissions { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        InvalidUsageOfUnmanagedConstraint();
        ValdUsageOfUnmanagedConstraint();
    }

    private static void ValdUsageOfUnmanagedConstraint()
    {
        // Will compile =) All constraints are satisfied.
        var dict = new MyCustomDict<Key, ValidUnmanagedValue>();
        dict.Add(new Key { Name = "Key1" }, new ValidUnmanagedValue { Id = 1, Permission = 1 });
        Console.WriteLine(dict);
    }

    private static void InvalidUsageOfUnmanagedConstraint()
    {
        // Will not compile as we're trying to apply invalid unmanaged struct.
        // var dict = new MyCustomDict<Key, InvalidUnmanagedValue>();
    }
}