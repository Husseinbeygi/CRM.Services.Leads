namespace Domain.Test.Aggregates.Leads.ValueObjects;

public class LeadSourceUnitTest
{
	[Theory]
	[InlineData(null)]
	[InlineData(100)]
	public void ShouldReturnErrorWhenValueIsInvalid(int? @value)
	{
		var result = () =>
			Domain.Aggregates.Leads.ValueObjects.LeadSource.GetByValue(value: @value);


		result.Should().Throw<Exception>();
	}

	[Fact]
	public void ShouldReturnValueThenInputIsValid()
	{
		var result =
			Domain.SharedKernel.Salutation.GetByValue(value: 1);

		result.Value.Should()
		.Be(Domain.Aggregates.Leads.ValueObjects.LeadSource.Advertisement.Value);

	}


}
