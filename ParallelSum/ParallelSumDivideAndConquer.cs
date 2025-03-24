namespace ParallelSum;

public static class ParallelSumDivideAndConquer
{
    public static long Sum(long[] numbers)
    {
        var processors = Environment.ProcessorCount;
        return SumPartition(numbers, 0, numbers.Length, processors);
    }

    private static long SumPartition(long[] numbers, int low, int high, int processorsCount)
    {
        if (high - low == 1)
        {
            return numbers[low];
        }
        if (processorsCount == 1)
        {
            return SequentialSum(numbers, low, high);
        }
        
        var mid = (low + high) / 2 + (low + high) % 2;

        var leftSum = 0L;
        var rightSum = 0L;
        
        Parallel.Invoke(
            () => leftSum = SumPartition(numbers, low, mid, processorsCount / 2),
            () => rightSum = SumPartition(numbers, mid, high, processorsCount / 2 + processorsCount % 2));
        
        return leftSum + rightSum;
    }

    private static long SequentialSum(long[] numbers, int low, int high)
    {
        var sum = 0L;
        for (var i = low; i < high; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }
}
