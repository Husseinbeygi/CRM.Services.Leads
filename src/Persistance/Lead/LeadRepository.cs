using ViewModels.Lead;

namespace Persistence.Lead;

internal class LeadRepository :
	Framework.EntityFrameworkCore.Repository<Domain.Aggregates.Leads.Lead>, ILeadRepository
{
	private readonly DatabaseContext databaseContext;

	public LeadRepository(DatabaseContext databaseContext) : base(databaseContext)
	{
		this.databaseContext = databaseContext;
	}

}
