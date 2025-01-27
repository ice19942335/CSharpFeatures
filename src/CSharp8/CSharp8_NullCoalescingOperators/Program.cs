namespace CSharp8_NullCoalescingOperators;

class Program
{
    static void Main(string[] args)
    {
        AssignsRightHandOperandToLeftHandOperandIfLeftOperandIsNull();
        EvaluatesRightHandOperatorIfLeftHandOperatorIsNull();
    }

    private static void EvaluatesRightHandOperatorIfLeftHandOperatorIsNull()
    {
        double? nullableInt = null;
        Console.WriteLine(nullableInt ?? double.NaN); // prints right hand operand because left operand is null.
    }

    private static void AssignsRightHandOperandToLeftHandOperandIfLeftOperandIsNull()
    {
        List<int> list = null;
        list ??= [1, 2, 3]; // Left operand is null, so it is assigned from the right operand.

        foreach (var item in list)
        {
            Console.WriteLine(item);   
        }
    }
}