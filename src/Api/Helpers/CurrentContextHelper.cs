using Api.Exceptions;
using System.Security.Claims;

namespace Api.Helpers
{
	public class CurrentContextHelper
	{
		private readonly HttpContext context;

		public CurrentContextHelper(IHttpContextAccessor contextAccessor)
		{
			context = contextAccessor.HttpContext;
		}

		public Guid CurrentUserId
		{
			get
			{
				try
				{

					var res = Guid.Parse(context.User.Claims
								.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)
								.Value);

					if (res == null || res == Guid.Empty)
					{

						throw new InvalidUserIdException();
					}

					return res;

				}
				catch (Exception ex)
				{

					throw new InvalidUserIdException(ex.Message,ex.InnerException);
				}
			}
		}
	}
}
