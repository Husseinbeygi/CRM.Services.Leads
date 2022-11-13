using Domain.Aggregates.Leads.ValueObjects;
using Domain.SharedKernel;

namespace Domain.Test.Aggregates.Leads;

public class LeadUnitTest
{
	[Theory]
	[InlineData(null, null)]
	[InlineData("Beygi",null)]
	[InlineData(null, "TestComp")]
	public void ShouldThrowExceptionWhenRequiredInputIsNotValid(string Lname,string Company)
	{
		var result = () =>
			new Domain.Aggregates.Leads.Lead
			(Guid.NewGuid(),
			null,
			null, LastName.Create(Lname), null, null, null,
			company: Company, mobile: null, phone: null, rating: null, country: null, state: null, city: null, street: null, industry: null, annualRevenue: null, leadSource: null, postalCode: null
, numberOfEmployees: null, website: null, description: null);


		result.Should().Throw<Exception>();
	}

	[Theory]
	[InlineData("Beygi", "TestComp")]
	[InlineData("    Beygi       ", "        TestComp          ")]
	[InlineData("    Beygi   ", "        Test    Comp          ")]
	public void ShouldCreateUserWhenMinimumRequiredInputAreValid(string Lname, string Company)
	{
		var result = 
			new Domain.Aggregates.Leads.Lead
			(Guid.NewGuid(),
			null,
			null, LastName.Create(Lname), null, null, null,
			company: Company, mobile: null, phone: null, rating: null, country: null, state: null, city: null, street: null, industry: null, annualRevenue: null, leadSource: null, postalCode: null
, numberOfEmployees: null, website: null, description: null);


		result.LastName.Should().Be(LastName.Create("Beygi"));
		result.Company.Should().Be(Company);
	}

	[Fact]
	public void ShouldCreateUserProperly()
	{
		var result =
			new Domain.Aggregates.Leads.Lead
			(Guid.NewGuid(),
			Salutation.Mr,
			FirstName.Create("Hussein"),
			LastName.Create("beygi"),
			EmailAddress.Create("Hussein@Gmail.com"), LeadStatus.New, "CEO",
			company: "Company", mobile: "+989152020056", phone: "123456789",
			rating: Rating.Warm, country: "Iran", state: "Khorasan",
			city: "Mashhad", street: "Saba", industry: Industry.Technology, annualRevenue: 120000,
			leadSource: LeadSource.Web, postalCode: "123123123", numberOfEmployees: 0, website: "Goolds.com",
			description: "Very Good");


		result.FirstName.Value.Should().Be("Hussein");
		result.LastName.Value.Should().Be("beygi");
		result.LeadSource.Value.Should().Be(5);
		result.Rating.Value.Should().Be(1);
		result.LeadStatus.Value.Should().Be(0);
		result.Company.Should().Be("Company");
		result.Title.Should().Be("CEO");
		result.Mobile.Should().Be("+989152020056");
		result.Phone.Should().Be("123456789");
		result.AnnualRevenue.Should().Be(120000);
		result.City.Should().Be("Mashhad");
		result.Country.Should().Be("Iran");
		result.Description.Should().Be("Very Good");
		result.Industry.Value.Should().Be(24);
		result.State.Should().Be("Khorasan");
		result.NumberOfEmployees.Should().Be(0);
		result.PostalCode.Should().Be("123123123");
		result.Street.Should().Be("Saba");
		result.Website.Should().Be("Goolds.com");
		result.Email.Value.Should().Be("Hussein@Gmail.com");
		result.FullName.Salutation.Value.Should().Be(0);
		result.FullName.FirstName.Value.Should().Be("Hussein");
		result.FullName.LastName.Value.Should().Be("beygi");

	}


}
