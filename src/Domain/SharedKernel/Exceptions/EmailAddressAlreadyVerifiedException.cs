namespace Domain.SharedKernel.Exceptions;

public class EmailAddressAlreadyVerifiedException : Exception
{
	public EmailAddressAlreadyVerifiedException(EmailAddress? emailAddress) :
		base(string.Format(Resources.Messages.Errors.EmailAddressAlreadyVerified,emailAddress?.Value))
	{
	}
}
