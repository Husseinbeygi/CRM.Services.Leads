namespace Domain.Test.Aggregates.Leads.ValueObjects;

public class IndustryUnitTest
{
	[Theory]
	[InlineData(null)]
	[InlineData(100)]
	public void ShouldReturnErrorWhenValueIsInvalid(int? @value)
	{
		var result = () =>
			Domain.Aggregates.Leads.ValueObjects.Industry.GetByValue(value: @value);


		result.Should().Throw<Exception>();
	}

	[Fact]
	public void ShouldReturnValueThenInputIsValid()
	{
		var result =
			Domain.SharedKernel.Salutation.GetByValue(value: 0);

		result.Value.Should()
		.Be(Domain.Aggregates.Leads.ValueObjects.Industry.Agriculture.Value);

	}

}
