using Cyrus.DDD;

namespace Domain.Aggregates.Leads.Events;

public class LeadCreatedEvent : IDomainEvent
{
	public Guid Id { get; }
	public Guid TenantId { get; }
	public Guid OwnerId { get; }
	public Guid CreatedById { get; }
	public Guid ModifiedById { get; }
	public long CreatedAt { get;  }
	public long ModifiedAt { get;  }

	public LeadCreatedEvent
	(Guid id, Guid tenantId, Guid ownerId, Guid createdById, Guid modifiedById, long createdAt, long modifiedAt)
	{
		Id = id;
		TenantId = tenantId;
		OwnerId = ownerId;
		CreatedById = createdById;
		ModifiedById = modifiedById;
		CreatedAt = createdAt;
		ModifiedAt = modifiedAt;
	}
}
