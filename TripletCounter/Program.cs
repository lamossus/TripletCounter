using System.Diagnostics;

namespace TripletCounter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Укажите путь к текстовому файлу в качестве параметра.");
                return;
            }
            if (!File.Exists(args[0]))
            {
                Console.WriteLine($"Не удалось найти файл {args[0]}.");
                return;
            }

            bool ignoreCase = args.Contains("-i");

            var text = File.ReadAllText(args[0]);

            var counter = new LetterSequenceCounter() { SequenceLength = 3, IgnoreCase = ignoreCase };
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var counts = counter.CountSequences(text);
            stopwatch.Stop();

            var result = counts.OrderByDescending((pair) => { return pair.Value; }).Take(10).ToList();

            var printer = new ConsoleResultPrinter();
            printer.PrintResults(result, stopwatch.Elapsed);
        }
    }
}