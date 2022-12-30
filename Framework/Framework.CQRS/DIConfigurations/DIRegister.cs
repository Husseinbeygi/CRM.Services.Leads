using Microsoft.Extensions.DependencyInjection;

namespace Framework.CQRS.DIConfigurations
{
	public static class DIRegister
	{
		public static IServiceCollection AddCQRS(this IServiceCollection services)
		{
			return services;
		}
	}
}
