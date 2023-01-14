using Cyrus.CQRS;
using Cyrus.DDD;
using Persistence.Lead;

namespace Persistence;

public class DatabaseContext : DbContext
{
	private static readonly System.Type[] EnumerationTypes =
	{ typeof(Domain.Aggregates.Leads.ValueObjects.Industry), 
	  typeof(Domain.Aggregates.Leads.ValueObjects.LeadSource),
	  typeof(Domain.Aggregates.Leads.ValueObjects.LeadStatus),
	  typeof(Domain.Aggregates.Leads.ValueObjects.Rating),
	  typeof(Domain.SharedKernel.Salutation)
	};
	private readonly IMessages _messages;

	public DatabaseContext(DbContextOptions<DatabaseContext> options,IMessages Messages) : base(options)
	{
		_messages = Messages;
	}

	public DbSet<Domain.Aggregates.Leads.Lead> Leads { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly
			(typeof(LeadConfiguration).Assembly);
	}

	public override
		async
		System.Threading.Tasks.Task<int>
		SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default)
	{
		// **************************************************
		// Very Important CODE! Credit : Dariush Tasdighi
		// **************************************************
		var enumerationEntries =
			ChangeTracker.Entries()
			.Where(current => EnumerationTypes.Contains(current.Entity.GetType()));

		foreach (var enumerationEntry in enumerationEntries)
		{
			enumerationEntry.State =
				EntityState.Unchanged;
		}
		// **************************************************

		int affectedRows =
			await base.SaveChangesAsync(cancellationToken: cancellationToken);

		if (affectedRows > 0)
		{
			var aggregateRoots =
				ChangeTracker.Entries()
				.Where(current => current.Entity is IAggregateRoot)
				.Select(current => current.Entity as IAggregateRoot)
				.ToList()
				;

			foreach (var aggregateRoot in aggregateRoots)
			{
				// Dispatch Events!
				foreach (var domainEvent in aggregateRoot.DomainEvents)
				{
					await _messages.PublishAsync(domainEvent, cancellationToken);
				}

				// Clear Events!
				aggregateRoot.ClearDomainEvents();
			}
		}

		return affectedRows;
	}

}