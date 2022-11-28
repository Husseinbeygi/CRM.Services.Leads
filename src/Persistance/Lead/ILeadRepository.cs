using ViewModels.Lead;

namespace Persistence.Lead;

public interface ILeadRepository : Framework.DDD.IRepository<Domain.Aggregates.Leads.Lead>
{
}
