using Framework.CQRS.Contracts;
using Framework.DDD;

namespace Domain.Aggregates.Leads.Events;

public class LeadCreatedEvent : IDomainEvent
{
	public Guid Id { get; }

	public LeadCreatedEvent(Guid id)
	{
		Id = id;
	}
}
