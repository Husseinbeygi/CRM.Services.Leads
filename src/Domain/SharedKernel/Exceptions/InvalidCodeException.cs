namespace Domain.SharedKernel.Exceptions;

internal class InvalidCodeException : Exception
{
	public InvalidCodeException(string? message) : base(message)
	{
	}
}
