using Api.Infrustructure.Idempotency;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace Api.Infrustructure.Middlewares
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class UseIdempotencyCheck
	{
		private readonly RequestDelegate _next;

		public UseIdempotencyCheck(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext, IdempotentInMemory idempotency)
		{
			
			var _idempotencyheader = httpContext.Request.Headers["idempotency-key"].ToString();

			if (httpContext.Request.Method.ToLower() == "post"
				&& string.IsNullOrWhiteSpace(_idempotencyheader))
			{
				await httpContext.Response.WriteAsync("idempotency-key missing");
			}

			if (httpContext.Request.Method.ToLower() == "post"
				&& !string.IsNullOrWhiteSpace(_idempotencyheader))
			{

				var isRequestExist = idempotency.CheckForRequest(_idempotencyheader);

				if (isRequestExist)
				{
					httpContext.Response.Headers.Add("Content-Type", "application/json");
					httpContext.Response.StatusCode = StatusCodes.Status208AlreadyReported;
					return;
				}

				idempotency.AddNewrequest(_idempotencyheader);
			}

			await _next(httpContext);

			if (httpContext.Request.Method.ToLower() == "post"
				&& !string.IsNullOrWhiteSpace(_idempotencyheader))
			{
				idempotency.Updaterequest(_idempotencyheader,httpContext.Response.StatusCode,"");
			}

		}

	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class UseIdempotencyCheckExtensions
	{
		public static IApplicationBuilder UseIdempotencyCheck(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<UseIdempotencyCheck>();
		}
	}
}
