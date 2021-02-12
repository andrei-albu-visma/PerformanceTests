using BenchmarkDotNet.Attributes;

namespace PerformanceExamples
{
    [MemoryDiagnoser]
    public class BoxingUnboxingTests
    {
        private const int iterationCount = 1000000;

        [Benchmark]
        public void MeasureIntegerAdd()
        {
            int a = 1;
            for (int i = 0; i < iterationCount; i++)
            {
                a += 1;
            }
        }

        [Benchmark]
        public void MeasureBoxedIntegerAdd()
        {
            object a = 1;
            for (int i = 0; i < iterationCount; i++)
            {
                a = (int)a + 1;
            }
        }
    }
}
