using FluentAssertions;
using System.Text;
using WordFinder.Domain;
using WordFinder.Domain.CustomExceptions;

namespace WordFinder.UnitTests;

[TestClass]
public class WordFinderTests
{
	[TestMethod]
	public void CreateWordFinder_WhenMatrixIsEmpty_ShouldThrowMatrixValidationException()
	{
		var exception = Assert.ThrowsException<MatrixValidationException>(() => new WordFinderProcessor([]));
		Assert.IsNotNull(exception);
		exception.Message.Should().Contain("Matrix can not me empty");

		Console.WriteLine(exception.Message);
	}

	[TestMethod]
	public void CreateWordFinder_WithDifferentStringCharacterSize_ShouldThrowMatrixValidationException()
	{
		ICollection<string> matrix = [];

		var size = 0;
		while (size != 16)
		{
			matrix.Add(GenerateRandomString(64));
			matrix.Add(GenerateRandomString(10));
			matrix.Add(GenerateRandomString(50));
			matrix.Add(GenerateRandomString(8));
			size++;
		}

		var exception = Assert.ThrowsException<MatrixValidationException>(() => new WordFinderProcessor(matrix));
		Assert.IsNotNull(exception);
		exception.Message.Should().Contain("All items must contains the same number of character");

		Console.WriteLine(exception.Message);
	}

	[TestMethod]
	public void CreateWordFinder_WithMatrixThatExceeds64HorizontalItems_ShouldThrowMatrixValidationException()
	{
		ICollection<string> matrix = [];

		var size = 0;
		while (size != 65)
		{
			matrix.Add(GenerateRandomString(65));
			size++;
		}

		var exception = Assert.ThrowsException<MatrixValidationException>(() => new WordFinderProcessor(matrix));
		Assert.IsNotNull(exception);

		for (var i = 0; i < matrix.Count; i++)
		{
			var word = matrix.ElementAt(i);
			exception.Message.Should().Contain($"Word {word} exceeds length 64. Actual length {word.Length}");
		}

		Console.WriteLine(exception.Message);
	}

	[TestMethod]
	public void CreateWordFinder_WithMatrixThatExceeds64VerticalItems_ShouldThrowMatrixValidationException()
	{
		ICollection<string> matrix = [];
		
		var size = 0;
		while (size != 65)
		{
			matrix.Add(GenerateRandomString(64));
			size++;
		}

		var exception = Assert.ThrowsException<MatrixValidationException>(() => new WordFinderProcessor(matrix));
		Assert.IsNotNull(exception);
		exception.Message.Should().Contain("Max vertical size for matrix must be 64. Actual size 65");
		
		Console.WriteLine(exception.Message);
	}

	[TestMethod]
	public void FindWords_WhenMatrixContainsMoreThan10TimesForSomeWords_ShouldReturnTop10MostRepeated()
	{
		ICollection<string> matrix =
		[
			"VhelloYchairhatEcoffeeSJcomputerVHLtableYFTOtreeJredVMblackDblue",
			"VhelloYchairhatEcoffeeSJcomputerVHLtableYFTOtreeJredVMblackDblue",
			"VhelloYchairhatEcoffeeSJcomputerVHLtableYFTOtreeJredVMblackDblue",
			"VhelloYchairhatEcoffeeSJcomputerVHLtableYFTOtreeJredVMblackDblue",
			"VhelloYchairhatEcoffeeSJcomputerVHLtableYFTOtreeJredVMblackDblue",
			"VhelloYchairhatEcoffeeSJcomputerVHLtableYFTOtreeJredVMblackDblue",
			"VhelloYchairhatEcoffeeSJcomputerVHLtableYFTOtreeJredVMblackDblue",
			"VhelloYchairhatEcoffeeSJcomputerVHLtableYFTOtreeJredVMblackDblue",
			"VhelloYchairhatEcoffeeSJcomputerVHLtableYFTOtreeJredVMblackDblue",
			"VhelloYchairhatEcoffeeSJcomputerVHLtableYFTOtreeJredVMblackDblue",
			"VhelloYYFUGKKRGEOJUXSCSJPOOQIBQVVHLQYBIUYFTOJUQSJJJUVMDVHQJDAUCG",
			"VhelloYYFUGKKRGEOvideoSJPorangeVVHLQYBIUYFTOJUQSJJJUVMDVHQJDAUCG",
			"VhelloYYFUGKKRGEOJUXSCSJPOOQIBQVVHLQYBIUYFheadsetJJUVMDVHQJDAUCG",
			"VhelloYYFUGKKRGEOJUXSCSJPOOQIBQVVHbookIUYFheadsetJJUVMDVHQJDAUCG",
			"VhelloYYFUGKKRGEOJUXSCSJPOOQIBQVVHLQYBIUYFTOJUQSJJJUVMorangeAUCG",
			"VhelloYYFUGKKRGEOJUXSCSJPOOQIBQVVHLQYBIUYFTOJorangeUVMDVHQJDAUCG",
		];

		for (var i = matrix.Count; i < 64; i++)
		{
			matrix.Add(GenerateRandomString(64));
		}

		var wordFinder = new WordFinderProcessor(matrix);
		var wordsFounded = wordFinder.Find(
		[
			"orange",
			"headset",
			"video",
			"hello", 
			"chair", 
			"hat", 
			"coffee", 
			"computer", 
			"table", 
			"tree", 
			"red", 
			"black", 
			"blue"
		]);

		Assert.IsNotNull(wordsFounded);
		wordsFounded.Should().HaveCount(10);
		wordsFounded.Should().Contain("hello");
		wordsFounded.Should().Contain("chair");
		wordsFounded.Should().Contain("hat");
		wordsFounded.Should().Contain("coffee");
		wordsFounded.Should().Contain("computer");
		wordsFounded.Should().Contain("table");
		wordsFounded.Should().Contain("tree");
		wordsFounded.Should().Contain("red");
		wordsFounded.Should().Contain("black");
		wordsFounded.Should().Contain("blue");
	}

