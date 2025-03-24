using System.Diagnostics;

var arr = new long[1000000000];
Parallel.For(0, arr.Length, i =>
{
    arr[i] = Random.Shared.NextInt64(1000);
});
Console.WriteLine($"Checksum: {arr.Sum()}");

Console.WriteLine("Example:");
var sw = Stopwatch.StartNew();
Console.WriteLine(ParallelSum.ParallelSum.Sum(arr));
sw.Stop();
Console.WriteLine(sw.Elapsed);
Console.WriteLine();

sw.Restart();
Console.WriteLine($"Parallel sum (divide and conquer): {ParallelSum.ParallelSumDivideAndConquer.Sum(arr)}");
sw.Stop();
Console.WriteLine($"Parallel sum (divide and conquer): {sw.Elapsed}");
Console.WriteLine();

sw.Restart();
Console.WriteLine($"Parallel sum: {ParallelSum.ParallelSum.Sum(arr)}");        // Looks like the best algorithm for this problem.
sw.Stop();
Console.WriteLine($"Parallel sum: {sw.Elapsed}");
Console.WriteLine();

sw.Restart();
Console.WriteLine($"PLINQ: {arr.AsParallel().Sum()}");                  // A bit slower than manual implementations, but good.
sw.Stop();
Console.WriteLine($"PLINQ: {sw.Elapsed}");
Console.WriteLine();

sw.Restart();
Console.WriteLine($"Simple sum: {ParallelSum.SimpleParallelSum.Sum(arr)}");        // Even slower than non-parallel LINQ.
                                                                                   // Do not use this.
sw.Stop();
Console.WriteLine($"Simple sum: {sw.Elapsed}");
