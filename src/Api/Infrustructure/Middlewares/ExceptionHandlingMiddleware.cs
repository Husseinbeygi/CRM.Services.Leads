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
			(HttpContext httpContext, IWebHostEnvironment hostEnvironment)
		{
			try
			{
				await Next(httpContext);
			}
			catch (Exception ex)
			{
				if (hostEnvironment.IsDevelopment())
				{
					await HandleException(httpContext.Response, ex);
				}
				else
				{
					await HandleException(httpContext.Response);
				}
			}
		}

		private static async Task HandleException
			(HttpResponse httpResponse, Exception ex)
		{
			var res = new Framework.Results.Result<string>();

			res.AddErrorMessage(ex.Message);

			httpResponse.ContentType = "application/json";

			await httpResponse
				.WriteAsync(System.Text.Json.JsonSerializer.Serialize(res)).ConfigureAwait(false);
		}

		private static async Task HandleException
			(HttpResponse httpResponse)
		{

			var res = new Framework.Results.Result<string>();

			var msg = Resources.Messages.Errors.UnexpectedError;

			res.AddErrorMessage(msg);

			httpResponse.ContentType = "application/json";

			await httpResponse
				.WriteAsync(System.Text.Json.JsonSerializer.Serialize(res)).ConfigureAwait(false);
		}
	}
}