	[TestMethod]
	public void FindWords_WhenMatrixDoesNotContainAnyWordPassed_ShouldReturnEmptySet()
	{
		ICollection<string> matrix = [];
		for (var i = 0; i < 64; i++)
		{
			matrix.Add(GenerateRandomString(64));
		}

		var wordFinder = new WordFinderProcessor(matrix);
		var wordsFounded = wordFinder.Find(["pencil", "summer", "movie", "computer", "book"]);

		Assert.IsNotNull(wordsFounded);
		wordsFounded.Should().BeEmpty();
	}

	[TestMethod]
	public void FindWords_WhenMatrixConfigurationIsValid_ShouldReturnWordsFound()
	{
		ICollection<string> matrix =
		[
			"XKSOISpencilPGNUYULTAUTCJDHXCOOWLQJBRUVZQZRZZRVUVGPOELKTLMDKRPTU",
			"XKSOISZFOHYAPGNUYULTpUTCJDHXCOOWLQJBRUVZQZRZZRVUVGPOELKTLsummerU",
			"XKSOISZFOHYAPGNUYULTrUTCJDHXCOOWLQJBeUVZQZRZZRVUVGPOELKTLMDKRPTU",
			"XKSOISZFsummerNUYULToUTCJDHXCOOWLQJBxUVZQZRZZRVUVGPOELKTLMDKRPcc",
			"XKSOISZFOHYAPaNUYULTjUTCJDHXCOOWLQJBiUVZQZRZZRVUVGPOELKTLMDKRPhh",
			"XKmOISZFOHYAPrNUYULTeUTCJDHXCOOWLQJBtUVZQZRZZRVUVGPOELKTLMDKRPaa",
			"XKoOISZFOHYAPeNUYULTcUTCJDHXCOOWLQJBRUVZQpencilUVGPOELKTLMDKRPii",
			"XKvOISZFOHYAPGNUYULTtUTCJDHXCOOWLQJBRUVZQZRZZRiUVGPOELKTLMDKRPrr",
			"XKiOISZFOHYAPGNUYULTAUTCJDHXCOOWLQJBRUVZQZRZZRfUVGPOELKTLMDKRPTU",
			"XKeOISZFOHYAPGNUYULTApencilXCOOWLQJBRUVZQZRZZReUVGPOELKTLMDKRPTU"
		];

		for (var i = matrix.Count; i < 64; i++)
		{
			matrix.Add(GenerateRandomString(64));
		}

		var wordFinder = new WordFinderProcessor(matrix);
		var wordsFounded = wordFinder.Find(["pencil", "summer", "movie", "computer", "book"]);

		Assert.IsNotNull(wordsFounded);
		wordsFounded.Should().HaveCount(3);
		wordsFounded.Should().Contain("pencil");
		wordsFounded.Should().Contain("summer");
		wordsFounded.Should().Contain("movie");
	}

	private static string GenerateRandomString(int length)
	{
		const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		var random = new Random();
		var stringBuilder = new StringBuilder(length);

		for (int i = 0; i < length; i++)
		{
			stringBuilder.Append(chars[random.Next(chars.Length)]);
		}

		return stringBuilder.ToString();
	}
}