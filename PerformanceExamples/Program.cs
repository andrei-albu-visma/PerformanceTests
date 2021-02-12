using BenchmarkDotNet.Running;
using System;

namespace PerformanceExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = BenchmarkRunner.Run<StringConcatenationTests>();

             // _ = BenchmarkRunner.Run<CollectionTests>();
             // _ = BenchmarkRunner.Run<ExceptionTests>();
            _//  = BenchmarkRunner.Run<TryParseTests>();
             // _ = BenchmarkRunner.Run<BoxingUnboxingTests>();

            BoxingUnboxingExample();
            Console.Read();
        }

        private static void BoxingUnboxingExample()
        {
            int a = 123;
            object b = a;
            int c = (int)b;

            Console.WriteLine(c);
        }
    }
}
