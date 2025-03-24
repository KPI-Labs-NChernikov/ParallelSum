// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

var arr = new long[1000000000];
Parallel.For(0, arr.Length, i =>
{
    arr[i] = Random.Shared.NextInt64(1000);
});
Console.WriteLine($"Checksum: {arr.Sum()}");

var sw = Stopwatch.StartNew();
Console.WriteLine(ParallelSum.ParallelSum.Sum(arr));
sw.Stop();
Console.WriteLine(sw.Elapsed);

sw.Restart();
Console.WriteLine(ParallelSum.ParallelSumDivideAndConquer.Sum(arr));
sw.Stop();
Console.WriteLine(sw.Elapsed);

sw.Restart();
Console.WriteLine(ParallelSum.ParallelSum.Sum(arr));        // Looks like the best algorithm for this problem.
sw.Stop();
Console.WriteLine(sw.Elapsed);

sw.Restart();
Console.WriteLine(ParallelSum.SimpleParallelSum.Sum(arr));        // Even slower than non-parallel LINQ.
                                                                  // Do not use this.
sw.Stop();
Console.WriteLine(sw.Elapsed);
