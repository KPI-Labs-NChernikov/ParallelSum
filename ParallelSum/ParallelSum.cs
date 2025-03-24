namespace ParallelSum;

public static class ParallelSum
{
    public static long Sum(long[] numbers)
    {
        var processors = Environment.ProcessorCount;
        var processorsToUse = processors <= numbers.Length ? processors : numbers.Length;
        
        var sum = 0L;
        var step = (long)Math.Ceiling((double)numbers.Length / processorsToUse);
        Parallel.For(0, processorsToUse, i =>
        {
            var start = i * step;
            var end = (i + 1) * step;
            if (end > numbers.Length)
            {
                end = numbers.Length;
            }
            var partialSum = 0L;
            for (var j = start; j < end; j++)
            {
                partialSum += numbers[j];
            }
            
            Interlocked.Add(ref sum, partialSum);
        });
        
        return sum;
    }
}
