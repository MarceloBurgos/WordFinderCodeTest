using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WordFinder.Api.Middlewares;

/// <summary>
/// Global exception handler for application.
/// </summary>
public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
	/// <inheritdoc />
	public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
	{
		var reference = $"Error during '{httpContext.Request.Method}{httpContext.Request.Path}' execution";

		var problemDetails = new ProblemDetails
		{
			Type = $"Exception type '{exception.GetType().Name}'",
			Instance = $"Method: {httpContext.Request.Method}. Path: {httpContext.Request.Path}",
			Title = reference
		};

		switch (exception)
		{
			default:
				problemDetails.Detail = $"Unexpected exception occurs. {exception.Message}";
				problemDetails.Status = (int)HttpStatusCode.InternalServerError;

				httpContext.Response.StatusCode = problemDetails.Status.Value;
				httpContext.Response.ContentType = "application/json";
				await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

				logger.LogCritical(exception, "Unexpected exception occurs. {message}", exception.Message);
				break;
		}

		return true;
	}
}
