using BenchmarkDotNet.Running;

namespace Sample.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            //var strings = BenchmarkRunner.Run<SnakeCaseBenchmarks>();
            var summary = BenchmarkRunner.Run<Benchmarks>();
        }
    }
}