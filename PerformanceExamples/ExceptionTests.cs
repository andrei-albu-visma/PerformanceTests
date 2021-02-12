using System;
using BenchmarkDotNet.Attributes;

namespace PerformanceExamples
{
    [MemoryDiagnoser]
    public class ExceptionTests
    {
        private const int iterationCount = 100000;

        [Benchmark]
        public void MeasureIntegerIncrementNoException()
        {
            var count = 0;

            for(int i = 0; i < iterationCount; i++)
            {
                count += 1;
            }
        }

        [Benchmark]
        public void MeasureIntegerIncrementThrowException()
        {
            var count = 0;

            for (int i = 0; i < iterationCount; i++)
            {
                try
                {
                    count += 1;
                    throw new InvalidOperationException();
                }
                catch (InvalidOperationException)
                {

                }
            }
        }
    }
}
