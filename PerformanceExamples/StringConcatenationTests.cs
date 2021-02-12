using System.Text;
using BenchmarkDotNet.Attributes;

namespace PerformanceExamples
{
    [MemoryDiagnoser]
    public class StringConcatenationTests
    {
        private const int iterationCount = 100000;

        [Benchmark]
        public void MeasureStringConcatenation()
        {
            var stringToConcatenate = string.Empty;

            for (int i = 0; i < iterationCount; i++)
            {
                stringToConcatenate = stringToConcatenate + "a";
            }
        }

        [Benchmark]
        public void MeasureStringInterpolation()
        {
            var stringToConcatenate = string.Empty;

            for (int i = 0; i < iterationCount; i++)
            {
                stringToConcatenate = $"{stringToConcatenate}a";
            }
        }

        [Benchmark]
        public void MeasureStringConcatenationStringBuilder()
        {
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < iterationCount; i++)
            {
                stringBuilder.Append("a");
            }
        }
    }
}
