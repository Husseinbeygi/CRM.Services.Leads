using FluentAssertions;

namespace Domain.Test.SharedKernel
{
	public class EmailAddressUnitTest : object
	{
		public EmailAddressUnitTest() : base()
		{
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("    ")]
		public void ShouldReturnErrorWhenEmailAddressIsNullOrEmpty(string email)
		{
			var result = () =>
				Domain.SharedKernel.EmailAddress.Create(value: email);

			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.EmailAddress);

			result.Should()
			.Throw<ArgumentNullOrEmptyException>()
			.WithMessage(errorMessage);
		}

		[Theory]
		[InlineData("abcde")]
		[InlineData("abcde@")]
		[InlineData("@abcde")]
		[InlineData("abcde.com")]
		public void ShouldReturnErrorWhenEmailAddressIsInvalid(string email)
		{
			var result = () =>
				Domain.SharedKernel.EmailAddress.Create(value: email);

			string errorMessage = string.Format
				(Resources.Messages.Validations.RegularExpression, Resources.DataDictionary.EmailAddress);

			result.Should()
			.Throw<InvalidEmailFormatException>()
			.WithMessage(errorMessage);
		}

		[Xunit.Fact]
		public void ShouldReturnErrorWhenEmailAddressLengthExceeded()
		{

			string value = string.Empty;

			for (int index = 1; index <= Domain.SharedKernel.EmailAddress.MaxLength + 1; index++)
			{
				value += "a";
			}


			var result = () =>
				Domain.SharedKernel.EmailAddress.Create(value: value);


			string errorMessage = string.Format
				(Resources.Messages.Validations.MaxLength,
				Resources.DataDictionary.EmailAddress,
				Domain.SharedKernel.EmailAddress.MaxLength);

			result.Should()
				.Throw<InvalidLengthException>()
				.WithMessage(errorMessage);
		}


		[Theory]
		[InlineData("DariushT@GMail.com")]
		[InlineData("   DariushT@GMail.com   ")]
		public void ShouldCreateEmailWhenEverythingOkey(string value)
		{
			var result =
				Domain.SharedKernel.EmailAddress.Create(value: value);

			result.Value
				.Should().Be("DariushT@GMail.com");
		}


		[Xunit.Fact]
		public void ShouldCreateVerficationKeyWhenEmailCreated()
		{
			var result =
				Domain.SharedKernel.EmailAddress.Create(value: "  DariushT@GMail.com  ");

			result.Value.Should().Be("DariushT@GMail.com");
			result.VerificationKey.Should().NotBeNullOrWhiteSpace();
		}

		[Xunit.Fact]
		public void ShouldVerfiyEmailByVerificationKey()
		{
			var result =
				Domain.SharedKernel.EmailAddress.Create(value: "  DariushT@GMail.com  ");

			var emailAddressObject = result;

			var emailAddress = emailAddressObject;
			var verificationKey = emailAddressObject.VerificationKey;

			var newEmailAddressObject = () =>
				emailAddressObject.VerifyByKey(verificationKey);

			newEmailAddressObject.Should().NotThrow<Exception>();
		}

		[Xunit.Fact]
		public void ShouldThrowExceptionWhenEmailAlreadyVerified()
		{
			var result =
				Domain.SharedKernel.EmailAddress.Create(value: "  DariushT@GMail.com  ");

			var emailAddressObject = result;

			var newResult =
				emailAddressObject.Verify();

			var newNewResult = () =>
				newResult.Verify();

			newNewResult.Should().Throw<EmailAddressAlreadyVerifiedException>();
		}

	}
}
