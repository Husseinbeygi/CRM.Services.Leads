using Microsoft.AspNetCore.Builder;

namespace Api.Infrustructure.Middlewares
{
	/// <summary>
	/// 
	/// </summary>
	public static class MyMiddlewareExtensions
	{
		/// <summary>
		/// 
		/// </summary>
		static MyMiddlewareExtensions()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="builder"></param>
		/// <returns></returns>
		public static IApplicationBuilder
			UseExceptionHandling(this IApplicationBuilder builder)
		{
			// UseMiddleware -> using Microsoft.AspNetCore.Builder;
			return builder.UseMiddleware<ExceptionHandlingMiddleware>();
		}
	}
}
