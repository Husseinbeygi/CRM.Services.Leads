namespace Domain.SeedWork
{
	public abstract class AggregateRoot : Entity, Cyrus.DDD.IAggregateRoot
	{
		protected AggregateRoot() : base()
		{
			_domainEvents =
				new System.Collections.Generic.List<Cyrus.DDD.IDomainEvent>();
		}

		// **********
		[System.Text.Json.Serialization.JsonIgnore]
		private readonly List<Cyrus.DDD.IDomainEvent> _domainEvents;

		[System.Text.Json.Serialization.JsonIgnore]
		public IReadOnlyList<Cyrus.DDD.IDomainEvent> DomainEvents
		{
			get
			{
				return _domainEvents;
			}
		}
		// **********

		protected void RaiseDomainEvent(Cyrus.DDD.IDomainEvent domainEvent)
		{
			if (domainEvent is null)
			{
				return;
			}

			// **************************************************
			_domainEvents?.Add(domainEvent);
			// **************************************************

		}

		protected void RemoveDomainEvent(Cyrus.DDD.IDomainEvent domainEvent)
		{
			if (domainEvent is null)
			{
				return;
			}

			// **************************************************
			_domainEvents?.Remove(domainEvent);
			// **************************************************
		}

		public void ClearDomainEvents()
		{
			// **************************************************
			_domainEvents?.Clear();
			// **************************************************
		}
	}
}
