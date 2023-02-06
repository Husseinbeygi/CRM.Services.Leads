using Cyrus.CQRS.Contracts;
using Domain.Aggregates.Leads.Events;
using MassTransit;
using Messages.History.Contracts;
using Messages.History.Enums;

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
		var history = new HistoryMessage
		{
			ActionType = (uint)ActionType.Create,
			Action = "Create",
			ActionDate = DateTime.UtcNow,
			ActionTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
			BusinessUnitId = @event.TenantId,
			CreatedById = @event.CreatedById,
			TenantId = @event.TenantId,
			CreatedTimestamp = @event.CreatedAt,
			ModifyTimestamp = @event.ModifiedAt,
			IsUndeletable = true,
			ModifiedById = @event.ModifiedById,
			ObjectId = @event.Id,
			ObjectType = "Lead",
			TraceId = Guid.NewGuid(),
			Version = 1M,
			OwnerId = @event.OwnerId,
			ModifiedDateTime = Cyrus.DateTime
					.DateTime.FromUnixUtcTimeMilliseconds(@event.ModifiedAt),
			CreatedDateTime = Cyrus.DateTime
					.DateTime.FromUnixUtcTimeMilliseconds(@event.CreatedAt),
		};
		await _bus.Publish(history, cancellationToken);
	}
}
