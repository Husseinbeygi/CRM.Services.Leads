using ViewModels.Lead;

namespace Persistence.Lead;

public interface ILeadRepository : Cyrus.DDD.IRepository<Domain.Aggregates.Leads.Lead>
{
}
