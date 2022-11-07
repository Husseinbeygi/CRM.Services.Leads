namespace Domain.SharedKernel.Exceptions;

public class MobilePhoneAlreadyVerifiedException : Exception
{
	public MobilePhoneAlreadyVerifiedException() 
		: base(Resources.Messages.Errors.CellPhoneNumberAlreadyVerified)
	{
	}
}
