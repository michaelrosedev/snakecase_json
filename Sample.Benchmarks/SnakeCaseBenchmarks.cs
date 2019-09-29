using BenchmarkDotNet.Attributes;
using Sample.Serialization;

namespace Sample.Benchmarks
{
    [RankColumn]
    [MemoryDiagnoser]
    public class SnakeCaseBenchmarks
    {
        private const string Input = "ThisIsAString";

        [Benchmark] 
        public string ToSnakeCaseOriginal() => Input.ToSnakeCaseNoSpan();

        [Benchmark]
        public string ToSnakeCase() => Input.ToSnakeCase();

        [Benchmark]
        public string ToSnakeCaseCharLower() => Input.ToSnakeCaseAsSpan();
    }
}