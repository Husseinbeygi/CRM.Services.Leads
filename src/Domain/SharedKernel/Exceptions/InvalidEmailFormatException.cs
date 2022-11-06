namespace Domain.SharedKernel.Exceptions;

internal class InvalidEmailFormatException : Exception
{
	public InvalidEmailFormatException(string? message) : base(message)
	{
	}
}
