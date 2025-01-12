// This particular example is made specifically for - Local functions and exceptions - To demonstrate that:
// One of the useful features of local functions is that they can allow exceptions to surface immediately.
// For iterator methods, exceptions are surfaced only when the returned sequence is enumerated, and not when the iterator is retrieved.
public static class Program
{
    public static void Main(string[] args)
    {
        IEnumerable<int> xs = OddSequence(50, 110);
        Console.WriteLine("Retrieved enumerator...");

        foreach (var x in xs)
        {
            Console.Write($"{x} ");
        }
    }

    private static IEnumerable<int> OddSequence(int start, int end)
    {
        if (start < 0 || start > 99)
            throw new ArgumentOutOfRangeException(nameof(start), "start must be between 0 and 99.");
        if (end > 100)
            throw new ArgumentOutOfRangeException(nameof(end), "end must be less than or equal to 100.");
        if (start >= end)
            throw new ArgumentException("start must be less than end.");
            
        return GetOddSequenceEnumerator();

        // One of the useful features of local functions is that they can allow exceptions to surface immediately.
        IEnumerable<int> GetOddSequenceEnumerator()
        {
            for (var i = start; i <= end; i++)
            {
                if (i % 2 == 0)
                {
                    yield return i;
                }
            }
        }
    }
}



