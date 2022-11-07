
using Xunit.Sdk;

namespace Domain.Test.SharedKernel
{
	public class MobilePhoneUnitTest : object
	{
		public MobilePhoneUnitTest() : base()
		{
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("        ")]
		public void ShouldReturnErrorWhenMobilePhoneIsNullOrEmpty(string mobile)
		{
			Action result  = () =>	
				Domain.SharedKernel.MobilePhone.Create(value: mobile);


			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Mobile);

			result.Should()
				.Throw<ArgumentNullOrEmptyException>()
				.WithMessage(errorMessage);
		}

		[Theory]
		[InlineData("  12345  ")]
		[InlineData("  123451234512345  ")]
		public void ShouldReturnErrorWhenLengthIsInvalid(string mobile)
		{
			Action result = () =>
						Domain.SharedKernel.MobilePhone.Create(value: mobile);

			string errorMessage = string.Format
				(Resources.Messages.Validations.FixLengthNumeric,
				Resources.DataDictionary.Mobile, Domain.SharedKernel.MobilePhone.FixLength);

			result.Should().Throw<InvalidLengthException>();
		}

		[Theory]
		[InlineData("09121087461")]
		[InlineData("  09121087461  ")]
		public void ShouldReturnSuccessWhenMobileNumberIsValid(string mobile)
		{
			var result =
				Domain.SharedKernel.MobilePhone.Create(value: mobile);

			result.Value.Should().Be("09121087461");
		}

		[Fact]
		public void ShouldReturnSuccessIfMobileNumberIsVerifiedSuccessfully()
		{
			var MobilePhoneNumber =
				Domain.SharedKernel.MobilePhone.Create(value: "  09121087461  ");

			var act = () => MobilePhoneNumber.VerifyByKey(MobilePhoneNumber.VerificationKey);

			act.Should().NotThrow<Exception>();
		}

		[Xunit.Fact]
		public void ShouldReturnErrorIfMobileNumberIsAlreadyVerified()
		{
			var result =
				Domain.SharedKernel.MobilePhone.Create(value: "  09121087461  ");


			var Newobj = result.VerifyByKey(result.VerificationKey);
			var act = () => Newobj.VerifyByKey(result.VerificationKey);


			act.Should().Throw<MobilePhoneAlreadyVerifiedException>();
		}
	}
}
