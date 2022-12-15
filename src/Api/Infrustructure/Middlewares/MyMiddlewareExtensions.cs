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
			return builder.UseMiddleware<ExceptionHandlingMiddleware>();
		}

		public static IApplicationBuilder
UseCultureHandler(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<CultureCookieHandlerMiddleware>();
		}

	}
}
