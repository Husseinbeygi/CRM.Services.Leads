namespace Domain.SharedKernel.Exceptions;

internal class EmailAddressAlreadyVerifiedException : Exception
{
	public EmailAddressAlreadyVerifiedException(EmailAddress? emailAddress) :
		base(string.Format(Resources.Messages.Errors.EmailAddressAlreadyVerified,emailAddress?.Value))
	{
	}
}
