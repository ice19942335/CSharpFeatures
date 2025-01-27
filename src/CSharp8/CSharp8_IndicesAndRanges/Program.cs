namespace CSharp8_IndicesAndRanges;

class Program
{
    static void Main(string[] args)
    {
        //SampleIndexFromEndOperator();
        //SampleRange();
        //SampleMargin();
        //SampleIndexExpression();
        SampleAllRangesFromReadmeTable();
    }

    /// <summary>
    /// Index from end operator ^
    /// </summary>
    static void SampleIndexFromEndOperator()
    {
        int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        int last = numbers[^1];
        Console.WriteLine(last);

        List<string> lines = ["One", "Two", "Three", "Four"];
        string prelast = lines[^2];
        Console.WriteLine(prelast);

        string word = "Tweleve";
        Index toFirst = ^word.Length;
        Console.WriteLine(toFirst);
    }

    /// <summary>
    /// Range operator ..
    /// </summary>
    private static void SampleRange()
    {
        int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        int start = 1;
        int amountToTake = 3;
        Console.WriteLine(string.Join(", ", numbers[start..(start + amountToTake)]));

        // Old way to do so - seems it is easy readable!!!
        Console.WriteLine(string.Join(", ", numbers.Skip(start).Take(amountToTake)));
    }

    /// <summary>
    /// Range operator ..
    /// </summary>
    private static void SampleMargin()
    {
        int[] numbers = [0, 10, 20, 30, 40, 50];
        int margin = 1;
        int[] inner = numbers[margin..^margin];
        Console.WriteLine(string.Join(", ", inner));
    }

    /// <summary>
    /// Range operator ..
    /// </summary>
    private static void SampleIndexExpression()
    {
        string line = "One Two Three Four Five";
        int amountToTakeFromEnd = 4;
        Range endIndices = ^amountToTakeFromEnd..^0;
        Console.WriteLine(string.Join(", ", line[endIndices]));
    }

    /// <summary>
    /// The following example demonstrates the effect of using all the ranges presented in the preceding table:
    /// </summary>
    private static void SampleAllRangesFromReadmeTable()
    {
        Console.WriteLine("The following example demonstrates the effect of using all the ranges presented in the preceding table:");
        int[] oneThroughTen = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        Write(oneThroughTen, ..);
        Write(oneThroughTen, ..3);
        Write(oneThroughTen, 2..);
        Write(oneThroughTen, 3..5);
        Write(oneThroughTen, ^2..);
        Write(oneThroughTen, ..^3);
        Write(oneThroughTen, 3..^4);
        Write(oneThroughTen, ^4..^2);
        static void Write(int[] values, Range range) =>
            Console.WriteLine($"{range}:\t{string.Join(", ", values[range])}");
    }
}