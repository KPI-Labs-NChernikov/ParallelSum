namespace ParallelSum;

public static class SimpleParallelSum
{
    // Very bad performance.
    public static long Sum(long[] numbers)
    {
        var sum = 0L;
        Parallel.For(0, numbers.Length, i =>
        {
            Interlocked.Add(ref sum, numbers[i]);
        });
        return sum;
    }
}
