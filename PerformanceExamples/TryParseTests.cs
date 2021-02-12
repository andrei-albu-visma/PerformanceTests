using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace PerformanceExamples
{
    [MemoryDiagnoser]
    public class TryParseTests
    {
        private const int iterationCount = 10000;
        private const int digits = 5;
        private char[] digitArray = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'X'};
        private List<string> numbers = new List<string>();

        [GlobalSetup]
        public void PrepareList()
        {
            var random = new Random();

            for(int i = 0; i < iterationCount; i++)
            {
                var stringBuilder = new StringBuilder();
                for(int j = 0; j < digits; j++)
                {
                    var index = random.Next(11);
                    stringBuilder.Append(digitArray[index]);
                }
                numbers.Add(stringBuilder.ToString());
            }
        }

        [Benchmark]
        public void MeasureIntegerParse()
        {
            for (int i = 0; i < iterationCount; i++)
            {
                try
                {
                    int.Parse(numbers[i]);
                }
                catch (FormatException)
                {

                }
            }
        }

        [Benchmark]
        public void MeasureIntegerTryParse()
        {
            for (int i = 0; i < iterationCount; i++)
            {
                int.TryParse(numbers[i], out var result);
            }
        }
    }
}
