using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTests
{
	public class HealthCheckTests : IClassFixture<WebApplicationFactory<Program>>
	{
		public HealthCheckTests(WebApplicationFactory<Program> factory)
		{
			Client = factory.CreateClient();
		}

		public HttpClient Client { get; }

		[Fact]
		public async Task ShouldReturnOkStatusWhenApiIsHealthy()
		{
			var res = await Client.GetAsync("/healthcheck");

			res.IsSuccessStatusCode.Should().BeTrue();
		}
	}
}