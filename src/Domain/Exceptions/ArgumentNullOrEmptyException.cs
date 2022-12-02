namespace Domain.SharedKernel.Exceptions;

public class ArgumentNullOrEmptyException : Exception
{
	public ArgumentNullOrEmptyException(string? message) : base(message)
	{
	}
}
