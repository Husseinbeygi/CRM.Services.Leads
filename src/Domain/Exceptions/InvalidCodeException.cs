namespace Domain.SharedKernel.Exceptions;

public class InvalidCodeException : Exception
{
	public InvalidCodeException(string? message) : base(message)
	{
	}
}
