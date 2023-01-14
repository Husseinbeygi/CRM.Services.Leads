using Cyrus.CQRS.Contracts;
using Domain.Aggregates.Leads.Events;
using MassTransit;

namespace Application.Leads.Events;

public class LeadCreatedEventHandler : IEventHandlerAsync<LeadCreatedEvent>
{
	private readonly IBus _bus;

	public LeadCreatedEventHandler(IBus Bus)
	{
		_bus = Bus;
	}


	public async Task HandleAsync(LeadCreatedEvent @event, CancellationToken cancellationToken = default)
	{
			await _bus.Publish(new LeadCreatedEvent(@event.Id), cancellationToken);
	}
}
