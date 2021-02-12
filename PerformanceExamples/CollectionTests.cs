using System.Collections;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace PerformanceExamples
{
    [MemoryDiagnoser]
    public class CollectionTests
    {
        private const int iterationCount = 1000000;

        [Benchmark]
        public void MeasureArrayListAdd()
        {
            var list = new ArrayList();

            for (int i = 0; i < iterationCount; i++)
            {
                list.Add(i);
            }
        }

        [Benchmark]
        public void MeasureGenericIntegerList()
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
    }
}
