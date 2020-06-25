using BenchmarkDotNet.Running;
using System;
using System.Buffers;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Warandpeace
{
    public class Program
    {
        //static void Main(string[] args)
        //{
        //    var text = File.ReadAllText("warandpeace.txt");
        //    var parser = new Parser6();
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        parser.GetMostCommonWord2(text);
        //    }

        //    Console.ReadKey();
        //}

        static void Main(string[] args) => _ = BenchmarkRunner.Run<WarandpeaceBenchmarks>();
    }

    [MemoryDiagnoser]
    public class WarandpeaceBenchmarks
    {
        private string text;

        [GlobalSetup]
        public void Setup()
        {
            text = File.ReadAllText("warandpeace.txt");
        }

        [Benchmark(Baseline = true)]
        public void Original()
        {
            var parser = new Parser1();
            parser.GetMostCommonWord(text);
        }

        //[Benchmark]
        //public void LinqGroupBy()
        //{
        //    var word = text.Split(',', ' ', '.', ':', ';', '-', '\r', '\n')
        //        .Where(x => !string.IsNullOrEmpty(x))
        //        .GroupBy(x => x.ToLower(CultureInfo.CurrentCulture))
        //        .OrderByDescending(x => x.Count())
        //        .First();
        //}

        [Benchmark]
        public void Optimised()
        {
            var parser = new Parser2();
            parser.GetMostCommonWord(text);
        }

        //[Benchmark]
        //public void OptimisedV2()
        //{
        //    var parser = new Parser3();
        //    parser.GetMostCommonWord(text);
        //}

        //[Benchmark]
        //public void OptimisedV3()
        //{
        //    var parser = new Parser4();
        //    parser.GetMostCommonWord(text);
        //}

        [Benchmark]
        public void OptimisedV4()
        {
            var parser = new Parser6();
            parser.GetMostCommonWord2(text);
        }
    }
}
