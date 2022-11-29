using FluentAssertions;
using IntegrationTests.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace IntegrationTests;

public class LeadsControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
	public LeadsControllerTests(WebApplicationFactory<Program> factory)
	{
		Client = factory.CreateClient(new WebApplicationFactoryClientOptions
		{
			BaseAddress = new Uri("https://localhost:7281/api/v1/")
		});
	}

	public HttpClient Client { get; }

	[Fact]
	public async Task ShouldReturnOkWhenRequestToGetAllLeads()
	{
		var res = await Client.GetAsync("Leads");

		res.EnsureSuccessStatusCode();

	}

	[Fact]
	public async Task ShouldReturnProperMediaTypeWhenRequestToGetAllLeads()
	{
		var res = await Client.GetAsync("Leads");

		res.Content.Headers.ContentType?.MediaType.Should().Be("application/json");
	}

	[Fact]
	public async Task ShouldReturnProperContentWhenRequestToGetAllLeads()
	{
		var res = await Client.GetFromJsonAsync<Models.LeadResponse>("Leads");

		res.Should().NotBeNull();
		(res.data.Where(x => x.id == Guid.Empty)).Should().BeNullOrEmpty();
	}

	[Fact]
	public async Task ShouldReturnOkWhenRequestToGetALead()
	{
		var Lead = await Client.GetFromJsonAsync<Models.LeadResponse>("Leads");

		Lead.Should().NotBeNull();

		var id = Lead?.data.First().id;

		var res = await Client.GetAsync($"Leads/{id}");

		res.EnsureSuccessStatusCode();
	}

	[Fact]
	public async Task ShouldCreateLeadWhenValidationIsOk()
	{
		var jsonBody = System.Text.Json.JsonSerializer.Serialize(new Leads
		{
			lastName = "LastNameTests",
			company = "ComponyTests",
			tenantId = Guid.NewGuid().ToString(),
			salutaion = new ValueObject { value = 0 },
			industry = new ValueObject { value = 0 },
			rating = new ValueObject { value = 0 },
			leadSource = new ValueObject { value = 0 },
			leadStatus = new ValueObject { value = 0 }
		});

		StringContent httpContent = new(jsonBody, System.Text.Encoding.UTF8, "application/json");

		var post = await Client.PostAsync("Leads", httpContent);

		var res = await post.Content.ReadAsStringAsync();

		post.EnsureSuccessStatusCode();
	}

}
