using Persistence.Lead;

namespace Persistence;

public interface IUnitOfWork : Cyrus.DDD.IUnitOfWork
{
	public ILeadRepository LeadRepository { get; }
}
