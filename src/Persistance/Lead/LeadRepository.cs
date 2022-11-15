namespace Persistence.Lead;

internal class LeadRepository : 
	Framework.EntityFrameworkCore.Repository<Domain.Aggregates.Leads.Lead>, ILeadRepository
{
	public LeadRepository(DatabaseContext databaseContext) : base(databaseContext)
	{
	}
}
