using Framework.CQRS;

namespace Api.Infrustructure
{
	/// <summary>
	/// 
	/// </summary>
	[Microsoft.AspNetCore.Mvc.ApiController]

	[Microsoft.AspNetCore.Mvc.Route
		(template: Constants.Routing.Controller)]
	public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="unitOfWork"></param>
		public IMessages Messages { get; set; }

		public ControllerBase(IMessages Messages)
		{
			this.Messages = Messages;
		}

	}
}
