using FluentValidation;
using FluentValidation.Results;
using System.Text;
using WordFinder.Domain.CustomExceptions;

namespace WordFinder.Domain;

/// <summary>
/// Validator to check matrix consistency with business rules.
/// </summary>
public class MatrixValidator : AbstractValidator<IEnumerable<string>>
{
	/// <summary>
	/// Creates a valid <see cref="MatrixValidator"/> instance.
	/// </summary>
	public MatrixValidator()
	{
		RuleFor(x => x.Count())
			.Must(items => items <= 64)
			.WithMessage((_, count) => $"Max vertical size for matrix must be 64. Actual size {count}");

		RuleFor(x => x)
			.Must(x => x.Any())
			.WithMessage("Matrix can not me empty");

		RuleFor(x => x)
			.Must(items =>
			{
				var length = items.ElementAt(0).Length;
				return items.All(inlineStream => inlineStream.Length == length) && items.Count() == length;
			})
			.WithMessage("All items must contains the same number of character")
			.When(x => x.Any());

		RuleForEach(x => x)
			.Must(word => word.Length <= 64)
			.WithMessage((_, word) => $"Word {word} exceeds length 64. Actual length {word.Length}");
	}

	/// <inheritdoc />
	/// <exception cref="MatrixValidationException"></exception>
	protected override void RaiseValidationException(ValidationContext<IEnumerable<string>> context, ValidationResult result)
	{
		var messageBuilder = new StringBuilder("Matrix validation errors: " + Environment.NewLine);
		foreach (var error in result.Errors)
		{
			messageBuilder.AppendLine(error.ErrorMessage);
		}

		throw new MatrixValidationException(context.InstanceToValidate, messageBuilder.ToString());
	}
}
