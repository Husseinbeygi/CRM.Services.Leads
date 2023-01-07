using Domain.Aggregates.Leads.Events;
using Framework.CQRS.Contracts;

namespace Application.Leads.Events;

public class LeadCreatedEventHandler : IEventHandlerAsync<LeadCreatedEvent>
{
	public Task HandleAsync(LeadCreatedEvent @event)
	{
		Console.WriteLine("Not_1");

		
		return Task.CompletedTask;
	}
}
