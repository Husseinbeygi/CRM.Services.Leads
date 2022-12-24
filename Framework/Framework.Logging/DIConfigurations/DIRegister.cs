using Framework.Logging.Adapter;
using Framework.Logging.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Logging.DIConfigurations;

public static class DIRegister
{
	public static IServiceCollection 
	AddNLogServer(this IServiceCollection services)
	{
		services.AddTransient
		   (serviceType: typeof(ILogger<>),
		   implementationType: typeof(NLogAdapter<>));

		return services;

	}
}
