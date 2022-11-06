namespace Domain.SharedKernel.Exceptions
{
	internal class MaxLengthException : Exception
	{
		public MaxLengthException(string? message) : base(message)
		{
		}
	}
}
