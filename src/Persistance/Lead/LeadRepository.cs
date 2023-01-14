using Cyrus.EntityFrameworkCore.SqlServer;
using ViewModels.Lead;

namespace Persistence.Lead;

internal class LeadRepository :
	Repository<Domain.Aggregates.Leads.Lead>, ILeadRepository
{
	private readonly DatabaseContext databaseContext;

	public LeadRepository(DatabaseContext databaseContext) : base(databaseContext)
	{
		this.databaseContext = databaseContext;
	}

}
