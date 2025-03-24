namespace WordFinder.Domain.CustomExceptions;

public class MatrixValidationException(IEnumerable<string> matrix, string message) : Exception(message)
{
	public IEnumerable<string> Matrix { get; } = matrix;
}
