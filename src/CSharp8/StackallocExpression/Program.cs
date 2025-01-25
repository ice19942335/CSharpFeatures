using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace StackallocExpression;

class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<ArrayCreationApproaches>();
    }
}

[MemoryDiagnoser]
public class ArrayCreationApproaches
{
    [Benchmark]
    public int NewArray()
    {
        Span<int> span = new int[] { 1, 2 };
        
        return Math.Max(span[0], span[1]);
    }
    
    [Benchmark]
    public int Stackalloc()
    {
        Span<int> span = stackalloc int[] { 1, 2 };
        
        return Math.Max(span[0], span[1]);
    }
    
    [Benchmark]
    public int CollectionExpression()
    {
        Span<int> span = [1, 2];
        
        return Math.Max(span[0], span[1]);
    }
}