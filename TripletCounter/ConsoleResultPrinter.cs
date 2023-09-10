using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripletCounter
{
	internal class ConsoleResultPrinter
	{
		public void PrintResults(IList<KeyValuePair<string, int>> results, TimeSpan? time = null)
		{
			Console.WriteLine("Результаты работы счётчика: ");
			foreach (var result in results)
				Console.WriteLine($"{result.Key}:	{result.Value}");
			if (time != null)
				Console.WriteLine($"Время работы счётчика: {time.Value.Milliseconds}мс");
        }
	}
}
