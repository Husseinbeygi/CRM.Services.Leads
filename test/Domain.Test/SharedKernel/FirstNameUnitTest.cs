namespace Domain.Test.SharedKernel
{
	public class FirstNameUnitTest : object
	{
		public FirstNameUnitTest() : base()
		{
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("        ")]
		public void ShouldThrowExceptionWhenValueIsNullOrEmpty(string value)
		{
			var result = () =>
				Domain.SharedKernel.FirstName.Create(value: value);

			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.FirstName);

			result.Should().Throw<ArgumentNullOrEmptyException>().WithMessage(errorMessage);
		}

		[Theory]
		[InlineData("ali","ali")]
		[InlineData("  Ali     Reza  ", "Ali Reza")]
		[InlineData("  Ali  Reza  ", "Ali Reza")]

		public void ShouldReturnNameWhenNoError(string value,string expected)
		{
			var result =
				Domain.SharedKernel.FirstName.Create(value: value);

			result.Value.Should().Be(expected);
		}
	}
}
