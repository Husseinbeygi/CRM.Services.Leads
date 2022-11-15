using Persistence.Lead;

namespace Persistence;

public interface IUnitOfWork : Framework.DDD.IUnitOfWork
{
	public ILeadRepository LeadRepository { get; }
}
