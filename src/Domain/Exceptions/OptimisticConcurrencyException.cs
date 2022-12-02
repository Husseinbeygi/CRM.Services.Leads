namespace Domain.Exceptions;

internal class OptimisticConcurrencyException : Exception
{
	public OptimisticConcurrencyException() : base(Resources.Messages.Errors.OptimisticConcurrencyException)
	{
	}
}
