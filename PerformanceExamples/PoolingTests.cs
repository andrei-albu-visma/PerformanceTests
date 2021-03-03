using System.Buffers;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace PerformanceExamples
{
    [MemoryDiagnoser]
    public class PoolingTests
    {
        private const int iterationCount = 100000;

        [Benchmark]
        public void MeasureGenericIntegerListAdd()
        {
            var list = new List<int>();

            for (int i = 0; i < iterationCount; i++)
            {
                list.Add(i);
            }
        }

        [Benchmark]
        public void MeasureIntegerArray()
        {
            var list = new int[iterationCount];

            for (int i = 0; i < iterationCount; i++)
            {
                list[i] = i;
            }
        }

        [Benchmark]
        public void MeasureSharedIntegerArrayAdd()
        {
            var pool = ArrayPool<int>.Shared;
            int[] buffer = pool.Rent(iterationCount);

            for (int i = 0; i < iterationCount; i++)
            {
                buffer[i] = i;
            }

            pool.Return(buffer);
        }
    }
}
