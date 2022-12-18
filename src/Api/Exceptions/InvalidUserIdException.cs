namespace Api.Exceptions
{
	public class InvalidUserIdException : Exception
	{
		public InvalidUserIdException() : base("The UserId in Context is Invalid")
		{
		}
		public InvalidUserIdException(string message, System.Exception? innerException)
			: base(message: message, innerException: innerException)
		{
		}

	}
}
