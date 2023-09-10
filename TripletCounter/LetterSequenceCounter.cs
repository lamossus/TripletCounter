using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TripletCounter
{
	internal class LetterSequenceCounter
	{
		public int SequenceLength { get; set; } = 3;
		public bool IgnoreCase { get; set; } = false;

		public LetterSequenceCounter() { }

		public IReadOnlyDictionary<string, int> CountSequences(string text)
		{
			if (IgnoreCase)
				text = text.ToLower();

			ConcurrentDictionary<string, int> sequenceCounts = new();
			var words = Regex.Matches(text, @"\p{L}+");

			Parallel.ForEach(words, (word, index) =>
			{
				Parallel.For(0, word.Length - SequenceLength + 1, (i) =>
				{
					var sequence = word.Value.Substring(i, SequenceLength);
                    sequenceCounts.AddOrUpdate(sequence, 1, (_, val) => (val + 1));
				});
			});

			return sequenceCounts;
		}
	}
}
