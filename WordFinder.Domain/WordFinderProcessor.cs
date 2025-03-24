using FluentValidation;
using System.Text;

namespace WordFinder.Domain;

/// <summary>
/// Define the process to find a word in a defined matrix.
/// </summary>
public class WordFinderProcessor
{
	/// <summary>
	/// Creates a valid <see cref="WordFinderProcessor"/> instance.
	/// </summary>
	/// <param name="matrix"></param>
	public WordFinderProcessor(IEnumerable<string> matrix)
	{
		var validator = new MatrixValidator();
		validator.ValidateAndThrow(matrix);

		_matrix = matrix;
	}

	/// <summary>
	/// Finds any word in matrix using <paramref name="wordStream"/> as parameter.
	/// </summary>
	/// <param name="wordStream">Words to find in the matrix</param>
	/// <returns>
	/// Returns the words found.
	/// </returns>
	public IEnumerable<string> Find(IEnumerable<string> wordStream)
	{
		foreach (var word in wordStream)
		{
			for (var row = 0; row < _matrix.Count(); row++)
			{
				var rowStream = _matrix.ElementAt(row);
				FindOccurrences(word, rowStream);
			}

			for (var column = 0; column < _matrix.Count(); column++)
			{
				var rowIndex = 0;
				var columnStream = new StringBuilder();

				while (rowIndex < _matrix.Count())
				{
					columnStream.Append(_matrix.ElementAt(rowIndex)[column]);
					rowIndex++;
				}

				FindOccurrences(word, columnStream.ToString());
			}
		}

		var wordsFounded = from word in _wordsSearched
						   where word.Value > 0
						   orderby word.Value descending
						   select word.Key;

		return wordsFounded.Take(10);
	}

	/// <summary>
	/// Finds occurrences for <paramref name="word"/> in a character <paramref name="row"/> using <see cref="string.IndexOfAny(char[], int)"/> to match string.
	/// </summary>
	/// <param name="word">Word to found</param>
	/// <param name="row">Stream where to search</param>
	private void FindOccurrences(string word, string row)
	{
		int occurrences = 0;
		int rowIndex = 0;

		while ((rowIndex = row.IndexOf(word, rowIndex)) != -1)
		{
			occurrences++;
			rowIndex += word.Length;
		}

		if (_wordsSearched.ContainsKey(word))
		{
			_wordsSearched[word] += occurrences;
		}
		else
		{
			_wordsSearched[word] = occurrences;
		}
	}

	private readonly IEnumerable<string> _matrix;
	private readonly Dictionary<string, int> _wordsSearched = [];
}
