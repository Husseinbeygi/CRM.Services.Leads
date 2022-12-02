namespace Domain.SharedKernel.Exceptions
{
	public class InvalidLengthException : Exception
	{
		public InvalidLengthException(string? message) : base(message)
		{
		}
	}
}
