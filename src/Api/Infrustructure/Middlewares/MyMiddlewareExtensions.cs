using Microsoft.AspNetCore.Builder;

namespace Api.Infrustructure.Middlewares
{
	public static class MyMiddlewareExtensions
	{
		static MyMiddlewareExtensions()
		{
		}
		public static IApplicationBuilder
			UseExceptionHandling(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<UseExceptionHandlingMiddleware>();
		}

		public static IApplicationBuilder
UseCultureHandler(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<UseCultureHandlerMiddleware>();
		}


		public static IServiceCollection 
			AddIdempotentRequest(this IServiceCollection services)
		{
			return services.AddSingleton<Idempotency.IdempotentInMemory>();
		}
	}
}
