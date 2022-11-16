using Microsoft.AspNetCore.Http;

namespace Api.Infrustructure.Middlewares
{
	/// <summary>
	/// 
	/// </summary>
	public class ExceptionHandlingMiddleware : object
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="next"></param>
		public ExceptionHandlingMiddleware
			(RequestDelegate next) : base()
		{
			Next = next;
		}

		/// <summary>
		/// 
		/// </summary>
		protected RequestDelegate Next { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="httpContext"></param>
		/// <returns></returns>
		public async Task InvokeAsync
			(HttpContext httpContext)
		{
			try
			{
				await Next(httpContext);
			}
			catch (Exception ex)
			{
				await HandleException(httpContext.Response, ex);
			}
		}

		private static async Task HandleException
			(HttpResponse httpResponse, Exception exception)
		{
			// Log

			httpResponse.Headers.Add("Exception-Type", exception.GetType().Name);

			var feature =
				httpResponse.HttpContext.Features
				.Get<Microsoft.AspNetCore.Http.Features.IHttpResponseFeature>();

			feature.ReasonPhrase =
				"خطای ناشناخته‌ای صورت گرفته است! یا مجددا سعی نمایید و یا با تیم پشتیبانی تماس حاصل فرمایید.";

			httpResponse.StatusCode =
				(int)System.Net.HttpStatusCode.BadRequest;

			await httpResponse.WriteAsync(exception.Message).ConfigureAwait(false);
		}
	}
}
