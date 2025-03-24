namespace WordFinder.Domain.CustomExceptions;

/// <summary>
/// Custom exception used when matrix configuration is invalid.
/// </summary>
/// <param name="matrix">Invalid matrix</param>
/// <param name="message">Error message</param>
public class MatrixValidationException(IEnumerable<string> matrix, string message) : Exception(message)
{
	/// <summary>
	/// Contains the invalid matrix.
	/// </summary>
	public IEnumerable<string> Matrix { get; } = matrix;
}
