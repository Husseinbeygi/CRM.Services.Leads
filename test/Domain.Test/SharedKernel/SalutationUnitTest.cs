namespace Domain.Test.SharedKernel;

public class SalutationUnitTest
{
	[Theory]
	[InlineData(null)]
	[InlineData(100)]
	public void ShouldReturnErrorWhenValueIsInvalid(int? @value)
	{
		var result = () =>
			Domain.SharedKernel.Salutation.GetByValue(value: @value);


		result.Should().Throw<Exception>();
	}

	[Fact]
	public void ShouldReturnValueThenInputIsValid()
	{
		var result =
			Domain.SharedKernel.Salutation.GetByValue(value: 0);

		result.Value.Should()
		.Be(Domain.SharedKernel.Salutation.Mr.Value);

	}
}
